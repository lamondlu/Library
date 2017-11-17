using  Library.SignalR.DTOs;
using  Library.SignalR.Hubs;
using  Library.SignalR.Models;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace  Library.SignalR.Controllers
{
    [RoutePrefix("api/monitored_commands")]
    public class MonitoredCommandController : ApiController
    {
        public MonitoredCommandController()
        {
        }

        [HttpPost, Route("")]
        public void Commands(MonitoredCommand model)
        {
            CommandHub hub = new Hubs.CommandHub();
            hub.MonitorCommand(model);
        }

        [HttpPut, Route("{commandUniqueId}")]
        public void UpdateCommandStatus(Guid commandUniqueId, EventStatusDTO dto)
        {
            CommandHub hub = new Hubs.CommandHub();
            hub.CommandStatusChangeDirectly(commandUniqueId, 
                (dto.Status == EventStatusEnum.Finished), 
                (dto.Status == EventStatusEnum.Error),
                dto.ErrorCode,
                dto.ErrorMessage
            );
        }

        [HttpPut, Route("{commandUniqueId}/events/{eventName}")]
        public void UpdateStatus(Guid commandUniqueId, string eventName, EventStatusDTO dto)
        {
            CommandHub hub = new Hubs.CommandHub();
            hub.CommandStatusChange(new CommandStatusChangeObject
            {
                CommandUniqueId = commandUniqueId,
                EventName = eventName,
                ErrorCode = dto.ErrorCode,
                ErrorMessage = dto.ErrorMessage,
                IsFinished = (dto.Status == EventStatusEnum.Finished),
                IsError = (dto.Status == EventStatusEnum.Error)
            });
        }
    }
}