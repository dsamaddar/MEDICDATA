<%@ Page Title="MEDICDATA | HOME" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu86" Visible="false" runat="server" class="report-link" Text="ALLOCATION OF HOSPITAL BEDS GENERAL"
                OnClick="rptHospitalBedsGen_Click"></asp:LinkButton>
        </div>
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu68" Visible="false" runat="server" class="report-link" Text="ATTENDANCE BY STATE OF ORIGIN (SOO) GENERAL"
                OnClick="lnkSOOGeneral_Click"></asp:LinkButton>
        </div>
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu92" Visible="false" runat="server" class="report-link" Text="BLINDNESS PREVENTION DATA GENERAL"
                OnClick="rptBlindnessGEN_Click"></asp:LinkButton>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu87" Visible="false" runat="server" class="report-link" Text="ALLOCATION OF HOSPITAL BEDS MCC"
                OnClick="rptHospitalBedsMCC_Click"></asp:LinkButton>
        </div>
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu69" Visible="false" runat="server" class="report-link" Text="ATTENDANCE BY STATE OF ORIGIN (SOO) MCC"
                OnClick="lnkSOOMCC_Click"></asp:LinkButton>
        </div>
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu93" Visible="false" runat="server" class="report-link" Text="BLINDNESS PREVENTION DATA MCC"
                OnClick="rptBlindnessMCC_Click"></asp:LinkButton>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu88" Visible="false" runat="server" class="report-link" Text="ALLOCATION OF HOSPITAL BEDS COMPLEX"
                OnClick="rptHospitalBedsComp_Click"></asp:LinkButton>
        </div>
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <a href="#" class="report-link"></a>
            <asp:LinkButton ID="Menu70" Visible="false" runat="server" class="report-link" Text="ATTENDANCE BY STATE OF ORIGIN (SOO) COMPLEX"
                OnClick="lnkSOOComplex_Click"></asp:LinkButton>
        </div>
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu94" Visible="false" runat="server" class="report-link" Text="BLINDNESS PREVENTION DATA COMPLEX"
                OnClick="rptBlindnessComp_Click"></asp:LinkButton>
        </div>
    </div>
    <div class="row" id="LineMenu86" runat ="server" visible="false">
        <div class="col-lg-12">
            <hr class="hr-border">
        </div>
    </div>
    <div class="row">
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu77" Visible="false" runat="server" class="report-link" Text="BROUGHT-IN-DEATH GENERAL"
                OnClick="lnkBroughtInDeathGen_Click"></asp:LinkButton>
        </div>
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu151" Visible="false" runat="server" class="report-link" Text="DENTAL PROCEDURE  GENERAL"
                OnClick="rptDentalGen_Click"></asp:LinkButton>
        </div>
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu80" Visible="false" runat="server" class="report-link" Text="IN-PATIENT DEATH GENERAL"
                OnClick="lnkINPatientDeathGen_Click"></asp:LinkButton>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu78" Visible="false" runat="server" class="report-link" Text="BROUGHT-IN-DEATH MCC"
                OnClick="lnkBroughtInDeathMCC_Click"></asp:LinkButton>
        </div>
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu152" Visible="false" runat="server" class="report-link" Text="DENTAL PROCEDURE  MCC"
                OnClick="rptDentalMCC_Click"></asp:LinkButton>
        </div>
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu81" Visible="false" runat="server" class="report-link" Text="IN-PATIENT DEATH MCC"
                OnClick="lnkINPatientDeathMCC_Click"></asp:LinkButton>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu79" Visible="false" runat="server" class="report-link" Text="BROUGHT-IN-DEATH COMPLEX"
                OnClick="lnkBroughtInDeathComplex_Click"></asp:LinkButton>
        </div>
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu153" Visible="false" runat="server" class="report-link" Text="DENTAL PROCEDURE COMPLEX"
                OnClick="rptDentalComp_Click"></asp:LinkButton>
        </div>
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu82" Visible="false" runat="server" class="report-link" Text="IN-PATIENT DEATH COMPLEX"
                OnClick="lnkINPatientDeathComplex_Click"></asp:LinkButton>
        </div>
    </div>
        <div class="row" id="LineMenu77" runat ="server" visible="false">
        <div class="col-lg-12">
            <hr class="hr-border">
        </div>
    </div>
    <div class="row">
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu98" Visible="false" runat="server" class="report-link" Text="LIVE BIRTH WEIGHT BY SEX GENERAL"
                OnClick="rptLiveBirthGen_Click"></asp:LinkButton>
        </div>
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu95" Visible="false" runat="server" class="report-link" Text="MATERNAL HEALTH SERVICES INFORMATION GENERAL"
                OnClick="rptMaternalGen_Click"></asp:LinkButton>
        </div>
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu65" Visible="false" runat="server" class="report-link" Text="OUTPATIENT CASES AND ATTENDANCE (DOPCA) GENERAL"
                OnClick="lnkDOPCAGen_Click"></asp:LinkButton>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu99" Visible="false" runat="server" class="report-link" Text="LIVE BIRTH WEIGHT BY SEX MCC"
                OnClick="rptLiveBirthMCC_Click"></asp:LinkButton>
        </div>
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu96" Visible="false" runat="server" class="report-link" Text="MATERNAL HEALTH SERVICES INFORMATION MCC"
                OnClick="rptMaternalMCC_Click"></asp:LinkButton>
        </div>
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu66" Visible="false" runat="server" class="report-link" Text="OUTPATIENT CASES AND ATTENDANCE (DOPCA) MCC"
                OnClick="lnkDOPCAMCC_Click"></asp:LinkButton>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu100" Visible="false" runat="server" class="report-link" Text="LIVE BIRTH WEIGHT BY SEX COMPLEX"
                OnClick="rptLiveBirthComp_Click"></asp:LinkButton>
        </div>
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu97" Visible="false" runat="server" class="report-link" Text="MATERNAL HEALTH SERVICES INFORMATION COMPLEX"
                OnClick="rptMaternalComp_Click"></asp:LinkButton>
        </div>
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu67" Visible="false" runat="server" class="report-link" Text="OUTPATIENT CASES AND ATTENDANCE (DOPCA) COMPLEX"
                OnClick="lnkDOPCAComplex_Click"></asp:LinkButton>
        </div>
    </div>
    <div class="row" id="LineMenu98" runat ="server" visible="false">
        <div class="col-lg-12">
            <hr class="hr-border">
        </div>
    </div>
    <div class="row">
        <div class="col-lg-6 col-md-6 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu83" Visible="false" runat="server" class="report-link" Text="OUT-PATIENT CASUALITY NEW CASES AND DEATH BY AGE GROUP AND SEX GENERAL"
                OnClick="lnkdocng_Click"></asp:LinkButton>
        </div>
        <div class="col-lg-6 col-md-6 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu71" Visible="false" runat="server" class="report-link" Text="AGE SEX DISTRIBUTION BY ADMISSION GENERAL"
                OnClick="lnkAandSDistGen_Click"></asp:LinkButton>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-6 col-md-6 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu84" Visible="false" runat="server" class="report-link" Text="OUT-PATIENT CASUALITY NEW CASES AND DEATH BY AGE GROUP AND SEX MCC"
                OnClick="lnkdocnm_Click"></asp:LinkButton>
        </div>
        <div class="col-lg-6 col-md-6 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu72" Visible="false" runat="server" class="report-link" Text="AGE SEX DISTRIBUTION BY ADMISSION MCC"
                OnClick="lnkAandSDistMCC_Click"></asp:LinkButton>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-6 col-md-6 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu85" Visible="false" runat="server" class="report-link" Text="OUT-PATIENT CASUALITY NEW CASES AND DEATH BY AGE GROUP AND SEX COMPLEX"
                OnClick="lnkdocnc_Click"></asp:LinkButton>
        </div>
        <div class="col-lg-6 col-md-6 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu73" Visible="false" runat="server" class="report-link" Text="AGE SEX DISTRIBUTION BY ADMISSION COMPLEX"
                OnClick="lnkAandSDistComplex_Click"></asp:LinkButton>
        </div>
    </div>
    <div class="row" id="LineMenu83" runat ="server" visible="false">
        <div class="col-lg-12">
            <hr class="hr-border">
        </div>
    </div>
    <div class="row">
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu74" Visible="false" runat="server" class="report-link" Text="OUT-PATIENT DEATH GENERAL"
                OnClick="lnkOUTPatientDeathGen_Click"></asp:LinkButton>
        </div>
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu89" Visible="false" runat="server" class="report-link" Text="PATIENT ADMIT OUTCOMES GENERAL"
                OnClick="rptPatientOutGen_Click"></asp:LinkButton>
        </div>
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu155" Visible="false" runat="server" class="report-link" Text="C.M.F. 12"
                OnClick="CMF12_Click"></asp:LinkButton>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu75" Visible="false" runat="server" class="report-link" Text="OUT-PATIENT DEATH MCC"
                OnClick="lnkOUTPatientDeathMCC_Click"></asp:LinkButton>
        </div>
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu90" Visible="false" runat="server" class="report-link" Text="PATIENT ADMIT OUTCOMES MCC"
                OnClick="rptPatientOutMCC_Click"></asp:LinkButton>
        </div>
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
        </div>
    </div>
    <div class="row">
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu76" Visible="false" runat="server" class="report-link" Text="OUT-PATIENT DEATH COMPLEX"
                OnClick="lnkOUTPatientDeathComplex_Click"></asp:LinkButton>
        </div>
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu91" Visible="false" runat="server" class="report-link" Text="PATIENT ADMIT OUTCOMES COMPLEX"
                OnClick="rptPatientOutComp_Click"></asp:LinkButton>
        </div>
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
        </div>
    </div>
    <div id="divAggRptHeader" runat="server">
        <div class="row">
            <div class="col-lg-12">
                <hr class="hr-border">
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <h4 style="text-align: center; padding-bottom: 10px;">
                    Aggregated Reports</h4>
            </div>
        </div>
    </div>
    <!--New-->
    <div class="row">
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu2008" Visible="false" runat="server" class="report-link"
                Text="ADMISSION BY AGE-GROUP GENERAL" OnClick="Menu2008_Click"></asp:LinkButton>
        </div>
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu2005" Visible="false" runat="server" class="report-link"
                Text="DEATH BY AGE-GROUP (IN PATIENTS) GENERAL" OnClick="Menu2005_Click"></asp:LinkButton>
        </div>
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu2010" Visible="false" runat="server" class="report-link"
                Text="IN-PATIENT STATISTICS GENERAL" OnClick="Menu2010_Click"></asp:LinkButton>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu2018" Visible="false" runat="server" class="report-link"
                Text="ADMISSION BY AGE-GROUP MCC" OnClick="Menu2018_Click"></asp:LinkButton>
        </div>
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu2015" Visible="false" runat="server" class="report-link"
                Text="DEATH BY AGE-GROUP (IN PATIENTS) MCC" OnClick="Menu2015_Click"></asp:LinkButton>
        </div>
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu2020" Visible="false" runat="server" class="report-link"
                Text="IN-PATIENT STATISTICS MCC" OnClick="Menu2020_Click"></asp:LinkButton>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu2048" Visible="false" runat="server" class="report-link"
                Text="ADMISSION BY AGE-GROUP COMPLEX" OnClick="Menu2048_Click"></asp:LinkButton>
        </div>
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu2045" Visible="false" runat="server" class="report-link"
                Text="DEATH BY AGE-GROUP (IN PATIENTS) COMPLEX" OnClick="Menu2045_Click"></asp:LinkButton>
        </div>
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu2050" Visible="false" runat="server" class="report-link"
                Text="IN-PATIENT STATISTICS COMPLEX" OnClick="Menu2050_Click"></asp:LinkButton>
        </div>
    </div>
    <div class="row" id="LineMenu2008" runat ="server" visible="false">
        <div class="col-lg-12">
            <hr class="hr-border">
        </div>
    </div>
    <div class="row">
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu2002" Visible="false" runat="server" class="report-link"
                Text="MATERNAL HEALTH SERVICES INFORMATION GENERAL" OnClick="Menu2002_Click"></asp:LinkButton>
        </div>
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu2009" Visible="false" runat="server" class="report-link"
                Text="MISCELLANEOUS ATTENDANCES GENERAL" OnClick="Menu2009_Click"></asp:LinkButton>
        </div>
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu2003" Visible="false" runat="server" class="report-link"
                Text="NEW CASES OUT-PATIENT CONSULTANT CLINIC GENERAL" OnClick="Menu2003_Click"></asp:LinkButton>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu2012" Visible="false" runat="server" class="report-link"
                Text="MATERNAL HEALTH SERVICES INFORMATION MCC" OnClick="Menu2012_Click"></asp:LinkButton>
        </div>
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu2019" Visible="false" runat="server" class="report-link"
                Text="MISCELLANEOUS ATTENDANCES MCC" OnClick="Menu2019_Click"></asp:LinkButton>
        </div>
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu2013" Visible="false" runat="server" class="report-link"
                Text="NEW CASES OUT-PATIENT CONSULTANT CLINIC MCC" OnClick="Menu2013_Click"></asp:LinkButton>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu2042" Visible="false" runat="server" class="report-link"
                Text="MATERNAL HEALTH SERVICES INFORMATION COMPLEX" OnClick="Menu2042_Click"></asp:LinkButton>
        </div>
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu2049" Visible="false" runat="server" class="report-link"
                Text="MISCELLANEOUS ATTENDANCES COMPLEX" OnClick="Menu2049_Click"></asp:LinkButton>
        </div>
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu2043" Visible="false" runat="server" class="report-link"
                Text="NEW CASES OUT-PATIENT CONSULTANT CLINIC COMPLEX" OnClick="Menu2043_Click"></asp:LinkButton>
        </div>
    </div>
    <div class="row" id="LineMenu2002" runat ="server" visible="false">
        <div class="col-lg-12">
            <hr class="hr-border">
        </div>
    </div>
    <div class="row">
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu2004" Visible="false" runat="server" class="report-link"
                Text="OLD CASES OUT-PATIENT CONSULTANT CLINIC GENERAL" OnClick="Menu2004_Click"></asp:LinkButton>
        </div>
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu2006" Visible="false" runat="server" class="report-link"
                Text="OUT-PATIENT TOTAL ATTENDANCES GENERAL" OnClick="Menu2006_Click"></asp:LinkButton>
        </div>
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu2007" Visible="false" runat="server" class="report-link"
                Text="OUT-PATIENTS NEW CASES BY AGE-GROUP GENERAL" OnClick="Menu2007_Click"></asp:LinkButton>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu2014" Visible="false" runat="server" class="report-link"
                Text="OLD CASES OUT-PATIENT CONSULTANT CLINIC MCC" OnClick="Menu2014_Click"></asp:LinkButton>
        </div>
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu2016" Visible="false" runat="server" class="report-link"
                Text="OUT-PATIENT TOTAL ATTENDANCES MCC" OnClick="Menu2016_Click"></asp:LinkButton>
        </div>
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu2017" Visible="false" runat="server" class="report-link"
                Text="OUT-PATIENTS NEW CASES BY AGE-GROUP MCC" OnClick="Menu2017_Click"></asp:LinkButton>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu2044" Visible="false" runat="server" class="report-link"
                Text="OLD CASES OUT-PATIENT CONSULTANT CLINIC COMPLEX" OnClick="Menu2044_Click"></asp:LinkButton>
        </div>
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu2046" Visible="false" runat="server" class="report-link"
                Text="OUT-PATIENT TOTAL ATTENDANCES COMPLEX" OnClick="Menu2046_Click"></asp:LinkButton>
        </div>
        <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu2047" Visible="false" runat="server" class="report-link"
                Text="OUT-PATIENTS NEW CASES BY AGE-GROUP COMPLEX" OnClick="Menu2047_Click"></asp:LinkButton>
        </div>
    </div>
    <div class="row" id="LineMenu2004" runat ="server" visible="false">
        <div class="col-lg-12">
            <hr class="hr-border">
        </div>
    </div>
    <div class="row">
        <div class="col-lg-6 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu2001" Visible="false" runat="server" class="report-link"
                Text="UTILIZATION OF HOSPITALS SERVICE ACCORDING TO STATE OF ORIGIN GENERAL"
                OnClick="Menu2001_Click"></asp:LinkButton>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-6 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu2011" Visible="false" runat="server" class="report-link"
                Text="UTILIZATION OF HOSPITALS SERVICE ACCORDING TO STATE OF ORIGIN MCC" OnClick="Menu2011_Click"></asp:LinkButton>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-6 col-md-4 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu2041" Visible="false" runat="server" class="report-link"
                Text="UTILIZATION OF HOSPITALS SERVICE ACCORDING TO STATE OF ORIGIN COMPLEX"
                OnClick="Menu2041_Click"></asp:LinkButton>
        </div>
    </div>  
    <div class="row" id="LineMenu2001" runat ="server" visible="false">
        <div class="col-lg-12">
            <hr class="hr-border">
        </div>
    </div>
    <div class="row">
        <div class="col-lg-6 col-md-6 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu2051" Visible="false" runat="server" class="report-link"
                Text="MORBIDITY CASES PATTERN BY GENDER" OnClick="Menu2051_Click"></asp:LinkButton>
        </div>
        <div class="col-lg-6 col-md-6 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu2052" Visible="false" runat="server" class="report-link"
                Text="MORBIDITY CASES PATTERN BY AGE" OnClick="Menu2052_Click"></asp:LinkButton>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-6 col-md-6 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu2053" Visible="false" runat="server" class="report-link"
                Text="MORBIDITY DEATH PATTERN BY GENDER" OnClick="Menu2053_Click"></asp:LinkButton>
        </div>
        <div class="col-lg-6 col-md-6 col-xs-12 col-sm-12">
            <asp:LinkButton ID="Menu2054" Visible="false" runat="server" class="report-link"
                Text="MORBIDITY DEATH PATTERN BY AGE" OnClick="Menu2054_Click"></asp:LinkButton>
        </div>
    </div>
    <div class="row" style="visibility: hidden;">
        <div class="col-lg-12 col-sm-12 col-sm-12 col-xs-12">
            <div class="row py-3">
                <div class="col-lg-6 col-md-6 col-xs-12 col-sm-12">
                    <a href="#" class="report-link">CERTAIN INFECTIOS AND PARASITIC DISEASES (CIPD)</a>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-6 col-md-6 col-xs-12 col-sm-12">
                    <a href="#" class="report-link1">CIPD GENERATOR (CASES)</a>
                    <div class="row">
                        <div class="col-lg-12">
                            <b class="pages-title">PAGES</b>
                            <ul class="pages-link">
                                <li><a href="#">A</a></li>
                                <li><a href="#">B</a></li>
                                <li><a href="#">C</a></li>
                                <li><a href="#">D</a></li>
                                <li><a href="#">E</a></li>
                                <li><a href="#">F</a></li>
                                <li><a href="#">H</a></li>
                                <li><a href="#">I</a></li>
                                <li><a href="#">J</a></li>
                                <li><a href="#">K</a></li>
                                <li><a href="#">L</a></li>
                                <li><a href="#">M</a></li>
                                <li><a href="#">O</a></li>
                                <li><a href="#">P</a></li>
                                <li><a href="#">Q</a></li>
                                <li><a href="#">R</a></li>
                                <li><a href="#">S</a></li>
                                <li><a href="#">T</a></li>
                                <li><a href="#">V</a></li>
                                <li><a href="#">W</a></li>
                                <li><a href="#">X</a></li>
                                <li><a href="#">Y</a></li>
                                <li><a href="#">Z</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 col-xs-12 col-sm-12">
                    <a href="#" class="report-link1">CIPD GENERATOR (DEATH)</a>
                    <div class="row">
                        <div class="col-lg-12">
                            <b class="pages-title">PAGES</b>
                            <ul class="pages-link">
                                <li><a href="#">A</a></li>
                                <li><a href="#">B</a></li>
                                <li><a href="#">C</a></li>
                                <li><a href="#">D</a></li>
                                <li><a href="#">E</a></li>
                                <li><a href="#">F</a></li>
                                <li><a href="#">H</a></li>
                                <li><a href="#">I</a></li>
                                <li><a href="#">J</a></li>
                                <li><a href="#">K</a></li>
                                <li><a href="#">L</a></li>
                                <li><a href="#">M</a></li>
                                <li><a href="#">O</a></li>
                                <li><a href="#">P</a></li>
                                <li><a href="#">Q</a></li>
                                <li><a href="#">R</a></li>
                                <li><a href="#">S</a></li>
                                <li><a href="#">T</a></li>
                                <li><a href="#">V</a></li>
                                <li><a href="#">W</a></li>
                                <li><a href="#">X</a></li>
                                <li><a href="#">Y</a></li>
                                <li><a href="#">Z</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <style type="text/css">
        #content
        {
            background-image: url(images/homebg.jpg);
            background-size: 100%;
        }
    </style>
</asp:Content>
