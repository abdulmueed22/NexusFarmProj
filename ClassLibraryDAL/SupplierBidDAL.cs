using ClassLibraryModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDAL
{
    public class SupplierBidDAL
    {
        public static int SaveSupplierBid(SupplierBidModel sb)
        {
            SqlConnection con = DBContext.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_SaveSupplierBid", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure; 
            cmd.Parameters.AddWithValue("@bidName", sb.bidName);
            cmd.Parameters.AddWithValue("@bidQty", sb.bidQty);
            cmd.Parameters.AddWithValue("@bidPrice", sb.bidPrice);
            cmd.Parameters.AddWithValue("@bidCategory", sb.bidCategory);
            cmd.Parameters.AddWithValue("@SupplierID_FK", sb.SupplierID_FK);
            int i = cmd.ExecuteNonQuery(); 
            con.Close();
            return i;
        }
        public static List<SupplierBidModel> GetSupplierBid()
        {
            SqlConnection con = DBContext.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_GetSupplierBid", con); 
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            List<SupplierBidModel> supplierbidlist = new List<SupplierBidModel>();
            while (sdr.Read())
            {
                SupplierBidModel supplierModel = new SupplierBidModel();
                supplierModel.bidID = int.Parse(sdr["bidID"].ToString());
                supplierModel.bidName = sdr["bidName"].ToString();
                supplierModel.bidQty = int.Parse(sdr["bidQty"].ToString());
                supplierModel.bidPrice = int.Parse(sdr["bidPrice"].ToString());
                supplierModel.bidCategory = sdr["bidCategory"].ToString();
                supplierbidlist.Add(supplierModel);
            }
            con.Close();
            return supplierbidlist;
        }

        public static async Task<List<SupplierBidModel>> GetSupplierProductBySupplierID(string supplier_fkid)
        {
            SqlConnection con = DBContext.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_GetSupplierProductBySupplierID", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SupplierID_FK", supplier_fkid);
            SqlDataReader sdr = await cmd.ExecuteReaderAsync();
            List<SupplierBidModel> supplierbid = new List<SupplierBidModel>();
            while (await sdr.ReadAsync())
            {
                SupplierBidModel supp = new SupplierBidModel();
                supp.bidID = int.Parse(sdr["bidID"].ToString());
                supp.bidName = sdr["bidName"].ToString();
                supp.bidQty = int.Parse(sdr["bidQty"].ToString());
                supp.bidCategory = sdr["bidCategory"].ToString();
                supp.bidPrice = int.Parse(sdr["bidPrice"].ToString());
                supplierbid.Add(supp);
            }
            return supplierbid;
        }

    }
}
