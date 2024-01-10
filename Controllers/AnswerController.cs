using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Net.Data.DTOS;
using Net.UnitOfWork;
using Net.Models;


namespace NTT_Data.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnswerController : ControllerBase
    {
        private readonly IUnitOfWork _unitofWork;
        private readonly ILogger<AnswerController> _logger;
        private readonly IMapper _mapper;

        public AnswerController(ILogger<AnswerController> logger, IUnitOfWork work, IMapper mapper)
        {
            _logger = logger;
            _unitofWork = work;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var _data = await _unitofWork.AnswerRepository.GetAllAsync();
            return Ok(_data);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var _data = await _unitofWork.AnswerRepository.GetAsync(id);
            return _data is null ? NotFound() : Ok(_data);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(AnswerDto AnswerDto)
        {
            var product = _mapper.Map<Answer>(AnswerDto);
            await _unitofWork.AnswerRepository.AddEntity(product);
            await _unitofWork.CompleteAsync();

            _logger.LogInformation("Created: {Date}", DateTime.Now);   

            return Ok();
        }
    }
}