using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Interfaces;

namespace OpenUITwitchBot.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class CommandController : ControllerBase
    {

        private ICommandService CommandService { get; set; }

        public CommandController(ICommandService commandService)
        {
            CommandService = commandService;
        }

        [HttpPost("")]
        public IActionResult Create(Command command)
        {
            Command commandResult = CommandService.Create(command);
            if (commandResult == null)
                return BadRequest();
            return Ok(commandResult);
        }

        [HttpGet("")]
        public IActionResult GetById(string commandId)
        {
            Command commandResult = CommandService.GetById(commandId);
            if (commandResult == null)
                return NotFound();
            return Ok(commandResult);
        }

        [HttpPut("")]
        public IActionResult Update(string commandId, Command command)
        {
            Command commandResult = CommandService.Update(commandId, command);
            if (commandResult == null)
                return BadRequest();
            return Ok(commandResult);
        }

        [HttpDelete("")]
        public IActionResult Delete(string commandId)
        {
            Command commandResult = CommandService.Delete(commandId);
            if (commandResult == null)
                return NotFound();
            return Ok(commandResult);
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            List<Command> commandsResult = CommandService.GetAll();
            return Ok(commandsResult);
        }

        [HttpGet("types")]
        public IActionResult GetCommandTypeNames()
        {
            List<string> commandTypeNames = Enum.GetNames(typeof(CommandType)).ToList();
            return Ok(commandTypeNames);
        }

        [HttpGet("type")]
        public IActionResult GetCommandTypeIdByName(string name)
        {
            int? id = Convert.ToInt32(Enum.Parse(typeof(CommandType), name));
            if (id == null)
                return BadRequest("You have to provide a valid command-type.");
            return Ok(id);
        }

    }
}