using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeePortal
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ImageChange();
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            ImageChange();

        }

        private void ImageChange()
        {
            string BannerPath = Server.MapPath("")+ "\\BannerImage\\";
            //Getting no of files count from directory and incrementing by 1
            int NextCount = Directory.GetFiles(BannerPath, "*", SearchOption.TopDirectoryOnly).Length + 1;
            Random ran = new Random();
            int i = ran.Next(1, NextCount);

            if (Directory.GetFiles(BannerPath, i.ToString() + ".jpg", SearchOption.TopDirectoryOnly).Length==1)
            {
                Image1.ImageUrl = "~/BannerImage/" + i.ToString() + ".jpg";
            }
            else if (Directory.GetFiles(BannerPath, i.ToString() + ".png", SearchOption.TopDirectoryOnly).Length == 1)
            {
                Image1.ImageUrl = "~/BannerImage/" + i.ToString() + ".png";
            }
            
        }
    }
}