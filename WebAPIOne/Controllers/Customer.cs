using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIOne.Data;
using WebAPIOne.DTO;

namespace WebAPIOne.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class Customer : Controller
    {
        public readonly DataContext context;

        public Customer(DataContext context)
        {
            this.context = context;
        }
        [HttpGet("GetAllCustomers")]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetCustomers()//IEnumerable ie a list of customers will be returned
        {
            return await context.Customers.ToListAsync();
        }

        [HttpPost("AddConsumer")]
        public async Task<ActionResult<CustomerDTO>> AddConsumer(CustomerDTO customer)
        {
            var newCustomer = new CustomerDTO
            {
                CustomerID = customer.CustomerID,
                CustomerName = customer.CustomerName,
                Email = customer.Email,
                Mobile = customer.Mobile
            };
            context.Customers.Add(newCustomer);
            await context.SaveChangesAsync();

            return new CustomerDTO
            {
                CustomerID= customer.CustomerID,
                CustomerName = customer.CustomerName,
                Email = customer.Email,
                Mobile = customer.Mobile
            };
        }
        [HttpPut("UpdateConsumer")]
        public async Task<ActionResult<CustomerDTO>> UpdateCustomer(Int32 customerID, CustomerDTO customer)
        {
            if(customerID!=customer.CustomerID)
            {
                return BadRequest();
            }

            context.Entry(customer).State = EntityState.Modified;

            await context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("DeleteConsumer")]
        public async Task<ActionResult<CustomerDTO>> DeleteCustomer(Int32 customerID, CustomerDTO customer)
        {
            if (customerID != customer.CustomerID)
            {
                return BadRequest();
            }

            context.Entry(customer).State = EntityState.Deleted;

            await context.SaveChangesAsync();

            return NoContent();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
