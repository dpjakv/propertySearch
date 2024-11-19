using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using PropertyApi.Models;
using Newtonsoft.Json;

namespace PropertyService
{
    public class PropertyData
    {
        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
        }
        public static async Task<string> GetJsonFromAzureBlob()
        {
            // Store these constants elsewhere. SAS token would be queries in real time. Shouldn't be stored.
            const string blobUrl = "https://nmrkpidev.blob.core.windows.net/dev-test/dev-test.json";
            const string sasToken = "?sp=r&st=2024-10-28T10:35:48Z&se=2025-10-28T18:35:48Z&spr=https&sv=2022-11-02&sr=b&sig=bdeoPWtefikVgUGFCUs4ihsl22ZhQGu4%2B4cAfoMwd4k%3D";

            // Create a BlobClient
            BlobClient blobClient = new BlobClient(new Uri($"{blobUrl}?{sasToken}"));

            try
            {
                // Downloading the blob's content as a stream
                BlobDownloadInfo download = await blobClient.DownloadAsync();

                string jsonContent = "";

                // Reading the stream as a string
                using (StreamReader reader = new StreamReader(download.Content))
                {
                    jsonContent = await reader.ReadToEndAsync();

                    // Optionally, parse the JSON content
                    var jsonDocument = JsonDocument.Parse(jsonContent);

                    // Define the file path
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", "output.json");

                    // Ensure the directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                    // Write to the file
                    using (StreamWriter writer = new StreamWriter(filePath, append: true))
                    {
                        writer.WriteLine(jsonDocument.RootElement.ToString());
                        writer.WriteLine($"Timestamp: {DateTime.Now}");
                    }

                    Console.WriteLine("File written successfully!");
                }
                List<Property> properties = JsonConvert.DeserializeObject<List<Property>>(jsonContent);

                return jsonContent;
                
            }
            catch (Exception ex)
            {
                // Log Error for observability. Prometheus/ Grafana?
                Console.WriteLine($"Error accessing blob: {ex.Message}");
                return "";
            }
        }
    }
}

