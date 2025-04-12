using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Factories
{
    public interface IUpdateFormMapper<TForm, TModel>
    {
        TModel MapToUpdateModel(TForm form);
    }

}
