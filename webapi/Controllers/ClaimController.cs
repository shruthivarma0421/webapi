using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webapi.Models;
using CsvHelper;
using System.Globalization;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace webapi.Controllers
{
    public class ClaimController : ApiController
    {
        // GET: api/Claim
        public HttpResponseMessage Get(DateTime dateParam)
        {

            List<Members> memberRecords = new List<Members>();
            List<Claims> claimRecords = new List<Claims>();
            var paths = Directory.GetFiles(@"C:\Users\Documents\Visual Studio 2015\Projects\webapi\", "*.csv");
            foreach (var P in paths)
            {
                TextReader reader = new StreamReader(P);
                var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                if (P.Contains("Member"))
                {

                    memberRecords = csv.GetRecords<Members>().ToList();
                }
                else
                {
                    claimRecords = csv.GetRecords<Claims>().ToList();
                }
            }

            try
            {
                var membelaimDetails = (from m in memberRecords
                                        join c in claimRecords on m.MemberID equals c.MemberID
                                        where c.ClaimDate == dateParam
                                        select new MemberClaimDetails()
                                        {
                                            MemberID = m.MemberID,
                                            FirstName = m.FirstName,
                                            LastName = m.LastName,
                                            ClaimAmount = c.ClaimAmount,
                                            ClaimDate = c.ClaimDate

                                        }).ToList();

                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(JsonConvert.SerializeObject(membelaimDetails));
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                return response;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

 
  
    }
}
