namespace NetPcRekrutacjaBackend.Domain.Employee
{
    public class Details
    {
        private string _phoneNumber;
        private DateTime _birthdate;
        private string _password;
        public Details(string name, string surname, string email, string password, string phoneNumber, DateTime birthdate)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
            Birthdate = birthdate;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password
        {
            get { return _password; }
            set
            {
                if (!IsValidPassword(value))
                {
                    throw new ArgumentException("Invalid password");
                }
                _password = value;
            }
        }
        public DateTime Birthdate
        {
            get { return _birthdate; }
            set
            {
                if (!IsValidBirthdate(value))
                {
                    throw new ArgumentException("Invalid birthdate");
                }
                _birthdate = value;
            }
        }
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                if (!IsValidPhoneNumber(value))
                {
                    throw new ArgumentException("Invalid phone number");
                }
                _phoneNumber = value;
            }
        }
        // Validation methods
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return !string.IsNullOrWhiteSpace(phoneNumber) && phoneNumber.Length >= 9;
        }

        private bool IsValidBirthdate(DateTime birthdate)
        {
            return birthdate <= DateTime.Now;
        }

        private bool IsValidPassword(string password)
        {
            return !string.IsNullOrWhiteSpace(password) &&
                   password.Length >= 8 &&
                   password.Any(char.IsUpper) &&
                   password.Any(char.IsLower) &&
                   password.Any(char.IsDigit);
        }
    }
}
