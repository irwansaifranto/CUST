using CUST.Model.Models;
using CUST.Repository.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CUST.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration,
            ICustomerRepository customerRepository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _customerRepository = customerRepository;
        }

        [HttpPost("CreateCustomer")]
        public async Task<IActionResult> Create(CustomerModel model)
        {
            BaseResponseModel response = new BaseResponseModel();

            try
            {
                string name = !string.IsNullOrEmpty(User.Identity?.Name) ? User.Identity.Name : model.Name;
                var customer = await _customerRepository.FirstOrDefault(n => n.Name == name);

                if (customer == null)
                {
                    await _customerRepository.Add(
                       new Model.Customers
                       {
                           Name = name,
                           Phone = model.Phone,
                       });

                    response.Code = (int)HttpStatusCode.OK;
                    response.Status = HttpStatusCode.OK.ToString();
                    response.Message = $"User {name} has been added successfully.";
                }
                else
                {
                    response.Code = (int)HttpStatusCode.BadRequest;
                    response.Status = HttpStatusCode.BadRequest.ToString();
                    response.Message = $"Customer with username: {name} already exist.";
                    response.Data = customer;

                    return StatusCode(StatusCodes.Status400BadRequest, response);
                }
            }
            catch (Exception ex)
            {
                response.Code = (int)HttpStatusCode.InternalServerError;
                response.Status = HttpStatusCode.InternalServerError.ToString();
                response.Message = ex.Message;

                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

            return Ok(response);
        }

        [HttpGet("GetCustomer")]
        public async Task<IActionResult> Read()
        {
            BaseResponseModel response = new BaseResponseModel();

            try
            {
                var name = !string.IsNullOrEmpty(User.Identity?.Name) ? User.Identity.Name : string.Empty;
                var customer = await _customerRepository.FirstOrDefault(n => n.Name == name);

                if (customer != null)
                {
                    response.Code = (int)HttpStatusCode.OK;
                    response.Status = HttpStatusCode.OK.ToString();
                    response.Message = $"User {name} has been retrieve successfully.";
                    response.Data = customer;
                }
                else
                {
                    response.Code = (int)HttpStatusCode.BadRequest;
                    response.Status = HttpStatusCode.BadRequest.ToString();
                    response.Message = $"Customer {name} still not created.";
                    response.Data = customer;

                    return StatusCode(StatusCodes.Status400BadRequest, response);
                }
            }
            catch (Exception ex)
            {
                response.Code = (int)HttpStatusCode.InternalServerError;
                response.Status = HttpStatusCode.InternalServerError.ToString();
                response.Message = ex.Message;

                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

            return Ok(response);
        }

        [HttpPost("UpdateCustomer")]
        public async Task<IActionResult> Update(CustomerModel model)
        {
            BaseResponseModel response = new BaseResponseModel();

            try
            {
                var name = !string.IsNullOrEmpty(User.Identity?.Name) ? User.Identity.Name : string.Empty;
                var customer = await _customerRepository.FirstOrDefault(n => n.Name == name);

                if (customer != null)
                {
                    customer.Phone = model.Phone;
                    await _customerRepository.Update(customer);

                    response.Code = (int)HttpStatusCode.OK;
                    response.Status = HttpStatusCode.OK.ToString();
                    response.Message = $"User {name} has been updated successfully.";
                    response.Data = customer;
                }
                else
                {
                    response.Code = (int)HttpStatusCode.BadRequest;
                    response.Status = HttpStatusCode.BadRequest.ToString();
                    response.Message = $"Can't Update. Customer {name} still not created.";
                    response.Data = customer;

                    return StatusCode(StatusCodes.Status400BadRequest, response);
                }
            }
            catch (Exception ex)
            {
                response.Code = (int)HttpStatusCode.InternalServerError;
                response.Status = HttpStatusCode.InternalServerError.ToString();
                response.Message = ex.Message;

                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

            return Ok(response);
        }

        [HttpPost("DeleteCustomer")]
        public async Task<IActionResult> Delete()
        {
            BaseResponseModel response = new BaseResponseModel();

            try
            {
                var name = !string.IsNullOrEmpty(User.Identity?.Name) ? User.Identity.Name : string.Empty;
                var customer = await _customerRepository.FirstOrDefault(n => n.Name == name);

                if (customer != null)
                {
                    await _customerRepository.Remove(customer);

                    response.Code = (int)HttpStatusCode.OK;
                    response.Status = HttpStatusCode.OK.ToString();
                    response.Message = $"User {name} has been deleted successfully.";
                }
                else
                {
                    response.Code = (int)HttpStatusCode.BadRequest;
                    response.Status = HttpStatusCode.BadRequest.ToString();
                    response.Message = $"Can't delete. Customer {name} still not created.";
                    response.Data = customer;

                    return StatusCode(StatusCodes.Status400BadRequest, response);
                }
            }
            catch (Exception ex)
            {
                response.Code = (int)HttpStatusCode.InternalServerError;
                response.Status = HttpStatusCode.InternalServerError.ToString();
                response.Message = ex.Message;

                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

            return Ok(response);
        }
    }
}
