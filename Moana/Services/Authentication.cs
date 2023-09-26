using Supabase;
using Websocket.Client;
namespace Moana
{
    public class AuthenticationService
    {
        private readonly Supabase.Client _supabase;
        public AuthenticationService()
        {
            var url = "xd";
            var key = "xd";
            _supabase = new Supabase.Client(url, key);
        }
        public async Task<bool> Authenticate(string email, string password)
        {
            try
            {
                var session = await _supabase.Auth.SignIn(email, password);
                if (session == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
