using System;
using System.Collections.Generic;
using System.Text;
using AgendaWeb.Models;
using AgendaWeb.Core.DI;

namespace AgendaWeb.Repositories.Addresses
{
    [AutoDIService]
    public interface IAddressRepository: IRepository<Address>
    {
    }
}
