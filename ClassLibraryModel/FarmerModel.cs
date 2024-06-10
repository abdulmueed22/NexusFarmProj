using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryModel
{
    public class FarmerModel
    {
        public int FID { get; set; } //Primary Key of Farmer
        public string? farmerName{ get; set; }
        public int farmerPIN { get; set; }
        public string? farmerAddress { get; set; }

        public string? farmerCompany { get; set; }
        public int farmerContact { get; set; }
    }
}
