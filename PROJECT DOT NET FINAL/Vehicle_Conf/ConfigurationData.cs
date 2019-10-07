using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Vehicle_Conf
{
    [DataContract]
    public class ConfigurationData
    {
        [DataMember]
        public int conf_id { get; set; }

        [DataMember]
        public int var_id { get; set; }

        [DataMember]
        public string type { get; set; }

        [DataMember]
        public string description { get; set; }
    }
}