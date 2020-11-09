using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeePortal.Account
{
    public partial class UserLanding : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(Session["UserName"] as string))
                {
                    Response.Redirect("~/Default.aspx");
                }
                else 
                {
                    byte[] ImageByteArray = FetchImage(Convert.ToInt16(Session["userid"]));
                    imProfilePc.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String(ImageByteArray);
                    
                }
            }
            if (string.IsNullOrEmpty(Session["UserName"] as string))
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        protected byte[] FetchImage(int id)
        {
            try
            {
                byte[] bytes;
                string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "usp_loginCheck";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@type", 2);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            sdr.Read();
                            bytes = (byte[])sdr["ProfilePic"];
                        }
                        con.Close();
                    }
                }
                return bytes;
                
            }
            catch (Exception )
            {
                return null;
            }
            
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {

        }
    }
}