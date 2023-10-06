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
        Task<List<User>> GetPatients();
        Task<(bool success, string errorMessage)> CreatePatient(string email, string password, string name);
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

        public async Task<(bool success, string errorMessage)> CreatePatient(string email, string password, string name)
        {
            try
            {
                var existingUser = await _supabase
                    .From<User>()
                    .Select("id")
                    .Where(x => x.Email == email)
                    .Get();
                Console.WriteLine(existingUser.ToString());
                if (existingUser == null)
                {
                    var user = new User
                    {
                        Email = email,
                        Name = name,
                    };

                    var insertResult = await _supabase
                        .From<User>()
                        .Insert(user);
                    Console.WriteLine(insertResult.Model.ToString());
                    if (insertResult != null)
                    {
                       
                        var session = await _supabase.Auth.SignUp(email, password);

                        if (session != null)
                        {
                            return (true, null); 
                        }
                        else
                        {

                            await _supabase
                            .From<User>()
                            .Where(x => x.Email == email)
                            .Delete();
                            return (false, "Error al registrar al usuario en la autenticación de Supabase.");
                        }
                    }
                }

                return (false, "Ya existe un usuario con el mismo correo electrónico.");
            }
            catch (Exception ex)
            {
                return (false, ex.Message); 
            }
        }
    }
}