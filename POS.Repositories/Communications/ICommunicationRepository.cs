using System;
using System.Collections.Generic;
using System.Text;
using POS.Models;
using POS.Core.DI;

namespace POS.Repositories.Communications
{
    [AutoDIService]
    public interface ICommunicationRepository: IRepository<Communication>
    {
    }
}
