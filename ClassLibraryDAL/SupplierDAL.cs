using ClassLibraryModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDAL
{
    public class SupplierDAL
    {
        public static int SaveSupplier(SupplierModel sm)
        {
            SqlConnection con = DBContext.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_SaveSupplier", con); 
            cmd.CommandType = System.Data.CommandType.StoredProcedure; 
            cmd.Parameters.AddWithValue("@supplierName", sm.supplierName);
            cmd.Parameters.AddWithValue("@supplierPIN", sm.supplierPIN);
            cmd.Parameters.AddWithValue("@supplierAddress", sm.supplierAddress);
            cmd.Parameters.AddWithValue("@supplierContact", sm.supplierContact);
            int i = cmd.ExecuteNonQuery(); 
            con.Close();
            return i;
        }
        public static List<SupplierModel> GetSupplier()
        {
            SqlConnection con = DBContext.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_GetSupplier", con); 
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            List<SupplierModel> supplierlist = new List<SupplierModel>();
            while (sdr.Read())
            {
                SupplierModel supplierModel = new SupplierModel();
                supplierModel.SupplierID = int.Parse(sdr["SupplierID"].ToString());
                supplierModel.supplierName = sdr["supplierName"].ToString();
                supplierModel.supplierPIN = int.Parse(sdr["supplierPIN"].ToString());
                supplierModel.supplierAddress = sdr["supplierAddress"].ToString();
                supplierModel.supplierContact = int.Parse(sdr["supplierContact"].ToString());
                supplierlist.Add(supplierModel);
            }
            con.Close();
            return supplierlist;
        }

    }
}
