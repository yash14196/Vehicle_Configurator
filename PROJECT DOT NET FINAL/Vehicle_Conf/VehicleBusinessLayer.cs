using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace Vehicle_Conf
{

    public class VehicleBusinessLayer
    {
        public static SqlConnection getConnetion()
        {
            string cs = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            return con;
        }

        public bool addRegDetails(RegistrationData rd)
        {
            SqlConnection con=null;
          
            try
            {
                con = getConnetion();
                string query = "insert into Registration_Table (company_name,login_id,password,customer_name,designation,email_id,address_line_1,address_line_2,city,state,pincode,company_tel,company_fax,holding,customer_tel,customer_mob,vat_no,pan_no) values(@company_name,@login_id,@password,@customer_name,@designation,@email_id,@address_line_1,@address_line_2,@city,@state,@pincode,@company_tel,@company_fax,@holding,@customer_tel,@customer_mob,@vat_no,@pan_no)";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.AddWithValue("@company_name", rd.company_name);
                cmd.Parameters.AddWithValue("@login_id", rd.login_id);
                cmd.Parameters.AddWithValue("@password", rd.password);
                cmd.Parameters.AddWithValue("@customer_name", rd.customer_name);
                cmd.Parameters.AddWithValue("@designation", rd.designation);
                cmd.Parameters.AddWithValue("@email_id", rd.email_id);
                cmd.Parameters.AddWithValue("@address_line_1", rd.address_line_1);
                cmd.Parameters.AddWithValue("@address_line_2", rd.address_line_2);
                cmd.Parameters.AddWithValue("@city", rd.city);
                cmd.Parameters.AddWithValue("@state", rd.state);
                cmd.Parameters.AddWithValue("@pincode", rd.pincode);
                cmd.Parameters.AddWithValue("@company_tel", rd.company_tel);
                cmd.Parameters.AddWithValue("@company_fax", rd.company_fax);
                cmd.Parameters.AddWithValue("@holding", rd.holding);
                cmd.Parameters.AddWithValue("@customer_tel", rd.customer_tel);
                cmd.Parameters.AddWithValue("@customer_mob", rd.customer_mob);
                cmd.Parameters.AddWithValue("@vat_no", rd.vat_no);
                cmd.Parameters.AddWithValue("@pan_no", rd.pan_no);

                int result = cmd.ExecuteNonQuery();
                Console.WriteLine(result);
                if (result > 0)
                    return true;
                else
                    return false;
                
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
            
        }

        public List<SegmentData> getAllSeg()
        {
            List<SegmentData> segList=new List<SegmentData>();
            SqlConnection con=null;
            try
            {

                con = getConnetion();
                string query = "select * from Segment_Table";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        SegmentData s = new SegmentData();
                        s.seg_id = Convert.ToInt32(sdr["seg_id"]);
                        s.seg_name = sdr["seg_name"].ToString();

                        segList.Add(s);
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
            return segList;
        }


        public List<ManufacturerData> getManBySegId(int id)
        {
            List<ManufacturerData> manList = new List<ManufacturerData>();
            SqlConnection con = null;
            try
            {
                con = getConnetion();
                SqlCommand cmd = new SqlCommand("getmanufacturerbysegid", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@segid", SqlDbType.Int).Value = id;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        ManufacturerData m = new ManufacturerData();
                        //m.man_id = 0;
                        m.man_id = Convert.ToInt32(sdr["man_id"]);
                        m.man_name = sdr["man_name"].ToString();
                        manList.Add(m);
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
            return manList;
        }

        public List<VariantData> getVarBySegnManId(int manid)
        {
            List<VariantData> varList = new List<VariantData>();
            SqlConnection con = null;

            try
            {
                con = getConnetion();
                string query = "select var_id, var_name, min_qty, base_price from Variant_Table where man_id = @manid";

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                //cmd.Parameters.AddWithValue("@segid", segid);
               
                cmd.Parameters.AddWithValue("@manid", manid);

                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        VariantData v = new VariantData();
                        v.var_id = Convert.ToInt32(sdr["var_id"]);
                        v.var_name = sdr["var_name"].ToString();
                        v.min_qty = Convert.ToInt32(sdr["min_qty"]);
                        v.base_price = Convert.ToDouble(sdr["base_price"]);
                        varList.Add(v);
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally{
                con.Close();
            }
            return varList;
        }


        public List<VariantData> getVarByVarId(int varid)
        {
            List<VariantData> varList = new List<VariantData>();
            SqlConnection con = null;

            try
            {
                con = getConnetion();
                string query = "select * from Variant_Table where var_id = @varid";

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                //cmd.Parameters.AddWithValue("@segid", segid);

                cmd.Parameters.AddWithValue("@varid", varid);

                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        VariantData v = new VariantData();
                        v.var_id = Convert.ToInt32(sdr["var_id"]);
                        v.var_name = sdr["var_name"].ToString();
                        v.min_qty = Convert.ToInt32(sdr["min_qty"]);
                        v.base_price = Convert.ToDouble(sdr["base_price"]);
                        v.image = sdr["image"].ToString();
                        varList.Add(v);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
            return varList;
        }


        public List<ConfigurationData> getDefaultFeature(int varid)
        {
            List<ConfigurationData> conList = new List<ConfigurationData>();
            SqlConnection con = null;
            try
            {
                con = getConnetion();
                SqlCommand cmd = new SqlCommand("select description from Configuration_Table where type='d' and var_id=@varid", con);
                cmd.Parameters.AddWithValue("@varid", varid);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        ConfigurationData c = new ConfigurationData();
                        c.description = sdr["description"].ToString();
                        conList.Add(c);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
            return conList;
        }

        public List<ConfigurationData> getStandardFeature(int varid)
        {
            List<ConfigurationData> conList = new List<ConfigurationData>();
            SqlConnection con = null;
            try
            {
                con = getConnetion();
                SqlCommand cmd = new SqlCommand("select description from Configuration_Table where type='s' and var_id=@varid", con);
                cmd.Parameters.AddWithValue("@varid", varid);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        ConfigurationData c = new ConfigurationData();
                        c.description = sdr["description"].ToString();
                        conList.Add(c);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
            return conList;
        }

        public List<ConfigurationData> getInteriorFeature(int varid)
        {
            List<ConfigurationData> conList = new List<ConfigurationData>();
            SqlConnection con = null;
            try
            {
                con = getConnetion();
                SqlCommand cmd = new SqlCommand("select description from Configuration_Table where type='i' and var_id=@varid", con);
                cmd.Parameters.AddWithValue("@varid", varid);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        ConfigurationData c = new ConfigurationData();
                        c.description = sdr["description"].ToString();
                        conList.Add(c);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
            return conList;
        }


        public List<ConfigurationData> getExteriorFeature(int varid)
        {
            List<ConfigurationData> conList = new List<ConfigurationData>();
            SqlConnection con = null;
            try
            {
                con = getConnetion();
                SqlCommand cmd = new SqlCommand("select description from Configuration_Table where type='e' and var_id=@varid", con);
                cmd.Parameters.AddWithValue("@varid", varid);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        ConfigurationData c = new ConfigurationData();
                        c.description = sdr["description"].ToString();
                        conList.Add(c);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
            return conList;
        }


        public List<AlternateData> getAltDespnPriceByConfId(int confid)
        {
            List<AlternateData> altList = new List<AlternateData>();
            SqlConnection con = null;
            try
            {
                con = getConnetion();
                SqlCommand cmd = new SqlCommand("select alt_id, alt_desp, alt_price from Alternate_Table where conf_id=@confid", con);
                con.Open();
                cmd.Parameters.AddWithValue("@confid", confid);
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        AlternateData a = new AlternateData();
                        a.alt_id = Convert.ToInt32(sdr["alt_id"]);
                        a.alt_desp = sdr["alt_desp"].ToString();
                        a.alt_price = Convert.ToDouble(sdr["alt_price"]);
                        altList.Add(a);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
            return altList;
        }



        public string getLoginIdAndPassword(string loginid, string pwd)
        {
            SqlConnection con = null;
            string id = null;
            try
            {
                con = getConnetion();
                SqlCommand cmd = new SqlCommand("select company_id from Registration_Table where login_id=@loginid and password=@pwd", con);
                cmd.Parameters.AddWithValue("@loginid", loginid);
                cmd.Parameters.AddWithValue("@pwd", pwd);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        id = (sdr["company_id"]).ToString();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }

            return id;
        }

        public RegistrationData getUserInfo(int companyid)
        {
            SqlConnection con = null;
            RegistrationData rd = new RegistrationData();
            try
            {
                con = getConnetion();
                SqlCommand cmd = new SqlCommand("select * from Registration_Table where company_id=@companyid", con);
                con.Open();
                cmd.Parameters.AddWithValue("@companyid", companyid);
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        rd.company_id = Convert.ToInt32(sdr["company_id"]);
                        rd.company_name = sdr["company_name"].ToString();
                        rd.customer_name = sdr["customer_name"].ToString();
                        rd.designation = sdr["designation"].ToString();
                        rd.email_id = sdr["email_id"].ToString();
                        rd.address_line_1 = sdr["address_line_1"].ToString();
                        rd.address_line_2 = sdr["address_line_2"].ToString();
                        rd.city = sdr["city"].ToString();
                        rd.state = sdr["state"].ToString();
                        rd.pincode = Convert.ToInt32(sdr["pincode"]);
                        rd.company_tel = sdr["company_tel"].ToString();
                        rd.company_fax = sdr["company_fax"].ToString();
                        rd.holding = sdr["holding"].ToString();
                        rd.customer_tel = sdr["customer_tel"].ToString();
                        rd.customer_mob = sdr["customer_mob"].ToString();
                        rd.vat_no = sdr["vat_no"].ToString();
                        rd.pan_no = sdr["pan_no"].ToString();
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally{
                con.Close();
            }
            return rd;
        }

        public List<ConfigurationData> getExConfByVarId(int varid)
        {
            List<ConfigurationData> conList = new List<ConfigurationData>();
            SqlConnection con = null;
            try
            {
                con = getConnetion();
                SqlCommand cmd = new SqlCommand("select conf_id, description from Configuration_Table where type='e' and var_id=@varid and configurable='y'", con);
                cmd.Parameters.AddWithValue("@varid", varid);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        ConfigurationData c = new ConfigurationData();
                        c.conf_id = Convert.ToInt32(sdr["conf_id"]);
                        c.description = sdr["description"].ToString();
                        conList.Add(c);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
            return conList;
        }

        public List<ConfigurationData> getInConfByVarId(int varid)
        {
            List<ConfigurationData> conList = new List<ConfigurationData>();
            SqlConnection con = null;
            try
            {
                con = getConnetion();
                SqlCommand cmd = new SqlCommand("select conf_id, description from Configuration_Table where type='i' and var_id=@varid and configurable='y'", con);
                cmd.Parameters.AddWithValue("@varid", varid);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        ConfigurationData c = new ConfigurationData();
                        c.conf_id = Convert.ToInt32(sdr["conf_id"]);
                        c.description = sdr["description"].ToString();
                        conList.Add(c);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
            return conList;
        }

        public List<ConfigurationData> getStandardConfByVarId(int varid)
        {
            List<ConfigurationData> conList = new List<ConfigurationData>();
            SqlConnection con = null;
            try
            {
                con = getConnetion();
                SqlCommand cmd = new SqlCommand("select conf_id, description from Configuration_Table where type='s' and var_id=@varid and configurable='y'", con);
                cmd.Parameters.AddWithValue("@varid", varid);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        ConfigurationData c = new ConfigurationData();
                        c.conf_id = Convert.ToInt32(sdr["conf_id"]);
                        c.description = sdr["description"].ToString();
                        conList.Add(c);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
            return conList;
        }

        public List<AlternateData> getAltDespByAltId(int altid)
        {
            List<AlternateData> altList = new List<AlternateData>();
            SqlConnection con = null;
            try
            {
                con = getConnetion();
                SqlCommand cmd = new SqlCommand("select alt_id, alt_desp, alt_price from Alternate_Table where alt_id=@altid", con);
                con.Open();
                cmd.Parameters.AddWithValue("@altid", altid);
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        AlternateData a = new AlternateData();
                        a.alt_id = Convert.ToInt32(sdr["alt_id"]);
                        a.alt_desp = sdr["alt_desp"].ToString();
                        a.alt_price = Convert.ToDouble(sdr["alt_price"]);
                        altList.Add(a);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
            return altList;
        }

    }
}