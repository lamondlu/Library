using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Library.Infrastructure.Core.Models;
using Library.Infrastructure.Core;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.Service.Logs
{
    [Route("api/[controller]")]
    public class CommandLogsController : Controller
    {
        private ILogger _logger;

        public CommandLogsController(ILogger logger)
        {
            _logger = logger;
        }

        [HttpGet("")]
        public List<CommandLogModel> GetAllCommandLogs()
        {
            return _logger.GetCommandLogs();
        }

        [HttpGet("{commandUnqiueId}/eventLogs")]
        public List<CommandLogModel> GetAllCommandLogs(Guid commandUniqueId)
        {
            return _logger.GetEventLogs(commandUniqueId);
        }
    }
}
