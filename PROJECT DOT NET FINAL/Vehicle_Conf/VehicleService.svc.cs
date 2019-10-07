using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Vehicle_Conf
{
    
    public class VehicleService : IVehicleService
    {
        private static VehicleBusinessLayer vehicle = new VehicleBusinessLayer();


        bool IVehicleService.addRegistrationDetails(RegistrationData rd)
        {
            return vehicle.addRegDetails(rd);
        }

        List<SegmentData> IVehicleService.getAllSegment()
        {
            return vehicle.getAllSeg();
        }


        List<ManufacturerData> IVehicleService.getManufacturerBySegId(string id)
        {
            int segid = Convert.ToInt32(id);
            return vehicle.getManBySegId(segid);
        }

        List<ConfigurationData> IVehicleService.getExteriorConfigurableByVarId(string varid)
        {
            int vid = Convert.ToInt32(varid);
            return vehicle.getExConfByVarId(vid);
        }

        List<ConfigurationData> IVehicleService.getInteriorConfigurableByVarId(string varid)
        {
            int vid = Convert.ToInt32(varid);
            return vehicle.getInConfByVarId(vid);
        }

        List<ConfigurationData> IVehicleService.getStandardConfigurableByVarId(string varid)
        {
            int vid = Convert.ToInt32(varid);
            return vehicle.getStandardConfByVarId(vid);
        }

        List<VariantData> IVehicleService.getVariantBySegIdnManId(string mmanid)
        {
            //int segid = Convert.ToInt32(ssegid);
            int manid = Convert.ToInt32(mmanid);
            return vehicle.getVarBySegnManId(manid);
        }


        List<ConfigurationData> IVehicleService.getDefaultFeatureByVarId(string vid)
        {
            int varid = Convert.ToInt32(vid);
            return vehicle.getDefaultFeature(varid);
        }

        List<ConfigurationData> IVehicleService.getStandardFeatureByVarId(string vid)
        {
            int varid = Convert.ToInt32(vid);
            return vehicle.getStandardFeature(varid);
        }

        List<ConfigurationData> IVehicleService.getInteriorFeatureByVarId(string vid)
        {
            int varid = Convert.ToInt32(vid);
            return vehicle.getInteriorFeature(varid);
        }

        List<ConfigurationData> IVehicleService.getExteriorFeatureByVarId(string vid)
        {
            int varid = Convert.ToInt32(vid);
            return vehicle.getExteriorFeature(varid);
        }


        List<AlternateData> IVehicleService.getAltDespByConfId(string confid)
        {
            int cid = Convert.ToInt32(confid);
            return vehicle.getAltDespnPriceByConfId(cid);
        }

        string IVehicleService.getCredentials(string loginid, string password)
        {
            return vehicle.getLoginIdAndPassword(loginid, password);
        }




        RegistrationData IVehicleService.getUserDetails(string id)
        {
            int companyid = Convert.ToInt32(id);
            return vehicle.getUserInfo(companyid);
        }


        List<VariantData> IVehicleService.getVariantByVarId(string vid)
        {
            int varid = Convert.ToInt32(vid);
            return vehicle.getVarByVarId(varid);
        }


        List<AlternateData> IVehicleService.getAlternateConfigurationByAltId(string altid)
        {
            int aid = Convert.ToInt32(altid);
            return vehicle.getAltDespByAltId(aid);
        }
    }
}
