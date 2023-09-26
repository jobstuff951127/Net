using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NTT_Data.Data.DTOS;
using NTT_Data.UnitOfWork;
using NTT_Data.Models;


namespace NTT_Data.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitofWork;
        private readonly ILogger<ProductController> _logger;
        private readonly IMapper _mapper;

        public ProductController(ILogger<ProductController> logger, IUnitOfWork work, IMapper mapper)
        {
            _logger = logger;
            _unitofWork = work;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var _data = await _unitofWork.ProductsRepository.GetAllAsync();
            return Ok(_data);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var _data = await _unitofWork.ProductsRepository.GetAsync(id);
            return _data is null ? NotFound() : Ok(_data);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(ProductDto ProductDto)
        {
            var product = _mapper.Map<Product>(ProductDto);
            await _unitofWork.ProductsRepository.AddEntity(product);
            await _unitofWork.CompleteAsync();

            _logger.LogInformation("Created: {Date}", DateTime.Now);   

            return Ok();
        }
    }
}