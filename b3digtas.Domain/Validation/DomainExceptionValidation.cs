namespace b3digitas.Domain.Validation
{
    public class DomainExceptionValidation : Exception
    {
        public DomainExceptionValidation(string error) : base(error) { }

        public static void When(bool condition, string message)
        {
            if (condition) 
                throw new DomainExceptionValidation(message);
        }

    }
}
