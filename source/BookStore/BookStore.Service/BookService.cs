using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BookStore.Model;
using Newtonsoft.Json;
using System.Configuration;

namespace BookStore.Service
{
   public class BookService : IBookService
    {
        private readonly HttpClient _httpClient;
        public  BookService( HttpClient httpClient)
        {
            //_httpClient = new HttpClient();
            _httpClient = httpClient;
        }

        public async Task <List<Owner>> GetData()
        {
            try
            {
                var appurl = ConfigurationManager.AppSettings["BookStoreApiUrl"];
                var response = await  _httpClient.GetAsync(appurl);
                response.EnsureSuccessStatusCode();

                if (!response.IsSuccessStatusCode)
                {
                    // Handle non-success status codes
                    if (response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        return new List<Owner>(); // Return an empty list for Bad Request
                    }

                    response.EnsureSuccessStatusCode(); // Throw exception for other status codes
                }

                var responseContent = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrWhiteSpace(responseContent))
                {
                    return new List<Owner>();
                }

                var owners = JsonConvert.DeserializeObject<List<Owner>>(responseContent);
                return owners ?? new List<Owner>();

            }

            catch (Exception ex)
            {
                return new List<Owner>();
            }
        }
    }
}
