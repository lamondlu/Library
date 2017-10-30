using BookLibrary.SignalR.DTOs;
using BookLibrary.SignalR.Hubs;
using BookLibrary.SignalR.Models;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BookLibrary.SignalR.Controllers
{
    [RoutePrefix("api/monitored_commands")]
    public class MonitoredCommandController : ApiController
    {

        [HttpPost, Route("")]
        public void Commands(MonitoredCommand model)
        {
            CommandHub hub = new Hubs.CommandHub();
            hub.MonitorCommand(model);
        }

        [HttpPut, Route("{commandUniqueId}/events/{eventName}")]
        public void UpdateStatus(Guid commandUniqueId, string eventName, EventStatusDTO dto)
        {
            CommandHub hub = new Hubs.CommandHub();
            hub.CommandStatusChange(new CommandStatusChangeObject
            {
                CommandUniqueId = commandUniqueId,
                EventName = eventName,
                IsFinished = (dto.Status == EventStatusEnum.Finished),
                IsError = (dto.Status == EventStatusEnum.Error)
            });
        }
    }
}