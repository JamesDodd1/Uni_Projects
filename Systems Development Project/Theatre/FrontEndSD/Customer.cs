
using System;

namespace FrontEndSD
{
    /* ContreteProduct */
    class Customer : User
    {
        /* Declare variables */
        private int id;
        private string accountNo, username, password, firstName, lastName, email, address, postCode;
        private DateTime dateOfBirth;

        private bool isStaff, isAdmin, isLoggedIn, isDeleted;


        /* Default constructor */
        public Customer()
        {
            this.id = 0;
            this.accountNo = null;
            this.username = null;
            this.password = null;
            this.firstName = null;
            this.lastName = null;
            this.email = null;
            this.address = null;
            this.postCode = null;
            this.dateOfBirth = new DateTime();

            this.isStaff = false;
            this.isAdmin = false;

            this.isLoggedIn = true;
            this.isDeleted = false;
        }


        public Customer(int id, string accountNo, string username, string password, string firstName, string lastName, string email, string address, string postCode, DateTime dateOfBirth) : this()
        {
            this.id = id;
            this.accountNo = accountNo;
            this.username = username;
            this.password = password;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.address = address;
            this.postCode = postCode;
            this.dateOfBirth = dateOfBirth;
        }


        /* Override get/set methods */
        public override int ID { get => id; }
        public override string AccountNo { get => accountNo; }
        public override string Username { get => username; set => username = value; }
        public override string Password { get => password; set => password = value; }
        public override string FirstName { get => firstName; set => firstName = value; }
        public override string LastName { get => lastName; set => lastName = value; }
        public override string Email { get => email; set => email = value; }
        public override string Address { get => address; set => address = value; }
        public override string PostCode { get => postCode; set => postCode = value; }
        public override DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }

        public override bool IsStaff { get => isStaff; }
        public override bool IsAdmin { get => isAdmin; }

        public override bool IsLoggedIn { get => isLoggedIn; set => isLoggedIn = value; }
        public override bool IsDeleted { get => isDeleted; set => isDeleted = value; }
    }


    /* ConcreteCreator */
    class CustomerFactory : UserFactory
    {
        /* Declare variables */
        private int id;
        private string accountNo, username, password, firstName, lastName, email, address, postCode;
        private DateTime dateOfBirth;


        /* Constructor */
        public CustomerFactory(int id, string accountNo, string username, string password, string firstName, string lastName, string email, string address, string postCode, DateTime dateOfBirth)
        {
            this.id = id;
            this.accountNo = accountNo;
            this.username = username;
            this.password = password;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.address = address;
            this.postCode = postCode;
            this.dateOfBirth = dateOfBirth;
        }


        /* Override method */
        public override User CreateUser()
        {
            return new Customer(id, accountNo, username, password, firstName, lastName, email, address, postCode, dateOfBirth);
        }
    }
}
