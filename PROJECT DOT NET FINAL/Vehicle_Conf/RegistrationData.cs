using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Vehicle_Conf
{
    [DataContract]
    public class RegistrationData
    {
        [DataMember]
        public int company_id { get; set; }

        [DataMember]
        public string company_name { get; set; }

        [DataMember]
        public string login_id { get; set; }

        [DataMember]
        public string password { get; set; }

        [DataMember]
        public string customer_name { get; set; }

        [DataMember]
        public string designation { get; set; }

        [DataMember]
        public string email_id { get; set; }

        [DataMember]
        public string address_line_1 { get; set; }

        [DataMember]
        public string address_line_2 { get; set; }

        [DataMember]
        public string city { get; set; }

        [DataMember]
        public string state { get; set; }

        [DataMember]
        public int pincode { get; set; }

        [DataMember]
        public string company_tel { get; set; }

        [DataMember]
        public string company_fax { get; set; }

        [DataMember]
        public string holding { get; set; }

        [DataMember]
        public string customer_tel { get; set; }

        [DataMember]
        public string customer_mob { get; set; }

        [DataMember]
        public string vat_no { get; set; }

        [DataMember]
        public string pan_no { get; set; }
        }
}