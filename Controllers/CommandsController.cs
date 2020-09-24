using System.Collections.Generic;
using CmdApi.Models;
using CmdApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CmdApi.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;
        public CommandsController(ICommanderRepo commanderRepo)
        {
            _repository = commanderRepo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            var allCommands = _repository.GetAllCommands();

            return Ok(allCommands);
        }

        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandById(int id)
        {
            var command = _repository.GetCommandById(id);

            return Ok(command);
        }
    }
}