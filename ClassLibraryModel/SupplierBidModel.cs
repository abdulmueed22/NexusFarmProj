using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryModel
{
    public class SupplierBidModel
    {
        public int bidID { get; set; }
        public string? bidName { get; set; }
        public int bidQty { get; set; }
        public int bidPrice { get; set; }
        public string? bidCategory { get; set; }
        public int SupplierID_FK { get; set; } //Foriegn Key of Supplier
    }
}
