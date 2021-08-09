using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public class BusinessBase
{
    protected static string _connectionString = string.Empty;
    static BusinessBase()
    {
        _connectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
        if (_connectionString.Contains("medicdata.com.ng.om"))
        {
            _connectionString = "Data Source=medicdata.com.ng;Initial Catalog=asanni2_MEDICDATA;User ID=asanni2_medicdata;Password=omtech@987;";
        }
    }
}
