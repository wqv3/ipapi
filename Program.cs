using Newtonsoft.Json;

class Program
{
    private static readonly HttpClient hcl = new HttpClient();

    static async Task Main(string[] args)
    {
        Console.Write("url/domain/ip: ");
        string Target = Console.ReadLine();

        //
        if (Target.StartsWith("https://")) { Target = Target.Substring(8); }
        else if (Target.StartsWith("http://")) { Target = Target.Substring(7); }
        Target = Target.TrimEnd('/');
        //

        string ipapi = $"http://ip-api.com/json/{Target}?fields=status,message,continent,continentCode,country,countryCode,region,regionName,city,district,zip,lat,lon,timezone,offset,currency,isp,org,as,asname,reverse,mobile,proxy,hosting,query";

        try
        {
            string response = await hcl.GetStringAsync(ipapi);
            var occur = JsonConvert.DeserializeObject<ResponseItself>(response);

            foreach (var field in typeof(ResponseItself).GetProperties())
            {
                var status = field.GetValue(occur);
                Console.Write($"{field.Name}: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(status);
                Console.ResetColor();
            }

            string outputDir = "outp";
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            string datetime = DateTime.Now.ToString("HH-mm");
            string file = Path.Combine(outputDir, $"{Target}_{datetime}.json");

            await File.WriteAllTextAsync(file, response);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"err: {ex.Message}");
        }

        Console.ReadKey();
    }
}

public class ResponseItself
{
    public string Status { get; set; }
    public string Message { get; set; }
    public string Continent { get; set; }
    public string ContinentCode { get; set; }
    public string Country { get; set; }
    public string CountryCode { get; set; }
    public string Region { get; set; }
    public string RegionName { get; set; }
    public string City { get; set; }
    public string District { get; set; }
    public string Zip { get; set; }
    public float Lat { get; set; }
    public float Lon { get; set; }
    public string Timezone { get; set; }
    public int Offset { get; set; }
    public string Currency { get; set; }
    public string Isp { get; set; }
    public string Org { get; set; }
    public string As { get; set; }
    public string Asname { get; set; }
    public string Reverse { get; set; }
    public bool Mobile { get; set; }
    public bool Proxy { get; set; }
    public bool Hosting { get; set; }
    public string Query { get; set; }
}
