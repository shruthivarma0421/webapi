using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webapi.Models
{
    public class MemberClaimDetails
    {

        public int MemberID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime ClaimDate { get; set; }
        public Double ClaimAmount { get; set; }
    }
}