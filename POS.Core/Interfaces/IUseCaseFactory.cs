using System;
using System.Collections.Generic;
using System.Text;
using AgendaWeb.Core.DI;

namespace AgendaWeb.Core.Interfaces
{
    [AutoDIService(implementationType: "AgendaWeb.Core.Implementation.UseCaseFactory")]
    public interface IUseCaseFactory
    {
        T Create<T>() where T : UseCase;
    }
}
