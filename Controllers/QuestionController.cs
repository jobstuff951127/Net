using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Net.Data.DTOS;
using Net.UnitOfWork;
using Net.Models;
using System.Formats.Asn1;
using Net.Services;


namespace Net.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionController : ControllerBase
    { 
        private readonly IUnitOfWork _unitofWork;
        private readonly IMapper _mapper;
        private readonly ILogger<QuestionController> _logger;
        private readonly QuestionHelper _questionParser;


        public QuestionController(ILogger<QuestionController> logger, IUnitOfWork work, IMapper mapper, QuestionHelper questionParser)
        {
            _logger = logger;
            _unitofWork = work;
            _mapper = mapper;
            _questionParser = questionParser;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var _data = await _unitofWork.QuestionRepository.GetAllAsync();
            return Ok(_data);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var _data = await _unitofWork.QuestionRepository.GetAsync(id);
            return _data is null ? NotFound() : Ok(_data);
        }

        [HttpPost("import")]
        public async Task<IActionResult> ImportQuestions(IFormFile file)
        {
            try
            {
                // Parse the file and extract questions and answers
                var questions = ParseQuestionsFromFile(file);

                // Save questions to the database
                await _unitofWork.QuestionRepository.AddQuestionsAsync(questions);

                return Ok("Import successful");
            }
            catch (Exception ex)
            {
                return BadRequest($"Import failed: {ex.Message}");
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody]QuestionDto QuestionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var question = _mapper.Map<Question>(QuestionDto);
            await _unitofWork.QuestionRepository.AddEntity(question);
            await _unitofWork.CompleteAsync();

            _logger.LogInformation("Question created with ID {CustomerId} at {Date}", question.QuestionId, DateTime.Now);

            return CreatedAtAction(nameof(GetById), new { id = question.QuestionId }, question);
        }

        [HttpGet("tags/{tagName}")]
        public IActionResult GetQuestionsByTag(string tagName)
        {
            var questions = _unitofWork.QuestionRepository.GetQuestionsByTag(tagName);
            return Ok(questions);
        }
        private List<Question> ParseQuestionsFromFile(IFormFile file)
        {
            return _questionParser.ParseQuestionsFromFile(file);
        }
    }
}

