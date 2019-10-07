using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Vehicle_Conf
{
    [DataContract]
    public class AlternateData
    {
        [DataMember]
        public int alt_id { get; set; }

        [DataMember]
        public int conf_id { get; set; }

        [DataMember]
        public string alt_desp { get; set; }

        [DataMember]
        public double alt_price { get; set; }
    }
}