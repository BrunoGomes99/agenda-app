using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Service.Interfaces
{
    public interface IRabbitMqService
    {
        void SendMessage(string message);
    }
}
