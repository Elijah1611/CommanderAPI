using AutoMapper;
using CmdApi.Dtos;
using CmdApi.Models;

namespace CmdApi.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            CreateMap<Command, CommandReadDto>();
            CreateMap<CommandCreateDto, Command>();
        }
    }
}