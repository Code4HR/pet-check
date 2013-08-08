using System;
using System.Collections.Generic;

namespace APHIS.Models
{
    public partial class inspectionDetail
    {
        public int DetailID { get; set; }
        public Nullable<long> InspectionID { get; set; }
        public string USDACertificateNumber { get; set; }
        public string CFRCitationSection { get; set; }
        public string NCICFRCitationDescription { get; set; }
        public string TypeofInspection { get; set; }
    }
}
