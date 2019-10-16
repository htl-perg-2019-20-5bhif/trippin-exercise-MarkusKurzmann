using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TrippinExample.DTO;

namespace TrippinExample
{
    class Program
    {

        private static HttpClient HttpClient = new HttpClient() { BaseAddress = new Uri("https://services.odata.org/TripPinRESTierService/(S(zt1wf2wxake11fhzmtbgxogi))/") };

        static async Task Main(string[] args)
        {
            await AddUsersToTrippin();
        }

        public static async Task AddUsersToTrippin()
        {
            var fileContent = await File.ReadAllTextAsync("./Data/users.json");
            IEnumerable<NewPersonDTO> users = JsonSerializer.Deserialize<IEnumerable<NewPersonDTO>>(fileContent);

            //iterate through users
            foreach(var user in users)
            {
                //send GET-Request for user
                var response = await HttpClient.GetAsync("People('" + user.UserName + "')");

                //check wheteher the user exists or not
                if (!response.IsSuccessStatusCode)
                {
                    //user was not found -> add via POST
                    var newUser = new StringContent(JsonSerializer.Serialize(new PersonDTO(user)), Encoding.UTF8, "application/json");
                    var postResult = await HttpClient.PostAsync("People", newUser);
                    try
                    {
                        postResult.EnsureSuccessStatusCode();
                        Console.WriteLine("User with username \"" + user.UserName + "\" was added successfully");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error while adding user \"" + user.UserName + "\"!\n Exception: " + e.GetType().ToString());
                    }
                }else
                {
                    //user was found -> do nothing
                    Console.WriteLine("User with username \"" + user.UserName + "\" already exists!");
                }
            }
        }
    }
}
