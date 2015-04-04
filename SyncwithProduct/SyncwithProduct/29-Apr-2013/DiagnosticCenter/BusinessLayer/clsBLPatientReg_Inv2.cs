using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataLayer;
using System.Globalization;
using System.Web.UI;

namespace BusinessLayer
{
    public class clsBLPatientReg_Inv : Page
    {
        clsdbhims objdbhims = new clsdbhims();
        clsoperation objTrans = new clsoperation();

        #region"Variables"

        private const string Default = "~!@";
        private const string Table_Patient = "dc_tpatient";
        private const string Table_BookingM = "dc_Tpatient_bookingm";
        private const string Table_BookingD = "dc_tpatient_bookingd";
        private const string Table_Cash = "dc_tcashcollection";

        private string StrPRID = Default;
        private string StrPRNO = Default;
        private string StrTitle = Default;
        private string StrName = Default;

        private string StrGender = Default;
        private string StrDOB = Default;
        private string StrMaritalStatus = Default;

        private string StrHphone = Default;
        private string StrCellNo = Default;
        private string StrFax = Default;

        private string StrEmail = Default;
        private string StrCNIC = Default;

        private string StrPanelID = Default;
        private string StrClassID = Default;
        private string StrServiceNo = Default;
        private string StrAuthorizeNo = Default;

        private string StrEnteredBy = Default;
        private string StrEnteredOn = Default;
        private string StrClientID = Default;
        private string StrAddress = Default;

        private string StrBookingID = Default;
        private string StrPriority = Default;
        private string StrType = Default;
        private string StrPatient_Type = Default;
        private string StrPaymentMode = Default;

        private string StrLabID = Default;
        private string StrTotalAmount = Default;
        private string StrPaidAmount = Default;

        private string StrDoctorID = Default;
        private string StrReferredBY = Default;

        private string StrOrgin_Place = Default;
        private string StrDeliveryBy = Default;

        private string StrBookingDetailID = Default;
        private string StrTestID = Default;
        private string StrReceive_No = Default;

        private string StrStatus = Default;
        private string StrREfundNo = Default;
        private string StrRefundType = Default;
        private string StrDelivery_Time = Default;

        private string StrTestAmount = Default;
        private string StrTest_PaidAmt = Default;
        private string StrClassificationID = Default;

        private string StrDepartmentID = Default;
        private string StrSubDepartmentID = Default;
        private string StrGroupID = Default;

        private string StrError = Default;
        private string StrBranchID = Default;
        private string StrSpeedKey = Default;
        private string StrOrgID = Default;

        private string Str_F_Parent = Default;
        private string Str_S_Parent = Default;
        private string StrRelation = Default;

        private string StrParent = Default;
        private string StrProcessID = Default;
        private string StrDiscount = Default;
        private string StrDiscount_Amt_Test = Default;

        private string StrP_Salutation = Default;
        private string StrP_Name = Default;
        private string StrP_Gender = Default;

        private string StrP_DOB = Default;
        private string StrP_Marital = Default;
        private string StrRate = Default;

        private string StrReferenceNo = Default; // AFH 100522
        private string StrPassword = Default;
        private string StrCard_ReferenceNo = Default;

        private string StrFor_Process = Default;
        private string StrInt_Comment = Default;
        private string StrRemarks = Default;
        private string StrWardID = Default;
        private string StrBed = Default;
        private string StrAdm_Ref = Default;
        #endregion

        #region"Properties"

        public string PRID
        {
            get { return StrPRID; }
            set { StrPRID = value; }
        }
        public string PRNO
        {
            get { return StrPRNO; }
            set { StrPRNO = value; }
        }
        public string Title
        {
            get { return StrTitle; }
            set { StrTitle = value; }
        }

        public string Name
        {
            get { return StrName; }
            set { StrName = value; }
        }
        public string Gender
        {
            get { return StrGender; }
            set { StrGender = value; }
        }
        public string DOB
        {
            get { return StrDOB; }
            set { StrDOB = value; }
        }
        public string MaritalStatus
        {
            get { return StrMaritalStatus; }
            set { StrMaritalStatus = value; }
        }

        public string HPhone
        {
            get { return StrHphone; }
            set { StrHphone = value; }
        }
        public string CellNo
        {
            get { return StrCellNo; }
            set { StrCellNo = value; }
        }
        public string Fax
        {
            get { return StrFax; }
            set { StrFax = value; }
        }

        public string Email
        {
            get { return StrEmail; }
            set { StrEmail = value; }
        }
        public string CNIC
        {
            get { return StrCNIC; }
            set { StrCNIC = value; }
        }

        public string PanelID
        {
            get { return StrPanelID; }
            set { StrPanelID = value; }
        }
        public string ClassID
        {
            get { return StrClassID; }
            set { StrClassID = value; }
        }
        public string ServiceNo
        {
            get { return StrServiceNo; }
            set { StrServiceNo = value; }
        }
        public string AuthorizeNo
        {
            get { return StrAuthorizeNo; }
            set { StrAuthorizeNo = value; }
        }

        public string Address
        {
            get { return StrAddress; }
            set { StrAddress = value; }
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

        public string BookingID
        {
            get { return StrBookingID; }
            set { StrBookingID = value; }
        }
        public string Patient_Type
        {
            get { return StrPatient_Type; }
            set { StrPatient_Type = value; }
        }
        public string Type
        {
            get { return StrType; }
            set { StrType = value; }
        }
        public string PaymentMode
        {
            get { return StrPaymentMode; }
            set { StrPaymentMode = value; }
        }

        public string LabID
        {
            get { return StrLabID; }
            set { StrLabID = value; }
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

        public string ReferredBy
        {
            get { return StrReferredBY; }
            set { StrReferredBY = value; }
        }
        public string DoctorID
        {
            get { return StrDoctorID; }
            set { StrDoctorID = value; }
        }
        public string Orgin_Place
        {
            get { return StrOrgin_Place; }
            set { StrOrgin_Place = value; }
        }

        public string DeliveryBy
        {
            get { return StrDeliveryBy; }
            set { StrDeliveryBy = value; }
        }
        public string Receive_NO
        {
            get { return StrReceive_No; }
            set { StrReceive_No = value; }
        }

        public string BookingDID
        {
            get { return StrBookingDetailID; }
            set { StrBookingDetailID = value; }
        }
        public string TestID
        {
            get { return StrTestID; }
            set { StrTestID = value; }
        }
        public string Status
        {
            get { return StrStatus; }
            set { StrStatus = value; }
        }

        public string Refund_No
        {
            get { return StrREfundNo; }
            set { StrREfundNo = value; }
        }
        public string RefundType
        {
            get { return StrRefundType; }
            set { StrRefundType = value; }
        }
        public string DeliveryTime
        {
            get { return StrDelivery_Time; }
            set { StrDelivery_Time = value; }
        }
        public string Priority
        {
            get { return StrPriority; }
            set { StrPriority = value; }
        }

        public string TestAmount
        {
            get { return StrTestAmount; }
            set { StrTestAmount = value; }
        }
        public string Test_PaidAmt
        {
            get { return StrTest_PaidAmt; }
            set { StrTest_PaidAmt = value; }
        }
        public string ClassificationID
        {
            get { return StrClassificationID; }
            set { StrClassificationID = value; }
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

        public string Error
        {
            get { return StrError; }
            set { StrError = value; }
        }
        public string BranchID
        {
            get { return StrBranchID; }
            set { StrBranchID = value; }
        }
        public string SpeedKey
        {
            get { return StrSpeedKey; }
            set { StrSpeedKey = value; }
        }
        public string OrgID
        {
            get { return StrOrgID; }
            set { StrOrgID = value; }
        }

        public string F_Parent
        {
            get { return Str_F_Parent; }
            set { Str_F_Parent = value; }
        }
        public string S_Parent
        {
            get { return Str_S_Parent; }
            set { Str_S_Parent = value; }
        }
        public string Relation
        {
            get { return StrRelation; }
            set { StrRelation = value; }
        }

        public string Parent_Panel
        {
            get { return StrParent; }
            set { StrParent = value; }
        }
        public string ProcessID
        {
            get { return StrProcessID; }
            set { StrProcessID = value; }
        }
        public string Discount
        {
            get { return StrDiscount; }
            set { StrDiscount = value; }
        }
        public string Discount_Amt_Test
        {
            get { return StrDiscount_Amt_Test; }
            set { StrDiscount_Amt_Test = value; }
        }

        public string P_Salutation
        {
            get { return StrP_Salutation; }
            set { StrP_Salutation = value; }
        }
        public string P_Name
        {
            get { return StrP_Name; }
            set { StrP_Name = value; }
        }
        public string P_Gender
        {
            get { return StrP_Gender; }
            set { StrP_Gender = value; }
        }

        public string P_DOB
        {
            get { return StrP_DOB; }
            set { StrP_DOB = value; }
        }
        public string P_Marital
        {
            get { return StrP_Marital; }
            set { StrP_Marital = value; }
        }
        public string Rate
        {
            get { return StrRate; }
            set { StrRate = value; }
        }

        public string ReferenceNo
        {
            get { return StrReferenceNo; }
            set { StrReferenceNo = value; }
        }
        public string Password
        {
            get { return StrPassword; }
            set { StrPassword = value; }
        }
        public string Card_ReferenceNo
        {
            get { return StrCard_ReferenceNo; }
            set { StrCard_ReferenceNo = value; }
        }

        public string For_Process
        {
            get { return StrFor_Process; }
            set { StrFor_Process = value; }
        }
        public string Int_Comment
        {
            get { return StrInt_Comment; }
            set { StrInt_Comment = value; }
        } 
        public string Remarks
        {
            get { return StrRemarks; }
            set { StrRemarks = value; }
        }
        public string WardID
        {
            get { return StrWardID; }
            set { StrWardID = value; }
        }
        public string Bed
        {
            get { return StrBed; }
            set { StrBed = value; }
        }
        public string Adm_Ref
        {
            get { return StrAdm_Ref; }
            set { StrAdm_Ref = value; }
        }
        #endregion

        #region "Method"

        public DataView GetAll(int flag)
        {
            switch (flag)
            {
                case 1: // fill gv 
                    break;
                case 2: // fill Department
                    objdbhims.Query = "select departmentid,name from dc_tp_departments where type='S' and active='Y'";
                    break;
                case 3: // fill subdepartment
                    objdbhims.Query = "select subdepartmentid,name,departmentid from dc_tp_subdepartments where active='Y'";
                    if (!StrDepartmentID.Equals(Default) && !StrDepartmentID.Equals("-1"))
                        objdbhims.Query += " and departmentid =" + StrDepartmentID;
                    break;
                case 4: // fill group
                    objdbhims.Query = "select groupid,name as groupname from dc_tp_groupm where active='Y' order by name";
                    break;
                case 5: // fill test
                    objdbhims.Query = "select c.classificationid, t.testid,concat(ifnull(su.acronym,''),':',t.test_name,' ',ifnull(c.name,'')) as testname,case when 'N'='" + StrPriority + "' and 'P'='" + StrRate + "' then ifnull(t.charges,0)+ifnull(org.process_fee,0) when 'N'='" + StrPriority + "' and 'C'='" + StrRate + "' then ifnull(t.charityrate,0)+ifnull(org.process_fee,0) else ifnull(chargesurgent,0)+ifnull(org.process_fee,0) end as charges,'" + StrPriority + "' as priority,concat(ifnull(t.speedkey,''),':') as speedkey,ifnull(mt.maxtime,0) as maxtime,'Y' as print_amount from dc_tp_test t left outer join dc_tp_tclass c on t.testid=c.testid left outer join dc_tp_test_age ag on t.testid = ag.testid left outer join dc_tp_subdepartments su on t.subdepartmentid=su.subdepartmentid left outer join dc_tp_organization org on t.external_org= org.orgid left outer join dc_tp_method mt on t.d_methodid=mt.methodid where t.active='Y' and ag.maxage >" + StrDOB + " and ag.minage<=" + StrDOB + " and (ag.gender='" + StrGender + "' or ag.gender='A') ";
                    if (!StrSubDepartmentID.Equals(Default) && !StrSubDepartmentID.Equals("-1"))
                        objdbhims.Query += " and t.subdepartmentid=" + StrSubDepartmentID;
                    if (!StrName.Equals("") && !StrName.Equals(Default))
                        objdbhims.Query += " and t.test_name like '%" + StrName + "%'";
                    if (!StrSpeedKey.Equals(Default) && !StrSpeedKey.Equals(""))
                        objdbhims.Query += " and t.speedkey like '" + StrSpeedKey + "%'";
                    if (StrRate.Equals("C"))
                        objdbhims.Query += " and ifnull(t.charityrate,0) <>0";
                    objdbhims.Query += " order by su.name,t.dorder";
                    break;
                // and ag.maxage >" + StrDOB + " and ag.minage<=" + StrDOB + " and (ag.gender='" + StrGender + "' or ag.gender='A')
                case 6: // fill panel
                    objdbhims.Query = "select panelid,concat(name,' (',case when clientid = '006' then 'BCL' when clientid = '008' then 'AMC' else '-' end ,')') as name from dc_tpanel where active='Y' and clientid in (select allow_panel_org from dc_tp_org_allowpanel where orgid='" + StrClientID + "' ) order by clientid";
                    //if (StrClientID.Equals("006"))
                    //    objdbhims.Query += " and clientid='" + StrClientID + "'";
                    break;
                case 7: // fill class
                    objdbhims.Query = "select classid,name from dc_tpanel_class where active='Y' and panelid=" + StrPanelID + "";
                    break;
                case 8: //fill test panel and class wise
                    objdbhims.Query = "select t.testid,t.name from dc_tpanel_test pt left outer join dc_tp_test t on pt.testid = t.testid where panelid=" + StrPanelID + " and classid=" + StrClassID + "";

                    break;
                case 9: // search person
                    objdbhims.Query = "select (select concat(ifnull(title,''),' ',name) from dc_tpatient where prid=p.f_parent) as panelpatient, p.prid,p.prno,p.name,p.title,case when p.gender = 'M' then 'Male' else 'Female' end as gender,concat(date_format(p.dob,'%d/%m/%Y'),' (',  case when DATEDIFF(CURRENT_DATE,p.dob) > 365 then      concat(Floor(DATEDIFF(CURRENT_DATE,p.dob)/365),' -Y')  else case when DATEDIFF(CURRENT_DATE,p.dob) > 30 then      concat(Floor(DATEDIFF(CURRENT_DATE,p.dob)/30),' -M')     else concat(DATEDIFF(CURRENT_DATE,p.dob),'-D') end end,')' )  as dob_age,date_format(p.dob,'%d/%m/%Y') as dob,p.hphone,p.cellno,p.fax,p.email,p.cnic, pn.panelid ,p.serviceno,p.classid,p.address,case when p.maritalstatus ='S' then 'Single' else 'Married' end as maritalstatus,concat(ifnull(p.title,''),' ',p.name) as patientname,p.relation,p.f_parent,ifnull(pn.name,'-') as panelname from ((dc_Tpatient p left outer join dc_Tpatient_bookingm m on m.prid=p.prid and m.bookingid=(select max(mm.bookingid) from dc_tpatient_bookingm mm where mm.prid=p.prid) )left outer join dc_tpanel pn on pn.panelid = m.panelid)  where 1=1";
                    if (!StrPRNO.Equals(Default))
                        objdbhims.Query += " and p.prno='" + StrPRNO + "'";
                    if (!StrTitle.Equals(Default))
                        objdbhims.Query += " and p.title='" + StrTitle + "'";

                    if (!StrName.Equals(Default))
                        objdbhims.Query += " and p.name like '%" + StrName + "%'";
                    if (!StrDOB.Equals(Default))
                        objdbhims.Query += " and date_format(p.dob,'%d/%m/%Y')='" + StrDOB + "'";

                    if (!StrGender.Equals(Default))
                        objdbhims.Query += " and p.gender = '" + StrGender + "'";
                    if (!StrMaritalStatus.Equals(Default))
                        objdbhims.Query += " and p.maritalstatus='" + StrMaritalStatus + "'";

                    if (!StrCellNo.Equals(Default))
                        objdbhims.Query += " and p.cellno='" + StrCellNo + "'";
                    if (!StrHphone.Equals(Default))
                        objdbhims.Query += " and p.hphone='" + StrHphone + "'";

                    if (!StrFax.Equals(Default))
                        objdbhims.Query += " and p.fax like '%" + StrFax + "%'";
                    if (!StrEmail.Equals(Default))
                        objdbhims.Query += " and p.email like '%" + StrEmail + "%'";
                    //if (StrPanelID.Equals("-1") && !StrPanelID.Equals(Default))
                    //    objdbhims.Query += " and p.panelid is not null";
                    if (!StrPanelID.Equals("-1") && !StrPanelID.Equals(Default) && !StrPanelID.Equals(""))
                        objdbhims.Query += " and p.panelid =" + StrPanelID + "";
                    //if (StrPanelID.Equals(Default))
                    //    objdbhims.Query += " and p.panelid is null";
                    if (!StrServiceNo.Equals("") && !StrServiceNo.Equals(Default))
                        objdbhims.Query += " and p.serviceno='" + StrServiceNo + "'";
                    
                    break;
                case 10: // fill doctor
                    objdbhims.Query = "SELECT personid,concat(fname,' ',ifnull(mname,''),' ',ifnull(lname,'')) as name FROM dc_tp_personnel where active='Y' and designationid=3";
                    break;
                case 11: // fill test gv on group : cash patient
                    objdbhims.Query = "select distinct c.classificationid, d.testid,concat(ifnull(su.acronym,''),':',t.test_name,' ',ifnull(c.name,'')) as testname,case when 'N'='" + StrPriority + "' and 'P'='" + StrRate + "' then ifnull(d.charges,0)+ifnull(org.process_fee,0) when 'N'='" + StrPriority + "' and 'C'='" + StrRate + "' then ifnull(t.charityrate,0)+ifnull(org.process_fee,0) else ifnull(chargesurgent,0)+ifnull(org.process_fee,0) end as charges,d.groupid,'" + StrPriority + "' as priority,concat(ifnull(t.speedkey,''),':') as speedkey,ifnull(mt.maxtime,0) as maxtime from dc_tp_groupd d left outer join dc_tp_test t on d.testid=t.testid left outer join dc_tp_tclass c on t.testid=c.testid left outer join dc_tp_test_age ag on t.testid = ag.testid left outer join dc_tp_subdepartments su on t.subdepartmentid=su.subdepartmentid left outer join dc_tp_organization org on t.external_org= org.orgid left outer join dc_tp_method mt on t.d_methodid=mt.methodid where d.groupid=" + StrGroupID + " and t.active='Y' and d.active='Y' and ag.maxage >" + StrDOB + " and ag.minage<=" + StrDOB + " and (ag.gender='" + StrGender + "' or ag.gender='A')";
                    if (StrRate.Equals("C"))
                        objdbhims.Query += " and ifnull(t.charityrate,0) <>0";
                    break;
                //and ag.maxage>" + StrDOB + " and minage<=" + StrDOB + " and (ag.gender='" + StrGender + "' or ag.gender='A')
                case 12: // get test price : cash patient
                    objdbhims.Query = "SELECT ifnull(charges,0) as charges FROM dc_tp_test d where d.testid=" + StrTestID + "";
                    break;
                case 13: // get test price : panel patient
                    objdbhims.Query = "SELECT case when 'N'='" + StrPriority + "' then ifnull(rate,0) else ifnull(urgentrate,0) end as charges,testid FROM dc_tpanel_test  where  panelid=" + StrPanelID + "";
                    if (!StrClassID.Equals(Default))
                        objdbhims.Query += " and classid=" + StrClassID + " ";
                    break;
                case 14: // get test gv on group: Panel Patient
                    objdbhims.Query = "SELECT case when 'N'='" + StrPriority + "' then ifnull(p.rate,0) else ifnull(p.urgentrate,0) end as charges,p.testid,t.test_name,t.groupid FROM dc_tpanel_test p left outer join dc_tp_test t on p.testid=t.testid where t.groupid=" + StrGroupID + " and p.panelid=" + StrPanelID + " and p.classid=" + StrClassID + "";
                    break;
                case 15: // fill doctor on patient reg
                    objdbhims.Query = "SELECT doctorid,concat(name,' ',title) as name FROM dc_tp_refdoctors where active='Y'";
                    if (!StrOrgID.Equals(Default) && !StrOrgID.Equals(""))
                        objdbhims.Query += " and panelid is null and orgid is not null";
                    if (!StrPanelID.Equals(Default) && !StrPanelID.Equals(""))
                        objdbhims.Query += " and orgid is null and panelid is not null";
                    break;
                case 16: // validation panel person
                    objdbhims.Query = "select prid,relation from dc_tpatient where serviceno='" + StrServiceNo + "'  and panelid=" + StrPanelID + " and relation='Self'";
                    break;
                case 17:
                    objdbhims.Query = "select prid from dc_tpatient where serviceno='" + StrServiceNo + "' and relation='Self'";
                    break;
                case 18: // fill dependent
                    objdbhims.Query = "select p.prid,p.f_parent, p.prno, concat(ifnull(p.title,''),' ',p.name) as dependent,p.title,p.name,case when p.relation='S/O' then 'Son' when p.relation='F/O' then 'Father'  when p.relation='M/O' then 'Mother' when p.relation='H/O' then 'Husband' when p.relation='D/O' then 'Daughter' when p.relation='W/O' then 'Wife' when p.relation='Self' then 'Self' else null end as relation,p.title,case when p.gender = 'M' then 'Male' else 'Female' end as gender,date_format(p.dob,'%d/%m/%Y') as dob,p.hphone,p.cellno,p.fax,p.email,p.cnic,p.panelid,p.serviceno,p.classid,p.address,case when p.maritalstatus ='S' then 'Single' else 'Married' end as maritalstatus,(select concat(name,'.',title) from dc_tpatient where prid=p.f_parent) as panelpatient,p.name,p.relation as panelrelation from dc_tpatient p where 1=1";
                    if (!Str_F_Parent.Equals(Default) && !Str_F_Parent.Equals(""))
                        objdbhims.Query += " and p.f_parent=" + Str_F_Parent + "";
                    if (!StrServiceNo.Equals(Default) && !StrServiceNo.Equals(""))
                        objdbhims.Query += " and p.serviceno='" + StrServiceNo + "'";
                    if (!StrPanelID.Equals(Default) && !StrPanelID.Equals("-1"))
                        objdbhims.Query += " and p.panelid=" + StrPanelID + "";
                    break;
                case 19: // branchID
                    objdbhims.Query = "SELECT orgid,name FROM dc_tp_organization d where active='Y' and external='N' ";
                    break;
                case 20: // show panel info => dependent add
                    objdbhims.Query = "select concat(p.title,'.',p.name) as parent,p.prid,p.prno,p.serviceno,p.maritalstatus,pn.name as panelname from dc_tpatient p left outer join dc_tpanel pn on p.panelid = pn.panelid where p.prid=" + StrPRID + " and p.serviceno='" + StrServiceNo + "' and p.relation='Self'";
                    break;
                case 21: // validation: father repeated
                    objdbhims.Query = "select prid from dc_tpatient where relation='F/O' and f_parent=" + Str_F_Parent + " and serviceno='" + StrServiceNo + "'";
                    break;
                case 22: // fill panel test list : fill test grid
                    objdbhims.Query = "select c.classificationid, t.testid,concat(ifnull(su.acronym,''),':',t.test_name,' ',ifnull(c.name,'')) as testname,ifnull(pt.rate,0)+ifnull(org.process_fee,0)  as charges, '" + StrPriority + "' as priority, concat(ifnull(t.speedkey,''),':') as speedkey,ifnull(mt.maxtime,0) as maxtime,ifnull(pn.print_amount,'N') as print_amount from dc_tpanel_test pt left outer join dc_tp_test t on pt.testid=t.testid left outer join dc_tp_tclass c on t.testid=c.testid left outer join dc_tp_test_age ag on t.testid = ag.testid left outer join dc_tp_subdepartments su on t.subdepartmentid=su.subdepartmentid left outer join dc_tp_organization org on t.external_org= org.orgid left outer join dc_tp_method mt on t.d_methodid=mt.methodid left outer join dc_tpanel pn on pn.panelid=pt.panelid where t.active='Y' and ag.maxage >" + StrDOB + " and ag.minage<=" + StrDOB + " and (ag.gender='" + StrGender + "' or ag.gender='A')";
                    if (!StrSubDepartmentID.Equals(Default) && !StrSubDepartmentID.Equals("-1"))
                        objdbhims.Query += " and t.subdepartmentid=" + StrSubDepartmentID;
                    if (!StrName.Equals("") && !StrName.Equals(Default))
                        objdbhims.Query += " and t.test_name like '%" + StrName + "%'";
                    if (!StrSpeedKey.Equals(Default) && !StrSpeedKey.Equals(""))
                        objdbhims.Query += " and t.speedkey like '" + StrSpeedKey + "%'";
                    if (!StrPanelID.Equals(Default) && !StrPanelID.Equals("-1") && !StrPanelID.Equals(""))
                        objdbhims.Query += " and pt.panelid=" + StrPanelID + "";
                    objdbhims.Query += " order by su.name,t.dorder";
                    break;
                case 23: // fill panel test list: Group 
                    objdbhims.Query = "select distinct c.classificationid, d.testid,concat(ifnull(su.acronym,''),':',t.test_name,' ',ifnull(c.name,'')) as testname,ifnull(pt.rate,0)+ifnull(org.process_fee,0) as charges,d.groupid,'" + StrPriority + "' as priority,concat(ifnull(t.speedkey,''),':') as speedkey,ifnull(mt.maxtime,0) as maxtime from dc_tp_groupd d left outer join dc_tpanel_test pt on d.testid=pt.testid left outer join dc_tp_test t on d.testid=t.testid left outer join dc_tp_tclass c on t.testid=c.testid left outer join dc_tp_test_age ag on t.testid = ag.testid left outer join dc_tp_subdepartments su on t.subdepartmentid=su.subdepartmentid left outer join dc_tp_organization org on t.external_org= org.orgid left outer join dc_tp_method mt on t.d_methodid=mt.methodid where d.groupid=" + StrGroupID + " and t.active='Y' and pt.panelid=" + StrPanelID + "";
                    break;
                case 24: // fill tool tip test using groups
                    objdbhims.Query = "SELECT testid,test_name FROM dc_tp_groupd where active='Y' and groupid=" + StrGroupID + "";
                    if (!StrPanelID.Equals(Default) && !StrPanelID.Equals(""))
                        objdbhims.Query += " and testid in (select testid from dc_tpanel_test where panelid="+StrPanelID+" and groupid="+StrGroupID+")";
                    break;
                case 25: // get processid 
                    objdbhims.Query = "SELECT d.processid,d.name,t.test_name,ifnull((select processid from dc_tpatient_bookingd where testid=" + StrTestID + " and bookingid=" + StrBookingID + "),'N') as current_status FROM dc_tp_tprocess d left outer join dc_tp_tprocedured pd on pd.processid=d.processid left outer join dc_tp_test t on t.procedureid=pd.procedureid  where d.active='Y' and t.testid=" + StrTestID + " order by t.testid,d.processid";
                    break;
                case 26: // check validate duplicate name panel case
                    objdbhims.Query = "select prid from dc_tpatient where panelid=" + StrPanelID + " and serviceno='" + StrServiceNo + "' and name ='" + StrName + "' and title='" + StrTitle + "'";
                    break;
                case 27: // fill group on investigation panel
                    objdbhims.Query = "select name as groupname,groupid from dc_tp_groupm where active='Y' and groupid in (select groupid from dc_tpanel_test where panelid="+StrPanelID+") order by name";
                    break;
                case 28: // fill test group panel
                    objdbhims.Query = "select distinct c.classificationid, d.testid,concat(ifnull(su.acronym,''),':',t.test_name,' ',ifnull(c.name,'')) as testname,case when 'N'='" + StrPriority + "' and 'P'='" + StrRate + "' then ifnull(d.rate,0)+ifnull(org.process_fee,0) when 'N'='" + StrPriority + "' and 'C'='" + StrRate + "' then ifnull(t.charityrate,0)+ifnull(org.process_fee,0) else ifnull(chargesurgent,0)+ifnull(org.process_fee,0) end as charges,d.groupid,'"+StrPriority+"' as priority, concat(ifnull(t.speedkey,''),':') as speedkey,ifnull(mt.maxtime,0) as maxtime from dc_tpanel_test d left outer join dc_tp_test t on d.testid=t.testid left outer join dc_tp_tclass c on t.testid=c.testid left outer join dc_tp_test_age ag on t.testid = ag.testid left outer join dc_tp_subdepartments su on t.subdepartmentid=su.subdepartmentid left outer join dc_tp_organization org on t.external_org= org.orgid left outer join dc_tp_method mt on t.d_methodid=mt.methodid where d.groupid="+StrGroupID+" and t.active='Y' and ag.maxage >" + StrDOB + " and ag.minage<=" + StrDOB + " and (ag.gender='" + StrGender + "' or ag.gender='A') and panelid="+StrPanelID+"";
                    break;
                case 29: // internal comment fill process
                    objdbhims.Query = " SELECT p.name,p.processid FROM dc_tp_tprocess p join dc_tp_tprocedured d join dc_tp_test t where p.active='Y' and p.processid=d.processid and t.procedureid=d.procedureid and t.testid="+StrTestID+" ";
                    break;
                case 30: // internal comment shw
                    objdbhims.Query = "SELECT d.comentid,d.bookingid,d.testid,d.description,d.active,date_format(d.enteredon,'%d/%m/%Y') as enteredon,d.for_process,concat(p.salutation,p.fname,' ',ifnull(p.mname,''),' ' ,ifnull(p.lname,'')) as enteredby FROM dc_tint_coment d join dc_Tp_personnel p where p.personid=d.enteredby and d.testid="+StrTestID+" and d.bookingid="+StrBookingID+" and (d.for_process is null or d.for_process="+StrFor_Process+") order by d.enteredon desc";
                    break;
                case 31: // ward ddl\
                    objdbhims.Query = "select wardid,name from dc_tp_ward where active='Y'";
                    break;
                case 32:
                    objdbhims.Query = "SELECT d.maxtime FROM dc_tp_method d join dc_Tp_tmethod tm on tm.methodid=d.methodid  join dc_tp_test t  on tm.testid = t.testid where t.testid=" + StrTestID + " and tm.m_default='Y'";
                    //System.Configuration.ConfigurationSettings.AppSettings["clientid"].ToString()
                    if (Session["default_route"].ToString().Equals("006"))
                        objdbhims.Query += " and (case when ifnull(t.external_org,'006') ='006' then tm.clientid='006' when  t.external_org = '008'  then tm.clientid ='008' else tm.clientid='006'  end)";
                    if (Session["default_route"].ToString().Equals("008"))
                        objdbhims.Query += " and (case when ifnull(t.external_org,'008') ='008' then tm.clientid='008' when  t.external_org = '006'  then tm.clientid ='006' else tm.clientid='006' end)";
                    break;
            }
            return objTrans.DataTrigger_Get_All(objdbhims);
        }

        public bool Patient_Insert()
        {
            if (Validate_Patient())
            {
                QueryBuilder objQB = new QueryBuilder();

                objTrans.Start_Transaction();

                objdbhims.Query = objQB.QBGetMax("prid", Table_Patient);
                this.StrPRID = objTrans.DataTrigger_Get_Max(objdbhims);

                if (!StrPRID.Equals("True"))
                {

                    objdbhims.Query = "SELECT lpad(ifnull(max(substr(e.prno,8,8)),0)+1,8,0) as maxid FROM dc_tpatient e where substr(e.prno,5,2)= date_format(current_date,'%y') and substr(e.prno,1,3)='" + StrBranchID + "'";
                    StrPRNO = objTrans.DataTrigger_Get_Max(objdbhims);

                    if (!StrPRNO.Equals("True"))
                    {
                        if (!StrPanelID.Equals("-1") && !StrPanelID.Equals(Default) && StrRelation.Equals("Self"))
                            Str_F_Parent = StrPRID;

                        StrPRNO = StrBranchID + "-" + System.DateTime.Now.ToString("yy") + "-" + StrPRNO;

                        objdbhims.Query = objQB.QBInsert(MakeArray_Patient(), Table_Patient);
                        StrError = objTrans.DataTrigger_Insert(objdbhims);
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
            else
            {
                return false;
            }
        }
        public bool Patient_Update()
        {
            if (Validate_Patient())
            {
                QueryBuilder objQB = new QueryBuilder();

                objTrans.Start_Transaction();

                objdbhims.Query = objQB.QBUpdate(MakeArray_Patient(), Table_Patient);
                StrError = objTrans.DataTrigger_Update(objdbhims);
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
                return false;
            }

        }

        public bool Booking_Insert(string[,] str)
        {
            QueryBuilder objQB = new QueryBuilder();

            objTrans.Start_Transaction();

            objdbhims.Query = "SELECT lpad(ifnull(max(substr(e.labid,8,8)),0)+1,8,0) as maxid FROM dc_tpatient_bookingm e where substr(e.labid,1,2)= date_format(current_date,'%y') and substr(e.labid,4,3)='" + StrBranchID + "'";
            StrLabID = objTrans.DataTrigger_Get_Max(objdbhims);

            if (!StrLabID.Equals("True"))
            {
                StrLabID = System.DateTime.Now.ToString("yy") + "-" + StrBranchID + "-" + StrLabID;
                objdbhims.Query = objQB.QBInsert(MakeArray_Booking_M(), Table_BookingM);
                StrError = objTrans.DataTrigger_Insert(objdbhims);

                if (!StrError.Equals("True"))
                {
                    DataView dvBkID;
                    objdbhims.Query = "select bookingid from dc_tpatient_bookingm where labid='" + StrLabID + "'";
                    dvBkID = this.objTrans.Transaction_Get_Single(objdbhims);
                    StrBookingID = dvBkID[0]["bookingid"].ToString();

                    for (int i = 0; i <= str.GetUpperBound(0); i++)
                    {
                        StrTestID = str[i, 0];

                        StrClassificationID = str[i, 1];
                        if (StrClassificationID == null || StrClassificationID == "")
                            StrClassificationID = "null";

                        StrTestAmount = str[i, 2];
                        StrPriority = str[i, 3];
                        StrProcessID = str[i, 4];
                        StrInt_Comment = str[i, 5];
                        StrFor_Process = str[i, 6];


                        DataView dv;
                        DateTime dtNow = Convert.ToDateTime(System.DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt"));
                        objdbhims.Query = "SELECT type,lower(value) as sched,testid FROM dc_tp_test_schedule where testid=" + StrTestID + "";
                        dv = objTrans.Transaction_Get_Single(objdbhims);
                        if (dv.Count > 0 && !dv[0]["type"].ToString().Equals("Daily"))
                        {
                            dtNow = Date_test(dv[0]["type"].ToString(), dtNow, dv);
                        }

                        objdbhims.Query = "SELECT d.maxtime FROM dc_tp_method d join dc_Tp_tmethod tm on tm.methodid=d.methodid  join dc_tp_test t  on tm.testid = t.testid where t.testid=" + StrTestID + " and tm.m_default='Y'";
                        //System.Configuration.ConfigurationSettings.AppSettings["clientid"].ToString()
                        if ( Session["default_route"].ToString().Equals("006")) 
                            objdbhims.Query += " and (case when ifnull(t.external_org,'006') ='006' then tm.clientid='006' when  t.external_org = '008'  then tm.clientid ='008' else tm.clientid='006'  end)";
                        if ( Session["default_route"].ToString().Equals("008"))
                            objdbhims.Query += " and (case when ifnull(t.external_org,'008') ='008' then tm.clientid='008' when  t.external_org = '006'  then tm.clientid ='006' else tm.clientid='006' end)";
                        //objdbhims.Query = "SELECT d.maxtime FROM dc_tp_method d left outer join dc_tp_test t  on d.methodid = t.d_methodid where t.testid=" + StrTestID + "";
                        //DataView dv;
                        //objdbhims.Query = "SELECT d.maxtime FROM dc_tp_method d left outer join dc_tp_test t  on d.methodid = t.d_methodid where t.testid=" + StrTestID + "";
                        dv = this.objTrans.Transaction_Get_Single(objdbhims);
                        if (dv.Count > 0 && Convert.ToInt32(dv[0]["maxtime"]) > 0)
                        {
                            double dtMtd = Convert.ToDouble(dv[0]["maxtime"].ToString());
                            //DateTime dtNow = Convert.ToDateTime(System.DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt"));
                            DateTime ts = dtNow.AddMinutes(dtMtd);
                            StrDelivery_Time = ts.ToString("dd/MM/yyyy hh:mm:ss tt");
                            if (ts.DayOfWeek.ToString() == "Sunday" && Convert.ToDateTime(ts.ToShortTimeString()) > DateTime.Parse("3:00 PM"))
                            {
                                StrDelivery_Time = Convert.ToString(ts.AddDays(1.0));

                                StrDelivery_Time = Convert.ToDateTime(StrDelivery_Time).ToString("dd/MM/yyyy") + " 09:00:00 AM";
                            }
                            else if (Convert.ToDateTime(ts.ToShortTimeString()) > DateTime.Parse("10:00 PM") && Convert.ToDateTime(ts.ToShortTimeString()) < DateTime.Parse("11:59 PM"))
                            {
                                StrDelivery_Time = Convert.ToString(ts.AddDays(1.0));
                                StrDelivery_Time = Convert.ToDateTime(StrDelivery_Time).ToString("dd/MM/yyyy") + " 09:00:00 AM";

                            }

                            else if (Convert.ToDateTime(ts.ToShortTimeString()) < DateTime.Parse("9:00 AM"))
                            {
                                StrDelivery_Time = Convert.ToDateTime(StrDelivery_Time).ToString("dd/MM/yyyy") + " 09:00:00 AM";
                            }
                        }
                        else
                        {
                            StrDelivery_Time = "~!@";
                            //System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                        }
                        StrBookingDetailID = "~!@";
                        objdbhims.Query = objQB.QBInsert(MakeArray_Booking_D(), Table_BookingD);
                        StrError = objTrans.DataTrigger_Insert(objdbhims);

                        if (StrError.Equals("True"))
                        {
                            StrError = objTrans.OperationError;
                            objTrans.End_Transaction();
                            return false;
                        }
                        else
                        {
                            objdbhims.Query = "update dc_tp_test set ordering=ifnull(ordering,0)+1 where testid=" + StrTestID + "";
                            StrError = objTrans.DataTrigger_Update(objdbhims);
                            if (StrError.Equals("True"))
                            {
                                StrError = objTrans.OperationError;
                                objTrans.End_Transaction();
                                return false;
                            }
                            else
                            {
                                objdbhims.Query = objQB.QBGetLastID("bookingdid", "dc_tpatient_bookingd");
                                StrBookingDetailID = objTrans.DataTrigger_Get_Max(objdbhims);

                                objdbhims.Query = "insert into dc_tstatustrack (labid,processid,testid,enteredby,enteredon,clientid,bookingdid) values ('" + StrLabID + "',1," + StrTestID + "," + StrEnteredBy + ",str_to_date('" + StrEnteredOn + "','%d/%m/%Y %h:%i:%s %p'),'" + StrClientID + "'," + StrBookingDetailID + ") ";
                                StrError = objTrans.DataTrigger_Insert(objdbhims);
                                if (StrError.Equals("True"))
                                {
                                    StrError = objTrans.OperationError;
                                    objTrans.End_Transaction();
                                    return false;
                                }
                                else
                                {
                                    if (!StrInt_Comment.Trim().Equals("") && !StrInt_Comment.Trim().Equals(Default))
                                    {
                                        objdbhims.Query = "insert into dc_tint_coment (bookingid,testid,description,active,process,for_process,enteredon,enteredby,clientid) values (" + StrBookingID + "," + StrTestID + ",'" + StrInt_Comment + "','Y',1," + StrFor_Process + ",str_to_date('" + StrEnteredOn + "','%d/%m/%Y %h:%i:%s %p'),"+StrEnteredBy+",'" + StrClientID + "')";
                                        StrError = objTrans.DataTrigger_Insert(objdbhims);
                                    }
                                    if (StrError.Equals("True"))
                                    {
                                        StrError = objTrans.OperationError;
                                        objTrans.End_Transaction();
                                        return false;
                                    }
                                }
                            }
                        }

                    }

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
        public bool Booking_Cash_Insert(string[,] str)
        {
            QueryBuilder objQB = new QueryBuilder();

            objTrans.Start_Transaction();

            objdbhims.Query = "SELECT lpad(ifnull(max(substr(e.labid,8,8)),0)+1,8,0) as maxid FROM dc_tpatient_bookingm e where substr(e.labid,1,2)= date_format(current_date,'%y') and substr(e.labid,4,3)='" + StrBranchID + "'";
            StrLabID = objTrans.DataTrigger_Get_Max(objdbhims);

            if (!StrLabID.Equals("True"))
            {
                StrLabID = System.DateTime.Now.ToString("yy") + "-" + StrBranchID + "-" + StrLabID;
                objdbhims.Query = objQB.QBInsert(MakeArray_Booking_M(), Table_BookingM);
                StrError = objTrans.DataTrigger_Insert(objdbhims);

                if (!StrError.Equals("True"))
                {
                    DataView dvBkID;
                    objdbhims.Query = "select bookingid from dc_tpatient_bookingm where labid='" + StrLabID + "'";
                    dvBkID = this.objTrans.Transaction_Get_Single(objdbhims);
                    StrBookingID = dvBkID[0]["bookingid"].ToString();

                    for (int i = 0; i <= str.GetUpperBound(0); i++)
                    {
                        StrTestID = str[i, 0];

                        StrClassificationID = str[i, 1];
                        if (StrClassificationID == null || StrClassificationID.Equals(""))
                            StrClassificationID = "~!@";

                        StrTestAmount = str[i, 2];
                        StrDiscount_Amt_Test = str[i, 3];
                        StrPriority = str[i, 4];
                        StrProcessID = str[i, 5];
                        StrInt_Comment = str[i, 6];
                        StrFor_Process = str[i, 7];
                        
                        if (StrProcessID == null || StrProcessID.Equals(""))
                            StrProcessID = "~!@";

                        DataView dv;
                        DateTime dtNow = Convert.ToDateTime(System.DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt"));
                        objdbhims.Query = "SELECT type,lower(value) as sched,testid FROM dc_tp_test_schedule where testid=" + StrTestID + "";
                        dv = objTrans.Transaction_Get_Single(objdbhims);
                        if (dv.Count > 0 && !dv[0]["type"].ToString().Equals("Daily"))
                        {
                            dtNow = Date_test(dv[0]["type"].ToString(), dtNow, dv);                         
                        }

                        objdbhims.Query = "SELECT d.maxtime FROM dc_tp_method d join dc_Tp_tmethod tm on tm.methodid=d.methodid  join dc_tp_test t  on tm.testid = t.testid where t.testid=" + StrTestID + " and tm.m_default='Y'";
                        if ( Session["default_route"].ToString().Equals("006"))
                            objdbhims.Query += " and (case when ifnull(t.external_org,'006') ='006' then tm.clientid='006' when  t.external_org = '008'  then tm.clientid ='008' else tm.clientid='006'  end)";
                        if (Session["default_route"].ToString().Equals("008"))
                            objdbhims.Query += " and (case when ifnull(t.external_org,'008') ='008' then tm.clientid='008' when  t.external_org = '006'  then tm.clientid ='006' else tm.clientid='006' end)";
                        //objdbhims.Query = "SELECT d.maxtime FROM dc_tp_method d left outer join dc_tp_test t  on d.methodid = t.d_methodid where t.testid=" + StrTestID + "";
                        dv = this.objTrans.Transaction_Get_Single(objdbhims);
                        if (dv.Count > 0 && Convert.ToInt32(dv[0]["maxtime"]) > 0)
                        {
                            double dtMtd = Convert.ToDouble(dv[0]["maxtime"].ToString());
                            
                            DateTime ts = dtNow.AddMinutes(dtMtd);
                            DateTime fin_date = new DateTime();
                            StrDelivery_Time = ts.ToString("dd/MM/yyyy hh:mm:ss tt");
                            if (System.Configuration.ConfigurationSettings.AppSettings["clientid"].ToString().Equals("006"))
                            {
                                if (ts.DayOfWeek.ToString() == "Sunday" && Convert.ToDateTime(ts.ToShortTimeString()) > DateTime.Parse("3:00 PM"))
                                {
                                    fin_date = ts.AddDays(1.0);
                                    StrDelivery_Time = fin_date.ToString("dd/MM/yyyy") + " 09:00:00 AM";
                                }
                                else if (Convert.ToDateTime(ts.ToShortTimeString()) > DateTime.Parse("10:00 PM") && Convert.ToDateTime(ts.ToShortTimeString()) < DateTime.Parse("11:59 PM"))
                                {
                                    fin_date = ts.AddDays(1.0);
                                    StrDelivery_Time = fin_date.ToString("dd/MM/yyyy") + " 09:00:00 AM";

                                }

                                else if (Convert.ToDateTime(ts.ToShortTimeString()) < DateTime.Parse("9:00 AM"))
                                {
                                    fin_date = ts;
                                    StrDelivery_Time = fin_date.ToString("dd/MM/yyyy") + " 09:00:00 AM";
                                }
                            }
                          
                        }
                        else
                        {
                            StrDelivery_Time = "~!@";
                            //System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                        }
                        StrBookingDetailID = "~!@";
                        objdbhims.Query = objQB.QBInsert(MakeArray_Booking_D(), Table_BookingD);
                        StrError = objTrans.DataTrigger_Insert(objdbhims);

                        if (StrError.Equals("True"))
                        {
                            StrError = objTrans.OperationError;
                            objTrans.End_Transaction();
                            return false;
                        }
                        else
                        {//
                            objdbhims.Query = "update dc_tp_test set ordering=ifnull(ordering,0)+1 where testid=" + StrTestID + "";
                            StrError = objTrans.DataTrigger_Update(objdbhims);
                            if (StrError.Equals("True"))
                            {
                                StrError = objTrans.OperationError;
                                objTrans.End_Transaction();
                                return false;
                            }
                            else
                            {
                                objdbhims.Query = objQB.QBGetLastID("bookingdid", "dc_tpatient_bookingd");
                                StrBookingDetailID = objTrans.DataTrigger_Get_Max(objdbhims);

                                objdbhims.Query = "insert into dc_tstatustrack (labid,processid,testid,enteredby,enteredon,clientid,bookingdid) values ('" + StrLabID + "',10," + StrTestID + "," + StrEnteredBy + ",str_to_date('" + StrEnteredOn + "','%d/%m/%Y %h:%i:%s %p'),'" + StrClientID + "'," + StrBookingDetailID + ") ";
                                StrError = objTrans.DataTrigger_Insert(objdbhims);
                                if (StrError.Equals("True"))
                                {
                                    StrError = objTrans.OperationError;
                                    objTrans.End_Transaction();
                                    return false;
                                }
                                else
                                {
                                    if (!StrInt_Comment.Trim().Equals("") && !StrInt_Comment.Trim().Equals(Default))
                                    {
                                        objdbhims.Query = "insert into dc_tint_coment (bookingid,testid,description,active,process,for_process,enteredon,enteredby,clientid) values (" + StrBookingID + "," + StrTestID + ",'" + StrInt_Comment + "','Y',10," + StrFor_Process + ",str_to_date('" + StrEnteredOn + "','%d/%m/%Y %h:%i:%s %p'),"+StrEnteredBy+",'" + StrClientID + "')";
                                        StrError = objTrans.DataTrigger_Insert(objdbhims);
                                    }
                                    if (StrError.Equals("True"))
                                    {
                                        StrError = objTrans.OperationError;
                                        objTrans.End_Transaction();
                                        return false;
                                    }
                                }
                            }
                        }//

                    }

                    if (StrError.Equals("True"))
                    {
                        StrError = objTrans.OperationError;
                        objTrans.End_Transaction();
                        return false;
                    }
                    else
                    {

                        objdbhims.Query = "SELECT lpad(ifnull(max(substr(e.receiveno,9,7)),0)+1,7,0) as maxid FROM dc_tcashcollection e where substr(e.receiveno,6,2)= date_format(current_date,'%y') and substr(e.receiveno,2,3)='" + StrBranchID + "'";
                        StrReceive_No = this.objTrans.DataTrigger_Get_Max(objdbhims);

                        if (!StrReceive_No.Equals("True"))
                        {
                            StrReceive_No = "R" + StrBranchID + "-" + System.DateTime.Now.ToString("yy") + "-" + StrReceive_No;
                            objdbhims.Query = objQB.QBInsert(MakeArray_cash(), Table_Cash);
                            StrError = objTrans.DataTrigger_Insert(objdbhims);

                            if (!StrError.Equals("True"))
                            {
                                objdbhims.Query = "update dc_tpatient_bookingm set paidamount=" + StrPaidAmount + ",refund_amt=0,balance=" + StrTotalAmount + "-" + StrPaidAmount + "-" + StrDiscount + " where bookingid=" + StrBookingID + "";
                                //objdbhims.Query = "update dc_tpatient_bookingm set paidamount=" + StrPaidAmount + " where bookingid=" + StrBookingID + "";
                                StrError = objTrans.DataTrigger_Update(objdbhims);

                                if (!StrError.Equals("True") && StrRefundType.Equals("D"))
                                {
                                    objdbhims.Query = "SELECT lpad(ifnull(max(substr(e.refundno,9,7)),0)+1,7,0) as maxid FROM dc_tcashrefund e where substr(e.refundno,6,2)= date_format(current_date,'%y') and substr(e.refundno,2,3)='" + StrBranchID + "'";
                                    StrREfundNo = this.objTrans.DataTrigger_Get_Max(objdbhims);
                                    if (!StrREfundNo.Equals("True"))
                                    {
                                        StrREfundNo = "F" + StrBranchID + "-" + System.DateTime.Now.ToString("yy") + "-" + StrREfundNo;
                                        objdbhims.Query = objQB.QBInsert(MakeArray_Refund(), "dc_tcashrefund");
                                        StrError = objTrans.DataTrigger_Insert(objdbhims);

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

        public bool Insert_IntComent()
        {
            objTrans.Start_Transaction();

            objdbhims.Query = "insert into dc_tint_coment (bookingid,testid,description,active,process,for_process,enteredon,enteredby,clientid) values (" + StrBookingID + "," + StrTestID + ",'" + StrInt_Comment + "','Y',"+StrProcessID+"," + StrFor_Process + ",str_to_date('" + StrEnteredOn + "','%d/%m/%Y %h:%i:%s %p')," + StrEnteredBy + ",'" + StrClientID + "')";
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

        private string[,] MakeArray_Patient()
        {
            string[,] kd_arr = new string[23, 3];

            if (!StrPRID.Equals(Default) && !StrPRID.Equals(""))
            {
                kd_arr[0, 0] = "prid";
                kd_arr[0, 1] = this.StrPRID;
                kd_arr[0, 2] = "int";
            }
            if (!StrPRNO.Equals(Default))
            {
                kd_arr[1, 0] = "prno";
                kd_arr[1, 1] = this.StrPRNO;
                kd_arr[1, 2] = "string";
            }
            if (!StrTitle.Equals(Default))
            {
                kd_arr[2, 0] = "title";
                kd_arr[2, 1] = this.StrTitle;
                kd_arr[2, 2] = "string";
            }
            else
            {
                kd_arr[2, 0] = "title";
                kd_arr[2, 1] = "null";
                kd_arr[2, 2] = "int";

            }
            if (!StrName.Equals(Default))
            {
                kd_arr[3, 0] = "name";
                kd_arr[3, 1] = this.StrName;
                kd_arr[3, 2] = "string";
            }
            if (!StrGender.Equals(Default))
            {
                kd_arr[4, 0] = "gender";
                kd_arr[4, 1] = this.StrGender;
                kd_arr[4, 2] = "string";
            }
            if (!StrDOB.Equals(Default))
            {
                kd_arr[5, 0] = "dob";
                kd_arr[5, 1] = this.StrDOB;
                kd_arr[5, 2] = "date";
            }
            if (!StrHphone.Equals(Default) && !StrHphone.Equals(""))
            {
                kd_arr[6, 0] = "hphone";
                kd_arr[6, 1] = this.StrHphone;
                kd_arr[6, 2] = "int";
            }
            else
            {
                kd_arr[6, 0] = "hphone";
                kd_arr[6, 1] = "null";
                kd_arr[6, 2] = "int";
            }
            if (!StrCellNo.Equals(Default) && !StrCellNo.Equals(""))
            {
                kd_arr[7, 0] = "cellno";
                kd_arr[7, 1] = this.StrCellNo;
                kd_arr[7, 2] = "int";
            }
            else
            {
                kd_arr[7, 0] = "cellno";
                kd_arr[7, 1] = "null";
                kd_arr[7, 2] = "int";
            }
            if (!StrFax.Equals(Default) && !StrFax.Equals(""))
            {
                kd_arr[8, 0] = "fax";
                kd_arr[8, 1] = this.StrFax;
                kd_arr[8, 2] = "int";
            }
            else
            {
                kd_arr[8, 0] = "fax";
                kd_arr[8, 1] = "null";
                kd_arr[8, 2] = "int";
            }
            if (!StrEmail.Equals(Default))
            {
                kd_arr[9, 0] = "email";
                kd_arr[9, 1] = this.StrEmail;
                kd_arr[9, 2] = "string";
            }
            if (!StrCNIC.Equals(Default))
            {
                kd_arr[10, 0] = "cnic";
                kd_arr[10, 1] = this.StrCNIC;
                kd_arr[10, 2] = "string";
            }
            if (!StrAddress.Equals(Default))
            {
                kd_arr[11, 0] = "address";
                kd_arr[11, 1] = this.Address;
                kd_arr[11, 2] = "string";
            }
            if (!StrPanelID.Equals(Default))
            {
                kd_arr[12, 0] = "panelid";
                kd_arr[12, 1] = this.StrPanelID;
                kd_arr[12, 2] = "int";
            }
            if (!StrClassID.Equals(Default))
            {
                kd_arr[13, 0] = "classid";
                kd_arr[13, 1] = this.StrClassID;
                kd_arr[13, 2] = "int";
            }
            else
            {
                kd_arr[13, 0] = "classid";
                kd_arr[13, 1] = "null";
                kd_arr[13, 2] = "int";
            }
            if (!StrServiceNo.Equals(Default))
            {
                kd_arr[14, 0] = "serviceno";
                kd_arr[14, 1] = this.StrServiceNo;
                kd_arr[14, 2] = "string";
            }
            if (!StrEnteredBy.Equals(Default))
            {
                kd_arr[15, 0] = "enteredby";
                kd_arr[15, 1] = this.StrEnteredBy;
                kd_arr[15, 2] = "int";
            }
            if (!StrEnteredOn.Equals(Default))
            {
                kd_arr[16, 0] = "enteredon";
                kd_arr[16, 1] = this.StrEnteredOn;
                kd_arr[16, 2] = "datetime";
            }
            if (!StrClientID.Equals(Default))
            {
                kd_arr[17, 0] = "clientid";
                kd_arr[17, 1] = this.StrClientID;
                kd_arr[17, 2] = "string";
            }
            if (!StrMaritalStatus.Equals(Default))
            {
                kd_arr[18, 0] = "maritalstatus";
                kd_arr[18, 1] = this.StrMaritalStatus;
                kd_arr[18, 2] = "string";
            }
            if (!StrRelation.Equals(Default))
            {
                kd_arr[19, 0] = "relation";
                kd_arr[19, 1] = this.StrRelation;
                kd_arr[19, 2] = "string";
            }
            if (!Str_F_Parent.Equals(Default))
            {
                kd_arr[20, 0] = "f_parent";
                kd_arr[20, 1] = this.Str_F_Parent;
                kd_arr[20, 2] = "int";
            }
            if (!Str_S_Parent.Equals(Default))
            {
                kd_arr[21, 0] = "s_parent";
                kd_arr[21, 1] = this.Str_S_Parent;
                kd_arr[21, 2] = "int";
            }
            if (!StrPassword.Equals(Default))
            {
                kd_arr[22, 0] = "pasword";
                kd_arr[22, 1] = this.StrPassword;
                kd_arr[22, 2] = "string";
            }
            return kd_arr;
        }

        private string[,] MakeArray_Booking_M()
        {
            string[,] kd_array = new string[21, 3];

            if (!StrBookingID.Equals(Default))
            {
                kd_array[0, 0] = "bookingid";
                kd_array[0, 1] = this.StrBookingID;
                kd_array[0, 2] = "int";
            }
            if (!StrPRID.Equals(Default))
            {
                kd_array[1, 0] = "prid";
                kd_array[1, 1] = this.StrPRID;
                kd_array[1, 2] = "int";
            }
            if (!StrType.Equals(Default))
            {
                kd_array[2, 0] = "type";
                kd_array[2, 1] = this.StrType;
                kd_array[2, 2] = "string";
            }
            if (!StrLabID.Equals(Default))
            {
                kd_array[3, 0] = "labid";
                kd_array[3, 1] = this.StrLabID;
                kd_array[3, 2] = "string";
            }
            if (!StrTotalAmount.Equals(Default))
            {
                kd_array[4, 0] = "totalamount";
                kd_array[4, 1] = this.StrTotalAmount;
                kd_array[4, 2] = "int";
            }
            if (!StrDoctorID.Equals(Default))
            {
                kd_array[5, 0] = "doctorid";
                kd_array[5, 1] = this.StrDoctorID;
                kd_array[5, 2] = "int";
            }
            if (!StrReferredBY.Equals(Default))
            {
                kd_array[6, 0] = "referredby";
                kd_array[6, 1] = this.StrReferredBY;
                kd_array[6, 2] = "string";
            }
            if (!StrOrgin_Place.Equals(Default))
            {
                kd_array[7, 0] = "origin_place";
                kd_array[7, 1] = this.StrOrgin_Place;
                kd_array[7, 2] = "string";
            }
            if (!StrDeliveryBy.Equals(Default))
            {
                kd_array[8, 0] = "deliveryby";
                kd_array[8, 1] = this.StrDeliveryBy;
                kd_array[8, 2] = "string";
            }
            if (!StrEnteredBy.Equals(Default))
            {
                kd_array[9, 0] = "enteredby";
                kd_array[9, 1] = this.StrEnteredBy;
                kd_array[9, 2] = "int";
            }
            if (!StrEnteredOn.Equals(Default))
            {
                kd_array[10, 0] = "enteredon";
                kd_array[10, 1] = this.StrEnteredOn;
                kd_array[10, 2] = "datetime";
            }
            if (!StrClientID.Equals(Default))
            {
                kd_array[11, 0] = "clientid";
                kd_array[11, 1] = this.StrClientID;
                kd_array[11, 2] = "string";
            }
            if (!StrAuthorizeNo.Equals(Default))
            {
                kd_array[12, 0] = "authorizeno";
                kd_array[12, 1] = this.StrAuthorizeNo;
                kd_array[12, 2] = "string";
            }
            if (!StrDiscount.Equals(Default))
            {
                kd_array[13, 0] = "discount_amt";
                kd_array[13, 1] = this.StrDiscount;
                kd_array[13, 2] = "int";
            }
            if (!StrReferenceNo.Equals(Default))
            {
                kd_array[14, 0] = "referenceno";
                kd_array[14, 1] = this.StrReferenceNo;
                kd_array[14, 2] = "string";
            }
            if (!StrPatient_Type.Equals(Default))
            {
                kd_array[15, 0] = "payment_mode";
                kd_array[15, 1] = this.StrPatient_Type;
                kd_array[15, 2] = "string";
            }
            if (!StrRemarks.Equals(Default))
            {
                kd_array[16, 0] = "remarks";
                kd_array[16, 1] = this.StrRemarks;
                kd_array[16, 2] = "string";
            }
            if (!StrPanelID.Equals(Default))
            {
                kd_array[17, 0] = "panelid";
                kd_array[17, 1] = this.StrPanelID;
                kd_array[17, 2] = "int";
            }
            if (!StrWardID.Equals(Default))
            {
                kd_array[18, 0] = "wardid";
                kd_array[18, 1] = this.StrWardID;
                kd_array[18, 2] = "int";
            }
            if (!StrBed.Equals(Default))
            {
                kd_array[19, 0] = "bed";
                kd_array[19, 1] = this.StrBed;
                kd_array[19, 2] = "string";
            }
            if (!StrAdm_Ref.Equals(Default))
            {
                kd_array[20, 0] = "adm_ref";
                kd_array[20, 1] = this.StrAdm_Ref;
                kd_array[20, 2] = "string";
            }
            return kd_array;

        }

        private string[,] MakeArray_Booking_D()
        {
            string[,] kd_array = new string[13, 3];

            if (!StrBookingDetailID.Equals(Default))
            {
                kd_array[0, 0] = "bookingdid";
                kd_array[0, 1] = this.StrBookingDetailID;
                kd_array[0, 2] = "int";
            }
            if (!StrLabID.Equals(Default))
            {
                kd_array[1, 0] = "labid";
                kd_array[1, 1] = this.StrLabID;
                kd_array[1, 2] = "string";
            }
            if (!StrTestID.Equals(Default))
            {
                kd_array[2, 0] = "testid";
                kd_array[2, 1] = this.StrTestID;
                kd_array[2, 2] = "int";
            }
            if (!StrTestAmount.Equals(Default))
            {
                kd_array[3, 0] = "totalamount";
                kd_array[3, 1] = this.StrTestAmount;
                kd_array[3, 2] = "int";
            }
            if (!StrStatus.Equals(Default))
            {
                kd_array[4, 0] = "status";
                kd_array[4, 1] = this.StrStatus;
                kd_array[4, 2] = "string";
            }
            if (!StrDelivery_Time.Equals(Default))
            {
                kd_array[5, 0] = "deliveryTime";
                kd_array[5, 1] = this.StrDelivery_Time;
                kd_array[5, 2] = "datetime";
            }
            if (!StrClassificationID.Equals(Default))
            {
                kd_array[6, 0] = "classificationid";
                kd_array[6, 1] = this.StrClassificationID;
                kd_array[6, 2] = "int";
            }
            if (!StrBookingID.Equals(Default))
            {
                kd_array[7, 0] = "bookingid";
                kd_array[7, 1] = this.StrBookingID;
                kd_array[7, 2] = "int";
            }
            if (!StrPriority.Equals(Default))
            {
                kd_array[8, 0] = "priority";
                kd_array[8, 1] = this.StrPriority;
                kd_array[8, 2] = "string";
            }
            if (!StrEnteredBy.Equals(Default))
            {
                kd_array[9, 0] = "enteredby";
                kd_array[9, 1] = this.StrEnteredBy;
                kd_array[9, 2] = "int";
            }
            if (!StrEnteredOn.Equals(Default))
            {
                kd_array[10, 0] = "enteredon";
                kd_array[10, 1] = this.StrEnteredOn;
                kd_array[10, 2] = "datetime";
            }
            if (!StrClientID.Equals(Default))
            {
                kd_array[11, 0] = "clientid";
                kd_array[11, 1] = Session["default_route"].ToString();
                kd_array[11, 2] = "string";
            }
            if (!StrProcessID.Equals(Default))
            {
                kd_array[12, 0] = "processid";
                kd_array[12, 1] = this.StrProcessID;
                kd_array[12, 2] = "int";
            }
            return kd_array;

        }

        private string[,] MakeArray_cash()
        {
            string[,] kdc_arr = new string[13, 3];

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
            if (!StrReceive_No.Equals(Default))
            {
                kdc_arr[3, 0] = "receiveno";
                kdc_arr[3, 1] = this.StrReceive_No;
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
            if (!StrDiscount.Equals(Default))
            {
                kdc_arr[11, 0] = "discount";
                kdc_arr[11, 1] = this.StrDiscount;
                kdc_arr[11, 2] = "int";
            }
            if (!StrCard_ReferenceNo.Equals(Default))
            {
                kdc_arr[12, 0] = "referenceno";
                kdc_arr[12, 1] = this.StrCard_ReferenceNo;
                kdc_arr[12, 2] = "string";
            }
            return kdc_arr;
        }

        private string[,] MakeArray_Refund()
        {
            string[,] kdc_arr = new string[15, 3];

            if (!StrREfundNo.Equals(Default))
            {
                kdc_arr[1, 0] = "refundno";
                kdc_arr[1, 1] = this.StrREfundNo;
                kdc_arr[1, 2] = "string";
            }
            if (!StrBookingID.Equals(Default))
            {
                kdc_arr[2, 0] = "bookingid";
                kdc_arr[2, 1] = this.StrBookingID;
                kdc_arr[2, 2] = "int";
            }
            if (!StrReceive_No.Equals(Default))
            {
                kdc_arr[3, 0] = "receiveno";
                kdc_arr[3, 1] = this.StrReceive_No;
                kdc_arr[3, 2] = "string";
            }
            if (!StrPRID.Equals(Default))
            {
                kdc_arr[4, 0] = "prid";
                kdc_arr[4, 1] = this.StrPRID;
                kdc_arr[4, 2] = "int";
            }
            if (!StrClientID.Equals(Default))
            {
                kdc_arr[5, 0] = "clientid";
                kdc_arr[5, 1] = this.StrClientID;
                kdc_arr[5, 2] = "string";
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
                kdc_arr[7, 1] = StrRefundType;
                kdc_arr[7, 2] = "string";
            }
            if (!StrEnteredBy.Equals(Default))
            {
                kdc_arr[8, 0] = "authorizedby";
                kdc_arr[8, 1] = this.StrEnteredBy;
                kdc_arr[8, 2] = "int";
            }
            if (!StrEnteredBy.Equals(Default))
            {
                kdc_arr[9, 0] = "comments";
                kdc_arr[9, 1] = "discount on reception";
                kdc_arr[9, 2] = "string";
            }
            if (!StrTotalAmount.Equals(Default))
            {
                kdc_arr[10, 0] = "totalamount";
                kdc_arr[10, 1] = this.StrTotalAmount;
                kdc_arr[10, 2] = "int";
            }
            if (!StrDiscount.Equals(Default))
            {
                kdc_arr[11, 0] = "paidamount";
                kdc_arr[11, 1] = this.StrDiscount;
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
            kdc_arr[14, 0] = "type";
            kdc_arr[14, 1] = "B";
            kdc_arr[14, 2] = "string";

            return kdc_arr;
        }

        private bool Validate_Patient()
        {
            //if (!StrPanelID.Equals(Default) && !StrPanelID.Equals("-1"))
            //{
            //    DataView dv = GetAll(26);
            //    if (dv.Count > 0)
            //    {
            //        if (!StrPRID.Equals(Default) && !StrPRID.Equals("") && StrPRID != null)
            //            dv.RowFilter = "prid <>" + StrPRID;
            //        if (dv.Count > 0)
            //        {
            //            StrError = "This patient is already got prno.";
            //            return false;
            //        }
            //        else
            //        {
            //            return true;
            //        }
            //    }
            //    else
            //    {
            //        return true;
            //    }
            //}

            //if (!StrPanelID.Equals(Default) && !StrRelation.Equals("Self"))
            //{
            //    DataView dv = GetAll(16);
            //    if (!StrPRID.Equals(Default) && !StrPRID.Equals("") && StrPRID != null)
            //        dv.RowFilter = "prid <>" + StrPRID + " and relation='Self'";
            //    if (dv.Count > 0)
            //    {
            //        //return true;

            //    }
            //    else
            //    {
            //        StrError = "There is no parent found.Please add parent before add Dependent.";
            //        return false;
            //    }
            //}

            //if (!StrPanelID.Equals(Default) && StrRelation.Equals("Self"))
            //{
            //    DataView dv = GetAll(16);
            //    if (dv.Count > 0)
            //    {
            //        if (!StrPRID.Equals(Default) && !StrPRID.Equals("") && StrPRID != null)
            //            dv.RowFilter = "prid <>" + StrPRID;
            //        if (dv.Count > 0)
            //        {
            //            StrError = "Employee already registered against this service number.";
            //            return false;
            //        }
            //        else
            //        {
            //           // return true;
            //        }

            //    }
            //    else
            //    {
            //        //StrError = "There is no self dependent found.Please add Self first then add dependent";
            //       //-- return true;
            //    }
            //}
            //if (!StrPanelID.Equals(Default) && StrRelation.Equals("F/O"))
            //{
            //    DataView dv = GetAll(21);
            //    if (dv.Count > 0)
            //    {
            //        if (!StrPRID.Equals(Default) && !StrPRID.Equals("") && StrPRID != null)
            //            dv.RowFilter = "prid <>" + StrPRID;
            //        if (dv.Count > 0)
            //        {
            //            StrError = "Employee father already exist";
            //            return false;
            //        }
            //        else
            //        {
            //            //return true;
            //        }

            //    }
            //    else
            //    {
            //        //StrError = "There is no self dependent found.Please add Self first then add dependent";
            //        return true;
            //    }
            //}



            return true;
        }

        private bool vald_alrdy()
        {

            return true;
        }
        private bool Vald_Self()
        {

            return true;
        }
        private bool vald_Fath()
        {

            return true;
        }

        private DateTime Date_test(string strSchedule,DateTime dt,DataView dv)
        {
            bool istrue = true;
            int dd = 0;
            int wk = 0;
            DateTime dtnow = new DateTime();
            if (dv[0]["type"].ToString().Equals("Days"))
            {
                while (istrue)
                {
                    for (int i = 0; i < dv.Count; i++)
                    {
                        if (dt.AddDays(dd).DayOfWeek.ToString().ToLower().Contains(dv[i]["sched"].ToString()))
                        {
                            //lblDay.Text = Convert.ToString(Math.Round(Convert.ToDouble(dt.Day) / 7));
                            //lblDay.Text += "\n" + dt.AddDays(i).Day.ToString();
                            dtnow = dt.AddDays(dd).Date;
                            istrue = false;
                        }
                    }
                    dd++;
                }
            }
            else
            {
                while (istrue)
                {
                    for (int j = 0; j < dv.Count; j++)
                    {
                        if (get(dt) == Convert.ToInt32(dv[j]["sched"].ToString().Substring(0, 1)))
                        {
                            for (int k = 0; k < dv.Count; k++)
                            {
                                if ((get(dt) == Convert.ToDouble(dv[j]["sched"].ToString().Substring(0, 1))) && dt.DayOfWeek.ToString().ToLower().Contains(dv[k]["sched"].ToString().Substring(2, 3)))
                                {
                                    dtnow = dt.Date;
                                    istrue = false;
                                }
                            }
                        }
                    }

                    wk++;
                    dt = Convert.ToDateTime(System.DateTime.Now.AddDays(wk).ToString("MM/dd/yyyy hh:mm:ss tt"));
                }
            }
            return dtnow;
        }
        private int get(DateTime date)
        {

            DateTime tempdate = date.AddDays(-date.Day + 1);

            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            int weekNumStart = ciCurr.Calendar.GetWeekOfYear(tempdate, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
            int weekNum = ciCurr.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);

            return weekNum - weekNumStart + 1;
        }
        #endregion
    }
}
