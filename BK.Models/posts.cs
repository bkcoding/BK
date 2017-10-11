using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BK.Models
{
    public partial class posts
    {
        partial void OnCreated()
        {
            isDel = false;
            title = "";
            pic = "";
            writer = "bkcoding";
            createTime = DateTime.Now;
            readcount = 0;
            excerpt = "";
            content = "";
        }
    }
}
