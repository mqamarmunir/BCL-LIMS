using System;
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

    public string ErrorMessage
    {
        get { return StrErrorMessage; }
        set { StrErrorMessage = value; }
    }


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
    private string StrProcessID = Default;

    public string ProcessID
    {
        get { return StrProcessID; }
        set { StrProcessID = value; }
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
                objdbhims.Query = "SELECT c.reportno,c.cashChkin_id,c.cashierid,c.cashierName,c.cashOpening_Amount,c.cashClosing_Amount,c.cashStatus,c.enteredby,c.enteredon,c.enteredoff,c.branchid,b.Name FROM dc_tcashcheckin as c, dc_tp_branch as b WHERE c.branchid=b.BranchID ORDER BY cashChkin_id DESC Limit 200";
                break;
            case 3:
                // objdbhims.Query = "select r.reportno,concat(ifnull(p.salutation,''),'',p.fname,' ',ifnull(p.mname,''),ifnull(p.lname,'')) as cashier,date_format(r.enteredon,'%D %M, %Y %h:%m:%s') as enteredon,date_format(NOW(),'%D %M, %Y %h:%m:%s') as datetoday from dc_tcashreport r join dc_tp_personnel p on p.personid=r.enteredby WHERE r.reportno='12-00001'";
                objdbhims.Query = "select r.reportno,concat(ifnull(p.salutation,''),'',p.fname,' ',ifnull(p.mname,''),ifnull(p.lname,'')) as cashier,date_format(r.enteredon,'%D %M, %Y %h:%i:%s') as enteredon,date_format(NOW(),'%D %M, %Y %h:%i:%s') as datetoday from dc_tcashreport r join dc_tp_personnel p on p.personid=r.enteredby WHERE r.reportno='" + _reportno + "'";
                break;
            case 4:
                //objdbhims.Query = "SELECT  p.prno, c.prid,c.labid,c.receiveno,c.paidamount,concat(ifnull(p.title,''),' ',p.name) as patientname,c.enteredon as receiveon,rp.enteredon as generatedon,og.name as orgname,og.phoneno,ifnull((select sum(paidamount) from dc_tcashcollection where panelid IS NULL AND reportno ='12-00001'),0) as totalcash,c.reportno,case when c.paymentmode='C' then 'Cash' when c.paymentmode='A' then 'On Account' when c.paymentmode='D' then 'Debit Card' when c.paymentmode='R' then 'Credit Card'  else '-' end as paymentmode, pn.name as panel,c.referenceno,bm.remarks ,bm.enteredon,case when bm.type='I' then 'Indoor' when bm.type='O' then 'Outdoor' else '-' end as patientType,c.discount,c.totalamount FROM dc_tcashcollection c left outer join dc_tpatient p on c.prid = p.prid left outer join dc_Tpatient_bookingm bm on bm.bookingid=c.bookingid left outer join dc_tp_organization og on c.clientid=og.orgid join dc_tcashreport rp on c.reportno=rp.reportno left outer join  dc_tpanel pn on pn.panelid=c.panelid where rp.reportno='12-00001' AND date_format(c.enteredon,'%d/%m/%Y') =date_format(bm.enteredon,'%d/%m/%Y') AND pn.panelid IS NULL order by p.prno,c.labid";
                objdbhims.Query = @"SELECT p.prno,
       c.prid,
       c.labid,
       c.receiveno,
       ifnull(c.paidamount, 0) paidamount,
       concat(ifnull(p.title, ''), ' ', p.name) as patientname,
       date_format(c.enteredon, '%d/%m/%Y %r') as receiveon,
       date_format(rp.enteredon, '%d/%m/%Y %r') as generatedon,
       og.name as orgname,
       og.phoneno,
       c.reportno,
       case
         when c.paymentmode = 'C' then
          'Cash'
         when c.paymentmode = 'A' then
          concat('On Account (', pn.Name, ')')
         when c.paymentmode = 'D' then
          concat('Debit Card (', c.Referenceno, ')')
         when c.paymentmode = 'R' then
          concat('Credit Card (', c.Referenceno, ')')
         else
          '-'
       end as paymentmode,
       pn.name as panel,
       c.referenceno,
       bm.remarks,
       bm.enteredon,
       case
         when bm.type = 'I' then
          'Indoor'
         when bm.type = 'O' then
          'Outdoor'
         else
          '-'
       end as patientType,
       ifnull(c.discount, 0) discount,
       ifnull(c.totalamount, 0) totalamount,
       (Select totalamount - sum(paidamount) - sum(discount)
          from dc_tcashcollection c1
         where c1.labid = c.labid and c1.enteredon<=rp.enteredon
         group by c1.labid) as balance
  FROM dc_tcashcollection c
  left outer join dc_tpatient p on c.prid = p.prid
  left outer join dc_Tpatient_bookingm bm on bm.bookingid = c.bookingid
  left outer join dc_tp_organization og on c.clientid = og.orgid
  join dc_tcashreport rp on c.reportno = rp.reportno
  left outer join dc_tpanel pn on pn.panelid = c.panelid where rp.reportno='" + _reportno + "' AND date_format(c.enteredon,'%d/%m/%Y') =date_format(bm.enteredon,'%d/%m/%Y') AND pn.panelid IS NULL order by c.labid, p.prno";
            //objdbhims.Query = "SELECT  p.prno, c.prid,c.labid,c.receiveno,ifnull(c.paidamount,0) paidamount,concat(ifnull(p.title,''),' ',p.name) as patientname,date_format(c.enteredon,'%d/%m/%Y %r') as receiveon,date_format(rp.enteredon,'%d/%m/%Y %r') as generatedon,og.name as orgname,og.phoneno,c.reportno,case when c.paymentmode='C' then 'Cash' when c.paymentmode='A' then concat('On Account (',pn.Name,')') when c.paymentmode='D' then concat('Debit Card (',c.Referenceno,')') when c.paymentmode='R' then  concat('Credit Card (',c.Referenceno,')')  else '-' end as paymentmode, pn.name as panel,c.referenceno,bm.remarks ,bm.enteredon,case when bm.type='I' then 'Indoor' when bm.type='O' then 'Outdoor' else '-' end as patientType,ifnull(c.discount,0) discount,ifnull(c.totalamount,0) totalamount FROM dc_tcashcollection c left outer join dc_tpatient p on c.prid = p.prid left outer join dc_Tpatient_bookingm bm on bm.bookingid=c.bookingid left outer join dc_tp_organization og on c.clientid=og.orgid join dc_tcashreport rp on c.reportno=rp.reportno left outer join  dc_tpanel pn on pn.panelid=c.panelid where rp.reportno='" + _reportno + "' AND date_format(c.enteredon,'%d/%m/%Y') =date_format(bm.enteredon,'%d/%m/%Y') AND pn.panelid IS NULL order by p.prno,c.labid";//,ifnull((select sum(paidamount) from dc_tcashcollection where panelid IS NULL AND reportno ='" + _reportno + "'),0) as totalcash

                break;
            case 5:
                //objdbhims.Query = "SELECT  p.prno, c.prid,c.labid,c.receiveno,ifnull(c.paidamount,0) paidamount,concat(ifnull(p.title,''),' ',p.name) as patientname,date_format(c.enteredon,'%d/%m/%Y %r') as receiveon,date_format(rp.enteredon,'%d/%m/%Y %r') as generatedon,og.name as orgname,og.phoneno,c.reportno,case when c.paymentmode='C' then 'Cash' when c.paymentmode='A' then concat('On Account (',pn.Name,')') when c.paymentmode='D' then concat('Debit Card (',c.Referenceno,')') when c.paymentmode='R' then  concat('Credit Card (',c.Referenceno,')')  else '-' end as paymentmode, pn.name as panel,pn.panelid,pn.cashpanel,c.referenceno,bm.remarks ,bm.enteredon,case when bm.type='I' then 'Indoor' when bm.type='O' then 'Outdoor' else '-' end as patientType,ifnull(c.discount,0) discount,ifnull(c.totalamount,0) totalamount FROM dc_tcashcollection c left outer join dc_tpatient p on c.prid = p.prid left outer join dc_Tpatient_bookingm bm on bm.bookingid=c.bookingid left outer join dc_tp_organization og on c.clientid=og.orgid join dc_tcashreport rp on c.reportno=rp.reportno left outer join  dc_tpanel pn on pn.panelid=c.panelid where rp.reportno='" + _reportno + "' AND date_format(c.enteredon,'%d/%m/%Y') =date_format(bm.enteredon,'%d/%m/%Y') and date_format(c.enteredon,'%d/%m/%Y')=date_format(rp.enteredon,'%d/%m/%Y') AND pn.panelid IS NOT NULL order by  c.paymentmode,c.receiveno,c.labid,p.prno";//ifnull((select sum(paidamount) from dc_tcashcollection where panelid IS NOT NULL AND reportno ='" + _reportno + "'),0) as totalcash,
                objdbhims.Query = @"SELECT p.prno,
       c.prid,
       c.labid,
       c.receiveno,
       ifnull(c.paidamount, 0) paidamount,
       concat(ifnull(p.title, ''), ' ', p.name) as patientname,
       date_format(c.enteredon, '%d/%m/%Y %r') as receiveon,
       date_format(rp.enteredon, '%d/%m/%Y %r') as generatedon,
       og.name as orgname,
       og.phoneno,
       c.reportno,
       case
         when c.paymentmode = 'C' then
          'Cash'
         when c.paymentmode = 'A' then
          concat('On Account (', pn.Name, ')')
         when c.paymentmode = 'D' then
          concat('Debit Card (', c.Referenceno, ')')
         when c.paymentmode = 'R' then
          concat('Credit Card (', c.Referenceno, ')')
         else
          '-'
       end as paymentmode,
       pn.name as panel,
       pn.panelid,
       pn.cashpanel,
       c.referenceno,
       bm.remarks,
       bm.enteredon,
       case
         when bm.type = 'I' then
          'Indoor'
         when bm.type = 'O' then
          'Outdoor'
         else
          '-'
       end as patientType,
       ifnull(c.discount, 0) discount,
       ifnull(c.totalamount, 0) totalamount,
        (Select totalamount - sum(paidamount) - sum(discount)
          from dc_tcashcollection c1
         where c1.labid = c.labid and c1.enteredon<=rp.enteredon
         group by c1.labid) as balance
  FROM dc_tcashcollection c
  left outer join dc_tpatient p on c.prid = p.prid
  left outer join dc_Tpatient_bookingm bm on bm.bookingid = c.bookingid
  left outer join dc_tp_organization og on c.clientid = og.orgid
  join dc_tcashreport rp on c.reportno = rp.reportno
  left outer join dc_tpanel pn on pn.panelid = c.panelid
 where rp.reportno = '" + _reportno +@"'
   AND date_format(c.enteredon, '%d/%m/%Y') =
       date_format(bm.enteredon, '%d/%m/%Y')

   AND pn.panelid IS NOT NULL
 order by c.paymentmode, c.receiveno, c.labid, p.prno";
                break;
                // old query
               // "SELECT p.prno,c.prid,c.labid,c.refundno,sum(c.paidamount) as paidamount, concat(ifnull(p.title,''),' ',p.name) as patientname,date_format(c.enteredon,'%d/%m/%Y %r') as refundon,ifnull((select sum(paidamount) from dc_tcashrefund where refundtype<>'D' and reportno =c.reportno),0) as totalrefund, case when c.refundtype='C' then 'Cancel' when c.refundtype='D' then 'Discount' when c.refundtype='K' then 'BCL Staff' when c.refundtype='R' then 'Poor Patient' when c.refundtype='P' then 'Panel Patient' when c.refundtype='W' then 'Wrong Entry' else '-' end as refundtype,r.reportno,SUM(c.totalamount) as totalamount FROM dc_tcashrefund c left outer join dc_tpatient p on c.prid = p.prid join dc_tcashreport r on c.reportno=r.reportno where  c.refundtype<>'D' AND r.reportno='" + _reportno + "' group by c.refundno";
            case 6:
                objdbhims.Query = "SELECT p.prno,c.prid,c.labid,c.refundno,sum(c.paidamount) as paidamount, concat(ifnull(p.title,''),' ',p.name) as patientname,date_format(c.enteredon,'%d/%m/%Y %r') as refundon,ifnull((select sum(paidamount) from dc_tcashrefund where refundtype<>'D' and reportno =c.reportno),0) as totalrefund, case when c.refundtype='C' then 'Cancel' when c.refundtype='D' then 'Discount' when c.refundtype='K' then 'BCL Staff' when c.refundtype='R' then 'Poor Patient' when c.refundtype='P' then 'Panel Patient' when c.refundtype='W' then 'Wrong Entry' else '-' end as refundtype,r.reportno,SUM(c.totalamount) as totalamount FROM dc_tcashrefund c left outer join dc_tpatient p on c.prid = p.prid join dc_tcashreport r on c.reportno=r.reportno where r.reportno='" + _reportno + "' group by c.refundno";
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
                                    else pro.name  end as status, case when pro.Name='Refund/Discount' then ref.RefundNo else '-' end as RefundNo,t.Test_Name,t.charges as Test_Charges,pd.labid,date_format(pm.enteredon,'%d/%m/%Y') as StatusDate,p.BranchID,pm.balance,p.email,pm.referenceno,panel.cashpanel from dc_tpatient p left outer join dc_tpatient_bookingm pm on pm.prid = p.prid  left outer join dc_tp_branch b on b.branchid = pm.branchid left outer join dc_tpatient_bookingd pd on pd.bookingid = pm.bookingid left outer join dc_tp_tprocess pro on pro.processid = pd.processid left outer join  dc_tp_test t on t.testid=pd.testid left outer join dc_tpanel panel on panel.panelid  = pm.panelid left outer join dc_tcashrefund ref on ref.bookingid=pm.bookingid  and ref.RefundType!='D' 
where 1=1 ";
             
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
                if (!this.ProcessID.Equals(Default) && !this.ProcessID.Equals(""))
                {
                    objdbhims.Query += " and pd.processID in(" + StrProcessID + ") ";
                }
                objdbhims.Query += "  order by pm.labid desc, date_format(pm.enteredon,'%Y/%m/%d') desc ";
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
               @"SELECT dt2.prno patientPR,dt2.name PatientName,dt2.cellno PatientCellNo,dt.labid,dt.testid,dtt2.Test_Name,REPLACE(GROUP_CONCAT(dtt.name,' - (',CONCAT(dtp.FName,' ',dtp.MName,' ',dtp.LName),'-',date_format(dt.Enteredon,'%d/%m/%Y %r'),')'  ORDER BY dt.enteredon SEPARATOR ',') , ',' , '<br />') EnteredBy
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
                objdbhims.Query = @"SELECT pm.type,pm.adm_ref , payment_mode,panel.name as Panel,ifnull(p.cellno,p.hphone) as cellno, pm.totalamount,pm.paidamount,t.testid,pm.Bookingid,pd.Bookingdid,t.TestType,SubdepartmentId,ifnull(DestinationBranchId,'-') as origin,pm.branchid, pd.ProcessID,p.prid ,b.name as Branches,p.name as Patient_Name,coalesce(panel.panelid,0) as panelid,date_format(p.dob,'%Y/%m/%d') as dob,case when DATEDIFF(CURRENT_DATE,p.dob) > 365 then      concat(Floor(DATEDIFF(CURRENT_DATE,p.dob)/365),'(Years)')  else    case when DATEDIFF(CURRENT_DATE,p.dob) > 30 then      concat(Floor(DATEDIFF(CURRENT_DATE,p.dob)/30),' (M)')    else      concat(DATEDIFF(CURRENT_DATE,p.dob),'(d)')    end  end  AS age,p.prno,case when pro.name  = 'Archiving' then 'ARV'  when pro.name  = 'Specimen Collection' then 'SCOL'
                                    when pro.name  = 'Worklist' then 'WLIST'
                                    when pro.name  = 'Result Entry' then 'RENT'
                                    when pro.name  = 'Result Verification' then 'VERF'
                                    when pro.name  = 'Result Dispatch' then 'RDY'
                                    when pro.name  = 'Refund/Discount' then 'REF'
                                    else pro.name  end as status,t.Test_Name,t.charges as Test_Charges,pd.labid,date_format(pm.enteredon,'%d/%m/%Y') as StatusDate,p.BranchID,pm.balance,p.email,pm.referenceno,coalesce(panel.cashpanel,'N') as cashpanel from dc_tpatient p left outer join dc_tpatient_bookingm pm on pm.prid = p.prid  left outer join dc_tp_branch b on b.branchid = pm.branchid left outer join dc_tpatient_bookingd pd on pd.bookingid = pm.bookingid left outer join dc_tp_tprocess pro on pro.processid = pd.processid left outer join  dc_tp_test t on t.testid=pd.testid left outer join dc_tpanel panel on panel.panelid  = pm.panelid where  pro.name IN ('Result Dispatch')";

              if (!this.FromDate.Equals(Default) && !this.FromDate.Equals("") && !this.ToDate.Equals(Default) && !this.ToDate.Equals(""))
                {
                    //objdbhims.Query += " and date_format(p.enteredon,'%Y/%m/%d')   >= '" + FromDate + "' and date_format(p.enteredon,'%Y/%m/%d') <=  '" + ToDate + "'";
                    objdbhims.Query += " and date_format(pm.enteredon,'%Y/%m/%d')   between '" + FromDate + "' and  '" + ToDate + "' ";

                }
                if (!StrProcessID.Equals(Default) && !StrProcessID.Equals(""))
                {
                    objdbhims.Query += " and pro.ProcessId=" + StrProcessID;
                }
                if (!this.type.Equals(Default) && !this.type.Equals(""))
                {
                    objdbhims.Query += " And pm.type = '" + this.type + "'";
                }
				objdbhims.Query += " order by pm.labid desc, date_format(pm.enteredon,'%Y/%m/%d') desc ";
                break;
            case 26:
                objdbhims.Query = @"SELECT  p.prno, c.prid,c.labid,c.receiveno,c.paidamount,
                concat(ifnull(p.title,''),' ',p.name) as patientname,
                date_format(c.enteredon,'%d/%m/%Y %r') as receiveon,date_format(rp.enteredon,'%d/%m/%Y %r') as generatedon,
                og.name as orgname,og.phoneno,
                ifnull((select sum(paidamount) from dc_tcashcollection where reportno =rp.reportno),0)
                as totalcash,c.reportno,case when c.paymentmode='C' then 'Cash' when c.paymentmode='A' then 'On Account'
                when c.paymentmode='D' then 'Debit Card' when c.paymentmode='R' then 'Credit Card'  else '-' end as paymentmode,
                pn.name as panel,c.referenceno,bm.remarks ,bm.enteredon,bm.type
                FROM dc_tcashcollection c left outer join dc_tpatient p on c.prid = p.prid left outer join dc_Tpatient_bookingm bm
                on bm.bookingid=c.bookingid
                left outer join dc_tp_organization og on c.clientid=og.orgid
                 join dc_tcashreport rp on c.reportno=rp.reportno left outer join  dc_tpanel pn on pn.panelid=c.panelid
                where rp.reportno = '" + _reportno+@"' AND date_format(c.enteredon,'%d/%m/%Y') <> date_format(bm.enteredon,'%d/%m/%Y')
                order by c.labid,p.prno";
                break;
            case 27:
                objdbhims.Query = "Select * from dc_tcashcheckin where cashierid='" + _cashierid + "' and lower(cashstatus)='online'";
                break;
            case 28:
                objdbhims.Query = @"select c.branchid,
                                                               c.cashierid,
                                                               c.cashiername,

                                                               c.cashOpening_Amount,
                                                               (select ifnull(sum(paidamount),'0')
                                                                  from dc_tcashcollection c1
                                                                 where c1.enteredby = c.cashierid
                                                                   and c1.reportno=r.reportno
                                                                   and c1.paymentmode = 'C'
                                                                  ) as cashClosing_Amount,
                                                               c.reportno,
                                                              date_format(r.enteredon,'%d/%m/%Y') as enteredon,
                                                               ifnull((select sum(paidamount)
                                                                        from dc_tcashcollection
                                                                       where enteredby = c.cashierid
                                                                         and reportno=r.reportno
                                                                     
                                                                         and paymentmode = 'R'),
                                                                      '0') as CreditCardAmt,
                                                               ifnull((select sum(paidamount)
                                                                        from dc_tcashcollection
                                                                       where enteredby = c.cashierid
                                                                         and reportno=r.reportno
                                                                        
                                                                         and paymentmode = 'D'),
                                                                      '0') as DebitCardAmt,
                                                               ifnull((select sum(paidamount)
                                                                        from dc_tcashrefund
                                                                       where enteredby = c.cashierid
                                                                         and reportno=r.reportno
                                                                        
                                                                         and refundtype <> 'D'),
                                                                      '0') as Refund,
                                                               ifnull((select sum(totalamount)
                                                                        from dc_tcashcollection
                                                                       where enteredby = c.cashierid
                                                                        and reportno=r.reportno
                                                                         
                                                                         and paymentmode = 'A'),
                                                                      '0') as onaccount,
                                                               ifnull((Select sum(totalamount) - sum(paidamount) - sum(discount)
                                                                        from dc_tcashcollection c1
                                                                       where c1.enteredby = c.cashierid and
                                                                       c1.paymentmode = 'C' and c1.reportno=r.reportno
                                                                             and c1.enteredon <= str_to_date('" + FromDate + @"', '%d/%m/%Y')
                                                                             and c1.enteredon >= str_to_date('" + ToDate + @"', '%d/%m/%Y')),

                                                                      '0') as balance,
       
                                                               b.name
                                                          from dc_tcashcheckin c, dc_tp_branch as b, dc_tcashreport r
                                                         WHERE c.branchid = b.BranchID
                                                         and r.reportno=c.reportno
                                                           and b.branchid = " + _branchid +@"
                                                           and r.enteredon between
                                                               str_to_date('" + FromDate + @"', '%d/%m/%Y') and
                                                               str_to_date('" + ToDate + @"', '%d/%m/%Y')";
                break;
                        case 29:
                objdbhims.Query = @"select * from dc_tcashcheckin where str_to_date(enteredoff,'%d/%m/%Y %r') between str_to_date('"+FromDate+"','%d/%m/%Y %r') and str_to_date('"+ToDate+"','%d/%m/%Y %r') and cashierid="+_cashierid;
                break;
                        case 30: objdbhims.Query = @"
                                                            select p.branchid,
                                                                   p.personid as cashierid,
                                                                   concat(p.salutation,' ',p.FName,' ',p.MName,' ',p.LName) as cashiername,

                                                                    '' as cashOpening_Amount,
                                                                   (select ifnull(sum(paidamount), '0')
                                                                      from dc_tcashcollection c1
                                                                     where c1.enteredby = p.personid
                                                                       and c1.paymentmode = 'C'
                                                                       and c1.enteredon between str_to_date('" + FromDate + @"', '%d/%m/%Y') and
                                                                           str_to_date('" + ToDate + @"', '%d/%m/%Y')) as cashClosing_Amount,
                                                                   '' as reportno,
                                                                   date_format(c.enteredon, '%d/%m/%Y') as enteredon,
                                                                   ifnull((select sum(paidamount)
                                                                            from dc_tcashcollection
                                                                           where enteredby = p.personid
                                                                             and enteredon between
                                                                                 str_to_date('" + FromDate + @"', '%d/%m/%Y') and
                                                                                 str_to_date('" + ToDate + @"', '%d/%m/%Y')
                                                                             and paymentmode = 'R'),
                                                                          '0') as CreditCardAmt,
                                                                   ifnull((select sum(paidamount)
                                                                            from dc_tcashcollection
                                                                           where enteredby = p.personid
                                                                             and enteredon between
                                                                                 str_to_date('" + FromDate + @"', '%d/%m/%Y') and
                                                                                 str_to_date('" + ToDate + @"', '%d/%m/%Y')
                                                                             and paymentmode = 'D'),
                                                                          '0') as DebitCardAmt,
                                                                   ifnull((select sum(paidamount)
                                                                            from dc_tcashrefund
                                                                           where enteredby = p.personid
                    
                                                                             and enteredon between
                                                                                 str_to_date('" + FromDate + @"', '%d/%m/%Y') and
                                                                                 str_to_date('" + ToDate + @"', '%d/%m/%Y')
                                                                             and refundtype <> 'D'),
                                                                          '0') as Refund,
                                                                   ifnull((select sum(totalamount)
                                                                            from dc_tcashcollection
                                                                           where enteredby = p.personid
                                                                             and enteredon between
                                                                                 str_to_date('" + FromDate + @"', '%d/%m/%Y') and
                                                                                 str_to_date('" + ToDate + @"', '%d/%m/%Y')
                                                                             and paymentmode = 'A'),
                                                                          '0') as onaccount,
                                                                   ifnull((Select sum(totalamount) - sum(paidamount) - sum(discount)
                                                                            from dc_tcashcollection c1
                                                                           where c1.enteredby = p.personid
                                                                             and c1.paymentmode = 'C'
                                                                             and c1.enteredon <= str_to_date('" + FromDate + @"', '%d/%m/%Y')
                                                                             and c1.enteredon >= str_to_date('" + ToDate + @"', '%d/%m/%Y')),
                                                                          '0') as balance,
       
                                                                   b.name
                                                              from dc_tp_personnel p, dc_tp_branch as b, dc_tcashcollection c,dc_tcashcheckin ch
                                                             WHERE p.branchid = b.BranchID
                                                                and c.enteredby=ch.cashierid
                                                               and b.branchid = " + _branchid + @"
                                                               and p.personid=c.enteredby
                                                                and ch.cashstatus<>'Offline' and c.reportno is null
                                                               and c.enteredon between str_to_date('" + FromDate + @"', '%d/%m/%Y') and
                                                                   str_to_date('" + ToDate + @"', '%d/%m/%Y')
                                                                   group by p.personid";
                break;
            case 31:
                #region old query
//                objdbhims.Query = @"select c.branchid,
//       c.cashierid,
//       concat(p.FName, ' ', p.MName, ' ', p.LName) as cashiername,
//       
//       c.cashOpening_Amount,
//       (select ifnull(sum(m.totalamount), '0')
//          from dc_tpatient_bookingm m
//         where m.enteredby = c.cashierid
//              
//           and m.payment_mode = 'C'
//              
//           and m.panelid is null
//           and m.enteredon between str_to_date(''"+FromDate+@"'', '%d/%m/%Y') and
//               str_to_date('"+ToDate+@"', '%d/%m/%Y')) as totalamountcash,
//       (select ifnull(sum(totalamount), '0')
//          from dc_tpatient_bookingm c1
//         where c1.enteredby = c.cashierid
//           and c1.payment_mode = 'P'
//              
//           and c1.panelid is not null
//           and c1.enteredon between str_to_date(''"+FromDate+@"'', '%d/%m/%Y') and
//               str_to_date('"+ToDate+@"', '%d/%m/%Y')) as totalamountcashpanel,
//       (select ifnull(sum(paidamount), '0')
//          from dc_tcashcollection c1
//         where c1.enteredby = c.cashierid
//           and c1.paymentmode = 'C'
//           and c1.reportno = r.reportno
//           and c1.panelid is null
//           and c1.enteredon between str_to_date(''"+FromDate+@"'', '%d/%m/%Y') and
//               str_to_date('"+ToDate+@"', '%d/%m/%Y')) as cashClosing_Amountcash,
//       (select ifnull(sum(paidamount), '0')
//          from dc_tcashcollection c1
//         where c1.enteredby = c.cashierid
//           and c1.paymentmode = 'C'
//           and c1.reportno = r.reportno
//           and c1.panelid is not null
//           and c1.enteredon between str_to_date(''"+FromDate+@"'', '%d/%m/%Y') and
//               str_to_date('"+ToDate+@"', '%d/%m/%Y')) as cashClosing_Amountcashpanel,
//       c.reportno,
//       date_format(r.enteredon, '%d/%m/%Y') as enteredon,
//       ifnull((select sum(paidamount)
//                from dc_tcashcollection
//               where enteredby = c.cashierid
//                 and reportno = r.reportno
//                 and enteredon between
//                     str_to_date(''"+FromDate+@"'', '%d/%m/%Y') and
//                     str_to_date('"+ToDate+@"', '%d/%m/%Y')
//                 and paymentmode = 'R'),
//              '0') as CreditCardAmt,
//       ifnull((select sum(paidamount)
//                from dc_tcashcollection
//               where enteredby = c.cashierid
//                 and reportno = r.reportno
//                 and enteredon between
//                     str_to_date(''"+FromDate+@"'', '%d/%m/%Y') and
//                     str_to_date('"+ToDate+@"', '%d/%m/%Y')
//                 and paymentmode = 'D'),
//              '0') as DebitCardAmt,
//       ifnull((select sum(re.paidamount)
//                from dc_tcashrefund re, dc_tpatient_bookingm m
//               where re.enteredby = c.cashierid
//                 and m.bookingid = re.bookingid
//                 and re.reportno = r.reportno
//                 and m.panelid is null
//                 and re.enteredon between
//                     str_to_date(''"+FromDate+@"'', '%d/%m/%Y') and
//                     str_to_date('"+ToDate+@"', '%d/%m/%Y')
//                 and refundtype <> 'D'),
//              '0') as refundcash,
//       
//       ifnull((select sum(re.paidamount)
//                from dc_tcashrefund re, dc_tpatient_bookingm m
//               where re.enteredby = c.cashierid
//                 and m.bookingid = re.bookingid
//                 and re.reportno = r.reportno
//                 and m.panelid is not null
//                 and re.enteredon between
//                     str_to_date(''"+FromDate+@"'', '%d/%m/%Y') and
//                     str_to_date('"+ToDate1+@"', '%d/%m/%Y')
//                 and refundtype <> 'D'),
//              '0') as refundcashpanel,
//                ifnull((select sum(re.paidamount)
//                from dc_tcashrefund re, dc_tpatient_bookingm m
//               where re.enteredby = c.cashierid
//                 and m.bookingid = re.bookingid
//                 and re.reportno = r.reportno
//                 and m.panelid is not null
//                 and re.enteredon between
//                     str_to_date(''"+FromDate+@"'', '%d/%m/%Y') and
//                     str_to_date('"+ToDate+@"', '%d/%m/%Y')
//                 and refundtype ='D'),
//              '0') as discountcashpanel,
//               ifnull((select sum(re.paidamount)
//                from dc_tcashrefund re, dc_tpatient_bookingm m
//               where re.enteredby = c.cashierid
//                 and m.bookingid = re.bookingid
//                 and re.reportno = r.reportno
//                 and m.panelid is not null
//                 and re.enteredon between
//                     str_to_date(''"+FromDate+@"'', '%d/%m/%Y') and
//                     str_to_date('"+ToDate+@"', '%d/%m/%Y')
//                 and refundtype <> 'D'),
//              '0') as refundcashpanel,
//                ifnull((select sum(re.paidamount)
//                from dc_tcashrefund re, dc_tpatient_bookingm m
//               where re.enteredby = c.cashierid
//                 and m.bookingid = re.bookingid
//                 and re.reportno = r.reportno
//                 and m.panelid is null
//                 and re.enteredon between
//                     str_to_date(''"+FromDate+@"'', '%d/%m/%Y') and
//                     str_to_date('"+ToDate+@"', '%d/%m/%Y')
//                 and refundtype ='D'),
//              '0') as discountcash,
//       ifnull((select sum(totalamount)
//                from dc_tcashcollection
//               where enteredby = c.cashierid
//                 and reportno = r.reportno
//                 and panelid is not null
//                 and enteredon between
//                     str_to_date(''"+FromDate+@"'', '%d/%m/%Y') and
//                     str_to_date('"+ToDate+@"', '%d/%m/%Y')
//                 and paymentmode = 'A'),
//              '0') as Creditpanel,
//       ifnull((Select sum(totalamount) - sum(paidamount) - sum(discount)
//                from dc_tcashcollection c1
//               where c1.enteredby = c.cashierid
//                 and c1.paymentmode = 'C'
//                 and c1.reportno = r.reportno
//                 and c1.panelid is not null
//                 and c1.enteredon between
//                     str_to_date(''"+FromDate+@"'', '%d/%m/%Y') and
//                     str_to_date('"+ToDate+@"', '%d/%m/%Y')),
//              '0') as balancecashpanel,
//       ifnull((Select sum(totalamount) - sum(paidamount) - sum(discount)
//                from dc_tcashcollection c1
//               where c1.enteredby = c.cashierid
//                 and c1.paymentmode = 'C'
//                 and c1.reportno = r.reportno
//                 and c1.panelid is null
//                 and c1.enteredon between
//                     str_to_date(''"+FromDate+@"'', '%d/%m/%Y') and
//                     str_to_date('"+ToDate+@"', '%d/%m/%Y')),
//              '0') as balancecash,
//       
//       b.name as branchname,
//       ' ' as page,
//       
//       
//       
//       '' as collection,
//       c.cashClosing_Amount as closingamount,
//       '' as difference,
//       '' as receivingamount
//      
//  from dc_tcashcheckin c,
//       dc_tp_branch    as b,
//       dc_tcashreport  r,
//       dc_tp_personnel p
// WHERE c.branchid = b.BranchID
//   and r.reportno = c.reportno
//   and p.personid = c.cashierid
//   and r.enteredon between str_to_date(''"+FromDate+@"'', '%d/%m/%Y') and
//       str_to_date('"+ToDate+@"', '%d/%m/%Y')
// group by b.branchid, r.reportno
//";
#endregion
                objdbhims.Query = @"select c.branchid,
       c.cashierid,
       concat(p.FName, ' ', p.MName, ' ',p.LName) as cashiername,
       
       c.cashOpening_Amount,
       (select ifnull(sum(m.totalamount), '0')
          from dc_tpatient_bookingm m,dc_tcashcollection c1
         where m.enteredby = c.cashierid
            and c1.bookingid=m.bookingid 
           and m.payment_mode = 'C'
           and date_format(c1.enteredon,'%d/%m/%Y')=date_format(m.enteredon,'%d/%m/%Y')
           and c1.reportno=r.reportno   
           and m.panelid is null
           ) as totalamountcash,
       (select ifnull(sum(c1.totalamount), '0')
          from dc_tcashcollection c1 ,dc_tpatient_bookingm m
         where c1.enteredby = c.cashierid
           and c1.bookingid=m.bookingid
           and c1.paymentmode = 'C'
           and c1.reportno=r.reportno
           and date_format(m.enteredon,'%d/%m/%Y')=date_format(c1.enteredon,'%d/%m/%Y')   
           and c1.panelid is not null
           ) as totalamountcashpanel,
       (select ifnull(sum(c1.paidamount), '0')
        
          from dc_tcashcollection c1
         inner join dc_tpatient_bookingm m on c1.bookingid = m.bookingid
        
         where date_format(m.enteredon, '%d/%m/%y') <>
               date_format(c1.enteredon, '%d/%m/%y')
           and c1.enteredby = c.cashierid
           and c1.reportno = r.reportno) as previouscash,
       (select ifnull(sum(c1.paidamount), '0')
          from dc_tcashcollection c1,dc_tpatient_bookingm m
         where c1.enteredby = c.cashierid
           and c1.bookingid=m.bookingid
           
           and date_format(m.enteredon,'%d/%m/%Y')=date_format(c1.enteredon,'%d/%m/%Y')  
           and c1.paymentmode = 'C'
           and c1.reportno = r.reportno
           and c1.panelid is null
           ) as cashClosing_Amountcash,
       (select ifnull(sum(c1.paidamount), '0')
          from dc_tcashcollection c1,dc_tpatient_bookingm m
         where c1.enteredby = c.cashierid
           and c1.bookingid=m.bookingid
          
           and date_format(m.enteredon,'%d/%m/%Y')=date_format(c1.enteredon,'%d/%m/%Y')  
           and c1.paymentmode = 'C'
           and c1.reportno = r.reportno
           and c1.panelid is not null
           ) as cashClosing_Amountcashpanel,
       c.reportno,
       date_format(r.enteredon, '%d/%m/%Y') as enteredon,
       
       ifnull((select sum(re.paidamount)
                from dc_tcashrefund re, dc_tpatient_bookingm m
               where re.enteredby = c.cashierid
                 and m.bookingid = re.bookingid
                 and re.reportno = r.reportno
                 and m.panelid is null
                
                 and refundtype <> 'D'),
              '0') as refundcash,
       
       ifnull((select sum(re.paidamount)
                from dc_tcashrefund re, dc_tpatient_bookingm m
               where re.enteredby = c.cashierid
                 and m.bookingid = re.bookingid
                 and re.reportno = r.reportno
                 and m.panelid is not null
                 
                 and refundtype <> 'D'),
              '0') as refundcashpanel,
       ifnull((select sum(re.paidamount)
                from dc_tcashrefund re, dc_tpatient_bookingm m
               where re.enteredby = c.cashierid
                 and m.bookingid = re.bookingid
                 and re.reportno = r.reportno
                 and m.panelid is not null
                
                 and refundtype = 'D'),
              '0') as discountcashpanel,
       ifnull((select sum(re.paidamount)
                from dc_tcashrefund re, dc_tpatient_bookingm m
               where re.enteredby = c.cashierid
                 and m.bookingid = re.bookingid
                 and re.reportno = r.reportno
                 and m.panelid is not null
                 
                 and refundtype <> 'D'),
              '0') as refundcashpanel,
       ifnull((select sum(re.paidamount)
                from dc_tcashrefund re, dc_tpatient_bookingm m
               where re.enteredby = c.cashierid
                 and m.bookingid = re.bookingid
                 and re.reportno = r.reportno
                 and m.panelid is null
                 
                 and refundtype = 'D'),
              '0') as discountcash,
       ifnull((select sum(totalamount)
                from dc_tcashcollection
               where enteredby = c.cashierid
                 and reportno = r.reportno
                 and panelid is not null
                 
                 and paymentmode = 'A'),
              '0') as Creditpanel,
   (select ifnull(sum(c1.paidamount), '0')
          from dc_tcashcollection c1,dc_tpatient_bookingm m
         where c1.enteredby = c.cashierid
           and c1.bookingid=m.bookingid


           and c1.paymentmode = 'C'
           and c1.reportno = r.reportno

           ) as netcash,
   
       
       b.name as branchname,
       c.cashClosing_Amount as closingamount,
       '' as difference,
       '' as netamount

  from dc_tcashcheckin c,
       dc_tp_branch    as b,
       dc_tcashreport  r,
       dc_tp_personnel p
 WHERE c.branchid = b.BranchID
   and r.reportno = c.reportno
   and p.personid = c.cashierid
   and r.enteredon between str_to_date('" + FromDate + @"', '%d/%m/%Y') and
       str_to_date('" + ToDate + @"', '%d/%m/%Y')
 group by b.branchid, r.reportno
union
select c.branchid,
       cc.enteredby as cashierid,
       concat(p.FName, ' ', p.MName, ' ', p.LName) as cashiername,
       
       c.cashOpening_Amount,
       (select ifnull(sum(c1.totalamount), '0')
          from dc_tpatient_bookingm m,dc_tcashcollection c1
         where m.enteredby = c.cashierid
           and c1.bookingid=m.bookingid
           and m.payment_mode = 'C'
            and date_format(c1.enteredon,'%d/%m/%Y')=date_format(m.enteredon,'%d/%m/%Y')  
           and m.panelid is null
           and c1.reportno is null
           and m.enteredon between str_to_date('" + FromDate + @"', '%d/%m/%Y') and
               str_to_date('" + ToDate + @"', '%d/%m/%Y')) as totalamountcash,
       (select ifnull(sum(c1.totalamount), '0')
          from dc_tcashcollection c1,dc_tpatient_bookingm m
         where c1.enteredby = c.cashierid
           and m.bookingid=c1.bookingid
           and c1.paymentmode = 'C'
           and date_format(m.enteredon,'%d/%m/%Y')=date_format(c1.enteredon,'%d/%m/%Y')  
           and c1.panelid is not null
           and reportno is null
           and c1.enteredon between str_to_date('" + FromDate + @"', '%d/%m/%Y') and
               str_to_date('" + ToDate + @"', '%d/%m/%Y')) as totalamountcashpanel,
       
       (select ifnull(sum(c1.paidamount), '0')
        
          from dc_tcashcollection c1
         inner join dc_tpatient_bookingm m on c1.bookingid = m.bookingid
        
         where c1.enteredon between str_to_Date('" + FromDate + @"', '%d/%m/%Y') and
               str_to_date('" + ToDate + @"', '%d/%m/%Y')
           and date_format(m.enteredon, '%d/%m/%y') <>
               date_format(c1.enteredon, '%d/%m/%y')
           and c1.enteredby = c.cashierid
           and c1.reportno is null) as previouscash,
       (select ifnull(sum(c1.paidamount), '0')
          from dc_tcashcollection c1,dc_tpatient_bookingm m
         where c1.enteredby = c.cashierid
           and c1.bookingid=m.bookingid
          
           and date_format(m.enteredon,'%d/%m/%Y')=date_format(c1.enteredon,'%d/%m/%Y')  
           and c1.paymentmode = 'C'
           and c1.reportno is null
           and c1.panelid is null
           and c1.enteredon between str_to_date('" + FromDate + @"', '%d/%m/%Y') and
               str_to_date('" + ToDate + @"', '%d/%m/%Y')) as cashClosing_Amountcash,
       (select ifnull(sum(c1.paidamount), '0')
          from dc_tcashcollection c1,dc_tpatient_bookingm m
         where c1.enteredby = c.cashierid
           and c1.bookingid=m.bookingid
         
           and date_format(m.enteredon,'%d/%m/%Y')=date_format(c1.enteredon,'%d/%m/%Y')  
           and c1.paymentmode = 'C'
           and c1.reportno is null
           and c1.panelid is not null
           and c1.enteredon between str_to_date('" + FromDate + @"', '%d/%m/%Y') and
               str_to_date('" + ToDate + @"', '%d/%m/%Y')) as cashClosing_Amountcashpanel,
       '' as reportno,
       date_format(cc.enteredon, '%d/%m/%Y') as enteredon,
       
       ifnull((select sum(re.paidamount)
                from dc_tcashrefund re, dc_tpatient_bookingm m
               where re.enteredby = c.cashierid
                 and m.bookingid = re.bookingid
                 and re.reportno is null
                 and m.panelid is null
                 and re.enteredon between
                     str_to_date('" + FromDate + @"', '%d/%m/%Y') and
                     str_to_date('" + ToDate + @"', '%d/%m/%Y')
                 and refundtype <> 'D'),
              '0') as refundcash,
       
       ifnull((select sum(re.paidamount)
                from dc_tcashrefund re, dc_tpatient_bookingm m
               where re.enteredby = c.cashierid
                 and m.bookingid = re.bookingid
                 and re.reportno is null
                 and m.panelid is not null
                 and re.enteredon between
                     str_to_date('" + FromDate + @"', '%d/%m/%Y') and
                     str_to_date('" + ToDate + @"', '%d/%m/%Y')
                 and refundtype <> 'D'),
              '0') as refundcashpanel,
       ifnull((select sum(re.paidamount)
                from dc_tcashrefund re, dc_tpatient_bookingm m
               where re.enteredby = c.cashierid
                 and m.bookingid = re.bookingid
                 and re.reportno is null
                 and m.panelid is not null
                 and re.enteredon between
                     str_to_date('" + FromDate + @"', '%d/%m/%Y') and
                     str_to_date('" + ToDate + @"', '%d/%m/%Y')
                 and refundtype = 'D'),
              '0') as discountcashpanel,
       ifnull((select sum(re.paidamount)
                from dc_tcashrefund re, dc_tpatient_bookingm m
               where re.enteredby = c.cashierid
                 and m.bookingid = re.bookingid
                 and re.reportno is null
                 and m.panelid is not null
                 and re.enteredon between
                     str_to_date('" + FromDate + @"', '%d/%m/%Y') and
                     str_to_date('" + ToDate + @"', '%d/%m/%Y')
                 and refundtype <> 'D'),
              '0') as refundcashpanel,
       ifnull((select sum(re.paidamount)
                from dc_tcashrefund re, dc_tpatient_bookingm m
               where re.enteredby = c.cashierid
                 and m.bookingid = re.bookingid
                 and re.reportno is null
                 and m.panelid is null
                 and re.enteredon between
                     str_to_date('" + FromDate + @"', '%d/%m/%Y') and
                     str_to_date('" + ToDate + @"', '%d/%m/%Y')
                 and refundtype = 'D'),
              '0') as discountcash,
       ifnull((select sum(totalamount)
                from dc_tcashcollection
               where enteredby = c.cashierid
                 and reportno is null
                 and panelid is not null
                 and enteredon between
                     str_to_date('" + FromDate + @"', '%d/%m/%Y') and
                     str_to_date('" + ToDate + @"', '%d/%m/%Y')
                 and paymentmode = 'A'),
              '0') as Creditpanel,
(select ifnull(sum(c1.paidamount), '0')
          from dc_tcashcollection c1,dc_tpatient_bookingm m
         where c1.enteredby = c.cashierid
           and c1.bookingid=m.bookingid


           and c1.paymentmode = 'C'
           and c1.reportno is null

           and c1.enteredon between str_to_date('" + FromDate + @"', '%d/%m/%Y') and
               str_to_date('" + ToDate + @"', '%d/%m/%Y')) as netcash,

     
       
       b.name as branchname,
       c.cashClosing_Amount as closingamount,
       '' as difference,
       '' as netamount

  from dc_tcashcollection as cc,
       dc_tcashcheckin    c,
       
       dc_tp_branch as b,
       
       dc_tp_personnel p
 WHERE c.branchid = b.BranchID
   and cc.enteredby = c.cashierid
   and c.reportno is null
   and cc.reportno is null
   and c.cashstatus = 'Online'
   and p.personid = c.cashierid
   and cc.enteredon between str_to_date('" + FromDate + @"', '%d/%m/%Y') and
       str_to_date('" + ToDate + @"', '%d/%m/%Y')
 group by b.branchid
";
                break;
            case 32:
                objdbhims.Query = @"SELECT c.reportno,c.cashChkin_id,c.cashierid,c.cashierName,c.cashOpening_Amount,c.cashClosing_Amount,c.cashStatus,c.enteredby,c.enteredon,c.enteredoff,c.branchid,b.Name FROM dc_tcashcheckin as c, dc_tp_branch as b, dc_tcashreport as r WHERE c.branchid=b.BranchID and c.reportno=r.reportno ";
                                   if(FromDate!=null && FromDate!="" && ToDate!=null && ToDate!="")
                                   {
                                       objdbhims.Query +=@"   and r.enteredon between str_to_date('" + FromDate + @"', '%d/%m/%Y') and
                                    str_to_date('" + ToDate + @"', '%d/%m/%Y')";
                                   }
                                   if(Reportno!=null && Reportno!="")
                                   {
                                       objdbhims.Query += @" and  c.reportno='"+Reportno+"'";
                                   }
                break;
            case 33:
                objdbhims.Query = @"select * from dc_tcashcheckin where cashierid="+ Personid +@" and
                                    cashChkin_id=(select max(cashChkin_id) from dc_tcashcheckin where cashierid="+ Personid +")";
                break;
            case 34:
                if (PatientName.Length > 2)
                {
                    objdbhims.Query = @"Select test_name from dc_tp_test where test_name like('%" + PatientName + "%') and Active='Y' order by test_name asc limit 10";
                }
                else
                {
                    objdbhims.Query = @"Select 'Please enter 3 or more characters'";
                }
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
            ary[6, 2] = "int";
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
        DataView dv_checkedin = GetAll(27);
        if (dv_checkedin.Count > 0)
        {
            this.StrErrorMessage = "One of your session is already open. Please close it first.";
            dv_checkedin.Dispose();
            return false;
        }
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
