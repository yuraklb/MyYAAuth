using MyYAAuth.Auth.Api.Models;

namespace MyYAAuth.Auth.Api.Services
{
    public interface IAccountsService
    {
        List<Account> GetAllAccounts();
        Account GetAccount(string email, string password);

    }
    
    public class AccountsService : IAccountsService
    {
        /*
        e2d80add-3db9-465e-b00b-cc0be173d76a
        a834d832-d2b6-44e8-ab1f-bd12423c8fbd
        a9ac59ee-342c-4f7a-a7bb-7f6242bb2ef9
        a8173529-e083-4ee5-8f9b-a1ffee140f5c
        */

        private List<Account> Accounts = new List<Account>()
        {
            new Account()
            {
                Id = Guid.Parse("e2d80add-3db9-465e-b00b-cc0be173d76a"),
                Email = "user@email.com",
                Password = "user",
                Roles = new Role[] { Role.User }
            },
            new Account()
            {
                Id = Guid.Parse("a834d832-d2b6-44e8-ab1f-bd12423c8fbd"),
                Email = "user2@email.com",
                Password = "user2",
                Roles = new Role[] { Role.User }
            },
            new Account()
            {
                Id = Guid.Parse("a9ac59ee-342c-4f7a-a7bb-7f6242bb2ef9"),
                Email = "admin@email.com",
                Password = "admin",
                Roles = new Role[] { Role.Admin }
            }

        };

        public Account GetAccount(string email, string password)
        {
            return this.Accounts.SingleOrDefault(a=>a.Email == email && a.Password == password);
        }

        public List<Account> GetAllAccounts()
        {
            return this.Accounts;
        }
    }
}