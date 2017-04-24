using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BK.Models
{
    public partial class user
    {
        partial void OnCreated()
        {
            user_isdel = false;
            user_isAdmin = false;
            user_loginName = "";
            user_name = "";
            user_pwd = "";            
        }
    }
}
