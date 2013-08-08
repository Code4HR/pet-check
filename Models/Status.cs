using System;
using System.Collections.Generic;

namespace APHIS.Models
{
    public partial class Status
    {
        public int cid { get; set; }
        public Nullable<int> CustomerNumber { get; set; }
        public string USDACertificateNumber { get; set; }
        public string USDACertificateCurrentStatus { get; set; }
        public string USDACertificateBeginDate { get; set; }
        public string USDACertificateCurrentStatusDate { get; set; }
    }
}
