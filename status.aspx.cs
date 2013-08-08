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
    public partial class status : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string txtLic = Request.QueryString["id"];

                Regex licregex = new Regex("[0-9][0-9]-[ABCD]-[0-9][0-9][0-9][0-9]");
                Match m = licregex.Match(txtLic);
                if (m.Success)
                {
                    GetStatusInfo(txtLic);
                }
                else
                {
                    lblOutput.Text = txtLic + " is an incorrect format. A USDA License is always in this format: 99-A-9999";
                }
            }
        }

        private void GetStatusInfo(string txtLic)
        {
            lblOutput.Text = "No information about this license is in our database. <br/>You may be able to obtain more information here: <br/><br/><a href=" + "\"http://acissearch.aphis.usda.gov/LPASearch/faces/CustomerSearch.jspx \"" + ">acissearch</a>";
            using (var insp = new InspectionContext())
            {
                // Get the Customer Number for this licensee
                var qryCustNum = from ic in insp.Status
                                 where ic.USDACertificateNumber == txtLic
                          orderby ic.USDACertificateNumber descending
                          select ic;
                
                foreach(var CN in qryCustNum){
                    var qry = from i in insp.Status
                              where i.CustomerNumber == CN.CustomerNumber
                              orderby i.USDACertificateNumber descending
                              select i;

                    if (qry.Count() >= 1)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine("<br/><br/>");
                        sb.AppendLine("<table>");
                        if (qry.Count() == 1)
                        {
                            foreach (var item in qry)
                            {
                                sb.AppendFormat("<tr><td>The license {0} was issued on {1} and as of {3} has a status of {2} </td></tr>", item.USDACertificateNumber, CleanDate(item.USDACertificateBeginDate), item.USDACertificateCurrentStatus, CleanDate(item.USDACertificateCurrentStatusDate));
                            }
                        }
                        else
                        {
                            sb.AppendFormat("<tr><td>The licensee has multiple licenses.</td></tr>");
                            string strStatus = "";
                            foreach (var item in qry)
                            {
                                switch (item.USDACertificateCurrentStatus.TrimStart().TrimEnd()) {
                                    case "CANCELLED":
                                        strStatus = "<font color=\"red\"><b>CANCELLED</b><font>";
                                        break;
                                    case "REVOKED":
                                        strStatus = "<font color=\"red\"><b>REVOKED</b><font>";
                                        break;
                                    default:
                                        strStatus = item.USDACertificateCurrentStatus;
                                        break;
                                }
                                sb.AppendFormat("<tr><td>The license {0} was issued on {1} and as of {3} has a status of {2} </td></tr>", item.USDACertificateNumber, item.USDACertificateBeginDate, strStatus, item.USDACertificateCurrentStatusDate);
                            }
                        }
                        sb.AppendLine("</table>");
                        lblOutput.Text = sb.ToString();
                    }
                }
                
            }                        
        }

        private string CleanDate(string p)
        {
            return p.Substring(0, p.IndexOf("("));
        }

    }
}