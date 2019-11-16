using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using AgendaWeb.DAL;
using AgendaWeb.Models;

namespace AgendaWeb.Repositories.Addresses
{
    public class AddressRepository:Repository<Address>,IAddressRepository
    {
        public AddressRepository(DataBaseContext context) : base(context)
        {

        }
    }
}
