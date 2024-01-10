using AutoMapper;
using Net.Data.DTOS;
using Net.Models;

namespace Net.Data
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<QuestionDto, Question>();
            CreateMap<AnswerDto, Answer>();
            CreateMap<UserDto, User>();
            CreateMap<VoteDto, Vote>();
        }
    }
}
