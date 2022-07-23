namespace Middleware_Services.Services
{
    public class TextMessageService : MessagingSenderService
    {
        public override void SendMessage(string message)
        {
            Console.WriteLine("I'm sending " + message + " as a text.");
        }
    }
}
