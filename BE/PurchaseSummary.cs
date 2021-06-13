using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class PurchaseSummary
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public string Product_Name { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public decimal Total { get; set; }
        public DateTime Added_Date { get; set; }
        public int AddBy { get; set; }
        public int Product_Id { get; set; }
    }
}
