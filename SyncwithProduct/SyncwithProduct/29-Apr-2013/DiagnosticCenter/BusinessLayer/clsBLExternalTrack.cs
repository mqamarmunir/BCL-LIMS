using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataLayer;

namespace BusinessLayer
{
   public class clsBLExternalTrack
    {
       clsdbhims objdbhims = new clsdbhims();
       clsoperation objTrans = new clsoperation();

       #region "Variable"

       private const string Default = "~!@";
       private string StrError = Default;

       private string StrOutID = Default;
       private string StrLabID = Default;
       private string StrPatientName = Default;
       private string StrTestID = Default;

       private string StrFromDate = Default;
       private string StrToDate = Default;

       private string StrSend_time = Default;
       private string StrRec_time = Default;
       private string StrComment = Default;

       private string StrOrgID = Default;
       private string StrOriginal_Org = Default;
       private string StrEnteredBy = Default;
       private string StrEnteredOn = Default;

       private string StrClientID = Default;
       private string _BranchID = Default;

     
       #endregion

       #region"Properties"

       public string Error
       {
           get { return StrError; }
           set { StrError = value; }
       }
       public string OutID
       {
           get { return StrOutID; }
           set { StrOutID = value; }
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
       public string TestID
       {
           get { return StrTestID; }
           set { StrTestID = value; }
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

       public string Send_Time
       {
           get { return StrSend_time; }
           set { StrSend_time = value; }
       }
       public string Rec_Time
       {
           get { return StrRec_time; }
           set { StrRec_time = value; }
       }
       public string Comment
       {
           get { return StrComment; }
           set { StrComment = value; }
       }

       public string OrgID
       {
           get { return StrOrgID; }
           set { StrOrgID = value; }
       }
       public string Original_Org
       {
           get { return StrOriginal_Org; }
           set { StrOriginal_Org = value; }
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
       public string BranchID
       {
           get { return _BranchID; }
           set { _BranchID = value; }
       }
       #endregion

       #region"Method"

       public DataView GetAll(int flag)
       {
           switch (flag)
           {
               case 1: // fill sending test
                   //////////////After Including Branhces////////////////////////
                   objdbhims.Query = @"SELECT d.bookingdid, d.bookingid,d.labid,d.processid,p.prno,
                                    concat(ifnull(p.title,''),' ',p.name,' ( ',case when p.gender='M' then 'Male' else 'Female' end,
                                    ' : ',case when DATEDIFF(CURRENT_DATE,p.dob) > 365 then
                                    concat(Floor(DATEDIFF(CURRENT_DATE,p.dob)/365),' Yrs')  else
                                    case when DATEDIFF(CURRENT_DATE,p.dob) > 30 then
                                    concat(Floor(DATEDIFF(CURRENT_DATE,p.dob)/30),' Mon')
                                    else concat(DATEDIFF(CURRENT_DATE,p.dob),'Dys') end end,' ) ') as patientname,
                                    gm.name as groupname,m.authorizeno,pn.name as panel,
                                    concat(t.test_name,' ',ifnull(c.name,'')) as test_name,d.testid,og.name as location,
                                    date_format(m.enteredon,'%d/%m/%Y %h:%i %p') as bookon,
                                    date_format(d.deliverytime,'%d/%m/%Y %h:%i %p') as deliverytime,
                                    d.clientid as original_org,t.external_org,ifnull(oc.acronym,'-') as origin1,
                                    tb.Name as origin

                                    FROM dc_tpatient_bookingd d left outer join dc_tpatient_bookingm m on d.bookingid=m.bookingid
                                    left outer join dc_tpatient p on p.prid=m.prid
                                    left outer join dc_tp_test t on d.testid=t.testid
                                    left outer join dc_tp_groupm gm on t.groupid = gm.groupid
                                    left outer join dc_tpanel pn on p.panelid = pn.panelid
                                    left outer join dc_tp_tclass c on t.testid = c.testid
                                    left outer join dc_tp_organization og on og.orgid=t.external_org
                                    left outer join dc_toutside_test ot on ot.labid=m.labid and ot.testid=t.testid
                                    left outer join dc_Tp_organization oc on oc.orgid=d.clientid
                                    left outer join dc_tp_branch tb on tb.BranchID=m.BranchID

                                    where d.processid in(4,5) and t.external='Y' and (d.DestinationbranchID=" + Convert.ToInt32(_BranchID) + @" or  m.BranchID="+Convert.ToInt32(_BranchID)+@")
                                    
                                    and t.external_org not in ('006','008')
                                    and ot.sendon is null
                                    and date_format(m.enteredon,'%Y/%m/%d') between '" + StrFromDate + "' and '" + StrToDate + "'";
                   if (!StrOrgID.Equals(Default) && !StrOrgID.Equals(""))
                       objdbhims.Query += " and d.clientid='" + StrOrgID + "'";
                   //////////////////--------------//////////////////////
                   break;

                   //objdbhims.Query = "SELECT d.bookingdid, d.bookingid,d.labid,d.processid,p.prno,concat(ifnull(p.title,''),' ',p.name,' ( ',case when p.gender='M' then 'Male' else 'Female' end,' : ', case when DATEDIFF(CURRENT_DATE,p.dob) > 365 then concat(Floor(DATEDIFF(CURRENT_DATE,p.dob)/365),' Yrs')  else case when DATEDIFF(CURRENT_DATE,p.dob) > 30 then concat(Floor(DATEDIFF(CURRENT_DATE,p.dob)/30),' Mon') else      concat(DATEDIFF(CURRENT_DATE,p.dob),'Dys') end end,' ) ')   as patientname,gm.name as groupname,m.authorizeno,pn.name as panel,concat(t.test_name,' ',ifnull(c.name,'')) as test_name,d.testid,og.name as location,date_format(m.enteredon,'%d/%m/%Y %h:%i %p') as bookon,date_format(d.deliverytime,'%d/%m/%Y %h:%i %p') as deliverytime,d.clientid as original_org,t.external_org,ifnull(oc.acronym,'-') as origin     FROM dc_tpatient_bookingd d left outer join dc_tpatient_bookingm m on d.bookingid=m.bookingid     left outer join dc_tpatient p on p.prid=m.prid left outer join dc_tp_test t on d.testid=t.testid       left outer join dc_tp_groupm gm on t.groupid = gm.groupid left outer join dc_tpanel pn on p.panelid = pn.panelid left outer join dc_tp_tclass c on t.testid = c.testid left outer join dc_tp_organization og on og.orgid=t.external_org left outer join dc_toutside_test ot on ot.labid=m.labid and ot.testid=t.testid left outer join dc_Tp_organization oc on oc.orgid=d.clientid where d.processid=4 and t.external='Y' and t.external_org not in ('006','008') and ot.sendon is  null and date_format(m.enteredon,'%Y/%m/%d') between '" + StrFromDate + "' and '" + StrToDate + "'";
                   //if (!StrOrgID.Equals(Default) && !StrOrgID.Equals(""))
                   //    objdbhims.Query += " and d.clientid='" + StrOrgID + "'";


                   
               case 2: // fill sending test

                   ////////////////After catering branches//////////////////
                   objdbhims.Query = @"SELECT d.bookingdid, d.bookingid,d.labid,d.processid,p.prno,
                                        concat(ifnull(p.title,''),' ',p.name,' ( ',case when p.gender='M' then 'Male' else 'Female' end,' : ',
                                        case when DATEDIFF(CURRENT_DATE,p.dob) > 365 then concat(Floor(DATEDIFF(CURRENT_DATE,p.dob)/365),' Yrs')  else
                                        case when DATEDIFF(CURRENT_DATE,p.dob) > 30 then concat(Floor(DATEDIFF(CURRENT_DATE,p.dob)/30),' Mon')
                                        else concat(DATEDIFF(CURRENT_DATE,p.dob),'Dys') end end,' ) ')   as patientname,
                                        gm.name as groupname,m.authorizeno,pn.name as panel,
                                        concat(t.test_name,' ',ifnull(c.name,'')) as test_name,
                                        d.testid,og.name as location,date_format(m.enteredon,'%d/%m/%Y %h:%i %p') as bookon,
                                        date_format(d.deliverytime,'%d/%m/%Y %h:%i %p') as deliverytime,
                                        date_format(ot.receive_time,'%d/%m/%Y %H:%i') as receive_time,
                                        date_format(ot.send_time,'%d/%m/%Y') as send_date,
                                        date_format(ot.send_time,'%H:%i') as send_time,ot.original_org,
                                        date_format(ot.send_time,'%d/%m/%Y %H:%i') as sendon,ot.outid,ot.orgid,
                                        date_format(ot.receive_time,'%d/%m/%Y') as rec_date,
                                        date_format(ot.receive_time,'%H:%i') as rec_time,ifnull(oc.acronym,'-') as origin1,
                                        case when ps.processid =8 then 'Delivered' else ps.name end as process,d.processid,
                                        tb.Name as Origin

                                        FROM dc_tpatient_bookingd d left outer join dc_tpatient_bookingm m on d.bookingid=m.bookingid
                                        left outer join dc_tpatient p on p.prid=m.prid
                                        left outer join dc_tp_test t on d.testid=t.testid
                                        left outer join dc_tp_groupm gm on t.groupid = gm.groupid
                                        left outer join dc_tpanel pn on p.panelid = pn.panelid
                                        left outer join dc_tp_tclass c on t.testid = c.testid
                                        left outer join dc_toutside_test ot on ot.labid=m.labid and ot.testid=t.testid
                                        left outer join dc_tp_organization og on og.orgid=ot.orgid
                                        left outer join dc_Tp_organization oc on oc.orgid=d.clientid
                                        left outer join dc_tp_tprocess ps on ps.processid=d.processid
                                        left outer join dc_tp_Branch tb on m.BranchID=tb.BranchID

                                        where  t.external='Y' and t.external_org not in ('006','008')
                                        and (d.DestinationBranchID="+Convert.ToInt32(_BranchID)+@" or m.BranchID="+Convert.ToInt32(_BranchID)+@")
                                        and ot.sendon is not null
                                        and date_format(m.enteredon,'%Y/%m/%d') between '" + StrFromDate + "' and '" + StrToDate + "'";
                   if (!StrOrgID.Equals(Default) && !StrOrgID.Equals(""))
                       objdbhims.Query += " and d.clientid='" + StrOrgID + "'";  
               /////////////////-------------///////////////////////
                   break;

                   //objdbhims.Query = "SELECT d.bookingdid, d.bookingid,d.labid,d.processid,p.prno,concat(ifnull(p.title,''),' ',p.name,' ( ',case when p.gender='M' then 'Male' else 'Female' end,' : ', case when DATEDIFF(CURRENT_DATE,p.dob) > 365 then concat(Floor(DATEDIFF(CURRENT_DATE,p.dob)/365),' Yrs')  else case when DATEDIFF(CURRENT_DATE,p.dob) > 30 then concat(Floor(DATEDIFF(CURRENT_DATE,p.dob)/30),' Mon') else      concat(DATEDIFF(CURRENT_DATE,p.dob),'Dys') end end,' ) ')   as patientname,gm.name as groupname,m.authorizeno,pn.name as panel,concat(t.test_name,' ',ifnull(c.name,'')) as test_name,d.testid,og.name as location,date_format(m.enteredon,'%d/%m/%Y %h:%i %p') as bookon,date_format(d.deliverytime,'%d/%m/%Y %h:%i %p') as deliverytime,date_format(ot.receive_time,'%d/%m/%Y %H:%i') as receive_time,date_format(ot.send_time,'%d/%m/%Y') as send_date,date_format(ot.send_time,'%H:%i') as send_time,ot.original_org,date_format(ot.send_time,'%d/%m/%Y %H:%i') as sendon,ot.outid,ot.orgid,date_format(ot.receive_time,'%d/%m/%Y') as rec_date,date_format(ot.receive_time,'%H:%i') as rec_time,ifnull(oc.acronym,'-') as origin,case when ps.processid =8 then 'Delivered' else ps.name end as process,d.processid    FROM dc_tpatient_bookingd d left outer join dc_tpatient_bookingm m on d.bookingid=m.bookingid     left outer join dc_tpatient p on p.prid=m.prid left outer join dc_tp_test t on d.testid=t.testid       left outer join dc_tp_groupm gm on t.groupid = gm.groupid left outer join dc_tpanel pn on p.panelid = pn.panelid left outer join dc_tp_tclass c on t.testid = c.testid  left outer join dc_toutside_test ot on ot.labid=m.labid and ot.testid=t.testid left outer join dc_tp_organization og on og.orgid=ot.orgid left outer join dc_Tp_organization oc on oc.orgid=d.clientid left outer join dc_tp_tprocess ps on ps.processid=d.processid where  t.external='Y' and t.external_org not in ('006','008') and ot.sendon is not null  and date_format(m.enteredon,'%Y/%m/%d') between '" + StrFromDate + "' and '" + StrToDate + "'";
                   //if (!StrOrgID.Equals(Default) && !StrOrgID.Equals(""))
                   //    objdbhims.Query += " and d.clientid='" + StrOrgID + "'";


                  
               case 3: // fill external org
                   objdbhims.Query = "select orgid,name from dc_tp_organization where active='Y' and external='Y'";
                   break;
               case 4: // external test receipt
                   objdbhims.Query = "select m.labid,d.totalamount as charges,t.test_name as testname, concat(ifnull(pp.title,''),' ',pp.name) as patient, pp.prno, d.deliverytime ,og.name as organization,og.phoneno,date_format(pp.dob,'%d/%m/%Y') as dob,case when pp.gender='M' then 'Male' else 'Female' end as gender,d.testid,m.bookingid,m.prid,pn.panelid,pn.name as panelname,ifnull(m.authorizeno,'') as authorizeno,ifnull(pp.serviceno,'') as serviceno,case when pp.address is null or pp.address='' then '-' else pp.address end as address,m.enteredon,case when DATEDIFF(CURRENT_DATE,pp.dob) > 365 then      concat(Floor(DATEDIFF(CURRENT_DATE,pp.dob)/365),' (Y)') else    case when DATEDIFF(CURRENT_DATE,pp.dob) > 30 then     concat(Floor(DATEDIFF(CURRENT_DATE,pp.dob)/30),' (M)')     else      concat(DATEDIFF(CURRENT_DATE,pp.dob),'(D)')    end  end  AS age,     case when m.doctorid is null or m.doctorid='' then     m.referredby else concat(ifnull(dr.title,''),' ',dr.name) end as consultant,m.discount_amt,     pp.cellno,pp.hphone,dr.code,m.referenceno,t.external,t.speedkey,pp.pasword,m.remarks,m.payment_mode as M_Bmode,ot.send_time,ot.receive_time,ot.comment,ot.outid,concat(per.salutation,per.fname,ifnull(per.mname,''),ifnull(per.lname,'')) as sendby from  dc_tpatient_bookingm m join dc_tpatient_bookingd d on m.bookingid = d.bookingid join dc_tp_test t on d.testid = t.testid join dc_tpatient pp on m.prid = pp.prid left outer join dc_tpanel pn on m.panelid= pn.panelid left outer join dc_tp_refdoctors dr on dr.doctorid=m.doctorid join dc_toutside_test ot on ot.labid=m.labid left outer join dc_tp_organization og on ot.orgid = og.orgid and ot.testid=t.testid left outer join dc_Tp_personnel per on per.personid= ot.sendby where  ot.labid='" + StrLabID + "' and ot.testid=" + StrTestID + "";
                   break;
           }
           return objTrans.DataTrigger_Get_All(objdbhims);
       }

       public bool Send_Inv()
       {
           objTrans.Start_Transaction();

           objdbhims.Query = "insert into dc_toutside_test (labid,testid,orgid,original_org,send_time,sendby,sendon,receive_time,status,clientid,comment) values ('" + StrLabID + "'," + StrTestID + ",'" + StrOrgID + "','" + StrOriginal_Org + "',str_to_date('" + StrSend_time + "','%d/%m/%Y %H:%i')," + StrEnteredBy + ",str_to_date('" + StrEnteredOn + "','%d/%m/%Y %h:%i:%s %p'),str_to_date('" + StrRec_time + "','%d/%m/%Y %H:%i'),'S','" + StrClientID + "','" + StrComment + "')";
           StrError = objTrans.DataTrigger_Insert(objdbhims);

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
       }

       public bool Rec_Inv()
       {
           objTrans.Start_Transaction();

           objdbhims.Query = "update dc_toutside_test set  send_time=str_to_date('" + StrSend_time + "','%d/%m/%Y %H:%i'),sendby=" + StrEnteredBy + ", sendon=str_to_date('" + StrEnteredOn + "','%d/%m/%Y %h:%i:%s %p'), clientid='" + StrClientID + "',receive_time=str_to_date('" + StrRec_time + "','%d/%m/%Y %H:%i'), orgid='"+StrOrgID+"' where labid='" + StrLabID + "' and testid='" + StrTestID + "' and outid=" + StrOutID + "";
           StrError = objTrans.DataTrigger_Update(objdbhims);


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
       }

       #endregion


   }
}
