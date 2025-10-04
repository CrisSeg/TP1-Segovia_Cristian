using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ClaseAbstacta
{
    public abstract class IsDeleteEntitties
    {
        public bool IsDelete { get; set; }

        protected IsDeleteEntitties() { 
            IsDelete = false;
        }
    }
}
