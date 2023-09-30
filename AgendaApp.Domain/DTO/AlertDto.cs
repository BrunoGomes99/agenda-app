using AgendaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Domain.DTO
{
    public class AlertDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int IdAlertType { get; set; }
        public DateTime Date { get; set; }

        public static List<AlertDto> MapList(List<Alert> alerts)
        {
            var result = new List<AlertDto>();
            foreach (var alert in alerts)
            {
                result.Add(new AlertDto
                {
                    Id = alert.Id,
                    Title = alert.Title,
                    Description = alert.Description,
                    IdAlertType = alert.IdAlertType,
                    Date = alert.Date
                });
            }
            return result;
        }
    }
}
