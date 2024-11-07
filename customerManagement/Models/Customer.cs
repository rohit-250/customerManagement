namespace customerManagement.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public CustomerDetails? Details { get; set; }
    }
    public class CustomerDetails
    {
        public string? CustomerName { get; set; }
        public string? CustomerAddress { get; set; }
        public string? CustomerEmail { get; set; }
        public string? CustomerMobileNo { get; set; }
        public string? GeoLocation { get; set; }

    }
}
