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
    public partial class _Default : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) { 
            //btnBack.Style.Add("display", "block");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (Page.IsPostBack)
            {
                lblInspection.Text = "";
                string txtLic = txtPre.Text + "-" + ddlType.SelectedValue + "-" + txtSuffix.Text;
                if (txtLic.Length > 0)
                {                    
                    Regex licregex = new Regex("[0-9][0-9]-[ABCD]-[0-9][0-9][0-9][0-9]");
                    Match m = licregex.Match(txtLic);
                    if (m.Success)
                    {
                        GetInspectionInfo(txtLic);
                    }
                    else
                    {
                        lblInspection.Text = txtLic + " is an incorrect format. A USDA License is always in this format: 99-A-9999";
                    }
                }
            }
        }

        private void GetInspectionInfo(string p)
        {
            string output = "No Inspections were found for this Licensee.<br/> <br/> Check <a href=status.aspx?id=" + p.Trim()  +">here</a> for information we may have on this licensee, or you may obtain more information here: <a href=" + "\"http://acissearch.aphis.usda.gov/LPASearch/faces/CustomerSearch.jspx \"" + ">acissearch</a>";
            using (var insp = new InspectionContext())
            {
                Response.Write(p + "<br/>");
                var qry = from i in insp.inspections
                          where i.USDACertificateNumber == p.Trim()                          
                          orderby i.InspectionDate descending
                          select i;
                string HTMLOut = "";
                long inspID = 0;
                string what = "";
                long howmany = 0;

                if (qry.Count() > 0)
                {
                    Response.Write("<br> COUNT: " +  qry.Count().ToString() + "<br>");
                    IntroBlurb.Style.Add("display", "none");
                    Instructions.InnerText = "Results for License: " + p.Trim();
                    HTMLOut = "<table>";
                    HTMLOut += "<tr><td>Check <a href=\"status.aspx?id=" + p.Trim() + "\">here</a> for information we may have on this licensee</td></tr>";
                    HTMLOut +="<tr><td>&nbsp;</td></tr>";
                    foreach (var item in qry)
                    {
                        //inspID = Int64.Parse(item.InspectionID.ToString());
                        if (item.CountCitations == 0) {                            
                            HTMLOut +="<tr><td>The " + CleanDate(item.InspectionDate) + " inspection had no violations.</td></tr><br/>";
                            HTMLOut += "<tr><td>&nbsp;</td></tr>";
                        } else {                            
                            if (item.InspectionInventoryAnimalsCommonName == "") {                  
                                HTMLOut +="<tr class=\"warn\"><td><a href=\"details.aspx?id="+ item.InspectionID.ToString() + "\">Inspection</a> was attempted on " + CleanDate(item.InspectionDate) + " but access was not possible.</td></tr>";
                                HTMLOut += "<tr><td>&nbsp;</td></tr>";
                            }
                            else
                            {
                                if (inspID != item.InspectionID) {
                                    howmany = Int64.Parse(item.CountCitations.ToString());
                                    what = item.InspectionInventoryCount.ToString() + " " + Pluralize(Int32.Parse(item.InspectionInventoryCount.ToString()), item.InspectionInventoryAnimalsCommonName);                                    
                                    HTMLOut += "<tr><td>The " + CleanDate(item.InspectionDate) + " <a href=\"details.aspx?id=" + item.InspectionID.ToString() + " \">Inspection</a> showed " + item.CountCitations.ToString() + " violation(s) on " + what + ".</td></tr>";
                                    HTMLOut += "<tr><td>&nbsp;</td></tr>";                                    
                                }else{
                                    what += " and " + item.InspectionInventoryCount.ToString() + " " + Pluralize(Int32.Parse(item.InspectionInventoryCount.ToString()), item.InspectionInventoryAnimalsCommonName);
                                    HTMLOut += "<tr><td>The " + CleanDate(item.InspectionDate) + " <a href=\"details.aspx?id=" + item.InspectionID.ToString() + " \">Inspection</a> showed " + item.CountCitations.ToString() + " violation(s) on " + what + ".</td></tr>";
                                    HTMLOut += "<tr><td>&nbsp;</td></tr>";                                    
                                }
                            }
                            inspID = Int64.Parse(item.InspectionID.ToString());
                        }
                    }
                    HTMLOut += "</table>";
                    output = HTMLOut;
                }
            }
            lblInspection.Text = output;
        }

        public string Pluralize(int counts, string critter)
        {
            string strAnimals;
            if (counts > 1)
            {
                switch (critter)
                {
                    case "DOG ADULT":
                        strAnimals = "DOGS";
                        break;
                    case "DOG PUPPY":
                        strAnimals = "PUPPIES";
                        break;
                    case "GUINEA PIG":
                        strAnimals = "GUINEA PIGS";
                        break;
                    default:
                        strAnimals = critter;
                        break;
                }
            }
            else
            {
                switch (critter)
                {
                    case "DOG ADULT":
                        strAnimals = "DOG";
                        break;
                    case "DOG PUPPY":
                        strAnimals = "PUPPY";
                        break;
                    default:
                        strAnimals = critter;
                        break;
                }
            }
            return strAnimals;
        }
        private string CleanDate(string p)
        {
            return p.Substring(0, p.IndexOf("("));
        }
    }
}