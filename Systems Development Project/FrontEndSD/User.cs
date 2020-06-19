
using System;

namespace FrontEndSD
{
    /* Product */
    public abstract class User
    {
        /* Get/Set methods */
        public abstract int ID { get;}
        public abstract string AccountNo { get; }
        public abstract string Username { get; set; }
        public abstract string Password { get; set; }
        public abstract string FirstName { get; set; }
        public abstract string LastName { get; set; }
        public abstract string Email { get; set; }
        public abstract string Address { get; set; }
        public abstract string PostCode { get; set; }
        public abstract DateTime DateOfBirth { get; set; }

        public abstract bool IsStaff { get; }
        public abstract bool IsAdmin { get; }

        public abstract bool IsLoggedIn { get; set; }
        public abstract bool IsDeleted { get; set; }
    }


    /* Creator */
    abstract class UserFactory
    {
        public abstract User CreateUser();
    }



}
