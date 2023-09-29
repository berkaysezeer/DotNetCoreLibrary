using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FluentValidation.Web.Models;
using FluentValidation.Web.FluentValidators;
using AutoMapper;
using FluentValidation.Web.Dto;

namespace FluentValidation.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersApiController : ControllerBase
    {
        private readonly Context _context;
        private readonly IValidator<Customer> _validator;
        private readonly IMapper _mapper;

        public CustomersApiController(Context context, IValidator<Customer> validator, IMapper mapper)
        {
            _validator = validator;
            _context = context;
            _mapper = mapper;
        }

        // GET: api/CustomersApi
        [HttpGet]
        public async Task<ActionResult<List<CustomerDto>>> GetCustomers()
        {
            List<Customer> customers = await _context.Customers.ToListAsync();

            /*aşağıdaki gibi bir kullanımda modelimizdeki tüm alanlar dış dünyaya açılmış oluyor.
             Eğer automapper ile mapping yaparsak dto'daki alanları kullanmış olacağız. Bu da sa istediğimiz alanları dış dünyaya açacağımız anlamına gelir

            return await _context.Customers.ToListAsync();
             */

            return _mapper.Map<List<CustomerDto>>(customers);
        }

        // GET: api/CustomersApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            if (_context.Customers == null)
            {
                return NotFound();
            }
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // PUT: api/CustomersApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CustomersApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            if (_context.Customers == null)
            {
                return Problem("Entity set 'Context.Customers'  is null.");
            }

            var result = _validator.Validate(customer);

            //BadRequest üzerinden fluent validation'a takılmış hataları geri dnüyoruz
            if (!result.IsValid)
            {
                return BadRequest(result.Errors.Select(x => new
                {
                    property = x.PropertyName,
                    error = x.ErrorMessage
                }));
            }

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        }

        // DELETE: api/CustomersApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            if (_context.Customers == null)
            {
                return NotFound();
            }
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(int id)
        {
            return (_context.Customers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
