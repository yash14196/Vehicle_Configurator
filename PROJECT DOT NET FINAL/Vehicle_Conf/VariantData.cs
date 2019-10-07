using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Vehicle_Conf
{
    [DataContract]
    public class VariantData
    {
        [DataMember]
        public int var_id { get; set; }

        [DataMember]
        public string var_name { get; set; }

        [DataMember]
        public int seg_id { get; set; }

        [DataMember]
        public int man_id { get; set; }

        [DataMember]
        public int min_qty { get; set; }

        [DataMember]
        public double base_price { get; set; }

        [DataMember]
        public string image { get; set; }
    }
}