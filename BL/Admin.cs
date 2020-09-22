using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using DAL;

namespace BL
{
    public class Admin: User
    {
        public Admin(DataRow userDataRow) : base(userDataRow)
        {

        }
    }
}
