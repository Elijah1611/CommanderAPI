using System.Collections.Generic;
using CmdApi.Models;

namespace CmdApi.Repository
{
    public interface ICommanderRepo
    {
        IEnumerable<Command> GetAppCommands();
        Command GetCommandById(int id);
    }
}