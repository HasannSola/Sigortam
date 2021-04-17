using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Sigortam.Service.Model
{
    [DataContract]
    public class OfferModel
    {
        [DataMember]
        public string ConpanyName { get; set; }
        [DataMember]
        public string ConpanyLogo { get; set; }
        [DataMember]
        public string Desc { get; set; }
        [DataMember]
        public long Price { get; set; }
        [DataMember]
        public string Plate { get; set; }
    }
}