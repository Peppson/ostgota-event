using BlazorStandAlone.Models;
using System.Net.Http.Json;

namespace BlazorStandAlone.Services;

public interface ITicketService
{
    Task<List<TicketDto>> GetAllTickets();
    TicketDto? GetTicketById(int id);
    Task<bool> CreateTicket(TicketDto ticket);
    Task<bool> DeleteTicket(int id);
    List<TicketDto> Tickets { get; }
    int TicketCount { get; }
}

public class TicketServiceException : Exception
{
    public TicketServiceException(string message, Exception? inner = null)
        :base(message, inner) { }
}

public class TicketService : ITicketService
{
    private readonly HttpClient _httpClient;
    private List<TicketDto> _tickets = new();
    public List<TicketDto> Tickets => _tickets;

    public int TicketCount => _tickets.Count;

    public TicketService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<TicketDto>> GetAllTickets()
    {
        try
        {
            var response = await _httpClient.GetAsync("api/ticket/get");
            if (response.IsSuccessStatusCode)
            {
                _tickets = await response.Content.ReadFromJsonAsync<List<TicketDto>>() ?? new();
                return _tickets;
            }
            throw new TicketServiceException($"Failed to fetch ticket: {response.StatusCode}");
        }
        catch (Exception ex) when (ex is not TicketServiceException)
        {
            throw new TicketServiceException("An error occurred while fetching ticket", ex);
        }
    }

    public TicketDto? GetTicketById(int id)
    {
        return _tickets.FirstOrDefault(t => t.Id == id);
    }
    public async Task<bool> CreateTicket(TicketDto ticket)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("api/ticket/create", ticket);
            if (response.IsSuccessStatusCode)
            {
                await GetAllTickets();
                return true;
            }
            throw new TicketServiceException($"Failed to create ticket: {response.ReasonPhrase}");
        }
        catch (Exception ex) when (ex is not TicketServiceException)
        {
            throw new TicketServiceException("An error occurred while creating ticket", ex);
        }
    }
    
    public async Task<bool> DeleteTicket(int id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"api/ticket/delete/{id}");
            if(response.IsSuccessStatusCode)
            {
                await GetAllTickets();
                return true;
            }
            throw new TicketServiceException($"Failed to delete ticket: {response.StatusCode}");
        }
        catch(Exception ex) when (ex is not TicketServiceException)
        {
            throw new TicketServiceException("An error occured while deleting ticket",ex);
        }
    }
}
