using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace Vehicle_Conf
{
 
    [ServiceContract]
    public interface IVehicleService
    {
        [OperationContract]
        [WebInvoke(Method = "POST",
          RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Bare,
          UriTemplate = "/AddRegistrationDetails")]
        bool addRegistrationDetails(RegistrationData rd);


        [OperationContract]
        [WebInvoke(Method = "GET",
          RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Bare,
          UriTemplate = "/GetCredentials/{loginid}/{password}")]
        string getCredentials(string loginid,string password);

        [OperationContract]
        [WebInvoke(Method = "GET",
          RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Bare,
          UriTemplate = "/GetUserDetails/{id}")]
        RegistrationData getUserDetails(string id);

        [OperationContract]
        [WebInvoke(Method = "GET",
          RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Bare,
          UriTemplate = "/GetAllSegment")]
        List<SegmentData> getAllSegment();

        [OperationContract]
        [WebInvoke(Method = "GET",
          RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Bare,
          UriTemplate = "/GetManufacturerBySegId/{id}")]
        List<ManufacturerData> getManufacturerBySegId(string id);

        [OperationContract]
        [WebInvoke(Method = "GET",
          RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Bare,
          UriTemplate = "/GetVariantBySegIdnManId/{manid}")]
        List<VariantData> getVariantBySegIdnManId(string manid);

        [OperationContract]
        [WebInvoke(Method = "GET",
          RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Bare,
          UriTemplate = "/GetDefaultFeature/{varid}")]
        List<ConfigurationData> getDefaultFeatureByVarId(string varid);

        [OperationContract]
        [WebInvoke(Method = "GET",
          RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Bare,
          UriTemplate = "/GetStandardFeature/{varid}")]
        List<ConfigurationData> getStandardFeatureByVarId(string varid);


        [OperationContract]
        [WebInvoke(Method = "GET",
          RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Bare,
          UriTemplate = "/GetInteriorFeature/{varid}")]
        List<ConfigurationData> getInteriorFeatureByVarId(string varid);


        [OperationContract]
        [WebInvoke(Method = "GET",
          RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Bare,
          UriTemplate = "/GetExteriorFeature/{varid}")]
        List<ConfigurationData> getExteriorFeatureByVarId(string varid);


        [OperationContract]
        [WebInvoke(Method = "GET",
          RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Bare,
          UriTemplate = "/GetAltDespByConfId/{confid}")]
        List<AlternateData> getAltDespByConfId(string confid);

        [OperationContract]
        [WebInvoke(Method = "GET",
          RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Bare,
          UriTemplate = "/GetVariantByVarId/{varid}")]
        List<VariantData> getVariantByVarId(string varid);

        [OperationContract]
        [WebInvoke(Method = "GET",
          RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Bare,
          UriTemplate = "/GetExteriorConfigurableByVarId/{varid}")]
        List<ConfigurationData> getExteriorConfigurableByVarId(string varid);

        [OperationContract]
        [WebInvoke(Method = "GET",
          RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Bare,
          UriTemplate = "/GetInteriorConfigurableByVarId/{varid}")]
        List<ConfigurationData> getInteriorConfigurableByVarId(string varid);

        [OperationContract]
        [WebInvoke(Method = "GET",
          RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Bare,
          UriTemplate = "/GetStandardConfigurableByVarId/{varid}")]
        List<ConfigurationData> getStandardConfigurableByVarId(string varid);

        [OperationContract]
        [WebInvoke(Method = "GET",
          RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Bare,
          UriTemplate = "/GetAlternateConfigurationByAltId/{altid}")]
        List<AlternateData> getAlternateConfigurationByAltId(string altid);
    }
}
