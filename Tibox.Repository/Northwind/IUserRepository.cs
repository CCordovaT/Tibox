using Tibox.Models;

namespace Tibox.Repository.Northwind
{
    public interface IUserRepository: IRepository<User>
    {
        User ValidateUser(string email, string password);
    }
}
