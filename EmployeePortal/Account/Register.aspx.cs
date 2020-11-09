using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Membership.OpenAuth;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace EmployeePortal.Account
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
            
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            int length = fuProfile.PostedFile.ContentLength;
            string contentType = fuProfile.PostedFile.ContentType;
            if (length > 0)
            {
                if (length <= 100000)
                {
                    using (Stream fs = fuProfile.PostedFile.InputStream)
                    {
                        using (BinaryReader br = new BinaryReader(fs))
                        {
                            byte[] bytes = br.ReadBytes((Int32)fs.Length);
                            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                            using (SqlConnection con = new SqlConnection(constr))
                            {
                                using (SqlCommand cmd = new SqlCommand())
                                {
                                    cmd.CommandText = "usp_RegisterUser";
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Connection = con;
                                    cmd.Parameters.AddWithValue("@UserName", UserName.Text.ToString());
                                    cmd.Parameters.AddWithValue("@password", Encrypt(Password.Text.ToString()));
                                    cmd.Parameters.AddWithValue("@ContentType", contentType);
                                    cmd.Parameters.AddWithValue("@ProfilePic", bytes);
                                    //con.Open();
                                    //i = cmd.ExecuteNonQuery();
                                    //con.Close();
                                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                                    da.Fill(dt);
                                }
                            }
                        }
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Maximum size of Image upload is 100 KB!');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Image mandatory to upload!');", true);
            }
            if (dt.Rows.Count >= 1)
            {
                if (Convert.ToInt16(dt.Rows[0]["CNT"].ToString()) == 1)
                {
                    
                    UserName.Text = "";
                    Response.Redirect("Login.aspx");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('User registered successfully now proceed with Login');", true);
                }
                else if (Convert.ToInt16(dt.Rows[0]["CNT"].ToString()) == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('User Already present, Duplicate not allowed!');", true);
                }
            }
        }

        private string Encrypt(string clearText)
        {
            string EncryptionKey = "V1I2V3E4K";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        
    }
}