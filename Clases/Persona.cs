using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace listas_cSharp.Clases
{
    public class Persona
    {
        private string ?  idPerson;
        private string ? name;
        private int age;
        private string ? email;

        public string IdPerson { get => this.idPerson ?? String.Empty; set => idPerson = value; }
        public string Name { get => this.name ?? String.Empty; set => name = value; }
        public int Age { get => this.age; set => age = value; }
        public string Email { get => this.email ?? String.Empty; set => email = value; }

        public Persona(string idPerson, string name, int age, string email){
            this.IdPerson = GenerateShortId(Guid.NewGuid().ToString()); 
            this.Name =  name;
            this.Age = age; 
            this.Email = email;
        }
        public Persona(){
            this.IdPerson = GenerateShortId(Guid.NewGuid().ToString());
        }

        public static string GenerateShortId(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input));
                string base64String = Convert.ToBase64String(hashBytes);
                string shortId = base64String.Substring(0, 8); // Acorta a los primeros 8 caracteres
                return shortId;
            }
        }

        /*Validar email regex*/
        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

    }
}