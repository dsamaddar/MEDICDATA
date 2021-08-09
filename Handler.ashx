<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;

public class Handler : IHttpHandler
{
    ClsDataset Obj = new ClsDataset();

    public void ProcessRequest(HttpContext context)
    {
        try
        {
            switch (context.Request.PathInfo.Split('/')[1])
            {
                case "SaveCaseDetailHandler":
                    using (var reader = new System.IO.StreamReader(context.Request.InputStream))
                    {
                        string values = reader.ReadToEnd();

                        JsonData jd = new JsonData();
                        if (jd != null)
                        {
                            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
                            jd = js.Deserialize<JsonData>(values);

                            int Result = 0;
                            Result = SaveCaseDetailHandler(jd.RecId, jd.ServiceId, jd.HType, jd.CaseType, jd.Gender, jd.CMonth, jd.CYear, jd.CDay, jd.CVal, jd.CreatedBy, jd.StateId);
                            if (Result > 0)
                            {
                                context.Response.Write("db save success");
                            }
                            else
                            {
                                context.Response.Write("db save error");
                            }
                        }
                        else
                        {
                            context.Response.Write("json not found");
                        }
                    }
                    break;
                case "SaveHospitalBedsDetailsHandler":
                    using (var reader = new System.IO.StreamReader(context.Request.InputStream))
                    {
                        string values = reader.ReadToEnd();

                        JsonDataAllBed jd = new JsonDataAllBed();
                        System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
                        jd = js.Deserialize<JsonDataAllBed>(values);
                        if (jd != null)
                        {
                            int Result = 0;
                            Result = SaveHospitalBedsDetailsHandler(jd.RecId, jd.ServiceId, jd.CompanyId, jd.StateId, jd.CMonth, jd.CYear, jd.CDay, jd.CVal, jd.CreatedBy, jd.HType);
                            if (Result > 0)
                            {
                                context.Response.Write("db save success");
                            }
                            else
                            {
                                context.Response.Write("db save error");
                            }
                        }
                        else
                        {
                            context.Response.Write("json not found");
                        }
                    }
                    break;
                case "SavePatientAdmitOutcomesHandler":
                    using (var reader = new System.IO.StreamReader(context.Request.InputStream))
                    {
                        string values = reader.ReadToEnd();

                        JsonDataAllBed jd = new JsonDataAllBed();
                        System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
                        jd = js.Deserialize<JsonDataAllBed>(values);
                        if (jd != null)
                        {
                            int Result = 0;
                            Result = SavePatientAdmitOutcomesHandler(jd.RecId, jd.ServiceId, jd.CompanyId, jd.StateId, jd.CMonth, jd.CYear, jd.CDay, jd.CVal, jd.CreatedBy, jd.HType);
                            if (Result > 0)
                            {
                                context.Response.Write("db save success");
                            }
                            else
                            {
                                context.Response.Write("db save error");
                            }
                        }
                        else
                        {
                            context.Response.Write("json not found");
                        }
                    }
                    break;
                case "SaveBlindnessPrevProgHandler":
                    using (var reader = new System.IO.StreamReader(context.Request.InputStream))
                    {
                        string values = reader.ReadToEnd();

                        JsonDataAllBed jd = new JsonDataAllBed();
                        System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
                        jd = js.Deserialize<JsonDataAllBed>(values);
                        if (jd != null)
                        {
                            int Result = 0;
                            Result = SaveBlindnessPrevProgHandler(jd.RecId, jd.ServiceId, jd.CompanyId, jd.StateId, jd.CMonth, jd.CYear, jd.CDay, jd.CVal, jd.CreatedBy, jd.HType);
                            if (Result > 0)
                            {
                                context.Response.Write("db save success");
                            }
                            else
                            {
                                context.Response.Write("db save error");
                            }
                        }
                        else
                        {
                            context.Response.Write("json not found");
                        }
                    }
                    break;
                case "SaveDentalProcedureHandler":
                    using (var reader = new System.IO.StreamReader(context.Request.InputStream))
                    {
                        string values = reader.ReadToEnd();

                        JsonDataAllBed jd = new JsonDataAllBed();
                        System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
                        jd = js.Deserialize<JsonDataAllBed>(values);
                        if (jd != null)
                        {
                            int Result = 0;
                            Result = SaveDentalProcedureHandler(jd.RecId, jd.ServiceId, jd.CompanyId, jd.StateId, jd.CMonth, jd.CYear, jd.CDay, jd.CVal, jd.CreatedBy, jd.HType);
                            if (Result > 0)
                            {
                                context.Response.Write("db save success");
                            }
                            else
                            {
                                context.Response.Write("db save error");
                            }
                        }
                        else
                        {
                            context.Response.Write("json not found");
                        }
                    }
                    break;
                case "SaveMaternalHealthHandler":
                    using (var reader = new System.IO.StreamReader(context.Request.InputStream))
                    {
                        string values = reader.ReadToEnd();

                        JsonDataAllBed jd = new JsonDataAllBed();
                        System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
                        jd = js.Deserialize<JsonDataAllBed>(values);
                        if (jd != null)
                        {
                            int Result = 0;
                            Result = SaveMaternalHealthHandler(jd.RecId, jd.ServiceId, jd.CompanyId, jd.StateId, jd.CMonth, jd.CYear, jd.CDay, jd.CVal, jd.CreatedBy,jd.HType);
                            if (Result > 0)
                            {
                                context.Response.Write("db save success");
                            }
                            else
                            {
                                context.Response.Write("db save error");
                            }
                        }
                        else
                        {
                            context.Response.Write("json not found");
                        }
                    }
                    break;

                case "SaveLiveBirthWeightHandler":
                    using (var reader = new System.IO.StreamReader(context.Request.InputStream))
                    {
                        string values = reader.ReadToEnd();

                        JsonDataAllBed jd = new JsonDataAllBed();
                        System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
                        jd = js.Deserialize<JsonDataAllBed>(values);
                        if (jd != null)
                        {
                            int Result = 0;
                            Result = SaveLiveBirthWeightHandler(jd.RecId, jd.ServiceId, jd.CompanyId, jd.StateId, jd.CMonth, jd.CYear, jd.CDay, jd.CVal, jd.CreatedBy,jd.HType);
                            if (Result > 0)
                            {
                                context.Response.Write("db save success");
                            }
                            else
                            {
                                context.Response.Write("db save error");
                            }
                        }
                        else
                        {
                            context.Response.Write("json not found");
                        }
                    }
                    break;
                default:
                    throw new ArgumentException("unknown method");
            }
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Handler.ashx", "ProcessRequest", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

    public int SaveCaseDetailHandler(Int64 RecId, Int64 ServiceId, int HType, int CaseType, int Gender, int CMonth, int CYear, string CDay, int CVal, Int64 CreatedBy, Int64 StateId)
    {
        int Result = 0;
        try
        {
            Result = Obj.SaveCaseDetail(RecId, ServiceId, HType, CaseType, Gender, CMonth, CYear, "Date" + CDay, CVal, CreatedBy, StateId);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Handler.ashx", "SaveCaseDetailHandler", Ex.Message.ToString(), System.DateTime.Now.ToString());
            Result = 0;
        }
        return Result;
    }

    public int SaveHospitalBedsDetailsHandler(Int64 RecId, Int64 ServiceId, Int64 CompanyId, Int64 StateId, int CMonth, int CYear, string CDay, int CVal, Int64 CreatedBy, int Htype)
    {
        int Result = 0;
        try
        {
            Result = Obj.SaveHospitalBedsDetails(RecId, ServiceId, CompanyId, StateId, CMonth, CYear, CDay, CVal, CreatedBy, Htype);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Handler.ashx", "SaveHospitalBedsDetails", Ex.Message.ToString(), System.DateTime.Now.ToString());
            Result = 0;
        }
        return Result;
    }
    public int SavePatientAdmitOutcomesHandler(Int64 RecId, Int64 ServiceId, Int64 CompanyId, Int64 StateId, int CMonth, int CYear, string CDay, int CVal, Int64 CreatedBy, int HType)
    {
        int Result = 0;
        try
        {
            Result = Obj.SavePatientAdmitOutcomes(RecId, ServiceId, CompanyId, StateId, CMonth, CYear, CDay, CVal, CreatedBy, HType);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Handler.ashx", "SavePatientAdmitOutcomesHandler", Ex.Message.ToString(), System.DateTime.Now.ToString());
            Result = 0;
        }
        return Result;
    }
    public int SaveBlindnessPrevProgHandler(Int64 RecId, Int64 ServiceId, Int64 CompanyId, Int64 StateId, int CMonth, int CYear, string CDay, int CVal, Int64 CreatedBy, int Htype)
    {
        int Result = 0;
        try
        {
            Result = Obj.SaveBlindnessPrevProg(RecId, ServiceId, CompanyId, StateId, CMonth, CYear, CDay, CVal, CreatedBy, Htype);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Handler.ashx", "SaveBlindnessPrevProgHandler", Ex.Message.ToString(), System.DateTime.Now.ToString());
            Result = 0;
        }
        return Result;
    }

    public int SaveDentalProcedureHandler(Int64 RecId, Int64 ServiceId, Int64 CompanyId, Int64 StateId, int CMonth, int CYear, string CDay, int CVal, Int64 CreatedBy, int Htype)
    {
        int Result = 0;
        try
        {
            Result = Obj.SaveDentalProcedure(RecId, ServiceId, CompanyId, StateId, CMonth, CYear, CDay, CVal, CreatedBy, Htype);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Handler.ashx", "SaveDentalProcedureHandler", Ex.Message.ToString(), System.DateTime.Now.ToString());
            Result = 0;
        }
        return Result;
    }


    public int SaveMaternalHealthHandler(Int64 RecId, Int64 ServiceId, Int64 CompanyId, Int64 StateId, int CMonth, int CYear, string CDay, int CVal, Int64 CreatedBy, int Htype)
    {
        int Result = 0;
        try
        {
            Result = Obj.SaveMaternalHealth(RecId, ServiceId, CompanyId, StateId, CMonth, CYear, CDay, CVal, CreatedBy,Htype);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Handler.ashx", "SavePatientAdmitOutcomesHandler", Ex.Message.ToString(), System.DateTime.Now.ToString());
            Result = 0;
        }
        return Result;
    }
    public int SaveLiveBirthWeightHandler(Int64 RecId, Int64 ServiceId, Int64 CompanyId, Int64 StateId, int CMonth, int CYear, string CDay, int CVal, Int64 CreatedBy, int Htype)
    {
        int Result = 0;
        try
        {
            Result = Obj.SaveLiveBirthWeight(RecId, ServiceId, CompanyId, StateId, CMonth, CYear, CDay, CVal, CreatedBy,Htype);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Handler.ashx", "SaveLiveBirthWeightHandler", Ex.Message.ToString(), System.DateTime.Now.ToString());
            Result = 0;
        }
        return Result;
    }

}


public class JsonData
{
    public Int64 RecId;
    public Int64 ServiceId;
    public int HType;
    public int CaseType;
    public int Gender;
    public int CMonth;
    public int CYear;
    public string CDay;
    public int CVal;
    public Int64 CreatedBy;
    public Int64 StateId;
}
public class JsonDataAllBed
{
    public Int64 RecId;
    public Int64 ServiceId;
    public Int64 CompanyId;
    public Int64 StateId;
    public int CMonth;
    public int CYear;
    public string CDay;
    public int CVal;
    public Int64 CreatedBy;
    public int HType;

}