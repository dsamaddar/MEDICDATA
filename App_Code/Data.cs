using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Data
{
    public Data()
    {
        GroupId = 0;
        HType = 0;
        HType1 = 0;
        HType2 = 0;
        HType3 = 0;
        HType4 = 0;
        CaseType = 0;
        GenderType = 0;
        FrmTitle = "";
    }
    public int GroupId;
    public int HType;
    public int HType1;
    public int HType2;
    public int HType3;
    public int HType4;
    public int CaseType;
    public int GenderType;
    public string FrmTitle;

}

public class DataAlloc
{
    public DataAlloc()
    {
        HType = 0;
        FrmTitle = "";
    }

    public int HType;
    public string FrmTitle;
}