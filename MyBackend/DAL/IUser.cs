using MyBackend.DTO;

namespace MyBackend.DAL
{
    public interface IUser
    {
        Task Registration(AddUserDTO user);
        IEnumerable<UserGetDTO> GetAll();
        Task<UserGetDTO> Authenticate(AddUserDTO user);
    }
}
