using ClassLibraryModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDAL
{
    public class FarmerProductDAL
    {
        public static int SaveFarmerProduct(FarmerProduct fp)
        {
            SqlConnection con = DBContext.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_SaveFarmerProduct", con); 
            cmd.CommandType = System.Data.CommandType.StoredProcedure; 
            cmd.Parameters.AddWithValue("@productName", fp.productName);
            cmd.Parameters.AddWithValue("@productQty", fp.productQty);
            cmd.Parameters.AddWithValue("@productCategory", fp.productCategory);
            cmd.Parameters.AddWithValue("@productImg", fp.productImg);
            int i = cmd.ExecuteNonQuery(); 
            con.Close();
            return i;
        }
        public static List<FarmerProduct> GetFarmerProduct()
        {
            SqlConnection con = DBContext.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_GetFarmerProduct", con); 
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            List<FarmerProduct> farmerproductlist = new List<FarmerProduct>();
            while (sdr.Read())
            {
                FarmerProduct farmerProduct = new FarmerProduct();
                farmerProduct.PID = int.Parse(sdr["PID"].ToString());
                farmerProduct.productName = sdr["farmerName"].ToString();
                farmerProduct.productQty = int.Parse(sdr["productQty"].ToString());
                farmerProduct.productCategory = sdr["productCategory"].ToString();
                farmerProduct.productImg = sdr["productImg"].ToString();
                farmerproductlist.Add(farmerProduct);
            }
            con.Close();
            return farmerproductlist;
        }

        public static async Task<List<FarmerProduct>> GetFarmerProductByFID(string farmer_fkid)
        {
            SqlConnection con = DBContext.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_GetFarmerProductByID", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PID_FK", farmer_fkid); 
            SqlDataReader sdr = await cmd.ExecuteReaderAsync();
            List<FarmerProduct> ListProducts = new List<FarmerProduct>();
            while (await sdr.ReadAsync())
            {
                FarmerProduct farp = new FarmerProduct();
                farp.PID = int.Parse(sdr["PID"].ToString());
                farp.productName = sdr["productName"].ToString();
                farp.productQty = int.Parse(sdr["productQty"].ToString());
                farp.productCategory = sdr["productCategory"].ToString();
                farp.productImg = sdr["productImg"].ToString();
                ListProducts.Add(farp);
            }
            return ListProducts;
        }

        public static int DeleteFproduct(int productid)
        {
            SqlConnection con = DBContext.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_DeleteFarmerProduct", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PID", productid);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}
