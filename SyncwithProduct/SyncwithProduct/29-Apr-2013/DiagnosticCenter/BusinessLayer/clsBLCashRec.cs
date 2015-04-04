using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataLayer;

namespace BusinessLayer
{
   public class clsBLCashRec
    {
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

       #region"Method"

       public DataView GetAll(int flag)
       {
           switch (flag)
           {
               case 1://waiting grid fill//where  m.origin_place='" + StrBranchID + "' and
                    objdbhims.Query=@"select p.prid,p.prno,concat(ifnull(p.title,''),' ',p.name) as Name,
                                        ifnull(m.totalamount,0) as totalamount,m.bookingid,m.labid,
                                        date_format(m.enteredon,'%d/%m/%Y') as bookingdate,
                                        m.totalamount-(ifnull(m.paidamount, 0)+ifnull(discount_amt, 0)) as amount,
                                        ifnull(m.authorizeno,'') as authorizeno,ifnull(p.serviceno,'') as serviceno,
                                        ifnull(m.refund_amt,0) as refund_amt,ifnull(m.balance,0) as balance ,og.acronym as origin1,
                                        tb.Name origin,(case when m.type='I' then concat(w.name,':', m.adm_ref) else '-' end) as adm_info

                                        from dc_tpatient p left outer join dc_tpatient_bookingm m on p.prid=m.prid
                                        left outer join dc_tp_organization og on og.orgid=m.clientid
                                        left outer join dc_tp_ward w on w.wardid=m.wardid
                                        left outer join dc_tp_branch tb on tb.branchID=m.BranchID

                                        where m.payment_mode in (" + StrPaymentMode + ")";// m.origin_place='"+StrBranchID+@"' and and m.BranchID="+Convert.ToInt32(_Branch_ID)

                        if (!StrPatient.Equals(Default) && !StrPatient.Equals(""))
                            objdbhims.Query += " and p.name like '%"+StrPatient+"%'";
                        if (!StrPrNo.Equals(Default) && !StrPrNo.Equals(""))
                            objdbhims.Query += " and p.prno='"+StrPrNo+"'";
                        if (!StrDate.Equals(Default) && !StrDate.Equals(""))
                            objdbhims.Query += " and date_format(m.enteredon,'%Y/%m/%d') between '"+StrDate+"' and '"+StrTODate+"'";
                        if (!StrLabID.Equals(Default) && !StrLabID.Equals(""))
                        {
                            objdbhims.Query += " and m.labid='" + StrLabID + "'";
                        }

                        break;
               //objdbhims.Query = "select p.prid,p.prno,concat(ifnull(p.title,''),' ',p.name) as Name,ifnull(m.totalamount,0) as totalamount,m.bookingid,m.labid,date_format(m.enteredon,'%d/%m/%Y') as bookingdate, m.totalamount-(ifnull(m.paidamount, 0)+ifnull(discount_amt, 0)) as amount,ifnull(m.authorizeno,'') as authorizeno,ifnull(p.serviceno,'') as serviceno,ifnull(m.refund_amt,0) as refund_amt,ifnull(m.balance,0) as balance ,og.acronym as origin, (case when m.type='I' then concat(w.name,':', m.adm_ref) else '-' end) as adm_info from dc_tpatient p left outer join dc_tpatient_bookingm m on p.prid=m.prid left outer join dc_tp_organization og on og.orgid=m.clientid left outer join dc_tp_ward w on w.wardid=m.wardid where m.origin_place='" + StrBranchID + "' and m.payment_mode in (" + StrPaymentMode + ")";
                   ////and ifnull(m.payment_mode,'C')<>'A'";     march 09,11
                   ////objdbhims.Query = "select p.prid,p.prno,concat(ifnull(p.title,''),' ',p.name) as Name,ifnull(m.totalamount,0) as totalamount,m.bookingid,m.labid,date_format(m.enteredon,'%d/%m/%Y') as bookingdate, m.totalamount-(m.paidamount+ifnull((select sum(discount_amt) from dc_tpatient_bookingm where labid=m.labid), 0)) as amount,ifnull(m.authorizeno,'') as authorizeno,ifnull(p.serviceno,'') as serviceno from dc_tpatient p left outer join dc_tpatient_bookingm m on p.prid=m.prid where m.origin_place='" + StrBranchID + "' and  (select totalamount from dc_tpatient_bookingm where labid=m.labid) <>( (ifnull((select sum(paidamount) from dc_tcashcollection where labid=m.labid), 0)) +  (ifnull((select sum(discount_amt) from dc_tpatient_bookingm where labid=m.labid), 0))) and ifnull(m.payment_mode,'C')<>'A'";
                   //if (!StrPatient.Equals(Default) && !StrPatient.Equals(""))
                   //    objdbhims.Query += " and p.name like '%"+StrPatient+"%'";
                   //if (!StrPrNo.Equals(Default) && !StrPrNo.Equals(""))
                   //    objdbhims.Query += " and p.prno='"+StrPrNo+"'";
                   //if (!StrDate.Equals(Default) && !StrDate.Equals(""))
                   //    objdbhims.Query += " and date_format(m.enteredon,'%Y/%m/%d') between '"+StrDate+"' and '"+StrTODate+"'";
                   ////case when (m.paidamount is null or m.paidamount=0) then m.totalamount else
               
               case 2:// count,and total amount
                   objdbhims.Query = "SELECT ifnull(sum(paidamount),0) as paidamount,ifnull((select sum(paidamount) from dc_tcashrefund where enteredby=" + StrEnteredBy + " and reportno is null and type='R'),0) as refundamount,count(transid)+ ifnull((select count(refundid) from dc_tcashrefund where enteredby=" + StrEnteredBy + " and reportno is null and type='R'),0) as TotalEntries,ifnull(sum(paidamount),0)-ifnull((select sum(paidamount) from dc_tcashrefund where enteredby=" + StrEnteredBy + " and reportno is null and type='R'),0) as balance FROM dc_tcashcollection d where enteredby=" + StrEnteredBy + " and reportno is null";
                   //objdbhims.Query = "SELECT ifnull(sum(paidamount),0) as paidamount,ifnull((select sum(paidamount) from dc_tcashrefund where enteredby="+StrEnteredBy+" and reportno is null),0) as refundamount,count(transid)+ ifnull((select count(refundid) from dc_tcashrefund where enteredby="+StrEnteredBy+" and reportno is null),0) as TotalEntries,ifnull(sum(paidamount),0)-ifnull((select sum(paidamount) from dc_tcashrefund where enteredby="+StrEnteredBy+" and reportno is null),0) as balance FROM dc_tcashcollection d where enteredby="+StrEnteredBy+" and reportno is null";
                   break;
               case 3: // fill test gv base upon labid
                   objdbhims.Query = "SELECT distinct c.classificationid, m.bookingid,d.bookingdid,m.prid,m.labid,d.testid,ifnull(d.paidamount,d.totalamount) as totalamount,concat(t.test_name,' ',ifnull(c.name,'')) as testname,m.panelid FROM dc_tpatient_bookingm m left outer join  dc_tpatient_bookingd d on m.bookingid=d.bookingid  left outer join dc_tp_test t on d.testid = t.testid left outer join dc_tp_tclass c  on d.classificationid=c.classificationid left outer join dc_tpatient p on m.prid=p.prid where m.labid='" + StrLabID + "'";//d.totalamount-ifnull(m.discount_amt,0) as totalamount changed while synchronizing 
                   break;
               case 4://print cash
                   objdbhims.Query = "select c.receiveno,c.labid,ifnull(c.paidamount,0) as paidamount,c.totalamount,d.totalamount as charges,concat(t.test_name,' ',ifnull(cl.name,'')) as testname, concat(pr.salutation,' ',pr.fname,' ',ifnull(mname,''),' ',ifnull(lname,'')) as receivedby,concat(ifnull(pp.title,''),' ',pp.name) as patient, date_format(c.enteredon,'%d/%m/%y %h:%i %p') as receivedon,pp.prno,case when d.deliverytime is null then '-----' else date_format(d.deliverytime,'%d/%m/%Y') end as deliverytime,concat(og.name,' ',og.address) as orgaddress,og.phoneno,date_format(pp.dob,'%d/%m/%Y') as dob,case when pp.gender='M' then 'Male' else 'Female' end as gender,cl.classificationid,d.testid,m.bookingid,m.prid,c.paymentmode,pn.panelid,pn.name as panelname,ifnull(m.authorizeno,'') as authorizeno,ifnull(pp.serviceno,'') as serviceno from dc_tcashcollection c left outer join dc_tpatient_bookingm m on c.bookingid = m.bookingid left outer join dc_tp_personnel pr on c.enteredby = pr.personid left outer join dc_tpatient_bookingd d on m.bookingid = d.bookingid left outer join dc_tp_test t on d.testid = t.testid left outer join dc_tp_tclass cl  on d.classificationid = cl.classificationid left outer join dc_tpatient pp on m.prid = pp.prid left outer join dc_tp_organization og on m.origin_place = og.orgid left outer join dc_tpanel pn on c.panelid= pn.panelid where c.receiveno='" + StrReceiveNo + "'";
                   //if(!StrReceiveNo.Equals(Default) && !StrReceiveNo.Equals(""))
                   //    objdbhims.Query +=" and c.receiveno='"+StrReceiveNo+"'";
                   
                   break;
               case 5: // refund queue // c.clientid='"+StrBranchID+"' and
                   objdbhims.Query = @"select distinct c.bookingid,c.prid,p.prno,concat(ifnull(p.title,''),' ',p.name) as patientname,
                                    c.labid,c.receiveno,c.totalamount,ifnull(sum(c.paidamount),0) as paidamount,
                                    c.panelid,date_format(c.enteredon,'%d/%m/%Y %h:%i:%s %p') as receiveon,
                                    ifnull(m.discount_amt,0) as Totaldiscount,ifnull(m.totalamount,0) as totalamount,
                                    ifnull(m.paidamount,0) as totalpaid,
                                    ifnull(m.refund_amt,0) as totalrefund,
                                    ifnull(m.balance,0) as balance,og.acronym as origin1,tb.Name origin,
                                    (case when m.type='I' then concat(w.name,':', m.adm_ref) else '-' end) as adm_info
                                    from dc_tcashcollection c left outer join dc_tpatient p on c.prid = p.prid
                                    join dc_tpatient_bookingm m on c.bookingid=m.bookingid
                                    left outer join dc_tp_organization og on og.orgid=m.clientid
                                    left outer join dc_tp_ward w on w.wardid=m.wardid 
                                    left outer join dc_tp_branch tb on tb.BranchID=m.BranchID

                                    where c.clientid='" + StrBranchID + @"' and m.BranchID=" + Convert.ToInt32(_Branch_ID) + @"
                                    and c.bookingid in (select bookingid from dc_tpatient_bookingd where status <>'X') ";
                                   
                                   if (!StrLabID.Equals(Default))
                                       objdbhims.Query += " and c.labid='"+StrLabID+"'";
                                   if (!StrPatient.Equals(Default) && !StrPatient.Equals(""))
                                       objdbhims.Query += " and p.name like '%"+StrPatient+"%'";
                                   if (!StrReceiveNo.Equals(Default) && !StrReceiveNo.Equals(""))
                                       objdbhims.Query += " and c.receiveno='"+StrReceiveNo+"'";
                                   if (!StrPrNo.Equals(Default) && !StrPrNo.Equals(""))
                                       objdbhims.Query += " and p.prno='"+StrPrNo+"'";
                                   if (!StrDate.Equals(Default) && !StrTODate.Equals(Default))
                                       objdbhims.Query += " and date_format(c.enteredon,'%Y/%m/%d') between '"+StrDate+"' and '"+StrTODate+"'";
                                   objdbhims.Query += " group by c.labid";
                                   break;
               ///objdbhims.Query = "select distinct c.bookingid,c.prid,p.prno,concat(ifnull(p.title,''),' ',p.name) as patientname,c.labid,c.receiveno,c.totalamount,ifnull(sum(c.paidamount),0) as paidamount,c.panelid,date_format(c.enteredon,'%d/%m/%Y %h:%i:%s %p') as receiveon, ifnull(m.discount_amt,0) as Totaldiscount,ifnull(m.totalamount,0) as totalamount,ifnull(m.paidamount,0) as totalpaid,ifnull(m.refund_amt,0) as totalrefund,ifnull(m.balance,0) as balance,og.acronym as origin,(case when m.type='I' then concat(w.name,':', m.adm_ref) else '-' end) as adm_info from dc_tcashcollection c left outer join dc_tpatient p on c.prid = p.prid join dc_tpatient_bookingm m on c.bookingid=m.bookingid left outer join dc_tp_organization og on og.orgid=m.clientid left outer join dc_tp_ward w on w.wardid=m.wardid where c.clientid='" + StrBranchID + "' and  c.bookingid in (select bookingid from dc_tpatient_bookingd where status <>'X') ";
                   //if (!StrLabID.Equals(Default))
                   //    objdbhims.Query += " and c.labid='"+StrLabID+"'";
                   //if (!StrPatient.Equals(Default) && !StrPatient.Equals(""))
                   //    objdbhims.Query += " and p.name like '%"+StrPatient+"%'";
                   //if (!StrReceiveNo.Equals(Default) && !StrReceiveNo.Equals(""))
                   //    objdbhims.Query += " and c.receiveno='"+StrReceiveNo+"'";
                   //if (!StrPrNo.Equals(Default) && !StrPrNo.Equals(""))
                   //    objdbhims.Query += " and p.prno='"+StrPrNo+"'";
                   //if (!StrDate.Equals(Default) && !StrTODate.Equals(Default))
                   //    objdbhims.Query += " and date_format(c.enteredon,'%Y/%m/%d') between '"+StrDate+"' and '"+StrTODate+"'";
                   //objdbhims.Query += " group by c.labid";
              case 6:// authorized drop down fill
                   objdbhims.Query = "select personid,concat(fname,' ',ifnull(mname,''),' ',ifnull(lname,''),' ',salutation) as personname from dc_tp_personnel where active='Y' ";
                   break;
               case 7://print Refund slip
                   objdbhims.Query = "select c.refundno, c.labid,c.paidamount,c.totalamount,concat(t.test_name,' ',ifnull(cl.name,'')) as testname,concat(pr.salutation,' ',pr.fname,' ',ifnull(pr.mname,''),' ',ifnull(pr.lname,'')) as receivedby,concat(ifnull(pp.title,''),' ',pp.name) as patient, date_format(c.enteredon,'%d/%m/%y %h:%i %p') as receivedon, pp.prno,concat(og.name,' ',og.address) as orgaddress,og.phoneno,date_format(pp.dob,'%d/%m/%Y') as dob,case when pp.gender='M' then 'Male' else 'Female' end as gender,cl.classificationid,c.testid,m.bookingid,m.prid,concat(au.salutation,' ',au.fname,' ',ifnull(au.mname,''),' ',ifnull(au.lname,'')) as Authorizedby,case when c.refundtype='C' then 'Booking Cancel' when c.refundtype='D' then 'Discount' when c.refundtype='K' then 'BCL Staff' when c.refundtype='R' then 'Poor Patient' when c.refundtype='P' then 'Panel Patient' when c.refundtype='W' then 'Wrong Entry'  else '-' end as refundtype from dc_tcashrefund c left outer join dc_tpatient_bookingm m on c.bookingid = m.bookingid left outer join dc_tp_personnel pr on c.enteredby = pr.personid  left outer join dc_tp_test t on c.testid = t.testid left outer join dc_tp_tclass cl  on c.classificationid = cl.classificationid left outer join dc_tpatient pp on m.prid = pp.prid left outer join dc_tp_organization og on m.origin_place = og.orgid left outer join dc_tp_personnel au on c.authorizedby = au.personid where c.refundno='" + StrRefundNo + "' ";
                   break;
               case 8: // Refund History
                   objdbhims.Query = "SELECT f.refundid,f.refundno,f.bookingid,f.receiveno,f.labid,f.totalamount,f.paidamount,t.test_name FROM dc_tcashrefund f left outer join dc_tp_test t on f.testid=t.testid where f.labid='"+StrLabID+"'";
                   break;
               case 9: // refund : balance charges
                   objdbhims.Query = "select paidamount,testid from dc_tcashrefund where labid='"+StrLabID+"'";
                   break;
               case 10://print cash //-ifnull(m.discount_amt,0)
                  //objdbhims.Query = "select c.receiveno,c.labid,sum(ifnull(c.paidamount,0)) as paidamount,c.totalamount,(m.discountAll*d.totalamount/100) as discountAll,d.totalamount as charges,concat(t.test_name,' ',ifnull(cl.name,'')) as testname, concat(pr.fname,' ',ifnull(mname,''),' ',ifnull(lname,''),' ',pr.salutation) as receivedby,concat(pp.name,' ',ifnull(title,'')) as patient, date_format(c.enteredon,'%d/%m/%Y %h:%i:%s %p') as receivedon,pp.prno,case when d.deliverytime is null then '-----' else date_format(d.deliverytime,'%d/%m/%Y %h:%i %p') end as deliverytime,concat(og.name,' ',og.address) as orgaddress,og.phoneno,date_format(pp.dob,'%d/%m/%Y') as dob,case when pp.gender='M' then 'Male' else 'Female' end as gender,cl.classificationid,d.testid,m.bookingid,m.prid,d.bookingdid,m.payment_mode from dc_tcashcollection c left outer join dc_tpatient_bookingm m on c.bookingid = m.bookingid left outer join dc_tp_personnel pr on c.enteredby = pr.personid left outer join dc_tpatient_bookingd d on m.bookingid = d.bookingid left outer join dc_tp_test t on d.testid = t.testid left outer join dc_tp_tclass cl  on d.classificationid = cl.classificationid left outer join dc_tpatient pp on m.prid = pp.prid left outer join dc_tp_organization og on m.origin_place = og.orgid where m.labid='" + StrLabID + "' group by d.bookingdid";
                  objdbhims.Query = "select c.receiveno,c.labid,sum(ifnull(c.paidamount,0)) as paidamount,c.totalamount,round((d.totalamount-(ifnull(d.percentdiscountcash,0)*d.totalamount/100))) as charges,d.totalamount as charges2,concat(t.test_name,' ',ifnull(cl.name,'')) as testname, concat(pr.fname,' ',ifnull(mname,''),' ',ifnull(lname,''),' ',pr.salutation) as receivedby,concat(pp.name,' ',ifnull(title,'')) as patient, date_format(c.enteredon,'%d/%m/%Y %h:%i:%s %p') as receivedon,pp.prno,case when d.deliverytime is null then '-----' else date_format(d.deliverytime,'%d/%m/%Y %h:%i %p') end as deliverytime,concat(og.name,' ',og.address) as orgaddress,og.phoneno,date_format(pp.dob,'%d/%m/%Y') as dob,case when pp.gender='M' then 'Male' else 'Female' end as gender,cl.classificationid,d.testid,m.bookingid,m.prid,d.bookingdid,m.payment_mode from dc_tcashcollection c left outer join dc_tpatient_bookingm m on c.bookingid = m.bookingid left outer join dc_tp_personnel pr on c.enteredby = pr.personid left outer join dc_tpatient_bookingd d on m.bookingid = d.bookingid left outer join dc_tp_test t on d.testid = t.testid left outer join dc_tp_tclass cl  on d.classificationid = cl.classificationid left outer join dc_tpatient pp on m.prid = pp.prid left outer join dc_tp_organization og on m.origin_place = og.orgid where m.labid='"+StrLabID+"' group by d.bookingdid"; 
                  break;
               case 11: // get paid and total amount
                   objdbhims.Query = "SELECT sum(ifnull(paidamount,0)) as paidamount,totalamount,(SELECT ifnull(sum(discount_amt),0)  FROM dc_tpatient_bookingm d where labid='"+StrLabID+"') as discount_amt FROM dc_tcashcollection d where labid='" + StrLabID + "' group by labid";
                   break;
               case 12: // cash close grid
                   objdbhims.Query = "select cc.cashClosing_Amount,cc.cashOpening_Amount,cc.cashClosing_Amount - cc.cashOpening_Amount as netcash, rp.reportno,(select ifnull(sum(paidamount),0) from dc_tcashcollection where rp.reportno=reportno) as Collectedcash,(select ifnull(sum(paidamount),0) from dc_tcashrefund where rp.reportno=reportno and refundtype<>'D') as Refundedamount,ifnull((select ifnull(sum(paidamount),0) from dc_tcashcollection where rp.reportno=reportno),0)-ifnull((select ifnull(sum(paidamount),0) from dc_tcashrefund where rp.reportno=reportno and refundtype<>'D'),0) as netamount,date_format(rp.enteredon,'%d/%m/%Y %h:%i:%s %p') as printon from dc_tcashreport rp  inner join dc_tcashcheckin cc on cc.reportno=rp.reportno where rp.cashierid=" + StrEnteredBy + "  order by rp.enteredon desc";
                   break;
           }
           return objTrans.DataTrigger_Get_All(objdbhims);
       }

       public bool Cash_Receive(string[,] str)
       {
           QueryBuilder objQB = new QueryBuilder();

           objTrans.Start_Transaction();

           objdbhims.Query = "SELECT lpad(ifnull(max(substr(e.receiveno,9,7)),0)+1,7,0) as maxid FROM dc_tcashcollection e where substr(e.receiveno,6,2)= date_format(current_date,'%y') and substr(e.receiveno,2,3)='" + StrBranchID + "'";
           StrReceiveNo = this.objTrans.DataTrigger_Get_Max(objdbhims);

           if (!StrReceiveNo.Equals("True"))
           {
               StrReceiveNo = "R" + StrBranchID + "-" + System.DateTime.Now.ToString("yy") + "-" + StrReceiveNo;
               objdbhims.Query = objQB.QBInsert(MakeArray(), TableName);
               StrError = objTrans.DataTrigger_Insert(objdbhims);

               if (!StrError.Equals("True"))
               {
                   objdbhims.Query = "update dc_tpatient_bookingm set paidamount=ifnull(paidamount,0)+" + StrPaidAmount + ",discount_amt=ifnull(discount_amt,0)+" + StrDiscount_Amt_Test + ",balance=ifnull(balance,totalamount)-" + StrPaidAmount + "-" + StrDiscount_Amt_Test + " where bookingid=" + StrBookingID + "";
                   // objdbhims.Query = "update dc_tpatient_bookingm set paidamount=ifnull(paidamount,0)+"+StrPaidAmount+",payment_mode='"+StrPaymentMode+"' where bookingid="+StrBookingID+"";
                   StrError = objTrans.DataTrigger_Update(objdbhims);

                   if (!StrError.Equals("True"))
                   {
                       for (int i = 0; i <= str.GetUpperBound(0); i++)
                       {
                           StrTestID = str[i, 0];
                           //StrDiscount_Amt_Test = str[i, 1];
                           if (str[i, 1] != null)
                               StrPRocessID = str[i, 1];
                           else
                               StrPRocessID = "null";
                           

                           objdbhims.Query = "update dc_tpatient_bookingd set status='P',processid="+StrPRocessID+" where bookingid=" + StrBookingID + " and testid='"+StrTestID+"'";
                           StrError = objTrans.DataTrigger_Update(objdbhims);

                           if (!StrError.Equals("True"))
                           {

                               objdbhims.Query = "insert into dc_tstatustrack (labid,processid,testid,enteredby,enteredon,clientid) values ('" + StrLabID + "',2," + StrTestID + "," + StrEnteredBy + ",str_to_date('" + StrEnteredOn + "','%d/%m/%Y %h:%i:%s %p')," + StrClientID + ") ";
                               StrError = objTrans.DataTrigger_Insert(objdbhims);
                               if (StrError.Equals("True"))
                               {
                                   StrError = objTrans.OperationError;
                                   objTrans.End_Transaction();
                                   return false;
                               }

                           }
                           else
                           {
                               StrError = objTrans.OperationError;
                               objTrans.End_Transaction();
                               return false;
                           }
                       }
                       if (!StrError.Equals("True"))
                       {
                           if (!StrDiscount_Amt_Test.Equals("") && !StrDiscount_Amt_Test.Equals(Default) && Convert.ToInt32(StrDiscount_Amt_Test) > 0)
                           {
                               objdbhims.Query = "SELECT lpad(ifnull(max(substr(e.refundno,9,7)),0)+1,7,0) as maxid FROM dc_tcashrefund e where substr(e.refundno,6,2)= date_format(current_date,'%y') and substr(e.refundno,2,3)='" + StrBranchID + "'";
                               StrRefundNo = this.objTrans.DataTrigger_Get_Max(objdbhims);
                               if (!StrRefundNo.Equals("True"))
                               {
                                   StrRefundNo = "F" + StrBranchID + "-" + System.DateTime.Now.ToString("yy") + "-" + StrRefundNo;
                                   objdbhims.Query = "Insert into dc_tcashrefund(refundno,bookingid,receiveno,prid,labid,totalamount,paidamount,enteredby,enteredon,clientid,refundtype,authorizedby,comments,type) Values('" + StrRefundNo + "'," + StrBookingID + ",'" + StrReceiveNo + "'," + StrPRID + ",'" + StrLabID + "'," + StrTotalAmount + "," + StrDiscount_Amt_Test + "," + StrEnteredBy + ",str_to_date('" + StrEnteredOn + "','%d/%m/%Y %h:%i:%s %p'),'" + StrClientID + "','D'," + StrEnteredBy + ",'Discount on cash queue','C')";
                                   StrError = objTrans.DataTrigger_Insert(objdbhims);

                                   //if (!StrError.Equals("True"))
                                   //{
                                   //    objdbhims.Query = "update dc_tpatient_bookingm set discount_amt=ifnull(discount_amt,0)+" + StrDiscount_Amt_Test + " where bookingid=" + StrBookingID + "";


                                   //    StrError = objTrans.DataTrigger_Update(objdbhims);


                                       if (StrError.Equals("True"))
                                       {
                                           objTrans.End_Transaction();
                                           StrError = objTrans.OperationError;
                                           return false;
                                       }
                                       else
                                       {
                                           objTrans.End_Transaction();
                                           return true;
                                       }
                                  // }
                                   //else
                                   //{
                                   //    StrError = objTrans.OperationError;
                                   //    objTrans.End_Transaction();
                                   //    return false;
                                   //}
                               }
                               else
                               {
                                   StrError = objTrans.OperationError;
                                   objTrans.End_Transaction();
                                   return false;
                               }

                           }
                           else
                           {
                               objTrans.End_Transaction();
                               return true;
                           }
                       }
                       else
                       {
                           StrError = objTrans.OperationError;
                           objTrans.End_Transaction();
                           return false;
                       }
                   }
                   else
                   {
                       StrError = objTrans.OperationError;
                       objTrans.End_Transaction();
                       return false;
                   }
               }
               else
               {
                   StrError = objTrans.OperationError;
                   objTrans.End_Transaction();
                   return false;
               }
           }
           else
           {
               StrError = objTrans.OperationError;
               objTrans.End_Transaction();
               return false;
           }

       }

       private string[,] MakeArray()
       {
           string[,] kdc_arr = new string[11, 3];

           if (!StrBookingID.Equals(Default))
           {
               kdc_arr[0, 0] = "bookingid";
               kdc_arr[0, 1] = this.StrBookingID;
               kdc_arr[0, 2] = "int";
           }
           if (!StrPRID.Equals(Default))
           {
               kdc_arr[1, 0] = "prid";
               kdc_arr[1, 1] = this.StrPRID;
               kdc_arr[1, 2] = "int";
           }
           if (!StrLabID.Equals(Default))
           {
               kdc_arr[2, 0] = "labid";
               kdc_arr[2, 1] = this.StrLabID;
               kdc_arr[2, 2] = "string";
           }
           if (!StrReceiveNo.Equals(Default))
           {
               kdc_arr[3, 0] = "receiveno";
               kdc_arr[3, 1] = this.StrReceiveNo;
               kdc_arr[3, 2] = "string";
           }
           if (!StrPaymentMode.Equals(Default))
           {
               kdc_arr[4, 0] = "paymentmode";
               kdc_arr[4, 1] = this.StrPaymentMode;
               kdc_arr[4, 2] = "string";
           }
           if (!StrTotalAmount.Equals(Default))
           {
               kdc_arr[5, 0] = "totalamount";
               kdc_arr[5, 1] = this.StrTotalAmount;
               kdc_arr[5, 2] = "int";
           }
           if (!StrPaidAmount.Equals(Default))
           {
               kdc_arr[6, 0] = "paidamount";
               kdc_arr[6, 1] = this.StrPaidAmount;
               kdc_arr[6, 2] = "int";
           }
           if (!StrPanelID.Equals(Default))
           {
               kdc_arr[7, 0] = "panelid";
               kdc_arr[7, 1] = this.StrPanelID;
               kdc_arr[7, 2] = "int";
           }
           if (!StrEnteredBy.Equals(Default))
           {
               kdc_arr[8, 0] = "enteredby";
               kdc_arr[8, 1] = this.StrEnteredBy;
               kdc_arr[8, 2] = "int";
           }
           if (!StrEnteredOn.Equals(Default))
           {
               kdc_arr[9, 0] = "enteredon";
               kdc_arr[9, 1] = this.StrEnteredOn;
               kdc_arr[9, 2] = "datetime";
           }
           if (!StrClientID.Equals(Default))
           {
               kdc_arr[10, 0] = "clientid";
               kdc_arr[10, 1] = this.StrClientID;
               kdc_arr[10, 2] = "string";
           }
           return kdc_arr;
       }

       public bool Cash_Refund(string[,] str)
       {
           QueryBuilder ObjQB = new QueryBuilder();

           objTrans.Start_Transaction();

           objdbhims.Query = "SELECT lpad(ifnull(max(substr(e.refundno,9,7)),0)+1,7,0) as maxid FROM dc_tcashrefund e where substr(e.refundno,6,2)= date_format(current_date,'%y') and substr(e.refundno,2,3)='" + StrBranchID + "'";
           StrRefundNo = this.objTrans.DataTrigger_Get_Max(objdbhims);

           if (!StrRefundNo.Equals("True"))
           {
               StrRefundNo = "F" + StrBranchID + "-" + System.DateTime.Now.ToString("yy") + "-" + StrRefundNo;

               for (int i = 0; i <= str.GetUpperBound(0); i++)
               {
                   StrTestID = str[i, 0];
                   StrBookingDID = str[i, 1]; // previous classificationid
                   //if (StrClassificationID == "" || StrClassificationID == null)
                   //    StrClassificationID = "null";                   

                   StrPaidAmount = str[i, 2];
                   StrDiscount_Amt_Test = str[i, 3];
                   StrTotalAmount = str[i, 4];

                   objdbhims.Query = ObjQB.QBInsert(MakeArray_Refund(), "dc_tcashrefund");
                   StrError = objTrans.DataTrigger_Insert(objdbhims);

                   if (!StrError.Equals("True"))
                   {
                       if (StrRefundType.Equals("C"))
                       {
                           objdbhims.Query = "update dc_tpatient_bookingd set status='X',processid=9 where bookingid=" + StrBookingID + " and testid=" + StrTestID + " and bookingdid = " + StrBookingDID + "";
                           StrError = objTrans.DataTrigger_Update(objdbhims);
                           if (StrError.Equals("True"))
                           {
                               objTrans.End_Transaction();
                               StrError = objTrans.OperationError;
                               return false;
                           }
                           else
                           {
                               objdbhims.Query = "update dc_tpatient_bookingm set refund_amt=ifnull(refund_amt,0)+" + StrPaidAmount + " where bookingid=" + StrBookingID + "";
                               StrError = objTrans.DataTrigger_Update(objdbhims);
                           }

                       }
                       else if (StrRefundType.Equals("D") || StrRefundType.Equals("B"))
                       {
                           objdbhims.Query = "update dc_tpatient_bookingm set refund_amt=ifnull(refund_amt,0)+" + StrPaidAmount + " where bookingid=" + StrBookingID + "";
                           StrError = objTrans.DataTrigger_Update(objdbhims);
                       }




                       if (StrError.Equals("True"))
                       {
                           objTrans.End_Transaction();
                           StrError = objTrans.OperationError;
                           return false;
                       }
                       else
                       {
                           objdbhims.Query = "insert into dc_tstatustrack (labid,processid,testid,enteredby,enteredon,clientid,bookingdid) values ('" + StrLabID + "',9," + StrTestID + "," + StrEnteredBy + ",str_to_date('" + StrEnteredOn + "','%d/%m/%Y %h:%i:%s %p')," + StrClientID + "," + StrBookingDID + ") ";
                           StrError = objTrans.DataTrigger_Insert(objdbhims);
                           if (StrError.Equals("True"))
                           {
                               StrError = objTrans.OperationError;
                               objTrans.End_Transaction();
                               return false;
                           }
                       }

                   }
                   else
                   {
                       objTrans.End_Transaction();
                       StrError = objTrans.OperationError;
                       return false;
                   }
               }
               if (!StrError.Equals("True"))
               {
                   objTrans.End_Transaction();
                   return true;
               }
               else
               {
                   objTrans.End_Transaction();
                   StrError = objTrans.OperationError;
                   return false;
               }
           }
           else
           {
               objTrans.End_Transaction();
               StrError = objTrans.OperationError;
               return false;
           }


           return false;
       }

       private string[,] MakeArray_Refund()
       {
           string[,] kdc_arr = new string[17,3];

           if (!StrRefundID.Equals(Default))
           {
               kdc_arr[0, 0] = "refundid";
               kdc_arr[0, 1] = this.StrRefundID;
               kdc_arr[0, 2] = "int";
           }
           if (!StrRefundNo.Equals(Default))
           {
               kdc_arr[1, 0] = "refundno";
               kdc_arr[1, 1] = this.StrRefundNo;
               kdc_arr[1, 2] = "string";
           }
           if (!StrBookingID.Equals(Default))
           {
               kdc_arr[2, 0] = "bookingid";
               kdc_arr[2, 1] = this.StrBookingID;
               kdc_arr[2, 2] = "int";
           }
           if (!StrReceiveNo.Equals(Default))
           {
               kdc_arr[3, 0] = "receiveno";
               kdc_arr[3, 1] = this.StrReceiveNo;
               kdc_arr[3, 2] = "string";
           }
           if (!StrPRID.Equals(Default))
           {
               kdc_arr[4, 0] = "prid";
               kdc_arr[4, 1] = this.StrPRID;
               kdc_arr[4, 2] = "int";
           }
           if (!StrTestID.Equals(Default))
           {
               kdc_arr[5, 0] = "testid";
               kdc_arr[5, 1] = this.StrTestID;
               kdc_arr[5, 2] = "int";
           }
           if (!StrLabID.Equals(Default))
           {
               kdc_arr[6, 0] = "labid";
               kdc_arr[6, 1] = this.StrLabID;
               kdc_arr[6, 2] = "string";
           }
           if (!StrRefundType.Equals(Default))
           {
               kdc_arr[7, 0] = "refundtype";
               kdc_arr[7, 1] = this.StrRefundType;
               kdc_arr[7, 2] = "string";
           }
           if (!StrAuthorizedBy.Equals(Default))
           {
               kdc_arr[8, 0] = "authorizedby";
               kdc_arr[8, 1] = this.StrAuthorizedBy;
               kdc_arr[8, 2] = "int";
           }
           if (!StrComment.Equals(Default))
           {
               kdc_arr[9, 0] = "comments";
               kdc_arr[9, 1] = this.StrComment;
               kdc_arr[9, 2] = "string";
           }
           if (!StrTotalAmount.Equals(Default))
           {
               kdc_arr[10, 0] = "totalamount";
               kdc_arr[10, 1] = this.StrTotalAmount;
               kdc_arr[10, 2] = "int";
           }
           if (!StrPaidAmount.Equals(Default))
           {
               kdc_arr[11, 0] = "paidamount";
               kdc_arr[11, 1] = this.StrPaidAmount;
               kdc_arr[11, 2] = "int";
           }
           if (!StrEnteredBy.Equals(Default))
           {
               kdc_arr[12, 0] = "enteredby";
               kdc_arr[12, 1] = this.StrEnteredBy;
               kdc_arr[12, 2] = "int";
           }
           if (!StrEnteredOn.Equals(Default))
           {
               kdc_arr[13, 0] = "enteredon";
               kdc_arr[13, 1] = this.StrEnteredOn;
               kdc_arr[13, 2] = "datetime";
           }
           if (!StrClientID.Equals(Default))
           {
               kdc_arr[14, 0] = "clientid";
               kdc_arr[14, 1] = this.StrClientID;
               kdc_arr[14, 2] = "string";
           }
           if (!StrClassificationID.Equals(Default))
           {
               kdc_arr[15, 0] = "classificationid";
               kdc_arr[15, 1] = this.StrClassificationID;
               kdc_arr[15, 2] = "int";
           }
           kdc_arr[16, 0] = "type";
           kdc_arr[16, 1] = "R";
           kdc_arr[16, 2] = "string";
           return kdc_arr;
       }

       public bool Cash_Close()
       {
           QueryBuilder objQB = new QueryBuilder();

           objTrans.Start_Transaction();

           objdbhims.Query = "SELECT lpad(ifnull(max(substr(e.reportno,4,5)),0)+1,5,0) as maxid FROM dc_tcashreport e where substr(e.reportno,1,2)= date_format(current_date,'%y') ";
           StrReportNo = this.objTrans.DataTrigger_Get_Max(objdbhims);

           if (!StrReportNo.Equals("True"))
           {
               StrReportNo = System.DateTime.Now.ToString("yy") + "-" + StrReportNo;

               objdbhims.Query = "insert into dc_tcashreport (reportno,cashierid,enteredby,enteredon,clientid) values ('"+StrReportNo+"',"+StrEnteredBy+","+StrEnteredBy+",str_to_date('"+StrEnteredOn+"','%d/%m/%Y %h:%i:%s %p'),'"+StrClientID+"')";
               StrError = objTrans.DataTrigger_Insert(objdbhims);

               if (!StrError.Equals("True"))
               {
                   objdbhims.Query = "update dc_tcashcollection set reportno='"+StrReportNo+"' where enteredby="+StrEnteredBy+" and reportno is null";
                   StrError = objTrans.DataTrigger_Update(objdbhims);

                   if (!StrError.Equals("True"))
                   {
                       objdbhims.Query = "update dc_tcashrefund set reportno='"+StrReportNo+"' where enteredby="+StrEnteredBy+" and reportno is null";
                       StrError = objTrans.DataTrigger_Update(objdbhims);

                       if (!StrError.Equals("True"))
                       {
                           objTrans.End_Transaction();
                           return true;
                       }
                       else
                       {
                           objTrans.End_Transaction();
                           StrError = objTrans.OperationError;
                           return false;
                       }
                   }
                   else
                   {
                       objTrans.End_Transaction();
                       StrError = objTrans.OperationError;
                       return false;
                   }
               }
               else
               {
                   objTrans.End_Transaction();
                   StrError = objTrans.OperationError;
                   return false;
               }
           }
           else
           {
               objTrans.End_Transaction();
               StrError = objTrans.OperationError;
               return false;
           }

       }

       #endregion

   }
}
