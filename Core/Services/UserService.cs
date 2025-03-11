namespace Core.Services;

public class UserService
{
    /* private readonly IRepository<User> _userRepository;

    public UserService(IRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task AddTicketToUser(int userId, Ticket ticket)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user == null) throw new Exception("User not found");

        user.Tickets.Add(ticket);
        await _userRepository.SaveChangesAsync();
    }

    public async Task RemoveTicketFromUser(int userId, int ticketId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user == null) throw new Exception("User not found");

        var ticket = user.Tickets.FirstOrDefault(t => t.Id == ticketId);
        if (ticket != null)
        {
            user.Tickets.Remove(ticket);
            await _userRepository.SaveChangesAsync();
        }
    } */


    /*
    

    public void AddTicket(Ticket ticket)
    {   
        Tickets.Add(ticket);
    }

    public bool RemoveTicket(Ticket ticket)
    {   
        Tickets.RemoveAll(e => e.Id == ticket.Id);

    }

    public void RemoveTicket(int ticketId)
    {   
        Tickets.RemoveAll(e => e.Id == ticketId);
    }
    */
}
