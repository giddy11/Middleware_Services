namespace Middleware_Services.TypesOfServices
{
    public class Transient : ParentTransient
    {
        public Transient()
        {
            Console.WriteLine("Transient Class Constructor called");
        }
    }
}
