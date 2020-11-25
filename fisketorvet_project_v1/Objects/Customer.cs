using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fisketorvet_project_v1.Pages
{
    public class Customer
    {
        private int _id;
        private string _name;
        private string _address;
        private string _bankNo;
        private string _email;
        private string _pass;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        public string BankNo
        {
            get { return _bankNo; }
            set { _bankNo = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string Password
        {
            get { return _pass; }
            set { _pass = value; }
        }
    }
}
