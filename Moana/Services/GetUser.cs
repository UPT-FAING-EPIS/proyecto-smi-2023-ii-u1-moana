using Supabase;
using Supabase.Storage.Exceptions;
using System;
using System.Threading.Tasks;
using Moana.Models;
namespace Moana
{
    public interface IUserService
    {
        Task<Postgrest.Responses.ModeledResponse<Moana.Models.User>> GetUser(string email);
    }

    public class UserService : IUserService
    {
        private readonly Supabase.Client _supabase;

        public UserService(Supabase.Client supabase)
        {
            _supabase = supabase ?? throw new ArgumentNullException(nameof(supabase));
        }

        public async Task<Postgrest.Responses.ModeledResponse<Moana.Models.User>> GetUser(string email)
        {
            try
            {
                var user = await _supabase
                    .From<User>()
                    .Select("name,rolid")
                    .Where(x => x.Email == email)
                    .Get();
                return user;

            }
            catch
            {
                return null;
            }
        }
        public async Task<List<User>> GetPatients()
        {
            try
            {
                var patients = await _supabase
                    .From<User>()
                    .Select("name")
                    .Where(x => x.rolId == 4)
                    .Get();
                return patients.Models;
            }
            catch
            {
                return new List<User>();
            }
        }


    }
}