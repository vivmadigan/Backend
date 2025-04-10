using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Factories
{
    public interface IFormToModelMapper <TForm, TModel>
    {
        TModel MapToModel(TForm form);
    }
}
