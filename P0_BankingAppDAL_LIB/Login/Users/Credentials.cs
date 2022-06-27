namespace P0_BankingAppDAL_LIB.Login.Users
{
    public class Credentials
    {
        public string userName { get; set; }
        public string userPassword { get; set; }
        public bool accountIsActive { get; set; }
        public int loginAttempts { get; set; }
        // [WIP] public int userPin { get; set; } // used in post-login operations to validate before transacting with DB
        public int userIsAdmin { get; set; } // Admin = 1; Customer = 0
        public int customerId { get; set; }
    }

}
