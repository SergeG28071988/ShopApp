using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp
{
    class User
    {
        public int id { get; set; }

        private string name, login, pass, email;

        public string Name
        {
            get { return name;}
            set { name = value;}
        }

        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        public string Pass
        {
            get { return pass; }
            set { pass = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public User() { }
        public User (string name, string login, string pass, string email)
        {
            this.login = login;
            this.name = name;
            this.pass = pass;
            this.email = email;
        }

        //public override string ToString()
        //{
        //    return "Пользователь:  " + Name + ". Email:  " + Email;
        //}
    }
}
