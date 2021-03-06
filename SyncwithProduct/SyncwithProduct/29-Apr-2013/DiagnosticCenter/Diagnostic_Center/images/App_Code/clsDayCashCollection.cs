﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Odbc;
using BusinessLayer;
using DataLayer;

/// <summary>
/// Summary description for clsDayCashCollection
/// </summary>
public class clsDayCashCollection
{
    clsoperation objTrans = new clsoperation();
    clsdbhims objdbhims = new clsdbhims();

    private const string Default = "~!@";
    private const string TableName = "dc_tcashcheckin";
    private const string TableName1 = "dc_tpatient";

    private string StrErrorMessage = "";


    public clsDayCashCollection()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    private string type = Default;

    public string Type
    {
        get { return type; }
        set { type = value; }
    }
    private string StrFrom2 = Default;

    public string StrFrom21
    {
        get { return StrFrom2; }
        set { StrFrom2 = value; }
    }

    private string cashStatus = Default;

    public string CashStatus1
    {
        get { return cashStatus; }
        set { cashStatus = value; }
    }
    private string Personid = Default;

    public string Personid1
    {
        get { return Personid; }
        set { Personid = value; }
    }
    private string email = Default;

    public string Email
    {
        get { return email; }
        set { email = value; }
    }
    private string Panel = Default;

    public string Panel1
    {
        get { return Panel; }
        set { Panel = value; }
    }
    private string prid = Default;

    public string Prid
    {
        get { return prid; }
        set { prid = value; }
    }
    private string CellNo = Default;

    public string CellNo1
    {
        get { return CellNo; }
        set { CellNo = value; }
    }
    private string FromDate = Default;

    public string FromDate1
    {
        get { return FromDate; }
        set { FromDate = value; }
    }
    private string ToDate = Default;

    public string ToDate1
    {
        get { return ToDate; }
        set { ToDate = value; }
    }

    private string TestStatus = Default;

    public string TestStatus1
    {
        get { return TestStatus; }
        set { TestStatus = value; }
    }
    private string PatientName = Default;

    public string PatientName1
    {
        get { return PatientName; }
        set { PatientName = value; }
    }

    private string LableId = Default;

    public string LableId1
    {
        get { return LableId; }
        set { LableId = value; }
    }

    private string PR_NO = Default;

    public string PR_NO1
    {
        get { return PR_NO; }
        set { PR_NO = value; }
    }
    private string EntererOnTo1 = Default;

    public string _EnteredonTo
    {
        get { return EntererOnTo1; }
        set { EntererOnTo1 = value; }
    }
    private string _cashChkin_id = Default;

    public string CashChkin_id
    {
        get { return _cashChkin_id; }
        set { _cashChkin_id = value; }
    }
    private string _cashierid = Default;

    public string Cashierid
    {
        get { return _cashierid; }
        set { _cashierid = value; }
    }
    private string _cashierName = Default;

    public string CashierName
    {
        get { return _cashierName; }
        set { _cashierName = value; }
    }
    private string _cashOpening_Amount = Default;

    public string CashOpening_Amount
    {
        get { return _cashOpening_Amount; }
        set { _cashOpening_Amount = value; }
    }
    private string _cashClosing_Amount = Default;

    public string CashClosing_Amount
    {
        get { return _cashClosing_Amount; }
        set { _cashClosing_Amount = value; }
    }
    private string _cashStatus = Default;

    public string CashStatus
    {
        get { return _cashStatus; }
        set { _cashStatus = value; }
    }
    private string _enteredby = Default;

    public string Enteredby
    {
        get { return _enteredby; }
        set { _enteredby = value; }
    }
    private string _enteredon = Default;

    public string Enteredon
    {
        get { return _enteredon; }
        set { _enteredon = value; }
    }
    private string _enteredoff = Default;

    public string Enteredoff
    {
        get { return _enteredoff; }
        set { _enteredoff = value; }
    }
    private string _branchid = Default;

    public string Branchid
    {
        get { return _branchid; }
        set { _branchid = value; }
    }

    private string _reportno = Default;

    public string Reportno
    {
        get { return _reportno; }
        set { _reportno = value; }
    }


    private string StrDepartmentID = Default;
    private string StrSubDepartmentID = Default;
    private string StrGroupID = Default;
    private string StrTestID = Default;
    private string StrProcessID=Default;

    public string ProcessID
    {
        get { return StrProcessID; }
        set { StrProcessID = value; }
    }
    public string DepartmentID
    {
        get { return StrDepartmentID; }
        set { StrDepartmentID = value; }
    }
    public string SubDepartmentID
    {
        get { return StrSubDepartmentID; }
        set { StrSubDepartmentID = value; }
    }
    public string GroupID
    {
        get { return StrGroupID; }
        set { StrGroupID = value; }
    }
    public string TestID
    {
        get { return StrTestID; }
        set { StrTestID = value; }
    }


    public DataView GetAll(int flag)
    {
        switch (flag)
        {
            case 1:
                objdbhims.Query = "SELECT c.cashChkin_id,c.cashierid,c.cashierName,c.cashOpening_Amount,c.cashClosing_Amount,c.cashStatus,c.enteredby,c.enteredon,c.enteredoff,c.branchid,b.Name FROM dc_tcashcheckin as c, dc_tp_branch as b WHERE c.branchid=b.BranchID AND c.cashStatus='Online' AND c.cashierid ='" + Cashierid + "'";
                break;
            case 2:
                // objdbhims.Query = "SELECT c.reportno,c.cashChkin_id,c.cashierid,c.cashierName,c.cashOpening_Amount,c.cashClosing_Amount,c.cashStatus,c.enteredby,c.enteredon,c.enteredoff,c.branchid,b.Name FROM dc_tcashcheckin as c, dc_tp_branch as b WHERE c.branchid=b.BranchID AND b.BranchID = '" + _branchid + "' ORDER BY cashChkin_id DESC";
                objdbhims.Query = "SELECT c.reportno,c.cashChkin_id,c.cashierid,c.cashierName,c.cashOpening_Amount,c.cashClosing_Amount,c.cashStatus,c.enteredby,c.enteredon,c.enteredoff,c.branchid,b.Name FROM dc_tcashcheckin as c, dc_tp_branch as b WHERE c.branchid=b.BranchID ORDER BY cashChkin_id DESC";
                break;
            case 3:
                // objdbhims.Query = "select r.reportno,concat(ifnull(p.salutation,''),'',p.fname,' ',ifnull(p.mname,''),ifnull(p.lname,'')) as cashier,date_format(r.enteredon,'%D %M, %Y %h:%m:%s') as enteredon,date_format(NOW(),'%D %M, %Y %h:%m:%s') as datetoday from dc_tcashreport r join dc_tp_personnel p on p.personid=r.enteredby WHERE r.reportno='12-00001'";
                objdbhims.Query = "select r.reportno,concat(ifnull(p.salutation,''),'',p.fname,' ',ifnull(p.mname,''),ifnull(p.lname,'')) as cashier,date_format(r.enteredon,'%D %M, %Y %h:%m:%s') as enteredon,date_format(NOW(),'%D %M, %Y %h:%m:%s') as datetoday from dc_tcashreport r join dc_tp_personnel p on p.personid=r.enteredby WHERE r.reportno='" + _reportno + "'";
                break;
            case 4:
                //objdbhims.Query = "SELECT  p.prno, c.prid,c.labid,c.receiveno,c.paidamount,concat(ifnull(p.title,''),' ',p.name) as patientname,c.enteredon as receiveon,rp.enteredon as generatedon,og.name as orgname,og.phoneno,ifnull((select sum(paidamount) from dc_tcashcollection where panelid IS NULL AND reportno ='12-00001'),0) as totalcash,c.reportno,case when c.paymentmode='C' then 'Cash' when c.paymentmode='A' then 'On Account' when c.paymentmode='D' then 'Debit Card' when c.paymentmode='R' then 'Credit Card'  else '-' end as paymentmode, pn.name as panel,c.referenceno,bm.remarks ,bm.enteredon,case when bm.type='I' then 'Indoor' when bm.type='O' then 'Outdoor' else '-' end as patientType,c.discount,c.totalamount FROM dc_tcashcollection c left outer join dc_tpatient p on c.prid = p.prid left outer join dc_Tpatient_bookingm bm on bm.bookingid=c.bookingid left outer join dc_tp_organization og on c.clientid=og.orgid join dc_tcashreport rp on c.reportno=rp.reportno left outer join  dc_tpanel pn on pn.panelid=c.panelid where rp.reportno='12-00001' AND date_format(c.enteredon,'%d/%m/%Y') =date_format(bm.enteredon,'%d/%m/%Y') AND pn.panelid IS NULL order by p.prno,c.labid";
                objdbhims.Query = "SELECT  p.prno, c.prid,c.labid,c.receiveno,c.paidamount,concat(ifnull(p.title,''),' ',p.name) as patientname,c.enteredon as receiveon,rp.enteredon as generatedon,og.name as orgname,og.phoneno,ifnull((select sum(paidamount) from dc_tcashcollection where panelid IS NULL AND reportno ='" + _reportno + "'),0) as totalcash,c.reportno,case when c.paymentmode='C' then 'Cash' when c.paymentmode='A' then 'On Account' when c.paymentmode='D' then 'Debit Card' when c.paymentmode='R' then 'Credit Card'  else '-' end as paymentmode, pn.name as panel,c.referenceno,bm.remarks ,bm.enteredon,case when bm.type='I' then 'Indoor' when bm.type='O' then 'Outdoor' else '-' end as patientType,c.discount,c.totalamount FROM dc_tcashcollection c left outer join dc_tpatient p on c.prid = p.prid left outer join dc_Tpatient_bookingm bm on bm.bookingid=c.bookingid left outer join dc_tp_organization og on c.clientid=og.orgid join dc_tcashreport rp on c.reportno=rp.reportno left outer join  dc_tpanel pn on pn.panelid=c.panelid where rp.reportno='" + _reportno + "' AND date_format(c.enteredon,'%d/%m/%Y') =date_format(bm.enteredon,'%d/%m/%Y') AND pn.panelid IS NULL order by p.prno,c.labid";

                break;
            case 5:
                objdbhims.Query = "SELECT  p.prno, c.prid,c.labid,c.receiveno,c.paidamount,concat(ifnull(p.title,''),' ',p.name) as patientname,c.enteredon as receiveon,rp.enteredon as generatedon,og.name as orgname,og.phoneno,ifnull((select sum(paidamount) from dc_tcashcollection where panelid IS NOT NULL AND reportno ='" + _reportno + "'),0) as totalcash,c.reportno,case when c.paymentmode='C' then 'Cash' when c.paymentmode='A' then 'On Account' when c.paymentmode='D' then 'Debit Card' when c.paymentmode='R' then 'Credit Card'  else '-' end as paymentmode, pn.name as panel,c.referenceno,bm.remarks ,bm.enteredon,case when bm.type='I' then 'Indoor' when bm.type='O' then 'Outdoor' else '-' end as patientType,c.discount,c.totalamount FROM dc_tcashcollection c left outer join dc_tpatient p on c.prid = p.prid left outer join dc_Tpatient_bookingm bm on bm.bookingid=c.bookingid left outer join dc_tp_organization og on c.clientid=og.orgid join dc_tcashreport rp on c.reportno=rp.reportno left outer join  dc_tpanel pn on pn.panelid=c.panelid where rp.reportno='" + _reportno + "' AND date_format(c.enteredon,'%d/%m/%Y') =date_format(bm.enteredon,'%d/%m/%Y') AND pn.panelid IS NOT NULL order by p.prno,c.labid";
                break;
            case 6:
                objdbhims.Query = "SELECT p.prno,c.prid,c.labid,c.refundno,sum(c.paidamount) as paidamount, concat(ifnull(p.title,''),' ',p.name) as patientname,c.enteredon as refundon,ifnull((select sum(paidamount) from dc_tcashrefund where refundtype<>'D' and reportno =c.reportno),0) as totalrefund, case when c.refundtype='C' then 'Cancel' when c.refundtype='D' then 'Discount' when c.refundtype='K' then 'BCL Staff' when c.refundtype='R' then 'Poor Patient' when c.refundtype='P' then 'Panel Patient' when c.refundtype='W' then 'Wrong Entry' else '-' end as refundtype,r.reportno,SUM(c.totalamount) as totalamount FROM dc_tcashrefund c left outer join dc_tpatient p on c.prid = p.prid join dc_tcashreport r on c.reportno=r.reportno where  c.refundtype<>'D' AND r.reportno='" + _reportno + "' group by c.refundno";
                break;
            case 7:
                objdbhims.Query = "SELECT c.reportno,c.cashChkin_id,c.cashierid,c.cashierName,c.cashOpening_Amount,c.cashClosing_Amount,c.cashClosing_Amount - c.cashOpening_Amount as netcash,c.cashStatus,c.enteredby,c.enteredoff,c.branchid,b.Name FROM dc_tcashcheckin as c, dc_tp_branch as b WHERE c.branchid=b.BranchID and c.cashierName = '" + CashierName + "' and   (date_format(c.enteredon,'%Y/%m/%d')>= '" + Enteredon + "' or date_format(c.enteredon,'%Y/%m/%d') =   '" + Enteredon + "') and ( date_format(c.enteredon,'%Y/%m/%d')<= '" + _EnteredonTo + "'  or date_format(c.enteredon,'%Y/%m/%d') ='" + _EnteredonTo + "')";
                break;
            case 8:
                objdbhims.Query = "SELECT c.reportno,c.cashChkin_id,c.cashierid,c.cashierName,c.cashOpening_Amount,c.cashClosing_Amount,c.cashClosing_Amount - c.cashOpening_Amount as netcash,c.cashStatus,c.enteredby,c.enteredoff,c.branchid,b.Name FROM dc_tcashcheckin as c, dc_tp_branch as b WHERE c.branchid=b.BranchID and   (date_format(c.enteredon,'%Y/%m/%d')>= '" + Enteredon + "' or date_format(c.enteredon,'%Y/%m/%d') =   '" + Enteredon + "') and ( date_format(c.enteredon,'%Y/%m/%d')<= '" + _EnteredonTo + "'  or date_format(c.enteredon,'%Y/%m/%d')='" + _EnteredonTo + "')";
                break;
            case 9:
                objdbhims.Query = "SELECT c.reportno,c.cashChkin_id,c.cashierid,c.cashierName,c.cashOpening_Amount,c.cashClosing_Amount,c.cashClosing_Amount - c.cashOpening_Amount as netcash,c.cashStatus,c.enteredby,c.enteredoff,c.branchid,b.Name FROM dc_tcashcheckin as c, dc_tp_branch as b WHERE c.branchid=b.BranchID and   date_format(c.enteredon,'%Y/%m/%d') = '" + Enteredon + "'";
                break;
            case 10:
                objdbhims.Query = "SELECT c.reportno,c.cashChkin_id,c.cashierid,c.cashierName,c.cashOpening_Amount,c.cashClosing_Amount,c.cashClosing_Amount - c.cashOpening_Amount as netcash,c.cashStatus,c.enteredby,c.enteredoff,c.branchid,b.Name FROM dc_tcashcheckin as c, dc_tp_branch as b WHERE c.branchid=b.BranchID and c.cashierName = '" + CashierName + "' and  date_format(c.enteredon,'%Y/%m/%d')= '" + Enteredon + "'";
                break;
            case 11:
                objdbhims.Query = "SELECT c.reportno,c.cashChkin_id,c.cashierid,c.cashierName,c.cashOpening_Amount,c.cashClosing_Amount,c.cashStatus,c.enteredby,c.enteredon,c.enteredoff,c.branchid,b.Name FROM dc_tcashcheckin as c, dc_tp_branch as b WHERE c.branchid=b.BranchID and c.cashierid='" + Cashierid + "'";
                break;
            case 12:
                //objdbhims.Query = "SELECT c.reportno,c.cashChkin_id,c.cashierid,c.cashierName,c.cashOpening_Amount,c.cashClosing_Amount,c.cashStatus,c.enteredby,date_format(c.enteredon,'%b %d,%Y %h:%i:%s') as enteredon,date_format(c.enteredoff,'%b %d,%Y %h:%i:%s') as enteredoff,c.branchid,b.Name FROM dc_tcashcheckin as c, dc_tp_branch as b WHERE c.reportno = '" + _reportno + "' AND c.branchid=b.BranchID";
                objdbhims.Query = "SELECT c.reportno,c.cashChkin_id,c.cashierid,c.cashierName,c.cashOpening_Amount,c.cashClosing_Amount,c.cashStatus,c.enteredby,c.enteredon,c.enteredoff,c.branchid,b.Name FROM dc_tcashcheckin as c, dc_tp_branch as b WHERE c.reportno = '" + _reportno + "' AND c.branchid=b.BranchID LIMIT 1";
                break;
            case 13:
                objdbhims.Query = "select pd.ProcessID,p.prid, p.name as Patient_Name,p.cellno,p.hphone,date_format(p.dob,'%Y/%m/%d')as dob,case when DATEDIFF(CURRENT_DATE,p.dob) > 365 then      concat(Floor(DATEDIFF(CURRENT_DATE,p.dob)/365),'(Years)')  else    case when DATEDIFF(CURRENT_DATE,p.dob) > 30 then      concat(Floor(DATEDIFF(CURRENT_DATE,p.dob)/30),' (M)')    else      concat(DATEDIFF(CURRENT_DATE,p.dob),'(D)')    end  end  AS age,p.prno,case when pro.name = 'Archiving' then 'Archived' else pro.name end as status,t.Test_Name,t.charges as Test_Charges,pd.labid,date_format(p.enteredon,'%d/%m/%Y') as StatusDate,pm.balance from dc_tpatient p inner join dc_tpatient_bookingm pm on pm.prid = p.prid  inner join dc_tpatient_bookingd pd on pd.bookingid = pm.bookingid inner join dc_tp_tprocess pro on pro.processid = pd.processid inner join  dc_tp_test t on t.testid=pd.testid where 1=1   ";
                if (!this.PatientName1.Equals(Default) && !this.PatientName1.Equals(""))
                {
                    objdbhims.Query += " and p.name like '%" + PatientName1 + "%'";
                }
                if (!this.PR_NO.Equals(Default) && !this.PR_NO.Equals(""))
                {
                    objdbhims.Query += " And p.prno = '" + this.PR_NO + "'";
                }
                if (!this.LableId.Equals(Default) && !this.LableId.Equals(""))
                {
                    objdbhims.Query += " And pd.labid = '" + this.LableId + "'";
                }

                if (!this.CellNo.Equals(Default) && !this.CellNo.Equals(""))
                {
                    objdbhims.Query += " And p.cellno = '" + this.CellNo + "'";
                }
                if (!this.CellNo.Equals(Default) && !this.CellNo.Equals(""))
                {
                    objdbhims.Query += " or p.hphone = '" + this.CellNo + "'";
                }
                if (!this.FromDate.Equals(Default) && !this.FromDate.Equals("") && !this.ToDate.Equals(Default) && !this.ToDate.Equals(""))
                {
                    //objdbhims.Query += " and date_format(p.enteredon,'%Y/%m/%d')   >= '" + FromDate + "' and date_format(p.enteredon,'%Y/%m/%d') <=  '" + ToDate + "'";
                      objdbhims.Query += " and date_format(p.enteredon,'%Y/%m/%d')   between '" + FromDate + "' and  '" + ToDate + "' ";
                
                }
                objdbhims.Query += "order by date_format(p.enteredon,'%d/%m/%Y') desc ";
                
                break;
            case 14:
                objdbhims.Query = "select p.prid, p.name as Patient_Name,p.cellno,p.hphone,date_format(p.dob,'%Y/%m/%d')as dob,p.prno,pro.Name as Status,t.Test_Name,t.charges as Test_Charges,pd.labid,date_format(p.enteredon,'%Y/%m/%d') as StatusDate from dc_tpatient p inner join dc_tpatient_bookingm pm on pm.prid = p.prid  inner join dc_tpatient_bookingd pd on pd.bookingid = pm.bookingid inner join dc_tp_tprocess pro on pro.processid = pd.processid inner join  dc_tp_test t on t.testid=pd.testid where p.name  like '%" + PatientName1 + "%'";
                break;
            case 15:
                objdbhims.Query = "select p.Name,p.prno from " + TableName1 + " p where  p.Name LIKE '" + PatientName + "%' GROUP BY p.Name ORDER BY name LIMIT 0 , 8";
                break;
            case 16:
                objdbhims.Query = "select p.prid,p.email, p.name as Patient_Name,p.cellno,p.hphone,date_format(p.dob,'%Y/%m/%d')as dob,p.prno,pro.Name as Status,t.Test_Name,t.charges as Test_Charges,pd.labid,date_format(p.enteredon,'%Y/%m/%d') as StatusDate,p.BranchID from dc_tpatient p inner join dc_tpatient_bookingm pm on pm.prid = p.prid  inner join dc_tpatient_bookingd pd on pd.bookingid = pm.bookingid inner join dc_tp_tprocess pro on pro.processid = pd.processid inner join  dc_tp_test t on t.testid=pd.testid where p.prid ='" + prid + "' and pd.labid ='" + LableId1 + "' ";
                break;
            case 17:
               // objdbhims.Query = "select ifnull(DestinationBranchId,'-') as origin,pm.branchid, pd.ProcessID,p.prid ,b.name as Branches,p.name as Patient_Name,panel.panelid,p.cellno,p.hphone,date_format(p.dob,'%Y/%m/%d') as dob,case when DATEDIFF(CURRENT_DATE,p.dob) > 365 then      concat(Floor(DATEDIFF(CURRENT_DATE,p.dob)/365),'(Years)')  else    case when DATEDIFF(CURRENT_DATE,p.dob) > 30 then      concat(Floor(DATEDIFF(CURRENT_DATE,p.dob)/30),' (M)')    else      concat(DATEDIFF(CURRENT_DATE,p.dob),'(d)')    end  end  AS age,p.prno,case when pro.name  = 'Archiving' then 'Archived' else pro.name  end as status  ,t.Test_Name,t.charges as Test_Charges,pd.labid,date_format(p.enteredon,'%d/%m/%Y') as StatusDate,p.BranchID,pm.balance from dc_tpatient p left outer join dc_tpatient_bookingm pm on pm.prid = p.prid  left outer join dc_tp_branch b on b.branchid = pm.branchid left outer join dc_tpatient_bookingd pd on pd.bookingid = pm.bookingid left outer join dc_tp_tprocess pro on pro.processid = pd.processid left outer join  dc_tp_test t on t.testid=pd.testid left outer join dc_tpanel panel on panel.panelid  = p.panelid where 1=1 ";
                objdbhims.Query = @"SELECT pm.type,pm.adm_ref ,payment_mode,panel.name as Panel , pm.totalamount,pm.paidamount,t.testid,pm.Bookingid,pd.Bookingdid,t.TestType,SubdepartmentId,ifnull(DestinationBranchId,'-') as origin,pm.branchid, pd.ProcessID,p.prid ,b.name as Branches,p.name as Patient_Name,panel.panelid,ifnull(p.cellno,p.hphone)as cellno,date_format(p.dob,'%Y/%m/%d') as dob,case when DATEDIFF(CURRENT_DATE,p.dob) > 365 then      concat(Floor(DATEDIFF(CURRENT_DATE,p.dob)/365),'(Years)')  else    case when DATEDIFF(CURRENT_DATE,p.dob) > 30 then      concat(Floor(DATEDIFF(CURRENT_DATE,p.dob)/30),' (M)')    else      concat(DATEDIFF(CURRENT_DATE,p.dob),'(d)')    end  end  AS age,p.prno,case when pro.name  = 'Archiving' then 'ARV'  when pro.name  = 'Specimen Collection' then 'SCOL'
                                    when pro.name  = 'Worklist' then 'WLIST'
                                    when pro.name  = 'Result Entry' then 'RENT'
                                    when pro.name  = 'Result Verification' then 'VERF'
                                    when pro.name  = 'Result Dispatch' then 'RDY'
                                    when pro.name  = 'Refund/Discount' then 'REF'
                                    else pro.name  end as status,t.Test_Name,t.charges as Test_Charges,pd.labid,date_format(pm.enteredon,'%d/%m/%Y') as StatusDate,p.BranchID,pm.balance,p.email from dc_tpatient p left outer join dc_tpatient_bookingm pm on pm.prid = p.prid  left outer join dc_tp_branch b on b.branchid = pm.branchid left outer join dc_tpatient_bookingd pd on pd.bookingid = pm.bookingid left outer join dc_tp_tprocess pro on pro.processid = pd.processid left outer join  dc_tp_test t on t.testid=pd.testid left outer join dc_tpanel panel on panel.panelid  = p.panelid where 1=1 ";
             
               if (!this.PatientName1.Equals(Default) && !this.PatientName1.Equals(""))
                {
                    objdbhims.Query += " and p.name like '%" + PatientName1 + "%'";
                }
               if (!this.PR_NO.Equals(Default) && !this.PR_NO.Equals(""))
                {
                    objdbhims.Query += " And p.prno = '" + this.PR_NO + "'";
                }
               if (!this.LableId.Equals(Default) && !this.LableId.Equals(""))
                {
                    objdbhims.Query += " And pd.labid = '" + this.LableId + "'";
                }

                if (!this.CellNo.Equals(Default) && !this.CellNo.Equals(""))
                {
                    objdbhims.Query += " And p.cellno = '" + this.CellNo + "'";
                }
                if (!this.Panel.Equals(Default) && !this.Panel.Equals("-1")) 
                {
                    objdbhims.Query += " And panel.panelid = '" + this.Panel + "'";
                }

                if (!this.CellNo.Equals(Default) && !this.CellNo.Equals(""))
                {
                    objdbhims.Query += " or p.hphone = '" + this.CellNo + "'";
                }
                if (!this.Branchid.Equals(Default) && !this.Branchid.Equals("-1"))
                {
                    objdbhims.Query += "and pm.Branchid = '" + this.Branchid + "'";
                }
                if (!this.type.Equals(Default) && !this.type.Equals(""))
                {
                    objdbhims.Query += " And pm.type = '" + this.type + "'";
                }
                if (!StrDepartmentID.Equals(Default) && !StrDepartmentID.Equals(""))
                       objdbhims.Query += " and pd.testid in (select testid from dc_Tp_test where subdepartmentid in (select subdepartmentid from dc_tp_subdepartments where departmentid=" + StrDepartmentID + "))";
                if (!StrSubDepartmentID.Equals(Default) && !StrSubDepartmentID.Equals(""))
                       objdbhims.Query += " and t.subdepartmentid=" + StrSubDepartmentID + "";
                if (!StrGroupID.Equals(Default) && !StrGroupID.Equals(""))
                       objdbhims.Query += " and t.groupid=" + StrGroupID + "";
                if (!StrTestID.Equals(Default) && !StrTestID.Equals(""))
                       objdbhims.Query += " and t.testid=" + StrTestID + "";
                if (!this.FromDate.Equals(Default) && !this.FromDate.Equals("") && !this.ToDate.Equals(Default) && !this.ToDate.Equals(""))
                {
                    //objdbhims.Query += " and date_format(p.enteredon,'%Y/%m/%d')   >= '" + FromDate + "' and date_format(p.enteredon,'%Y/%m/%d') <=  '" + ToDate + "'";
                      objdbhims.Query += " and date_format(pm.enteredon,'%Y/%m/%d')   between '" + FromDate + "' and  '" + ToDate + "' ";
                
                }
                objdbhims.Query += "  order by date_format(pm.enteredon,'%Y/%m/%d') desc ";
                break;

            case 18:
                objdbhims.Query = "select panelid,name from dc_tpanel where active ='Y'";
                break;
            case 19:
                objdbhims.Query = "select   t.Test_Name,case when pro.name  = 'Archiving' then 'Archived' else pro.name  end as status  from dc_tp_test t inner join dc_tpatient_bookingd pd on pd.testid = t.testid inner join dc_tp_tprocess pro on pro.processid = pd.processid inner join dc_tpatient_bookingm pm on pm.bookingid = pd.bookingid where pm.prid = '" + prid + "'  and pm.labid='"+LableId+"'";
                break;

            case 20:
                // objdbhims.Query = "SELECT c.cashChkin_id,c.cashierid,c.cashierName,c.cashOpening_Amount,c.cashClosing_Amount,c.cashStatus,c.enteredby,c.enteredon,c.enteredoff,c.branchid,b.Name FROM dc_tcashcheckin as c, dc_tp_branch as b WHERE c.branchid=b.BranchID AND c.cashStatus='Online' AND b.BranchID='"+_branchid+"' ";
                objdbhims.Query = "SELECT c.cashChkin_id,c.cashierid,c.cashierName,c.cashOpening_Amount,c.cashClosing_Amount,c.cashStatus,c.enteredby,c.enteredon,c.enteredoff,c.branchid,b.Name FROM dc_tcashcheckin as c, dc_tp_branch as b WHERE c.branchid=b.BranchID AND c.cashStatus='Online' AND c.cashierid = '" + _cashierid + "' AND b.BranchID='"+_branchid+"' ";
                break;
            case 21:
                objdbhims.Query = //"SELECT date_format(dt.Enteredon,'%d/%m/%Y %H:%m:%s') as Enteredon, dt2.prno patientPR,dt2.name PatientName,dt2.cellno PatientCellNo,dt.labid,dt.testid,dtt2.Test_Name, CONCAT(dtp.FName,' ',dtp.MName,' ',dtp.LName) EnteredBy,dtt.name process FROM dc_tstatustrack dt INNER JOIN dc_tp_personnel dtp ON dtp.PersonId=dt.enteredby  INNER JOIN dc_tp_tprocess dtt ON dtt.processid=dt.processid INNER JOIN dc_tpatient_bookingd dtb ON dtb.bookingdid=dt.bookingdid INNER JOIN dc_tpatient_bookingm dtb2 ON dtb2.bookingid=dtb.bookingid INNER JOIN dc_tpatient dt2 ON dt2.prid=dtb2.prid INNER JOIN dc_tp_test dtt2 ON dtt2.TestId=dt.testid  WHERE dt.labid= '" + LableId + "' ORDER BY dt2.prno,dt.labid,dt.testid,dt.processid";
               @"SELECT dt2.prno patientPR,dt2.name PatientName,dt2.cellno PatientCellNo,dt.labid,dt.testid,dtt2.Test_Name,REPLACE(GROUP_CONCAT(dtt.name,' - (',CONCAT(dtp.FName,' ',dtp.MName,' ',dtp.LName),'-',date_format(dt.Enteredon,'%d/%m/%Y %H:%m:%s'),')'  ORDER BY dt.enteredon SEPARATOR ',') , ',' , '<br />') EnteredBy
FROM dc_tstatustrack dt INNER JOIN dc_tp_personnel dtp ON dtp.PersonId=dt.enteredby
INNER JOIN dc_tp_tprocess dtt ON dtt.processid=dt.processid
INNER JOIN dc_tpatient_bookingd dtb ON dtb.bookingdid=dt.bookingdid INNER JOIN dc_tpatient_bookingm dtb2 ON dtb2.bookingid=dtb.bookingid INNER JOIN dc_tpatient dt2 ON dt2.prid=dtb2.prid INNER JOIN dc_tp_test dtt2 ON dtt2.TestId=dt.testid
WHERE dt.labid= '" +LableId+"' GROUP BY dt.testid ORDER BY dt2.prno,dt.labid,dt.testid,dt.processid";
                
                
                break;
            case 22:
                objdbhims.Query = "select  cashStatus  from dc_tcashcheckin  where cashStatus = 'Online' AND branchid='"+_branchid+"' AND cashierid='"+_cashierid+"'";
                break;
            //////////testing......////////////////////////////////////////////////////////////////////////////
            case 23:
                objdbhims.Query = "SELECT prno,name FROM dc_tpatient d LIMIT 20";
                break;
            case 24:
                objdbhims.Query = "SELECT BranchID,Name FROM dc_tp_branch d LIMIT 5;";
                break;
            case 25:
               // objdbhims.Query = "select ifnull(DestinationBranchId,'-') as origin,pm.branchid, pd.ProcessID,p.prid ,b.name as Branches,p.name as Patient_Name,panel.panelid,p.cellno,p.hphone,date_format(p.dob,'%Y/%m/%d') as dob,case when DATEDIFF(CURRENT_DATE,p.dob) > 365 then      concat(Floor(DATEDIFF(CURRENT_DATE,p.dob)/365),'(Years)')  else    case when DATEDIFF(CURRENT_DATE,p.dob) > 30 then      concat(Floor(DATEDIFF(CURRENT_DATE,p.dob)/30),' (M)')    else      concat(DATEDIFF(CURRENT_DATE,p.dob),'(d)')    end  end  AS age,p.prno,case when pro.name  = 'Archiving' then 'Archived' else pro.name  end as status  ,t.Test_Name,t.charges as Test_Charges,pd.labid,date_format(p.enteredon,'%d/%m/%Y') as StatusDate,p.BranchID,pm.balance from dc_tpatient p left outer join dc_tpatient_bookingm pm on pm.prid = p.prid  left outer join dc_tp_branch b on b.branchid = pm.branchid left outer join dc_tpatient_bookingd pd on pd.bookingid = pm.bookingid left outer join dc_tp_tprocess pro on pro.processid = pd.processid left outer join  dc_tp_test t on t.testid=pd.testid left outer join dc_tpanel panel on panel.panelid  = p.panelid where 1=1 ";
                objdbhims.Query = @"SELECT pm.type,pm.adm_ref , payment_mode,panel.name as Panel,ifnull(p.cellno,p.hphone) as cellno, pm.totalamount,pm.paidamount,t.testid,pm.Bookingid,pd.Bookingdid,t.TestType,SubdepartmentId,ifnull(DestinationBranchId,'-') as origin,pm.branchid, pd.ProcessID,p.prid ,b.name as Branches,p.name as Patient_Name,panel.panelid,date_format(p.dob,'%Y/%m/%d') as dob,case when DATEDIFF(CURRENT_DATE,p.dob) > 365 then      concat(Floor(DATEDIFF(CURRENT_DATE,p.dob)/365),'(Years)')  else    case when DATEDIFF(CURRENT_DATE,p.dob) > 30 then      concat(Floor(DATEDIFF(CURRENT_DATE,p.dob)/30),' (M)')    else      concat(DATEDIFF(CURRENT_DATE,p.dob),'(d)')    end  end  AS age,p.prno,case when pro.name  = 'Archiving' then 'ARV'  when pro.name  = 'Specimen Collection' then 'SCOL'
                                    when pro.name  = 'Worklist' then 'WLIST'
                                    when pro.name  = 'Result Entry' then 'RENT'
                                    when pro.name  = 'Result Verification' then 'VERF'
                                    when pro.name  = 'Result Dispatch' then 'RDY'
                                    when pro.name  = 'Refund/Discount' then 'REF'
                                    else pro.name  end as status,t.Test_Name,t.charges as Test_Charges,pd.labid,date_format(pm.enteredon,'%d/%m/%Y') as StatusDate,p.BranchID,pm.balance,p.email from dc_tpatient p left outer join dc_tpatient_bookingm pm on pm.prid = p.prid  left outer join dc_tp_branch b on b.branchid = pm.branchid left outer join dc_tpatient_bookingd pd on pd.bookingid = pm.bookingid left outer join dc_tp_tprocess pro on pro.processid = pd.processid left outer join  dc_tp_test t on t.testid=pd.testid left outer join dc_tpanel panel on panel.panelid  = p.panelid where 1=1  ";

              if (!this.FromDate.Equals(Default) && !this.FromDate.Equals("") && !this.ToDate.Equals(Default) && !this.ToDate.Equals(""))
                {
                    //objdbhims.Query += " and date_format(p.enteredon,'%Y/%m/%d')   >= '" + FromDate + "' and date_format(p.enteredon,'%Y/%m/%d') <=  '" + ToDate + "'";
                      objdbhims.Query += " and date_format(pm.enteredon,'%Y/%m/%d')   between '" + FromDate + "' and  '" + ToDate + "' ";
                
                }
              if (!this.ProcessID.Equals("") && !this.ProcessID.Equals(Default))
              {
                  objdbhims.Query+=" and pro.processid="+StrProcessID;// IN ('Result Dispatch')"
              }
              if (!this.type.Equals(Default) && !this.type.Equals(""))
              {
                  objdbhims.Query += " And pm.type = '" + this.type + "'";
              }

              objdbhims.Query += " order by date_format(pm.enteredon,'%Y/%m/%d') asc ";
                break;
            case 26:
                objdbhims.Query = @"SELECT  p.prno, c.prid,c.labid,c.receiveno,c.paidamount,
                concat(ifnull(p.title,''),' ',p.name) as patientname,
                c.enteredon as receiveon,
                rp.enteredon as generatedon,
                og.name as orgname,og.phoneno,
                ifnull((select sum(paidamount) from dc_tcashcollection where reportno =rp.reportno),0)
                as totalcash,c.reportno,case when c.paymentmode='C' then 'Cash' when c.paymentmode='A' then 'On Account'
                when c.paymentmode='D' then 'Debit Card' when c.paymentmode='R' then 'Credit Card'  else '-' end as paymentmode,
                pn.name as panel,c.referenceno,bm.remarks ,bm.enteredon,bm.type
                FROM dc_tcashcollection c left outer join dc_tpatient p on c.prid = p.prid left outer join dc_Tpatient_bookingm bm
                on bm.bookingid=c.bookingid
                left outer join dc_tp_organization og on c.clientid=og.orgid
                 join dc_tcashreport rp on c.reportno=rp.reportno left outer join  dc_tpanel pn on pn.panelid=c.panelid
                where rp.reportno = '"+_reportno+@"' AND date_format(c.enteredon,'%d/%m/%Y') <> date_format(bm.enteredon,'%d/%m/%Y')
                order by p.prno,c.labid";
                break;
                 
        }
        return objTrans.DataTrigger_Get_All(objdbhims);
    }


    private string[,] MakeArray()
    {
        string[,] ary = new string[11, 3];

        if (!this._cashChkin_id.Equals(Default))
        {
            ary[0, 0] = "cashChkin_id";
            ary[0, 1] = this._cashChkin_id;
            ary[0, 2] = "int";
        }
        if (!this._cashierid.Equals(Default))
        {
            ary[1, 0] = "cashierid";
            ary[1, 1] = this._cashierid;
            ary[1, 2] = "string";
        }
        if (!this._cashierName.Equals(Default))
        {
            ary[2, 0] = "cashierName";
            ary[2, 1] = this._cashierName;
            ary[2, 2] = "string";
        }
        if (!this._cashOpening_Amount.Equals(Default))
        {
            ary[3, 0] = "cashOpening_Amount";
            ary[3, 1] = this._cashOpening_Amount;
            ary[3, 2] = "string";
        }
        if (!this._cashClosing_Amount.Equals(Default))
        {
            ary[4, 0] = "cashClosing_Amount";
            ary[4, 1] = this._cashClosing_Amount;
            ary[4, 2] = "string";
        }
        if (!this._cashStatus.Equals(Default))
        {
            ary[5, 0] = "cashStatus";
            ary[5, 1] = this._cashStatus;
            ary[5, 2] = "string";
        }

        if (!this._enteredby.Equals(Default))
        {
            ary[6, 0] = "enteredby";
            ary[6, 1] = this._enteredby;
            ary[6, 2] = "string";
        }
        if (!this._enteredon.Equals(Default))
        {
            ary[7, 0] = "enteredon";
            ary[7, 1] = this._enteredon;
            ary[7, 2] = "string";
        }
        if (!this._enteredoff.Equals(Default))
        {
            ary[8, 0] = "enteredoff";
            ary[8, 1] = this._enteredoff;
            ary[8, 2] = "string";
        }
        if (!this._branchid.Equals(Default))
        {
            ary[9, 0] = "branchid";
            ary[9, 1] = this._branchid;
            ary[9, 2] = "int";
        }
        if (!this._reportno.Equals(Default))
        {
            ary[10, 0] = "reportno";
            ary[10, 1] = this._reportno;
            ary[10, 2] = "string";
        }
        return ary;
    }
    
    public bool Insert()
    {
        QueryBuilder objQb = new QueryBuilder();
        objTrans.Start_Transaction();
        objdbhims.Query = objQb.QBInsert(MakeArray(), TableName);
        StrErrorMessage = objTrans.DataTrigger_Insert(objdbhims);
        if (StrErrorMessage.Equals("True"))
        {
            objTrans.End_Transaction();
            StrErrorMessage = objTrans.OperationError;
            return false;
        }
        else
        {
            objTrans.End_Transaction();
            return true;
        }
    }


    private bool Validation()
    {
        return true;
    }

    public bool Update()
    {
        if (Validation())
        {
            clsoperation objTrans = new clsoperation();
            QueryBuilder objQB = new QueryBuilder();

            objTrans.Start_Transaction();
            objdbhims.Query = objQB.QBUpdate(MakeArray(), TableName);
            this.StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);
            objTrans.End_Transaction();

            if (this.StrErrorMessage.Equals("True"))
            {
                this.StrErrorMessage = objTrans.OperationError;
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {

            return false;
        }
    }
}
