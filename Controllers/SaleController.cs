using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NTT_Data.Data.DTOS;
using NTT_Data.UnitOfWork;
using NTT_Data.Models;


namespace NTT_Data.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaleController : ControllerBase
    {
        private readonly IUnitOfWork _unitofWork;
        private readonly ILogger<SaleController> _logger;
        private readonly IMapper _mapper;

        public SaleController(ILogger<SaleController> logger, IUnitOfWork work, IMapper mapper)
        {
            _logger = logger;
            _unitofWork = work;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var _data = await _unitofWork.SalesRepository.GetAllAsync();
            return Ok(_data);
        }

        [HttpGet("GetByDateRange")]
        public async Task<IActionResult> GetByDateRange(DateTime fromDate, DateTime toDate)
        {
            var _data = await _unitofWork.SalesRepository.GetByDateRangeAsync(fromDate, toDate);
            return _data is null ? NotFound() : Ok(_data);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(SaleDto SaleDto)
        {
            var sale = _mapper.Map<Sale>(SaleDto);
            await _unitofWork.SalesRepository.AddEntity(sale);
            await _unitofWork.CompleteAsync();

            _logger.LogInformation("Created: {Date}", DateTime.Now);   

            return Ok();
        }
    }
}