using System.Data.SqlClient;
using ClassLibraryDAL;
using ClassLibraryModel;
namespace BlazorServerAuthenticationAndAuthorization.Authentication
{
    public class UserAccountService
    {
        private List<UserAccount> _users;
        
        public UserAccountService()
        {
            SqlConnection con = DBContext.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_GetUserNameandPass", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            _users= new List<UserAccount>();
            while (dr.Read())
            {
                UserAccount _user = new UserAccount();
                _user.UserName = dr["farmerContact"].ToString();
                _user.Password = dr["farmerPIN"].ToString();
                _users.Add(_user);
            }
            con.Close();
        }

        public UserAccount? GetByUserName(string userName)
        {
            return _users.FirstOrDefault(x => x.UserName == userName);
        }
    }
}
