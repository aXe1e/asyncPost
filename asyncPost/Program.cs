using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;


namespace asyncPost
{
    class Program
    {
        static readonly HttpClient client = new();
        private static readonly string file = "Result.txt";
        private static readonly int StartPost = 4;
        private static readonly int FinishPost = 13;


        static async Task Main()
        {
            File.Delete(file);
            for (int i = StartPost; i <= FinishPost; i++)
            {
                var resultPost = await GetPostAsync(i);
                await File.AppendAllTextAsync(file, resultPost.ToString() + Environment.NewLine);
            }
        }

        private static async Task<Post> GetPostAsync(int postId)
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                var response = await client.GetAsync($"https://jsonplaceholder.typicode.com/posts/{postId}");
                using var responseBody = await response.Content.ReadAsStreamAsync();
                return JsonSerializer.DeserializeAsync<Post>(responseBody).Result;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                throw;
            }
        }
    }
}
