namespace NetPcRekrutacjaBackend.Domain.Employee
{
    public class Contact
    {
        private string _subcategory;
        public ContactCategory Category { get; set; }
        public string Subcategory
        {
            get { return _subcategory; }
            set
            {
                if (Category == ContactCategory.Business)
                {
                    if (value != "boss" && value != "client" && value != "management")
                    {
                        throw new ArgumentException("Invalid subcategory for Business category");
                    }
                }
                else if (Category == ContactCategory.Private)
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        throw new ArgumentException("Subcategory must be empty for Private category");
                    }
                }
                _subcategory = value;
            }
        }
        public enum ContactCategory
        {
            Business,
            Private,
            Other
        }
    }
}
