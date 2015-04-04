using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataLayer;

namespace BusinessLayer
{
   public class clsBLDispatch
   {
       clsdbhims objdbhims = new clsdbhims();
       clsoperation objTrans = new clsoperation();

       #region"Variables"

       private const string Default = "~!@";
       private const string TableName = "";
       private string StrError = Default;

       private string StrPRNO = Default;
       private string StrLabID = Default;
       private string StrPatientName = Default;

       private string StrGender = Default;
       private string StrAge = Default;
       private string StrStatus = Default;

       private string StrPanelID = Default;
       private string StrEmployeeName = Default;
       private string StrEmployeeNumber = Default;

       private string StrDepartmentID = Default;
       private string StrSubDepartmentID = Default;
       private string StrGroupID = Default;
       private string StrTestID = Default;

       private string StrProcessID = Default;
       private string StrType = Default;
       private string StrFromDate = Default;
       private string StrToDate = Default;

       private string StrPRID = Default;
       private string StrBookingID = Default;
       private string StrBookingDID = Default;
       private string StrProvisionRpt = Default;

       private string StrEnteredOn = Default;
       private string StrEnteredBy = Default;
       private string StrClientID = Default;

       private string StrCellNo = Default;
       private string StrPhoneNo = Default;
       private string StrReferenceNO = Default;
       private string StrInd_OutDor = Default;

       private string StrWardID = Default;
       private string StrAdmNo = Default;

       private string _BranchID = Default;
       private string _Internal = Default;

       
    
       #endregion

       #region"Properties"

       public string Error
       {
           get { return StrError; }
           set { StrError = value; }
       }

       public string PRNO
       {
           get { return StrPRNO; }
           set { StrPRNO = value; }
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
       public string Status
       {
           get { return StrStatus; }
           set { StrStatus = value; }
       }

       public string PanelID
       {
           get { return StrPanelID; }
           set { StrPanelID = value; }
       }
       public string EmployeeName
       {
           get { return StrEmployeeName; }
           set { StrEmployeeName = value; }
       }
       public string EmployeeNumber
       {
           get { return StrEmployeeNumber; }
           set { StrEmployeeNumber = value; }
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

       public string ProcessID
       {
           get { return StrProcessID; }
           set { StrProcessID = value; }
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

       public string PRID
       {
           get { return StrPRID; }
           set { StrPRID = value; }
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
       public string ProvisionRpt
       {
           get { return StrProvisionRpt; }
           set { StrProvisionRpt = value; }
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

       public string CellNo
       {
           get { return StrCellNo; }
           set { StrCellNo = value; }
       }
       public string PhoneNo
       {
           get { return StrPhoneNo; }
           set { StrPhoneNo = value; }
       }
       public string ReferenceNo
       {
           get { return StrReferenceNO; }
           set { StrReferenceNO = value; }
       }
       public string Ind_Out
       {
           get { return StrInd_OutDor; }
           set { StrInd_OutDor = value; }
       }

       public string WardID
       {
           get { return StrWardID; }
           set { StrWardID = value; }
       }
       public string AdmNo
       {
           get { return StrAdmNo; }
           set { StrAdmNo = value; }
       }

       public string BranchID
       {
           get { return _BranchID; }
           set { _BranchID = value; }
       }
       public string Internal
       {
           get { return _Internal; }
           set { _Internal = value; }
       }

       #endregion

       #region"Method"

       public DataView GetAll(int flag)
       {
           switch (flag)
           {
               case 1: // fill status
                   objdbhims.Query = "select processid,case when processid=2 then 'Un Paid' when processid=8 then 'Delivered' else name end as name from dc_tp_tprocess where active='Y' and processid not in (1,9,10,11)";
                   break;
               case 2: // fill Panel
                   objdbhims.Query = "select panelid,name from dc_tpanel where active='Y'";
                   break;
               case 3: // fill department
                   objdbhims.Query = "select departmentid,name from dc_tp_departments where active='Y'";
                   break;
               case 4: // fill subdepartment
                   objdbhims.Query = "select subdepartmentid,name from dc_tp_subdepartments where active='Y'";
                   if (!StrDepartmentID.Equals(Default) && !StrDepartmentID.Equals(""))
                       objdbhims.Query += " and departmentid=" + StrDepartmentID + "";
                   break;
               case 5: // fill group
                   objdbhims.Query = "select groupid,name from dc_tp_groupm where active='Y'";
                   break;
               case 6: // fill test
                   objdbhims.Query = "select testid,test_name from dc_tp_test where active='Y'";
                   if (!StrDepartmentID.Equals(Default) && !StrDepartmentID.Equals(""))
                       objdbhims.Query += " and testid in (select testid from dc_Tp_test where subdepartmentid in (select subdepartmentid from dc_tp_subdepartments where departmentid=" + StrDepartmentID + "))";
                   if (!StrSubDepartmentID.Equals(Default) && !StrSubDepartmentID.Equals(""))
                       objdbhims.Query += " and subdepartmentid=" + StrSubDepartmentID + "";
                   break;
               case 7: // fill grid
                   ////////////////////////Catering branches//////////////////////
                   objdbhims.Query = @"select t.TestType,p.prno,b.name origin,t.subdepartmentId,
                                        concat(ifnull(p.title,''),' ',p.name,' ( ',case when p.gender='M' then 'Male' else 'Female' end,
                                        ' : ',
                                        case when DATEDIFF(CURRENT_DATE,p.dob) > 365 then
                                        concat(Floor(DATEDIFF(CURRENT_DATE,p.dob)/365),' Yrs')
                                        else case when DATEDIFF(CURRENT_DATE,p.dob) > 30
                                        then concat(Floor(DATEDIFF(CURRENT_DATE,p.dob)/30),' Mon')
                                        else concat(DATEDIFF(CURRENT_DATE,p.dob),'Dys') end end,' ) ')   as patientname,
                                        bm.labid,bd.testid,bd.processid,t.test_name,bm.bookingid,p.prid,
                                        date_format(bd.deliverytime,'%d/%m/%Y %h:%i %p') as deliveryon,
                                        date_format(bm.enteredon,'%d/%m/%Y %h:%i %p') as bookedon,
                                        (select max(date_format(enteredon,'%d/%m/%Y %h:%i %p'))
                                        from dc_tstatustrack where labid=bm.labid and testid=bd.testid and processid=7) as dispatchon,
                                        case when ifnull(bm.totalamount,0)-((ifnull(bm.paidamount,0)+ifnull(bm.discount_amt,0))-ifnull((select sum(paidamount) from dc_tcashrefund where labid=bm.labid and refundtype<>'D' ),0)) >0
                                        then ifnull(bm.totalamount,0)-((ifnull(bm.paidamount,0)+ifnull(bm.discount_amt,0))-ifnull((select sum(paidamount) from dc_tcashrefund
                                        where labid=bm.labid and refundtype<>'D' ),0)) else '-' end as balance,
                                        t.provisionrpt,bm.referenceno,case when bm.type ='I' then 'Indoor' else 'Outdoor' end as ind_out,
                                        bd.bookingdid ,og.acronym as origin1 ,bm.payment_mode

                                        from dc_tpatient p left outer join dc_Tpatient_bookingm bm on p.prid=bm.prid
                                        left outer join dc_tpatient_bookingd bd on bm.bookingid = bd.bookingid
                                        left outer join dc_tp_test t on bd.testid=t.testid
                                        left outer join dc_tp_organization og on og.orgid=bm.clientid
                                        left outer join dc_tp_ward wd on wd.wardid = bm.wardid
                                        left outer join dc_tp_branch b on b.BranchID=bm.BranchID

                                        where 1=1";
                   if (StrType.Equals("C"))
                       objdbhims.Query += " and bm.payment_mode <>'A'";//p
                   if (StrType.Equals("P"))
                       objdbhims.Query += " and bm.payment_mode='A'";//p.panelid is not null
                   if (!StrPatientName.Equals(Default) && !StrPatientName.Equals(""))
                       objdbhims.Query += " and p.name like '%" + StrPatientName + "%'";
                   if (!StrPRNO.Equals(Default) && !StrPRNO.Equals(""))
                       objdbhims.Query += " and p.prno='" + StrPRNO + "'";
                   if (!StrLabID.Equals(Default) && !StrLabID.Equals(""))
                       objdbhims.Query += " and bm.labid='" + StrLabID + "'";

                   if (!StrProcessID.Equals(Default) && !StrProcessID.Equals(""))
                       objdbhims.Query += " and bd.processid in (" + StrProcessID + ")";
                   if (!StrPanelID.Equals(Default) && !StrPanelID.Equals(""))
                       objdbhims.Query += " and bm.panelid=" + StrPanelID + "";
                   if (!StrEmployeeNumber.Equals(Default) && !StrEmployeeNumber.Equals(""))
                       objdbhims.Query += " and p.serviceno = '" + StrEmployeeNumber + "'";

                   if (!StrDepartmentID.Equals(Default) && !StrDepartmentID.Equals(""))
                       objdbhims.Query += " and bd.testid in (select testid from dc_Tp_test where subdepartmentid in (select subdepartmentid from dc_tp_subdepartments where departmentid=" + StrDepartmentID + "))";
                   if (!StrSubDepartmentID.Equals(Default) && !StrSubDepartmentID.Equals(""))
                       objdbhims.Query += " and t.subdepartmentid=" + StrSubDepartmentID + "";
                   if (!StrGroupID.Equals(Default) && !StrGroupID.Equals(""))
                       objdbhims.Query += " and t.groupid=" + StrGroupID + "";
                   if (!StrGender.Equals(Default))
                       objdbhims.Query += " and p.gender='" + StrGender + "'";
                   if (!StrTestID.Equals(Default) && !StrTestID.Equals(""))
                       objdbhims.Query += " and t.testid=" + StrTestID + "";
                   if (!StrFromDate.Equals(Default) && !StrToDate.Equals(Default))
                       objdbhims.Query += " and date_format(bm.enteredon,'%Y/%m/%d') between '" + StrFromDate + "' and '" + StrToDate + "'";
                   if (!StrCellNo.Equals(Default))
                       objdbhims.Query += " and p.cellno like '%" + StrCellNo + "%'";
                   if (!StrPhoneNo.Equals(Default))
                       objdbhims.Query += " and p.hphone like '%" + StrPhoneNo + "%'";
                   if (!StrReferenceNO.Equals(Default) && !StrReferenceNO.Equals(""))
                       objdbhims.Query += " and bm.referenceno like '%" + StrReferenceNO + "%'";
                   if (!StrInd_OutDor.Equals(Default))
                       objdbhims.Query += " and bm.type='"+StrInd_OutDor+"'";
                   if (!StrWardID.Equals(Default))
                       objdbhims.Query += " and bm.wardid='"+StrWardID+"'";
                   if (!StrAdmNo.Equals(Default) && !StrAdmNo.Equals(""))
                       objdbhims.Query += " and bm.adm_ref like '%" + StrAdmNo + "%'";
                   if (!_BranchID.Equals(Default) && !_BranchID.Equals("") && _Internal.Equals("Y"))
                       objdbhims.Query += " and bm.BranchID=" + Convert.ToInt32(_BranchID);
                   if (!_BranchID.Equals(Default) && !_BranchID.Equals("") && _Internal.Equals("N"))
                       objdbhims.Query += " and bm.BranchID!=" + Convert.ToInt32(_BranchID);
                   objdbhims.Query += " order by bm.bookingid desc";        
                   ///////////////////////////-------////////////////////////////


                   //objdbhims.Query = "select p.prno, concat(ifnull(p.title,''),' ',p.name,' ( ',case when p.gender='M' then 'Male' else 'Female' end,' : ', case when DATEDIFF(CURRENT_DATE,p.dob) > 365 then concat(Floor(DATEDIFF(CURRENT_DATE,p.dob)/365),' Yrs')  else case when DATEDIFF(CURRENT_DATE,p.dob) > 30 then concat(Floor(DATEDIFF(CURRENT_DATE,p.dob)/30),' Mon') else      concat(DATEDIFF(CURRENT_DATE,p.dob),'Dys') end end,' ) ')   as patientname,bm.labid,bd.testid,bd.processid,t.test_name,bm.bookingid,p.prid,date_format(bd.deliverytime,'%d/%m/%Y %h:%i %p') as deliveryon,date_format(bm.enteredon,'%d/%m/%Y %h:%i %p') as bookedon,(select max(date_format(enteredon,'%d/%m/%Y %h:%i %p')) from dc_tstatustrack where labid=bm.labid and testid=bd.testid and processid=7) as dispatchon,case when ifnull(bm.totalamount,0)-((ifnull(bm.paidamount,0)+ifnull(bm.discount_amt,0))-ifnull((select sum(paidamount) from dc_tcashrefund where labid=bm.labid and refundtype<>'D' ),0)) >0 then ifnull(bm.totalamount,0)-((ifnull(bm.paidamount,0)+ifnull(bm.discount_amt,0))-ifnull((select sum(paidamount) from dc_tcashrefund where labid=bm.labid and refundtype<>'D' ),0)) else '-' end as balance,t.provisionrpt,bm.referenceno,case when bm.type ='I' then 'Indoor' else 'Outdoor' end as ind_out,bd.bookingdid ,og.acronym as origin ,bm.payment_mode from dc_tpatient p left outer join dc_Tpatient_bookingm bm on p.prid=bm.prid left outer join dc_tpatient_bookingd bd on bm.bookingid = bd.bookingid left outer join dc_tp_test t on bd.testid=t.testid left outer join dc_tp_organization og on og.orgid=bm.clientid left outer join dc_tp_ward wd on wd.wardid = bm.wardid where 1=1 and bm.BranchID="+Convert.ToInt32(_BranchID);
                   //if (StrType.Equals("C"))
                   //    objdbhims.Query += " and bm.payment_mode <>'A'";//p
                   //if (StrType.Equals("P"))
                   //    objdbhims.Query += " and bm.payment_mode='A'";//p.panelid is not null
                   //if (!StrPatientName.Equals(Default) && !StrPatientName.Equals(""))
                   //    objdbhims.Query += " and p.name like '%" + StrPatientName + "%'";
                   //if (!StrPRNO.Equals(Default) && !StrPRNO.Equals(""))
                   //    objdbhims.Query += " and p.prno='" + StrPRNO + "'";
                   //if (!StrLabID.Equals(Default) && !StrLabID.Equals(""))
                   //    objdbhims.Query += " and bm.labid='" + StrLabID + "'";

                   //if (!StrProcessID.Equals(Default) && !StrProcessID.Equals(""))
                   //    objdbhims.Query += " and bd.processid in (" + StrProcessID + ")";
                   //if (!StrPanelID.Equals(Default) && !StrPanelID.Equals(""))
                   //    objdbhims.Query += " and bm.panelid=" + StrPanelID + "";
                   //if (!StrEmployeeNumber.Equals(Default) && !StrEmployeeNumber.Equals(""))
                   //    objdbhims.Query += " and p.serviceno = '" + StrEmployeeNumber + "'";

                   //if (!StrDepartmentID.Equals(Default) && !StrDepartmentID.Equals(""))
                   //    objdbhims.Query += " and bd.testid in (select testid from dc_Tp_test where subdepartmentid in (select subdepartmentid from dc_tp_subdepartments where departmentid=" + StrDepartmentID + "))";
                   //if (!StrSubDepartmentID.Equals(Default) && !StrSubDepartmentID.Equals(""))
                   //    objdbhims.Query += " and t.subdepartmentid=" + StrSubDepartmentID + "";
                   //if (!StrGroupID.Equals(Default) && !StrGroupID.Equals(""))
                   //    objdbhims.Query += " and t.groupid=" + StrGroupID + "";
                   //if (!StrGender.Equals(Default))
                   //    objdbhims.Query += " and p.gender='" + StrGender + "'";
                   //if (!StrTestID.Equals(Default) && !StrTestID.Equals(""))
                   //    objdbhims.Query += " and t.testid=" + StrTestID + "";
                   //if (!StrFromDate.Equals(Default) && !StrToDate.Equals(Default))
                   //    objdbhims.Query += " and date_format(bm.enteredon,'%Y/%m/%d') between '" + StrFromDate + "' and '" + StrToDate + "'";
                   //if (!StrCellNo.Equals(Default))
                   //    objdbhims.Query += " and p.cellno like '%" + StrCellNo + "%'";
                   //if (!StrPhoneNo.Equals(Default))
                   //    objdbhims.Query += " and p.hphone like '%" + StrPhoneNo + "%'";
                   //if (!StrReferenceNO.Equals(Default) && !StrReferenceNO.Equals(""))
                   //    objdbhims.Query += " and bm.referenceno like '%" + StrReferenceNO + "%'";
                   //if (!StrInd_OutDor.Equals(Default))
                   //    objdbhims.Query += " and bm.type='"+StrInd_OutDor+"'";
                   //if (!StrWardID.Equals(Default))
                   //    objdbhims.Query += " and bm.wardid='"+StrWardID+"'";
                   //if (!StrAdmNo.Equals(Default) && !StrAdmNo.Equals(""))
                   //    objdbhims.Query += " and bm.adm_ref like '%" + StrAdmNo + "%'";

                   //objdbhims.Query += " order by bm.bookingid desc";
                   break;
               case 8: // fill grid
                   objdbhims.Query = "select p.prno, concat(ifnull(p.title,''),' ',p.name) as patientname,bm.labid,bd.testid,bd.processid,t.test_name,bm.bookingid,p.prid,date_format(bm.enteredon,'%d/%m/%Y %h:%i') as bookedon,(SELECT cast(group_concat(p.processid) as char)  FROM dc_tp_tprocedured p where p.procedureid=t.procedureid group by p.procedureid) as procedureid,bd.bookingdid,og.acronym as origin,(case when bm.type='I' then concat(w.name,':', bm.adm_ref) else '-' end) as adm_info from dc_tpatient p left outer join dc_Tpatient_bookingm bm on p.prid=bm.prid left outer join  dc_tpatient_bookingd bd on bm.bookingid = bd.bookingid left outer join dc_tp_test t on bd.testid=t.testid left outer join dc_tp_organization og on og.orgid=bm.clientid left outer join dc_tp_ward w on w.wardid=bm.wardid where 1=1 and bm.BranchID="+Convert.ToInt32(_BranchID);   ////and bd.processid in (7,8)
                   if (StrType.Equals("C"))
                   {
                       objdbhims.Query += " and p.panelid is null";
                   }
                   if (StrType.Equals("P"))
                   {
                       objdbhims.Query += " and p.panelid is not null";
                   }
                   if (!StrPatientName.Equals(Default) && !StrPatientName.Equals(""))
                   {
                       objdbhims.Query += " and p.name like '%" + StrPatientName + "%'";
                   }
                   if (!StrPRNO.Equals(Default) && !StrPRNO.Equals(""))
                   {
                       objdbhims.Query += " and p.prno='" + StrPRNO + "'";
                   }
                   if (!StrLabID.Equals(Default) && !StrLabID.Equals(""))
                   {
                       objdbhims.Query += " and bm.labid='" + StrLabID + "'";
                   }
                   if (!StrPanelID.Equals(Default) && !StrPanelID.Equals(""))
                   {
                       objdbhims.Query += " and p.panelid=" + StrPanelID + "";
                   }
                   if (!StrEmployeeNumber.Equals(Default) && !StrEmployeeNumber.Equals(""))
                   {
                       objdbhims.Query += " and p.serviceno = '" + StrEmployeeNumber + "'";
                   }
                   if (!StrDepartmentID.Equals(Default) && !StrDepartmentID.Equals(""))
                   {
                       objdbhims.Query += " and bd.testid in (select testid from dc_Tp_test where subdepartmentid in (select subdepartmentid from dc_tp_subdepartments where departmentid=" + StrDepartmentID + "))";
                   }
                   if (!StrSubDepartmentID.Equals(Default) && !StrSubDepartmentID.Equals(""))
                   {
                       objdbhims.Query += " and t.subdepartmentid=" + StrSubDepartmentID + "";
                   }
                   if (!StrGroupID.Equals(Default) && !StrGroupID.Equals(""))
                   {
                       objdbhims.Query += " and t.groupid=" + StrGroupID + "";
                   }
                   if (!StrGender.Equals(Default))
                   {
                       objdbhims.Query += " and p.gender='" + StrGender + "'";
                   }
                   if (!StrTestID.Equals(Default) && !StrTestID.Equals(""))
                   {
                       objdbhims.Query += " and t.testid=" + StrTestID + "";
                   }
                   if (!StrFromDate.Equals(Default) && !StrToDate.Equals(Default))
                   {
                       objdbhims.Query += " and date_format(bm.enteredon,'%Y/%m/%d') between '" + StrFromDate + "' and '" + StrToDate + "'";
                   }

                   objdbhims.Query += " order by bm.bookingid desc";
                   break;
               case 9: // fill test
                   objdbhims.Query = "SELECT g.`prid`, g.`prno`, g.`name`, g.`gender`, g.`address`, g.`age`, g.`testid`, g.`test_name`, g.`sepreport`, g.`printgroup`, g.`printtest`, g.`groupid`, g.`reportformat`, g.`totaltext`, g.`automatedtext`, g.`groupname`, g.`labid`, g.`bookingid`, g.`consultant`, g.`registrationDate`,g.`processid`, g.`code`, g.`title`, g.`referenceno`, g.`subdepartmentid`,g.Panel,g.departmentid , g.`bookingdid`,g.ind_outdoor,g.phoneno,g.origin_place FROM general_result_main g where 1=1 ";
                   if (!StrPRID.Equals(Default))
                   {
                       objdbhims.Query += " and PRID in (" + StrPRID + ") ";
                   }
                   if (!StrTestID.Equals(Default))
                   {
                       objdbhims.Query += " and Testid in (" + StrTestID + ") ";
                   }
                   if (!StrBookingID.Equals(Default))
                   {
                       objdbhims.Query += " and bookingid in (" + StrBookingID + ")";
                   }

                   break;
               case 10: // Filter Report Result Detail
                   objdbhims.Query = "SELECT r.`resultid`, r.`bookingid`, r.`testid`, r.`prid`, r.`attributeid`, r.`result`, r.`attribute_name`, r.`min_value`, r.`max_value`, r.`aunit`, r.`attrib_droder`, r.`attribute_type`, r.`resultdate`, r.`heading`, r.`rangedescription`, r.`dorder`, r.`abnormal`,(SELECT concat(d2.result,' _ ',d2.abnormal)  as result FROM general_result_detail d2 where d2.attributeID=r.attributeid and d2.prid=r.prid and r.bookingid > d2.bookingid group by d2.Resultdate, d2.testid,d2.bookingid order by d2.Resultdate desc limit 0,1) as 1st,(SELECT concat(d2.result,' _ ',d2.abnormal)  as result FROM general_result_detail d2 where d2.attributeID=r.attributeid and d2.prid=r.prid and r.bookingid > d2.bookingid group by d2.Resultdate, d2.testid,d2.bookingid order by d2.Resultdate desc limit 1,1) as 2nd,(SELECT concat(d2.result,' _ ',d2.abnormal)  as result FROM general_result_detail d2 where d2.attributeID=r.attributeid and d2.prid=r.prid and r.bookingid > d2.bookingid group by d2.Resultdate, d2.testid,d2.bookingid order by d2.Resultdate desc limit 2,1) as 3rd, cast((SELECT d2.resultDate FROM general_result_detail d2 where d2.attributeID=r.attributeid and d2.prid=r.prid and r.bookingid > d2.bookingid group by d2.Resultdate, d2.testid,d2.bookingid order by d2.Resultdate desc limit 0,1) as datetime) as 1stDate,cast((SELECT d2.resultDate FROM general_result_detail d2 where d2.attributeID=r.attributeid and d2.prid=r.prid and r.bookingid > d2.bookingid group by d2.Resultdate, d2.testid, d2.bookingid order by d2.Resultdate desc limit 1,1) as Datetime) as 2ndDate,cast((SELECT d2.resultDate FROM general_result_detail d2 where d2.attributeID=r.attributeid and d2.prid=r.prid and r.bookingid > d2.bookingid group by d2.Resultdate, d2.testid,d2.bookingid order by d2.Resultdate desc limit 2,1) as Datetime) as 3rdDate FROM general_result_detail r where 1=1";
                       //"SELECT r.`resultid`,r.bookingdid, r.`bookingid`, r.`testid`, r.`prid`, r.`attributeid`, r.`result`, r.`attribute_name`, r.`min_value`, r.`max_value`, r.`aunit`, r.`attrib_droder`, r.`attribute_type`, r.`resultdate`, r.`heading`, r.`rangedescription`, r.`dorder`, r.`abnormal`,(SELECT d2.result FROM general_result_detail d2 where d2.attributeID=r.attributeid and d2.prid=r.prid and r.bookingdid<>d2.bookingdid group by d2.Resultdate, d2.testid,d2.bookingdid order by d2.Resultdate desc limit 0,1) as 1st,(SELECT d2.result FROM general_result_detail d2 where d2.attributeID=r.attributeid and d2.prid=r.prid and r.bookingdid<>d2.bookingdid group by d2.Resultdate, d2.testid,d2.bookingdid order by d2.Resultdate desc limit 1,1) as 2nd,(SELECT d2.result FROM general_result_detail d2 where d2.attributeID=r.attributeid and d2.prid=r.prid and r.bookingdid<>d2.bookingdid group by d2.Resultdate, d2.testid,d2.bookingdid order by d2.Resultdate desc limit 2,1) as 3rd, cast((SELECT d2.resultDate FROM general_result_detail d2 where d2.attributeID=r.attributeid and d2.prid=r.prid and r.bookingdid<>d2.bookingdid group by d2.Resultdate, d2.testid,d2.bookingdid order by d2.Resultdate desc limit 0,1) as datetime) as 1stDate,cast((SELECT d2.resultDate FROM general_result_detail d2 where d2.attributeID=r.attributeid and d2.prid=r.prid and r.bookingdid<>d2.bookingdid group by d2.Resultdate, d2.testid, d2.bookingdid order by d2.Resultdate desc limit 1,1) as Datetime) as 2ndDate,cast((SELECT d2.resultDate FROM general_result_detail d2 where d2.attributeID=r.attributeid and d2.prid=r.prid and r.bookingdid<>d2.bookingdid group by d2.Resultdate, d2.testid,d2.bookingdid order by d2.Resultdate desc limit 2,1) as Datetime) as 3rdDate FROM general_result_detail r where 1=1";
                   if (!StrPRID.Equals(Default))
                   {
                       objdbhims.Query += " and PRID in (" + StrPRID + ") ";
                   }
                   if (!StrTestID.Equals(Default))
                   {
                       objdbhims.Query += " and Testid in (" + StrTestID + ") ";
                   }
                   if (!StrBookingID.Equals(Default))
                   {
                       objdbhims.Query += " and bookingid in (" + StrBookingID + ")";
                   }
                   break;
               case 11: // ward fill
                   objdbhims.Query = "select wardid,name from dc_tp_ward where active='Y'";
                   break;
           }
           return objTrans.DataTrigger_Get_All(objdbhims);
 
       }

       public bool Dispatch(string[,] str)
       {
           objTrans.Start_Transaction();

           for (int i = 0; i <= str.GetUpperBound(0); i++)
           {
               StrPRID = str[i, 0]; // prid
               StrBookingID = str[i, 1]; // bookingid
               StrTestID = str[i, 2]; //testid
               StrLabID = str[i, 3]; // labid
               StrProcessID = str[i, 4]; // processID
               StrBookingDID = str[i, 5]; // bookingDID

               if (!StrProcessID.Equals("6"))
               {
                   objdbhims.Query = "update dc_tpatient_bookingd set processid=8 where testid=" + StrTestID + " and bookingid=" + StrBookingID + " and bookingdid=" + StrBookingDID + "";
                   StrError = objTrans.DataTrigger_Update(objdbhims);

                   if (StrError.Equals("True"))
                   {
                       objTrans.End_Transaction();
                       StrError = objTrans.OperationError;
                       return false;
                   }
                   else
                   {
                       objdbhims.Query = "insert into dc_tstatustrack (labid,processid,testid,enteredby,enteredon,clientid,bookingdid) values ('" + StrLabID + "',7," + StrTestID + "," + StrEnteredBy + ",str_to_date('" + StrEnteredOn + "','%d/%m/%Y %h:%i:%s %p'),'" + StrClientID + "',"+StrBookingDID+")";
                       StrError = objTrans.DataTrigger_Insert(objdbhims);
                       if (StrError.Equals("True"))
                       {
                           objTrans.End_Transaction();
                           StrError = objTrans.OperationError;
                           return false;
                       }
                   }
               }
               else
               {
                   objdbhims.Query = "insert into dc_tstatustrack (labid,processid,testid,enteredby,enteredon,clientid,bookingdid) values ('" + StrLabID + "',7," + StrTestID + "," + StrEnteredBy + ",str_to_date('" + StrEnteredOn + "','%d/%m/%Y %h:%i:%s %p'),'" + StrClientID + "',"+StrBookingDID+")";
                   StrError = objTrans.DataTrigger_Insert(objdbhims);
                   if (StrError.Equals("True"))
                   {
                       objTrans.End_Transaction();
                       StrError = objTrans.OperationError;
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
               objTrans.End_Transaction();
               StrError = objTrans.OperationError;
               return false;
           }
       }
             
       #endregion
   }
}
