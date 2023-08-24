using course.Entities;

namespace course.Application.Services
{
    public interface IUserService
    {
        User ValidateUser(string username, string password);
    }
}
