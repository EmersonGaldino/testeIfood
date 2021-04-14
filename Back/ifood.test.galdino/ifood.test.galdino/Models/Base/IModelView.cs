using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ifood.test.galdino.api.Models.Base
{
    public interface IModelView
    {
    }
    public interface IModelView<T> where T : new()
    {
    }
}
