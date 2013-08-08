using System;
using System.Collections.Generic;

namespace APHIS.Models
{
    public partial class inspection
    {
        public int IID { get; set; }
        public Nullable<int> CountCitations { get; set; }
        public Nullable<int> CustomerNumber { get; set; }
        public string InspectionDate { get; set; }
        public Nullable<long> InspectionID { get; set; }
        public string InspectionInventoryAnimalsCommonName { get; set; }
        public Nullable<int> InspectionInventoryCount { get; set; }
        public string USDACertificateNumber { get; set; }
    }
}
