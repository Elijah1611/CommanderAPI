using System.Collections.Generic;
using CmdApi.Models;

namespace CmdApi.Repository
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public IEnumerable<Command> GetAppCommands()
        {
            return new List<Command>()
            {
                new Command() {Id=0, Description="Make virtual environment", Snippet="python3 -m venv venv", Platform="Terminal"},
                new Command() {Id=1, Description="List databases", Snippet="\\l", Platform="Terminal"},
                new Command() {Id=2, Description="List tables", Snippet="\\dt", Platform="Terminal"}
            };
        }

        public Command GetCommandById(int id)
        {
            return new Command() { Id = 0, Description = "Make virtual environment", Snippet = "python3 -m venv venv", Platform = "Terminal" };
        }

    }
}