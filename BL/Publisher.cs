using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using DAL;

namespace BL
{
    class Publisher: User
    {
        public Publisher(DataRow userDataRow) : base(userDataRow)
        {

        }
        protected override DataTable GetAssociatedBooks()
        {
            return DAL.PublisherHelper.GetPublishedBooksList(base.id);
        }
    }
}
