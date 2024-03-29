using System.Collections.Generic;
using AutoMapper;
using CmdApi.Dtos;
using CmdApi.Models;
using CmdApi.Repository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CmdApi.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo commanderRepo, IMapper mapper)
        {
            _repository = commanderRepo;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var allCommands = _repository.GetAllCommands();

            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(allCommands));
        }


        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var command = _repository.GetCommandById(id);

            if (command != null) return Ok(_mapper.Map<CommandReadDto>(command));
            else return NotFound();
        }


        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);

            _repository.CreateCommand(commandModel);

            _repository.SaveChanges();

            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);

            return CreatedAtRoute(nameof(GetCommandById), new { Id = commandReadDto.Id }, commandReadDto);
        }


        [HttpPut("{id}")]
        public ActionResult FullUpdateCommand(int id, CommandUpdateDto commandUpdateDto)
        {
            var commandModel = _repository.GetCommandById(id);

            if (commandModel == null) return NotFound();

            _mapper.Map(commandUpdateDto, commandModel);

            _repository.UpdateCommand(commandModel);

            _repository.SaveChanges();

            return NoContent();
        }


        [HttpPatch("{id}")]
        public ActionResult PartialUpdateCommand(int id, JsonPatchDocument<CommandUpdateDto> patchDocument)
        {
            var commandModel = _repository.GetCommandById(id);

            if (commandModel == null) return NotFound();

            var commandToPatch = _mapper.Map<CommandUpdateDto>(commandModel);

            patchDocument.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModel);

            _repository.UpdateCommand(commandModel);

            _repository.SaveChanges();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var commandModel = _repository.GetCommandById(id);

            if (commandModel == null) return NotFound();

            _repository.DeleteCommand(commandModel);

            _repository.SaveChanges();

            return NoContent();
        }
    }
}