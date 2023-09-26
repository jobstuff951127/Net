using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NTT_Data.Data.DTOS;
using NTT_Data.UnitOfWork;
using NTT_Data.Models;


namespace NTT_Data.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IUnitOfWork _unitofWork;
        private readonly ILogger<CustomerController> _logger;
        private readonly IMapper _mapper;

        public CustomerController(ILogger<CustomerController> logger, IUnitOfWork work, IMapper mapper)
        {
            _logger = logger;
            _unitofWork = work;
            _mapper = mapper;
        }
          
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var _data = await _unitofWork.CustomersRepository.GetAllAsync();
            return Ok(_data);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var _data = await _unitofWork.CustomersRepository.GetAsync(id);
            return _data is null ? NotFound() : Ok(_data);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody]CustomerDto CustomerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customer = _mapper.Map<Customer>(CustomerDto);
            await _unitofWork.CustomersRepository.AddEntity(customer);
            await _unitofWork.CompleteAsync();

            _logger.LogInformation("Customer created with ID {CustomerId} at {Date}", customer.CustumerId, DateTime.Now);

            return CreatedAtAction(nameof(GetById), new { id = customer.CustumerId }, customer);
        }
    }
}