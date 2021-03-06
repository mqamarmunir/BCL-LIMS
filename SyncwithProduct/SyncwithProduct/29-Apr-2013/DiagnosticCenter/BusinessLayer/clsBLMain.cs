using System;
using System.Collections.Generic;
using System.Text;
using DataLayer;
using System.Data;


namespace BusinessLayer
{
   public class clsBLMain
    {
       clsoperation objTrans = new clsoperation();
       clsdbhims objdbhims = new clsdbhims();

       #region "Variables"

       private const string Default = "~!@";
       private string StrError = Default;

       private string StrDepartmentID = Default;
       private string StrSubDepartentID = Default;
       private string StrGroupID = Default;
       private string StrTestID = Default;

       private string StrReportNo = Default;
       private string StrCashierID = Default;
       private string StrActive = Default;

       private string StrDate = Default;
       private string StrExternal = Default;
       private string StrPanelID = Default;
       private string StrBranchID = Default;

       private string StrFromDate = Default;
       private string StrTODate = Default;
       private string StrBookingID = Default;
       private string StrRefundNo = Default;
       private string StrReceiveNo = Default;

       private string StrPRNo = Default;
       private string StrLabID = Default;
       private string StrType = Default;

       #endregion

       #region "Properties"

       public string Erorr
       {
           get { return StrError; }
           set { StrError = value; }
       }
       public string DepartmentID
       {
           get { return StrDepartmentID; }
           set { StrDepartmentID = value; }
       }
       public string SubDepartmentID
       {
           get { return StrSubDepartentID; }
           set { StrSubDepartentID = value; }
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

       public string ReportNo
       {
           get { return StrReportNo; }
           set { StrReportNo = value; }
       }
       public string CashierID
       {
           get { return StrCashierID; }
           set { StrCashierID = value; }
       }
       public string Active
       {
           get { return StrActive; }
           set { StrActive = value; }
       }

       public string Date
       {
           get { return StrDate; }
           set { StrDate = value; }
       }
       public string External
       {
           get { return StrExternal; }
           set { StrExternal = value; }
       }
       public string PanelID
       {
           get { return StrPanelID; }
           set { StrPanelID = value; }
       }
       public string BranchID
       {
           get { return StrBranchID;}
           set { StrBranchID = value; }
       }

       public string FromDate
       {
           get { return StrFromDate; }
           set { StrFromDate = value; }
       }
       public string ToDate
       {
           get { return StrTODate; }
           set { StrTODate = value; }
       }
       public string BookingID
       {
           get { return StrBookingID; }
           set { StrBookingID = value; }
       }
       public string RefundNo
       {
           get { return StrRefundNo; }
           set { StrRefundNo = value; }
       }
       public string ReceiveNo
       {
           get { return StrReceiveNo; }
           set { StrReceiveNo = value; }
       }

       public string PRNO
       {
           get { return StrPRNo; }
           set { StrPRNo = value; }
       }
       public string LabID
       {
           get { return StrLabID; }
           set { StrLabID = value; }
       }
       public string Type
       {
           get { return StrType; }
           set { StrType = value; }
       }
       #endregion

       #region "Method"

       public DataView GetAll(int flag)
       {
           switch (flag)
           {
               case 1: // fill gv on report view
                   objdbhims.Query = "select t.testid,t.test_name,ifnull(t.acronym,'-') as acronym,case when ag.gender='A' then 'All' when ag.gender='M' then 'Male' when ag.gender='F' then 'Female' else '-' end as Age_gender2,ifnull(ag.minage,'-') as minage, ifnull(ag.maxage,'-') as maxage,concat('(',ag.gender,')',ifnull(ag.minage,'~'),'-',ifnull(ag.maxage,'~')) as age_gender,t.charges,ifnull(t.chargesurgent,0) as chargesurgent, su.name as subdepartment,ifnull(sp.specimen_name,'-') as specimen_name,ifnull(sc.container_name,'-') as container_name,t.active,g.name as groupname,t.external,ifnull(t.charityrate,0) as charityrate,case when met.maxtime > 1440 then concat(floor(met.maxtime/1440),' Day(s)') else concat(floor(met.maxtime/60),' Hour(s)') end as tat  from dc_tp_test t left outer join dc_tp_test_age ag on t.testid =ag.testid left outer join dc_tp_subdepartments su on t.subdepartmentid =su.subdepartmentid left outer join dc_tp_stype sp on t.specimenid = sp.specimenid left outer join dc_tp_scontainer sc on t.scontainerid = sc.scontainerid left outer join dc_tp_groupm g on t.groupid=g.groupid left outer join dc_tp_method met on met.methodid=t.d_methodid where su.active='Y' ";
                   if (!StrDepartmentID.Equals(Default))
                       objdbhims.Query += "  and su.departmentid="+StrDepartmentID+"";
                   if (!StrSubDepartentID.Equals(Default))
                       objdbhims.Query += " and t.subdepartmentid="+StrSubDepartentID+"";
                   if (!StrGroupID.Equals(Default))
                       objdbhims.Query += " and t.groupid="+StrGroupID+"";
                   if (!StrActive.Equals(Default))
                       objdbhims.Query += " and t.active='"+StrActive+"'";
                   if (StrExternal.Equals("Y") || StrExternal.Equals("N"))
                       objdbhims.Query += " and t.external='"+StrExternal+"'";
                   objdbhims.Query += " order by su.name,t.test_name";
                   break;
               case 2: // department
                   objdbhims.Query = "SELECT departmentid,name FROM dc_tp_departments d where active='Y' and type='S'";
                   break;
               case 3: // subdepartment
                   objdbhims.Query = "SELECT subdepartmentid,name FROM dc_tp_subdepartments d where active='Y' and type='S' and departmentid="+StrDepartmentID+"";
                   break;
               case 4: // group
                   objdbhims.Query = "SELECT groupid,name  FROM dc_tp_groupm d where active='Y'";
                   break;
               case 5: // cash +report
                   objdbhims.Query = "SELECT p.prno, c.prid,c.labid,c.receiveno,c.paidamount,concat(ifnull(p.title,''),' ',p.name) as patientname,date_format(c.enteredon,'%d/%m/%Y %h:%i:%s %p') as receiveon,date_format(rp.enteredon,'%d/%m/%Y %h:%i:%s %p') as generatedon,og.name as orgname,og.phoneno,ifnull((select sum(paidamount) from dc_tcashcollection where reportno ='" + StrReportNo + "'),0) as totalcash,case when c.paymentmode='C' then 'Cash' when c.paymentmode='A' then 'On Acc' when c.paymentmode='D' then 'Debit Card' else '-' end as paymentmode FROM dc_tcashcollection c left outer join dc_tpatient p on c.prid = p.prid left outer join dc_tp_organization og on c.clientid=og.orgid left outer join dc_tcashreport rp on c.reportno=rp.reportno where c.reportno='" + StrReportNo + "'";
                   break;
               case 6: // Refund + report
                   objdbhims.Query = "SELECT p.prno,c.prid,c.labid,c.refundno,sum(c.paidamount) as paidamount,concat(ifnull(p.title,''),' ',p.name) as patientname,date_format(c.enteredon,'%d/%m/%Y %h:%i:%s %p') as refundon,ifnull((select sum(paidamount) from dc_tcashrefund where refundtype<>'D' and reportno ='"+StrReportNo+"'),0) as totalrefund,case when c.refundtype='C' then 'Cancel' when c.refundtype='D' then 'Discount' when c.refundtype='K' then 'BCL Staff' when c.refundtype='R' then 'Poor Patient' when c.refundtype='P' then 'Panel Patient' when c.refundtype='W' then 'Wrong Entry' else '-' end as refundtype FROM dc_tcashrefund c left outer join dc_tpatient p on c.prid = p.prid where c.reportno='" + StrReportNo + "' and c.refundtype<>'D' group by c.refundno";
                   break;
               case 7: // waiting for closing queue
                   objdbhims.Query = "SELECT p.prno, c.prid,c.labid,c.receiveno,c.paidamount,concat(ifnull(p.title,''),' ',p.name) as patientname,date_format(c.enteredon,'%d/%m/%Y %h:%i:%s %p') as receiveon,date_format(rp.enteredon,'%d/%m/%Y %h:%i:%s %p') as generatedon,og.name as orgname,og.phoneno,ifnull((select sum(paidamount) from dc_tcashcollection where reportno is null and paymentmode='C' and enteredby=" + StrCashierID + "),0) as totalcash,case when c.paymentmode='C' then 'Cash' when c.paymentmode='A' then 'On Acc' when c.paymentmode='D' then 'Debit Card' when c.paymentmode='R' then 'Credit Card' else '-' end as paymentmode FROM dc_tcashcollection c left outer join dc_tpatient p on c.prid = p.prid left outer join dc_tp_organization og on c.clientid=og.orgid left outer join dc_tcashreport rp on c.reportno=rp.reportno where c.reportno is null and c.enteredby=" + StrCashierID + "";
                   break;
               case 8: // Refund + report
                   objdbhims.Query = "SELECT p.prno,c.prid,c.labid,c.refundno,c.paidamount,concat(ifnull(p.title,''),' ',p.name) as patientname,date_format(c.enteredon,'%d/%m/%Y %h:%i:%s %p') as refundon,ifnull((select sum(paidamount) from dc_tcashrefund where reportno is null and enteredby="+StrCashierID+"),0) as totalrefund,case when c.refundtype='C' then 'Cancel' when c.refundtype='D' then 'Discount' when c.refundtype='K' then 'BCL Staff' when c.refundtype='R' then 'Poor Patient' when c.refundtype='P' then 'Panel Patient' when c.refundtype='W' then 'Wrong Entry' else '-' end as refundtype FROM dc_tcashrefund c left outer join dc_tpatient p on c.prid = p.prid where c.reportno is null and c.refundtype<>'D' and c.enteredby=" + StrCashierID + "";
                   break;
               case 9: // main org
                   objdbhims.Query = "SELECT name,phoneno FROM dc_tp_organization where active='Y' and external='N' and main='Y'";
                   break;
               case 10:// external test
                   objdbhims.Query = "select t.testid,t.test_name,ifnull(t.acronym,'-') as acronym,case when ag.gender='A' then 'All' when ag.gender='M' then 'Male' when ag.gender='F' then 'Female' else '-' end as Age_gender2,ifnull(ag.minage,'-') as minage, ifnull(ag.maxage,'-') as maxage,concat('(',ag.gender,')',ifnull(ag.minage,'~'),'-',ifnull(ag.maxage,'~')) as age_gender,t.charges,ifnull(t.chargesurgent,0) as chargesurgent, su.name as subdepartment,ifnull(sp.specimen_name,'-') as specimen_name,ifnull(sc.container_name,'-') as container_name,t.active,g.name as groupname,t.external,og.name as extorg,ifnull(t.charityrate,0) as charityrate,case when met.maxtime > 1440 then concat(floor(met.maxtime/1440),' Day(s)') else concat(floor(met.maxtime/60),' Hour(s)') end as tat  from dc_tp_test t left outer join dc_tp_test_age ag on t.testid =ag.testid left outer join dc_tp_subdepartments su on t.subdepartmentid =su.subdepartmentid left outer join dc_tp_stype sp on t.specimenid = sp.specimenid left outer join dc_tp_scontainer sc on t.scontainerid = sc.scontainerid  left outer join dc_tp_groupm g on t.groupid=g.groupid left outer join dc_tp_organization og on t.external_org=og.orgid left outer join dc_tp_method met on met.methodid=t.d_methodid where su.active='Y' and t.external='Y'";
                   if (!StrDepartmentID.Equals(Default))
                       objdbhims.Query += "  and su.departmentid=" + StrDepartmentID + "";
                   if (!StrSubDepartentID.Equals(Default))
                       objdbhims.Query += " and t.subdepartmentid=" + StrSubDepartentID + "";
                   if (!StrGroupID.Equals(Default))
                       objdbhims.Query += " and t.groupid=" + StrGroupID + "";
                   if (!StrActive.Equals(Default))
                       objdbhims.Query += " and t.active='" + StrActive + "'";                  
                   break;
               case 11: // management console grid
                   objdbhims.Query = "select og.orgid,og.name as branch,og.acronym,(select count(bookingid) from dc_tpatient_bookingm where ifnull(payment_mode,'C')<>'A' and clientid=og.orgid and date_format(enteredon,'%d/%m/%Y')='" + StrDate + "') as cashpatient,(select count(bookingid) from dc_tpatient_bookingm where payment_mode='A' and clientid=og.orgid and date_format(enteredon,'%d/%m/%Y')='" + StrDate + "') as panelpatient,ifnull((select sum(paidamount) from dc_tcashcollection where clientid=og.orgid and date_format(enteredon,'%d/%m/%Y')='" + StrDate + "'),0) as cashreceived,ifnull((select sum(paidamount) from dc_tcashrefund where clientid=og.orgid and refundtype<>'D' and date_format(enteredon,'%d/%m/%Y')='" + StrDate + "'),0) as cashrefund,ifnull((select sum(paidamount) from dc_tcashcollection where clientid=og.orgid and date_format(enteredon,'%d/%m/%Y')='" + StrDate + "'),0) - ifnull((select sum(paidamount) from dc_tcashrefund where clientid=og.orgid and date_format(enteredon,'%d/%m/%Y')='" + StrDate + "' and refundtype<>'D'),0) as netamount,(SELECT count(testid) FROM dc_tpatient_bookingd where clientid=og.orgid and date_format(enteredon,'%d/%m/%Y')='" + StrDate + "') as totaltest,'" + StrFromDate + "' as summarydate from dc_tp_organization og where og.external='N'";
                   break;
               case 12: // panel test report
                   objdbhims.Query = "SELECT d.panelid,d.name,d.address,t.testid,te.test_name,g.name as groupname,te.acronym,ifnull(t.rate,0) as charges FROM dc_tpanel d left outer join dc_tpanel_test t on t.panelid=d.panelid left outer join dc_tp_test te on te.testid=t.testid left outer join dc_tp_groupm g on g.groupid=te.groupid where d.active='Y' and te.active='Y' and d.panelid="+StrPanelID+"";
                   
                   break;
               case 13: // branch summary=> management console .....cash Received
                   objdbhims.Query = "SELECT p.prno, c.prid,c.labid,c.receiveno,c.paidamount,concat(ifnull(p.title,''),' ',p.name) as patientname,date_format(c.enteredon,'%d/%m/%Y %h:%i:%s %p') as receiveon,og.name as orgname,og.phoneno, case when c.paymentmode='C' then 'Cash' when c.paymentmode='A' then 'On Acc' when c.paymentmode='D' then 'Debit Card' when c.paymentmode='R' then 'Credit Card' else '-' end as paymentmode,c.bookingid,ifnull(pn.name,'-') as panelname,date_format(c.enteredon,'%d/%m/%Y %h:%i %p') as receivedon FROM dc_tcashcollection c left outer join dc_tpatient p on c.prid = p.prid left outer join dc_tp_organization og on c.clientid=og.orgid left outer join dc_tpanel pn on p.panelid=pn.panelid where c.clientid='" + StrBranchID + "' and date_format(c.enteredon,'%Y-%m-%d') = '" + StrFromDate + "'";
                       //"SELECT p.prno, c.prid,c.labid,c.receiveno,c.paidamount,concat(p.title,'.',p.name) as patientname,date_format(c.enteredon,'%d/%m/%Y %h:%i:%s %p') as receiveon,og.name as orgname,og.phoneno, case when c.paymentmode='C' then 'Cash' when c.paymentmode='A' then 'On Acc' when c.paymentmode='D' then 'Debit Card' else '-' end as paymentmode,bd.testid,t.test_name,ifnull(t.charges,0) as testamount,c.bookingid FROM dc_tcashcollection c left outer join dc_tpatient p on c.prid = p.prid left outer join dc_tp_organization og on c.clientid=og.orgid left outer join dc_tpatient_bookingd bd on c.bookingid=bd.bookingid left outer join dc_tp_test t on bd.testid = t.testid where c.clientid='"+StrBranchID+"' and date_format(c.enteredon,'%Y-%m-%d') = '"+StrFromDate+"'";
                   break;
               case 14: // branch summary => management console....cash refund
                   objdbhims.Query = "SELECT p.prno,c.prid,c.labid,c.refundno,c.paidamount,concat(ifnull(p.title,''),' ',p.name) as patientname,date_format(c.enteredon,'%d/%m/%Y %h:%i:%s %p') as refundon,case when c.refundtype='C' then 'Cancel' when c.refundtype='D' then 'Discount' when c.refundtype='K' then 'BCL Staff' when c.refundtype='R' then 'Poor Patient' when c.refundtype='P' then 'Panel Patient' when c.refundtype='W' then 'Wrong Entry' else '-' end as refundtype,c.bookingid,date_format(c.enteredon,'%d/%m/%Y %h:%i %p') as refundon FROM dc_tcashrefund c left outer join dc_tpatient p on c.prid = p.prid where date_format(c.enteredon,'%Y-%m-%d')= '" + StrFromDate + "' and c.clientid='" + StrBranchID + "' and c.refundtype <> 'D'  group by c.refundno" ;
                       //"SELECT p.prno,c.prid,c.labid,c.refundno,c.paidamount,concat(p.title,'.',p.name) as patientname,date_format(c.enteredon,'%d/%m/%Y %h:%i:%s %p') as refundon,case when c.refundtype='C' then 'Cancel' when c.refundtype='D' then 'Discount' when c.refundtype='K' then 'KLDC Staff' when c.refundtype='R' then 'Poor Patient' when c.refundtype='P' then 'Panel Patient' when c.refundtype='W' then 'Wrong Entry' else '-' end as refundtype,t.test_name,ifnull(t.charges,0) as testamount FROM dc_tcashrefund c left outer join dc_tpatient p on c.prid = p.prid left outer join dc_tpatient_bookingd bd on c.bookingid = bd.bookingid left outer join dc_tp_test t on bd.testid = t.testid where date_format(c.enteredon,'%Y-%m-%d')= '" + StrFromDate + "' and c.clientid='" + StrBranchID + "'  and t.testid in (select testid from dc_Tcashrefund where bookingid=bd.bookingid and labid=bd.labid) ";
                   break;
               case 15: // test fill template grid
                   objdbhims.Query = "select t.test_name,ifnull(d.totalamount,0) as testamount,d.bookingid,date_format(d.enteredon,'%d/%m/%y %h:%i %p')  as receiveon from dc_tpatient_bookingd d left outer join dc_tp_test t on d.testid=t.testid  where d.bookingid="+StrBookingID+"";
                   break;
               case 16: // test fill template grid refund
                   objdbhims.Query = "select t.test_name,ifnull(c.paidamount,0) as testamount,date_format(c.enteredon,'%d/%m/%y %h:%i %p') as refundon from  dc_tcashrefund c  left outer join dc_tp_test t on c.testid=t.testid where c.bookingid=" + StrBookingID + " and c.refundno='"+StrRefundNo+"'";
                   break;
               case 17: // schedule test
                   objdbhims.Query = "select type,value from dc_tp_test_schedule where testid="+StrTestID+"";
                   break;
               case 18: // total services, total cash and panel due
                   objdbhims.Query = "select max(prid),ifnull((select sum(totalamount) from dc_tpatient_bookingd where status<>'X' and clientid='" + StrBranchID + "' and date_format(enteredon,'%Y-%m-%d') = '" + StrFromDate + "'),0) as totalservices,ifnull((select sum(ifnull(totalamount,0)-(ifnull(paidamount,0)+ifnull(discount_amt,0))) from dc_tpatient_bookingm where payment_mode='C' and clientid='" + StrBranchID + "' and date_format(enteredon,'%Y-%m-%d') = '" + StrFromDate + "' and bookingid not in (select bookingid from dc_tpatient_bookingd where status='X')),0) as cashdue,ifnull((select sum(ifnull(totalamount,0)-(ifnull(paidamount,0)+ifnull(discount_amt,0))) from dc_tpatient_bookingm where payment_mode='A' and clientid='" + StrBranchID + "' and date_format(enteredon,'%Y-%m-%d') = '" + StrFromDate + "' and bookingid not in (select bookingid from dc_tpatient_bookingd where status='X') ),0) as paneldue from dc_tpatient";
                   break;
               case 19: // ref doctor: COnsultant
                   objdbhims.Query = "select doctorid,concat(name,' ',title) as consultant from dc_tp_refdoctors where active='Y'";
                   break;
               case 20: // fill sub on summary test code report & turnover & work load
                   objdbhims.Query = "select subdepartmentid,name from dc_tp_subdepartments where active='Y'";
                   if (!StrDepartmentID.Equals(Default) && !StrDepartmentID.Equals("-1"))
                       objdbhims.Query += " and departmentid="+StrDepartmentID+"";
                   break;
               case 21: // fill test on summary test code report & turnover
                   objdbhims.Query = "select testid,test_name as name from dc_Tp_test where active='Y'";
                   if (!StrSubDepartentID.Equals(Default) && !StrSubDepartentID.Equals("-1"))
                       objdbhims.Query += "   and subdepartmentid=" + StrSubDepartentID + "";
                   break;
               case 22: // fill department rpt turnover
                   objdbhims.Query = "select departmentid , name from dc_tp_departments where active='Y'";
                   break;
               case 23:// fill group rpt turnover
                   objdbhims.Query = "select groupid,name from dc_tp_groupm where active='Y'";
                   break;
               case 24: // turnover = > report dt
                   objdbhims.Query = "select bd.bookingid,bd.testid,g.groupid,g.name as groupname,t.test_name,bm.enteredon,d.departmentid,s.subdepartmentid,d.name as Department,s.name as subdepartment,count(bd.testid) as test_count,bd.clientid, ifnull((select  count(bbd.testid) from  dc_Tpatient_bookingm bbm join dc_tpatient_bookingd bbd where bbm.bookingid=bbd.bookingid and date_format(bbm.enteredon,'%Y-%m-%d') between '"+StrFromDate+"' and '"+StrTODate+"'  and bbm.clientid='"+StrBranchID+"' and bbd.testid in (select testid from dc_Tresult where bookingid=bbm.bookingid ) and bbd.testid=bd.testid group by bbd.testid),0) AS performed_count  from dc_tpatient_bookingm bm join dc_tpatient_bookingd bd join dc_tp_test t join  dc_tp_subdepartments s join dc_tp_departments d left outer join dc_tp_groupm g on t.groupid=g.groupid where bm.bookingid=bd.bookingid and  bd.testid=t.testid and t.subdepartmentid = s.subdepartmentid and s.departmentid=d.departmentid and date_format(bm.enteredon,'%Y-%m-%d') between '"+StrFromDate+"' and '"+StrTODate+"' and bm.clientid='"+StrBranchID+"'   group by bd.testid  order by performed_count Desc";
                   break;
               case 25: // external organization
                   objdbhims.Query = "select orgid,name from dc_tp_organization where active='Y' and external='Y'";
                   break;
               case 26: // pr no exist... indoor charge sheet
                   objdbhims.Query = "select prno from dc_tpatient where prno='"+StrPRNo+"'";
                   break;
               case 27: // consultant ordering summary
                   objdbhims.Query = "select count(d.testid) as testcount,sum(d.totalamount) as totalamount,r.name as name,(select count(prid) from dc_Tpatient_bookingm mm where date_format(mm.enteredon,'%Y-%m-%d') between '" + StrFromDate + "' and '" + StrTODate + "' and mm.doctorid=m.doctorid and mm.clientid='" + StrBranchID + "' ) as patient from dc_Tpatient_bookingm m join dc_Tpatient_bookingd d on m.bookingid= d.bookingid join dc_tp_refdoctors r on r.doctorid=m.doctorid where m.clientid='" + StrBranchID + "' and date_format(m.enteredon,'%Y-%m-%d') between '" + StrFromDate + "' and '" + StrTODate + "' group by m.doctorid order by testcount desc"; 
                   break;
               case 28: // test ordering summary
                   objdbhims.Query = "select p.prid,p.name,p.title,m.bookingid,m.labid,m.totalamount as bookingTotal, m.paidamount,ifnull(m.discount_amt,0) as discount_amt,d.totalamount as testRate,case when pn.name is null then '-' else pn.name end as Panel,t.testid,t.test_name,case when m.doctorid is null then m.referredby else dr.name end as doctor,m.enteredon,d.clientid from dc_Tpatient p join dc_tpatient_bookingm m join dc_tpatient_bookingd d left outer join dc_tpanel pn on m.panelid=pn.panelid join dc_Tp_Test t left outer join dc_tp_refdoctors dr on dr.doctorid=m.doctorid where p.prid=m.prid and m.bookingid=d.bookingid and t.testid=d.testid and date_format(m.enteredon,'%Y-%m-%d') between '" + StrFromDate + "' and '" + StrTODate + "'";
                   if (!StrTestID.Equals(Default) && !StrTestID.Equals(""))
                       objdbhims.Query += " and t.testid=" + StrTestID + "";
                   if (!StrBranchID.Equals(Default) && !StrBranchID.Equals(""))
                       objdbhims.Query += " and m.clientid=" + StrBranchID + "";
                   
                   break;
               case 29: // discount summry report
                   objdbhims.Query = "select p.prid,p.name,p.title,m.bookingid,m.labid,m.totalamount , m.paidamount,ifnull(m.discount_amt,0) as discount_amt,d.totalamount as testRate,m.enteredon,d.clientid,pr.salutation,pr.fname,pr.mname,pr.lname,m.panelid,pp.name  from dc_Tpatient p join dc_tpatient_bookingm m join dc_tpatient_bookingd d join dc_Tp_personnel pr left outer join dc_tpanel pp on pp.panelid=m.panelid where p.prid=m.prid and m.bookingid=d.bookingid and pr.personid = m.enteredby and date_format(m.enteredon,'%Y-%m-%d') between '" + StrFromDate + "' and '" + StrTODate + "'";
                   if (!StrBranchID.Equals(Default) && !StrBranchID.Equals(""))
                       objdbhims.Query += " and m.clientid=" + StrBranchID + "";
                   if (!StrPanelID.Equals(Default) && !StrPanelID.Equals(""))
                       objdbhims.Query += " and m.panelid=" + StrPanelID + "";
                   if (!StrType.Equals(Default) && StrType.Equals("C"))
                       objdbhims.Query += " and m.panelid is null";
                   if (!StrType.Equals(Default) && StrType.Equals("P"))
                       objdbhims.Query += " and m.panelid is not null";
                   break;
               case 30: // cash receipt print
                   objdbhims.Query = "select c.receiveno,c.labid,ifnull(c.paidamount,0) as paidamount,c.totalamount,d.totalamount as charges,concat(t.test_name,' ',ifnull(cl.name,'')) as testname, concat(pr.salutation,' ',pr.fname,' ',ifnull(mname,''),' ',ifnull(lname,'')) as receivedby,concat(ifnull(pp.title,''),' ',pp.name) as patient, date_format(c.enteredon,'%d/%m/%y %h:%i %p') as receivedon,pp.prno, d.deliverytime ,concat(og.name,' ',og.address) as orgaddress,og.phoneno,date_format(pp.dob,'%d/%m/%Y') as dob,case when pp.gender='M' then 'Male' else 'Female' end as gender,cl.classificationid,d.testid,m.bookingid,m.prid,c.paymentmode,pn.panelid,pn.name as panelname,ifnull(m.authorizeno,'') as authorizeno,ifnull(pp.serviceno,'') as serviceno,case when pp.address is null or pp.address='' then '-' else pp.address end as address,m.enteredon,case when DATEDIFF(CURRENT_DATE,pp.dob) > 365 then      concat(Floor(DATEDIFF(CURRENT_DATE,pp.dob)/365),' (Y)')  else   case when DATEDIFF(CURRENT_DATE,pp.dob) > 30 then      concat(Floor(DATEDIFF(CURRENT_DATE,pp.dob)/30),' (M)')    else      concat(DATEDIFF(CURRENT_DATE,pp.dob),'(D)')    end  end  AS age,case when m.doctorid is null or    m.doctorid='' then m.referredby else concat(ifnull(dr.title,''),' ',dr.name) end as consultant,m.discount_amt,    ifnull((select sum(ifnull(paidamount,0)) from dc_tcashcollection where bookingid=m.bookingid),0) as totalpaid,     pp.cellno,pp.hphone,dr.code,m.referenceno,t.external,t.speedkey,pp.pasword,m.remarks,m.payment_mode as M_Bmode,     pn.print_amount,w.name as ward,m.type as ind_outdoor,m.origin_place from dc_tcashcollection c  join dc_tpatient_bookingm m on c.bookingid = m.bookingid left outer join dc_tp_personnel pr on c.enteredby = pr.personid join dc_tpatient_bookingd d on m.bookingid = d.bookingid join dc_tp_test t on d.testid = t.testid left outer join dc_tp_tclass cl  on d.classificationid = cl.classificationid join dc_tpatient pp on m.prid = pp.prid left outer join dc_tp_organization og on m.origin_place = og.orgid left outer join dc_tpanel pn on c.panelid= pn.panelid left outer join dc_tp_refdoctors dr on dr.doctorid=m.doctorid left outer join dc_tp_ward w on w.wardid=m.wardid where c.receiveno='" + StrReceiveNo + "'";
                   break;
               case 31: // cash refund
                   objdbhims.Query = "select c.refundno, c.labid,c.paidamount,c.totalamount,concat(t.test_name,' ',ifnull(cl.name,'')) as testname,concat(pr.salutation,' ',pr.fname,' ',ifnull(pr.mname,''),' ',ifnull(pr.lname,'')) as receivedby,concat(ifnull(pp.title,''),' ',pp.name) as patient, c.enteredon as receivedon, pp.prno,concat(og.name,' ',og.address) as orgaddress,og.phoneno,date_format(pp.dob,'%d/%m/%Y') as dob,case when pp.gender='M' then 'Male' else 'Female' end as gender,cl.classificationid,c.testid,m.bookingid,m.prid,concat(au.salutation,' ',au.fname,' ',ifnull(au.mname,''),' ',ifnull(au.lname,'')) as Authorizedby,case when c.refundtype='C' then 'Booking Cancel' when c.refundtype='D' then 'Discount' when c.refundtype='K' then 'BCL Staff' when c.refundtype='R' then 'Poor Patient' when c.refundtype='P' then 'Panel Patient' when c.refundtype='W' then 'Wrong Entry'  else '-' end as refundtype,case when DATEDIFF(CURRENT_DATE,pp.dob) > 365 then concat(Floor(DATEDIFF(CURRENT_DATE,pp.dob)/365),' Years')  else case when DATEDIFF(CURRENT_DATE,pp.dob) > 30 then concat(Floor(DATEDIFF(CURRENT_DATE,pp.dob)/30),' Month') else concat(DATEDIFF(CURRENT_DATE,pp.dob),' Days')    end  end  AS age,case when pp.address is null or pp.address='' then '-' else pp.address end as address,m.enteredon from dc_tcashrefund c left outer join dc_tpatient_bookingm m on c.bookingid = m.bookingid left outer join dc_tp_personnel pr on c.enteredby = pr.personid  left outer join dc_tp_test t on c.testid = t.testid left outer join dc_tp_tclass cl  on c.classificationid = cl.classificationid left outer join dc_tpatient pp on m.prid = pp.prid left outer join dc_tp_organization og on m.origin_place = og.orgid left outer join dc_tp_personnel au on c.authorizedby = au.personid where c.refundno='" + StrRefundNo + "'";
                   break;
               case 32:
                   objdbhims.Query = @"select c.receiveno,c.labid,ifnull(c.paidamount,0) as paidamount,c.totalamount,d.totalamount as charges,
concat(t.test_name,' ',ifnull(cl.name,'')) as testname, concat(pr.salutation,' ',
pr.fname,' ',ifnull(mname,''),' ',ifnull(lname,'')) as receivedby,concat(ifnull(pp.title,''),' ',
pp.name) as patient, date_format(c.enteredon,'%d/%m/%y %h:%i %p') as receivedon,pp.prno,
 d.deliverytime ,concat(og.name,' ',og.address) as orgaddress,
og.phoneno,date_format(pp.dob,'%d/%m/%Y') as dob,case when pp.gender='M' then 'Male' else 'Female'
end as gender,cl.classificationid,d.testid,m.bookingid,m.prid,c.paymentmode,pn.panelid,
pn.name as panelname,ifnull(m.authorizeno,'') as authorizeno,ifnull(pp.serviceno,'') as serviceno,
case when pp.address is null or pp.address='' then '-' else pp.address end as address,m.enteredon,case when DATEDIFF(CURRENT_DATE,pp.dob) > 365 then      concat(Floor(DATEDIFF(CURRENT_DATE,pp.dob)/365),' (Y)')  else    case when DATEDIFF(CURRENT_DATE,pp.dob) > 30 then      concat(Floor(DATEDIFF(CURRENT_DATE,pp.dob)/30),' (M)')    else      concat(DATEDIFF(CURRENT_DATE,pp.dob),'(D)')    end  end  AS age,case when m.doctorid is null or m.doctorid='' then m.referredby else concat(ifnull(dr.title,''),' ',dr.name) end as consultant,m.discount_amt,ifnull((select sum(ifnull(paidamount,0)) from dc_tcashcollection where bookingid=m.bookingid),0) as totalpaid, pp.cellno,pp.hphone,dr.code,m.referenceno,t.external,t.speedkey,pp.pasword,m.remarks,m.payment_mode as M_Bmode,pn.print_amount,w.name as ward,m.type as ind_outdoor,m.origin_place
from dc_tcashcollection c  join dc_tpatient_bookingm m on c.bookingid = m.bookingid
left outer join dc_tp_personnel pr on c.enteredby = pr.personid
join dc_tpatient_bookingd d on m.bookingid = d.bookingid
join dc_tp_test t on d.testid = t.testid
left outer join dc_tp_tclass cl  on d.classificationid = cl.classificationid
join dc_tpatient pp on m.prid = pp.prid
left outer join dc_tp_organization og on m.origin_place = og.orgid
left outer join dc_tpanel pn on c.panelid= pn.panelid
left outer join dc_tp_refdoctors dr on dr.doctorid=m.doctorid left outer join dc_tp_ward w on w.wardid=m.wardid";
                   if (!StrReceiveNo.Equals(Default) && !StrReceiveNo.Equals(""))
                       objdbhims.Query += " where c.receiveno='" + StrReceiveNo + "'";

                   break;
             

           }
           return objTrans.DataTrigger_Get_All(objdbhims);
       }

       #endregion
   }
}
