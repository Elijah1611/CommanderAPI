using System.Collections.Generic;
using CmdApi.Models;

namespace CmdApi.Repository
{
    public interface ICommanderRepo
    {
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);
    }
}