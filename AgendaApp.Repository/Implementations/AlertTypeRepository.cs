﻿using AgendaApp.Domain.Entities;
using AgendaApp.Domain.Repository.Interfaces;
using AgendaApp.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Repository.Implementations
{
    public class AlertTypeRepository : RepositoryBase<AlertType>, IAlertTypeRepository
    {
        public AlertTypeRepository(MyDbContext context) : base(context)
        {
        }
    }
}
