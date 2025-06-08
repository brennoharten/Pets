using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pets.Application.Output.Results.Interfaces;
using Pets.Domain.Notifications;

namespace Pets.Application.Output.Results
{
    public class Result : IResultBase
    {
        private List<Notification> _notifications;
        public int StatusCode { get; private set; }
        public string Message { get; private set; }
        public bool Success { get; private set; }
        public object Data { get; private set; }
        public IReadOnlyCollection<Notification> Notifications => _notifications.AsReadOnly();

        public Result(int statusCode, string message, bool success, object data = null)
        {
            _notifications = new List<Notification>();
            StatusCode = statusCode;
            Message = message;
            Success = success;
            Data = data;
        }

        public void SetNotification(List<Notification> notifications)
        {
            _notifications = notifications;
        }

        public void SetData(object data)
        {
            Data = data;
        }  
    }
}