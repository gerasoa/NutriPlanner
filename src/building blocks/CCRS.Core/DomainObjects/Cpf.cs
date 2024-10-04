using CCRS.Core.Tools;

namespace CCRS.Core.DomainObjects
{
    public class Cpf
    {
        //EF Relation
        protected Cpf() { }

        public Cpf(string number)
        {
           if(!IsValidCpf(number)) throw new DomainException("Invalid CPF");
            Number = number;
        }

        public static bool IsValidCpf(string cpf)
        {
            // Remove non-numeric characters (e.g., dots, hyphens)
            //cpf = new string(cpf.Where(char.IsDigit).ToArray());
            cpf = cpf.NumbersOnly(cpf);

            // CPF must have 15 digits
            if (cpf.Length != 11)
                return false;

            // Check if all digits are the same (invalid CPF)
            if (cpf.Distinct().Count() == 1)
                return false;

            // Calculate the first check digit
            int[] multiplier1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int sum = 0;

            for (int i = 0; i < 9; i++)
                sum += int.Parse(cpf[i].ToString()) * multiplier1[i];

            int remainder = sum % 11;
            int firstCheckDigit = remainder < 2 ? 0 : 11 - remainder;

            // Calculate the second check digit
            int[] multiplier2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            sum = 0;

            for (int i = 0; i < 10; i++)
                sum += int.Parse(cpf[i].ToString()) * multiplier2[i];

            remainder = sum % 11;
            int secondCheckDigit = remainder < 2 ? 0 : 11 - remainder;

            // Verify if the calculated check digits match the input
            return cpf[9].ToString() == firstCheckDigit.ToString() &&
                   cpf[10].ToString() == secondCheckDigit.ToString();

        }

        public const int cpfLength = 15;

        public string Number { get; private set; }

    }
}
