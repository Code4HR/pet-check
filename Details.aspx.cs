using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using APHIS.Models;

namespace APHIS
{
    public partial class Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               string id = Request.QueryString["id"];

                if (isNumeric(id, System.Globalization.NumberStyles.Integer))
                {
                    long iid = Convert.ToInt64(id);
                    GetDetails(iid);
                }
                else
                    lblDetails.Text = id + " Invalid Inspection ID";
            }
        }

        private void GetDetails(long id)
        {
            string output = "The USDA has not made the details of this inspection public.<br/> You can request the information here: <a href=" + "\"http://www.aphis.usda.gov/foia/\"" + ">FOIA Request</a>";
            using (var insp = new InspectionContext())
            {
                var qry = from i in insp.inspectionDetails
                          where i.InspectionID == id
                          orderby i.USDACertificateNumber descending
                          select i;
                if (qry.Count() > 0)
                {                    
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("<br/><br/>");
                    sb.AppendLine("<table><tr><th>AWA Section</th><th>Section Description</th></tr>");
                    foreach (var item in qry)
                    {
                            sb.AppendFormat("<tr><td>{0}</td><td>{1}</td></tr>", item.CFRCitationSection, item.NCICFRCitationDescription );
                     }

                    sb.AppendLine("</table>");
                    sb.Append("<br/><br/>");
                    sb.Append("<b>For detailed information of these violations you can view the inspecting officer's notes by searching for this license on the <a href=" + "\"http://acissearch.aphis.usda.gov/LPASearch/faces/CustomerSearch.jspx \"" + ">USDA Site</a>.</b>");
                    sb.Append("<br/><br/>");

                    output = sb.ToString();
                }
            
            }
            lblDetails.Text = output;
        }

        public bool isNumeric(string val, System.Globalization.NumberStyles NumberStyle)
        {
            Double result;
            return Double.TryParse(val, NumberStyle, System.Globalization.CultureInfo.CurrentCulture, out result);
        }

    }
}