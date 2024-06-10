using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryModel
{
    public class FarmerProduct
    {
        public int PID { get; set; } //Primary Key of Farmer's Product
        public string? productName { get; set; }
        public int productQty { get; set; }
        public string? productCategory { get; set; }
        public string? productImg { get; set; }
        public int PID_FK { get; set; } //Foreign Key 
    }
}
