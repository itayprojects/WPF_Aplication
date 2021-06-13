using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class PurchaseDetails
    {
        public int PurchaseDetailsID { get; set; }
        public int ID_User { get; set; }
        public decimal Grand_Total { get; set; }
        public decimal Tax { get; set; }
        public decimal Discount { get; set; }
        public DateTime Purchase_Time { get; set; }
        public int AddBy { get; set; }
    }
}
