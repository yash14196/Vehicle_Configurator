using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
namespace Vehicle_Conf
{
    [DataContract]
    public class SegmentData
    {
        [DataMember]
        public int seg_id { get; set; }

        [DataMember]
        public string seg_name { get; set; }

    }
}