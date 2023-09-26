using Supabase;
using Supabase.Storage.Exceptions;
using System;
using System.Threading.Tasks;

namespace Moana
{
    public interface IAuthenticationService
    {
        Task<string> Authenticate(string email, string password);
    }

    public class AuthenticationService : IAuthenticationService
    {
        private readonly Supabase.Client _supabase;

        public AuthenticationService(Supabase.Client supabase)
        {
            _supabase = supabase ?? throw new ArgumentNullException(nameof(supabase));
        }

        public async Task<string> Authenticate(string email, string password)
        {
            try{
                var response = await _supabase.Auth.SignIn(email, password);
                
                Console.WriteLine(response.User);
                if(response==null){
                    return "false";
                }
                
                var user = _supabase.Auth.CurrentUser;
                return user.Email;
            }catch{
                return "false";
            }
        }

    }
}
