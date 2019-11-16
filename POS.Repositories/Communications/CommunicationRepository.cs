using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using POS.DAL;
using POS.Models;

namespace POS.Repositories.Communications
{
    public class CommunicationRepository:Repository<Communication>,ICommunicationRepository
    {
        public CommunicationRepository(DataBaseContext context):base(context)
        {

        }
    }
}
