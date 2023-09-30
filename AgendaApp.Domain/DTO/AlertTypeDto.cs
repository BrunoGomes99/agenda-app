using AgendaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Domain.DTO
{
    public class AlertTypeDto
    {
        public int Id { get; set; }
        public string? Type { get; set; }

        public static List<AlertTypeDto> MapList(List<AlertType> alertTypes)
        {
            var result = new List<AlertTypeDto>();
            foreach (var alertType in alertTypes)
            {
                result.Add(new AlertTypeDto
                {
                    Id = alertType.Id,
                    Type = alertType.Type
                });
            }
            return result;
        }
    }
}
