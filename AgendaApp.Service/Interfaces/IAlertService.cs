using AgendaApp.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Service.Interfaces
{
    public interface IAlertService
    {
        List<AlertDto> Get();
        AlertDto? GetById(int id);
        AlertDto Save(AlertDto dto);
        AlertDto Update(AlertDto dto);
        void Delete(int id);
    }
}
