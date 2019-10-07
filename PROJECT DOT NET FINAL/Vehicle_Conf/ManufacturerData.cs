using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Vehicle_Conf
{
    [DataContract]
    public class ManufacturerData
    {
        [DataMember]
        public int man_id { get; set; }

        [DataMember]
        public string man_name { get; set; }
    }
}