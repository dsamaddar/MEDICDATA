using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Configuration;

public class ClsDataset : BusinessBase
{
    /*Conversation Function*/
    public int strtoint(String Val)
    {
        int Result = 0;
        try
        {
            if (Val != "")
            {
                Result = Convert.ToInt16(Val);
            }
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "strtoint", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Result;
    }
    public Int32 strtoint32(String Val)
    {
        Int32 Result = 0;
        try
        {
            if (Val != "")
            {
                Result = Convert.ToInt32(Val);
            }
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "strtoint32", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Result;
    }
    public Int64 strtoint64(String Val)
    {
        Int64 Result = 0;
        try
        {
            if (Val != "")
            {
                Result = Convert.ToInt64(Val);
            }
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "strtoint64", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Result;
    }
    public DateTime strtodate(String Val)
    {
        DateTime Result = new DateTime(1900, 01, 01);
        try
        {
            if (Val != "")
            {
                Result = Convert.ToDateTime(Val);
            }
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "strtodate", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Result;
    }
    public Double strtodouble(String Val)
    {
        Double Result = 0;
        try
        {
            if (Val != "")
            {
                Result = Convert.ToDouble(Val);
            }
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "strtodouble", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Result;
    }
    public Boolean IsNumber(String str)
    {
        try
        {
            Double.Parse(str);
            return true;
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "IsNumber", Ex.Message.ToString(), System.DateTime.Now.ToString());
            return false;
        }
    }
    public Boolean chkdataset(DataSet Ds)
    {
        Boolean Result = false;
        try
        {
            if (Ds.Tables != null)
            {
                if (Ds.Tables.Count > 0)
                {
                    if (Ds.Tables[0].Rows.Count > 0)
                    {
                        Result = true;
                    }
                }
            }
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "chkdataset", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Result;
    }
    public Boolean chkdatatable(DataTable Dt)
    {
        Boolean Result = false;
        try
        {
            if (Dt != null)
            {
                if (Dt.Rows.Count > 0)
                {
                    Result = true;
                }
            }
        }
        catch (Exception Ex)
        {
            ErrorLog("PaperTemplet", "chkdatatable", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Result;
    }

    /*Error Log Display*/
    public void ErrorLog(string Filename, string Functionname, string ErrMsg, string DtTm)
    {
        string ErrFilePath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "ErrorLog.txt";
        if (Directory.Exists(ErrFilePath))
        {
            Directory.CreateDirectory(ErrFilePath);
        }
        StreamWriter file = File.AppendText(ErrFilePath);
        file.WriteLine("###Date : " + DtTm + Environment.NewLine + "###Filename : " + Filename + "###FunctionaName : " + Functionname + Environment.NewLine + "###ErrMsg : " + ErrMsg);
        file.Close();
    }

    public DataSet SignInUserMaster(string UserId, string Pass)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[2];
            Param[0] = new SqlParameter("@UserId", SqlDbType.NVarChar, 50);
            Param[0].Value = UserId;
            Param[1] = new SqlParameter("@PWD", SqlDbType.NVarChar, 50);
            Param[1].Value = Pass;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "Web_GetLogin", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "SignInUserMaster", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }

    public DataSet ForgotPassword(string UserId)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[1];
            Param[0] = new SqlParameter("@UserId", SqlDbType.NVarChar, 50);
            Param[0].Value = UserId;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "Web_ForgotPassword", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "ForgotPassword", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }

    public DataSet GetForgotTrans(string Key)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[1];
            Param[0] = new SqlParameter("@Key", SqlDbType.NVarChar, 100);
            Param[0].Value = Key;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "Web_GetForgotTrans", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "ForgotPassword", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }

    public string SaveOTPMaster(string USERID, string USERNAME, string OTP, string MACHINENAME, int ISSUCCESS, string EMAILID)
    {
        string Result = "";
        try
        {
            SqlParameter[] Param = new SqlParameter[6];
            Param[0] = new SqlParameter("@USERID", SqlDbType.NVarChar, 20);
            Param[0].Value = USERID;
            Param[1] = new SqlParameter("@USERNAME", SqlDbType.NVarChar, 50);
            Param[1].Value = USERNAME;
            Param[2] = new SqlParameter("@OTP", SqlDbType.NVarChar, 100);
            Param[2].Value = OTP;
            Param[2].Direction = ParameterDirection.InputOutput;
            Param[3] = new SqlParameter("@MACHINENAME", SqlDbType.NVarChar, 50);
            Param[3].Value = MACHINENAME;
            Param[4] = new SqlParameter("@ISSUCCESS", SqlDbType.Int);
            Param[4].Value = ISSUCCESS;
            Param[5] = new SqlParameter("@EMAILID", SqlDbType.NVarChar, 70);
            Param[5].Value = EMAILID;
            int R = 0;
            R = SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "Web_SaveOTPMaster", Param);
            if (R > 0)
            {
                Result = Param[2].Value.ToString();
            }
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "SaveOTPMaster", Ex.Message.ToString(), System.DateTime.Now.ToString());
            Result = "";
        }
        return Result;
    }

    public int SavePassword(string UserId, string Password, string Key)
    {
        int Result = 0;
        try
        {
            SqlParameter[] Param = new SqlParameter[3];
            Param[0] = new SqlParameter("@UserId", SqlDbType.NVarChar, 50);
            Param[0].Value = UserId;
            Param[1] = new SqlParameter("@Password", SqlDbType.NVarChar, 50);
            Param[1].Value = Password;
            Param[2] = new SqlParameter("@Key", SqlDbType.NVarChar, 100);
            Param[2].Value = Key;
            Result = SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "Web_SavePassword", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "SaveOTPMaster", Ex.Message.ToString(), System.DateTime.Now.ToString());
            Result = 0;
        }
        return Result;
    }



    public DataSet GetStateDrp()
    {
        DataSet Ds = new DataSet();
        try
        {
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "Web_GetStateDrp");
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "GetStateDrp", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }
    public DataSet GetCompanyMaster(Int64 RecId)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[1];
            Param[0] = new SqlParameter("@RecId", SqlDbType.BigInt);
            Param[0].Value = RecId;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "Web_GetCompanyMaster", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "GetCompanyMaster", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }
    public int SaveCompanyMaster(Int64 RecId, string CName, string City, Int64 State, string Contact, string Email, string LogoString, int IsActive, Int64 CreatedBy, string ReportTitle1, string ReportTitle2, string ReportTitle3)
    {
        int Result = 0;
        try
        {
            SqlParameter[] Param = new SqlParameter[12];
            Param[0] = new SqlParameter("@RecId", SqlDbType.BigInt);
            Param[0].Value = RecId;
            Param[1] = new SqlParameter("@CName", SqlDbType.NVarChar, 100);
            Param[1].Value = CName;
            Param[2] = new SqlParameter("@City", SqlDbType.NVarChar, 100);
            Param[2].Value = City;
            Param[3] = new SqlParameter("@State", SqlDbType.BigInt);
            Param[3].Value = State;
            Param[4] = new SqlParameter("@Contact", SqlDbType.NVarChar, 50);
            Param[4].Value = Contact;
            Param[5] = new SqlParameter("@Email", SqlDbType.NVarChar, 50);
            Param[5].Value = Email;
            Param[6] = new SqlParameter("@LogoString", SqlDbType.NText);
            Param[6].Value = LogoString;
            Param[7] = new SqlParameter("@IsActive", SqlDbType.Int);
            Param[7].Value = IsActive;
            Param[8] = new SqlParameter("@CreatedBy", SqlDbType.BigInt);
            Param[8].Value = CreatedBy;
            Param[9] = new SqlParameter("@ReportTitle1", SqlDbType.NVarChar, 500);
            Param[9].Value = ReportTitle1;
            Param[10] = new SqlParameter("@ReportTitle2", SqlDbType.NVarChar, 500);
            Param[10].Value = ReportTitle2;
            Param[11] = new SqlParameter("@ReportTitle3", SqlDbType.NVarChar, 500);
            Param[11].Value = ReportTitle3;

            Result = SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "Web_SaveCompanyMaster", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "SaveCompanyMaster", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Result;
    }

    public DataSet GetUserList(string SearchText, Int64 UID)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[2];
            Param[0] = new SqlParameter("@SearchText", SqlDbType.NVarChar, 200);
            Param[0].Value = SearchText;
            Param[1] = new SqlParameter("@UserId", SqlDbType.BigInt);
            Param[1].Value = UID;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "Web_GetUserList", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "GetUserList", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }

    public DataSet GetHospitalList(string SearchText)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[1];
            Param[0] = new SqlParameter("@SearchText", SqlDbType.NVarChar, 200);
            Param[0].Value = SearchText;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "Web_GetHospitalList", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "GetUserList", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }

    public DataSet GetHospitalDrp(Int64 UserId)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[1];
            Param[0] = new SqlParameter("@UserId", SqlDbType.BigInt);
            Param[0].Value = UserId;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "Web_GetHospitalDrp", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "GetHospitalDrp", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }

    public int DeleteUser(Int64 RecId)
    {
        int Result = 0;
        try
        {
            SqlParameter[] Param = new SqlParameter[1];
            Param[0] = new SqlParameter("@RecId", SqlDbType.BigInt);
            Param[0].Value = RecId;

            Result = SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "Web_DeleteUser", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "DeleteUser", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Result;
    }

    public int SaveUser(Int64 RecId, string UserId, string PWD, string UserName, DateTime DOB, int Gender, string EmailId,
                            string Contact, string Address, string City, string State, string ZipCode, string ProfilePic,
                            int UserType, int IsActive, Int64 CreatedBy, int CompanyId)
    {
        int Result = 0;
        try
        {
            SqlParameter[] Param = new SqlParameter[17];
            Param[0] = new SqlParameter("@RecId", SqlDbType.BigInt);
            Param[0].Value = RecId;
            Param[0].Direction = ParameterDirection.InputOutput;
            Param[1] = new SqlParameter("@UserId", SqlDbType.NVarChar, 50);
            Param[1].Value = UserId;
            Param[2] = new SqlParameter("@PWD", SqlDbType.NVarChar, 50);
            Param[2].Value = PWD;
            Param[3] = new SqlParameter("@UserName", SqlDbType.NVarChar, 100);
            Param[3].Value = UserName;
            Param[4] = new SqlParameter("@DOB", SqlDbType.DateTime);
            Param[4].Value = DOB;
            Param[5] = new SqlParameter("@Gender", SqlDbType.Int);
            Param[5].Value = Gender;
            Param[6] = new SqlParameter("@EmailId", SqlDbType.NVarChar, 50);
            Param[6].Value = EmailId;
            Param[7] = new SqlParameter("@Contact", SqlDbType.NVarChar, 50);
            Param[7].Value = Contact;
            Param[8] = new SqlParameter("@Address", SqlDbType.NVarChar, 500);
            Param[8].Value = Address;
            Param[9] = new SqlParameter("@City", SqlDbType.NVarChar, 50);
            Param[9].Value = City;
            Param[10] = new SqlParameter("@State", SqlDbType.NVarChar, 50);
            Param[10].Value = State;
            Param[11] = new SqlParameter("@ZipCode", SqlDbType.NVarChar, 10);
            Param[11].Value = ZipCode;
            Param[12] = new SqlParameter("@ProfilePic", SqlDbType.NVarChar, 100);
            Param[12].Value = ProfilePic;
            Param[13] = new SqlParameter("@UserType", SqlDbType.Int);
            Param[13].Value = UserType;
            Param[14] = new SqlParameter("@IsActive", SqlDbType.Int);
            Param[14].Value = IsActive;
            Param[15] = new SqlParameter("@CreatedBy", SqlDbType.BigInt);
            Param[15].Value = CreatedBy;
            Param[16] = new SqlParameter("@CompanyId", SqlDbType.Int);
            Param[16].Value = CompanyId;
            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "Web_SaveUser", Param);
            Result = strtoint(Param[0].Value.ToString());
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "SaveUser", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Result;
    }

    public DataSet GetUserMaster(Int64 RecId)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[1];
            Param[0] = new SqlParameter("@RecId", SqlDbType.BigInt);
            Param[0].Value = RecId;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "Web_GetUserMaster", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "GetUserMaster", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }

    public DataSet GetServicesList(string SearchText)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[1];
            Param[0] = new SqlParameter("@SearchText", SqlDbType.NVarChar, 200);
            Param[0].Value = SearchText;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "Web_GetServicesList", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "GetServicesList", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }

    public DataSet GetServicesMaster(Int64 RecId)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[1];
            Param[0] = new SqlParameter("@RecId", SqlDbType.BigInt);
            Param[0].Value = RecId;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "Web_GetServicesMaster", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "GetServicesMaster", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }

    public int UpdateServicesIsActive(Int64 RecId)
    {
        int Result = 0;
        try
        {
            SqlParameter[] Param = new SqlParameter[1];
            Param[0] = new SqlParameter("@RecId", SqlDbType.BigInt);
            Param[0].Value = RecId;
            Result = SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "Web_UpdateServicesIsActive", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "UpdateServicesIsActive", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Result;
    }

    public int UpdateHospitalIsActive(Int64 RecId)
    {
        int Result = 0;
        try
        {
            SqlParameter[] Param = new SqlParameter[1];
            Param[0] = new SqlParameter("@RecId", SqlDbType.BigInt);
            Param[0].Value = RecId;
            Result = SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "Web_UpdateHospitalIsActive", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "UpdateServicesIsActive", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Result;
    }

    public DataSet GetServicesDrp()
    {
        DataSet Ds = new DataSet();
        try
        {
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "Web_GetServicesDrp");
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "GetServicesDrp", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }

    public int SaveServicesMaster(Int64 RecId, Int64 ParentId, string ServiceName, string Description, int IsActive, Int64 CreatedBy)
    {
        int Result = 0;
        try
        {
            SqlParameter[] Param = new SqlParameter[6];
            Param[0] = new SqlParameter("@RecId", SqlDbType.BigInt);
            Param[0].Value = RecId;
            Param[0].Direction = ParameterDirection.InputOutput;
            Param[1] = new SqlParameter("@ParentId", SqlDbType.BigInt);
            Param[1].Value = ParentId;
            Param[2] = new SqlParameter("@ServiceName", SqlDbType.NVarChar, 100);
            Param[2].Value = ServiceName;
            Param[3] = new SqlParameter("@Description", SqlDbType.NVarChar, 500);
            Param[3].Value = Description;
            Param[4] = new SqlParameter("@IsActive", SqlDbType.Int);
            Param[4].Value = IsActive;
            Param[5] = new SqlParameter("@CreatedBy", SqlDbType.BigInt);
            Param[5].Value = CreatedBy;
            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "Web_SaveServicesMaster", Param);
            Result = strtoint(Param[0].Value.ToString());
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "SaveServicesMaster", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Result;
    }

    public DataSet GetStateList(string SearchText)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[1];
            Param[0] = new SqlParameter("@SearchText", SqlDbType.NVarChar, 200);
            Param[0].Value = SearchText;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "Web_GetStateList", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "GetStateList", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }

    public DataSet GetStateMaster(Int64 RecId)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[1];
            Param[0] = new SqlParameter("@RecId", SqlDbType.BigInt);
            Param[0].Value = RecId;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "Web_GetStateMaster", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "GetStateMaster", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }

    public int UpdateStateIsActive(Int64 RecId)
    {
        int Result = 0;
        try
        {
            SqlParameter[] Param = new SqlParameter[1];
            Param[0] = new SqlParameter("@RecId", SqlDbType.BigInt);
            Param[0].Value = RecId;
            Result = SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "Web_UpdateStateIsActive", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "UpdateStateIsActive", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Result;
    }

    public int UpdateUserIsActive(Int64 RecId)
    {
        int Result = 0;
        try
        {
            SqlParameter[] Param = new SqlParameter[1];
            Param[0] = new SqlParameter("@RecId", SqlDbType.BigInt);
            Param[0].Value = RecId;
            Result = SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "Web_UpdateUserIsActive", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "UpdateStateIsActive", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Result;
    }

    public int SaveStateMaster(Int64 RecId, string StateName, string Description, int IsActive, Int64 CreatedBy)
    {
        int Result = 0;
        try
        {
            SqlParameter[] Param = new SqlParameter[5];
            Param[0] = new SqlParameter("@RecId", SqlDbType.BigInt);
            Param[0].Value = RecId;
            Param[0].Direction = ParameterDirection.InputOutput;
            Param[1] = new SqlParameter("@StateName", SqlDbType.NVarChar, 200);
            Param[1].Value = StateName;
            Param[2] = new SqlParameter("@Description", SqlDbType.NVarChar, 500);
            Param[2].Value = Description;
            Param[3] = new SqlParameter("@IsActive", SqlDbType.Int);
            Param[3].Value = IsActive;
            Param[4] = new SqlParameter("@CreatedBy", SqlDbType.BigInt);
            Param[4].Value = CreatedBy;
            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "Web_SaveStateMaster", Param);
            Result = strtoint(Param[0].Value.ToString());
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "SaveStateMaster", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Result;
    }

    public DataSet GetCaseDetail(int GroupId, int CMonth, int CYear, int HType, int CaseType, int Gender, Int64 StateId, Int64 CompanyId, string SearchVal)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[9];
            Param[0] = new SqlParameter("@GroupId", SqlDbType.Int);
            Param[0].Value = GroupId;
            Param[1] = new SqlParameter("@CMonth", SqlDbType.Int);
            Param[1].Value = CMonth;
            Param[2] = new SqlParameter("@CYear", SqlDbType.Int);
            Param[2].Value = CYear;
            Param[3] = new SqlParameter("@CaseType", SqlDbType.Int);
            Param[3].Value = CaseType;
            Param[4] = new SqlParameter("@HType", SqlDbType.Int);
            Param[4].Value = HType;
            Param[5] = new SqlParameter("@Gender", SqlDbType.Int);
            Param[5].Value = Gender;
            Param[6] = new SqlParameter("@StateId", SqlDbType.BigInt);
            Param[6].Value = StateId;
            Param[7] = new SqlParameter("@CompanyId", SqlDbType.BigInt);
            Param[7].Value = CompanyId;
            Param[8] = new SqlParameter("@SearchVal", SqlDbType.NVarChar, 5);
            Param[8].Value = SearchVal;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "Web_GetCaseDetail", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "GetCaseDetail", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }

    /*23 Sept 2019 : By - Jaydip*/
    public DataSet GetAllHosptBEDS(Int64 CompanyId, Int64 StateId, string Machine, int CMonth, int CYear, int Htype)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[6];
            Param[0] = new SqlParameter("@CompanyId", SqlDbType.BigInt);
            Param[0].Value = CompanyId;
            Param[1] = new SqlParameter("@StateId", SqlDbType.BigInt);
            Param[1].Value = StateId;
            Param[2] = new SqlParameter("@Machine", SqlDbType.NVarChar, 120);
            Param[2].Value = Machine;
            Param[3] = new SqlParameter("@CMonth", SqlDbType.Int);
            Param[3].Value = CMonth;
            Param[4] = new SqlParameter("@CYear", SqlDbType.Int);
            Param[4].Value = CYear;
            Param[5] = new SqlParameter("@Htype", SqlDbType.Int);
            Param[5].Value = Htype;

            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "Web_GetAllHosptBEDS", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "GetAllHosptBEDS", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }
    public DataSet GetPatientAdmitOutcomes(Int64 CompanyId, Int64 StateId, string Machine, int CMonth, int CYear, int Htype)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[6];
            Param[0] = new SqlParameter("@CompanyId", SqlDbType.BigInt);
            Param[0].Value = CompanyId;
            Param[1] = new SqlParameter("@StateId", SqlDbType.BigInt);
            Param[1].Value = StateId;
            Param[2] = new SqlParameter("@Machine", SqlDbType.NVarChar, 120);
            Param[2].Value = Machine;
            Param[3] = new SqlParameter("@CMonth", SqlDbType.Int);
            Param[3].Value = CMonth;
            Param[4] = new SqlParameter("@CYear", SqlDbType.Int);
            Param[4].Value = CYear;
            Param[5] = new SqlParameter("@Htype", SqlDbType.Int);
            Param[5].Value = Htype;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "Web_GetPatientAdmitOutcomes", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "GetPatientAdmitOutcomes", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }
    public DataSet GetBlindnessPreProg(Int64 CompanyId, Int64 StateId, string Machine, int CMonth, int CYear, int Htype)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[6];
            Param[0] = new SqlParameter("@CompanyId", SqlDbType.BigInt);
            Param[0].Value = CompanyId;
            Param[1] = new SqlParameter("@StateId", SqlDbType.BigInt);
            Param[1].Value = StateId;
            Param[2] = new SqlParameter("@Machine", SqlDbType.NVarChar, 120);
            Param[2].Value = Machine;
            Param[3] = new SqlParameter("@CMonth", SqlDbType.Int);
            Param[3].Value = CMonth;
            Param[4] = new SqlParameter("@CYear", SqlDbType.Int);
            Param[4].Value = CYear;
            Param[5] = new SqlParameter("@Htype", SqlDbType.Int);
            Param[5].Value = Htype;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "web_GetBlindnessPrevProg", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "GetBlindnessPreProg", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }
    public DataSet GetDentalProcedure(Int64 CompanyId, Int64 StateId, string Machine, int CMonth, int CYear, int Htype)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[6];
            Param[0] = new SqlParameter("@CompanyId", SqlDbType.BigInt);
            Param[0].Value = CompanyId;
            Param[1] = new SqlParameter("@StateId", SqlDbType.BigInt);
            Param[1].Value = StateId;
            Param[2] = new SqlParameter("@Machine", SqlDbType.NVarChar, 120);
            Param[2].Value = Machine;
            Param[3] = new SqlParameter("@CMonth", SqlDbType.Int);
            Param[3].Value = CMonth;
            Param[4] = new SqlParameter("@CYear", SqlDbType.Int);
            Param[4].Value = CYear;
            Param[5] = new SqlParameter("@Htype", SqlDbType.Int);
            Param[5].Value = Htype;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "web_GetDentalProcedure", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "GetDentalProcedure", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }
    public DataSet GetMaternalHealth(Int64 CompanyId, Int64 StateId, string Machine, int CMonth, int CYear, int Htype)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[6];
            Param[0] = new SqlParameter("@CompanyId", SqlDbType.BigInt);
            Param[0].Value = CompanyId;
            Param[1] = new SqlParameter("@StateId", SqlDbType.BigInt);
            Param[1].Value = StateId;
            Param[2] = new SqlParameter("@Machine", SqlDbType.NVarChar, 120);
            Param[2].Value = Machine;
            Param[3] = new SqlParameter("@CMonth", SqlDbType.Int);
            Param[3].Value = CMonth;
            Param[4] = new SqlParameter("@CYear", SqlDbType.Int);
            Param[4].Value = CYear;
            Param[5] = new SqlParameter("@Htype", SqlDbType.Int);
            Param[5].Value = Htype;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "Web_GetMaternalHealth", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "GetMaternalHealth", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }
    public DataSet GetLiveBirthWeight(Int64 CompanyId, Int64 StateId, string Machine, int CMonth, int CYear, int Htype)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[6];
            Param[0] = new SqlParameter("@CompanyId", SqlDbType.BigInt);
            Param[0].Value = CompanyId;
            Param[1] = new SqlParameter("@StateId", SqlDbType.BigInt);
            Param[1].Value = StateId;
            Param[2] = new SqlParameter("@Machine", SqlDbType.NVarChar, 120);
            Param[2].Value = Machine;
            Param[3] = new SqlParameter("@CMonth", SqlDbType.Int);
            Param[3].Value = CMonth;
            Param[4] = new SqlParameter("@CYear", SqlDbType.Int);
            Param[4].Value = CYear;
            Param[5] = new SqlParameter("@Htype", SqlDbType.Int);
            Param[5].Value = Htype;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "web_GetLiveBirthWeight", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "GetLiveBirthWeight", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }

    /*23 Sept 2019 : By - Jaydip*/
    public int SaveCaseDetail(Int64 RecId, Int64 ServiceId, int HType, int CaseType, int Gender, int CMonth, int CYear, string CDay, int CVal, Int64 CreatedBy, Int64 StateId)
    {
        int Result = 0;
        try
        {
            SqlParameter[] Param = new SqlParameter[11];
            Param[0] = new SqlParameter("@RecId", SqlDbType.BigInt);
            Param[0].Value = RecId;
            Param[1] = new SqlParameter("@ServiceId", SqlDbType.BigInt);
            Param[1].Value = ServiceId;
            Param[2] = new SqlParameter("@HType", SqlDbType.Int);
            Param[2].Value = HType;
            Param[3] = new SqlParameter("@CaseType", SqlDbType.Int);
            Param[3].Value = CaseType;
            Param[4] = new SqlParameter("@Gender", SqlDbType.Int);
            Param[4].Value = Gender;
            Param[5] = new SqlParameter("@CMonth", SqlDbType.Int);
            Param[5].Value = CMonth;
            Param[6] = new SqlParameter("@CYear", SqlDbType.Int);
            Param[6].Value = CYear;
            Param[7] = new SqlParameter("@CDay", SqlDbType.NVarChar, 100);
            Param[7].Value = CDay;
            Param[8] = new SqlParameter("@CVal", SqlDbType.Int);
            Param[8].Value = CVal;
            Param[9] = new SqlParameter("@CreatedBy", SqlDbType.BigInt);
            Param[9].Value = CreatedBy;
            Param[10] = new SqlParameter("@StateId", SqlDbType.BigInt);
            Param[10].Value = StateId;
            Result = SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "Web_SaveCaseDetail", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "SaveCaseDetail", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Result;
    }
    public int SaveHospitalBedsDetails(Int64 RecId, Int64 ServiceId, Int64 CompanyId, Int64 StateId, int CMonth, int CYear, string CDay, int CVal, Int64 CreatedBy, int Htype)
    {
        int Result = 0;
        try
        {
            SqlParameter[] Param = new SqlParameter[10];
            Param[0] = new SqlParameter("@RecId", SqlDbType.BigInt);
            Param[0].Value = RecId;
            Param[1] = new SqlParameter("@ServiceId", SqlDbType.BigInt);
            Param[1].Value = ServiceId;
            Param[2] = new SqlParameter("@CompanyId", SqlDbType.BigInt);
            Param[2].Value = CompanyId;
            Param[3] = new SqlParameter("@StateId", SqlDbType.BigInt);
            Param[3].Value = StateId;
            Param[4] = new SqlParameter("@CMonth", SqlDbType.Int);
            Param[4].Value = CMonth;
            Param[5] = new SqlParameter("@CYear", SqlDbType.Int);
            Param[5].Value = CYear;
            Param[6] = new SqlParameter("@CDay", SqlDbType.NVarChar, 100);
            Param[6].Value = CDay;
            Param[7] = new SqlParameter("@CVal", SqlDbType.Int);
            Param[7].Value = CVal;
            Param[8] = new SqlParameter("@CreatedBy", SqlDbType.BigInt);
            Param[8].Value = CreatedBy;
            Param[9] = new SqlParameter("@Htype", SqlDbType.Int);
            Param[9].Value = Htype;
            Result = SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "Web_SaveHospitalBedsDetails", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "SaveHospitalBedsDetails", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Result;
    }
    public int SavePatientAdmitOutcomes(Int64 RecId, Int64 ServiceId, Int64 CompanyId, Int64 StateId, int CMonth, int CYear, string CDay, int CVal, Int64 CreatedBy, int Htype)
    {
        int Result = 0;
        try
        {
            SqlParameter[] Param = new SqlParameter[10];
            Param[0] = new SqlParameter("@RecId", SqlDbType.BigInt);
            Param[0].Value = RecId;
            Param[1] = new SqlParameter("@ServiceId", SqlDbType.BigInt);
            Param[1].Value = ServiceId;
            Param[2] = new SqlParameter("@CompanyId", SqlDbType.BigInt);
            Param[2].Value = CompanyId;
            Param[3] = new SqlParameter("@StateId", SqlDbType.BigInt);
            Param[3].Value = StateId;
            Param[4] = new SqlParameter("@CMonth", SqlDbType.Int);
            Param[4].Value = CMonth;
            Param[5] = new SqlParameter("@CYear", SqlDbType.Int);
            Param[5].Value = CYear;
            Param[6] = new SqlParameter("@CDay", SqlDbType.NVarChar, 100);
            Param[6].Value = CDay;
            Param[7] = new SqlParameter("@CVal", SqlDbType.Int);
            Param[7].Value = CVal;
            Param[8] = new SqlParameter("@CreatedBy", SqlDbType.BigInt);
            Param[8].Value = CreatedBy;
            Param[9] = new SqlParameter("@Htype", SqlDbType.Int);
            Param[9].Value = Htype;
            Result = SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "Web_SavePatientAdmitOutcomes", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "SavePatientAdmitOutcomes", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Result;
    }
    public int SaveBlindnessPrevProg(Int64 RecId, Int64 ServiceId, Int64 CompanyId, Int64 StateId, int CMonth, int CYear, string CDay, int CVal, Int64 CreatedBy, int Htype)
    {
        int Result = 0;
        try
        {
            SqlParameter[] Param = new SqlParameter[10];
            Param[0] = new SqlParameter("@RecId", SqlDbType.BigInt);
            Param[0].Value = RecId;
            Param[1] = new SqlParameter("@ServiceId", SqlDbType.BigInt);
            Param[1].Value = ServiceId;
            Param[2] = new SqlParameter("@CompanyId", SqlDbType.BigInt);
            Param[2].Value = CompanyId;
            Param[3] = new SqlParameter("@StateId", SqlDbType.BigInt);
            Param[3].Value = StateId;
            Param[4] = new SqlParameter("@CMonth", SqlDbType.Int);
            Param[4].Value = CMonth;
            Param[5] = new SqlParameter("@CYear", SqlDbType.Int);
            Param[5].Value = CYear;
            Param[6] = new SqlParameter("@CDay", SqlDbType.NVarChar, 100);
            Param[6].Value = CDay;
            Param[7] = new SqlParameter("@CVal", SqlDbType.Int);
            Param[7].Value = CVal;
            Param[8] = new SqlParameter("@CreatedBy", SqlDbType.BigInt);
            Param[8].Value = CreatedBy;
            Param[9] = new SqlParameter("@Htype", SqlDbType.Int);
            Param[9].Value = Htype;
            Result = SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "Web_SaveBlindnessPrevProg", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "SaveBlindnessPrevProg", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Result;
    }
    public int SaveDentalProcedure(Int64 RecId, Int64 ServiceId, Int64 CompanyId, Int64 StateId, int CMonth, int CYear, string CDay, int CVal, Int64 CreatedBy, int Htype)
    {
        int Result = 0;
        try
        {
            SqlParameter[] Param = new SqlParameter[10];
            Param[0] = new SqlParameter("@RecId", SqlDbType.BigInt);
            Param[0].Value = RecId;
            Param[1] = new SqlParameter("@ServiceId", SqlDbType.BigInt);
            Param[1].Value = ServiceId;
            Param[2] = new SqlParameter("@CompanyId", SqlDbType.BigInt);
            Param[2].Value = CompanyId;
            Param[3] = new SqlParameter("@StateId", SqlDbType.BigInt);
            Param[3].Value = StateId;
            Param[4] = new SqlParameter("@CMonth", SqlDbType.Int);
            Param[4].Value = CMonth;
            Param[5] = new SqlParameter("@CYear", SqlDbType.Int);
            Param[5].Value = CYear;
            Param[6] = new SqlParameter("@CDay", SqlDbType.NVarChar, 100);
            Param[6].Value = CDay;
            Param[7] = new SqlParameter("@CVal", SqlDbType.Int);
            Param[7].Value = CVal;
            Param[8] = new SqlParameter("@CreatedBy", SqlDbType.BigInt);
            Param[8].Value = CreatedBy;
            Param[9] = new SqlParameter("@Htype", SqlDbType.Int);
            Param[9].Value = Htype;
            Result = SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "Web_SaveDentalProcedure", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "SaveDentalProcedure", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Result;
    }
    public int SaveMaternalHealth(Int64 RecId, Int64 ServiceId, Int64 CompanyId, Int64 StateId, int CMonth, int CYear, string CDay, int CVal, Int64 CreatedBy, int Htype)
    {
        int Result = 0;
        try
        {
            SqlParameter[] Param = new SqlParameter[10];
            Param[0] = new SqlParameter("@RecId", SqlDbType.BigInt);
            Param[0].Value = RecId;
            Param[1] = new SqlParameter("@ServiceId", SqlDbType.BigInt);
            Param[1].Value = ServiceId;
            Param[2] = new SqlParameter("@CompanyId", SqlDbType.BigInt);
            Param[2].Value = CompanyId;
            Param[3] = new SqlParameter("@StateId", SqlDbType.BigInt);
            Param[3].Value = StateId;
            Param[4] = new SqlParameter("@CMonth", SqlDbType.Int);
            Param[4].Value = CMonth;
            Param[5] = new SqlParameter("@CYear", SqlDbType.Int);
            Param[5].Value = CYear;
            Param[6] = new SqlParameter("@CDay", SqlDbType.NVarChar, 100);
            Param[6].Value = CDay;
            Param[7] = new SqlParameter("@CVal", SqlDbType.Int);
            Param[7].Value = CVal;
            Param[8] = new SqlParameter("@CreatedBy", SqlDbType.BigInt);
            Param[8].Value = CreatedBy;
            Param[9] = new SqlParameter("@Htype", SqlDbType.Int);
            Param[9].Value = Htype;
            Result = SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "Web_SaveMaternalHealth", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "SaveMaternalHealth", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Result;
    }
    public int SaveLiveBirthWeight(Int64 RecId, Int64 ServiceId, Int64 CompanyId, Int64 StateId, int CMonth, int CYear, string CDay, int CVal, Int64 CreatedBy, int Htype)
    {
        int Result = 0;
        try
        {
            SqlParameter[] Param = new SqlParameter[10];
            Param[0] = new SqlParameter("@RecId", SqlDbType.BigInt);
            Param[0].Value = RecId;
            Param[1] = new SqlParameter("@ServiceId", SqlDbType.BigInt);
            Param[1].Value = ServiceId;
            Param[2] = new SqlParameter("@CompanyId", SqlDbType.BigInt);
            Param[2].Value = CompanyId;
            Param[3] = new SqlParameter("@StateId", SqlDbType.BigInt);
            Param[3].Value = StateId;
            Param[4] = new SqlParameter("@CMonth", SqlDbType.Int);
            Param[4].Value = CMonth;
            Param[5] = new SqlParameter("@CYear", SqlDbType.Int);
            Param[5].Value = CYear;
            Param[6] = new SqlParameter("@CDay", SqlDbType.NVarChar, 100);
            Param[6].Value = CDay;
            Param[7] = new SqlParameter("@CVal", SqlDbType.Int);
            Param[7].Value = CVal;
            Param[8] = new SqlParameter("@CreatedBy", SqlDbType.BigInt);
            Param[8].Value = CreatedBy;
            Param[9] = new SqlParameter("@Htype", SqlDbType.Int);
            Param[9].Value = Htype;
            Result = SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "Web_SaveLiveBirthWeight", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "SaveLiveBirthWeight", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Result;
    }
    /* -: By - Jaydip*/

    public DataSet GetYearDrp()
    {
        DataSet Ds = new DataSet();
        try
        {
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "Web_GetYearDrp");
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "GetYearDrp", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }
    public DataSet GetMonthDrp(Boolean IsReport)
    {
        DataSet Ds = new DataSet();
        try
        {
            if (IsReport == true)
            {
                Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "RptGetMonthDrp");
            }
            else
            {
                Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "Win_GetMonthDrp");
            }
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "GetMonthDrp", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }
    public DataSet GetQuarterDrp()
    {
        DataSet Ds = new DataSet();
        try
        {
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "Web_GetQuarterlyDrp");
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "GetQuarterDrp", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }

    /*Get Report Data*/
    public DataSet GetHospitalDrpReport(Int64 CompanyId, Int64 UserType)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[2];
            Param[0] = new SqlParameter("@CompanyId", SqlDbType.BigInt);
            Param[0].Value = CompanyId;
            Param[1] = new SqlParameter("@UserType", SqlDbType.BigInt);
            Param[1].Value = UserType;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "Web_GetHospitalDrpReport", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "GetHospitalDrpReport", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }
    public DataSet GetHospitalDrpReportV1()
    {
        DataSet Ds = new DataSet();
        try
        {
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "Web_GetHospitalDrpReportV1");
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "GetHospitalDrpReportV1", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }
    public DataSet GetMonthly(int CMonth, int CYear, int HType, Int64 StateId, string ReffNo, Int64 CompanyId, int EMonth)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[7];
            Param[0] = new SqlParameter("@CMonth", SqlDbType.Int);
            Param[0].Value = CMonth;
            Param[1] = new SqlParameter("@CYear", SqlDbType.Int);
            Param[1].Value = CYear;
            Param[2] = new SqlParameter("@HType", SqlDbType.Int);
            Param[2].Value = HType;
            Param[3] = new SqlParameter("@StateId", SqlDbType.BigInt);
            Param[3].Value = StateId;
            Param[4] = new SqlParameter("@ReffNo", SqlDbType.NVarChar, 100);
            Param[4].Value = ReffNo;
            Param[5] = new SqlParameter("@CompanyId", SqlDbType.BigInt);
            Param[5].Value = CompanyId;
            Param[6] = new SqlParameter("@EMonth", SqlDbType.Int);
            Param[6].Value = EMonth;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "RptMonthlyData", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "GetMonthly", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }
    public DataSet GetMonthlySummary(int CMonth, int CYear, int HType, Int64 StateId, Int64 CompanyId, int EMonth)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[6];
            Param[0] = new SqlParameter("@CMonth", SqlDbType.Int);
            Param[0].Value = CMonth;
            Param[1] = new SqlParameter("@CYear", SqlDbType.Int);
            Param[1].Value = CYear;
            Param[2] = new SqlParameter("@HType", SqlDbType.Int);
            Param[2].Value = HType;
            Param[3] = new SqlParameter("@StateId", SqlDbType.BigInt);
            Param[3].Value = StateId;
            Param[4] = new SqlParameter("@CompanyId", SqlDbType.BigInt);
            Param[4].Value = CompanyId;
            Param[5] = new SqlParameter("@EMonth", SqlDbType.Int);
            Param[5].Value = EMonth;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "RptMonthlySummary", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "GetMonthlySummary", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }

    public DataSet GetQuarterly(int CQuarter, int CYear, int HType, Int64 StateId, string ReffNo, Int64 CompanyId)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[6];
            Param[0] = new SqlParameter("@Quarter", SqlDbType.Int);
            Param[0].Value = CQuarter;
            Param[1] = new SqlParameter("@CYear", SqlDbType.Int);
            Param[1].Value = CYear;
            Param[2] = new SqlParameter("@HType", SqlDbType.Int);
            Param[2].Value = HType;
            Param[3] = new SqlParameter("@StateId", SqlDbType.BigInt);
            Param[3].Value = StateId;
            Param[4] = new SqlParameter("@ReffNo", SqlDbType.NVarChar, 100);
            Param[4].Value = ReffNo;
            Param[5] = new SqlParameter("@CompanyId", SqlDbType.BigInt);
            Param[5].Value = CompanyId;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "RptQuarterlyData", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "GetQuarterly", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }
    public DataSet GetQuarterlySummary(int CQuarter, int CYear, int HType, Int64 StateId, Int64 CompanyId)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[5];
            Param[0] = new SqlParameter("@Quarter", SqlDbType.Int);
            Param[0].Value = CQuarter;
            Param[1] = new SqlParameter("@CYear", SqlDbType.Int);
            Param[1].Value = CYear;
            Param[2] = new SqlParameter("@HType", SqlDbType.Int);
            Param[2].Value = HType;
            Param[3] = new SqlParameter("@StateId", SqlDbType.BigInt);
            Param[3].Value = StateId;
            Param[4] = new SqlParameter("@CompanyId", SqlDbType.BigInt);
            Param[4].Value = CompanyId;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "RptQuarterlySummary", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "GetQuarterlySummary", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }

    public DataSet GetYearly(int CYear, int HType, Int64 StateId, string ReffNo, Int64 CompanyId)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[5];
            Param[0] = new SqlParameter("@CYear", SqlDbType.Int);
            Param[0].Value = CYear;
            Param[1] = new SqlParameter("@HType", SqlDbType.Int);
            Param[1].Value = HType;
            Param[2] = new SqlParameter("@StateId", SqlDbType.BigInt);
            Param[2].Value = StateId;
            Param[3] = new SqlParameter("@ReffNo", SqlDbType.NVarChar, 100);
            Param[3].Value = ReffNo;
            Param[4] = new SqlParameter("@CompanyId", SqlDbType.BigInt);
            Param[4].Value = CompanyId;

            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "RptYearlyData", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "GetYearly", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }
    public DataSet GetYearlySummary(int CYear, int HType, Int64 StateId, Int64 CompanyId)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[4];
            Param[0] = new SqlParameter("@CYear", SqlDbType.Int);
            Param[0].Value = CYear;
            Param[1] = new SqlParameter("@HType", SqlDbType.Int);
            Param[1].Value = HType;
            Param[2] = new SqlParameter("@StateId", SqlDbType.BigInt);
            Param[2].Value = StateId;
            Param[3] = new SqlParameter("@CompanyId", SqlDbType.BigInt);
            Param[3].Value = CompanyId;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "RptYearlySummary", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "GetYearlySummary", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }
    public DataSet GetCausesDrp()
    {
        DataSet Ds = new DataSet();
        try
        {
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "Web_GetCausesDrp");
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "GetCausesDrp", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }
    public DataSet GetDeathsMaster(Int64 RecId)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[1];
            Param[0] = new SqlParameter("@RecId", SqlDbType.BigInt);
            Param[0].Value = RecId;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "Web_GetDeathsMaster", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "GetDeathsMaster", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }

    public int SaveDeathsDetails(Int64 RecId, int Htype, Int64 StateId, Int64 CompanyId, string Decease, int Sex, int Age, string Address, DateTime DOA, DateTime DOD, string CausesDeath, Int64 CreatedBy, string RefNo, string Machine)
    {
        int Result = 0;
        try
        {
            SqlParameter[] Param = new SqlParameter[14];
            Param[0] = new SqlParameter("@RecId", SqlDbType.BigInt);
            Param[0].Value = RecId;
            //Param[0].Direction = ParameterDirection.InputOutput;
            Param[1] = new SqlParameter("@Htype", SqlDbType.Int);
            Param[1].Value = Htype;
            Param[2] = new SqlParameter("@StateId", SqlDbType.BigInt);
            Param[2].Value = StateId;
            Param[3] = new SqlParameter("@CompanyId", SqlDbType.BigInt);
            Param[3].Value = CompanyId;
            Param[4] = new SqlParameter("@Decease", SqlDbType.NVarChar, 200);
            Param[4].Value = Decease;
            Param[5] = new SqlParameter("@Sex", SqlDbType.Int);
            Param[5].Value = Sex;
            Param[6] = new SqlParameter("@Age", SqlDbType.Int);
            Param[6].Value = Age;
            Param[7] = new SqlParameter("@Address", SqlDbType.NVarChar, 250);
            Param[7].Value = Address;
            Param[8] = new SqlParameter("@DOA", SqlDbType.DateTime);
            Param[8].Value = DOA;
            Param[9] = new SqlParameter("@DOD", SqlDbType.DateTime);
            Param[9].Value = DOD;
            Param[10] = new SqlParameter("@CausesDeath", SqlDbType.NVarChar, 500);
            Param[10].Value = CausesDeath;
            Param[11] = new SqlParameter("@CreatedBy", SqlDbType.BigInt);
            Param[11].Value = CreatedBy;
            Param[12] = new SqlParameter("@RefNo", SqlDbType.NVarChar, 150);
            Param[12].Value = RefNo;
            Param[13] = new SqlParameter("@Machine", SqlDbType.NVarChar, 250);
            Param[13].Value = Machine;
            Result = SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "Web_SaveDeathsDetails", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "SaveUser", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Result;
    }

    public DataSet GetDeathsList(string SearchText, int Htype, Int64 StateId, Int64 CompanyId)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[4];
            Param[0] = new SqlParameter("@SearchText", SqlDbType.NVarChar, 200);
            Param[0].Value = SearchText;
            Param[1] = new SqlParameter("@Htype", SqlDbType.Int);
            Param[1].Value = Htype;
            Param[2] = new SqlParameter("@StateId", SqlDbType.BigInt);
            Param[2].Value = StateId;
            Param[3] = new SqlParameter("@CompanyId", SqlDbType.BigInt);
            Param[3].Value = CompanyId;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "Web_GetDeathsList", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "GetUserList", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }
    public int DeleteDeaths(Int64 RecId)
    {
        int Result = 0;
        try
        {
            SqlParameter[] Param = new SqlParameter[1];
            Param[0] = new SqlParameter("@RecId", SqlDbType.BigInt);
            Param[0].Value = RecId;

            Result = SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "Web_DeleteDeaths", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "DeleteUser", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Result;
    }
    public DataSet GetReportList(Int64 UID)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[1];
            Param[0] = new SqlParameter("@UserId", SqlDbType.BigInt);
            Param[0].Value = UID;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "Web_GetReportList", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "GetUserList", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }

    /*Report By Jaydip : Sp (START)*/
    public DataSet RptGetHeaderDetails(Int64 CompanyId, int HType, string RefNum, string Period)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[4];
            Param[0] = new SqlParameter("@CompanyId", SqlDbType.BigInt);
            Param[0].Value = CompanyId;
            Param[1] = new SqlParameter("@HType", SqlDbType.Int);
            Param[1].Value = HType;
            Param[2] = new SqlParameter("@RefNum", SqlDbType.NVarChar, 100);
            Param[2].Value = RefNum;
            Param[3] = new SqlParameter("@Period", SqlDbType.NVarChar, 100);
            Param[3].Value = Period;

            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "RptGetHeaderDetails", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "RptGetHeaderDetails", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }
    public DataSet RptGetHeaderDetailsV1(string ReportTitle, string RefNum, string Period)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[3];
            Param[0] = new SqlParameter("@ReportTitle", SqlDbType.NVarChar, 200);
            Param[0].Value = ReportTitle;
            Param[1] = new SqlParameter("@RefNum", SqlDbType.NVarChar, 100);
            Param[1].Value = RefNum;
            Param[2] = new SqlParameter("@Period", SqlDbType.NVarChar, 150);
            Param[2].Value = Period;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "RptGetHeaderDetailsV1", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "RptGetHeaderDetailsV1", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }

    public DataSet RptGetAandSGeneral(int CMonth, int CYear, Int64 StateId, string ReffNo, Int64 CompanyId, int HType, int HType1, int EMonth)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[8];
            Param[0] = new SqlParameter("@CMonth", SqlDbType.Int);
            Param[0].Value = CMonth;
            Param[1] = new SqlParameter("@CYear", SqlDbType.Int);
            Param[1].Value = CYear;
            Param[2] = new SqlParameter("@StateId", SqlDbType.BigInt);
            Param[2].Value = StateId;
            Param[3] = new SqlParameter("@ReffNo", SqlDbType.NVarChar, 100);
            Param[3].Value = ReffNo;
            Param[4] = new SqlParameter("@CompanyId", SqlDbType.BigInt);
            Param[4].Value = CompanyId;
            Param[5] = new SqlParameter("@HType", SqlDbType.Int);
            Param[5].Value = HType;
            Param[6] = new SqlParameter("@HType1", SqlDbType.Int);
            Param[6].Value = HType1;
            Param[7] = new SqlParameter("@EMonth", SqlDbType.Int);
            Param[7].Value = EMonth;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "RptGetAandSGeneral", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "RptGetAandSGeneral", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }

    public DataSet RptGetAandSComplex(int CMonth, int CYear, Int64 StateId, string ReffNo, Int64 CompanyId, int HType, int HType1, int HType2, int HType3, int EMonth)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[10];
            Param[0] = new SqlParameter("@CMonth", SqlDbType.Int);
            Param[0].Value = CMonth;
            Param[1] = new SqlParameter("@CYear", SqlDbType.Int);
            Param[1].Value = CYear;
            Param[2] = new SqlParameter("@StateId", SqlDbType.BigInt);
            Param[2].Value = StateId;
            Param[3] = new SqlParameter("@ReffNo", SqlDbType.NVarChar, 100);
            Param[3].Value = ReffNo;
            Param[4] = new SqlParameter("@CompanyId", SqlDbType.BigInt);
            Param[4].Value = CompanyId;
            Param[5] = new SqlParameter("@HType", SqlDbType.Int);
            Param[5].Value = HType;
            Param[6] = new SqlParameter("@HType1", SqlDbType.Int);
            Param[6].Value = HType1;
            Param[7] = new SqlParameter("@HType2", SqlDbType.Int);
            Param[7].Value = HType2;
            Param[8] = new SqlParameter("@HType3", SqlDbType.Int);
            Param[8].Value = HType3;
            Param[9] = new SqlParameter("@EMonth", SqlDbType.Int);
            Param[9].Value = EMonth;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "RptGetAandSComplex", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "RptGetAandSComplex", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }

    public DataSet RptSOOGeneral(int CMonth, int CYear, Int64 StateId, string ReffNo, Int64 CompanyId, int HType, int HType1, int EMonth)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[8];
            Param[0] = new SqlParameter("@CMonth", SqlDbType.Int);
            Param[0].Value = CMonth;
            Param[1] = new SqlParameter("@CYear", SqlDbType.Int);
            Param[1].Value = CYear;
            Param[2] = new SqlParameter("@StateId", SqlDbType.BigInt);
            Param[2].Value = StateId;
            Param[3] = new SqlParameter("@ReffNo", SqlDbType.NVarChar, 100);
            Param[3].Value = ReffNo;
            Param[4] = new SqlParameter("@CompanyId", SqlDbType.BigInt);
            Param[4].Value = CompanyId;
            Param[5] = new SqlParameter("@HType", SqlDbType.Int);
            Param[5].Value = HType;
            Param[6] = new SqlParameter("@HType1", SqlDbType.Int);
            Param[6].Value = HType1;
            Param[7] = new SqlParameter("@EMonth", SqlDbType.Int);
            Param[7].Value = EMonth;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "RptGetSOOGeneral", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "RptSOOGeneral", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }
    public DataSet RptSOOComplex(int CMonth, int CYear, Int64 StateId, string ReffNo, Int64 CompanyId, int HType, int HType1, int HType2, int HType3, int EMonth)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[10];
            Param[0] = new SqlParameter("@CMonth", SqlDbType.Int);
            Param[0].Value = CMonth;
            Param[1] = new SqlParameter("@CYear", SqlDbType.Int);
            Param[1].Value = CYear;
            Param[2] = new SqlParameter("@StateId", SqlDbType.BigInt);
            Param[2].Value = StateId;
            Param[3] = new SqlParameter("@ReffNo", SqlDbType.NVarChar, 100);
            Param[3].Value = ReffNo;
            Param[4] = new SqlParameter("@CompanyId", SqlDbType.BigInt);
            Param[4].Value = CompanyId;
            Param[5] = new SqlParameter("@HType", SqlDbType.Int);
            Param[5].Value = HType;
            Param[6] = new SqlParameter("@HType1", SqlDbType.Int);
            Param[6].Value = HType1;
            Param[7] = new SqlParameter("@HType2", SqlDbType.Int);
            Param[7].Value = HType2;
            Param[8] = new SqlParameter("@HType3", SqlDbType.Int);
            Param[8].Value = HType3;
            Param[9] = new SqlParameter("@EMonth", SqlDbType.Int);
            Param[9].Value = EMonth;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "RptGetSOOComplex", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "RptSOOComplex", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }

    public DataSet RptGetPatientDeathDetails(int CMonth, int CYear, int HType, Int64 StateId, string ReffNo, Int64 CompanyId, int EMonth)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[7];
            Param[0] = new SqlParameter("@CMonth", SqlDbType.Int);
            Param[0].Value = CMonth;
            Param[1] = new SqlParameter("@CYear", SqlDbType.Int);
            Param[1].Value = CYear;
            Param[2] = new SqlParameter("@HType", SqlDbType.Int);
            Param[2].Value = HType;
            Param[3] = new SqlParameter("@StateId", SqlDbType.BigInt);
            Param[3].Value = StateId;
            Param[4] = new SqlParameter("@ReffNo", SqlDbType.NVarChar, 100);
            Param[4].Value = ReffNo;
            Param[5] = new SqlParameter("@CompanyId", SqlDbType.BigInt);
            Param[5].Value = CompanyId;
            Param[6] = new SqlParameter("@EMonth", SqlDbType.Int);
            Param[6].Value = EMonth;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "RptGetPatientDeathDetails", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "RptGetPatientDeathDetails", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }
    public DataSet RptGetPatientDeathComplex(int CMonth, int CYear, int HType, Int64 StateId, string ReffNo, Int64 CompanyId, int HType1, int EMonth)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[8];
            Param[0] = new SqlParameter("@CMonth", SqlDbType.Int);
            Param[0].Value = CMonth;
            Param[1] = new SqlParameter("@CYear", SqlDbType.Int);
            Param[1].Value = CYear;
            Param[2] = new SqlParameter("@HType", SqlDbType.Int);
            Param[2].Value = HType;
            Param[3] = new SqlParameter("@StateId", SqlDbType.BigInt);
            Param[3].Value = StateId;
            Param[4] = new SqlParameter("@ReffNo", SqlDbType.NVarChar, 100);
            Param[4].Value = ReffNo;
            Param[5] = new SqlParameter("@CompanyId", SqlDbType.BigInt);
            Param[5].Value = CompanyId;
            Param[6] = new SqlParameter("@HType1", SqlDbType.Int);
            Param[6].Value = HType1;
            Param[7] = new SqlParameter("@EMonth", SqlDbType.Int);
            Param[7].Value = EMonth;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "RptGetPatientDeathComplex", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "RptGetPatientDeathComplex", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }

    public DataSet RptGetBoughtPatientDeathDetails(int CMonth, int CYear, Int64 StateId, string ReffNo, Int64 CompanyId, int HType, int HType1, int EMonth)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[8];
            Param[0] = new SqlParameter("@CMonth", SqlDbType.Int);
            Param[0].Value = CMonth;
            Param[1] = new SqlParameter("@CYear", SqlDbType.Int);
            Param[1].Value = CYear;
            Param[2] = new SqlParameter("@HType", SqlDbType.Int);
            Param[2].Value = HType;
            Param[3] = new SqlParameter("@StateId", SqlDbType.BigInt);
            Param[3].Value = StateId;
            Param[4] = new SqlParameter("@ReffNo", SqlDbType.NVarChar, 100);
            Param[4].Value = ReffNo;
            Param[5] = new SqlParameter("@CompanyId", SqlDbType.BigInt);
            Param[5].Value = CompanyId;
            Param[6] = new SqlParameter("@HType1", SqlDbType.Int);
            Param[6].Value = HType1;
            Param[7] = new SqlParameter("@EMonth", SqlDbType.Int);
            Param[7].Value = EMonth;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "RptGetBoughtPatientDeathDetails", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "RptGetBoughtPatientDeathDetails", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }
    public DataSet RptGetBoughtPatientDeathComplex(int CMonth, int CYear, Int64 StateId, string ReffNo, Int64 CompanyId, int HType, int HType1, int HType2, int HType3, int EMonth)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[10];
            Param[0] = new SqlParameter("@CMonth", SqlDbType.Int);
            Param[0].Value = CMonth;
            Param[1] = new SqlParameter("@CYear", SqlDbType.Int);
            Param[1].Value = CYear;
            Param[2] = new SqlParameter("@HType", SqlDbType.Int);
            Param[2].Value = HType;
            Param[3] = new SqlParameter("@StateId", SqlDbType.BigInt);
            Param[3].Value = StateId;
            Param[4] = new SqlParameter("@ReffNo", SqlDbType.NVarChar, 100);
            Param[4].Value = ReffNo;
            Param[5] = new SqlParameter("@CompanyId", SqlDbType.BigInt);
            Param[5].Value = CompanyId;
            Param[6] = new SqlParameter("@HType1", SqlDbType.Int);
            Param[6].Value = HType1;
            Param[7] = new SqlParameter("@HType2", SqlDbType.Int);
            Param[7].Value = HType2;
            Param[8] = new SqlParameter("@HType3", SqlDbType.Int);
            Param[8].Value = HType3;
            Param[9] = new SqlParameter("@EMonth", SqlDbType.Int);
            Param[9].Value = EMonth;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "RptGetBoughtPatientDeathComplex", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "RptGetBoughtPatientDeathComplex", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }

    public DataSet RptGetCasualty(int CMonth, int CYear, int HType, Int64 StateId, string ReffNo, Int64 CompanyId, int HType1, int EMonth)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[8];
            Param[0] = new SqlParameter("@CMonth", SqlDbType.Int);
            Param[0].Value = CMonth;
            Param[1] = new SqlParameter("@CYear", SqlDbType.Int);
            Param[1].Value = CYear;
            Param[2] = new SqlParameter("@HType", SqlDbType.Int);
            Param[2].Value = HType;
            Param[3] = new SqlParameter("@StateId", SqlDbType.BigInt);
            Param[3].Value = StateId;
            Param[4] = new SqlParameter("@ReffNo", SqlDbType.NVarChar, 100);
            Param[4].Value = ReffNo;
            Param[5] = new SqlParameter("@CompanyId", SqlDbType.BigInt);
            Param[5].Value = CompanyId;
            Param[6] = new SqlParameter("@HType1", SqlDbType.BigInt);
            Param[6].Value = HType1;
            Param[7] = new SqlParameter("@EMonth", SqlDbType.Int);
            Param[7].Value = EMonth;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "RptGetCasualty", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "RptGetCasualty", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }
    public DataSet RptGetCasualtyComplex(int CMonth, int CYear, int HType, Int64 StateId, string ReffNo, Int64 CompanyId, int HType1, int HType2, int HType3, int EMonth)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[10];
            Param[0] = new SqlParameter("@CMonth", SqlDbType.Int);
            Param[0].Value = CMonth;
            Param[1] = new SqlParameter("@CYear", SqlDbType.Int);
            Param[1].Value = CYear;
            Param[2] = new SqlParameter("@HType", SqlDbType.Int);
            Param[2].Value = HType;
            Param[3] = new SqlParameter("@StateId", SqlDbType.BigInt);
            Param[3].Value = StateId;
            Param[4] = new SqlParameter("@ReffNo", SqlDbType.NVarChar, 100);
            Param[4].Value = ReffNo;
            Param[5] = new SqlParameter("@CompanyId", SqlDbType.BigInt);
            Param[5].Value = CompanyId;
            Param[6] = new SqlParameter("@HType1", SqlDbType.Int);
            Param[6].Value = HType1;
            Param[7] = new SqlParameter("@HType2", SqlDbType.Int);
            Param[7].Value = HType1;
            Param[8] = new SqlParameter("@HType3", SqlDbType.Int);
            Param[8].Value = HType1;
            Param[9] = new SqlParameter("@EMonth", SqlDbType.Int);
            Param[9].Value = EMonth;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "RptGetCasualtyComplex", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "RptGetCasualtyComplex", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }

    public string RptGetPeriod(int Mon, int Yea)
    {
        string Period = "";
        try
        {
            if (Mon == 0)
            {
                Period = "January - December " + Yea.ToString();
            }
            else if (Mon == 1)
            {
                Period = "January - " + Yea.ToString();
            }
            else if (Mon == 2)
            {
                Period = "February - " + Yea.ToString();
            }
            else if (Mon == 3)
            {
                Period = "March - " + Yea.ToString();
            }
            else if (Mon == 4)
            {
                Period = "April - " + Yea.ToString();
            }
            else if (Mon == 5)
            {
                Period = "May - " + Yea.ToString();
            }
            else if (Mon == 6)
            {
                Period = "June - " + Yea.ToString();
            }
            else if (Mon == 7)
            {
                Period = "July - " + Yea.ToString();
            }
            else if (Mon == 8)
            {
                Period = "August - " + Yea.ToString();
            }
            else if (Mon == 9)
            {
                Period = "September - " + Yea.ToString();
            }
            else if (Mon == 10)
            {
                Period = "October - " + Yea.ToString();
            }
            else if (Mon == 11)
            {
                Period = "November - " + Yea.ToString();
            }
            else if (Mon == 12)
            {
                Period = "December - " + Yea.ToString();
            }
            else if (Mon == 13)
            {
                Period = "Quarter1 (Jan-Mar) " + Yea.ToString();
            }
            else if (Mon == 14)
            {
                Period = "Quarter2 (Apr-Jun) " + Yea.ToString();
            }
            else if (Mon == 15)
            {
                Period = "Quarter3 (Jul-Sept) " + Yea.ToString();
            }
            else if (Mon == 16)
            {
                Period = "Quarter4 (Oct-Dec) " + Yea.ToString();
            }
            else if (Mon == 17)
            {
                Period = "Bi-annual (Jan-Jun) " + Yea.ToString();
            }
            else if (Mon == 18)
            {
                Period = "Bi-annual (Jul-Dec) " + Yea.ToString();
            }
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "RptGetPeriod", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Period;
    }
    public int RptGetSmonth(int Mon)
    {
        int SMonth = Mon;
        if (Mon == 13)
            SMonth = 1;
        if (Mon == 14)
            SMonth = 4;
        if (Mon == 15)
            SMonth = 7;
        if (Mon == 16)
            SMonth = 10;
        if (Mon == 17)
            SMonth = 1;
        if (Mon == 18)
            SMonth = 7;

        return SMonth;
    }
    public int RptGetEmonth(int Mon)
    {
        int EMonth = Mon;
        if (Mon == 13)
            EMonth = 3;
        if (Mon == 14)
            EMonth = 6;
        if (Mon == 15)
            EMonth = 9;
        if (Mon == 16)
            EMonth = 12;
        if (Mon == 17)
            EMonth = 6;
        if (Mon == 18)
            EMonth = 12;

        return EMonth;
    }
    /*New Added Report :04 OCt 19 - Jaydip*/
    public DataSet RptGetAllHosptBEDS(Int64 CompanyId, Int64 StateId, string Machine, int CMonth, int CYear, int Htype, string RefNum, int EMonth)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[8];
            Param[0] = new SqlParameter("@CompanyId", SqlDbType.BigInt);
            Param[0].Value = CompanyId;
            Param[1] = new SqlParameter("@StateId", SqlDbType.BigInt);
            Param[1].Value = StateId;
            Param[2] = new SqlParameter("@Machine", SqlDbType.NVarChar, 120);
            Param[2].Value = Machine;
            Param[3] = new SqlParameter("@CMonth", SqlDbType.Int);
            Param[3].Value = CMonth;
            Param[4] = new SqlParameter("@CYear", SqlDbType.Int);
            Param[4].Value = CYear;
            Param[5] = new SqlParameter("@Htype", SqlDbType.Int);
            Param[5].Value = Htype;
            Param[6] = new SqlParameter("@RefNum", SqlDbType.NVarChar, 120);
            Param[6].Value = RefNum;
            Param[7] = new SqlParameter("@EMonth", SqlDbType.Int);
            Param[7].Value = EMonth;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "RptGetAllHosptBEDS", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "RptGetAllHosptBEDS", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }
    public DataSet RptGetAllHosptOutCome(Int64 CompanyId, Int64 StateId, string Machine, int CMonth, int CYear, int Htype, string RefNum, int EMonth)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[8];
            Param[0] = new SqlParameter("@CompanyId", SqlDbType.BigInt);
            Param[0].Value = CompanyId;
            Param[1] = new SqlParameter("@StateId", SqlDbType.BigInt);
            Param[1].Value = StateId;
            Param[2] = new SqlParameter("@Machine", SqlDbType.NVarChar, 120);
            Param[2].Value = Machine;
            Param[3] = new SqlParameter("@CMonth", SqlDbType.Int);
            Param[3].Value = CMonth;
            Param[4] = new SqlParameter("@CYear", SqlDbType.Int);
            Param[4].Value = CYear;
            Param[5] = new SqlParameter("@Htype", SqlDbType.Int);
            Param[5].Value = Htype;
            Param[6] = new SqlParameter("@RefNum", SqlDbType.NVarChar, 120);
            Param[6].Value = RefNum;
            Param[7] = new SqlParameter("@EMonth", SqlDbType.Int);
            Param[7].Value = EMonth;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "RptGetAllHosptOutCome", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "RptGetAllHosptOutCome", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }
    public DataSet RptGetPatientAdmitOutcomes(Int64 CompanyId, Int64 StateId, string Machine, int CMonth, int CYear, int Htype, string RefNum, int EMonth)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[8];
            Param[0] = new SqlParameter("@CompanyId", SqlDbType.BigInt);
            Param[0].Value = CompanyId;
            Param[1] = new SqlParameter("@StateId", SqlDbType.BigInt);
            Param[1].Value = StateId;
            Param[2] = new SqlParameter("@Machine", SqlDbType.NVarChar, 120);
            Param[2].Value = Machine;
            Param[3] = new SqlParameter("@CMonth", SqlDbType.Int);
            Param[3].Value = CMonth;
            Param[4] = new SqlParameter("@CYear", SqlDbType.Int);
            Param[4].Value = CYear;
            Param[5] = new SqlParameter("@Htype", SqlDbType.Int);
            Param[5].Value = Htype;
            Param[6] = new SqlParameter("@RefNum", SqlDbType.NVarChar, 120);
            Param[6].Value = RefNum;
            Param[7] = new SqlParameter("@EMonth", SqlDbType.Int);
            Param[7].Value = EMonth;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "RptGetPatientAdmitOutcomes", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "RptGetPatientAdmitOutcomes", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }
    public DataSet RptGetBlindnessPrevProg(Int64 CompanyId, Int64 StateId, string Machine, int CMonth, int CYear, int Htype, string RefNum, int EMonth)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[8];
            Param[0] = new SqlParameter("@CompanyId", SqlDbType.BigInt);
            Param[0].Value = CompanyId;
            Param[1] = new SqlParameter("@StateId", SqlDbType.BigInt);
            Param[1].Value = StateId;
            Param[2] = new SqlParameter("@Machine", SqlDbType.NVarChar, 120);
            Param[2].Value = Machine;
            Param[3] = new SqlParameter("@CMonth", SqlDbType.Int);
            Param[3].Value = CMonth;
            Param[4] = new SqlParameter("@CYear", SqlDbType.Int);
            Param[4].Value = CYear;
            Param[5] = new SqlParameter("@Htype", SqlDbType.Int);
            Param[5].Value = Htype;
            Param[6] = new SqlParameter("@RefNum", SqlDbType.NVarChar, 120);
            Param[6].Value = RefNum;
            Param[7] = new SqlParameter("@EMonth", SqlDbType.Int);
            Param[7].Value = EMonth;

            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "RptGetBlindnessPrevProg", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "RptGetBlindnessPrevProg", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }
    public DataSet RptGetDentalProcedure(Int64 CompanyId, Int64 StateId, string Machine, int CMonth, int CYear, int Htype, string RefNum, int EMonth)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[8];
            Param[0] = new SqlParameter("@CompanyId", SqlDbType.BigInt);
            Param[0].Value = CompanyId;
            Param[1] = new SqlParameter("@StateId", SqlDbType.BigInt);
            Param[1].Value = StateId;
            Param[2] = new SqlParameter("@Machine", SqlDbType.NVarChar, 120);
            Param[2].Value = Machine;
            Param[3] = new SqlParameter("@CMonth", SqlDbType.Int);
            Param[3].Value = CMonth;
            Param[4] = new SqlParameter("@CYear", SqlDbType.Int);
            Param[4].Value = CYear;
            Param[5] = new SqlParameter("@Htype", SqlDbType.Int);
            Param[5].Value = Htype;
            Param[6] = new SqlParameter("@RefNum", SqlDbType.NVarChar, 120);
            Param[6].Value = RefNum;
            Param[7] = new SqlParameter("@EMonth", SqlDbType.Int);
            Param[7].Value = EMonth;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "RptGetDentalProcedure", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "RptGetDentalProcedure", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }
    public DataSet RptGetMaternalHealth(Int64 CompanyId, Int64 StateId, string Machine, int CMonth, int CYear, int Htype, string RefNum, int EMonth)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[8];
            Param[0] = new SqlParameter("@CompanyId", SqlDbType.BigInt);
            Param[0].Value = CompanyId;
            Param[1] = new SqlParameter("@StateId", SqlDbType.BigInt);
            Param[1].Value = StateId;
            Param[2] = new SqlParameter("@Machine", SqlDbType.NVarChar, 120);
            Param[2].Value = Machine;
            Param[3] = new SqlParameter("@CMonth", SqlDbType.Int);
            Param[3].Value = CMonth;
            Param[4] = new SqlParameter("@CYear", SqlDbType.Int);
            Param[4].Value = CYear;
            Param[5] = new SqlParameter("@Htype", SqlDbType.Int);
            Param[5].Value = Htype;
            Param[6] = new SqlParameter("@RefNum", SqlDbType.NVarChar, 120);
            Param[6].Value = RefNum;
            Param[7] = new SqlParameter("@EMonth", SqlDbType.Int);
            Param[7].Value = EMonth;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "RptGetMaternalHealth", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "RptGetMaternalHealth", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }
    public DataSet RptGetLiveBirthWeight(Int64 CompanyId, Int64 StateId, string Machine, int CMonth, int CYear, int Htype, string RefNum, int EMonth)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[8];
            Param[0] = new SqlParameter("@CompanyId", SqlDbType.BigInt);
            Param[0].Value = CompanyId;
            Param[1] = new SqlParameter("@StateId", SqlDbType.BigInt);
            Param[1].Value = StateId;
            Param[2] = new SqlParameter("@Machine", SqlDbType.NVarChar, 120);
            Param[2].Value = Machine;
            Param[3] = new SqlParameter("@CMonth", SqlDbType.Int);
            Param[3].Value = CMonth;
            Param[4] = new SqlParameter("@CYear", SqlDbType.Int);
            Param[4].Value = CYear;
            Param[5] = new SqlParameter("@Htype", SqlDbType.Int);
            Param[5].Value = Htype;
            Param[6] = new SqlParameter("@RefNum", SqlDbType.NVarChar, 120);
            Param[6].Value = RefNum;
            Param[7] = new SqlParameter("@EMonth", SqlDbType.Int);
            Param[7].Value = EMonth;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "RptGetLiveBirthWeight", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "RptGetLiveBirthWeight", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }

    public DataSet GetCMF(int CMonth, int CYear, int HType, int HType1, Int64 StateId, string ReffNo, Int64 CompanyId, int EMonth)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[8];
            Param[0] = new SqlParameter("@CMonth", SqlDbType.Int);
            Param[0].Value = CMonth;
            Param[1] = new SqlParameter("@CYear", SqlDbType.Int);
            Param[1].Value = CYear;
            Param[2] = new SqlParameter("@HType", SqlDbType.Int);
            Param[2].Value = HType;
            Param[3] = new SqlParameter("@HType1", SqlDbType.Int);
            Param[3].Value = HType1;
            Param[4] = new SqlParameter("@StateId", SqlDbType.BigInt);
            Param[4].Value = StateId;
            Param[5] = new SqlParameter("@ReffNo", SqlDbType.NVarChar, 100);
            Param[5].Value = ReffNo;
            Param[6] = new SqlParameter("@CompanyId", SqlDbType.BigInt);
            Param[6].Value = CompanyId;
            Param[7] = new SqlParameter("@EMonth", SqlDbType.Int);
            Param[7].Value = EMonth;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "RptGetCMF", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "GetMonthly", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }
    /*Report - END*/

    public DataSet GetUserTypeDrp(Int64 TypeId)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[1];
            Param[0] = new SqlParameter("@TypeId", SqlDbType.BigInt);
            Param[0].Value = TypeId;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "Web_GetUserTypeDrp", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "GetUserTypeDrp", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }
    public DataSet GetUserPermission(Int64 TypeId)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[1];
            Param[0] = new SqlParameter("@TypeId", SqlDbType.BigInt);
            Param[0].Value = TypeId;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "Web_GetUserPermission", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "GetUserPermission", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }
    public DataSet GetPermission(Int64 TypeId)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[1];
            Param[0] = new SqlParameter("@TypeId", SqlDbType.BigInt);
            Param[0].Value = TypeId;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "Web_GetPermission", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "GetUserPermission", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }
    public Int64 SavePermissionMaster(Int64 RecId, Int64 MenuId, Int64 TypeId, int IsActive, Int64 CreatedBy)
    {
        Int64 Result = 0;
        try
        {
            SqlParameter[] Param = new SqlParameter[5];
            Param[0] = new SqlParameter("@RecId", SqlDbType.BigInt);
            Param[0].Value = RecId;
            Param[0].Direction = ParameterDirection.InputOutput;
            Param[1] = new SqlParameter("@MenuId", SqlDbType.BigInt);
            Param[1].Value = MenuId;
            Param[2] = new SqlParameter("@TypeId", SqlDbType.BigInt);
            Param[2].Value = TypeId;
            Param[3] = new SqlParameter("@IsActive", SqlDbType.Int);
            Param[3].Value = IsActive;
            Param[4] = new SqlParameter("@CreatedBy", SqlDbType.BigInt);
            Param[4].Value = CreatedBy;
            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "Web_SavePermissionMaster", Param);
            Result = strtoint64(Param[0].Value.ToString());
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "SavePermissionMaster", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Result;
    }
    /*Report - Goverment*/
    public DataSet RptGovABAG(int CMonth, int EMonth, int CYear, Int64 CompanyId, int HType, DateTime FromDate, DateTime ToDate, int DateMode)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[8];
            Param[0] = new SqlParameter("@CMonth", SqlDbType.Int);
            Param[0].Value = CMonth;
            Param[1] = new SqlParameter("@EMonth", SqlDbType.Int);
            Param[1].Value = EMonth;
            Param[2] = new SqlParameter("@CYear", SqlDbType.Int);
            Param[2].Value = CYear;
            Param[3] = new SqlParameter("@CompanyId", SqlDbType.BigInt);
            Param[3].Value = CompanyId;
            Param[4] = new SqlParameter("@HType", SqlDbType.Int);
            Param[4].Value = HType;
            Param[5] = new SqlParameter("@FromDate", SqlDbType.DateTime);
            Param[5].Value = FromDate;
            Param[6] = new SqlParameter("@ToDate", SqlDbType.DateTime);
            Param[6].Value = ToDate;
            Param[7] = new SqlParameter("@DateMode", SqlDbType.Int);
            Param[7].Value = DateMode;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "RptGovABAG", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "RptGovABAG", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }
    public DataSet RptGovDBAGIP(int CMonth, int EMonth, int CYear, Int64 CompanyId, int HType, DateTime FromDate, DateTime ToDate, int DateMode)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[8];
            Param[0] = new SqlParameter("@CMonth", SqlDbType.Int);
            Param[0].Value = CMonth;
            Param[1] = new SqlParameter("@EMonth", SqlDbType.Int);
            Param[1].Value = EMonth;
            Param[2] = new SqlParameter("@CYear", SqlDbType.Int);
            Param[2].Value = CYear;
            Param[3] = new SqlParameter("@CompanyId", SqlDbType.BigInt);
            Param[3].Value = CompanyId;
            Param[4] = new SqlParameter("@HType", SqlDbType.Int);
            Param[4].Value = HType;
            Param[5] = new SqlParameter("@FromDate", SqlDbType.DateTime);
            Param[5].Value = FromDate;
            Param[6] = new SqlParameter("@ToDate", SqlDbType.DateTime);
            Param[6].Value = ToDate;
            Param[7] = new SqlParameter("@DateMode", SqlDbType.Int);
            Param[7].Value = DateMode;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "RptGovDBAGIP", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "RptGovDBAGIP", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }
    public DataSet RptGovIPS(int CMonth, int EMonth, int CYear, Int64 CompanyId, int HType)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[5];
            Param[0] = new SqlParameter("@CMonth", SqlDbType.Int);
            Param[0].Value = CMonth;
            Param[1] = new SqlParameter("@EMonth", SqlDbType.Int);
            Param[1].Value = EMonth;
            Param[2] = new SqlParameter("@CYear", SqlDbType.Int);
            Param[2].Value = CYear;
            Param[3] = new SqlParameter("@CompanyId", SqlDbType.BigInt);
            Param[3].Value = CompanyId;
            Param[4] = new SqlParameter("@HType", SqlDbType.Int);
            Param[4].Value = HType;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "RptGovIPS", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "RptGovIPS", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }
    public DataSet RptGovMA(int CMonth, int EMonth, int CYear, Int64 CompanyId, int HType, DateTime FromDate, DateTime ToDate, int DateMode)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[8];
            Param[0] = new SqlParameter("@CMonth", SqlDbType.Int);
            Param[0].Value = CMonth;
            Param[1] = new SqlParameter("@EMonth", SqlDbType.Int);
            Param[1].Value = EMonth;
            Param[2] = new SqlParameter("@CYear", SqlDbType.Int);
            Param[2].Value = CYear;
            Param[3] = new SqlParameter("@CompanyId", SqlDbType.BigInt);
            Param[3].Value = CompanyId;
            Param[4] = new SqlParameter("@HType", SqlDbType.Int);
            Param[4].Value = HType;
            Param[5] = new SqlParameter("@FromDate", SqlDbType.DateTime);
            Param[5].Value = FromDate;
            Param[6] = new SqlParameter("@ToDate", SqlDbType.DateTime);
            Param[6].Value = ToDate;
            Param[7] = new SqlParameter("@DateMode", SqlDbType.Int);
            Param[7].Value = DateMode;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "RptGovMA", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "RptGovMA", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }
    public DataSet RptGovMHSI(int CMonth, int EMonth, int CYear, Int64 CompanyId, int HType)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[5];
            Param[0] = new SqlParameter("@CMonth", SqlDbType.Int);
            Param[0].Value = CMonth;
            Param[1] = new SqlParameter("@EMonth", SqlDbType.Int);
            Param[1].Value = EMonth;
            Param[2] = new SqlParameter("@CYear", SqlDbType.Int);
            Param[2].Value = CYear;
            Param[3] = new SqlParameter("@CompanyId", SqlDbType.BigInt);
            Param[3].Value = CompanyId;
            Param[4] = new SqlParameter("@HType", SqlDbType.Int);
            Param[4].Value = HType;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "RptGovMHSI", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "RptGovMHSI", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }
    public DataSet RptGovNCOPCC(int CMonth, int EMonth, int CYear, Int64 CompanyId, int HType, DateTime FromDate, DateTime ToDate, int DateMode)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[8];
            Param[0] = new SqlParameter("@CMonth", SqlDbType.Int);
            Param[0].Value = CMonth;
            Param[1] = new SqlParameter("@EMonth", SqlDbType.Int);
            Param[1].Value = EMonth;
            Param[2] = new SqlParameter("@CYear", SqlDbType.Int);
            Param[2].Value = CYear;
            Param[3] = new SqlParameter("@CompanyId", SqlDbType.BigInt);
            Param[3].Value = CompanyId;
            Param[4] = new SqlParameter("@HType", SqlDbType.Int);
            Param[4].Value = HType;
            Param[5] = new SqlParameter("@FromDate", SqlDbType.DateTime);
            Param[5].Value = FromDate;
            Param[6] = new SqlParameter("@ToDate", SqlDbType.DateTime);
            Param[6].Value = ToDate;
            Param[7] = new SqlParameter("@DateMode", SqlDbType.Int);
            Param[7].Value = DateMode;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "RptGovNCOPCC", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "RptGovNCOPCC", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }
    public DataSet RptGovOCOPCC(int CMonth, int EMonth, int CYear, Int64 CompanyId, int HType, DateTime FromDate, DateTime ToDate, int DateMode)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[8];
            Param[0] = new SqlParameter("@CMonth", SqlDbType.Int);
            Param[0].Value = CMonth;
            Param[1] = new SqlParameter("@EMonth", SqlDbType.Int);
            Param[1].Value = EMonth;
            Param[2] = new SqlParameter("@CYear", SqlDbType.Int);
            Param[2].Value = CYear;
            Param[3] = new SqlParameter("@CompanyId", SqlDbType.BigInt);
            Param[3].Value = CompanyId;
            Param[4] = new SqlParameter("@HType", SqlDbType.Int);
            Param[4].Value = HType;
            Param[5] = new SqlParameter("@FromDate", SqlDbType.DateTime);
            Param[5].Value = FromDate;
            Param[6] = new SqlParameter("@ToDate", SqlDbType.DateTime);
            Param[6].Value = ToDate;
            Param[7] = new SqlParameter("@DateMode", SqlDbType.Int);
            Param[7].Value = DateMode;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "RptGovOCOPCC", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "RptGovOCOPCC", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }
    public DataSet RptGovOPNCBAG(int CMonth, int EMonth, int CYear, Int64 CompanyId, int HType, DateTime FromDate, DateTime ToDate, int DateMode)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[8];
            Param[0] = new SqlParameter("@CMonth", SqlDbType.Int);
            Param[0].Value = CMonth;
            Param[1] = new SqlParameter("@EMonth", SqlDbType.Int);
            Param[1].Value = EMonth;
            Param[2] = new SqlParameter("@CYear", SqlDbType.Int);
            Param[2].Value = CYear;
            Param[3] = new SqlParameter("@CompanyId", SqlDbType.BigInt);
            Param[3].Value = CompanyId;
            Param[4] = new SqlParameter("@HType", SqlDbType.Int);
            Param[4].Value = HType;
            Param[5] = new SqlParameter("@FromDate", SqlDbType.DateTime);
            Param[5].Value = FromDate;
            Param[6] = new SqlParameter("@ToDate", SqlDbType.DateTime);
            Param[6].Value = ToDate;
            Param[7] = new SqlParameter("@DateMode", SqlDbType.Int);
            Param[7].Value = DateMode;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "RptGovOPNCBAG", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "RptGovOPNCBAG", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }
    public DataSet RptGovOPTA(int CMonth, int EMonth, int CYear, Int64 CompanyId, int HType, DateTime FromDate, DateTime ToDate, int DateMode)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[8];
            Param[0] = new SqlParameter("@CMonth", SqlDbType.Int);
            Param[0].Value = CMonth;
            Param[1] = new SqlParameter("@EMonth", SqlDbType.Int);
            Param[1].Value = EMonth;
            Param[2] = new SqlParameter("@CYear", SqlDbType.Int);
            Param[2].Value = CYear;
            Param[3] = new SqlParameter("@CompanyId", SqlDbType.BigInt);
            Param[3].Value = CompanyId;
            Param[4] = new SqlParameter("@HType", SqlDbType.Int);
            Param[4].Value = HType;
            Param[5] = new SqlParameter("@FromDate", SqlDbType.DateTime);
            Param[5].Value = FromDate;
            Param[6] = new SqlParameter("@ToDate", SqlDbType.DateTime);
            Param[6].Value = ToDate;
            Param[7] = new SqlParameter("@DateMode", SqlDbType.Int);
            Param[7].Value = DateMode;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "RptGovOPTA", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "RptGovOPTA", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }
    public DataSet RptGovUOHSATSOO(int CMonth, int EMonth, int CYear, Int64 CompanyId, int HType, int HType1, DateTime FromDate, DateTime ToDate, int DateMode)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[9];
            Param[0] = new SqlParameter("@CMonth", SqlDbType.Int);
            Param[0].Value = CMonth;
            Param[1] = new SqlParameter("@EMonth", SqlDbType.Int);
            Param[1].Value = EMonth;
            Param[2] = new SqlParameter("@CYear", SqlDbType.Int);
            Param[2].Value = CYear;
            Param[3] = new SqlParameter("@CompanyId", SqlDbType.BigInt);
            Param[3].Value = CompanyId;
            Param[4] = new SqlParameter("@HType", SqlDbType.Int);
            Param[4].Value = HType;
            Param[5] = new SqlParameter("@HType1", SqlDbType.Int);
            Param[5].Value = HType1;
            Param[6] = new SqlParameter("@FromDate", SqlDbType.DateTime);
            Param[6].Value = FromDate;
            Param[7] = new SqlParameter("@ToDate", SqlDbType.DateTime);
            Param[7].Value = ToDate;
            Param[8] = new SqlParameter("@DateMode", SqlDbType.Int);
            Param[8].Value = DateMode;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "RptGovUOHSATSOO", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "RptGovUOHSATSOO", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }

    public DataSet RptGovMCPBG(int CMonth, int EMonth, int CYear, Int64 CompanyId)
    {
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter[] Param = new SqlParameter[4];
            Param[0] = new SqlParameter("@CMonth", SqlDbType.Int);
            Param[0].Value = CMonth;
            Param[1] = new SqlParameter("@EMonth", SqlDbType.Int);
            Param[1].Value = EMonth;
            Param[2] = new SqlParameter("@CYear", SqlDbType.Int);
            Param[2].Value = CYear;
            Param[3] = new SqlParameter("@CompanyId", SqlDbType.BigInt);
            Param[3].Value = CompanyId;
            Ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "RptGovMCPBG", Param);
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "RptGovMCPBG", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Ds;
    }
    /* Email Sent*/
    public Boolean EmailSent(string Body)
    {
        Boolean Result = false;
        try
        {
            String FromEmail = ConfigurationManager.AppSettings["Gid"].ToString();
            String EmailTo = ConfigurationManager.AppSettings["EmailTo"].ToString();
            string EmailTitle = ConfigurationManager.AppSettings["EmailTitle"].ToString();
            System.Net.Mail.MailMessage MyMailer = new System.Net.Mail.MailMessage();
            MyMailer.To.Add(EmailTo);
            MyMailer.From = new MailAddress(FromEmail, EmailTitle);
            MyMailer.IsBodyHtml = true;
            //MyMailer.Body = Body + GetSignature();
            MyMailer.Body = Body;
            MyMailer.Subject = EmailTitle;
            MyMailer.Priority = MailPriority.Normal;
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(FromEmail, ConfigurationManager.AppSettings["Gpass"]);
            client.EnableSsl = true;
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.Send(MyMailer);
            Result = true;
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "EmailSent", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Result;
    }
    public Boolean ForgotPwdEmailSent(string Body, string EmailTo, string EmailTitle)
    {
        Boolean Result = false;
        try
        {
            String FromEmail = ConfigurationManager.AppSettings["Gid"].ToString();

            System.Net.Mail.MailMessage MyMailer = new System.Net.Mail.MailMessage();
            MyMailer.From = new MailAddress(FromEmail, EmailTitle);
            if (EmailTo != "")
            {
                MyMailer.To.Add(EmailTo);
            }
            MyMailer.IsBodyHtml = true;
            MyMailer.Body = Body;
            MyMailer.Subject = EmailTitle;
            MyMailer.Priority = MailPriority.Normal;
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(FromEmail, ConfigurationManager.AppSettings["Gpass"]);
            client.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["Gid"].ToString());
            client.Port = strtoint(ConfigurationManager.AppSettings["Gid"].ToString());
            client.Host = ConfigurationManager.AppSettings["Gid"].ToString();
            client.Send(MyMailer);
            Result = true;
        }
        catch (Exception Ex)
        {
            ErrorLog("ClsDataset.cs", "EmailSent", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Result;
    }
}