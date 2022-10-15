namespace CityInfo.API.Services
{
    public class CloudMailService : ICloudMailService
    {
        public void Send(string mensage)
        {
            Console.WriteLine($"{mensage}");
        }
    }
}
