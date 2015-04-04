using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataLayer;

namespace BusinessLayer
{
   public class clsBLWorkList
    {
       clsdbhims objdbhims = new clsdbhims();
       clsoperation objTrans = new clsoperation();

       #region"Variables"

       private const string TableName = "dc_tworklist";
       private const string Default = "~!@";

       private string StrError = Default;
       private string StrWorkListID = Default;
       private string StrWorkListNO = Default;

       private string StrSubDeptID = Default;
       private string StrProcessID = Default;

       private string StrEnteredBy = Default;
       private string StrEnteredOn = Default;
       private string StrClientID = Default;

       private string StrTestID = Default;
       private string StrBookingID = Default;
       private string StrBookingDID = Default;

       private string StrFromDate = Default;
       private string StrToDate = Default;
       private string StrLabID = Default;
       private string StrPlaceID = Default;

       private string _BranchID = Default;

     
       #endregion

       #region"Properties"

       public string Error 
       {
           get { return StrError; }
           set { StrError = value; }
       }
       public string WorkListID
       {
           get { return StrWorkListID; }
           set { StrWorkListID = value; }
       }
       public string WorkListNo
       {
           get { return StrWorkListNO; }
           set { StrWorkListNO = value; }
       }

       public string SubDeptID
       {
           get { return StrSubDeptID; }
           set { StrSubDeptID = value; }
       }
       public string ProcessID
       {
           get { return StrProcessID; }
           set { StrProcessID = value; }
       }

       public string EnteredBY
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

       public string TestID
       {
           get { return StrTestID; }
           set { StrTestID = value; }
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
       public string LabID
       {
           get { return StrLabID; }
           set { StrLabID = value; }
       }
       public string PlaceID
       {
           get { return StrPlaceID; }
           set { StrPlaceID = value; }
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
               case 1: // fill subdept
                   objdbhims.Query = "select subdepartmentid,name from dc_tp_subdepartments where active='Y'";
                   break;
               case 2:// new after catering branches
                   objdbhims.Query = @"SELECT d.bookingdid, d.bookingid,d.labid,d.processid,p.prno,concat(ifnull(p.title,''),'.',p.name) as patientname,p.DOB,case when p.gender='M' then 'Male' when p.gender='F' then 'Female' else '' end as Gender,case when DATEDIFF(CURRENT_DATE,p.dob) > 365 then concat(Floor(DATEDIFF(CURRENT_DATE,p.dob)/365),' Years')  else   case when DATEDIFF(CURRENT_DATE,p.dob) > 30 then    concat(Floor(DATEDIFF(CURRENT_DATE,p.dob)/30),' Month')    else      concat(DATEDIFF(CURRENT_DATE,p.dob),' Days')     end  end  AS age,gm.name as groupname,m.authorizeno,pn.name as panel,concat(t.test_name,' ',ifnull(c.name,'')) as testname,d.testid     FROM dc_tpatient_bookingd d left outer join dc_tpatient_bookingm m on d.bookingid=m.bookingid     left outer join dc_tpatient p on p.prid=m.prid left outer join dc_tp_test t on d.testid=t.testid       left outer join dc_tp_groupm gm on t.groupid = gm.groupid left outer join dc_tpanel pn on p.panelid = pn.panelid left outer join dc_tp_tclass c on t.testid = c.testid where d.processid=4 and ((m.BranchId=" + Convert.ToInt32(_BranchID) + @" and (d.DestinationbranchID=0 or d.DestinationBranchID is null)) or (d.DestinationBranchID=" + Convert.ToInt32(_BranchID) + @" and d.SendStatus='R'))";
                   if (!StrSubDeptID.Equals(Default) && !StrSubDeptID.Equals(""))
                               objdbhims.Query += " and d.testid in (select testid from dc_tp_test where subdepartmentid=" + StrSubDeptID + ")";
                   break;
               //case 2: // fill new list
               //    objdbhims.Query = "SELECT d.bookingdid, d.bookingid,d.labid,d.processid,p.prno,concat(ifnull(p.title,''),'.',p.name) as patientname,p.DOB,case when p.gender='M' then 'Male' when p.gender='F' then 'Female' else '' end as Gender,case when DATEDIFF(CURRENT_DATE,p.dob) > 365 then concat(Floor(DATEDIFF(CURRENT_DATE,p.dob)/365),' Years')  else   case when DATEDIFF(CURRENT_DATE,p.dob) > 30 then    concat(Floor(DATEDIFF(CURRENT_DATE,p.dob)/30),' Month')    else      concat(DATEDIFF(CURRENT_DATE,p.dob),' Days')     end  end  AS age,gm.name as groupname,m.authorizeno,pn.name as panel,concat(t.test_name,' ',ifnull(c.name,'')) as testname,d.testid     FROM dc_tpatient_bookingd d left outer join dc_tpatient_bookingm m on d.bookingid=m.bookingid     left outer join dc_tpatient p on p.prid=m.prid left outer join dc_tp_test t on d.testid=t.testid       left outer join dc_tp_groupm gm on t.groupid = gm.groupid left outer join dc_tpanel pn on p.panelid = pn.panelid left outer join dc_tp_tclass c on t.testid = c.testid where d.processid=4";
               //    /* Will use later*/
               //    //if (StrPlaceID.Equals("008"))
               //    //    objdbhims.Query += " and ((case when t.external_org is null then d.clientid='008' end) or t.external_org in ('" + StrPlaceID + "','-1')) ";
               //    //else if (StrPlaceID.Equals("006"))
               //    //{
               //    //    objdbhims.Query += " and ((case when t.external_org is null and t.external='N' then d.clientid='006' else t.external_org='006' end) or (case when t.external='Y' and t.external_org not in ('006','008') then d.testid in (select testid from dc_toutside_test where labid=m.labid   )  end))";
               //    //}
               //    //else if (StrPlaceID.Equals("006"))
               //    //    objdbhims.Query += " and (t.external_org<>'008' or (case when t.external_org is null then d.clientid='" + StrPlaceID + "' end))";
               //    if (!StrSubDeptID.Equals(Default) && !StrSubDeptID.Equals(""))
               //        objdbhims.Query += " and d.testid in (select testid from dc_tp_test where subdepartmentid=" + StrSubDeptID + ")";
               //    break;
               case 3: // fill previous list
                   objdbhims.Query = "select w.worklistid,w.worklistno,w.subdeptid,(select count(testid) from dc_tpatient_bookingd where worklistid=w.worklistid) as totaltest,concat(date_format(w.enteredon,'%d/%m/%Y'),' : ',p.salutation,p.fname,' ',ifnull(p.mname,''),' ',ifnull(p.lname,'')) as enteredon,s.name as subdept from dc_tworklist w left outer join dc_tp_personnel p on p.personid=w.enteredby left outer join dc_tp_subdepartments s on s.subdepartmentid=w.subdeptid where w.clientid='"+StrClientID+"' and w.BranchID="+Convert.ToInt32(_BranchID)+"  order by w.worklistno desc";
                   break;
               case 4: // fill report work list
                   objdbhims.Query = "SELECT  t.testid,d.bookingdid,d.bookingid,d.labid,d.processid,p.prno,concat(ifnull(p.title,''),'.',p.name) as patientname,p.DOB,case when p.gender='M' then 'Male' when p.gender='F' then 'Female' else '' end as Gender,case when DATEDIFF(CURRENT_DATE,p.dob) > 365 then concat(Floor(DATEDIFF(CURRENT_DATE,p.dob)/365),' Years')  else   case when DATEDIFF(CURRENT_DATE,p.dob) > 30 then    concat(Floor(DATEDIFF(CURRENT_DATE,p.dob)/30),' Month')    else      concat(DATEDIFF(CURRENT_DATE,p.dob),' Days')     end  end  AS age,gm.name as groupname,m.authorizeno,pn.name as panel,concat(t.test_name,' ',ifnull(c.name,'')) as testname,date_format(d.deliverytime,'%d/%m/%y %h:%i %p') as deliverytime,date_format(w.enteredon,'%d/%m/%y %h:%i %p') as enteredon,w.worklistno,date_format(m.enteredon,'%d/%m/%Y %h:%i %p') as bookedon,og.acronym as origin1,br.Name as origin     FROM dc_tpatient_bookingd d left outer join dc_tpatient_bookingm m on d.bookingid=m.bookingid     left outer join dc_tpatient p on p.prid=m.prid left outer join dc_tp_test t on d.testid=t.testid     left outer join dc_tp_groupm gm on t.groupid = gm.groupid left outer join dc_tpanel pn on p.panelid = pn.panelid left outer join dc_tp_tclass c on t.testid = c.testid left outer join dc_tworklist w on d.worklistid=w.worklistid left outer join dc_tp_organization og on og.orgid=m.clientid left outer join dc_tp_branch br on br.branchID=m.branchID where w.worklistno='" + StrWorkListNO + "'";
                   break;
               case 5: // fill pending record grid
                   ///////////////////////After catering branhches/////////////////////
                   objdbhims.Query = @"SELECT count(d.testid) as records,s.name as subdept,s.subdepartmentid as subdeptid,d.DestinationBranchID

                                        FROM dc_tpatient_bookingd d left outer join dc_tpatient_bookingm m on d.bookingid=m.bookingid
                                        left outer join dc_tpatient p on p.prid=m.prid
                                        left outer join dc_tp_test t on d.testid=t.testid
                                        left outer join dc_tp_tclass c on t.testid = c.testid
                                        left outer join dc_tp_subdepartments s on s.subdepartmentid=t.subdepartmentid

                                        where d.processid=4
                                        and ((m.BranchId=" + Convert.ToInt32(_BranchID) + @" and (d.DestinationbranchID=0 or d.DestinationBranchID is null)) or (d.DestinationBranchID=" + Convert.ToInt32(_BranchID) + @" and d.SendStatus='R'))";
               /*Will use later*/   
               //if (StrPlaceID.Equals("008"))
                   //    objdbhims.Query += "    and (( case when t.external_org is null then d.clientid='008' end) or t.external_org in ('" + StrPlaceID + "','-1'))";
                   //else if (StrPlaceID.Equals("006"))
                   //{
                   //    objdbhims.Query += " and ((case when t.external_org is null and t.external='N' then d.clientid='006' else t.external_org='006' end) or (case when t.external='Y' and t.external_org not in ('006','008') then d.testid in (select testid from dc_toutside_test where labid=m.labid   )  end))";
                   //    //objdbhims.Query += " and (t.external_org='006' or (case when t.external_org is null then d.clientid='006' end))";
                   //    //objdbhims.Query += " or (case when t.external='Y' and t.external_org not in ('006','008') then d.testid in (select testid from dc_toutside_test where labid=m.labid  ) end)";
                   //}
                   //else
                   //    objdbhims.Query += " and d.clientid='" + StrPlaceID + "'";
                   objdbhims.Query += "  group by s.name,s.subdepartmentid";
                   //////////////////////////////-----------./////////////////////
                   break;
               case 6:
                   objdbhims.Query = "Select Attribute_Name From dc_tp_Attributes a Where a.active = 'Y' and a.testid=" + TestID + " order By a.dorder";
                   break;


                   //objdbhims.Query = "SELECT count(d.testid) as records,s.name as subdept,s.subdepartmentid as subdeptid FROM dc_tpatient_bookingd d left outer join dc_tpatient_bookingm m on d.bookingid=m.bookingid   left outer join dc_tpatient p on p.prid=m.prid left outer join dc_tp_test t on d.testid=t.testid left outer join dc_tp_tclass c on t.testid = c.testid left outer join dc_tp_subdepartments s on s.subdepartmentid=t.subdepartmentid where d.processid=4 and m.BranchId="+Convert.ToInt32(_BranchID);
                   //if (StrPlaceID.Equals("008"))
                   //    objdbhims.Query += "    and (( case when t.external_org is null then d.clientid='008' end) or t.external_org in ('" + StrPlaceID + "','-1'))";
                   //else if (StrPlaceID.Equals("006"))
                   //{
                   //    objdbhims.Query += " and ((case when t.external_org is null and t.external='N' then d.clientid='006' else t.external_org='006' end) or (case when t.external='Y' and t.external_org not in ('006','008') then d.testid in (select testid from dc_toutside_test where labid=m.labid   )  end))";
                   //    //objdbhims.Query += " and (t.external_org='006' or (case when t.external_org is null then d.clientid='006' end))";
                   //    //objdbhims.Query += " or (case when t.external='Y' and t.external_org not in ('006','008') then d.testid in (select testid from dc_toutside_test where labid=m.labid  ) end)";
                   //}
                   ////else if (StrPlaceID.Equals("006"))
                   ////    objdbhims.Query += " and (t.external_org<>'008' or (case when t.external_org is null then d.clientid='" + StrPlaceID + "' end))";
                   //else
                   //    objdbhims.Query += " and d.clientid='" + StrPlaceID + "'";
                   //objdbhims.Query += "  group by s.name,s.subdepartmentid";
                 
           }
           return objTrans.DataTrigger_Get_All(objdbhims);
       }

       public bool Insert(string[,] str)
       {
           QueryBuilder objQB = new QueryBuilder();

           objTrans.Start_Transaction();

           objdbhims.Query = objQB.QBGetMax("worklistid", TableName);
           StrWorkListID = objTrans.DataTrigger_Get_Max(objdbhims);

           if (!StrWorkListID.Equals("True"))
           {
               objdbhims.Query = "SELECT lpad(ifnull(max(substr(e.worklistno,6,5)),0)+1,5,0) as maxid FROM dc_tworklist e where substr(e.worklistno,3,2)= date_format(current_date,'%y') ";
               StrWorkListNO = this.objTrans.DataTrigger_Get_Max(objdbhims);
               if (StrWorkListNO.Equals("True"))
               {
                   StrError = objTrans.OperationError;
                   objTrans.End_Transaction();
                   return false;
               }

               StrWorkListNO = "W-" + System.DateTime.Now.ToString("yy") + "-" + StrWorkListNO;

               objdbhims.Query = "insert into dc_tworklist (worklistid,worklistno,subdeptid,enteredby,enteredon,clientid,BranchID) values ("+StrWorkListID+",'"+StrWorkListNO+"',"+StrSubDeptID+","+StrEnteredBy+",str_to_date('"+StrEnteredOn+"','%d/%m/%Y %h:%i:%s %p'),'"+StrClientID+"','"+Convert.ToInt32(_BranchID)+"')";
               StrError = objTrans.DataTrigger_Insert(objdbhims);

               if (!StrError.Equals("True"))
               {
                   for (int i = 0; i <= str.GetUpperBound(0); i++)
                   {
                       StrTestID = str[i, 0];
                       StrBookingID = str[i, 1];
                       StrBookingDID = str[i, 2];
                       StrLabID = str[i, 3];
                       StrProcessID = str[i, 4];

                       objdbhims.Query = "update dc_tpatient_bookingd set worklistid=" + StrWorkListID + ",processid="+StrProcessID+" where testid=" + StrTestID + " and bookingid=" + StrBookingID + " and bookingdid=" + StrBookingDID + "";
                       StrError = objTrans.DataTrigger_Update(objdbhims);

                       if (StrError.Equals("True"))
                       {
                           StrError = objTrans.OperationError;
                           objTrans.End_Transaction();
                           return false;
                       }
                       else
                       {
                           objdbhims.Query = "insert into dc_tstatustrack (labid,testid,processid,enteredby,enteredon,clientid,bookingdid) values ('" + StrLabID + "'," + StrTestID + ",4," + StrEnteredBy + ",str_to_date('" + StrEnteredOn + "','%d/%m/%Y %h:%i:%s %p'),'" + StrClientID + "'," + StrBookingDID + ")";
                           StrError = objTrans.DataTrigger_Insert(objdbhims);

                           if (StrError.Equals("True"))
                           {
                               StrError = objTrans.OperationError;
                               objTrans.End_Transaction();
                               return false;
                           }
                       }
                   }
                   if (!StrError.Equals("True"))
                   {
                       objTrans.End_Transaction();
                       return true;
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
       #endregion
   }
}
