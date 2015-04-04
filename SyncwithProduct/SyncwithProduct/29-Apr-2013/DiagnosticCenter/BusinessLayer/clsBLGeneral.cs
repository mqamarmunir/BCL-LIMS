using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataLayer;

namespace BusinessLayer
{
   public class clsBLGeneral
   {
       clsoperation objTrans = new clsoperation();
       clsdbhims objdbhims = new clsdbhims();

       #region "Variables"

       private const string TableName = "";
       private const string Default = "~!@";
       private string StrError = Default;

       private string StrBookingID = Default;
       private string StrPRNo = Default;
       private string StrLabID = Default;

       private string StrFromDate = Default;
       private string StrToDate = Default;

       private string StrEnteredBy = Default;
       private string StrEnteredOn = Default;
       private string StrClientID = Default;

       private string StrReceiveNo = Default;
       private string StrRefundNo = Default;

       private string StrPatientName = Default;
       private string StrPanelID = Default;
       private string StrAuthorizeNo = Default;

       private string StrConsultantID = Default;
       private string StrConult_Name = Default;

       private string _BranchID = Default;


       
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
       public string PRNo
       {
           get { return StrPRNo; }
           set { StrPRNo = value; }
       }
       public string LabID
       {
           get { return StrLabID; }
           set { StrLabID = value; }
       }
       public string PatientName
       {
           get { return StrPatientName; }
           set { StrPatientName = value; }
       }

       public string FromDate
       {
           get { return StrFromDate; }
           set { StrFromDate = value; }
       }
       public string ToDate
       {
           get { return StrToDate; }
           set { StrToDate = value; }
       }

       public string EnteredBy
       {
           get { return StrEnteredBy; }
           set { StrEnteredBy = value; }
       }
       public string EnteredOn
       {
           get { return StrEnteredOn; }
           set { StrEnteredOn = value; }
       }
       public string ClientID
       {
           get { return StrClientID; }
           set { StrClientID = value; }
       }

       public string ReceiveNo
       {
           get { return StrReceiveNo; }
           set { StrReceiveNo = value; }
       }
       public string RefundNo
       {
           get { return StrRefundNo; }
           set { StrRefundNo = value; }
       }
       public string AuthorizeNo
       {
           get { return StrAuthorizeNo; }
           set { StrAuthorizeNo = value; }
       }
       public string PanelID
       {
           get { return StrPanelID; }
           set { StrPanelID = value; }
       }

       public string ConsultantID
       {
           get { return StrConsultantID; }
           set { StrConsultantID = value; }
       }
       public string Consult_Name
       {
           get { return StrConult_Name; }
           set { StrConult_Name = value; }
       }
       public string BranchID
       {
           get { return _BranchID; }
           set { _BranchID = value; }
       }


       #endregion

       #region "Method"

       public DataView GetAll(int flag)
       {
           switch (flag)
           {
               case 1: // fill authorize number for update
                   objdbhims.Query = "select p.prno,concat(ifnull(p.title,''),'.',p.name) as patientname,pn.name as panelname,m.labid,date_format(m.enteredon,'%d/%m/%Y') as bookingdate,m.bookingid,og.acronym as origin1,tb.Name origin,(case when m.type='I' then concat(w.name,':', m.adm_ref) else '-' end) as adm_info from dc_tpatient p left outer join dc_tpatient_bookingm m on p.prid = m.prid left outer join dc_tpanel pn on p.panelid=pn.panelid left outer join dc_tp_organization og on og.orgid=m.clientid left outer join dc_tp_ward w on w.wardid=m.wardid left outer join dc_tp_branch tb on tb.branchID=m.BranchID where m.authorizeno is null and m.BranchID="+Convert.ToInt32(_BranchID)+" and p.panelid >0 and date_format(m.enteredon,'%Y-%m-%d') between '" + StrFromDate + "' and '" + StrToDate + "'";
                   if (!StrPRNo.Equals(Default) && !StrPRNo.Equals("") && !StrPRNo.Equals("___-__-________"))
                       objdbhims.Query += " and p.prno='"+StrPRNo+"'";
                   if (!StrPatientName.Equals(Default) && !StrPatientName.Equals(""))
                       objdbhims.Query += " and p.name like '%"+StrPatientName+"%'";
                   if (!StrPanelID.Equals(Default) && !StrPanelID.Equals("-1"))
                       objdbhims.Query += " and p.panelid="+StrPanelID+"";
                   break;
               case 2: // fill cash received for reprint
                   objdbhims.Query = "select p.prno,concat(ifnull(p.title,''),' ',p.name) as patientname,m.labid,date_format(m.enteredon,'%d/%m/%Y') as receiptdate,m.bookingid,c.receiveno as receiptno,ifnull(c.paidamount,0) as paidamount,'C' as type,og.acronym as origin1,tb.Name origin,(case when m.type='I' then concat(w.name,':', m.adm_ref) else '-' end) as adm_info from dc_tpatient p left outer join dc_tpatient_bookingm m on p.prid = m.prid left outer join dc_tcashcollection c on m.bookingid=c.bookingid left outer join dc_tp_organization og on og.orgid=m.clientid left outer join dc_tp_ward w on w.wardid=m.wardid left outer join dc_tp_branch tb on tb.BranchID=m.BranchID where m.BranchID="+Convert.ToInt32(_BranchID)+" and  date_format(c.enteredon,'%Y-%m-%d') between '" + StrFromDate + "' and '" + StrToDate + "'";
                   if (!StrPRNo.Equals(Default) && !StrPRNo.Equals("") && !StrPRNo.Equals("___-__-________"))
                       objdbhims.Query += " and p.prno='" + StrPRNo + "'";
                   if (!StrPatientName.Equals(Default) && !StrPatientName.Equals(""))
                       objdbhims.Query += " and p.name like '%" + StrPatientName + "%'";
                  
                   break;
               case 3: // fill refund for reprint
                   objdbhims.Query = "select p.prno,concat(ifnull(p.title,''),' ',p.name) as patientname,m.labid,date_format(m.enteredon,'%d/%m/%Y') as receiptdate,m.bookingid,c.refundno as receiptno,sum(ifnull(c.paidamount,0)) as paidamount,'R' as type,og.acronym as origin1,tb.Name origin,(case when m.type='I' then concat(w.name,':', m.adm_ref) else '-' end) as adm_info from dc_tpatient p left outer join dc_tpatient_bookingm m on p.prid = m.prid left outer join dc_tcashrefund c on m.bookingid=c.bookingid left outer join dc_tp_organization og on og.orgid=m.clientid left outer join dc_tp_ward w on w.wardid=m.wardid left outer join dc_tp_branch tb on tb.BranchID=m.BranchID where m.BranchID="+Convert.ToInt32(_BranchID)+" and date_format(c.enteredon,'%Y-%m-%d') between '" + StrFromDate + "' and '" + StrToDate + "'";
                   if (!StrPRNo.Equals(Default) && !StrPRNo.Equals("") && !StrPRNo.Equals("___-__-________"))
                       objdbhims.Query += " and p.prno='" + StrPRNo + "'";
                   if (!StrPatientName.Equals(Default) && !StrPatientName.Equals(""))
                       objdbhims.Query += " and p.name like '%" + StrPatientName + "%'";
                   objdbhims.Query += " group by c.refundno";
                 
                   break;
               case 4: // fill panel company drop down
                   objdbhims.Query = "select name ,panelid from dc_tpanel where active='Y'";
                   break;
               case 5: 
                   objdbhims.Query = "select p.prno,concat(ifnull(p.title,''),'.',p.name) as patientname,pn.name as panelname,m.labid,date_format(m.enteredon,'%d/%m/%Y') as bookingdate,m.bookingid,og.acronym as origin1, tb.Name origin,(case when m.type='I' then concat(w.name,':', m.adm_ref) else '-' end) as adm_info,m.doctorid,m.referredby from dc_tpatient p left outer join dc_tpatient_bookingm m on p.prid = m.prid left outer join dc_tpanel pn on p.panelid=pn.panelid left outer join dc_tp_organization og on og.orgid=m.clientid left outer join dc_tp_ward w on w.wardid=m.wardid left outer join dc_tp_branch tb on tb.BranchID=m.BranchID where m.authorizeno is null and p.panelid >0 and date_format(m.enteredon,'%Y-%m-%d') between '" + StrFromDate + "' and '" + StrToDate + "'";
                   if (!StrPRNo.Equals(Default) && !StrPRNo.Equals("") && !StrPRNo.Equals("___-__-________"))
                       objdbhims.Query += " and p.prno='" + StrPRNo + "'";
                   if (!StrPatientName.Equals(Default) && !StrPatientName.Equals(""))
                       objdbhims.Query += " and p.name like '%" + StrPatientName + "%'";
     
                   break;
               case 6: // get consultant
                   objdbhims.Query = "SELECT doctorid,concat(name,' ',title) as name FROM dc_tp_refdoctors d where active='Y'";
                   break;
           }
           return objTrans.DataTrigger_Get_All(objdbhims);
       }

       public bool Update_Authorize()
       {
           QueryBuilder objQB = new QueryBuilder();

           objTrans.Start_Transaction();

           objdbhims.Query = "update dc_tpatient_bookingm set authorizeno='"+StrAuthorizeNo+"' where bookingid="+StrBookingID+"";
           StrError = objTrans.DataTrigger_Update(objdbhims);

           if (StrError.Equals("True"))
           {
               StrError = objTrans.OperationError;
               objTrans.End_Transaction();
               return false;
           }
           else
           {
               objTrans.End_Transaction();
               return true;
           }
       }

       public bool Update_ConsultName()
       {
           objTrans.Start_Transaction();

           objdbhims.Query = "update dc_tpatient_bookingm set ";
           if (!StrConsultantID.Equals(Default) && !StrConsultantID.Equals("-1"))
               objdbhims.Query += " doctorid=" + StrConsultantID+" , referredby=null";
           else
               objdbhims.Query += " referredby='" + StrConult_Name + "' , doctorid=null";
           objdbhims.Query += " where bookingid=" + StrBookingID + " ";

           StrError = objTrans.DataTrigger_Update(objdbhims);
           if (StrError.Equals("True"))
           {
               StrError = objTrans.OperationError;
               objTrans.End_Transaction();
               return false;
           }
           else
           {
               objTrans.End_Transaction();
               return true;
           }
       }
       #endregion
   }
}
