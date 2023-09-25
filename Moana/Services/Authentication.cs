using Supabase;
using Websocket.Client;
namespace Moana
{
    public class AuthenticationService
    {
        private readonly Supabase.Client _supabase;
        public AuthenticationService()
        {
            var url = "https://aedefiwrqctkhakwuhqb.supabase.co/";
            var key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImFlZGVmaXdycWN0a2hha3d1aHFiIiwicm9sZSI6ImFub24iLCJpYXQiOjE2OTU2MTQ4NTYsImV4cCI6MjAxMTE5MDg1Nn0.-Irt1RDGROoKmJyrNdcCUNiIuUMoZWcXP1QRDpPI0sM";
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