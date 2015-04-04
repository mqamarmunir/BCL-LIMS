using System;
using System.Collections.Generic;
using System.Text;
using DataLayer;
using System.Data;

namespace BusinessLayer
{
   public class clsBLSpecimen
   {
       clsdbhims objdbhims = new clsdbhims();
       clsoperation objTrans = new clsoperation();

       #region"Variable"

       private const string TableName = "";
       private const string Default = "~!@";

       private string StrError = Default;
       private string StrDepartmentID = Default;
       private string StrSubDept = Default;
       private string StrGroupID = Default;

       private string StrType = Default;
       private string StrFromDate = Default;
       private string StrToDate = Default;

       private string StrPRNO = Default;
       private string StrPatientName = Default;
       private string StrGender = Default;

       private string StrTestID = Default;
       private string StrSpecimen_Notes = Default;
       private string StrLabID = Default;

       private string StrBookingID = Default;
       private string StrBookingDID = Default;
       private string StrProcessID = Default;

       private string StrEnteredBy = Default;
       private string StrEnteredOn = Default;
       private string StrClientID = Default;

       private string StrSpec_Number = Default;
       private string StrSpec_Nature = Default;
       private string StrQty = Default;

       private string StrUnit = Default;
       private string StrContainer = Default;
       private string StrBattery_No = Default;

       private string StrFor_Process = Default;
       private string StrInt_Coment = Default;

       private string _BranchID = Default;
       private string _Specimen_code = Default;

       
      
       #endregion

       #region"Properties"
       public string Specimen_code
       {
           get { return _Specimen_code; }
           set { _Specimen_code = value; }
       }
       public string Error
       {
           get { return StrError; }
           set { StrError = value; }
       }
       public string DepartmentID
       {
           get { return StrDepartmentID; }
           set { StrDepartmentID = value; }
       }
       public string SubDept
       {
           get { return StrSubDept; }
           set { StrSubDept = value; }
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

       public string PRNO
       {
           get { return StrPRNO; }
           set { StrPRNO = value; }
       }
       public string PatientName
       {
           get { return StrPatientName; }
           set { StrPatientName = value; }
       }
       public string Gender
       {
           get { return StrGender; }
           set { StrGender = value; }
       }

       public string TestID
       {
           get { return StrTestID; }
           set { StrTestID = value; }
       }
       public string Specimen_Notes
       {
           get { return StrSpecimen_Notes; }
           set { StrSpecimen_Notes = value; }
       }
       public string LabID
       {
           get { return StrLabID; }
           set { StrLabID = value; }
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
       public string ProcessID
       {
           get { return StrProcessID; }
           set { StrProcessID = value; }
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

       public string Spec_number
       {
           get { return StrSpec_Number; }
           set { StrSpec_Number = value; }
       }
       public string Spec_Nature
       {
           get { return StrSpec_Nature; }
           set { StrSpec_Nature = value; }
       }
       public string Qty
       {
           get { return StrQty; }
           set { StrQty = value; }
       }

       public string Unit
       {
           get { return StrUnit; }
           set { StrUnit = value; }
       }
       public string Container
       {
           get { return StrContainer; }
           set { StrContainer = value; }
       }
       public string Battery_No
       {
           get { return StrBattery_No; }
           set { StrBattery_No = value; }
       }

       public string For_Process
       {
           get { return StrFor_Process; }
           set { StrFor_Process = value; }
       }
       public string Int_Coment
       {
           get { return StrInt_Coment; }
           set { StrInt_Coment = value; }
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
           switch(flag)
           {
               case 1: // fill depart
                   objdbhims.Query = "SELECT departmentid,name FROM dc_tp_departments  where active='Y'";
                   break;
               case 2: // fill subdept
                   objdbhims.Query = "SELECT subdepartmentid,name FROM dc_tp_subdepartments where active='Y'"; 
                   if(!StrDepartmentID.Equals("") && !StrDepartmentID.Equals("-1") && !StrDepartmentID.Equals(Default))
                       objdbhims.Query +=" and departmentid="+StrDepartmentID+"";
                   break;
               case 3: // fill test group
                   objdbhims.Query = "SELECT groupid,name FROM dc_tp_groupm where active='Y'";
                   break;
               case 4: // fill gv
                   objdbhims.Query = "SELECT distinct d.bookingid,d.labid,d.processid,p.prno,concat(ifnull(p.title,''),' ',p.name) as patientname,p.DOB,case when p.gender='M' then 'Male' when p.gender='F' then 'Female' else '' end as Gender,  case when DATEDIFF(CURRENT_DATE,p.dob) > 365 then      concat(Floor(DATEDIFF(CURRENT_DATE,p.dob)/365),' Years')  else    case when DATEDIFF(CURRENT_DATE,p.dob) > 30 then      concat(Floor(DATEDIFF(CURRENT_DATE,p.dob)/30),' Month')    else      concat(DATEDIFF(CURRENT_DATE,p.dob),' Days')    end  end  AS age,m.authorizeno,pn.name as panel,case when (select count(processid) from dc_tstatustrack where labid=m.labid and processid=3) >=1 then 'Y' else 'N' end as repeaty,(select comment from dc_tstatustrack where labid=m.labid and comment is not null and comment<>'' and testid=t.testid and trackid=(select max(trackid) from dc_tstatustrack)) as repeatcomment,m.referenceno,date_format(m.enteredon,'%d/%m/%Y %h:%i %p') as bookedon,case when m.type='I' then 'Indoor' else 'Outdoor' end as type,(select count(priority) from dc_tpatient_bookingd where bookingid=d.bookingid and priority='U') as priority,og.acronym as origin1,tb.Name origin,(case when m.type='I' then concat(w.name,':', m.adm_ref) else '-' end) as adm_info FROM dc_tpatient_bookingd d left outer join dc_tpatient_bookingm m on d.bookingid=m.bookingid left outer join dc_tpatient p on p.prid=m.prid left outer join dc_tp_test t on d.testid=t.testid left outer join   dc_tpanel pn on p.panelid = pn.panelid left outer join dc_tp_organization og on og.orgid=m.clientid left outer join dc_tp_ward w on w.wardid=m.wardid left outer join dc_tp_branch tb on tb.BranchID=m.branchID where d.processid=3 and m.branchid=" + Convert.ToInt32(_BranchID) + " and m.clientid='" + StrClientID + "'";
                   if (!StrType.Equals(Default))
                       objdbhims.Query += " and m.type='"+StrType+"'";
                   if (!StrDepartmentID.Equals(Default) && !StrDepartmentID.Equals(""))
                       objdbhims.Query += " and d.testid in (select testid from dc_Tp_test where subdepartmentid in (select subdepartmentid from dc_tp_subdepartments where departmentid=" + StrDepartmentID + "))  ";
                   if (!StrSubDept.Equals(Default) && !StrDepartmentID.Equals(""))
                       objdbhims.Query += " and d.testid in (select testid from dc_tp_test where subdepartmentid=" + StrSubDept + ")";
                   if (!StrGroupID.Equals(Default) && !StrGroupID.Equals(""))
                       objdbhims.Query += " and d.testid in (select  testid from dc_tp_groupd where groupid="+StrGroupID+")";
                   if (!StrFromDate.Equals(Default) && !StrToDate.Equals(Default))
                       objdbhims.Query += " and date_format(m.enteredon,'%Y/%m/%d') between '" + StrFromDate + "' and '" + StrToDate + "'";
                   objdbhims.Query += "  group by m.bookingid order by d.priority desc";

                   break;
               case 5: //  fill test for specimen collection
                   objdbhims.Query = "SELECT  ifnull(su.specimen_sub_code,repeat(t.testtype,2)) specimen_code, d.bookingdid,d.bookingid,d.labid,d.testid,d.classificationid,concat(t.test_name,' ',ifnull(c.name,'')) as testname,gm.name as groupname,(select name from dc_tp_departments where departmentid=(select departmentid from dc_tp_subdepartments where t.subdepartmentid=subdepartmentid)) as deptname,concat(sp.specimen_name,'/',ifnull(t.qty,'-')) as specimenqty,case when t.subdepartmentid =3 then 'H' when t.subdepartmentid=13 then 'M' else 'G' end as sub_Type,su.name as subdept,t.subdepartmentid,'T' as notes,'N' as spec_no,ifnull(t.unit,'-') as unit,ifnull(t.scontainerid,0) as scontainerid,ifnull(t.qty,0) as qty ,t.external,'' as comment,'' as for_process,case when t.external_org is null and '" + StrClientID + "'='006' then 'BCL'  when t.external_org is null and '"+StrClientID+"'='008' then 'AMC' else og.acronym end as origin FROM dc_tpatient_bookingd d left outer join dc_tpatient_bookingm m on d.bookingid=m.bookingid  left outer join dc_tpatient p on p.prid=m.prid left outer join dc_tp_test t on d.testid=t.testid  left outer join dc_tp_groupm gm on t.groupid = gm.groupid left outer join dc_tp_tclass c on t.testid = c.testid left outer join dc_tp_stype sp on t.specimenid = sp.specimenid left outer join dc_tp_subdepartments su on t.subdepartmentid=su.subdepartmentid left outer join dc_tp_organization og on og.orgid=t.external_org where d.processid=3 and m.labid='" + StrLabID + "' order by ifnull(su.dorder,999) asc,su.name";
                   break; 
               case 6://specimen nature drop down
                   objdbhims.Query = "SELECT specimennatureid,name,type FROM dc_tp_specimen_nature where active='Y'";
                   break;
               case 7:// specimen number get
                   objdbhims.Query = @"SELECT concat('H-',date_format(current_date,'%y'),'-',(SELECT lpad(ifnull(max(substr(s_number,6,5)),0)+1,5,0) as maxid

FROM  dc_tspecimen_get
where substr(s_number,1,1)='H')) as histo,
concat('M-',date_format(current_date,'%y'),'-',
(SELECT lpad(ifnull(max(substr(s_number,6,5)),0)+1,5,0) as maxid
FROM dc_tspecimen_get where substr(s_number,1,1)='M')) as Micro,
concat('G-',date_format(current_date,'%y'),'-',
(SELECT lpad(ifnull(max(substr(s_number,6,5)),0)+1,5,0) as maxid
 FROM dc_tspecimen_get where substr(s_number,1,1)='G')) as Gen";
                   break;
               #region old
               //  objdbhims.Query = "SELECT concat('H-',date_format(current_date,'%y'),'-',(SELECT lpad(ifnull(max(substr(s_number,6,5)),0)+1,5,0) as maxid FROM  dc_tspecimen_get where substr(s_number,1,1)='H')) as histo,concat('M-',date_format(current_date,'%y'),'-',(SELECT lpad(ifnull(max(substr(s_number,6,5)),0)+1,5,0) as maxid FROM dc_tspecimen_get where substr(s_number,1,1)='M')) as Micro,concat('G-',date_format(current_date,'%y'),'-',(SELECT lpad(ifnull(max(substr(s_number,6,5)),0)+1,5,0) as maxid FROM dc_tspecimen_get where substr(s_number,1,1)='G')) as Gen  FROM dc_dummy d;";
               // break;
               #endregion
               case 8: //specimen report check
                   objdbhims.Query = "select count(testid) from dc_tpatient_bookingd where processid=3 and status <>'X'";
                   break;
               case 9: objdbhims.Query = "select lpad(ifnull(max(substr(s_number,7,5)),0)+1,5,0) as maxid FROM dc_tspecimen_get where substr(s_number,1,2) = '" + Specimen_code + "' and substr(s_number,4,2) = date_format(current_date,'%y')";
                   break;


           }
           return objTrans.DataTrigger_Get_All(objdbhims);
       }

       public bool GetSpecimen()
       {
           QueryBuilder objQB = new QueryBuilder();
           objTrans.Start_Transaction();
           objdbhims.Query = "update dc_tpatient_bookingd set specimen_note='"+StrSpecimen_Notes+"',processid="+StrProcessID+" where testid="+StrTestID+" and bookingid="+StrBookingID+" and bookingdid="+StrBookingDID+" ";
           StrError = objTrans.DataTrigger_Update(objdbhims);

           if (!StrError.Equals("True"))
           {
               objdbhims.Query = "insert into dc_tstatustrack (labid,testid,processid,enteredby,enteredon,clientid,bookingdid) values ('"+StrLabID+"',"+StrTestID+",3,"+StrEnteredBy+",str_to_date('"+StrEnteredOn+"','%d/%m/%Y %h:%i:%s %p'),'"+StrClientID+"',"+StrBookingDID+")";
               StrError = objTrans.DataTrigger_Insert(objdbhims);

               if (!StrError.Equals("True"))
               {
                   objdbhims.Query = objQB.QBInsert(MakeArray(), "dc_tspecimen_get");
                   StrError = objTrans.DataTrigger_Insert(objdbhims);

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

       public bool GetSpecimen_All(string[,] str)
       {
           QueryBuilder objQB = new QueryBuilder();
           objTrans.Start_Transaction();

           for (int i = 0; i <= str.GetUpperBound(0); i++)
           {              
               StrTestID = str[i, 0];
               StrSpecimen_Notes = str[i, 1];
               StrBookingID = str[i, 2];

               StrBookingDID = str[i, 3];
               StrSpec_Number = str[i, 4];

               StrSpec_Nature = str[i, 5];
               StrBattery_No = str[i, 6];

               StrQty = str[i, 7];
               StrContainer = str[i, 8];
               StrUnit = str[i, 9];
               StrProcessID = str[i, 10];

             
               objdbhims.Query = "update dc_tpatient_bookingd set specimen_note='" + StrSpecimen_Notes + "',processid=" + StrProcessID + " where testid=" + StrTestID + " and bookingid=" + StrBookingID + " and bookingdid=" + StrBookingDID + " ";
               StrError = objTrans.DataTrigger_Update(objdbhims);

               if (!StrError.Equals("True"))
               {
                   objdbhims.Query = "insert into dc_tstatustrack (labid,testid,processid,enteredby,enteredon,clientid,bookingdid) values ('" + StrLabID + "'," + StrTestID + ",3," + StrEnteredBy + ",str_to_date('" + StrEnteredOn + "','%d/%m/%Y %h:%i:%s %p'),'" + StrClientID + "',"+StrBookingDID+")";
                   StrError = objTrans.DataTrigger_Insert(objdbhims);

                   if (StrError.Equals("True"))
                   {
                       StrError = objTrans.OperationError;
                       objTrans.End_Transaction();
                       return false;
                   }
                   else
                   {
                       objdbhims.Query = objQB.QBInsert(MakeArray(), "dc_tspecimen_get");
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
                   StrError = objTrans.OperationError;
                   objTrans.End_Transaction();
                   return false;
               }
           }
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

       private string[,] MakeArray()
       {
           string[,] kdcArr = new string[13, 3];

           if (!StrSpec_Number.Equals(Default) && !StrSpec_Number.Equals(""))
           {
               kdcArr[0, 0] = "s_number";
               kdcArr[0, 1] = this.StrSpec_Number;
               kdcArr[0, 2] = "string";
           }
           if (!StrSpec_Nature.Equals(Default) && !StrSpec_Nature.Equals(""))
           {
               kdcArr[1, 0] = "name";
               kdcArr[1, 1] = this.StrSpec_Nature;
               kdcArr[1, 2] = "string";
           }
           if (!StrQty.Equals(Default) && !StrQty.Equals(""))
           {
               kdcArr[2, 0] = "qty";
               kdcArr[2, 1] = this.StrQty;
               kdcArr[2, 2] = "string";
           }
           if (!StrUnit.Equals(Default) && !StrUnit.Equals(""))
           {
               kdcArr[3, 0] = "unit";
               kdcArr[3, 1] = this.StrUnit;
               kdcArr[3, 2] = "string";
           }

           if (!StrContainer.Equals(Default) && !StrContainer.Equals(""))
           {
               kdcArr[4, 0] = "container";
               kdcArr[4, 1] = this.StrContainer;
               kdcArr[4, 2] = "string";
           }
           if (!StrLabID.Equals(Default) && !StrLabID.Equals(""))
           {
               kdcArr[5, 0] = "labID";
               kdcArr[5, 1] = this.StrLabID;
               kdcArr[5, 2] = "string";
           }
           if (!StrTestID.Equals(Default) && !StrTestID.Equals(""))
           {
               kdcArr[6, 0] = "testid";
               kdcArr[6, 1] = this.StrTestID;
               kdcArr[6, 2] = "string";
           }
           if (!StrBattery_No.Equals(Default) && !StrBattery_No.Equals(""))
           {
               kdcArr[7, 0] = "battery_no";
               kdcArr[7, 1] = this.StrBattery_No;
               kdcArr[7, 2] = "string";
           }
           if (!StrEnteredBy.Equals(Default))
           {
               kdcArr[8, 0] = "enteredby";
               kdcArr[8, 1] = this.StrEnteredBy;
               kdcArr[8, 2] = "int";
           }
           if (!StrEnteredOn.Equals(Default))
           {
               kdcArr[9, 0] = "enteredon";
               kdcArr[9, 1] = this.StrEnteredOn;
               kdcArr[9, 2] = "datetime";
           }
           if (!StrClientID.Equals(Default))
           {
               kdcArr[10, 0] = "clientid";
               kdcArr[10, 1] = this.StrClientID;
               kdcArr[10, 2] = "string";
           }
           if (!StrBookingID.Equals(Default))
           {
               kdcArr[11, 0] = "bookingid";
               kdcArr[11, 1] = this.StrBookingID;
               kdcArr[11, 2] = "int";
           }
           if (!StrBookingDID.Equals(Default))
           {
               kdcArr[12, 0] = "bookingdid";
               kdcArr[12, 1] = this.StrBookingDID;
               kdcArr[12, 2] = "int";
           }
           return kdcArr;
       }


       #endregion
   }
}
