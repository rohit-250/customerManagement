using customerManagement.Models;
using System.Data;
using System.Data.SqlClient;

namespace customerManagement.Models
{
    public interface IDataBaseService
    {
        string createCustomer(CustomerDetails customer);
        string updateCustomer(Customer customer);
        string deleteCustomer(int customerId);
        Customer? getCustomerById(int customerId);
        List<Customer> getAllCustomer();

    }
    public class DataBaseService : IDataBaseService
    {
        private readonly string _conncetionString;

        public DataBaseService(string conncetionString)
        {
            _conncetionString = conncetionString;
        }
        public string createCustomer(CustomerDetails customer)
        {
            try
            {
                using (var connection = new SqlConnection(_conncetionString))
                {

                    using (var cmd = new SqlCommand("sp_InsertCustomer", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@name", customer.CustomerName);
                        cmd.Parameters.AddWithValue("@address", customer.CustomerAddress);
                        cmd.Parameters.AddWithValue("@email", customer.CustomerEmail);
                        cmd.Parameters.AddWithValue("@mobileNo", customer.CustomerMobileNo);
                        cmd.Parameters.AddWithValue("@geoLocation", customer.GeoLocation);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        return ("inserted");
                    }

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        //Display BY Id
        public Customer? getCustomerById(int customerId)
        {
            var customer = new Customer();
            try
            {
                using (var connection = new SqlConnection(_conncetionString))
                {

                    using (var cmd = new SqlCommand("sp_GetByCode", connection))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@customerCode", customerId);

                        connection.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            customer.Id = (int)dr["CustomerCode"];

                            customer.Details = new CustomerDetails
                            {

                                CustomerName = dr["Name"].ToString(),
                                CustomerAddress = dr["Address"].ToString(),
                                CustomerEmail = dr["Email"].ToString(),
                                CustomerMobileNo = dr["MobileNo"].ToString(),
                                GeoLocation = dr["GeoLocation"].ToString()
                            };
                        }
                        connection.Close();
                        if (customer.Id == 0 && customer.Details == null)
                        {
                            return null;
                        }
                        return customer;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public List<Customer> getAllCustomer()
        {
            var customerList = new List<Customer>();
            try
            {

                using (var connection = new SqlConnection(_conncetionString))
                {

                    using (var cmd = new SqlCommand("sp_Getall", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            Customer customer = new Customer();

                            customer.Id = (int)dr["CustomerCode"];
                            customer.Details = new CustomerDetails
                            {

                                CustomerName = dr["Name"].ToString(),
                                CustomerAddress = dr["Address"].ToString(),
                                CustomerEmail = dr["Email"].ToString(),
                                CustomerMobileNo = dr["MobileNo"].ToString(),
                                GeoLocation = dr["GeoLocation"].ToString()

                            };
                            customerList.Add(customer);
                        }
                        connection.Close();
                        return customerList;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public string updateCustomer(Customer customer)
        {
            string result = "";
            try
            {

                using (var connection = new SqlConnection(_conncetionString))
                {

                    using (var cmd = new SqlCommand("sp_UpdateCustomer", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@customerCode", customer.Id);
                        cmd.Parameters.AddWithValue("@name", customer.Details?.CustomerName);
                        cmd.Parameters.AddWithValue("@address", customer.Details?.CustomerAddress);
                        cmd.Parameters.AddWithValue("@email", customer.Details?.CustomerEmail);
                        cmd.Parameters.AddWithValue("@mobileNo", customer.Details?.CustomerMobileNo);
                        cmd.Parameters.AddWithValue("@geoLocation", customer.Details?.GeoLocation);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        result = "User updated";
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public string deleteCustomer(int customerId)
        {

            string result = "";
            try
            {

                using (var connection = new SqlConnection(_conncetionString))
                {

                    using (var cmd = new SqlCommand("sp_DeleteCustomer", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@customerCode", customerId);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        result = "ok deleted";
                        return result;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }

    }
}
