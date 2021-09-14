namespace SomosClearMovies.Core.Interfaces
{
    public interface IUserRepository
    {
        bool IsAnExistingUser(string userName);
        bool IsValidUserCredentials(string userName, string password);
        string GetUserRole(string userName);
    }
}
