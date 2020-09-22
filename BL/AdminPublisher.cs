using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BL
{
    public class AdminPublisher: User //this class probably wont have much use but it is used for a publisher which is also an admin
    {
        public AdminPublisher(DataRow userDataRow) : base(userDataRow)
        {

        }
    }
}
