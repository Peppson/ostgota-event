using BlazorStandAlone.Models;
using System.Net.Http.Json;

namespace BlazorStandAlone.Services;

public interface IEventService
{
    Task<List<EventDto>> GetAllEvents();
    EventDto? GetEventById(int id);
    Task<bool> CreateEvent(EventDto eventDto);
    Task<bool> UpdateEvent(EventDto eventDto);
    Task<bool> DeleteEvent(int id);
    List<EventDto> Events { get; }
    int EventCount { get; }
}

public class EventServiceException : Exception
{
    public EventServiceException(string message, Exception? inner = null)
    : base(message, inner) { }
}

public class EventService : IEventService
{

    private readonly HttpClient _httpClient;
    private List<EventDto> _events = new();
    public List<EventDto> Events => _events;

    public int EventCount => _events.Count;

    public EventService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<EventDto>> GetAllEvents()
    {
        try
        {
            var response = await _httpClient.GetAsync("api/event/get");
            if (response.IsSuccessStatusCode)
            {
                _events = await response.Content.ReadFromJsonAsync<List<EventDto>>() ?? new();
                return _events;
            }
            throw new EventServiceException($"Failed to fetch event: {response.StatusCode}");
        }
        catch (Exception ex) when (ex is not EventServiceException)
        {
            throw new EventServiceException("An error occurred while fetching event", ex);
        }
    }
    public EventDto? GetEventById(int id)
    {
        return _events.FirstOrDefault(e => e.Id == id);
    }

    public async Task<bool> CreateEvent(EventDto eventDto)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("api/event/create", eventDto);
            if (response.IsSuccessStatusCode)
            {
                await GetAllEvents();
                return true;
            }
            throw new EventServiceException($"Failed to create event: {response.ReasonPhrase}");
        }
        catch (Exception ex) when (ex is not EventServiceException)
        {
            throw new EventServiceException("An error occurred while creating event", ex);
        }
    }

    public async Task<bool> UpdateEvent(EventDto eventDto)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync($"api/event/update/{eventDto.Id}", eventDto);
            if (response.IsSuccessStatusCode)
            {
                await GetAllEvents();
                return true;
            }
            throw new EventServiceException($"Failed to update event: {response.StatusCode}");
        }
        catch (Exception ex) when (ex is not EventServiceException)
        {
            throw new EventServiceException("An error occurred while updating event", ex);
        }
    }


    public async Task<bool> DeleteEvent(int id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"api/event/delete/{id}");
            if (response.IsSuccessStatusCode)
            {
                await GetAllEvents();
                return true;
            }
            throw new EventServiceException($"Failed to delete event: {response.StatusCode}");
        }
        catch (Exception ex) when (ex is not EventServiceException)
        {
            throw new EventServiceException("An error occurred while deleting event", ex);
        }
    }
}
