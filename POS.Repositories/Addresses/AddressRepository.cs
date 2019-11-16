using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using POS.DAL;
using POS.Models;

namespace POS.Repositories.Addresses
{
    public class AddressRepository:Repository<Address>,IAddressRepository
    {
        public AddressRepository(DataBaseContext context) : base(context)
        {

        }
    }
}
