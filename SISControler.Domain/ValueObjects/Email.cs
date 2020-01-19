using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SISControler.Domain.ValueObjects
{
    public class Email
    {
        #region[Propriedades]

        public string email { get; private set; }

        #endregion

        #region[Contrutores]

        public Email(string Email )
        {
            IsValidEmail(Email);
            IsValid(Email);
            email = Email;
        }

        #endregion

        #region[Métodos]

        public static void IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException(email, "verifique o parametro email");
        }

        public bool IsValid(string email)
        {
            return Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        }

        #endregion
    }
}
