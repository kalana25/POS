using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using AgendaWeb.DAL;
using AgendaWeb.Models;

namespace AgendaWeb.Repositories.Communications
{
    public class CommunicationRepository:Repository<Communication>,ICommunicationRepository
    {
        public CommunicationRepository(DataBaseContext context):base(context)
        {

        }
    }
}
