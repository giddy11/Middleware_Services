namespace Middleware_Services.TypesOfServices
{
    public class Scoped : ParentScoped
    {
        public Scoped()
        {
            Console.WriteLine("Scoped Class Constructor called");
        }
    }
}
