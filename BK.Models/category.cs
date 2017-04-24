using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BK.Models
{
    public partial class category
    {
        partial void OnCreated()
        {
            category_name = "";
            category_otherName = "";
        }
    }
}
