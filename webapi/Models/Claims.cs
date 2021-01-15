using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webapi.Models
{
    public class Claims
    {
        public int MemberID { get; set; }
        public DateTime ClaimDate { get; set; }
        public Double ClaimAmount { get; set; }
    }
}