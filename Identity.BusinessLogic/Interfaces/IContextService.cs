using Identity.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.BusinessLogic.Interfaces
{
    public interface IContextService
    {
        public void Do(Action<DatabaseContext> action);
    }
}
