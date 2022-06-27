using P0_BankingAppDAL_LIB.Login.Users;
using System;
using System.Data.SqlClient;

namespace P0_BankingAppDAL_LIB.Login
{
    public class NewCustomer
    {
        SqlConnection connect = new SqlConnection("server=DESKTOP-D6VGEU1\\TRAINING;database=userAccountDB; user id=bank;password=bank1234");

        public string AddCustomer(Customer p_newCustomer)
        {
            SqlCommand cmdAddCustomer = new SqlCommand("insert into table_name values(@cusFN,@cusLN,@cusPhone,@cusAdd,@cusEmail)", connect);
            //cmdAddCustomer.Parameters.AddWithValue("@cusId", p_newCustomer.customerId);
            cmdAddCustomer.Parameters.AddWithValue("@cusFN", p_newCustomer.customerName);
            //cmdAddCustomer.Parameters.AddWithValue("@cusLN", p_newCustomer.customerLastName);
            cmdAddCustomer.Parameters.AddWithValue("@cusPhone", p_newCustomer.customerPhoneNumber);
            //cmdAddCustomer.Parameters.AddWithValue("@cusAdd", p_newCustomer.customerAddress);
            cmdAddCustomer.Parameters.AddWithValue("@cusEmail", p_newCustomer.customerEmail);

            connect.Open();
            int recordsAdded = (int)cmdAddCustomer.ExecuteScalar();
            connect.Close();
            if (recordsAdded == 0)
            {
                throw new Exception("Customer could not be added");
            }
            return "Customer Infornation Added Succesfull";
        }
    }
}
