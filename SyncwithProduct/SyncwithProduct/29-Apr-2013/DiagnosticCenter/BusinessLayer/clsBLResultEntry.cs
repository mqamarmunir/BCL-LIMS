using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataLayer;

namespace BusinessLayer
{
   public class clsBLResultEntry
    {
       clsdbhims objdbhims = new clsdbhims();
       clsoperation objTrans = new clsoperation();

       #region "Variables"

       private const string Default = "~!@";
       private const string TableName_Master = "dc_Tresult";
       private const string TableName_History = "dc_tresultH";
       private const string TableName_MicroSenstivty = "dc_tMicro_Senstivity";
       private string StrError = Default;

       private string StrResultID = Default;
       private string StrBookingID = Default;
       private string StrBookingDID = Default;
       private string StrTestID = Default;

       private string StrLabID = Default;
       private string StrPRID = Default;
       private string StrAttributeID = Default;

       private string StrResult = Default;
       private string StrAbnormal = Default;
       private string StrPrint = Default;

       private string StrInterfaceID = Default;
       private string StrRangeID = Default;
       private string StrRange_Text = Default;

       private string StrEnteredOn = Default;
       private string StrEnteredBy = Default;
       private string StrClientID = Default;

       private string StrDepartmentID = Default;
       private string StrSubDeptID = Default;
       private string StrGroupID = Default;
       private string StrType = Default;

       private string StrFromDate = Default;
       private string StrToDate = Default;

       private string StrProcessID = Default;
       private string StrAge = Default;
       private string StrGender = Default;

       private string StrComment = Default;
       private string StrOpinion = Default; 
       private string StrPersonID = Default;

       private string StrOrganismID = Default;
       private string StrDrugID = Default;
       private string StrSenstivity = Default;
       private string StrDOrder = Default;

       private string StrAttribute_Name = Default;
       private string StrHeading = Default;

       private string StrInt_Coment = Default;
       private string StrFor_Process = Default;

       private string _BranchID = Default;

     
       #endregion

       #region "Properties"

       public string Error
       {
           get { return StrError; }
           set { StrError = value; }
       }

       public string ResultID
       {
           get { return StrResultID; }
           set { StrResultID = value; }
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
       public string TestID
       {
           get { return StrTestID; }
           set { StrTestID = value; }
       }

       public string LabID
       {
           get { return StrLabID; }
           set { StrLabID = value; }
       }
       public string PRID
       {
           get { return StrPRID; }
           set { StrPRID = value; }
       }
       public string AttributeID
       {
           get { return StrAttributeID; }
           set { StrAttributeID = value; }
       }

       public string Result
       {
           get { return StrResult; }
           set { StrResult = value; }
       }
       public string Abnormal
       {
           get { return StrAbnormal; }
           set { StrAbnormal = value; }
       }
       public string Print
       {
           get { return StrPrint; }
           set { StrPrint = value; }
       }

       public string InterfaceID
       {
           get { return StrInterfaceID; }
           set { StrInterfaceID = value; }
       }
       public string RangeID
       {
           get { return StrRangeID; }
           set { StrRangeID = value; }
       }
       public string Range_Text
       {
           get { return StrRange_Text; }
           set { StrRange_Text = value; }
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

       public string DepartmentID
       {
           get { return StrDepartmentID; }
           set { StrDepartmentID = value; }
       }
       public string SubDeptID
       {
           get { return StrSubDeptID; }
           set { StrSubDeptID = value; }
       }
       public string GroupID
       {
           get { return StrGroupID; }
           set { StrGroupID = value; }
       }
       public string Type
       {
           get { return StrType; }
           set { StrType = value; }
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

       public string ProcessID
       {
           get { return StrProcessID; }
           set { StrProcessID = value; }
       }
       public string Gender
       {
           get { return StrGender; }
           set { StrGender = value; }
       }
       public string Age
       {
           get { return StrAge; }
           set { StrAge = value; }
       }

       public string Comment
       {
           get { return StrComment; }
           set { StrComment = value; }
       }
       public string Opinion
       {
           get { return StrOpinion; }
           set { StrOpinion = value; }
       }
       public string PersonID
       {
           get { return StrPersonID; }
           set { StrPersonID = value; }
       }

       public string Attribute_name
       {
           get { return StrAttribute_Name; }
           set { StrAttribute_Name = value; }
       }
       public string Heading
       {
           get { return StrHeading; }
           set { StrHeading = value; }
       }

       public string Int_Coment
       {
           get { return StrInt_Coment; }
           set { StrInt_Coment = value; }
       }
       public string For_Process
       {
           get { return StrFor_Process; }
           set { StrFor_Process = value; }
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
               case 1: // fill grid //left outer join dc_tp_groupd gd on d.testid = gd.testid
                   ////////////////////////////Catering Branches/////////////////////
                   objdbhims.Query = @"SELECT  d.bookingid,d.labid,d.processid,p.prid,p.prno,d.DestinationBranchID,d.SendStatus,
                                        concat(ifnull(p.title,''),' ',p.name,' ( ',case when p.gender='M' then 'Male'
                                        else 'Female' end,' : ',
                                        case when DATEDIFF(CURRENT_DATE,p.dob) > 365
                                        then concat(Floor(DATEDIFF(CURRENT_DATE,p.dob)/365),' Yrs')
                                        else case when DATEDIFF(CURRENT_DATE,p.dob) > 30
                                        then concat(Floor(DATEDIFF(CURRENT_DATE,p.dob)/30),' Mon')
                                        else      concat(DATEDIFF(CURRENT_DATE,p.dob),'Dys') end end,' ) ')   as patientname,
                                        p.DOB, p.gender,  case when DATEDIFF(CURRENT_DATE,p.dob) > 365
                                        then      concat(Floor(DATEDIFF(CURRENT_DATE,p.dob)/365),' (Y)')  else
                                        case when DATEDIFF(CURRENT_DATE,p.dob) > 30
                                        then      concat(Floor(DATEDIFF(CURRENT_DATE,p.dob)/30),' (M)')
                                        else      concat(DATEDIFF(CURRENT_DATE,p.dob),'(D)')    end  end  AS age,
                                        gm.name as groupname,m.authorizeno,pn.name as panel,t.testid,group_concat(t.test_name) as testname,
                                        t.acronym,date_format(d.deliverytime,'%d/%m/%y %h:%i %p') as deliverytime,
                                        DATEDIFF(CURRENT_DATE,p.dob) as Totalyear,'RED' as color_id,
                                        t.clinicaluse,t.automatedtext,m.referenceno,
                                        date_format(m.enteredon,'%d/%m/%Y %h:%i %p') as bookedon,
                                        case when m.type='I' then 'Indoor' else 'Outdoor' end as type,
                                        (select count(priority) from dc_tpatient_bookingd where bookingid=d.bookingid and priority='U') as priority,
                                        og.acronym as origin1,tb.Name origin,
                                        (case when m.type='I' then concat(w.name,':', m.adm_ref) else '-' end) as adm_info

                                        FROM dc_tpatient_bookingd d left outer join dc_tpatient_bookingm m on d.bookingid=m.bookingid
                                        left outer join dc_tpatient p on p.prid=m.prid
                                        left outer join dc_tp_test t on d.testid=t.testid
                                        left outer join dc_tp_groupm gm on t.groupid = gm.groupid
                                        left outer join dc_tpanel pn on m.panelid = pn.panelid
                                        left outer join dc_tp_organization og on og.orgid=m.clientid
                                        left outer join dc_tp_ward w on w.wardid=m.wardid
                                        left outer join dc_tp_branch tb on tb.BranchID=m.BranchID

                                        where d.processid=" + Convert.ToInt32(StrProcessID) + @" and ((m.branchId=" + Convert.ToInt32(_BranchID) + @" and ( d.DestinationBranchID=0 or d.DestinationBranchID is null)) or (d.DestinationBranchID=" + Convert.ToInt32(_BranchID) + @" and d.sendstatus='R'))";
                   if (!StrType.Equals(Default))
                       objdbhims.Query += " and m.type='" + StrType + "'";
                   if (!StrDepartmentID.Equals(Default) && !StrDepartmentID.Equals(""))
                       objdbhims.Query += " and d.testid in (select testid from dc_Tp_test where subdepartmentid in (select subdepartmentid from dc_tp_subdepartments where departmentid=" + StrDepartmentID + "))  ";
                   if (!StrSubDeptID.Equals(Default) && !StrDepartmentID.Equals(""))
                       objdbhims.Query += " and d.testid in (select testid from dc_tp_test where subdepartmentid=" + StrSubDeptID + ")";
                   if (!StrGroupID.Equals(Default) && !StrGroupID.Equals(""))
                       objdbhims.Query += " and d.testid in (select  testid from dc_tp_groupd where groupid=" + StrGroupID + ")";
                   if (!StrFromDate.Equals(Default) && !StrToDate.Equals(Default))
                       objdbhims.Query += "and date_format(m.enteredon,'%Y/%m/%d') between '" + StrFromDate + "' and '" + StrToDate + "'";
                   //if (StrClientID.Equals("008"))
                   //    objdbhims.Query += "   and (( case when t.external_org is null then d.clientid='008' end) or t.external_org in ('008','-1'))";
                   //else if (StrClientID.Equals("006"))
                   //    objdbhims.Query += " and (t.external_org<>'008' or (case when t.external_org is null then d.clientid='" + StrClientID + "' end))";
                   //else
                   //    objdbhims.Query += " and d.clientid='"+StrClientID+"'";

                   objdbhims.Query += " group by m.bookingid  order by d.priority desc,m.bookingid asc";
                   /////////////////////////////////-----//////////////////////////
                   break;
                  // objdbhims.Query = "SELECT  d.bookingid,d.labid,d.processid,p.prid,p.prno,concat(ifnull(p.title,''),' ',p.name,' ( ',case when p.gender='M' then 'Male' else 'Female' end,' : ', case when DATEDIFF(CURRENT_DATE,p.dob) > 365 then concat(Floor(DATEDIFF(CURRENT_DATE,p.dob)/365),' Yrs')  else case when DATEDIFF(CURRENT_DATE,p.dob) > 30 then concat(Floor(DATEDIFF(CURRENT_DATE,p.dob)/30),' Mon') else      concat(DATEDIFF(CURRENT_DATE,p.dob),'Dys') end end,' ) ')   as patientname,p.DOB, p.gender,  case when DATEDIFF(CURRENT_DATE,p.dob) > 365 then      concat(Floor(DATEDIFF(CURRENT_DATE,p.dob)/365),' (Y)')  else    case when DATEDIFF(CURRENT_DATE,p.dob) > 30 then      concat(Floor(DATEDIFF(CURRENT_DATE,p.dob)/30),' (M)')    else      concat(DATEDIFF(CURRENT_DATE,p.dob),'(D)')    end  end  AS age,gm.name as groupname,m.authorizeno,pn.name as panel,t.testid,group_concat(t.test_name) as testname,t.acronym,date_format(d.deliverytime,'%d/%m/%y %h:%i %p') as deliverytime,DATEDIFF(CURRENT_DATE,p.dob) as Totalyear,'RED' as color_id,t.clinicaluse,t.automatedtext,m.referenceno,date_format(m.enteredon,'%d/%m/%Y %h:%i %p') as bookedon,case when m.type='I' then 'Indoor' else 'Outdoor' end as type,(select count(priority) from dc_tpatient_bookingd where bookingid=d.bookingid and priority='U') as priority,og.acronym as origin,(case when m.type='I' then concat(w.name,':', m.adm_ref) else '-' end) as adm_info FROM dc_tpatient_bookingd d left outer join dc_tpatient_bookingm m on d.bookingid=m.bookingid left outer join dc_tpatient p on p.prid=m.prid left outer join dc_tp_test t on d.testid=t.testid  left outer join dc_tp_groupm gm on t.groupid = gm.groupid left outer join dc_tpanel pn on m.panelid = pn.panelid left outer join dc_tp_organization og on og.orgid=m.clientid left outer join dc_tp_ward w on w.wardid=m.wardid where d.processid=" + StrProcessID + " and (m.branchId="+Convert.ToInt32(_BranchID)+" or (d.DestinationBranchID="+Convert.ToInt32(_BranchID)+" and d.sendstatus='R'))"; //and d.clientid='" + StrClientID + "'" 
                   //if (!StrType.Equals(Default))
                   //    objdbhims.Query += " and m.type='" + StrType + "'";
                   //if (!StrDepartmentID.Equals(Default) && !StrDepartmentID.Equals(""))
                   //    objdbhims.Query += " and d.testid in (select testid from dc_Tp_test where subdepartmentid in (select subdepartmentid from dc_tp_subdepartments where departmentid=" + StrDepartmentID + "))  ";
                   //if (!StrSubDeptID.Equals(Default) && !StrDepartmentID.Equals(""))
                   //    objdbhims.Query += " and d.testid in (select testid from dc_tp_test where subdepartmentid=" + StrSubDeptID + ")";
                   //if (!StrGroupID.Equals(Default) && !StrGroupID.Equals(""))
                   //    objdbhims.Query += " and d.testid in (select  testid from dc_tp_groupd where groupid=" + StrGroupID + ")";
                   //if (!StrFromDate.Equals(Default) && !StrToDate.Equals(Default))
                   //    objdbhims.Query += "and date_format(m.enteredon,'%Y/%m/%d') between '" + StrFromDate + "' and '" + StrToDate + "'";
                   //if (StrClientID.Equals("008"))
                   //    objdbhims.Query += "   and (( case when t.external_org is null then d.clientid='008' end) or t.external_org in ('008','-1'))";
                   //else if (StrClientID.Equals("006"))
                   //    objdbhims.Query += " and (t.external_org<>'008' or (case when t.external_org is null then d.clientid='" + StrClientID + "' end))";
                   //else
                   //    objdbhims.Query += " and d.clientid='"+StrClientID+"'";

                   //objdbhims.Query += " group by m.bookingid  order by d.priority desc,m.bookingid asc";
                   
                   
               case 2: // display patient
                   objdbhims.Query = "SELECT m.bookingid,m.prid,m.labid,p.name as patientName,p.prno,case when DATEDIFF(CURRENT_DATE,p.dob) > 365 then concat(Floor(DATEDIFF(CURRENT_DATE,p.dob)/365),' Years')  else case when DATEDIFF(CURRENT_DATE,p.dob) > 30 then concat(Floor(DATEDIFF(CURRENT_DATE,p.dob)/30),' Month') else concat(DATEDIFF(CURRENT_DATE,p.dob),' Days')    end  end  AS age, case when p.gender='M' then 'Male' when p.gender='F' then 'Female' else '' end as gender, case when m.doctorid is null then m.referredby else dc.name end as referredby,case when m.type = 'O' then 'Outdoor' else 'Indoor' end as patienttype,DATEDIFF(CURRENT_DATE,p.dob) as pageindays FROM dc_tpatient_bookingm m left outer join dc_tpatient p on m.prid=p.prid left outer join dc_tp_refdoctors dc on m.doctorid=dc.doctorid where m.bookingid="+StrBookingID+" and m.labid='"+StrLabID+"'";
                   break;
               case 3: // fill test
                   objdbhims.Query = "SELECT testid,test_name as testname  FROM dc_tp_test";
                   break;
               case 4: // fill attribute
                   objdbhims.Query = "SELECT a.attributeid,a.attribute_name,a.print,a.attribute_type,ifnull(a.linesno,'1') as linesno,a.testid,case when a.attribute_type = 'N' then concat(concat(ifnull(r.min_value,'-'),'-'),ifnull(r.max_value,'-')) else '-' end as ranges,case when a.attribute_type='N' then r.max_value else '-' end as max_value,case when a.attribute_type='N' then r.min_value else '-' end as min_value,case when a.attribute_type='N' then ifnull(r.aunit,'-') else '-' end as aunit,r.rangeid,case when a.attributeid in (SELECT attributeid FROM dc_tp_atemplates d where active='Y') then 'Y' else 'N' end as template,ifnull((select result from dc_tresult where attributeid=a.attributeid and a.attribute_type='N'and prid=" + StrPRID + " and resultid=(select max(resultid) from dc_tresult)),'-') as last,ifnull((select date_format(enteredon,'%d/%m/%y') from dc_tresult where attributeid=a.attributeid and a.attribute_type='N' and prid=" + StrPRID + " and resultid=(select max(resultid) from dc_tresult)),'-')  as lastdate,ifnull((select result from dc_tresult where attributeid=a.attributeid and a.attribute_type='N' and prid=" + StrPRID + " and resultid=(select max(resultid)-1 from dc_tresult)),'-') as secondlast,ifnull((select date_format(enteredon,'%d/%m/%y') from dc_tresult where attributeid=a.attributeid and a.attribute_type='N' and prid=" + StrPRID + " and resultid=(select max(resultid)-1 from dc_tresult)),'-') as secondlastdate,ifnull((select result from dc_tresult where prid=" + StrPRID + " and bookingdid=" + StrBookingDID + " and bookingid=" + StrBookingID + " and a.attributeid=attributeid),'-') as result,case when (select result from dc_tresult where prid=" + StrPRID + " and bookingdid=" + StrBookingDID + " and bookingid=" + StrBookingID + " and a.attributeid=attributeid and testid=" + StrTestID + ") is null then (SELECT description FROM dc_tp_atemplates d where active='Y' and defaultt='Y' and attributeid=a.attributeid)  else (select result from dc_tresult where prid=" + StrPRID + " and bookingdid=" + StrBookingDID + " and bookingid=" + StrBookingID + " and a.attributeid=attributeid and testid=" + StrTestID + ")  end as defaulttemplate,ifnull((select count(tt.attributeid) from dc_tp_attributes tt where Attribute_Type='T' and tt.testid= r.testId) ,'0') as totalText,a.heading,ifnull(a.dorder,0) as a_dorder,(select comment from dc_ttest_opinion where bookingid=" + StrBookingID + " and testid=" + StrTestID + " and prid=" + StrPRID + " order by transid desc limit 0,1) as comment,(select opinion from dc_ttest_opinion where bookingid=" + StrBookingID + " and testid=" + StrTestID + " and prid=" + StrPRID + " order by transid desc limit 0,1 ) as opinion FROM dc_tp_attributes a left outer join dc_tp_aranges r on a.attributeid=r.attributeid left outer join dc_tp_test t on t.testid=a.testid left outer join dc_tp_tmethod mt on mt.testid=t.testid  where a.active='Y' and a.testid=" + StrTestID + " and (r.sex='" + StrGender + "' or r.sex='A' or a.heading='Y') and (" + StrAge + " between age_min and age_max or a.heading='Y' ) and ((a.heading='Y' and r.methodid is null) or r.methodid=mt.methodid  ) and ( r.testid=t.testid or (a.heading='Y' and r.testid is null)) and mt.m_default='Y' and mt.clientid='" + StrClientID + "' order by a.dorder asc";
                   break;
               case 5: // fill process drop down
                   objdbhims.Query = "SELECT d.processid,d.name,t.test_name FROM dc_tp_tprocess d left outer join dc_tp_tprocedured pd on pd.processid=d.processid left outer join dc_tp_test t on t.procedureid=pd.procedureid  where d.active='Y' and t.testid="+StrTestID+" and d.processid not in (1,2,5,8,9,10) order by t.testid,d.processid";
                   break;
               case 6: // fill attribute template
                   objdbhims.Query = "SELECT templateid,attributeid,description FROM dc_tp_atemplates d where active='Y' and attributeid="+StrAttributeID+"";
                   break;
               case 7:// fill comment and opinion
                   objdbhims.Query = "select cpid,case when '"+StrComment+"' ='Comment' then comment else opinion end as template from dc_ttest_c_p where active='Y' and testid="+StrTestID+" and "+StrComment+" is not null";
                   break;
               case 8: // fill patient history attribute
                   objdbhims.Query = "SELECT distinct r.attributeid,r.prid,r.testid,a.attribute_name as attrib_name,concat(ifnull(g.min_value,''),'-',ifnull(g.max_value,'')) as range  FROM dc_tresult r left outer join dc_tp_attributes a on r.attributeid=a.attributeid left outer join dc_tp_aranges g on r.rangeid=g.rangeid where ifnull(a.linesno,'1')=1 ";
                   if (!StrTestID.Equals("") && !StrTestID.Equals(Default))
                       objdbhims.Query += " and r.testid="+StrTestID+"";
                   if (!StrBookingID.Equals("") && !StrBookingID.Equals(Default))
                       objdbhims.Query += " and r.bookingid="+StrBookingID+"";
                   if (!StrPRID.Equals("") && !StrPRID.Equals(Default))
                       objdbhims.Query += " and r.prid="+StrPRID+"";
                   if (!StrAttributeID.Equals("") && !StrAttributeID.Equals(Default))
                       objdbhims.Query += " and r.attributeid="+StrAttributeID+"";
                   break;
               case 9: // fill patient history attribute result
                   objdbhims.Query = "SELECT  r.attributeid, r.bookingid,r.prid,r.testid,r.result,date_format(r.enteredon,'%d/%m/%y') as enteredon,a.attribute_name as attrib_name,concat(ifnull(g.min_value,''),'-',ifnull(g.max_value,'')) as range  FROM dc_tresult r left outer join dc_tp_attributes a on r.attributeid=a.attributeid left outer join dc_tp_aranges g on r.rangeid=g.rangeid where ifnull(a.linesno,'1')=1 ";
                   if (!StrTestID.Equals("") && !StrTestID.Equals(Default))
                       objdbhims.Query += " and r.testid=" + StrTestID + "";
                   if (!StrBookingID.Equals("") && !StrBookingID.Equals(Default))
                       objdbhims.Query += " and r.bookingid=" + StrBookingID + "";
                   if (!StrPRID.Equals("") && !StrPRID.Equals(Default))
                       objdbhims.Query += " and r.prid=" + StrPRID + "";
                   if (!StrAttributeID.Equals("") && !StrAttributeID.Equals(Default))
                       objdbhims.Query += " and r.attributeid=" + StrAttributeID + "";
                   break;
               case 10: // fill test group
                   objdbhims.Query = "SELECT groupid,name FROM dc_tp_groupm where active='Y'";
                   if (!StrDepartmentID.Equals(Default) && !StrDepartmentID.Equals("-1") && !StrDepartmentID.Equals(""))
                       objdbhims.Query += " and groupid in (select groupid from dc_tp_groupd where departmentid="+StrDepartmentID+")";
                   break;
               case 11: // fill attribute and result on verification              
                   objdbhims.Query = "SELECT a.attributeid,a.attribute_name,a.attribute_type,ifnull(a.linesno,'1') as linesno,a.testid,case when a.attribute_type = 'N' then concat(ifnull(r.min_value,'-'),'-',ifnull(r.max_value,'-')) else '-' end as ranges,case when a.attribute_type='N' then r.max_value else '-' end as max_value,case when a.attribute_type='N' then r.min_value else '-' end as min_value,case when a.attribute_type='N' then ifnull(r.aunit,'-') else '-' end as aunit,r.rangeid,case when a.attributeid in (SELECT attributeid FROM dc_tp_atemplates d where active='Y') then 'Y' else 'N' end as template,re.resultid,re.result,re.abnormal,ifnull((select count(tt.attributeid) from dc_tp_attributes tt where Attribute_Type='T' and tt.testid= r.testId) ,'0') as totalText ,re.print,a.heading,ifnull(a.dorder,0) as a_dorder,(select comment from dc_ttest_opinion where bookingid=" + StrBookingID + " and testid=" + StrTestID + " and prid=" + StrPRID + " and bookingdid=" + StrBookingDID + " order by transid desc limit 0,1) as comment,(select opinion from dc_ttest_opinion where bookingid=" + StrBookingID + " and testid=" + StrTestID + " and prid=" + StrPRID + " and bookingdid=" + StrBookingDID + " order by transid desc limit 0,1 ) as opinion FROM dc_tp_attributes a left outer join dc_tp_aranges r on a.attributeid=r.attributeid left outer join dc_tp_test t on t.testid=a.testid left outer join dc_tresult re on  a.attributeid=re.attributeid left outer join dc_tp_tmethod mt on mt.testid=t.testid  where a.active='Y'  and re.bookingdid=" + StrBookingDID + " and re.bookingid=" + StrBookingID + " and a.testid=" + StrTestID + " and (r.sex='" + StrGender + "' or r.sex='A' or a.heading='Y') and (" + StrAge + " between age_min and age_max or a.heading='Y' ) and ( r.methodid=mt.methodid or (a.heading='Y' and r.methodid is null) )and ( r.testid=t.testid or (r.testid is null and a.heading='Y'))   and mt.m_default='Y' and mt.clientid='" + StrClientID + "' order by a.dorder asc";//ifnull((select result from dc_tresult where attributeid=a.attributeid and a.attribute_type='N'and prid=" + StrPRID + " and resultid=(select max(resultid) from dc_tresult where bookingid<> " + StrBookingID + ")),'-') as last,ifnull((select date_format(enteredon,'%d/%m/%y') from dc_tresult where attributeid=a.attributeid and a.attribute_type='N' and prid=" + StrPRID + " and resultid=(select max(resultid) from dc_tresult where bookingid<>" + StrBookingID + ")),'-')  as lastdate,ifnull((select result from dc_tresult where attributeid=a.attributeid and a.attribute_type='N' and prid=" + StrPRID + " and resultid=(select max(resultid)-1 from dc_tresult where bookingid<>" + StrBookingID + ")),'-') as secondlast,ifnull((select date_format(enteredon,'%d/%m/%y') from dc_tresult where attributeid=a.attributeid and a.attribute_type='N' and prid=" + StrPRID + " and resultid=(select max(resultid)-1 from dc_tresult where bookingid<>" + StrBookingID + ")),'-') as secondlastdate, No need of this bullshit
                   break;
               case 12: // fill process drop down verification
                   objdbhims.Query = "SELECT d.processid,d.name,t.test_name FROM dc_tp_tprocess d left outer join dc_tp_tprocedured pd on pd.processid=d.processid left outer join dc_tp_test t on t.procedureid=pd.procedureid  where d.active='Y' and t.testid=" + StrTestID + " and d.processid not in (1,2,6,8,9,10) order by t.testid,d.processid";
                   break;
               case 13:
                   objdbhims.Query = "select distinct r.testid, t.test_name from dc_tresult r left outer join dc_tp_test t on r.testid=t.testid where r.prid="+StrPRID+"";
                   break;
               case 14: //b4 report opening
                   objdbhims.Query = "SELECT r.resultid,r.bookingid,r.testid,r.prid,r.attributeid,r.result,t.test_name,a.attribute_name,r.enteredon,a.attribute_type FROM dc_tresult r left outer join dc_tp_test t on r.testid=t.testid left outer join dc_tp_attributes a on r.attributeid=a.attributeid where r.prid="+StrPRID+"";
                   break;
               case 15: //duplicate check result entry
                   objdbhims.Query = "SELECT r.resultid FROM dc_tresult r where r.prid=" + StrPRID + " and r.bookingid"+StrBookingID+" and r.testid="+StrTestID+" and r.attributeid="+StrAttributeID+"";
                   break;
               case 16: //Fill Patient test According to Labid
                   objdbhims.Query = "SELECT d.bookingdid, d.bookingid ,t.testID,t.test_name,p.name,p.processid,ifnull(og.acronym,'-') as origin FROM dc_tpatient_bookingd d left outer join dc_tp_organization og on d.clientid=og.orgid,dc_tp_test t,dc_tp_tprocess p  where d.bookingid = " + StrBookingID + " and t.testid=d.testid and d.processid=p.processid";
                   //if (StrClientID.Equals("008"))
                   //    objdbhims.Query += "    and (( case when t.external_org is null then d.clientid='008' end) or t.external_org in ('008','-1'))";
                   //else if (StrClientID.Equals("006"))
                   //    objdbhims.Query += " and (t.external_org<>'008' or (case when t.external_org is null then d.clientid='006' end))";
                   break;
               case 17: //fill patient test according to bookingID, processID and Department in Resultentry and verification
                   objdbhims.Query = @"SELECT m.bookingid,d.bookingdid,d.testid,t.Test_name,t.procedureid,t.clinicaluse,t.automatedtext FROM dc_tpatient_bookingm m, dc_tpatient_bookingd d,dc_tp_test t where m.bookingid=d.bookingid and d.testid =t.testid and m.bookingid = " + StrBookingID + " and d.processid=" + StrProcessID + " and ((m.branchId="+Convert.ToInt32(_BranchID)+ " and d.DestinationBranchID=0) or (d.DestinationBranchID="+Convert.ToInt32(_BranchID)+" and d.sendstatus='R'))  and t.SubdepartmentId = " + StrSubDeptID;
                   //if (StrClientID.Equals("008"))
                   //    objdbhims.Query += "    and (( case when t.external_org is null then d.clientid='008' end) or t.external_org in ('008','-1'))";
                   //else if (StrClientID.Equals("006"))
                   //    objdbhims.Query += " and (t.external_org<>'008' or (case when t.external_org is null then d.clientid='006' end))";
                   break;
               case 18: // fill branch
                   objdbhims.Query = "select orgid,name from dc_tp_organization where active='Y' and external='N'";
                   break;
               case 19: // interface
                   objdbhims.Query = "select value from ls_tinterface where attributeid="+StrAttributeID+" and lpad(mserialno,8,0)='"+StrLabID+"'";
                   break;
           }
           return objTrans.DataTrigger_Get_All(objdbhims);
       }

                   
       public bool Insert_old(string[,] str, string[,] StrMicro)
       {
           QueryBuilder objQB = new QueryBuilder();
           objTrans.Start_Transaction();
           for (int i = 0; i <= str.GetUpperBound(0); i++)
           {
               objdbhims.Query = objQB.QBGetMax("resultid", TableName_Master);
               StrResultID = objTrans.DataTrigger_Get_Max(objdbhims);

               if (!StrResultID.Equals("True"))
               {
                   StrAttributeID = str[i, 0];
                   StrPrint = str[i, 1];
                   StrResult = str[i, 2];

                   StrAbnormal = str[i, 3];
                   StrRangeID = str[i, 4];
                   StrRange_Text = str[i,5];

                   StrHeading = str[i, 6];
                   StrDOrder = str[i, 7];
                   StrAttribute_Name = str[i, 8];
                   StrType = str[i, 9];

             

                   objdbhims.Query = objQB.QBInsert(MakeArray(), TableName_Master);
                   StrError = objTrans.DataTrigger_Insert(objdbhims);
                   if (!StrError.Equals("True"))
                   {
                       objdbhims.Query = objQB.QBInsert(MakeArray(), TableName_History);
                       StrError = objTrans.DataTrigger_Insert(objdbhims);
                       if (StrError.Equals("True"))
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
           if (!StrError.Equals("True"))
           {
               objdbhims.Query = "update dc_tpatient_bookingd set processid='"+StrProcessID+"' where testid="+StrTestID+" and bookingid="+StrBookingID+"";
               StrError = objTrans.DataTrigger_Update(objdbhims);
               if (!StrError.Equals("True"))
               {
                   objdbhims.Query = "insert into dc_tstatustrack (labid,processid,testid,enteredby,enteredon,clientid) values ('"+StrLabID+"',5,"+StrTestID+","+StrEnteredBy+",str_to_date('"+StrEnteredOn+"','%d/%m/%Y %h:%i:%s %p'),'"+StrClientID+"')";
                   StrError = objTrans.DataTrigger_Insert(objdbhims);
                   if (!StrError.Equals("True"))
                   {
                       if (!StrComment.Equals("") || !StrOpinion.Equals(""))
                       {
                           objdbhims.Query = "insert into dc_ttest_opinion (testid,bookingid,prid,opinion,comment,personid,enteredby,enteredon,clientid,type) values (" + StrTestID + "," + StrBookingID + "," + StrPRID + ",'" + StrOpinion + "','" + StrComment + "'," + StrPersonID + "," + StrEnteredBy + ",str_to_date('" + StrEnteredOn + "','%d/%m/%Y %h:%i:%s %p'),'" + StrClientID + "','R')";
                           StrError = objTrans.DataTrigger_Insert(objdbhims);
                       }
                       if (!StrError.Equals("True"))
                       {
                           List<string> Organ = new List<string>();
                           for (int l = 0; l <= StrMicro.GetUpperBound(0); l++)
                           {
                               StrOrganismID = StrMicro[l, 0];
                               StrDrugID = StrMicro[l, 1];
                               StrSenstivity = StrMicro[l, 2];

                               if (Organ.Contains(StrOrganismID))
                               {
                                   StrDOrder = Convert.ToString(Organ.IndexOf(StrOrganismID) + 1);
                               }
                               else
                               {
                                   Organ.Add(StrOrganismID);
                                   StrDOrder = Convert.ToString(Organ.IndexOf(StrOrganismID) + 1);
                               }

                               objdbhims.Query = objQB.QBInsert(MakeArrayMicroSenstivity(), TableName_MicroSenstivty);
                               StrError = objTrans.DataTrigger_Insert(objdbhims);
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
       
       public bool Update_Verifiy(string[,] str, string[,] StrMicro)
       {
           QueryBuilder objQB = new QueryBuilder();
           objTrans.Start_Transaction();
           for (int i = 0; i <= str.GetUpperBound(0); i++)
           {               
                   StrAttributeID = str[i, 0];
                   StrPrint = str[i, 1];
                   StrResult = str[i, 2];

                   StrAbnormal = str[i, 3];
                   StrRangeID = str[i, 4];

                   StrRange_Text = str[i, 5];
                   StrResultID = str[i, 6];

                   StrHeading = str[i, 7];
                   StrDOrder = str[i, 8];
                   StrAttribute_Name = str[i,9];
                   StrType = str[i, 10];

                   objdbhims.Query = objQB.QBUpdate(MakeArray(), TableName_Master);
                   StrError = objTrans.DataTrigger_Update(objdbhims);
                   if (!StrError.Equals("True"))
                   {
                       objdbhims.Query = objQB.QBInsert(MakeArray(), TableName_History);
                       StrError = objTrans.DataTrigger_Insert(objdbhims);
                       if (StrError.Equals("True"))
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
          
           if (!StrError.Equals("True"))
           {
               objdbhims.Query = "update dc_tpatient_bookingd set processid='" + StrProcessID + "' where testid=" + StrTestID + " and bookingid=" + StrBookingID + " and bookingdid=" + StrBookingDID;
               StrError = objTrans.DataTrigger_Update(objdbhims);
               if (!StrError.Equals("True"))
               {
                   objdbhims.Query = "insert into dc_tstatustrack (labid,processid,testid,enteredby,enteredon,clientid,bookingdid) values ('" + StrLabID + "',6," + StrTestID + "," + StrEnteredBy + ",str_to_date('" + StrEnteredOn + "','%d/%m/%Y %h:%i:%s %p'),'" + StrClientID + "',"+StrBookingDID+")";
                   StrError = objTrans.DataTrigger_Insert(objdbhims);
                   if (!StrError.Equals("True"))
                   {
                       if (!StrComment.Equals("") || !StrOpinion.Equals(""))
                       {
                           objdbhims.Query = "insert into dc_ttest_opinion (testid,bookingid,prid,opinion,comment,personid,enteredby,enteredon,clientid,type,bookingdid) values (" + StrTestID + "," + StrBookingID + "," + StrPRID + ",'" + StrOpinion + "','" + StrComment + "'," + StrPersonID + "," + StrEnteredBy + ",str_to_date('" + StrEnteredOn + "','%d/%m/%Y %h:%i:%s %p'),'" + StrClientID + "','V',"+StrBookingDID+")";
                           StrError = objTrans.DataTrigger_Insert(objdbhims);
                       }
                       if (!StrError.Equals("True"))
                       {
                           //=================================================

                           objdbhims.Query = "Delete From " + TableName_MicroSenstivty + " where Labid='" + StrLabID + "' and TestID= " + StrTestID + " and bookingdid=" + StrBookingDID;
                           StrError = objTrans.DataTrigger_Delete(objdbhims);
                           List<string> Organ = new List<string>();

                           for (int l = 0; l <= StrMicro.GetUpperBound(0); l++)
                           {
                               StrOrganismID = StrMicro[l, 0];
                               StrDrugID = StrMicro[l, 1];
                               StrSenstivity = StrMicro[l, 2];

                               if (Organ.Contains(StrOrganismID))
                               {
                                   StrDOrder = Convert.ToString(Organ.IndexOf(StrOrganismID) + 1);
                               }
                               else
                               {
                                   Organ.Add(StrOrganismID);
                                   StrDOrder = Convert.ToString(Organ.IndexOf(StrOrganismID) + 1);
                               }

                               objdbhims.Query = objQB.QBInsert(MakeArrayMicroSenstivity(), TableName_MicroSenstivty);
                               StrError = objTrans.DataTrigger_Insert(objdbhims);
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
                           //=================================================
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

       public bool Insert(string[,] str, string[,] StrMicro)
       {
           QueryBuilder objQB = new QueryBuilder();
           objTrans.Start_Transaction();
           for (int i = 0; i <= str.GetUpperBound(0); i++)
           {
               StrAttributeID = str[i, 0];
               StrPrint = str[i, 1];
               StrResult = str[i, 2];

               StrAbnormal = str[i, 3];
               StrRangeID = str[i, 4];

               StrRange_Text = str[i, 5];
               
               StrHeading = str[i, 6];
               StrDOrder = str[i, 7];
               StrAttribute_Name = str[i, 8];
               StrType = str[i, 9];

               objdbhims.Query = "SELECT r.resultid FROM dc_tresult r where r.prid=" + StrPRID + " and r.bookingid=" + StrBookingID + " and r.testid=" + StrTestID + " and r.attributeid=" + StrAttributeID + " and r.bookingdid=" + StrBookingDID + "";
               DataView dv = objTrans.Transaction_Get_Single(objdbhims);

               if (dv.Count == 0)
               {
                   objdbhims.Query = objQB.QBGetMax("resultid", TableName_Master);
                   StrResultID = objTrans.DataTrigger_Get_Max(objdbhims);

                   if (!StrResultID.Equals("True"))
                   {
                       objdbhims.Query = objQB.QBInsert(MakeArray(), TableName_Master);
                       StrError = objTrans.DataTrigger_Insert(objdbhims);
                       if (!StrError.Equals("True"))
                       {
                           objdbhims.Query = objQB.QBInsert(MakeArray(), TableName_History);
                           StrError = objTrans.DataTrigger_Insert(objdbhims);
                           if (StrError.Equals("True"))
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
                   StrResultID = dv[0]["resultid"].ToString();
                   objdbhims.Query = objQB.QBUpdate(MakeArray(), TableName_Master);
                   StrError = objTrans.DataTrigger_Update(objdbhims);
                   if (!StrError.Equals("True"))
                   {
                       objdbhims.Query = objQB.QBInsert(MakeArray(), TableName_History);
                       StrError = objTrans.DataTrigger_Insert(objdbhims);
                       if (StrError.Equals("True"))
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
           }
           
           if (!StrError.Equals("True"))
           {
               objdbhims.Query = "update dc_tpatient_bookingd set processid='" + StrProcessID + "' where testid=" + StrTestID + " and bookingid=" + StrBookingID + " and bookingdid=" + StrBookingDID;
               StrError = objTrans.DataTrigger_Update(objdbhims);
               if (!StrError.Equals("True"))
               {
                   objdbhims.Query = "insert into dc_tstatustrack (labid,processid,testid,enteredby,enteredon,clientid,bookingdid) values ('" + StrLabID + "',5," + StrTestID + "," + StrEnteredBy + ",str_to_date('" + StrEnteredOn + "','%d/%m/%Y %h:%i:%s %p'),'" + StrClientID + "'," + StrBookingDID + ")";
                   StrError = objTrans.DataTrigger_Insert(objdbhims);
                   if (!StrError.Equals("True"))
                   {
                       if (!StrComment.Equals("") || !StrOpinion.Equals(""))
                       {
                           objdbhims.Query = "insert into dc_ttest_opinion (testid,bookingid,prid,opinion,comment,personid,enteredby,enteredon,clientid,type,bookingdid) values (" + StrTestID + "," + StrBookingID + "," + StrPRID + ",'" + StrOpinion + "','" + StrComment + "'," + StrPersonID + "," + StrEnteredBy + ",str_to_date('" + StrEnteredOn + "','%d/%m/%Y %h:%i:%s %p'),'" + StrClientID + "','E',"+StrBookingDID+")";
                           StrError = objTrans.DataTrigger_Insert(objdbhims);
                       }
                       if (!StrError.Equals("True"))
                       {
                           //=================================================

                           objdbhims.Query = "Delete From " + TableName_MicroSenstivty + " where Labid='" + StrLabID + "' and TestID= " + StrTestID + " and bookingdid=" + StrBookingDID;
                           StrError = objTrans.DataTrigger_Delete(objdbhims);
                           List<string> Organ = new List<string>();

                           for (int l = 0; l <= StrMicro.GetUpperBound(0); l++)
                           {
                               StrOrganismID = StrMicro[l, 0];
                               StrDrugID = StrMicro[l, 1];
                               StrSenstivity = StrMicro[l, 2];

                               if (Organ.Contains(StrOrganismID))
                               {
                                   StrDOrder = Convert.ToString(Organ.IndexOf(StrOrganismID) + 1);
                               }
                               else
                               {
                                   Organ.Add(StrOrganismID);
                                   StrDOrder = Convert.ToString(Organ.IndexOf(StrOrganismID) + 1);
                               }

                               objdbhims.Query = objQB.QBInsert(MakeArrayMicroSenstivity(), TableName_MicroSenstivty);
                               StrError = objTrans.DataTrigger_Insert(objdbhims);
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
                           //=================================================
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

       public bool sentBack()
       {
           objTrans.Start_Transaction();

           objdbhims.Query = "update dc_tpatient_bookingd set processid='" + StrProcessID + "' where testid=" + StrTestID + " and bookingid=" + StrBookingID + " and bookingdid=" + StrBookingDID;
           StrError = objTrans.DataTrigger_Update(objdbhims);

           if (!StrError.Equals("True"))
           {
               objdbhims.Query = "insert into dc_tstatustrack (labid,processid,testid,enteredby,enteredon,clientid,comment,bookingdid) values ('" + StrLabID + "',5," + StrTestID + "," + StrEnteredBy + ",str_to_date('" + StrEnteredOn + "','%d/%m/%Y %h:%i:%s %p'),'" + StrClientID + "','"+StrComment+"',"+StrBookingDID+")";
               StrError = objTrans.DataTrigger_Insert(objdbhims);
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
       public bool Result_Call_Back()
       {
           QueryBuilder objQB = new QueryBuilder();
           objTrans.Start_Transaction();

           objdbhims.Query = "update dc_tpatient_bookingd set processid='" + StrProcessID + "' where testid=" + StrTestID + " and bookingid=" + StrBookingID + " and bookingdid=" + StrBookingDID;

           StrError = objTrans.DataTrigger_Update(objdbhims);
           if (!StrError.Equals("True"))
           {
               objdbhims.Query = "insert into dc_tstatustrack (labid,processid,testid,enteredby,enteredon,clientid,bookingdid) values ('" + StrLabID + "',11," + StrTestID + "," + StrEnteredBy + ",str_to_date('" + StrEnteredOn + "','%d/%m/%Y %h:%i:%s %p'),'" + StrClientID + "',"+StrBookingDID+")";
               StrError = objTrans.DataTrigger_Insert(objdbhims);
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

       private string[,] MakeArray()
       {
           string[,] KdcArr = new string[19, 3];

           if (!StrResultID.Equals(Default))
           {
               KdcArr[0, 0] = "resultid";
               KdcArr[0, 1] = this.StrResultID;
               KdcArr[0, 2] = "int";
           }
           if (!StrBookingID.Equals(Default))
           {
               KdcArr[1, 0] = "bookingid";
               KdcArr[1, 1] = this.StrBookingID;
               KdcArr[1, 2] = "int";
           }
           if (!StrTestID.Equals(Default))
           {
               KdcArr[2, 0] = "testid";
               KdcArr[2, 1] = this.StrTestID;
               KdcArr[2, 2] = "int";
           }
           if (!StrPRID.Equals(Default))
           {
               KdcArr[3, 0] = "prid";
               KdcArr[3, 1] = this.StrPRID;
               KdcArr[3, 2] = "int";
           }
           if (!StrAttributeID.Equals(Default))
           {
               KdcArr[4, 0] = "attributeid";
               KdcArr[4, 1] = this.StrAttributeID;
               KdcArr[4, 2] = "int";
           }
           if (!StrResult.Equals(Default))
           {
               KdcArr[5, 0] = "result";
               KdcArr[5, 1] = this.StrResult;
               KdcArr[5, 2] = "string";
           }
           if (!StrAbnormal.Equals(Default))
           {
               KdcArr[6, 0] = "abnormal";
               KdcArr[6, 1] = this.StrAbnormal;
               KdcArr[6, 2] = "string";
           }
           if (!StrPrint.Equals(Default))
           {
               KdcArr[7, 0] = "print";
               KdcArr[7, 1] = this.StrPrint;
               KdcArr[7, 2] = "string";
           }
           if (!StrInterfaceID.Equals(Default))
           {
               KdcArr[8, 0] = "interfaceid";
               KdcArr[8, 1] = this.StrInterfaceID;
               KdcArr[8, 2] = "int";
           }
           if (!StrRangeID.Equals(Default))
           {
               KdcArr[9, 0] = "rangeid";
               KdcArr[9, 1] = this.StrRangeID;
               KdcArr[9, 2] = "int";
           }
           if (!StrRange_Text.Equals(Default))
           {
               KdcArr[10, 0] = "range_text";
               KdcArr[10, 1] = this.StrRange_Text;
               KdcArr[10, 2] = "string";
           }
           if (!StrEnteredBy.Equals(Default))
           {
               KdcArr[11, 0] = "enteredby";
               KdcArr[11, 1] = this.StrEnteredBy;
               KdcArr[11, 2] = "int";
           }
           if (!StrEnteredOn.Equals(Default))
           {
               KdcArr[12, 0] = "enteredon";
               KdcArr[12, 1] = this.StrEnteredOn;
               KdcArr[12, 2] = "datetime";
           }
           if (!StrClientID.Equals(Default))
           {
               KdcArr[13, 0] = "clientid";
               KdcArr[13, 1] = this.StrClientID;
               KdcArr[13, 2] = "string";
           }
           if (!StrHeading.Equals(Default))
           {
               KdcArr[14, 0] = "heading";
               KdcArr[14, 1] = this.StrHeading;
               KdcArr[14, 2] = "string";
           }
           if (!StrDOrder.Equals(Default))
           {
               KdcArr[15, 0] = "dorder";
               KdcArr[15, 1] = this.StrDOrder;
               KdcArr[15, 2] = "int";
           }
           if (!StrAttribute_Name.Equals(Default))
           {
               KdcArr[16, 0] = "attribute_name";
               KdcArr[16, 1] = this.StrAttribute_Name;
               KdcArr[16, 2] = "string";
           }
           if (!StrClientID.Equals(Default))
           {
               KdcArr[17, 0] = "a_type";
               KdcArr[17, 1] = this.StrType;
               KdcArr[17, 2] = "string";
           }
           if (!StrBookingDID.Equals(Default))
           {
               KdcArr[18, 0] = "bookingdid";
               KdcArr[18, 1] = this.StrBookingDID;
               KdcArr[18, 2] = "int";
           }
           return KdcArr;
       }
       private string[,] MakeArrayMicroSenstivity()
       {
           string[,] aryOrganism = new string[10, 3];

           if (!this.StrLabID.Equals(Default))
           {
               aryOrganism[0, 0] = "LabID";
               aryOrganism[0, 1] = this.StrLabID;
               aryOrganism[0, 2] = "string";
           }

           if (!this.StrTestID.Equals(Default))
           {
               aryOrganism[1, 0] = "TestID";
               aryOrganism[1, 1] = this.StrTestID;
               aryOrganism[1, 2] = "int";
           }

           if (!this.StrOrganismID.Equals(Default))
           {
               aryOrganism[2, 0] = "OrganismID";
               aryOrganism[2, 1] = this.StrOrganismID;
               aryOrganism[2, 2] = "int";
           }

           if (!this.StrDrugID.Equals(Default))
           {
               aryOrganism[3, 0] = "DrugID";
               aryOrganism[3, 1] = this.StrDrugID;
               aryOrganism[3, 2] = "int";
           }

           if (!this.StrSenstivity.Equals(Default))
           {
               aryOrganism[4, 0] = "Senstivity";
               aryOrganism[4, 1] = this.StrSenstivity;
               aryOrganism[4, 2] = "string";
           }

           if (!this.StrEnteredBy.Equals(Default))
           {
               aryOrganism[5, 0] = "EnteredBY";
               aryOrganism[5, 1] = this.StrEnteredBy;
               aryOrganism[5, 2] = "int";
           }

           if (!this.StrEnteredOn.Equals(Default))
           {
               aryOrganism[6, 0] = "EnteredON";
               aryOrganism[6, 1] = this.StrEnteredOn;
               aryOrganism[6, 2] = "datetime";
           }

           if (!this.StrClientID.Equals(Default))
           {
               aryOrganism[7, 0] = "ClientID";
               aryOrganism[7, 1] = this.StrClientID;
               aryOrganism[7, 2] = "string";
           }

           if (!this.StrDOrder.Equals(Default))
           {
               aryOrganism[8, 0] = "DOrder";
               aryOrganism[8, 1] = this.StrDOrder;
               aryOrganism[8, 2] = "int";
           }
           if (!StrBookingDID.Equals(Default))
           {
               aryOrganism[9, 0] = "bookingdid";
               aryOrganism[9, 1] = this.StrBookingDID;
               aryOrganism[9, 2] = "int";
           }

           return aryOrganism;
       }

       #endregion
   }
}
