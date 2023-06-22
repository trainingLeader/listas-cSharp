using System;
using System.Collections.Generic;
using System.Linq;
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
            this.IdPerson = idPerson; 
            this.Name =  name;
            this.Age = age; 
            this.Email = email;
        }
        public Persona(){
        }

    }
}