using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Enums
{
    public enum SortOrder
    {
        [Display(Name = "--")]
        None,
        ASC,
        DESC
    }
}
