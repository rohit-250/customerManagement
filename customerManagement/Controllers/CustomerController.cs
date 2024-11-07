using Microsoft.AspNetCore.Mvc;
using customerManagement.Models;
namespace customerManagement.Controllers
{
    [ApiController]
    [Route("(Customer)")]
    public class CustomerController : ControllerBase
    {
        private readonly IDataBaseService _databaseService;

        public CustomerController(IDataBaseService databaseService)
        {
            _databaseService = databaseService;
        }

        // POST api to create customer
        [HttpPost]
        [Route("createCustomer")]
        public IActionResult Post(CustomerDetails customerDetails)
        {
            _databaseService.createCustomer(customerDetails);
            return Ok("customer added");
        }

        // POST api to create multiple customers
        [HttpPost]
        [Route("createmultipleCustomer")]
        public IActionResult Post(List<CustomerDetails> customerDetails)
        {
            customerDetails.ForEach(x => _databaseService.createCustomer(x));
            return Ok("customers added");
        }

        // GET: api to get all cutomers
        [HttpGet]
        [Route("getAllCustomer")]
        public IActionResult Get()
        {
            return Ok(_databaseService.getAllCustomer());
        }

        // GET api to get customer by Id
        [HttpGet]
        [Route("getCustomerById/{id}")]
        public IActionResult GetCustomerByCode(int id)
        {
            var customer = _databaseService.getCustomerById(id);
            return customer == null ? NotFound("Customer not found") : Ok(customer);

        }



        // PUT api to update customer
        [HttpPut]
        [Route("updateCustomer/{id}")]
        public IActionResult UpdatePut(int id, CustomerDetails customerDetails)
        {
            Customer newCutomer = new Customer { Id = id, Details = customerDetails };
            var customer = _databaseService.getCustomerById(id);
            if (customer == null)
            {
                return NotFound("Customer not found");
            }
            string UpdatedCustomer = _databaseService.updateCustomer(newCutomer);
            customer.Details = customerDetails;
            return Ok($"{customer.Id} is updated");
        }

        // DELETE api to delete customer
        [HttpDelete]
        [Route("deleteCustomer/{id}")]
        public IActionResult Delete(int id)
        {
            var customer = _databaseService.getCustomerById(id);
            if (customer == null)
            {
                return NotFound("Customer not found");
            }
            string DeletedCustomer = _databaseService.deleteCustomer(id);
            return Ok($"{customer.Id} is deleted");
        }
    }
}
