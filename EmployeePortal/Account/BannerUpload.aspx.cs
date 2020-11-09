using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeePortal.Account
{
    public partial class BannerUpload : System.Web.UI.Page
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
            catch (Exception)
            {
                return null;
            }

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (fuBanner.HasFile)
            {
                string extension = System.IO.Path.GetExtension(fuBanner.FileName);

                if (extension == ".jpg" || extension == ".png")
                {
                    string BannerPath = Server.MapPath("").Substring(0, Server.MapPath("").LastIndexOf("\\")) + "\\BannerImage\\";
                    //Getting no of files count from directory and incrementing by 1
                    int NextCount = Directory.GetFiles(BannerPath, "*", SearchOption.TopDirectoryOnly).Length + 1;
                    //Renaming existing file with incremented built logic
                    string FileName = NextCount + fuBanner.FileName.Substring(fuBanner.FileName.LastIndexOf("."), fuBanner.FileName.Length - fuBanner.FileName.LastIndexOf("."));
                    string fullPath = BannerPath + FileName;
                    //Dumping the file in BannerImage folder under application.
                    fuBanner.SaveAs(fullPath);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Banner Uploaded successfully!');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Only Image upload allowed!');", true);
                }
            }
        }
    }
}