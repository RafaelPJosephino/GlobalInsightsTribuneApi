using GlobalInsightsTribune.Application.DTOs;

namespace GlobalInsightsTribune.Application.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserDTO> GetUserAll();
        void RegisterUser(UserDTO user);
    }
}
