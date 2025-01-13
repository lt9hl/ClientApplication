using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApp
{
    internal class User
    {
        [Key] public int id { get; set; }
        private string login, passworsd, email;
        public string Login
        {
            get { return login; }
            set { this.login = value; }
        }
        public string Password
        {
            get { return passworsd; }
            set { this.passworsd = value; }
        }
        public string Email
        {
            get { return email; }
            set { this.email = value; }
        }
        public User() { }
        public User(string login,string Pass ,string email)
        {

            this.login= login;
            passworsd = Pass;
            this.email = email;
        }
    }
}
