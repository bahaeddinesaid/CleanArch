using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Common
{
    public abstract  class BaseDto<T>
    {
        public virtual T Id { get; set; }

    }
}
