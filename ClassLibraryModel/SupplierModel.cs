using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryModel
{
    public class SupplierModel
    {
        public int SupplierID { get; set; }
        public string? supplierName { get; set; }
        public int supplierPIN { get; set; }
        public string? supplierAddress { get; set; }
        public int supplierContact { get; set; }
    }
}
