using ClassLibraryModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDAL
{
    public class FarmerDAL
    {
        public static int SaveFarmer(FarmerModel fm)
        { 
            SqlConnection con = DBContext.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_SaveFarmer", con); 
            cmd.CommandType = System.Data.CommandType.StoredProcedure; 
            cmd.Parameters.AddWithValue("@farmerName", fm.farmerName);
            cmd.Parameters.AddWithValue("@farmerPIN", fm.farmerPIN);
            cmd.Parameters.AddWithValue("@farmerAddress", fm.farmerAddress);
            cmd.Parameters.AddWithValue("@farmerCompany", fm.farmerCompany);
            cmd.Parameters.AddWithValue("@farmerContact", fm.farmerContact);
            int i = cmd.ExecuteNonQuery(); 
            con.Close();
            return i;
        }
        public static List<FarmerModel> GetFarmers()
        {
            SqlConnection con = DBContext.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_GetFarmer", con); 
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            List<FarmerModel> farmerlist = new List<FarmerModel>(); 
            while (sdr.Read())
            {
                FarmerModel farmerModel = new FarmerModel();
                farmerModel.FID = int.Parse(sdr["FID"].ToString());
                farmerModel.farmerName = sdr["farmerName"].ToString();
                farmerModel.farmerPIN = int.Parse(sdr["farmerPIN"].ToString());
                farmerModel.farmerAddress = sdr["farmerAddress"].ToString();
                farmerModel.farmerCompany = sdr["farmerCompany"].ToString();
                farmerModel.farmerContact = int.Parse(sdr["farmerContact"].ToString());
                farmerlist.Add(farmerModel);
            }
            con.Close();
            return farmerlist;
        }

		public static int DeleteFarmer(int farmerid)
		{
			SqlConnection con = DBContext.GetConnection();
			con.Open();
			SqlCommand cmd = new SqlCommand("Sp_DeleteFarmer", con);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@FID", farmerid);
			int i = cmd.ExecuteNonQuery();
			con.Close();
			return i;
		}


	}
}
