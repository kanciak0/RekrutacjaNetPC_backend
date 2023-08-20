namespace NetPcRekrutacjaBackend.Domain.Employee
{
    public class Employee
    {
        public Guid Id { get; set; }
        public Details Details { get; set; }
        public Contact Contact { get; set; }

        public Employee(Details details, Contact contact)
        {
            Id = Guid.NewGuid();
            Details = details;
            Contact = contact;
        }
        protected Employee()
        {

        }
    }
}

