using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BK.Models
{
    public partial class release
    {
        partial void OnCreated()
        {
            time = DateTime.Now;
            isTop = false;          
        }
    }
}
