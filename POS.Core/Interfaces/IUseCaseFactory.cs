using System;
using System.Collections.Generic;
using System.Text;
using POS.Core.DI;

namespace POS.Core.Interfaces
{
    [AutoDIService(implementationType: "POS.Core.Implementation.UseCaseFactory")]
    public interface IUseCaseFactory
    {
        T Create<T>() where T : UseCase;
    }
}
