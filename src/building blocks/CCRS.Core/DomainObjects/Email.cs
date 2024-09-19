using System.Text.RegularExpressions;

namespace CCRS.Core.DomainObjects
{
    public class Email
    {
        public const int AddressMaxLenght = 254;
        public const int AddressMinLenght = 5;

        public string Address { get; private set; }

        //EF Relation
        protected Email() { }

        public Email(string address)
        {
            if (!IsValid(address)) throw new DomainException("Invalid e-mail");
            Address = address;
        }

        public static bool IsValid(string email)
        {
            var regexEmail = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return regexEmail.IsMatch(email);
        }
    }
}
