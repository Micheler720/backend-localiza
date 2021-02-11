using Entities.Roles;

namespace Entities.Interfaces
{
    public interface IUser
    {
        
        int Id { get; set; }
        string Name { get; set; }        
        string Password { get; set; }
        UserRole UserRole { get; } 

    }
}