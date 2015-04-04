using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Odbc;
using BusinessLayer;
using DataLayer;


/// <summary>
/// Summary description for clsCashRefund
/// </summary>
public class clsCashRefund
{
	public clsCashRefund()
	{

    }
	   clsdbhims objdbhims = new clsdbhims();
       clsoperation objTrans = new clsoperation();

       #region "Variables"

       private const string TableName = "dc_tcashcollection";
       private const string Default = "~!@";

       private string StrError = Default;
       private string StrBookingID = Default;
       private string StrBookingDID = Default;
       private string StrPRID = Default;

       private string StrLabID = Default;
       private string StrReceiveNo = Default;
       private string StrPaymentMode = Default;

       private string StrTotalAmount = Default;
       private string StrPaidAmount = Default;
       private string StrPanelID = Default;

       private string StrDiscount = Default;
       private string StrEnteredOn = Default;
       private string StrEnteredBy = Default;
       private string StrClientID = Default;

       private string StrRefundID = Default;
       private string StrRefundNo = Default;
       private string StrTestID = Default;
       private string StrClassificationID = Default;

       private string StrRefundType = Default;
       private string StrAuthorizedBy = Default;
       private string StrComment = Default;

       private string StrReportID = Default;
       private string StrReportNo = Default;
       private string StrCashierID = Default;

       private string StrPatient = Default;
       private string StrPrNo = Default;

       private string StrDate = Default;
       private string StrTODate = Default;
       private string StrBranchID = Default;
       private string StrPRocessID = Default;
       private string StrDiscount_Amt_Test = Default;

       private string _Branch_ID = Default;

    

       #endregion

       #region "Properties"

       public string Error
       {
           get { return StrError; }
           set { StrError = value; }
       }
       public string BookingID
       {
           get { return StrBookingID; }
           set { StrBookingID = value; }
       }
       public string BookingDID
       {
           get { return StrBookingDID; }
           set { StrBookingDID = value; }
       }
       public string PRID
       {
           get { return StrPRID; }
           set { StrPRID = value; }
       }

       public string LabID
       {
           get { return StrLabID; }
           set { StrLabID = value; }
       }
       public string ReceiveNo
       {
           get { return StrReceiveNo; }
           set { StrReceiveNo = value; }
       }
       public string PaymentMode
       {
           get { return StrPaymentMode; }
           set { StrPaymentMode = value; }
       }

       public string TotalAmount
       {
           get { return StrTotalAmount; }
           set { StrTotalAmount = value; }
       }
       public string PaidAmount
       {
           get { return StrPaidAmount; }
           set { StrPaidAmount = value; }
       }
       public string PanelID
       {
           get { return StrPanelID; }
           set { StrPanelID = value; }
       }

       public string Discount
       {
           get { return StrDiscount; }
           set { StrDiscount = value; }
       }
       public string EnteredOn
       {
           get { return StrEnteredOn; }
           set { StrEnteredOn = value; }
       }
       public string EnteredBy
       {
           get { return StrEnteredBy; }
           set { StrEnteredBy = value; }
       }
       public string ClientID
       {
           get { return StrClientID; }
           set { StrClientID = value; }
       }

       public string RefundID
       {
           get { return StrRefundID; }
           set { StrRefundID = value; }
       }
       public string RefundNo
       {
           get { return StrRefundNo; }
           set { StrRefundNo = value; }
       }
       public string TestID
       {
           get { return StrTestID; }
           set { StrTestID = value; }
       }
       public string ClassificationID
       {
           get { return StrClassificationID; }
           set { StrClassificationID = value; }
       }

       public string RefundType
       {
           get { return StrRefundType; }
           set { StrRefundType = value; }
       }
       public string AuthorizedBy
       {
           get { return StrAuthorizedBy; }
           set { StrAuthorizedBy = value; }
       }
       public string Comment
       {
           get { return StrComment; }
           set { StrComment = value; }
       }

       public string ReportID
       {
           get { return StrReportID; }
           set { StrReportID = value; }
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

       public string Patient
       {
           get { return StrPatient; }
           set { StrPatient = value; }
       }
       public string PRNO
       {
           get { return StrPrNo; }
           set { StrPrNo = value; }
       }

       public string Date
       {
           get { return StrDate; }
           set { StrDate = value; }
       }
       public string ToDate
       {
           get { return StrTODate; }
           set { StrTODate = value; }
       }
       public string BranchID
       {
           get { return StrBranchID; }
           set { StrBranchID = value; }
       }
       public string ProcessID
       {
           get { return StrPRocessID; }
           set { StrPRocessID = value; }
       }
       public string Discount_Amt_Test
       {
           get { return StrDiscount_Amt_Test; }
           set { StrDiscount_Amt_Test = value; }
       }

       public string Branch_ID
       {
           get { return _Branch_ID; }
           set { _Branch_ID = value; }
       }

       #endregion


      public DataView GetAll(int flag)
       {
           switch (flag)
           {
               case 1:  // cash Refund Patient Information
                   //objdbhims.Query = "select ifnull(pp.email,'-') as email,ifnull(pp.cellno,'-') as cellno,pp.Pasword,c.refundno, c.labid,c.paidamount,c.totalamount,concat(t.test_name,' ',ifnull(cl.name,'')) as testname,concat(pr.salutation,' ',pr.fname,' ',ifnull(pr.mname,''),' ',ifnull(pr.lname,'')) as receivedby,concat(ifnull(pp.title,''),' ',pp.name) as patient, c.enteredon as receivedon, pp.prno,concat(og.name,' ',og.address) as orgaddress,og.phoneno,date_format(pp.dob,'%d/%m/%Y') as dob, case when pp.gender='M' then 'Male' else 'Female' end as gender,cl.classificationid,c.testid,m.bookingid,m.prid,concat(au.salutation,' ',au.fname,' ',ifnull(au.mname,''),' ',ifnull(au.lname,'')) as Authorizedby, case when c.refundtype='C' then 'Booking Cancel' when c.refundtype='D' then 'Discount' when c.refundtype='K' then 'BCL Staff' when c.refundtype='R' then 'Poor Patient' when c.refundtype='P' then 'Panel Patient' when c.refundtype='W' then 'Wrong Entry'  else '-' end as refundtype, case when DATEDIFF(CURRENT_DATE,pp.dob) > 365 then concat(Floor(DATEDIFF(CURRENT_DATE,pp.dob)/365),' Years')  else case when DATEDIFF(CURRENT_DATE,pp.dob) > 30 then concat(Floor(DATEDIFF(CURRENT_DATE,pp.dob)/30),' Month') else concat(DATEDIFF(CURRENT_DATE,pp.dob),' Days')    end  end  AS age, case when pp.address is null or pp.address='' then '-' else pp.address end as address,m.enteredon from dc_tcashrefund c left outer join dc_tpatient_bookingm m on c.bookingid = m.bookingid left outer join dc_tp_personnel pr on c.enteredby = pr.personid left outer join dc_tp_test t on c.testid = t.testid left outer join dc_tp_tclass cl  on c.classificationid = cl.classificationid left outer join dc_tpatient pp on m.prid = pp.prid left outer join dc_tp_organization og on m.origin_place = og.orgid left outer join dc_tp_personnel au on c.authorizedby = au.personid WHERE c.refundno = 'F006-12-0000273' LIMIT 1 ";
                   objdbhims.Query = "select ifnull(pp.email,'-') as email,ifnull(pp.cellno,'-') as cellno,pp.Pasword,c.refundno, c.labid,c.paidamount,c.totalamount,concat(t.test_name,' ',ifnull(cl.name,'')) as testname,concat(pr.salutation,' ',pr.fname,' ',ifnull(pr.mname,''),' ',ifnull(pr.lname,'')) as receivedby,concat(ifnull(pp.title,''),' ',pp.name) as patient, date_format(c.enteredon,'%d/%m/%y %h:%i %p') as receivedon, pp.prno,concat(og.name,' ',og.address) as orgaddress,og.phoneno,date_format(pp.dob,'%d/%m/%Y') as dob, case when pp.gender='M' then 'Male' else 'Female' end as gender,cl.classificationid,c.testid,m.bookingid,m.prid,concat(au.salutation,' ',au.fname,' ',ifnull(au.mname,''),' ',ifnull(au.lname,'')) as Authorizedby, case when c.refundtype='C' then 'Booking Cancel' when c.refundtype='D' then 'Discount' when c.refundtype='K' then 'BCL Staff' when c.refundtype='R' then 'Poor Patient' when c.refundtype='P' then 'Panel Patient' when c.refundtype='W' then 'Wrong Entry'  else '-' end as refundtype, case when DATEDIFF(CURRENT_DATE,pp.dob) > 365 then concat(Floor(DATEDIFF(CURRENT_DATE,pp.dob)/365),' Years')  else case when DATEDIFF(CURRENT_DATE,pp.dob) > 30 then concat(Floor(DATEDIFF(CURRENT_DATE,pp.dob)/30),' Month') else concat(DATEDIFF(CURRENT_DATE,pp.dob),' Days')    end  end  AS age, case when pp.address is null or pp.address='' then '-' else pp.address end as address,date_format(m.enteredon,'%d/%m/%y %h:%i %p') as registering from dc_tcashrefund c left outer join dc_tpatient_bookingm m on c.bookingid = m.bookingid left outer join dc_tp_personnel pr on c.enteredby = pr.personid left outer join dc_tp_test t on c.testid = t.testid left outer join dc_tp_tclass cl  on c.classificationid = cl.classificationid left outer join dc_tpatient pp on m.prid = pp.prid left outer join dc_tp_organization og on m.origin_place = og.orgid left outer join dc_tp_personnel au on c.authorizedby = au.personid WHERE c.refundno = '" + RefundNo + "' LIMIT 1 ";
                   break;
               case 2:  // Cash Refund Test List
                  // objdbhims.Query = "select c.refundno, c.labid,c.paidamount,c.totalamount,concat(t.test_name,' ',ifnull(cl.name,'')) as testname,concat(pr.salutation,' ',pr.fname,' ',ifnull(pr.mname,''),' ',ifnull(pr.lname,'')) as receivedby,concat(ifnull(pp.title,''),' ',pp.name) as patient, c.enteredon as receivedon, pp.prno,concat(og.name,' ',og.address) as orgaddress,og.phoneno,date_format(pp.dob,'%d/%m/%Y') as dob, case when pp.gender='M' then 'Male' else 'Female' end as gender,cl.classificationid,c.testid,m.bookingid,m.prid,concat(au.salutation,' ',au.fname,' ',ifnull(au.mname,''),' ',ifnull(au.lname,'')) as Authorizedby, case when c.refundtype='C' then 'Booking Cancel' when c.refundtype='D' then 'Discount' when c.refundtype='K' then 'BCL Staff' when c.refundtype='R' then 'Poor Patient' when c.refundtype='P' then 'Panel Patient' when c.refundtype='W' then 'Wrong Entry'  else '-' end as refundtype, case when DATEDIFF(CURRENT_DATE,pp.dob) > 365 then concat(Floor(DATEDIFF(CURRENT_DATE,pp.dob)/365),' Years')  else case when DATEDIFF(CURRENT_DATE,pp.dob) > 30 then concat(Floor(DATEDIFF(CURRENT_DATE,pp.dob)/30),' Month') else concat(DATEDIFF(CURRENT_DATE,pp.dob),' Days')    end  end  AS age, case when pp.address is null or pp.address='' then '-' else pp.address end as address,m.enteredon from dc_tcashrefund c left outer join dc_tpatient_bookingm m on c.bookingid = m.bookingid left outer join dc_tp_personnel pr on c.enteredby = pr.personid left outer join dc_tp_test t on c.testid = t.testid left outer join dc_tp_tclass cl  on c.classificationid = cl.classificationid left outer join dc_tpatient pp on m.prid = pp.prid left outer join dc_tp_organization og on m.origin_place = og.orgid left outer join dc_tp_personnel au on c.authorizedby = au.personid WHERE c.refundno = 'F006-12-0000273' ";
                   objdbhims.Query = "select c.refundno, c.labid,c.paidamount,c.totalamount,concat(t.test_name,' ',ifnull(cl.name,'')) as testname,concat(pr.salutation,' ',pr.fname,' ',ifnull(pr.mname,''),' ',ifnull(pr.lname,'')) as receivedby,concat(ifnull(pp.title,''),' ',pp.name) as patient, c.enteredon as receivedon, pp.prno,concat(og.name,' ',og.address) as orgaddress,og.phoneno,date_format(pp.dob,'%d/%m/%Y') as dob, case when pp.gender='M' then 'Male' else 'Female' end as gender,cl.classificationid,c.testid,m.bookingid,m.prid,concat(au.salutation,' ',au.fname,' ',ifnull(au.mname,''),' ',ifnull(au.lname,'')) as Authorizedby, case when c.refundtype='C' then 'Booking Cancel' when c.refundtype='D' then 'Discount' when c.refundtype='K' then 'BCL Staff' when c.refundtype='R' then 'Poor Patient' when c.refundtype='P' then 'Panel Patient' when c.refundtype='W' then 'Wrong Entry'  else '-' end as refundtype, case when DATEDIFF(CURRENT_DATE,pp.dob) > 365 then concat(Floor(DATEDIFF(CURRENT_DATE,pp.dob)/365),' Years')  else case when DATEDIFF(CURRENT_DATE,pp.dob) > 30 then concat(Floor(DATEDIFF(CURRENT_DATE,pp.dob)/30),' Month') else concat(DATEDIFF(CURRENT_DATE,pp.dob),' Days')    end  end  AS age, case when pp.address is null or pp.address='' then '-' else pp.address end as address,m.enteredon from dc_tcashrefund c left outer join dc_tpatient_bookingm m on c.bookingid = m.bookingid left outer join dc_tp_personnel pr on c.enteredby = pr.personid left outer join dc_tp_test t on c.testid = t.testid left outer join dc_tp_tclass cl  on c.classificationid = cl.classificationid left outer join dc_tpatient pp on m.prid = pp.prid left outer join dc_tp_organization og on m.origin_place = og.orgid left outer join dc_tp_personnel au on c.authorizedby = au.personid WHERE c.refundno = '"+RefundNo+"' ";
                   break;
                case 3: // Cash Refund Total Amount
                  // objdbhims.Query = "select pp.Pasword,c.refundno, c.labid,SUM(c.paidamount) as refunded,c.totalamount,concat(t.test_name,' ',ifnull(cl.name,'')) as testname,concat(pr.salutation,' ',pr.fname,' ',ifnull(pr.mname,''),' ',ifnull(pr.lname,'')) as receivedby,concat(ifnull(pp.title,''),' ',pp.name) as patient, c.enteredon as receivedon, pp.prno,concat(og.name,' ',og.address) as orgaddress,og.phoneno,date_format(pp.dob,'%d/%m/%Y') as dob, case when pp.gender='M' then 'Male' else 'Female' end as gender,cl.classificationid,c.testid,m.bookingid,m.prid,concat(au.salutation,' ',au.fname,' ',ifnull(au.mname,''),' ',ifnull(au.lname,'')) as Authorizedby, case when c.refundtype='C' then 'Booking Cancel' when c.refundtype='D' then 'Discount' when c.refundtype='K' then 'BCL Staff' when c.refundtype='R' then 'Poor Patient' when c.refundtype='P' then 'Panel Patient' when c.refundtype='W' then 'Wrong Entry'  else '-' end as refundtype, case when DATEDIFF(CURRENT_DATE,pp.dob) > 365 then concat(Floor(DATEDIFF(CURRENT_DATE,pp.dob)/365),' Years')  else case when DATEDIFF(CURRENT_DATE,pp.dob) > 30 then concat(Floor(DATEDIFF(CURRENT_DATE,pp.dob)/30),' Month') else concat(DATEDIFF(CURRENT_DATE,pp.dob),' Days')    end  end  AS age, case when pp.address is null or pp.address='' then '-' else pp.address end as address,m.enteredon from dc_tcashrefund c left outer join dc_tpatient_bookingm m on c.bookingid = m.bookingid left outer join dc_tp_personnel pr on c.enteredby = pr.personid left outer join dc_tp_test t on c.testid = t.testid left outer join dc_tp_tclass cl  on c.classificationid = cl.classificationid left outer join dc_tpatient pp on m.prid = pp.prid left outer join dc_tp_organization og on m.origin_place = og.orgid left outer join dc_tp_personnel au on c.authorizedby = au.personid WHERE c.refundno = 'F006-12-0000273'";
                   objdbhims.Query = "select pp.Pasword,c.refundno, c.labid,SUM(c.paidamount) as refunded,c.totalamount,concat(t.test_name,' ',ifnull(cl.name,'')) as testname,concat(pr.salutation,' ',pr.fname,' ',ifnull(pr.mname,''),' ',ifnull(pr.lname,'')) as receivedby,concat(ifnull(pp.title,''),' ',pp.name) as patient, c.enteredon as receivedon, pp.prno,concat(og.name,' ',og.address) as orgaddress,og.phoneno,date_format(pp.dob,'%d/%m/%Y') as dob, case when pp.gender='M' then 'Male' else 'Female' end as gender,cl.classificationid,c.testid,m.bookingid,m.prid,concat(au.salutation,' ',au.fname,' ',ifnull(au.mname,''),' ',ifnull(au.lname,'')) as Authorizedby, case when c.refundtype='C' then 'Booking Cancel' when c.refundtype='D' then 'Discount' when c.refundtype='K' then 'BCL Staff' when c.refundtype='R' then 'Poor Patient' when c.refundtype='P' then 'Panel Patient' when c.refundtype='W' then 'Wrong Entry'  else '-' end as refundtype, case when DATEDIFF(CURRENT_DATE,pp.dob) > 365 then concat(Floor(DATEDIFF(CURRENT_DATE,pp.dob)/365),' Years')  else case when DATEDIFF(CURRENT_DATE,pp.dob) > 30 then concat(Floor(DATEDIFF(CURRENT_DATE,pp.dob)/30),' Month') else concat(DATEDIFF(CURRENT_DATE,pp.dob),' Days')    end  end  AS age, case when pp.address is null or pp.address='' then '-' else pp.address end as address,m.enteredon from dc_tcashrefund c left outer join dc_tpatient_bookingm m on c.bookingid = m.bookingid left outer join dc_tp_personnel pr on c.enteredby = pr.personid left outer join dc_tp_test t on c.testid = t.testid left outer join dc_tp_tclass cl  on c.classificationid = cl.classificationid left outer join dc_tpatient pp on m.prid = pp.prid left outer join dc_tp_organization og on m.origin_place = og.orgid left outer join dc_tp_personnel au on c.authorizedby = au.personid WHERE c.refundno = '"+RefundNo+"'"; 
                  
                   break;
               case 4: // Total Booking Test
                  //objdbhims.Query = "select c.receiveno,c.labid,ifnull(c.paidamount,0) as paidamount,c.totalamount,d.totalamount as charges,concat(t.test_name,' ',ifnull(cl.name,'')) as testname, concat(pr.salutation,' ',pr.fname,' ',ifnull(mname,''),' ',ifnull(lname,'')) as receivedby,concat(ifnull(pp.title,''),' ',pp.name) as patient, date_format(c.enteredon,'%d/%m/%y %h:%i %p') as receivedon,pp.prno, d.deliverytime ,concat(og.name,' ',og.address) as orgaddress,og.phoneno,date_format(pp.dob,'%d/%m/%Y') as dob,case when pp.gender='M' then 'Male' else 'Female' end as gender,cl.classificationid,d.testid,m.bookingid,m.prid,c.paymentmode,pn.panelid,pn.name as panelname,ifnull(m.authorizeno,'') as authorizeno,ifnull(pp.serviceno,'') as serviceno,case when pp.address is null or pp.address='' then '-' else pp.address end as address,m.enteredon,case when DATEDIFF(CURRENT_DATE,pp.dob) > 365 then      concat(Floor(DATEDIFF(CURRENT_DATE,pp.dob)/365),'(Years)')  else    case when DATEDIFF(CURRENT_DATE,pp.dob) > 30 then      concat(Floor(DATEDIFF(CURRENT_DATE,pp.dob)/30),' (M)')    else      concat(DATEDIFF(CURRENT_DATE,pp.dob),'(D)')    end  end  AS age,case when m.doctorid is null or m.doctorid='' then m.referredby else concat(ifnull(dr.title,''),' ',dr.name) end as consultant,m.discount_amt,ifnull((select sum(ifnull(paidamount,0)) from dc_tcashcollection where bookingid=m.bookingid),0) as totalpaid, pp.cellno,pp.hphone,dr.code,m.referenceno,t.external,t.speedkey,pp.pasword,m.remarks,m.payment_mode as M_Bmode,pn.print_amount,w.name as ward,m.type as ind_outdoor,m.origin_place from dc_tcashcollection c  join dc_tpatient_bookingm m on c.bookingid = m.bookingid left outer join dc_tp_personnel pr on c.enteredby = pr.personid join dc_tpatient_bookingd d on m.bookingid = d.bookingid join dc_tp_test t on d.testid = t.testid left outer join dc_tp_tclass cl  on d.classificationid = cl.classificationid join dc_tpatient pp on m.prid = pp.prid left outer join dc_tp_organization og on m.origin_place = og.orgid left outer join dc_tpanel pn on c.panelid= pn.panelid left outer join dc_tp_refdoctors dr on dr.doctorid=m.doctorid left outer join dc_tp_ward w on w.wardid=m.wardid WHERE pp.prno = '008-12-00004647' AND m.labid = '12-006-00002644' GROUP BY t.testid ";
                   objdbhims.Query = "select round((d.totalamount-(m.discountAll*d.totalamount/100))) as discount,c.receiveno,c.labid,ifnull(c.paidamount,0) as paidamount,c.totalamount,d.totalamount as charges,concat(t.test_name,' ',ifnull(cl.name,'')) as testname, concat(pr.salutation,' ',pr.fname,' ',ifnull(mname,''),' ',ifnull(lname,'')) as receivedby,concat(ifnull(pp.title,''),' ',pp.name) as patient, date_format(c.enteredon,'%d/%m/%y %h:%i %p') as receivedon,pp.prno, d.deliverytime ,concat(og.name,' ',og.address) as orgaddress,og.phoneno,date_format(pp.dob,'%d/%m/%Y') as dob,case when pp.gender='M' then 'Male' else 'Female' end as gender,cl.classificationid,d.testid,m.bookingid,m.prid,c.paymentmode,pn.panelid,pn.name as panelname,ifnull(m.authorizeno,'') as authorizeno,ifnull(pp.serviceno,'') as serviceno,case when pp.address is null or pp.address='' then '-' else pp.address end as address,m.enteredon,case when DATEDIFF(CURRENT_DATE,pp.dob) > 365 then      concat(Floor(DATEDIFF(CURRENT_DATE,pp.dob)/365),'(Years)')  else    case when DATEDIFF(CURRENT_DATE,pp.dob) > 30 then      concat(Floor(DATEDIFF(CURRENT_DATE,pp.dob)/30),' (M)')    else      concat(DATEDIFF(CURRENT_DATE,pp.dob),'(D)')    end  end  AS age,case when m.doctorid is null or m.doctorid='' then m.referredby else concat(ifnull(dr.title,''),' ',dr.name) end as consultant,m.discount_amt,ifnull((select sum(ifnull(paidamount,0)) from dc_tcashcollection where bookingid=m.bookingid),0) as totalpaid, pp.cellno,pp.hphone,dr.code,m.referenceno,t.external,t.speedkey,pp.pasword,m.remarks,m.payment_mode as M_Bmode,pn.print_amount,w.name as ward,m.type as ind_outdoor,m.origin_place from dc_tcashcollection c  join dc_tpatient_bookingm m on c.bookingid = m.bookingid left outer join dc_tp_personnel pr on c.enteredby = pr.personid join dc_tpatient_bookingd d on m.bookingid = d.bookingid join dc_tp_test t on d.testid = t.testid left outer join dc_tp_tclass cl  on d.classificationid = cl.classificationid join dc_tpatient pp on m.prid = pp.prid left outer join dc_tp_organization og on m.origin_place = og.orgid left outer join dc_tpanel pn on c.panelid= pn.panelid left outer join dc_tp_refdoctors dr on dr.doctorid=m.doctorid left outer join dc_tp_ward w on w.wardid=m.wardid WHERE pp.prno = '" + PRNO + "' AND m.labid = '" + LabID + "' GROUP BY t.testid ";
                  break;

           }
           return objTrans.DataTrigger_Get_All(objdbhims);
       }

	
}
