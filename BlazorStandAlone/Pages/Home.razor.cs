using BlazorStandAlone.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System.Globalization;
using System.Net.Http.Json;

namespace BlazorStandAlone.Pages
{
    public partial class Home
    {
        private void GoToCheckout(int eventId)
        {
            NavigationManager.NavigateTo($"/checkout/{eventId}");
        }

        // PAGINATION
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 4;

        // Making sure there's always at least one page
        public int TotalPages => Math.Max(1, (int)Math.Ceiling((double)FilteredEvents.Count / PageSize));

        // Skip and take to get the next set of events
        public List<EventDto> EventPages => FilteredEvents.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();
        public List<EventDto> events { get; set; } = new();

        // Bools for the onclick
        public bool IsNextDisabled => CurrentPage == TotalPages;
        public bool IsPreviousDisabled => CurrentPage == 1;

        public async Task NextPage()
        {
            if (CurrentPage < TotalPages)
            {
                CurrentPage++;
                await JS.InvokeVoidAsync("scrollToEventSection");
            }
        }

        public void PreviousPage()
        {
            if (CurrentPage > 1)
            {
                CurrentPage--;
            }
        }

        // GET EVENTS
        public string searchEvent { get; set; } = "";
        public List<EventDto> FilteredEvents { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            await GetEventsAsync();
            FilteredEvents = new List<EventDto>(events);
            SortEvents("date");
        }

        private async Task GetEventsAsync()
        {
            try
            {
                var response = await HttpClient.GetAsync("api/event/get");
                if (response.IsSuccessStatusCode)
                {
                    events = await response.Content.ReadFromJsonAsync<List<EventDto>>() ?? new();
                    FilteredEvents = new List<EventDto>(events);
                    StateHasChanged();
                }
                else
                {
                    Console.WriteLine($"Error fetching events: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception while fetching events: {ex.Message}");
            }
        }

        // Filter logic
        private void FilterEvents()
        {
            if (!string.IsNullOrWhiteSpace(searchEvent))
            {
                string searchLower = searchEvent.ToLower();

                FilteredEvents = events.Where(e =>
                    e.Name.ToLower().Contains(searchLower) ||
                    e.City.ToLower().Contains(searchLower) ||
                    e.Address.ToLower().Contains(searchLower) ||
                    e.Description.ToLower().Contains(searchLower) ||
                    e.StartTime.ToString("yyyy-MM-dd").Contains(searchLower) ||
                    e.StartTime.ToString("dd-MM").Contains(searchLower) ||
                    e.StartTime.ToString("MMMM", new CultureInfo("sv-SE")).ToLower().Contains(searchLower)
                ).ToList();
                CurrentPage = 1;
            }
            else
            {
                FilteredEvents = new List<EventDto>(events);
            }
            SortEvents("");
            StateHasChanged();
            searchEvent = "";
        }

        private void HandleSearchKeyPress(KeyboardEventArgs e)
        {
            if (e.Key == "Enter")
            {
                FilterEvents();
                searchEvent = "";
            }
        }

        // Sort method

        private void SortEvents(string sortBy)
        {
            switch (sortBy)
            {
                case "date":
                case "":
                default:
                    FilteredEvents = FilteredEvents.OrderBy(e => e.StartTime).ToList();
                    break;
                case "date-desc":
                    FilteredEvents = FilteredEvents.OrderByDescending(e => e.StartTime).ToList();
                    break;
                case "name":
                    FilteredEvents = FilteredEvents.OrderBy(e => e.Name).ToList();
                    break;
                case "name-desc":
                    FilteredEvents = FilteredEvents.OrderByDescending(e => e.Name).ToList();
                    break;
                case "city":
                    FilteredEvents = FilteredEvents.OrderBy(e => e.City).ToList();
                    break;
                case "city-desc":
                    FilteredEvents = FilteredEvents.OrderByDescending(e => e.City).ToList();
                    break;
                case "availability":
                    FilteredEvents = FilteredEvents.OrderByDescending(e => (e.TicketsMax ?? 0) - e.TicketsSold).ToList();
                    break;
                case "availability-desc":
                    FilteredEvents = FilteredEvents.OrderBy(e => (e.TicketsMax ?? 0) - e.TicketsSold).ToList();
                    break;
                case "size":
                    FilteredEvents = FilteredEvents.OrderBy(e => e.TicketsMax ?? int.MinValue).ToList();
                    break;
                case "size-desc":
                    FilteredEvents = FilteredEvents.OrderByDescending(e => e.TicketsMax ?? int.MinValue).ToList();
                    break;
            }
            CurrentPage = 1;
            StateHasChanged();
        }

        // OPEN SHOW MORE INFO MODAL
        private bool isModalVisible = false;
        private EventDto? selectedEvent;

        private void OpenModal(EventDto currentEvent)
        {
            selectedEvent = currentEvent;
            isModalVisible = true;
        }

        private void CloseModal()
        {
            isModalVisible = false;
        }

        // Login logic
        private LoginDto? user;

        protected async Task OnIntializedAsync()
        {
            var result = await SessionStorage.GetItemAsync<User>("user");

            if (result != null)
            {
                user = new LoginDto() { Username = result.Username };
            }
            else
            {
                NavigationManager.NavigateTo("/login");
            }
        }
    }
}