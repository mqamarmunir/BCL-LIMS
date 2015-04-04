using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataLayer;
using System.Globalization;
using System.Web.UI;
using System.Web.Configuration;

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

        private string _BranchID = Default;
        private string _DestinationBranchID = Default;
        private string _sendstatus = Default;

     	private string _SpecimenInternal = Default;
        private string _history_antobiotics = Default;
        private string _prescription_document_path = Default;

        private string _discountAll = Default;
        private string _brpercentagediscount = Default;
        private string _CardType = Default;

       
        private string _BankName = Default;
        private string _CardExpiryDate = Default;
        private string _CardNumber = Default;

        private string _percentdiscountpanel = Default;//to panel patients on panel ratess
        private string _paidamountsingle = Default;//payment made against single test
        private string _percentdiscountcash = Default;
        private string _tempbookingstatus = Default;
        private string _PathCliqueId = Default;
        private string _DateFrom = Default;
        private string _dependent_cliq_id = Default;

        public string Dependent_cliq_id
        {
            get { return _dependent_cliq_id; }
            set { _dependent_cliq_id = value; }
        }
       
        private string _DateTo = Default;
       
        public string DateFrom
        {
            get { return _DateFrom; }
            set { _DateFrom = value; }
        }
        public string DateTo
        {
            get { return _DateTo; }
            set { _DateTo = value; }
        }
        public string PathCliqueId
        {
            get { return _PathCliqueId; }
            set { _PathCliqueId = value; }
        }

        public string Tempbookingstatus
        {
            get { return _tempbookingstatus; }
            set { _tempbookingstatus = value; }
        }

        public string Percentdiscountcash
        {
            get { return _percentdiscountcash; }
            set { _percentdiscountcash = value; }
        }
        public string Paidamountsingle
        {
            get { return _paidamountsingle; }
            set { _paidamountsingle = value; }
        }

        public string percentdiscountpanel
        {
            get { return _percentdiscountpanel; }
            set { _percentdiscountpanel = value; }
        }        
public string Brpercentagediscount
        {
            get { return _brpercentagediscount; }
            set { _brpercentagediscount = value; }
        }

        public string DiscountAll
        {
            get { return _discountAll; }
            set { _discountAll = value; }
        }
      
        #endregion

        #region"Properties"
        public string CardType
        {
            get { return _CardType; }
            set { _CardType = value; }
        }
        public string BankName
        {
            get { return _BankName; }
            set { _BankName = value; }
        }
        public string CardExpiryDate
        {
            get { return _CardExpiryDate; }
            set { _CardExpiryDate = value; }
        }
        public string CardNumber
        {
            get { return _CardNumber; }
            set { _CardNumber = value; }
        }
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

        private string _headerid = Default;

        public string Headerid
        {
            get { return _headerid; }
            set { _headerid = value; }
        }

        public string Branch_ID
        {
            get { return _BranchID; }
            set { _BranchID = value; }
        }

        public string DestinationBranchID
        {
            get { return _DestinationBranchID; }
            set { _DestinationBranchID = value; }
        }
        public string Sendstatus
        {
            get { return _sendstatus; }
            set { _sendstatus = value; }
        }

	public string SpecimenInternal
        {
            get { return _SpecimenInternal; }
            set { _SpecimenInternal = value; }
        }
    public string Prescription_document_path
    {
        get { return _prescription_document_path; }
        set { _prescription_document_path = value; }
    }
    public string History_antobiotics
    {
        get { return _history_antobiotics; }
        set { _history_antobiotics = value; }
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
                    objdbhims.Query += " order by Dorder";
                    break;
                case 4: // fill group
                    objdbhims.Query = "select g.groupid,g.name as groupname from dc_tp_groupm g inner join dc_tp_branchgroups bg on bg.GroupID=g.Groupid where g.active='Y' and bg.Active='Y' and g.Package='Y' and sysdate() between packagedatefrom and packagedateto and bg.BranchID="+_BranchID+" order by name";
                    break;
                case 5: // fill test
                    objdbhims.Query = "select c.classificationid, t.testid,concat(ifnull(su.acronym,''),':',t.test_name,' ',ifnull(c.name,'')) as testname,case when 'N'='" + StrPriority + "' and 'P'='" + StrRate + "' then ifnull(t.charges,0)+ifnull(org.process_fee,0) when 'N'='" + StrPriority + "' and 'C'='" + StrRate + "' then ifnull(t.charityrate,0)+ifnull(org.process_fee,0) else ifnull(chargesurgent,0)+ifnull(org.process_fee,0) end as charges,'" + StrPriority + "' as priority,concat(ifnull(t.speedkey,''),':') as speedkey,ifnull(mt.maxtime,0) as maxtime,'Y' as print_amount,t.dplan,t.time1,t.time2,t.time3,t.time4,t.dispatchtime1,t.dispatchtime2,t.dispatchtime3,t.dispatchtime4 from dc_tp_test t left outer join dc_tp_tclass c on t.testid=c.testid left outer join dc_tp_test_age ag on t.testid = ag.testid left outer join dc_tp_subdepartments su on t.subdepartmentid=su.subdepartmentid left outer join dc_tp_organization org on t.external_org= org.orgid left outer join dc_tp_method mt on t.d_methodid=mt.methodid where t.active='Y' and ag.maxage >" + StrDOB + " and ag.minage<=" + StrDOB + " and (ag.gender='" + StrGender + "' or ag.gender='A') ";
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
                    objdbhims.Query = "select panelid,concat(ifnull(Acronym,'-'),':',name) as name,cashpanel from dc_tpanel where active='Y' and panelid in (Select panelid From dc_tp_branchpanels where branchid=" + _BranchID + " and Active='Y') order by clientid";
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
                    objdbhims.Query = "select (select concat(ifnull(title,''),' ',name) from dc_tpatient where prid=p.f_parent) as panelpatient, p.prid,p.prno,p.name,p.title,ifnull(m.authorizeno,'') authorizeno,case when p.gender = 'M' then 'Male' else 'Female' end as gender,concat(date_format(p.dob,'%d/%m/%Y'),' (',  case when DATEDIFF(CURRENT_DATE,p.dob) > 365 then      concat(Floor(DATEDIFF(CURRENT_DATE,p.dob)/365),' -Y')  else case when DATEDIFF(CURRENT_DATE,p.dob) > 30 then      concat(Floor(DATEDIFF(CURRENT_DATE,p.dob)/30),' -M')     else concat(DATEDIFF(CURRENT_DATE,p.dob),'-D') end end,')' )  as dob_age,date_format(p.dob,'%d/%m/%Y') as dob,p.hphone,p.cellno,p.fax,p.email,p.cnic, pn.panelid ,pn.cashpanel,p.serviceno,p.classid,p.address,case when p.maritalstatus ='S' then 'Single' else 'Married' end as maritalstatus,concat(ifnull(p.title,''),' ',p.name) as patientname,p.relation,p.f_parent,ifnull(pn.name,'-') as panelname from ((dc_Tpatient p left outer join dc_Tpatient_bookingm m on m.prid=p.prid and m.bookingid=(select max(mm.bookingid) from dc_tpatient_bookingm mm where mm.prid=p.prid) )left outer join dc_tpanel pn on pn.panelid = m.panelid)  where 1=1";
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
                    //if (!_BranchID.Equals("") && !_BranchID.Equals(Default))
                    //    objdbhims.Query += " and (p.BranchID=" + Convert.ToInt32(_BranchID) + " or p.panelid in(Select panelid From dc_tp_branchpanels where BranchID="+Convert.ToInt32(_BranchID)+" and Active='Y'))";
                    break;
                case 10: // fill doctor
                    objdbhims.Query = "SELECT personid,concat(fname,' ',ifnull(mname,''),' ',ifnull(lname,'')) as name FROM dc_tp_personnel where active='Y' and designationid=3";
                    break;
                case 11: // fill test gv on group : cash patient
                    objdbhims.Query += @"select distinct d.groupid, t.SpecialTest,c.classificationid,t.TestInfoReport TestInformation, t.testid,concat(ifnull(su.acronym,''),':',t.test_name,' ',ifnull(c.name,'')) as testname,
case when 'N'='" + StrPriority + @"' and 'P'='" + StrRate + "' then ifnull(d.charges,0)+ifnull(org.process_fee,0) when 'N'='" + StrPriority + @"' and 'C'='" + StrRate + @"' then ifnull(t.charityrate,0)+ifnull(org.process_fee,0) else ifnull(chargesurgent,0)+ifnull(org.process_fee,0) end as brtestcharges,
d.groupid,'N' as priority,
concat(ifnull(t.speedkey,''),':') as speedkey,
ifnull(mt.maxtime,0) as maxtime,bt.OfferedPrice as charges,
bt.External External,bt.DestinationBranchID DestinationBranch,
bt.TATType,bt.TATValue,bt.FranchiseDiscount,
bt.TestPrice Branchcost,t.dplan,t.time1,t.time2,t.time3,t.time4,
t.dispatchtime1,t.dispatchtime2,t.dispatchtime3,t.dispatchtime4,
b.Dplan_InternalTests,ifnull(bt.percentagediscount,0) as brpercentagediscount
from dc_tp_groupd d left outer join dc_tp_test t on d.testid=t.testid
left outer join dc_tp_tclass c on t.testid=c.testid
left outer join dc_tp_test_age ag on t.testid = ag.testid
left outer join dc_tp_subdepartments su on t.subdepartmentid=su.subdepartmentid
left outer join dc_tp_organization org on t.external_org= org.orgid
left outer join dc_tp_tmethod tmm on tmm.testid=t.testid
left outer join dc_tp_method mt on tmm.methodid=mt.methodid
inner join dc_tp_branchtestd bt on d.Testid=bt.testid
inner join dc_tp_branch b on b.BranchID=bt.branchID
where d.groupid=" + StrGroupID + " and t.active='Y' and tmm.m_default='Y' and d.active='Y' and bt.Branchid=" + _BranchID + " and ag.maxage >" + StrDOB + " and ag.minage<=" + StrDOB + " and (ag.gender='" + StrGender + "' or ag.gender='A')";
                    if (StrRate.Equals("C"))
                        objdbhims.Query += " and ifnull(t.charityrate,0) <>0";
                    #region old query before Branch groups
                    //objdbhims.Query = "select distinct c.classificationid, d.testid,concat(ifnull(su.acronym,''),':',t.test_name,' ',ifnull(c.name,'')) as testname,case when 'N'='" + StrPriority + "' and 'P'='" + StrRate + "' then ifnull(d.charges,0)+ifnull(org.process_fee,0) when 'N'='" + StrPriority + "' and 'C'='" + StrRate + "' then ifnull(t.charityrate,0)+ifnull(org.process_fee,0) else ifnull(chargesurgent,0)+ifnull(org.process_fee,0) end as charges,d.groupid,'" + StrPriority + "' as priority,concat(ifnull(t.speedkey,''),':') as speedkey,ifnull(mt.maxtime,0) as maxtime from dc_tp_groupd d left outer join dc_tp_test t on d.testid=t.testid left outer join dc_tp_tclass c on t.testid=c.testid left outer join dc_tp_test_age ag on t.testid = ag.testid left outer join dc_tp_subdepartments su on t.subdepartmentid=su.subdepartmentid left outer join dc_tp_organization org on t.external_org= org.orgid left outer join dc_tp_method mt on t.d_methodid=mt.methodid where d.groupid=" + StrGroupID + " and t.active='Y' and d.active='Y' and ag.maxage >" + StrDOB + " and ag.minage<=" + StrDOB + " and (ag.gender='" + StrGender + "' or ag.gender='A')";
                    //if (StrRate.Equals("C"))
                    //    objdbhims.Query += " and ifnull(t.charityrate,0) <>0";
                    #endregion
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
                    objdbhims.Query = "select c.classificationid, t.testid,concat(ifnull(su.acronym,''),':',t.test_name,' ',ifnull(c.name,'')) as testname,ifnull(pt.rate,0)+ifnull(org.process_fee,0)  as charges, '" + StrPriority + "' as priority, concat(ifnull(t.speedkey,''),':') as speedkey,ifnull(mt.maxtime,0) as maxtime,ifnull(pn.print_amount,'N') as print_amount,t.dplan,t.time1,t.time2,t.time3,t.time4,t.dispatchtime1,t.dispatchtime2,t.dispatchtime3,t.dispatchtime4 from dc_tpanel_test pt left outer join dc_tp_test t on pt.testid=t.testid left outer join dc_tp_tclass c on t.testid=c.testid left outer join dc_tp_test_age ag on t.testid = ag.testid left outer join dc_tp_subdepartments su on t.subdepartmentid=su.subdepartmentid left outer join dc_tp_organization org on t.external_org= org.orgid left outer join dc_tp_method mt on t.d_methodid=mt.methodid left outer join dc_tpanel pn on pn.panelid=pt.panelid where t.active='Y' and ag.maxage >" + StrDOB + " and ag.minage<=" + StrDOB + " and (ag.gender='" + StrGender + "' or ag.gender='A')";
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
                    objdbhims.Query = "select g.name as groupname,g.groupid from dc_tp_groupm G INNER JOIN DC_TP_BRANCHGROUPS bg on bg.groupid=g.groupid where bg.active='Y' and g.Active='Y' and bg.BranchID="+_BranchID+" and g.groupid in (select groupid from dc_tpanel_test where panelid=" + StrPanelID + ") order by name";
                    break;
                case 28: // fill test group panel
                    objdbhims.Query = @"select distinct c.classificationid,
                d.testid,
                concat(ifnull(su.acronym, ''),
                       ':',
                       t.test_name,
                       ' ',
                       ifnull(c.name, '')) as testname,
                case
                  when 'N' = 'N' and 'P' = 'P' then
                   ifnull(d.rate, 0) + ifnull(org.process_fee, 0)
                  when 'N' = 'N' and 'C' = 'P' then
                   ifnull(t.charityrate, 0) + ifnull(org.process_fee, 0)
                  else
                   ifnull(chargesurgent, 0) + ifnull(org.process_fee, 0)
                end as brtestcharges,
                d.groupid,
                'N' as priority,
                concat(ifnull(t.speedkey, ''), ':') as speedkey,
                ifnull(mt.maxtime, 0) as maxtime,
                bt.offeredprice as charges,
                bt.External,
                ifnull(bt.DestinationBranchid, 0) as DestinationBranch,
                bt.TATType,
                bt.TATValue,
                bt.FranchiseDiscount,
                bt.TestPrice Branchcost,
                t.dplan,
                t.time1,
                t.time2,
                t.time3,
                t.time4,
                t.dispatchtime1,
                t.dispatchtime2,
                t.dispatchtime3,
                t.dispatchtime4,
                b.Dplan_InternalTests,
                ifnull(bt.percentagediscount, 0) as brpercentagediscount,
t.testinforeport testInformation,t.SpecialTest,d.percentdiscount percentdiscountpanel

  from dc_tpanel_test d
  left outer join dc_tp_test t
    on d.testid = t.testid
 inner join dc_tpanel p
    on p.panelid = d.panelid
  left outer join dc_tp_tclass c
    on t.testid = c.testid
  left outer join dc_tp_test_age ag
    on t.testid = ag.testid
  left outer join dc_tp_subdepartments su
    on t.subdepartmentid = su.subdepartmentid
  left outer join dc_tp_organization org
    on t.external_org = org.orgid
  left outer join dc_tp_tmethod m
    on t.testid = m.testid
   and m.m_default = 'Y'

 inner join dc_tp_method mt
    on m.methodid = mt.methodid
 inner join dc_tp_branchtestd bt
    on t.Testid = bt.testid
 inner join dc_tp_branch b
    on b.BranchID = bt.branchID
inner join dc_tp_branchgroups bg on bg.groupid=d.groupid
 where d.groupid = " + StrGroupID+@"
   and t.active = 'Y'
   and ag.maxage > "+StrDOB+@"
   and ag.minage <= "+StrDOB+@"
   and (ag.gender = '"+StrGender+@"' or ag.gender = 'A')
   and d.panelid ="+StrPanelID+@"
   and bt.branchid = "+_BranchID;

                    #region old query before catering branches and Packages
                   // objdbhims.Query = "select distinct c.classificationid, d.testid,concat(ifnull(su.acronym,''),':',t.test_name,' ',ifnull(c.name,'')) as testname,case when 'N'='" + StrPriority + "' and 'P'='" + StrRate + "' then ifnull(d.rate,0)+ifnull(org.process_fee,0) when 'N'='" + StrPriority + "' and 'C'='" + StrRate + "' then ifnull(t.charityrate,0)+ifnull(org.process_fee,0) else ifnull(chargesurgent,0)+ifnull(org.process_fee,0) end as charges,d.groupid,'"+StrPriority+"' as priority, concat(ifnull(t.speedkey,''),':') as speedkey,ifnull(mt.maxtime,0) as maxtime from dc_tpanel_test d left outer join dc_tp_test t on d.testid=t.testid left outer join dc_tp_tclass c on t.testid=c.testid left outer join dc_tp_test_age ag on t.testid = ag.testid left outer join dc_tp_subdepartments su on t.subdepartmentid=su.subdepartmentid left outer join dc_tp_organization org on t.external_org= org.orgid left outer join dc_tp_method mt on t.d_methodid=mt.methodid where d.groupid="+StrGroupID+" and t.active='Y' and ag.maxage >" + StrDOB + " and ag.minage<=" + StrDOB + " and (ag.gender='" + StrGender + "' or ag.gender='A') and panelid="+StrPanelID+"";
                    #endregion
                    break;
                case 29: // internal comment fill process
                    objdbhims.Query = " SELECT p.name,p.processid FROM dc_tp_tprocess p join dc_tp_tprocedured d join dc_tp_test t where p.active='Y' and p.processid=d.processid and t.procedureid=d.procedureid and t.testid="+StrTestID+" ";
                    break;
                case 30: // internal comment shw
                    objdbhims.Query = "SELECT d.comentid,d.bookingid,d.testid,d.description,d.active,date_format(d.enteredon,'%d/%m/%Y') as enteredon,d.for_process,concat(p.salutation,p.fname,' ',ifnull(p.mname,''),' ' ,ifnull(p.lname,'')) as enteredby FROM dc_tint_coment d join dc_Tp_personnel p where p.personid=d.enteredby and d.testid="+StrTestID+" and d.bookingid="+StrBookingID+" and (d.for_process is null or d.for_process="+StrFor_Process+") order by d.enteredon desc";
                    break;
                case 31: // ward ddl\
                    objdbhims.Query = "select wardid,name from dc_tp_ward where active='Y' and Branchid="+_BranchID;
                   
                    break;
                case 32:
                    if (WebConfigurationManager.AppSettings["clientid"].Trim() == "006")
                    {
                        objdbhims.Query = "SELECT d.maxtime FROM dc_tp_method d join dc_Tp_tmethod tm on tm.methodid=d.methodid  join dc_tp_test t  on tm.testid = t.testid where t.testid=" + StrTestID + " and tm.m_default='Y' ";
                        //System.Configuration.ConfigurationSettings.AppSettings["clientid"].ToString()
                        //if (Session["default_route"].ToString().Equals("006"))
                        //    objdbhims.Query += " and (case when ifnull(t.external_org,'006') ='006' then tm.clientid='006' when  t.external_org = '008'  then tm.clientid ='008' else tm.clientid='006'  end)";
                        //if (Session["default_route"].ToString().Equals("008"))
                        //    objdbhims.Query += " and (case when ifnull(t.external_org,'008') ='008' then tm.clientid='008' when  t.external_org = '006'  then tm.clientid ='006' else tm.clientid='006' end)";
                    }
                    else
                    {
                        objdbhims.Query = "SELECT d.maxtime FROM dc_tp_method d join dc_Tp_tmethod tm on tm.methodid=d.methodid  join dc_tp_test t  on tm.testid = t.testid where t.testid=" + StrTestID + " and tm.m_default='Y' and tm.ClientId='" + StrOrgID + "'";
                        //System.Configuration.ConfigurationSettings.AppSettings["clientid"].ToString()
                        //if (Session["default_route"].ToString().Equals("006"))
                        //    objdbhims.Query += " and (case when ifnull(t.external_org,'006') ='006' then tm.clientid='006' when  t.external_org = '008'  then tm.clientid ='008' else tm.clientid='006'  end)";
                        //if (Session["default_route"].ToString().Equals("008"))
                        //    objdbhims.Query += " and (case when ifnull(t.external_org,'008') ='008' then tm.clientid='008' when  t.external_org = '006'  then tm.clientid ='006' else tm.clientid='006' end)";
                    }
                   break;
                case 33:
                    objdbhims.Query = "SELECT prno,name,gender,dob,hphone,Pasword,enteredon FROM dc_tpatient WHERE prid = '" + StrPRID + "' limit 1";
                    break;
                case 34:
                    objdbhims.Query = "select ifnull(m.specimen_internal,'I') as specimen,ifnull(pp.serviceno,'nil') as serviceno,ifnull(pp.email,'-') as email,c.receiveno,c.labid,ifnull(c.paidamount,0) as paidamount,c.totalamount,d.totalamount as charges,concat(t.test_name,' ',ifnull(cl.name,'')) as testname, concat(pr.salutation,' ',pr.fname,' ',ifnull(mname,''),' ',ifnull(lname,'')) as receivedby,concat(ifnull(pp.title,''),' ',pp.name) as patient, date_format(c.enteredon,'%d-%m-%Y %h:%i %p') as receivedon,pp.prno, d.deliverytime,DATE_FORMAT(DATE_ADD(DATE_FORMAT(d.deliverytime, '%Y-%m-%d %H:00:00'),INTERVAL IF(MINUTE(d.deliverytime) < 30, 0, 1)  HOUR),'%d-%m-%Y %h:00 %p') AS deliverydatetime ,concat(og.name,' ',og.address) as orgaddress,og.phoneno,date_format(pp.dob,'%d/%m/%Y') as dob,case when pp.gender='M' then 'Male' else 'Female' end as gender,cl.classificationid,d.testid,m.bookingid,m.prid,c.paymentmode,pn.panelid,pn.name as panelname,ifnull(m.authorizeno,'') as authorizeno,ifnull(pp.serviceno,'') as serviceno,case when pp.address is null or pp.address='' then '-' else pp.address end as address,m.enteredon,case when DATEDIFF(CURRENT_DATE,pp.dob) > 365 then      concat(Floor(DATEDIFF(CURRENT_DATE,pp.dob)/365),'(Years)')  else    case when DATEDIFF(CURRENT_DATE,pp.dob) > 30 then      concat(Floor(DATEDIFF(CURRENT_DATE,pp.dob)/30),' (M)')    else      concat(DATEDIFF(CURRENT_DATE,pp.dob),'(D)')    end  end  AS age,case when m.doctorid is null or m.doctorid='' then m.referredby else concat(ifnull(dr.title,''),' ',dr.name) end as consultant,m.discount_amt,ifnull((select sum(ifnull(paidamount,0)) from dc_tcashcollection where bookingid=m.bookingid),0) as totalpaid, pp.cellno,pp.hphone,dr.code,m.referenceno,t.external,t.speedkey,pp.pasword,m.remarks,m.payment_mode as M_Bmode,pn.print_amount,w.name as ward,m.type as ind_outdoor,m.origin_place from dc_tcashcollection c  join dc_tpatient_bookingm m on c.bookingid = m.bookingid left outer join dc_tp_personnel pr on c.enteredby = pr.personid join dc_tpatient_bookingd d on m.bookingid = d.bookingid join dc_tp_test t on d.testid = t.testid left outer join dc_tp_tclass cl  on d.classificationid = cl.classificationid join dc_tpatient pp on m.prid = pp.prid left outer join dc_tp_organization og on m.origin_place = og.orgid left outer join dc_tpanel pn on c.panelid= pn.panelid left outer join dc_tp_refdoctors dr on dr.doctorid=m.doctorid left outer join dc_tp_ward w on w.wardid=m.wardid WHERE pp.prno = '" + PRNO + "' AND d.labid = '" + LabID + "' Group By prid  ";
                    break;
                case 35:
                    objdbhims.Query = "select ifnull(gm.Name,'') as groupname, ifnull(d.totalamount-d.paidamount,'None') as discount,c.receiveno,c.labid,ifnull(c.paidamount,0) as paidamount,c.totalamount,d.totalamount as charges,concat(t.test_name,' ',ifnull(cl.name,'')) as testname, concat(pr.salutation,' ',pr.fname,' ',ifnull(mname,''),' ',ifnull(lname,'')) as receivedby,concat(ifnull(pp.title,''),' ',pp.name) as patient, date_format(c.enteredon,'%d/%m/%y %h:%i %p') as receivedon,pp.prno, d.deliverytime,DATE_FORMAT(DATE_ADD(DATE_FORMAT(d.deliverytime, '%Y-%m-%d %H:00:00'),INTERVAL IF(MINUTE(d.deliverytime) < 30, 0, 1)  HOUR),'%d-%m-%Y %H:00:00') AS deliverydatetime ,concat(og.name,' ',og.address) as orgaddress,og.phoneno,date_format(pp.dob,'%d/%m/%Y') as dob,case when pp.gender='M' then 'Male' else 'Female' end as gender,cl.classificationid,d.testid,m.bookingid,m.prid,c.paymentmode,pn.panelid,pn.name as panelname,ifnull(m.authorizeno,'') as authorizeno,ifnull(pp.serviceno,'') as serviceno,case when pp.address is null or pp.address='' then '-' else pp.address end as address,m.enteredon,case when DATEDIFF(CURRENT_DATE,pp.dob) > 365 then      concat(Floor(DATEDIFF(CURRENT_DATE,pp.dob)/365),'(Years)')  else    case when DATEDIFF(CURRENT_DATE,pp.dob) > 30 then      concat(Floor(DATEDIFF(CURRENT_DATE,pp.dob)/30),' (M)')    else      concat(DATEDIFF(CURRENT_DATE,pp.dob),'(D)')    end  end  AS age,case when m.doctorid is null or m.doctorid='' then m.referredby else concat(ifnull(dr.title,''),' ',dr.name) end as consultant,m.discount_amt,ifnull((select sum(ifnull(paidamount,0)) from dc_tcashcollection where bookingid=m.bookingid),0) as totalpaid, pp.cellno,pp.hphone,dr.code,m.referenceno,t.external,t.speedkey,pp.pasword,m.remarks,m.payment_mode as M_Bmode,pn.print_amount,w.name as ward,m.type as ind_outdoor,m.origin_place from dc_tcashcollection c  join dc_tpatient_bookingm m on c.bookingid = m.bookingid left outer join dc_tp_personnel pr on c.enteredby = pr.personid join dc_tpatient_bookingd d on m.bookingid = d.bookingid join dc_tp_test t on d.testid = t.testid left outer join dc_tp_tclass cl  on d.classificationid = cl.classificationid join dc_tpatient pp on m.prid = pp.prid left outer join dc_tp_organization og on m.origin_place = og.orgid left outer join dc_tpanel pn on c.panelid= pn.panelid left outer join dc_tp_refdoctors dr on dr.doctorid=m.doctorid left outer join dc_tp_ward w on w.wardid=m.wardid left outer join dc_tp_groupm gm on gm.groupid=m.groupid WHERE pp.prno = '" + PRNO + "' AND m.labid = '" + LabID + "' GROUP BY t.testid  ";
                    break;
                case 36:
                    objdbhims.Query = "SELECT ifnull(d.totalamount-d.paidamount,'None') as discount, c.receiveno,c.labid,ifnull(c.paidamount,0) as paidamount,c.totalamount,d.totalamount as charges,concat(t.test_name,' ',ifnull(cl.name,'')) as testname, concat(pr.salutation,' ',pr.fname,' ',ifnull(mname,''),' ',ifnull(lname,'')) as receivedby,concat(ifnull(pp.title,''),' ',pp.name) as patient, date_format(c.enteredon,'%d/%m/%y %h:%i %p') as receivedon,pp.prno, d.deliverytime ,concat(og.name,' ',og.address) as orgaddress,og.phoneno,date_format(pp.dob,'%d/%m/%Y') as dob,case when pp.gender='M' then 'Male' else 'Female' end as gender,cl.classificationid,d.testid,m.bookingid,m.prid,c.paymentmode,pn.panelid,pn.name as panelname,ifnull(m.authorizeno,'') as authorizeno,ifnull(pp.serviceno,'') as serviceno,case when pp.address is null or pp.address='' then '-' else pp.address end as address,m.enteredon,case when DATEDIFF(CURRENT_DATE,pp.dob) > 365 then      concat(Floor(DATEDIFF(CURRENT_DATE,pp.dob)/365),'(Years)')  else    case when DATEDIFF(CURRENT_DATE,pp.dob) > 30 then      concat(Floor(DATEDIFF(CURRENT_DATE,pp.dob)/30),' (M)')    else      concat(DATEDIFF(CURRENT_DATE,pp.dob),'(D)')    end  end  AS age,case when m.doctorid is null or m.doctorid='' then m.referredby else concat(ifnull(dr.title,''),' ',dr.name) end as consultant,m.discount_amt,ifnull((select sum(ifnull(paidamount,0)) from dc_tcashcollection where bookingid=m.bookingid),0) as totalpaid, pp.cellno,pp.hphone,dr.code,m.referenceno,t.external,t.speedkey,pp.pasword,m.remarks,m.payment_mode as M_Bmode,pn.print_amount,w.name as ward,m.type as ind_outdoor,m.origin_place from dc_tcashcollection c  join dc_tpatient_bookingm m on c.bookingid = m.bookingid left outer join dc_tp_personnel pr on c.enteredby = pr.personid join dc_tpatient_bookingd d on m.bookingid = d.bookingid join dc_tp_test t on d.testid = t.testid left outer join dc_tp_tclass cl  on d.classificationid = cl.classificationid join dc_tpatient pp on m.prid = pp.prid left outer join dc_tp_organization og on m.origin_place = og.orgid left outer join dc_tpanel pn on c.panelid= pn.panelid left outer join dc_tp_refdoctors dr on dr.doctorid=m.doctorid left outer join dc_tp_ward w on w.wardid=m.wardid WHERE pp.prno = '"+PRNO+"' AND d.labid = '"+LabID+"' GROUP BY prid ";
                    break;
                case 37:
                    objdbhims.Query = "SELECT headertitle,location,header_id FROM dc_treceiptheader";
                    break;
                case 38:
                    objdbhims.Query = "SELECT headertitle,location FROM dc_treceiptheader WHERE header_id = '"+_headerid+"' ";
                    break;
                case 39:
                    objdbhims.Query = "SELECT footertitle,location,footer_id FROM dc_treceiptfooter";
                    break;
                case 40: // fill branch test
                    objdbhims.Query = "select distinct '' as groupid,t.SpecialTest,c.classificationid,t.TestInfoReport TestInformation, t.testid,concat(ifnull(su.acronym,''),':',t.test_name,' ',ifnull(c.name,'')) as testname,case when 'N'='" + StrPriority + "' and 'P'='" + StrRate + "' then ifnull(t.charges,0)+ifnull(org.process_fee,0) when 'N'='" + StrPriority + "' and 'C'='" + StrRate + "' then ifnull(t.charityrate,0)+ifnull(org.process_fee,0) else ifnull(chargesurgent,0)+ifnull(org.process_fee,0) end as brtestcharges,'" + StrPriority + "' as priority,concat(ifnull(t.speedkey,''),':') as speedkey,ifnull(mt.maxtime,0) as maxtime,'Y' as print_amount,bt.OfferedPrice as charges,bt.External External,bt.DestinationBranchID DestinationBranch,bt.TATType,bt.TATValue,bt.FranchiseDiscount,bt.TestPrice Branchcost,t.dplan,t.time1,t.time2,t.time3,t.time4,t.dispatchtime1,t.dispatchtime2,t.dispatchtime3,t.dispatchtime4,b.Dplan_InternalTests,ifnull(bt.percentagediscount,0) as brpercentagediscount from dc_tp_test t left outer join dc_tp_tclass c on t.testid=c.testid left outer join dc_tp_test_age ag on t.testid = ag.testid left outer join dc_tp_subdepartments su on t.subdepartmentid=su.subdepartmentid left outer join dc_tp_organization org on t.external_org= org.orgid left outer join dc_tp_tmethod mtt on t.testid=mtt.testid left outer join dc_tp_method mt on mt.methodid=mtt.methodid Inner Join dc_tp_branchtestd bt on bt.TestID=t.TestID inner join dc_tp_branch b on b.BranchID=bt.branchID where t.active='Y' and mtt.m_Default='Y'  ";
                    if (!StrDOB.Equals(Default))
                    {
                        objdbhims.Query += @" and ag.maxage >" + StrDOB + " and ag.minage<=" + StrDOB + " and (ag.gender='" + StrGender + "' or ag.gender='A')";
                    }
                    if (!StrSubDepartmentID.Equals(Default) && !StrSubDepartmentID.Equals("-1"))
                        objdbhims.Query += " and t.subdepartmentid=" + StrSubDepartmentID;
                    if (!StrName.Equals("") && !StrName.Equals(Default))
                        objdbhims.Query += " and t.test_name like '%" + StrName + "%'";
                    if (!StrSpeedKey.Equals(Default) && !StrSpeedKey.Equals(""))
                        objdbhims.Query += " and t.speedkey like '" + StrSpeedKey + "%'";
                    if (StrRate.Equals("C"))
                        objdbhims.Query += " and ifnull(t.charityrate,0) <>0";


                    objdbhims.Query += " and bt.BranchID="+_BranchID+" and bt.Active='Y' order by su.name,t.dorder";
                    break;
                case 41: //fill branch tests w.r.t panel patient
                    objdbhims.Query = @"select distinct '' as GroupID,t.SpecialTest,c.classificationid, t.testid,bt.TestPrice branchcost,t.TEstInfoReport TestInformation,
                                        concat(ifnull(su.acronym,''),':',t.test_name,' ',ifnull(c.name,'')) as testname,
                                        ifnull(pt.rate,0)+ifnull(org.process_fee,0)  as brTestCharges, 'N' as priority,
                                        concat(ifnull(t.speedkey,''),':') as speedkey,ifnull(mt.maxtime,0) as maxtime,
                                        ifnull(pn.print_amount,'N') as print_amount,
                                        bt.DestinationBranchID Destinationbranch,bt.TAtvalue,bt.TatType,bt.Testprice Charges ,bt.External,bt.FranchiseDiscount,
                                        t.dplan,t.time1,t.time2,t.time3,t.time4,t.dispatchtime1,t.dispatchtime2,t.dispatchtime3,t.dispatchtime4,b.Dplan_InternalTests,
                                        ifnull(bt.percentagediscount,0) as brpercentagediscount,ifnull(pt.percentdiscount,0) percentdiscountpanel


                                        from dc_tpanel_test pt left outer Join dc_tp_test t on pt.testid=t.testid
                                        left outer join dc_tp_tclass c on t.testid=c.testid
                                        left outer join dc_tp_test_age ag on t.testid = ag.testid
                                        left outer join dc_tp_subdepartments su on t.subdepartmentid=su.subdepartmentid
                                        left outer join dc_tp_organization org on t.external_org= org.orgid
                                        left outer join dc_tp_tmethod mtt on t.testid=mtt.testid
                                        left outer join dc_tp_method mt on mt.methodid=mtt.methodid
                                        left outer join dc_tpanel pn on pn.panelid=pt.panelid
                                        inner join dc_tp_branchtestd bt on pt.Testid=bt.testid
                                        inner join dc_tp_branch b on b.BranchID=bt.branchID


                                        where t.active='Y' and mtt.m_default='Y' and ag.maxage >" + Convert.ToInt32(StrDOB) + @"
                                        and ag.minage<=" + Convert.ToInt32(StrDOB) + @" and (ag.gender='" + StrGender + @"' or ag.gender='A')

                                        and bt.BranchID=" + Convert.ToInt32(_BranchID) + @" and pt.panelid=" + StrPanelID + @"
                                        and bt.Active='Y'";
                    if (!StrSubDepartmentID.Equals(Default) && !StrSubDepartmentID.Equals("-1"))
                        objdbhims.Query += " and t.subdepartmentid=" + StrSubDepartmentID;
                    if (!StrName.Equals("") && !StrName.Equals(Default))
                        objdbhims.Query += " and t.test_name like '%" + StrName + "%'";
                    if (!StrSpeedKey.Equals(Default) && !StrSpeedKey.Equals(""))
                        objdbhims.Query += " and t.speedkey like '" + StrSpeedKey + "%'";
                    //if (!StrPanelID.Equals(Default) && !StrPanelID.Equals("-1") && !StrPanelID.Equals(""))
                    //        objdbhims.Query += " and pt.panelid=" + StrPanelID ;
                    objdbhims.Query += " order by su.name,t.dorder";
                    break;
                case 42:
                   // objdbhims.Query = "SELECT Name,ifnull(StreetAddress,'Not Available') as address FROM dc_tp_branch d WHERE Active = 'Y'";
                    objdbhims.Query = "SELECT ifnull(b.starttime,'00:00') as starttime,ifnull(b.endtime,'00:00') as endtime,b.printreporttext,ifnull(b.Name,'Bio Care Laborartory') as branchName,b.Report_Text,ifnull(b.StreetAddress,'Not Available') as address,CONCAT('(',b.PhoneNo,')') as phone,ifnull(c.Name,'-') as city FROM dc_tp_branch b , dc_tcity c WHERE c.cityid = b.city AND b.printreporttext='Y' and  b.Active='Y' and (b.Type='F' or b.Type='S') and b.parentid is not null and b.parentid!=-1 and b.branchID in (Select branchID From dc_tp_Personnel where Active='Y')";
                    break;
                case 43:
                    objdbhims.Query = "SELECT ifnull(Extension,'-') as Ext,CONCAT('(',PhoneNo,')') as phone,24HrsService,ifnull(starttime,'00:00') as starttimes,ifnull(endtime,'00:00') as endtimes,ifnull(Name,'Bio Care Laborartory') as branchName,Report_Text,ifnull(StreetAddress,'Not Available') as address FROM dc_tp_branch WHERE BranchID='" + _BranchID + "'";
                    break;
                case 44:
                    objdbhims.Query = "SELECT Test_Name,Instructions_Before,Instructions_After FROM dc_tp_test WHERE testId IN ("+StrTestID+")";
                    break;
                case 45:
                    objdbhims.Query = "SELECT PrintBranches,PrintTestComents,printgeneralcomments,ifnull(GeneralComments,'No Comments available') as coments FROM dc_tp_preferencesettings";
                    break;
                case 46: // fill branch test
                    objdbhims.Query = "select c.classificationid, t.testid,concat(ifnull(su.acronym,''),':',t.test_name,' ',ifnull(c.name,'')) as testname,case when 'N'='" + StrPriority + "' and 'P'='" + StrRate + "' then ifnull(t.charges,0)+ifnull(org.process_fee,0) when 'N'='" + StrPriority + "' and 'C'='" + StrRate + "' then ifnull(t.charityrate,0)+ifnull(org.process_fee,0) else ifnull(chargesurgent,0)+ifnull(org.process_fee,0) end as charges,'" + StrPriority + "' as priority,concat(ifnull(t.speedkey,''),':') as speedkey,ifnull(mt.maxtime,0) as maxtime,'Y' as print_amount,bt.OfferedPrice as brtestcharges,bt.External External,bt.DestinationBranchID DestinationBranch,bt.TATType,bt.TATValue,bt.FranchiseDiscount,bt.TestPrice Branchcost,t.dplan,t.time1,t.time2,t.time3,t.time4,t.dispatchtime1,t.dispatchtime2,t.dispatchtime3,t.dispatchtime4 from dc_tp_test t left outer join dc_tp_tclass c on t.testid=c.testid left outer join dc_tp_test_age ag on t.testid = ag.testid left outer join dc_tp_subdepartments su on t.subdepartmentid=su.subdepartmentid left outer join dc_tp_organization org on t.external_org= org.orgid left outer join dc_tp_method mt on t.d_methodid=mt.methodid Inner Join dc_tp_branchtestd bt on bt.TestID=t.TestID where t.active='Y'  ";
                    if (!StrSubDepartmentID.Equals(Default) && !StrSubDepartmentID.Equals("-1"))
                        objdbhims.Query += " and t.subdepartmentid=" + StrSubDepartmentID;
                    if (!StrName.Equals("") && !StrName.Equals(Default))
                        objdbhims.Query += " and t.test_name like '%" + StrName + "%'";
                    if (!StrSpeedKey.Equals(Default) && !StrSpeedKey.Equals(""))
                        objdbhims.Query += " and t.speedkey like '" + StrSpeedKey + "%'";
                    if (StrRate.Equals("C"))
                        objdbhims.Query += " and ifnull(t.charityrate,0) <>0";


                    objdbhims.Query += " and bt.BranchID=" + _BranchID + " and bt.Active='Y' order by su.name,t.dorder";
                    break;
                case 47://Getting patient EMail Id and mobile number for sending notifications
                    objdbhims.Query = @"SELECT dt.cellno,dt.email,dt.name
                                        FROM dc_tpatient dt WHERE dt.prno='" + StrPRNO + "'";

                    break;
                    //                 old query
                    //select m.bookingid, m.totalamount as charges,concat(ifnull(pp.title,''),' ',
                    //                    pp.name) as patient, pp.prno,

                    //                    date_format(pp.dob,'%d/%m/%Y') as dob,case when pp.gender='M' then 'Male' else 'Female'
                    //                    end as gender,m.bookingid,m.prid,pn.panelid,pn.cashpanel,
                    //                    pn.name as panelname,ifnull(m.authorizeno,'') as authorizeno,ifnull(pp.serviceno,'') as serviceno,
                    //                    case when pp.address is null or pp.address='' then '-' else pp.address end as address,m.enteredon,
                    //                    case when DATEDIFF(CURRENT_DATE,pp.dob) > 365 then      concat(Floor(DATEDIFF(CURRENT_DATE,pp.dob)/365),' (Y)')  else
                    //                     case when DATEDIFF(CURRENT_DATE,pp.dob) > 30 then      concat(Floor(DATEDIFF(CURRENT_DATE,pp.dob)/30),' (M)')    else
                    //                         concat(DATEDIFF(CURRENT_DATE,pp.dob),'(D)')    end  end  AS age,case when m.doctorid is null or m.doctorid=''
                    //                         then m.referredby else concat(ifnull(dr.title,''),' ',dr.name) end as consultant,m.discount_amt,
                    //                         dr.code,m.referenceno,m.payment_mode as M_Bmode,
                    //                         pn.print_amount,ifnull(m.bed,'-') bed ,ifnull(w.name,'-') as ward,case when m.type='I' then 'Indoor' else 'Outdoor' end as ind_outdoor,m.labid,date_format(m.enteredon,'%d %b %Y %r ') as bookedon,
                    //                    m.totalamount,ifnull(m.paidamount,0) as paidamount,ifnull(m.discount_amt,0) as discount_amt
                    //                    , m.totalamount-(ifnull(m.paidamount,0)+ifnull(m.discount_amt,0)) as Balance,m.adm_ref,concat(pp.prno,'(',concat(ifnull(pp.title,''),' ',pp.name),')') as PatientInfo
                    //                    from  dc_tpatient_bookingm m

                    //                    join dc_tpatient pp on m.prid = pp.prid
                    //                    left outer join dc_tpanel pn on m.panelid= pn.panelid
                    //                    left outer join dc_tp_refdoctors dr on dr.doctorid=m.doctorid left outer join dc_tp_ward w on w.wardid=m.wardid

                    //                     where 1=1 and  m.bookingid not in (select bookingid from dc_tcashrefund where refundtype='C' and prid=m.prid)
                case 48:

                    objdbhims.Query = @"select m.bookingid, m.totalamount as charges,concat(ifnull(pp.title,''),' ',
                                        pp.name) as patient, pp.prno,

                                        date_format(pp.dob,'%d/%m/%Y') as dob,case when pp.gender='M' then 'Male' else 'Female'
                                        end as gender,m.bookingid,m.prid,pn.panelid,pn.cashpanel,
                                        pn.name as panelname,ifnull(m.authorizeno,'') as authorizeno,ifnull(pp.serviceno,'') as serviceno,
                                        case when pp.address is null or pp.address='' then '-' else pp.address end as address,m.enteredon,
                                        case when DATEDIFF(CURRENT_DATE,pp.dob) > 365 then      concat(Floor(DATEDIFF(CURRENT_DATE,pp.dob)/365),' (Y)')  else
                                         case when DATEDIFF(CURRENT_DATE,pp.dob) > 30 then      concat(Floor(DATEDIFF(CURRENT_DATE,pp.dob)/30),' (M)')    else
                                             concat(DATEDIFF(CURRENT_DATE,pp.dob),'(D)')    end  end  AS age,case when m.doctorid is null or m.doctorid=''
                                             then m.referredby else concat(ifnull(dr.title,''),' ',dr.name) end as consultant,m.discount_amt,
                                             dr.code,m.referenceno,m.payment_mode as M_Bmode,
                                             pn.print_amount,ifnull(m.bed,'-') bed ,ifnull(w.name,'-') as ward,case when m.type='I' then 'Indoor' else 'Outdoor' end as ind_outdoor,m.labid,date_format(m.enteredon,'%d %b %Y %r ') as bookedon,
                                        (m.totalamount - (select ifnull(sum(totalamount),0) from dc_tcashrefund where bookingid=m.bookingid and refundtype='C')) as totalamount,ifnull(m.paidamount,0) as paidamount,ifnull(m.discount_amt,0) as discount_amt
                                        , (m.totalamount - (select ifnull(sum(totalamount),0) from dc_tcashrefund where bookingid=m.bookingid and refundtype='C')) -(ifnull(m.paidamount,0)+ifnull(m.discount_amt,0)) as Balance,m.adm_ref,concat(pp.prno,'(',concat(ifnull(pp.title,''),' ',pp.name),')') as PatientInfo
                                        from  dc_tpatient_bookingm m
                                        inner join dc_tpatient_bookingd d on d.bookingid=m.bookingid
                                        inner  join dc_tpatient pp on m.prid = pp.prid
                                        inner join dc_tpanel pn on m.panelid= pn.panelid
                                        left outer join dc_tp_refdoctors dr on dr.doctorid=m.doctorid
                         left outer join dc_tp_ward w on w.wardid=m.wardid

                                         where 1=1 and d.status<>'X' ";
                    if (!StrType.Equals(Default))
                    {
                        objdbhims.Query += " and m.Type='" + StrType + "'";
                    }
                    if (!StrPRNO.Equals(Default))
                    {
                        objdbhims.Query += " and pp.prno='" + StrPRNO + "'";
                    }
                    if (!StrReferenceNo.Equals(Default))
                    {
                        objdbhims.Query += " and m.adm_ref='" + StrReferenceNo + "'";
                    }
                    if (!StrLabID.Equals(Default) && !StrLabID.Equals(""))
                    {
                        objdbhims.Query += " and m.labid='" + StrLabID + "'";
                    }
                    if (!DateFrom.Equals(Default) && !DateFrom.Equals(""))
                    {
                        objdbhims.Query += " and m.enteredon between str_to_Date('" + _DateFrom + "','%d/%m/%Y') and str_to_date('" + _DateTo + "','%d/%m/%Y')";
                    }
                    if (!_BranchID.Equals(Default) && !_BranchID.Equals(""))
                    {
                        objdbhims.Query += " and m.branchid="+_BranchID;// between str_to_Date('" + _DateFrom + "','%d/%m/%Y') and str_to_date('" + _DateTo + "','%d/%m/%Y')";
                    }
                    if (!StrPanelID.Equals(Default) && !StrPanelID.Equals(""))
                    {
                        objdbhims.Query += " and m.panelid="+StrPanelID;// between str_to_Date('" + _DateFrom + "','%d/%m/%Y') and str_to_date('" + _DateTo + "','%d/%m/%Y')";
                    }
                    objdbhims.Query += " group by m.bookingid order by m.bookingid asc";

                    break;
                case 49:
                    objdbhims.Query = @" Select d.bookingid,t.test_name,d.totalamount as charges,(100-ifnull(pt.panelsharepercent,0))*d.totalamount/100 as LabShare,ifnull(d.branchdiscount,bt.PercentageDiscount)*d.totalamount/100 as BranchShare
                                        From dc_tpatient_bookingm m inner join dc_tpatient_bookingd d on m.bookingid=d.bookingid inner join dc_tp_test t on t.testid=d.testid
inner join dc_tpanel_test pt on pt.testid=d.testid and pt.panelid=m.panelid

inner join dc_tpanel p on p.panelid=m.panelid
inner join dc_tp_branchtestd bt on bt.branchid=m.branchid
and bt.testid=d.testid
and bt.Active='Y'

where d.status<>'X' and d.bookingid="+StrBookingID+@"
and case when m.groupid is null then pt.groupid is null else pt.groupid=m.groupid end";
                    break;
                case 50:
                    objdbhims.Query = @"select c.receiveno,c.labid,ifnull(c.paidamount,0) as paidamount,c.totalamount,
                                        d.totalamount as charges,concat(t.test_name,' ',ifnull(cl.name,'')) as testname,
                                        concat(pr.salutation,' ',pr.fname,' ',ifnull(mname,''),' ',ifnull(lname,'')) as receivedby,
                                        concat(ifnull(pp.title,''),' ',pp.name) as patient,
                                        date_format(c.enteredon,'%d/%m/%y %h:%i %p') as receivedon,pp.prno,
                                        d.deliverytime,
                                        DATE_FORMAT(DATE_ADD(DATE_FORMAT(d.deliverytime, '%Y-%m-%d %H:00:00'),INTERVAL IF(MINUTE(d.deliverytime) < 30, 0, 1)  HOUR),'%d-%m-%Y %H:00:00') AS deliverydatetime,
                                        DATE_FORMAT(d.deliverytime,'%d-%m-%Y') AS deliverydate,
                                        DATE_FORMAT(d.deliverytime,'%H:00') AS deliverytimes,
                                        concat(og.name,'',og.address) as orgaddress,og.phoneno,date_format(pp.dob,'%d/%m/%Y') as dob,case when pp.gender='M' then 'Male' else 'Female' end as gender,cl.classificationid,d.testid,m.bookingid,m.prid,c.paymentmode,pn.panelid,pn.name as panelname,ifnull(m.authorizeno,'') as authorizeno,ifnull(pp.serviceno,'') as serviceno,case when pp.address is null or pp.address='' then '-' else pp.address end as address,m.enteredon,case when DATEDIFF(CURRENT_DATE,pp.dob) > 365 then      concat(Floor(DATEDIFF(CURRENT_DATE,pp.dob)/365),'(Years)')  else    case when DATEDIFF(CURRENT_DATE,pp.dob) > 30 then      concat(Floor(DATEDIFF(CURRENT_DATE,pp.dob)/30),' (M)')    else      concat(DATEDIFF(CURRENT_DATE,pp.dob),'(D)')    end  end  AS age,case when m.doctorid is null or m.doctorid='' then m.referredby else concat(ifnull(dr.title,''),' ',dr.name) end as consultant,m.discount_amt,ifnull((select sum(ifnull(paidamount,0)) from dc_tcashcollection where bookingid=m.bookingid),0) as totalpaid, pp.cellno,pp.hphone,dr.code,m.referenceno,t.external,t.speedkey,pp.pasword,m.remarks,m.payment_mode as M_Bmode,pn.print_amount,w.name as ward,m.type as ind_outdoor,m.origin_place from dc_tcashcollection c  join dc_tpatient_bookingm m on c.bookingid = m.bookingid left outer join dc_tp_personnel pr on c.enteredby = pr.personid join dc_tpatient_bookingd d on m.bookingid = d.bookingid join dc_tp_test t on d.testid = t.testid left outer join dc_tp_tclass cl  on d.classificationid = cl.classificationid join dc_tpatient pp on m.prid = pp.prid left outer join dc_tp_organization og on m.origin_place = og.orgid left outer join dc_tpanel pn on c.panelid= pn.panelid left outer join dc_tp_refdoctors dr on dr.doctorid=m.doctorid left outer join dc_tp_ward w on w.wardid=m.wardid
                                        WHERE pp.prno = '" + StrPRNO + "' AND m.labid = '" + StrLabID + "' GROUP BY t.testid";
                    break;
                case 51:
                    objdbhims.Query = @"SELECT p.prid,p.prno,p.name PatientName,d.labid,d.Cancelled,
concat(ifnull(pp.Fname,''), ' ' ,ifnull(pp.Mname,''),' ',ifnull(pp.Lname,'')) as FinalizedBy,
case when d.Cancelled='Y' then concat('<font color=''blue''>',p.Name, '</font> request Rejected by <font color=''blue''>',concat(ifnull(pp.Fname,''), ' ' ,ifnull(pp.Mname,''),' ',ifnull(pp.Lname,'')),'</font>')
 when d.Cancelled='N' then concat('<font color=''blue''>',p.Name, '</font> request Approved by <font color=''blue''>',concat(ifnull(pp.Fname,''), ' ' ,ifnull(pp.Mname,''),' ',ifnull(pp.Lname,'')),'</font>') end as status,d.bookingid
FROM dc_tpatient_bookingm_temp d inner join dc_tpatient p on p.prid=d.prid
inner join dc_tp_personnel pp on pp.personid=d.finalizedby
where d.Cancelled IS NOT NULL and d.Cancelled<>'X' and d.finalizedon>=date_sub(sysdate(),interval 1 day)";
                    break;
                case 52:
                    objdbhims.Query = @"select m.bookingid,d.testid,m.referredby,d.totalamount testprice,m.prid,ifnull(m.doctorid,'') doctorid,m.totalamount,
(d.totalamount-(d.totalamount*ifnull(d.percentdiscountcash,0)/100)) testdiscountedprice,
m.specimen_Internal,m.type,d.status,m.deliveryby,ifnull(d.percentdiscountcash,0) percentdiscountcash,
ifnull(m.Remarks,'') Remarks,d.testid,ifnull(d.classificationid,'') classificationid,
d.Priority,d.destinationbranchid,ifnull(d.percentdiscountcash,0) percentdiscountcash,m.payment_mode,
p.prno,m.referenceno
from dc_tpatient_bookingm_temp m
inner join dc_tpatient_bookingd_temp d on d.bookingid=m.bookingid
inner join dc_tpatient p on p.prid=m.prid
where m.bookingid=" + StrBookingID;
                    break;
                case 53:
                    objdbhims.Query = @"Select prno,prid from dc_tpatient where cliq_Dependent_id=" + _dependent_cliq_id;
                    break;
                case 54:
                    objdbhims.Query = @"Select External,DestinationBranchid from dc_tp_branchtestd where Active='Y' and  Branchid=" + _BranchID + " and TestID=" + StrTestID;
                    break;
                case 55:
                    objdbhims.Query = @"select p.email,m.labid,p.prid from
dc_tpatient p inner join dc_tpatient_bookingm m on m.prid=p.prid
where m.bookingid=" + StrBookingID;
                    break;
                case 56:
                    objdbhims.Query=@"Select d.bookingid,t.test_name,d.totalamount as charges,ifnull(d.branchdiscount,bt.PercentageDiscount)*d.totalamount/100 as BranchShare
                                        From dc_tpatient_bookingm m inner join dc_tpatient_bookingd d on m.bookingid=d.bookingid inner join dc_tp_test t on t.testid=d.testid
inner join dc_tp_branchtestd bt on bt.branchid=m.branchid
and bt.testid=d.testid
and bt.Active='Y'

where d.bookingid="+StrBookingID;
                    break;
                case 57:
                    objdbhims.Query = @"select cashpanel from dc_tpanel where panelid="+StrPanelID;
                    break;

            }
            return objTrans.DataTrigger_Get_All(objdbhims);
        }
        public DataView GetAll_Async(int flag)
        {
            switch (flag)
            {
                
                case 40: // fill branch test
                    objdbhims.Query = "select distinct '' as groupid,t.SpecialTest,c.classificationid,t.TestInfoReport TestInformation, t.testid,concat(ifnull(su.acronym,''),':',t.test_name,' ',ifnull(c.name,'')) as testname,case when 'N'='" + StrPriority + "' and 'P'='" + StrRate + "' then ifnull(t.charges,0)+ifnull(org.process_fee,0) when 'N'='" + StrPriority + "' and 'C'='" + StrRate + "' then ifnull(t.charityrate,0)+ifnull(org.process_fee,0) else ifnull(chargesurgent,0)+ifnull(org.process_fee,0) end as brtestcharges,'" + StrPriority + "' as priority,concat(ifnull(t.speedkey,''),':') as speedkey,ifnull(mt.maxtime,0) as maxtime,'Y' as print_amount,bt.OfferedPrice as charges,bt.External External,bt.DestinationBranchID DestinationBranch,bt.TATType,bt.TATValue,bt.FranchiseDiscount,bt.TestPrice Branchcost,t.dplan,t.time1,t.time2,t.time3,t.time4,t.dispatchtime1,t.dispatchtime2,t.dispatchtime3,t.dispatchtime4,b.Dplan_InternalTests,ifnull(bt.percentagediscount,0) as brpercentagediscount from dc_tp_test t left outer join dc_tp_tclass c on t.testid=c.testid left outer join dc_tp_test_age ag on t.testid = ag.testid left outer join dc_tp_subdepartments su on t.subdepartmentid=su.subdepartmentid left outer join dc_tp_organization org on t.external_org= org.orgid left outer join dc_tp_tmethod mtt on t.testid=mtt.testid left outer join dc_tp_method mt on mt.methodid=mtt.methodid Inner Join dc_tp_branchtestd bt on bt.TestID=t.TestID inner join dc_tp_branch b on b.BranchID=bt.branchID where t.active='Y' and mtt.m_Default='Y'  ";
                    if (!StrDOB.Equals(Default))
                    {
                        objdbhims.Query += @" and ag.maxage >" + StrDOB + " and ag.minage<=" + StrDOB + " and (ag.gender='" + StrGender + "' or ag.gender='A')";
                    }
                    if (!StrSubDepartmentID.Equals(Default) && !StrSubDepartmentID.Equals("-1"))
                        objdbhims.Query += " and t.subdepartmentid=" + StrSubDepartmentID;
                    if (!StrName.Equals("") && !StrName.Equals(Default))
                        objdbhims.Query += " and t.test_name like '%" + StrName + "%'";
                    if (!StrSpeedKey.Equals(Default) && !StrSpeedKey.Equals(""))
                        objdbhims.Query += " and t.speedkey like '" + StrSpeedKey + "%'";
                    if (StrRate.Equals("C"))
                        objdbhims.Query += " and ifnull(t.charityrate,0) <>0";


                    objdbhims.Query += " and bt.BranchID=" + _BranchID + " and bt.Active='Y' order by su.name,t.dorder";
                    break;
                case 41: //fill branch tests w.r.t panel patient
                    objdbhims.Query = @"select distinct '' as GroupID,t.SpecialTest,c.classificationid, t.testid,bt.TestPrice branchcost,t.TEstInfoReport TestInformation,
                                        concat(ifnull(su.acronym,''),':',t.test_name,' ',ifnull(c.name,'')) as testname,
                                        ifnull(pt.rate,0)+ifnull(org.process_fee,0)  as brTestCharges, 'N' as priority,
                                        concat(ifnull(t.speedkey,''),':') as speedkey,ifnull(mt.maxtime,0) as maxtime,
                                        ifnull(pn.print_amount,'N') as print_amount,
                                        bt.DestinationBranchID Destinationbranch,bt.TAtvalue,bt.TatType,bt.Testprice Charges ,bt.External,bt.FranchiseDiscount,
                                        t.dplan,t.time1,t.time2,t.time3,t.time4,t.dispatchtime1,t.dispatchtime2,t.dispatchtime3,t.dispatchtime4,b.Dplan_InternalTests,
                                        ifnull(bt.percentagediscount,0) as brpercentagediscount,ifnull(pt.percentdiscount,0) percentdiscountpanel


                                        from dc_tpanel_test pt left outer Join dc_tp_test t on pt.testid=t.testid
                                        left outer join dc_tp_tclass c on t.testid=c.testid
                                        left outer join dc_tp_test_age ag on t.testid = ag.testid
                                        left outer join dc_tp_subdepartments su on t.subdepartmentid=su.subdepartmentid
                                        left outer join dc_tp_organization org on t.external_org= org.orgid
                                        left outer join dc_tp_tmethod mtt on t.testid=mtt.testid
                                        left outer join dc_tp_method mt on mt.methodid=mtt.methodid
                                        left outer join dc_tpanel pn on pn.panelid=pt.panelid
                                        inner join dc_tp_branchtestd bt on pt.Testid=bt.testid
                                        inner join dc_tp_branch b on b.BranchID=bt.branchID


                                        where t.active='Y' and mtt.m_default='Y' and ag.maxage >" + Convert.ToInt32(StrDOB) + @"
                                        and ag.minage<=" + Convert.ToInt32(StrDOB) + @" and (ag.gender='" + StrGender + @"' or ag.gender='A')

                                        and bt.BranchID=" + Convert.ToInt32(_BranchID) + @" and pt.panelid=" + StrPanelID + @"
                                        and bt.Active='Y'";
                    if (!StrSubDepartmentID.Equals(Default) && !StrSubDepartmentID.Equals("-1"))
                        objdbhims.Query += " and t.subdepartmentid=" + StrSubDepartmentID;
                    if (!StrName.Equals("") && !StrName.Equals(Default))
                        objdbhims.Query += " and t.test_name like '%" + StrName + "%'";
                    if (!StrSpeedKey.Equals(Default) && !StrSpeedKey.Equals(""))
                        objdbhims.Query += " and t.speedkey like '" + StrSpeedKey + "%'";
                    //if (!StrPanelID.Equals(Default) && !StrPanelID.Equals("-1") && !StrPanelID.Equals(""))
                    //        objdbhims.Query += " and pt.panelid=" + StrPanelID ;
                    objdbhims.Query += " order by su.name,t.dorder";
                    break;
                

            }
            return objTrans.DataTrigger_Get_All_Async(objdbhims);
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
        public bool Bookingd_Update()
        {
           
                QueryBuilder objQB = new QueryBuilder();

                objTrans.Start_Transaction();

                objdbhims.Query = objQB.QBUpdate(MakeArray_Booking_D(), "dc_tpatient_bookingd");
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
        public bool Update_status_onprint()
        {

           

            objTrans.Start_Transaction();

            objdbhims.Query = "Update dc_tpatient_bookingd set processid=" + ProcessID + " where bookingid=" + StrBookingID+" and processid>6";
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
                        if (str[i, 7] != "null" && str[i, 7] != "")
                        {
                            _percentdiscountpanel = str[i, 7];//Further discount for panel patients
                        }


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
                            //StrDelivery_Time = ts.ToString("dd/MM/yyyy hh:mm:ss tt");
                            ///////////////////////////----Mere Pange------///////////////////////////
                            objdbhims.Query = "Select External,DestinationBranchID,TATtype,TATValue From dc_tp_BranchTestD where TestId=" + StrTestID + " and BranchID=" + Session["BranchID"].ToString().Trim() + " and Active='Y'";
                            DataView dv_exinfo = objTrans.DataTrigger_Get_All(objdbhims);
                            if (dv_exinfo.Count > 0)
                            {
                                if (dv_exinfo[0]["External"].ToString().Trim() == "Y")
                                {
                                    if (dv_exinfo[0]["TATtype"].ToString().Trim() == "H")
                                    {
                                        ts = ts.AddHours(Convert.ToDouble(dv_exinfo[0]["TATValue"].ToString()));
                                    }
                                    else if (dv_exinfo[0]["TATtype"].ToString().Trim() == "D")
                                    {
                                        ts = ts.AddDays(Convert.ToDouble(dv_exinfo[0]["TATValue"].ToString()));
                                    }
                                    else if (dv_exinfo[0]["TATtype"].ToString().Trim() == "W")
                                    {
                                        ts = ts.AddDays(7 * Convert.ToDouble(dv_exinfo[0]["TATValue"].ToString()));
                                    }
                                }
                                dv_exinfo.Dispose();

                            }
                            ///////////////////////////////--------//////////////////////////////////

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
            try
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
                            _DestinationBranchID = str[i, 8];
                            if (str[i, 9] != "null" && str[i, 9] != "")
                            {
                                _percentdiscountpanel = str[i, 9];//Further discount for panel patients
                            }
                            if (str[i, 10] != "" && str[i, 10] != Default)
                            {
                                _percentdiscountcash = str[i, 10];
                                _paidamountsingle = str[i, 11];
                            }
                            _brpercentagediscount = str[i, 12];
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

                            if (WebConfigurationManager.AppSettings["clientid"].Trim() == "006")
							{
                            objdbhims.Query = "SELECT d.maxtime FROM dc_tp_method d join dc_Tp_tmethod tm on tm.methodid=d.methodid  join dc_tp_test t  on tm.testid = t.testid where t.testid=" + StrTestID + " and tm.m_default='Y'";
                            if (Session["default_route"].ToString().Equals("006"))
                                objdbhims.Query += " and (case when ifnull(t.external_org,'006') ='006' then tm.clientid='006' when  t.external_org = '008'  then tm.clientid ='008' else tm.clientid='006'  end)";
                            if (Session["default_route"].ToString().Equals("008"))
                                objdbhims.Query += " and (case when ifnull(t.external_org,'008') ='008' then tm.clientid='008' when  t.external_org = '006'  then tm.clientid ='006' else tm.clientid='006' end)";
                            }
							else
							{
							objdbhims.Query = "SELECT d.maxtime FROM dc_tp_method d join dc_Tp_tmethod tm on tm.methodid=d.methodid  join dc_tp_test t  on tm.testid = t.testid where t.testid=" + StrTestID + " and tm.m_default='Y' and tm.ClientID='"+StrOrgID+"'";
                            //if (Session["default_route"].ToString().Equals("006"))
                            //    objdbhims.Query += " and (case when ifnull(t.external_org,'006') ='006' then tm.clientid='006' when  t.external_org = '008'  then tm.clientid ='008' else tm.clientid='006'  end)";
                            //if (Session["default_route"].ToString().Equals("008"))
                            //    objdbhims.Query += " and (case when ifnull(t.external_org,'008') ='008' then tm.clientid='008' when  t.external_org = '006'  then tm.clientid ='006' else tm.clientid='006' end)";
                            //objdbhims.Query = "SELECT d.maxtime FROM dc_tp_method d left outer join dc_tp_test t  on d.methodid = t.d_methodid where t.testid=" + StrTestID + "";
                            
							}
							dv = this.objTrans.Transaction_Get_Single(objdbhims);
                            if (dv.Count > 0 && Convert.ToInt32(dv[0]["maxtime"]) > 0)
                            {
                                double dtMtd = Convert.ToDouble(dv[0]["maxtime"].ToString());

                                DateTime ts = dtNow.AddMinutes(dtMtd);
                                DateTime fin_date = new DateTime();
                                // StrDelivery_Time = ts.ToString("dd/MM/yyyy hh:mm:ss tt");
                                ////////////////////////////------Mere Pange------//////////////////////
                                objdbhims.Query = "Select External,DestinationBranchID,TATtype,TATValue From dc_tp_BranchTestD where TestId=" + StrTestID + " and BranchID=" + Session["BranchID"].ToString().Trim() + " and Active='Y'";
                                DataView dv_exinfo = objTrans.DataTrigger_Get_All(objdbhims);
                                if (dv_exinfo.Count > 0)
                                {
                                    if (dv_exinfo[0]["External"].ToString().Trim() == "Y")
                                    {
                                        if (dv_exinfo[0]["TATtype"].ToString().Trim() == "H")
                                        {
                                            ts = ts.AddHours(Convert.ToDouble(dv_exinfo[0]["TATValue"].ToString()));
                                        }
                                        else if (dv_exinfo[0]["TATtype"].ToString().Trim() == "D")
                                        {
                                            ts = ts.AddDays(Convert.ToDouble(dv_exinfo[0]["TATValue"].ToString()));
                                        }
                                        else if (dv_exinfo[0]["TATtype"].ToString().Trim() == "W")
                                        {
                                            ts = ts.AddDays(7 * Convert.ToDouble(dv_exinfo[0]["TATValue"].ToString()));
                                        }
                                    }
                                    dv_exinfo.Dispose();

                                }

                                #region Controlling Delivery dates with Branch Timings
                                clsBLBranch obj_br = new clsBLBranch();
                                obj_br.BranchID = Session["BranchID"].ToString().Trim();
                                DataView dv_br = obj_br.GetAll(2);
                                if (dv_br[0]["24HrsService"].ToString().Trim() == "N")
                                {
                                    if (ts.TimeOfDay > new TimeSpan(Convert.ToInt16(dv_br[0]["endtime"].ToString().Substring(0, 2)), Convert.ToInt16(dv_br[0]["endtime"].ToString().Substring(3, 2)), 0))
                                    {
                                        ts = ts.AddDays(1);
                                        ts = DateTime.Parse(ts.ToString("dd/MM/yyyy ") + dv_br[0]["starttime"].ToString(), new CultureInfo("ur-PK", false));

                                    }
                                    else if (ts.TimeOfDay < new TimeSpan(Convert.ToInt16(dv_br[0]["starttime"].ToString().Substring(0, 2)), Convert.ToInt16(dv_br[0]["starttime"].ToString().Substring(3, 2)), 0))
                                    {
                                        ts = DateTime.Parse(ts.ToString("dd/MM/yyyy ") + dv_br[0]["starttime"].ToString(), new CultureInfo("ur-PK", false));
                                    }
                                }
                                dv_br.Dispose();
                                obj_br = null;
                                #endregion

                                //////////////////////////////////-------///////////////////////////
                                ts = chkholiday(ts);
                                #region gazzeted holidays old code
                                //clsBLGazzetedHolidays obj_holidays = new clsBLGazzetedHolidays();
                                //obj_holidays.Active = "Y";
                                //int count_per_holidays = 0;
                                //int count_sea_holidays = 0;
                                //DateTime last_Seasonal = new DateTime();
                                //DataView dv_holidays = obj_holidays.GetAll(1);
                                //if (dv_holidays.Count > 0)
                                //{
                                //    for (int j = 0; j < dv_holidays.Count; j++)
                                //    {
                                //        if (dv_holidays[j]["Type"].ToString().Trim() == "P")
                                //        {
                                //            if (dv_holidays[j]["Date_From"].ToString().Substring(0, 5) == ts.ToString("dd/MM/yyyy").Substring(0, 5))
                                //            {
                                //                ts = ts.AddDays(1);
                                //                count_per_holidays++;
                                //            }
                                //        }
                                //        else if (dv_holidays[j]["Type"].ToString().Trim() == "S")
                                //        {
                                //            int noofholidays = Convert.ToInt16((DateTime.Parse(dv_holidays[j]["Date_To"].ToString().Trim(), new CultureInfo("en-GB", false)) - DateTime.Parse(dv_holidays[j]["Date_From"].ToString().Trim(), new CultureInfo("en-GB", false))).TotalDays);
                                //            for (int k = 0; k <= noofholidays; k++)
                                //            {
                                //                DateTime dtee = DateTime.Parse(dv_holidays[j]["Date_From"].ToString().Trim(), new CultureInfo("en-GB", false));
                                //                dtee = dtee.AddDays(k);

                                //                if (dtee.Date > System.DateTime.Now.Date && dtee.Date <= ts.Date)//dtee.ToString("dd/MM/yyyy") == ts.ToString("dd/MM/yyyy")
                                //                {
                                //                    count_sea_holidays++;

                                //                    //ts = (DateTime.Parse(dv_holidays[j]["Date_To"].ToString().Trim(), new CultureInfo("en-GB", false))).AddDays(k+1);
                                //                    //break;
                                //                }
                                //            }
                                //            last_Seasonal = DateTime.Parse(dv_holidays[j]["Date_To"].ToString().Trim(), new CultureInfo("en-GB", false));
                                //        }

                                //    }
                                //    if (count_sea_holidays - count_per_holidays > 0)
                                //    {
                                //        ts = last_Seasonal.AddDays(count_sea_holidays - count_per_holidays);
                                //    }
                                //}
                                #endregion


                                ///////////////////////////////////////////////////////////////////////////////////////////////////////
                                objdbhims.Query = @"Select dplan,time1,dispatchtime1,time2,dispatchtime2,time3,dispatchtime3,time4,dispatchtime4 From dc_tp_test where TestID=" + StrTestID + " and Active='Y'";
                                DataView dv_dplan = objTrans.DataTrigger_Get_All(objdbhims);
                                if (dv_dplan.Count > 0)
                                {
                                    if (dv_dplan[0]["dplan"].ToString().Trim() == "Y")
                                    {
                                        int flag = 0;
                                        if (!dv_dplan[0]["time1"].ToString().Trim().Equals(""))
                                        {
                                            if (DateTime.Parse(System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"), new CultureInfo("en-GB", false)) <= DateTime.Parse(System.DateTime.Now.ToString("dd/MM/yyyy") + " " + dv_dplan[0]["time1"].ToString().Trim(), new CultureInfo("en-GB", false)) && flag==0)
                                            {
                                                StrDelivery_Time = (DateTime.Parse(System.DateTime.Now.ToString("dd/MM/yyyy") + " " + dv_dplan[0]["dispatchtime1"].ToString().Trim(), new CultureInfo("en-GB", false))).ToString("dd/MM/yyyy hh:mm:ss tt");
                                                flag = 1;
                                            }
                                        }

                                        if (!dv_dplan[0]["time2"].ToString().Trim().Equals(""))
                                        {
                                            if (DateTime.Parse(System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"), new CultureInfo("en-GB", false)) <= DateTime.Parse(System.DateTime.Now.ToString("dd/MM/yyyy") + " " + dv_dplan[0]["time2"].ToString().Trim(), new CultureInfo("en-GB", false)) && flag==0)
                                            {
                                                StrDelivery_Time = (DateTime.Parse(System.DateTime.Now.ToString("dd/MM/yyyy") + " " + dv_dplan[0]["dispatchtime2"].ToString().Trim(), new CultureInfo("en-GB", false))).ToString("dd/MM/yyyy hh:mm:ss tt");
                                                flag = 1;
                                            }
                                        }
                                        if (!dv_dplan[0]["time3"].ToString().Trim().Equals(""))
                                        {
                                            if (DateTime.Parse(System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"), new CultureInfo("en-GB", false)) <= DateTime.Parse(System.DateTime.Now.ToString("dd/MM/yyyy") + " " + dv_dplan[0]["time3"].ToString().Trim(), new CultureInfo("en-GB", false)) && flag==0)
                                            {
                                                StrDelivery_Time = (DateTime.Parse(System.DateTime.Now.ToString("dd/MM/yyyy") + " " + dv_dplan[0]["dispatchtime3"].ToString().Trim(), new CultureInfo("en-GB", false))).ToString("dd/MM/yyyy hh:mm:ss tt");
                                                flag = 1;
                                            }
                                        }
                                        if (!dv_dplan[0]["time4"].ToString().Trim().Equals(""))
                                        {
                                            if (DateTime.Parse(System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"), new CultureInfo("en-GB", false)) <= DateTime.Parse(System.DateTime.Now.ToString("dd/MM/yyyy") + " " + dv_dplan[0]["time4"].ToString().Trim(), new CultureInfo("en-GB", false)) && flag==0)
                                            {
                                                StrDelivery_Time = (DateTime.Parse(System.DateTime.Now.ToString("dd/MM/yyyy") + " " + dv_dplan[0]["dispatchtime4"].ToString().Trim(), new CultureInfo("en-GB", false))).ToString("dd/MM/yyyy hh:mm:ss tt");
                                                flag = 1;
                                            }
                                        }
                                        if (flag == 0)
                                        {
                                            DateTime dtime = chkholiday(System.DateTime.Now.AddDays(1));
                                            StrDelivery_Time = (DateTime.Parse(dtime.ToString("dd/MM/yyyy") + " " + dv_dplan[0]["dispatchtime1"].ToString().Trim(),new CultureInfo("en-GB",false))).ToString("dd/MM/yyyy hh:mm:ss tt");
                                        }
                                    }
                                    else
                                    {
                                        StrDelivery_Time = ts.ToString("dd/MM/yyyy hh:mm:ss tt");




                                        if (WebConfigurationManager.AppSettings["clientid"].ToString().Equals("006"))
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
                                            objdbhims.Query = "insert into dc_tint_coment (bookingid,testid,description,active,process,for_process,enteredon,enteredby,clientid) values (" + StrBookingID + "," + StrTestID + ",'" + StrInt_Comment + "','Y',10," + StrFor_Process + ",str_to_date('" + StrEnteredOn + "','%d/%m/%Y %h:%i:%s %p')," + StrEnteredBy + ",'" + StrClientID + "')";
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
                                                try
                                                {
                                                    objTrans.End_Transaction();
                                                }
                                                catch { }
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
                                        try
                                        {
                                            objTrans.End_Transaction();
                                        }
                                        catch { }
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

            catch 
            {
                StrError = "Exception caught: " + objTrans.OperationError;
                return false;

            }


        }

        public bool Booking_Cash_Insert_temp(string[,] str)
        {
            try
            {
                QueryBuilder objQB = new QueryBuilder();

                objTrans.Start_Transaction();

                objdbhims.Query = "SELECT lpad(ifnull(max(substr(e.labid,9,8)),0)+1,8,0) as maxid FROM dc_tpatient_bookingm_temp e where substr(e.labid,1,3)= concat('T',date_format(current_date,'%y')) and substr(e.labid,5,3)='" + StrBranchID + "'";
                StrLabID = objTrans.DataTrigger_Get_Max(objdbhims);

                if (!StrLabID.Equals("True"))
                {
                    StrLabID = "T"+System.DateTime.Now.ToString("yy") + "-" + StrBranchID + "-" + StrLabID;
                    objdbhims.Query = objQB.QBInsert(MakeArray_Booking_MTemp(), "dc_tpatient_bookingm_temp");
                    StrError = objTrans.DataTrigger_Insert(objdbhims);

                    if (!StrError.Equals("True"))
                    {
                        DataView dvBkID;
                        objdbhims.Query = "select bookingid from dc_tpatient_bookingm_temp where labid='" + StrLabID + "'";
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
                            _DestinationBranchID = str[i, 8];
                            if (str[i, 9] != "null" && str[i, 9] != "")
                            {
                                _percentdiscountpanel = str[i, 9];//Further discount for panel patients
                            }
                            if (str[i, 10] != "" && str[i, 10] != Default)
                            {
                                _percentdiscountcash = str[i, 10];
                                _paidamountsingle = str[i, 11];
                            }
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

                            objdbhims.Query = "SELECT d.maxtime FROM dc_tp_method d join dc_Tp_tmethod tm on tm.methodid=d.methodid  join dc_tp_test t  on tm.testid = t.testid where t.testid=" + StrTestID + " and tm.m_default='Y' and tm.ClientID='" + StrOrgID + "'";
                            //if (Session["default_route"].ToString().Equals("006"))
                            //    objdbhims.Query += " and (case when ifnull(t.external_org,'006') ='006' then tm.clientid='006' when  t.external_org = '008'  then tm.clientid ='008' else tm.clientid='006'  end)";
                            //if (Session["default_route"].ToString().Equals("008"))
                            //    objdbhims.Query += " and (case when ifnull(t.external_org,'008') ='008' then tm.clientid='008' when  t.external_org = '006'  then tm.clientid ='006' else tm.clientid='006' end)";
                            //objdbhims.Query = "SELECT d.maxtime FROM dc_tp_method d left outer join dc_tp_test t  on d.methodid = t.d_methodid where t.testid=" + StrTestID + "";
                            dv = this.objTrans.Transaction_Get_Single(objdbhims);
                            if (dv.Count > 0 && Convert.ToInt32(dv[0]["maxtime"]) > 0)
                            {
                                double dtMtd = Convert.ToDouble(dv[0]["maxtime"].ToString());

                                DateTime ts = dtNow.AddMinutes(dtMtd);
                                DateTime fin_date = new DateTime();
                                // StrDelivery_Time = ts.ToString("dd/MM/yyyy hh:mm:ss tt");
                                ////////////////////////////------Mere Pange------//////////////////////
                                objdbhims.Query = "Select External,DestinationBranchID,TATtype,TATValue From dc_tp_BranchTestD where TestId=" + StrTestID + " and BranchID=" + Session["BranchID"].ToString().Trim() + " and Active='Y'";
                                DataView dv_exinfo = objTrans.DataTrigger_Get_All(objdbhims);
                                if (dv_exinfo.Count > 0)
                                {
                                    if (dv_exinfo[0]["External"].ToString().Trim() == "Y")
                                    {
                                        if (dv_exinfo[0]["TATtype"].ToString().Trim() == "H")
                                        {
                                            ts = ts.AddHours(Convert.ToDouble(dv_exinfo[0]["TATValue"].ToString()));
                                        }
                                        else if (dv_exinfo[0]["TATtype"].ToString().Trim() == "D")
                                        {
                                            ts = ts.AddDays(Convert.ToDouble(dv_exinfo[0]["TATValue"].ToString()));
                                        }
                                        else if (dv_exinfo[0]["TATtype"].ToString().Trim() == "W")
                                        {
                                            ts = ts.AddDays(7 * Convert.ToDouble(dv_exinfo[0]["TATValue"].ToString()));
                                        }
                                    }
                                    dv_exinfo.Dispose();

                                }

                                #region Controlling Delivery dates with Branch Timings
                                clsBLBranch obj_br = new clsBLBranch();
                                obj_br.BranchID = Session["BranchID"].ToString().Trim();
                                DataView dv_br = obj_br.GetAll(2);
                                if (dv_br[0]["24HrsService"].ToString().Trim() == "N")
                                {
                                    if (ts.TimeOfDay > new TimeSpan(Convert.ToInt16(dv_br[0]["endtime"].ToString().Substring(0, 2)), Convert.ToInt16(dv_br[0]["endtime"].ToString().Substring(3, 2)), 0))
                                    {
                                        ts = ts.AddDays(1);
                                        ts = DateTime.Parse(ts.ToString("dd/MM/yyyy ") + dv_br[0]["starttime"].ToString(), new CultureInfo("ur-PK", false));

                                    }
                                    else if (ts.TimeOfDay < new TimeSpan(Convert.ToInt16(dv_br[0]["starttime"].ToString().Substring(0, 2)), Convert.ToInt16(dv_br[0]["starttime"].ToString().Substring(3, 2)), 0))
                                    {
                                        ts = DateTime.Parse(ts.ToString("dd/MM/yyyy ") + dv_br[0]["starttime"].ToString(), new CultureInfo("ur-PK", false));
                                    }
                                }
                                dv_br.Dispose();
                                obj_br = null;
                                #endregion

                                //////////////////////////////////-------///////////////////////////
                                ts = chkholiday(ts);
                                #region gazzeted holidays old code
                                //clsBLGazzetedHolidays obj_holidays = new clsBLGazzetedHolidays();
                                //obj_holidays.Active = "Y";
                                //int count_per_holidays = 0;
                                //int count_sea_holidays = 0;
                                //DateTime last_Seasonal = new DateTime();
                                //DataView dv_holidays = obj_holidays.GetAll(1);
                                //if (dv_holidays.Count > 0)
                                //{
                                //    for (int j = 0; j < dv_holidays.Count; j++)
                                //    {
                                //        if (dv_holidays[j]["Type"].ToString().Trim() == "P")
                                //        {
                                //            if (dv_holidays[j]["Date_From"].ToString().Substring(0, 5) == ts.ToString("dd/MM/yyyy").Substring(0, 5))
                                //            {
                                //                ts = ts.AddDays(1);
                                //                count_per_holidays++;
                                //            }
                                //        }
                                //        else if (dv_holidays[j]["Type"].ToString().Trim() == "S")
                                //        {
                                //            int noofholidays = Convert.ToInt16((DateTime.Parse(dv_holidays[j]["Date_To"].ToString().Trim(), new CultureInfo("en-GB", false)) - DateTime.Parse(dv_holidays[j]["Date_From"].ToString().Trim(), new CultureInfo("en-GB", false))).TotalDays);
                                //            for (int k = 0; k <= noofholidays; k++)
                                //            {
                                //                DateTime dtee = DateTime.Parse(dv_holidays[j]["Date_From"].ToString().Trim(), new CultureInfo("en-GB", false));
                                //                dtee = dtee.AddDays(k);

                                //                if (dtee.Date > System.DateTime.Now.Date && dtee.Date <= ts.Date)//dtee.ToString("dd/MM/yyyy") == ts.ToString("dd/MM/yyyy")
                                //                {
                                //                    count_sea_holidays++;

                                //                    //ts = (DateTime.Parse(dv_holidays[j]["Date_To"].ToString().Trim(), new CultureInfo("en-GB", false))).AddDays(k+1);
                                //                    //break;
                                //                }
                                //            }
                                //            last_Seasonal = DateTime.Parse(dv_holidays[j]["Date_To"].ToString().Trim(), new CultureInfo("en-GB", false));
                                //        }

                                //    }
                                //    if (count_sea_holidays - count_per_holidays > 0)
                                //    {
                                //        ts = last_Seasonal.AddDays(count_sea_holidays - count_per_holidays);
                                //    }
                                //}
                                #endregion


                                ///////////////////////////////////////////////////////////////////////////////////////////////////////
                                objdbhims.Query = @"Select dplan,time1,dispatchtime1,time2,dispatchtime2,time3,dispatchtime3,time4,dispatchtime4 From dc_tp_test where TestID=" + StrTestID + " and Active='Y'";
                                DataView dv_dplan = objTrans.DataTrigger_Get_All(objdbhims);
                                if (dv_dplan.Count > 0)
                                {
                                    if (dv_dplan[0]["dplan"].ToString().Trim() == "Y")
                                    {
                                        int flag = 0;
                                        if (!dv_dplan[0]["time1"].ToString().Trim().Equals(""))
                                        {
                                            if (DateTime.Parse(System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"), new CultureInfo("en-GB", false)) <= DateTime.Parse(System.DateTime.Now.ToString("dd/MM/yyyy") + " " + dv_dplan[0]["time1"].ToString().Trim(), new CultureInfo("en-GB", false)) && flag == 0)
                                            {
                                                StrDelivery_Time = (DateTime.Parse(System.DateTime.Now.ToString("dd/MM/yyyy") + " " + dv_dplan[0]["dispatchtime1"].ToString().Trim(), new CultureInfo("en-GB", false))).ToString("dd/MM/yyyy hh:mm:ss tt");
                                                flag = 1;
                                            }
                                        }

                                        if (!dv_dplan[0]["time2"].ToString().Trim().Equals(""))
                                        {
                                            if (DateTime.Parse(System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"), new CultureInfo("en-GB", false)) <= DateTime.Parse(System.DateTime.Now.ToString("dd/MM/yyyy") + " " + dv_dplan[0]["time2"].ToString().Trim(), new CultureInfo("en-GB", false)) && flag == 0)
                                            {
                                                StrDelivery_Time = (DateTime.Parse(System.DateTime.Now.ToString("dd/MM/yyyy") + " " + dv_dplan[0]["dispatchtime2"].ToString().Trim(), new CultureInfo("en-GB", false))).ToString("dd/MM/yyyy hh:mm:ss tt");
                                                flag = 1;
                                            }
                                        }
                                        if (!dv_dplan[0]["time3"].ToString().Trim().Equals(""))
                                        {
                                            if (DateTime.Parse(System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"), new CultureInfo("en-GB", false)) <= DateTime.Parse(System.DateTime.Now.ToString("dd/MM/yyyy") + " " + dv_dplan[0]["time3"].ToString().Trim(), new CultureInfo("en-GB", false)) && flag == 0)
                                            {
                                                StrDelivery_Time = (DateTime.Parse(System.DateTime.Now.ToString("dd/MM/yyyy") + " " + dv_dplan[0]["dispatchtime3"].ToString().Trim(), new CultureInfo("en-GB", false))).ToString("dd/MM/yyyy hh:mm:ss tt");
                                                flag = 1;
                                            }
                                        }
                                        if (!dv_dplan[0]["time4"].ToString().Trim().Equals(""))
                                        {
                                            if (DateTime.Parse(System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"), new CultureInfo("en-GB", false)) <= DateTime.Parse(System.DateTime.Now.ToString("dd/MM/yyyy") + " " + dv_dplan[0]["time4"].ToString().Trim(), new CultureInfo("en-GB", false)) && flag == 0)
                                            {
                                                StrDelivery_Time = (DateTime.Parse(System.DateTime.Now.ToString("dd/MM/yyyy") + " " + dv_dplan[0]["dispatchtime4"].ToString().Trim(), new CultureInfo("en-GB", false))).ToString("dd/MM/yyyy hh:mm:ss tt");
                                                flag = 1;
                                            }
                                        }
                                        if (flag == 0)
                                        {
                                            DateTime dtime = chkholiday(System.DateTime.Now.AddDays(1));
                                            StrDelivery_Time = (DateTime.Parse(dtime.ToString("dd/MM/yyyy") + " " + dv_dplan[0]["dispatchtime1"].ToString().Trim(), new CultureInfo("en-GB", false))).ToString("dd/MM/yyyy hh:mm:ss tt");
                                        }
                                    }
                                    else
                                    {
                                        StrDelivery_Time = ts.ToString("dd/MM/yyyy hh:mm:ss tt");




                                        //if (System.Configuration.ConfigurationSettings.AppSettings["clientid"].ToString().Equals("006"))
                                        //{
                                        //    if (ts.DayOfWeek.ToString() == "Sunday" && Convert.ToDateTime(ts.ToShortTimeString()) > DateTime.Parse("3:00 PM"))
                                        //    {
                                        //        fin_date = ts.AddDays(1.0);
                                        //        StrDelivery_Time = fin_date.ToString("dd/MM/yyyy") + " 09:00:00 AM";
                                        //    }
                                        //    else if (Convert.ToDateTime(ts.ToShortTimeString()) > DateTime.Parse("10:00 PM") && Convert.ToDateTime(ts.ToShortTimeString()) < DateTime.Parse("11:59 PM"))
                                        //    {
                                        //        fin_date = ts.AddDays(1.0);
                                        //        StrDelivery_Time = fin_date.ToString("dd/MM/yyyy") + " 09:00:00 AM";

                                        //    }

                                        //    else if (Convert.ToDateTime(ts.ToShortTimeString()) < DateTime.Parse("9:00 AM"))
                                        //    {
                                        //        fin_date = ts;
                                        //        StrDelivery_Time = fin_date.ToString("dd/MM/yyyy") + " 09:00:00 AM";
                                        //    }
                                        //}
                                    }
                                }
                            }
                            else
                            {
                                StrDelivery_Time = "~!@";
                                //System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                            }
                            StrBookingDetailID = "~!@";
                            objdbhims.Query = objQB.QBInsert(MakeArray_Booking_DTemp(), "dc_tpatient_bookingd_temp");
                            StrError = objTrans.DataTrigger_Insert(objdbhims);

                            if (StrError.Equals("True"))
                            {

                                StrError = objTrans.OperationError;
                                objTrans.End_Transaction();
                                return false;
                            }
                            else
                            {//
                                //objdbhims.Query = "update dc_tp_test set ordering=ifnull(ordering,0)+1 where testid=" + StrTestID + "";
                                //StrError = objTrans.DataTrigger_Update(objdbhims);
                                //if (StrError.Equals("True"))
                                //{
                                //    StrError = objTrans.OperationError;
                                //    objTrans.End_Transaction();
                                //    return false;
                                //}
                                //else
                                //{
                                //    objdbhims.Query = objQB.QBGetLastID("bookingdid", "dc_tpatient_bookingd");
                                //    StrBookingDetailID = objTrans.DataTrigger_Get_Max(objdbhims);

                                //    objdbhims.Query = "insert into dc_tstatustrack (labid,processid,testid,enteredby,enteredon,clientid,bookingdid) values ('" + StrLabID + "',10," + StrTestID + "," + StrEnteredBy + ",str_to_date('" + StrEnteredOn + "','%d/%m/%Y %h:%i:%s %p'),'" + StrClientID + "'," + StrBookingDetailID + ") ";
                                //    StrError = objTrans.DataTrigger_Insert(objdbhims);
                                //    if (StrError.Equals("True"))
                                //    {
                                //        StrError = objTrans.OperationError;
                                //        objTrans.End_Transaction();
                                //        return false;
                                //    }
                                //    else
                                //    {
                                //        if (!StrInt_Comment.Trim().Equals("") && !StrInt_Comment.Trim().Equals(Default))
                                //        {
                                //            objdbhims.Query = "insert into dc_tint_coment (bookingid,testid,description,active,process,for_process,enteredon,enteredby,clientid) values (" + StrBookingID + "," + StrTestID + ",'" + StrInt_Comment + "','Y',10," + StrFor_Process + ",str_to_date('" + StrEnteredOn + "','%d/%m/%Y %h:%i:%s %p')," + StrEnteredBy + ",'" + StrClientID + "')";
                                //            StrError = objTrans.DataTrigger_Insert(objdbhims);
                                //        }
                                //        if (StrError.Equals("True"))
                                //        {
                                //            StrError = objTrans.OperationError;
                                //            objTrans.End_Transaction();
                                //            return false;
                                //        }
                                //    }
                                //}
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
                              try
                              {
                                  objTrans.End_Transaction();
                              }
                              catch { }
                              return true;

                            //objdbhims.Query = "SELECT lpad(ifnull(max(substr(e.receiveno,9,7)),0)+1,7,0) as maxid FROM dc_tcashcollection e where substr(e.receiveno,6,2)= date_format(current_date,'%y') and substr(e.receiveno,2,3)='" + StrBranchID + "'";
                            //StrReceive_No = this.objTrans.DataTrigger_Get_Max(objdbhims);

                            //if (!StrReceive_No.Equals("True"))
                            //{
                            //    StrReceive_No = "R" + StrBranchID + "-" + System.DateTime.Now.ToString("yy") + "-" + StrReceive_No;
                            //    objdbhims.Query = objQB.QBInsert(MakeArray_cash(), Table_Cash);
                            //    StrError = objTrans.DataTrigger_Insert(objdbhims);

                            //    if (!StrError.Equals("True"))
                            //    {
                            //        objdbhims.Query = "update dc_tpatient_bookingm set paidamount=" + StrPaidAmount + ",refund_amt=0,balance=" + StrTotalAmount + "-" + StrPaidAmount + "-" + StrDiscount + " where bookingid=" + StrBookingID + "";
                            //        //objdbhims.Query = "update dc_tpatient_bookingm set paidamount=" + StrPaidAmount + " where bookingid=" + StrBookingID + "";
                            //        StrError = objTrans.DataTrigger_Update(objdbhims);

                            //        if (!StrError.Equals("True") && StrRefundType.Equals("D"))
                            //        {
                            //            objdbhims.Query = "SELECT lpad(ifnull(max(substr(e.refundno,9,7)),0)+1,7,0) as maxid FROM dc_tcashrefund e where substr(e.refundno,6,2)= date_format(current_date,'%y') and substr(e.refundno,2,3)='" + StrBranchID + "'";
                            //            StrREfundNo = this.objTrans.DataTrigger_Get_Max(objdbhims);
                            //            if (!StrREfundNo.Equals("True"))
                            //            {
                            //                StrREfundNo = "F" + StrBranchID + "-" + System.DateTime.Now.ToString("yy") + "-" + StrREfundNo;
                            //                objdbhims.Query = objQB.QBInsert(MakeArray_Refund(), "dc_tcashrefund");
                            //                StrError = objTrans.DataTrigger_Insert(objdbhims);

                            //                if (!StrError.Equals("True"))
                            //                {
                            //                    try
                            //                    {
                            //                        objTrans.End_Transaction();
                            //                    }
                            //                    catch { }
                            //                    return true;
                            //                }
                            //                else
                            //                {
                            //                    StrError = objTrans.OperationError;
                            //                    objTrans.End_Transaction();
                            //                    return false;
                            //                }
                            //            }
                            //            else
                            //            {
                            //                StrError = objTrans.OperationError;
                            //                objTrans.End_Transaction();
                            //                return false;
                            //            }

                            //        }
                            //        if (!StrError.Equals("True"))
                            //        {
                            //            try
                            //            {
                            //                objTrans.End_Transaction();
                            //            }
                            //            catch { }
                            //            return true;
                            //        }
                            //        else
                            //        {
                            //            StrError = objTrans.OperationError;
                            //            objTrans.End_Transaction();
                            //            return false;
                            //        }
                            //    }
                            //    else
                            //    {
                            //        StrError = objTrans.OperationError;
                            //        objTrans.End_Transaction();
                            //        return false;
                            //    }
                            //}
                            //else
                            //{
                            //    StrError = objTrans.OperationError;
                            //    objTrans.End_Transaction();
                            //    return false;
                            //}
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

            catch
            {
                StrError = "Exception caught: " + objTrans.OperationError;
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
            string[,] kd_arr = new string[25, 3];

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

            if (!_BranchID.Equals(Default))
            {
                kd_arr[23, 0] = "BranchID";
                kd_arr[23, 1] = this._BranchID;
                kd_arr[23, 2] = "int";
            }
            if (!_dependent_cliq_id.Equals(Default))
            {
                kd_arr[24, 0] = "cliq_dependent_id";
                kd_arr[24, 1] = this._dependent_cliq_id;
                kd_arr[24, 2] = "int";
            }

            return kd_arr;
        }

        private string[,] MakeArray_Booking_M()
        {
            string[,] kd_array = new string[28, 3];

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
            if (!_BranchID.Equals(Default))
            {
                kd_array[21, 0] = "BranchID";
                kd_array[21, 1] = this._BranchID;
                kd_array[21, 2] = "int";
            }
	        if (!_SpecimenInternal.Equals(Default))
            {
                kd_array[22, 0] = "Specimen_Internal";
                kd_array[22, 1] = this._SpecimenInternal;
                kd_array[22, 2] = "string";
            }
            if (!_history_antobiotics.Equals(Default))
            {
                kd_array[23, 0] = "history_antobiotics";
                kd_array[23, 1] = this._history_antobiotics;
                kd_array[23, 2] = "string";
            }
            if (!_prescription_document_path.Equals(Default))
            {
                kd_array[24, 0] = "prescription_document_path";
                kd_array[24, 1] = this._prescription_document_path;
                kd_array[24, 2] = "string";
            }
            if (!_discountAll.Equals(Default))
            {
                kd_array[25, 0] = "discountAll";
                kd_array[25, 1] = this._discountAll;
                kd_array[25, 2] = "string";
            }
            if (!_PathCliqueId.Equals(Default))
            {
                kd_array[26, 0] = "PathCliqueId";
                kd_array[26, 1] = this._PathCliqueId;
                kd_array[26, 2] = "string";
            }
            if (!StrGroupID.Equals(Default))
            {
                kd_array[27, 0] = "GroupID";
                kd_array[27, 1] = this.GroupID;
                kd_array[27, 2] = "int";
            }
            return kd_array;

        }
        private string[,] MakeArray_Booking_MTemp()
        {
            string[,] kd_array = new string[24, 3];

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
            
            if (!StrReferenceNo.Equals(Default))
            {
                kd_array[13, 0] = "referenceno";
                kd_array[13, 1] = this.StrReferenceNo;
                kd_array[13, 2] = "string";
            }
            if (!StrPatient_Type.Equals(Default))
            {
                kd_array[14, 0] = "payment_mode";
                kd_array[14, 1] = this.StrPatient_Type;
                kd_array[14, 2] = "string";
            }
            if (!StrRemarks.Equals(Default))
            {
                kd_array[15, 0] = "remarks";
                kd_array[15, 1] = this.StrRemarks;
                kd_array[15, 2] = "string";
            }
            if (!StrPanelID.Equals(Default))
            {
                kd_array[16, 0] = "panelid";
                kd_array[16, 1] = this.StrPanelID;
                kd_array[16, 2] = "int";
            }
            if (!StrWardID.Equals(Default))
            {
                kd_array[17, 0] = "wardid";
                kd_array[17, 1] = this.StrWardID;
                kd_array[17, 2] = "int";
            }
            if (!StrBed.Equals(Default))
            {
                kd_array[18, 0] = "bed";
                kd_array[18, 1] = this.StrBed;
                kd_array[18, 2] = "string";
            }
            if (!StrAdm_Ref.Equals(Default))
            {
                kd_array[19, 0] = "adm_ref";
                kd_array[19, 1] = this.StrAdm_Ref;
                kd_array[19, 2] = "string";
            }
            if (!_BranchID.Equals(Default))
            {
                kd_array[20, 0] = "BranchID";
                kd_array[20, 1] = this._BranchID;
                kd_array[20, 2] = "int";
            }
            if (!_SpecimenInternal.Equals(Default))
            {
                kd_array[21, 0] = "Specimen_Internal";
                kd_array[21, 1] = this._SpecimenInternal;
                kd_array[21, 2] = "string";
            }
            if (!_history_antobiotics.Equals(Default))
            {
                kd_array[22, 0] = "history_antobiotics";
                kd_array[22, 1] = this._history_antobiotics;
                kd_array[22, 2] = "string";
            }
            if (!_prescription_document_path.Equals(Default))
            {
                kd_array[23, 0] = "prescription_document_path";
                kd_array[23, 1] = this._prescription_document_path;
                kd_array[23, 2] = "string";
            }
           
            return kd_array;

        }

        private string[,] MakeArray_Booking_D()
        {
            string[,] kd_array = new string[19, 3];

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

            if (!_DestinationBranchID.Equals(Default))
            {
                kd_array[13, 0] = "DestinationBranchID";
                kd_array[13, 1] = this._DestinationBranchID;
                kd_array[13, 2] = "int";
            }
            else
            {
                kd_array[13, 0] = "DestinationBranchID";
                kd_array[13, 1] = "0";
                kd_array[13, 2] = "int";
            }
            if (!_sendstatus.Equals(Default))
            {
                kd_array[14, 0] = "Sendstatus";
                kd_array[14, 1] = this._sendstatus;
                kd_array[14, 2] = "string";
            }
            if (!_brpercentagediscount.Equals(Default))
            {
                kd_array[15, 0] = "branchdiscount";
                kd_array[15, 1] = this._brpercentagediscount;
                kd_array[15, 2] = "int";
            }
            if (!_percentdiscountpanel.Equals(Default))
            {
                kd_array[16, 0] = "percentdiscountpanel";
                kd_array[16, 1] = this._percentdiscountpanel;
                kd_array[16, 2] = "int";
            }
            if (!_percentdiscountcash.Equals(Default))
            {
                kd_array[17, 0] = "percentdiscountcash";
                kd_array[17, 1] = this._percentdiscountcash;
                kd_array[17, 2] = "int";
            }
            if (!_paidamountsingle.Equals(Default))
            {
                kd_array[18, 0] = "paidamount";
                kd_array[18, 1] = this._paidamountsingle;
                kd_array[18, 2] = "int";
            }


            return kd_array;

        }
        private string[,] MakeArray_Booking_DTemp()
        {
            string[,] kd_array = new string[15, 3];

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

            if (!_DestinationBranchID.Equals(Default))
            {
                kd_array[13, 0] = "DestinationBranchID";
                kd_array[13, 1] = this._DestinationBranchID;
                kd_array[13, 2] = "int";
            }
            else
            {
                kd_array[13, 0] = "DestinationBranchID";
                kd_array[13, 1] = "0";
                kd_array[13, 2] = "int";
            }
            if (!_sendstatus.Equals(Default))
            {
                kd_array[14, 0] = "Sendstatus";
                kd_array[14, 1] = this._sendstatus;
                kd_array[14, 2] = "string";
            }
            //if (!_percentdiscountpanel.Equals(Default))
            //{
            //    kd_array[15, 0] = "percentdiscountpanel";
            //    kd_array[15, 1] = this._percentdiscountpanel;
            //    kd_array[15, 2] = "int";
            //}
            //if (!_percentdiscountcash.Equals(Default))
            //{
            //    kd_array[16, 0] = "percentdiscountcash";
            //    kd_array[16, 1] = this._percentdiscountcash;
            //    kd_array[16, 2] = "int";
            //}
            //if (!_paidamountsingle.Equals(Default))
            //{
            //    kd_array[17, 0] = "paidamount";
            //    kd_array[17, 1] = this._paidamountsingle;
            //    kd_array[17, 2] = "int";
            //}


            return kd_array;

        }

        private string[,] MakeArray_cash()
        {
            string[,] kdc_arr = new string[17, 3];

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
                kdc_arr[12, 0] = "ReferenceNo";
                kdc_arr[12, 1] = this.StrCard_ReferenceNo;
                kdc_arr[12, 2] = "string";
            }
            if (!_CardType.Equals(Default))
            {
                kdc_arr[13, 0] = "CardType";
                kdc_arr[13, 1] = this._CardType;
                kdc_arr[13, 2] = "string";
            }
            if (!_BankName.Equals(Default))
            {
                kdc_arr[14, 0] = "BankName";
                kdc_arr[14, 1] = this._BankName;
                kdc_arr[14, 2] = "string";
            }
            if (!_CardExpiryDate.Equals(Default))
            {
                kdc_arr[15, 0] = "ExpiryDate";
                kdc_arr[15, 1] = this._CardExpiryDate;
                kdc_arr[15, 2] = "date";
            }
            if (!_CardNumber.Equals(Default))
            {
                kdc_arr[16, 0] = "CardNumber";
                kdc_arr[16, 1] = this._CardNumber;
                kdc_arr[16, 2] = "string";
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
        private DateTime chkholiday(DateTime ts)
        {
            clsBLGazzetedHolidays obj_holidays = new clsBLGazzetedHolidays();
            obj_holidays.Active = "Y";
            obj_holidays.Deliverytime = ts.ToString("yyyy-MM-dd");
            DataView dv_holidays = obj_holidays.GetAll(1);
            int count_per_holidays = 0;
            int count_sea_holidays = 0;
            DateTime last_Seasonal = System.DateTime.Now;
            DataView dvS = new DataView();
            DataView dvP = new DataView();
            int seasonalflag = 0;

            dvS.Table = dv_holidays.ToTable();
            dvP.Table = dv_holidays.ToTable();
            dvS.RowFilter = "Type='S'";

            for (int k = 0; k < dvS.Count; k++)
            {
                int noofholidays = Convert.ToInt16((DateTime.Parse(dvS[k]["Date_To"].ToString().Trim(), new CultureInfo("en-GB", false)) - DateTime.Parse(dvS[k]["Date_From"].ToString().Trim(), new CultureInfo("en-GB", false))).TotalDays) + 1;

                for (int m = 0; m < noofholidays; m++)
                {
                    DateTime dtee = DateTime.Parse(dvS[k]["Date_From"].ToString().Trim(), new CultureInfo("en-GB", false));
                    dtee = dtee.AddDays(m);
                    if (dtee.Date >= System.DateTime.Now.Date && dtee.Date <= ts.Date)//dtee.ToString("dd/MM/yyyy") == ts.ToString("dd/MM/yyyy")
                    {
                        count_sea_holidays++;

                        //ts = (DateTime.Parse(dv_holidays[j]["Date_To"].ToString().Trim(), new CultureInfo("en-GB", false))).AddDays(k+1);
                        //break;
                    }
                }
                if (DateTime.Parse(dvS[k]["Date_To"].ToString().Trim(), new CultureInfo("en-GB", false)).Date > last_Seasonal.Date)
                {
                    last_Seasonal = DateTime.Parse(dvS[k]["Date_To"].ToString().Trim(), new CultureInfo("en-GB", false));
                }

            }
            // dvS.Dispose();

            if (ts.Date > last_Seasonal.Date && count_sea_holidays > 0)
            {
                ts = ts.AddDays(count_sea_holidays);
                seasonalflag = 1;
            }
            else if (count_sea_holidays > 0)
            {
                ts = last_Seasonal.AddDays(count_sea_holidays);
                seasonalflag = 1;
            }

            // DataView dvP = dv_holidays;
            dvP.RowFilter = "Type='P'";
            for (int n = 0; n < dvP.Count; n++)
            {
                int counter = 0;
                // string chutti_date = System.DateTime.Now.ToString("yyyy") + "-" + dvP[n]["date_from"].ToString().Substring(3, 2) + "-" + dvP[n]["date_from"].ToString().Substring(0, 2);

                if (dvS.Count > 0)
                {
                    for (int o = 0; o < dvS.Count; o++)
                    {
                        if (DateTime.Parse(dvP[n]["date_from"].ToString().Trim(), new CultureInfo("en-GB", false)).Date >= DateTime.Parse(dvS[o]["Date_from"].ToString().Trim(), new CultureInfo("en-GB", false)).Date && DateTime.Parse(dvP[n]["date_from"].ToString().Trim(), new CultureInfo("en-GB", false)).Date <= DateTime.Parse(dvS[o]["Date_to"].ToString().Trim(), new CultureInfo("en-GB", false)).Date)
                        {
                            break;
                        }
                        else
                        {
                            counter++;
                        }
                        if (counter == dvS.Count && (DateTime.Parse(dvP[n]["date_from"].ToString().Trim(), new CultureInfo("en-GB", false)).Date >= System.DateTime.Now.Date && DateTime.Parse(dvP[n]["date_from"].ToString().Trim(), new CultureInfo("en-GB", false)).Date <= ts.Date))
                        {
                            count_per_holidays++;
                        }
                    }
                }
                else
                {
                    if (DateTime.Parse(dvP[n]["date_from"].ToString().Trim(), new CultureInfo("en-GB", false)).Date >= System.DateTime.Now.Date && DateTime.Parse(dvP[n]["date_from"].ToString().Trim(), new CultureInfo("en-GB", false)).Date <= ts.Date)
                    {
                        count_per_holidays++;
                    }
                }

            }

            ts = ts.AddDays(count_per_holidays);

            if (seasonalflag == 0)
            {
                obj_holidays.Deliverytime = ts.ToString("yyyy-MM-dd");
                dv_holidays = obj_holidays.GetAll(1);
                dvS.Table = dv_holidays.ToTable();
                dvS.RowFilter = "Type='S'";
                for (int k = 0; k < dvS.Count; k++)
                {
                    int noofholidays = Convert.ToInt16((DateTime.Parse(dvS[k]["Date_To"].ToString().Trim(), new CultureInfo("en-GB", false)) - DateTime.Parse(dvS[k]["Date_From"].ToString().Trim(), new CultureInfo("en-GB", false))).TotalDays) + 1;

                    for (int m = 0; m < noofholidays; m++)
                    {
                        DateTime dtee = DateTime.Parse(dvS[k]["Date_From"].ToString().Trim(), new CultureInfo("en-GB", false));
                        dtee = dtee.AddDays(m);
                        if (dtee.Date >= System.DateTime.Now.Date && dtee.Date <= ts.Date)//dtee.ToString("dd/MM/yyyy") == ts.ToString("dd/MM/yyyy")
                        {
                            count_sea_holidays++;

                            //ts = (DateTime.Parse(dv_holidays[j]["Date_To"].ToString().Trim(), new CultureInfo("en-GB", false))).AddDays(k+1);
                            //break;
                        }
                    }
                    if (DateTime.Parse(dvS[k]["Date_To"].ToString().Trim(), new CultureInfo("en-GB", false)).Date > last_Seasonal.Date)
                    {
                        last_Seasonal = DateTime.Parse(dvS[k]["Date_To"].ToString().Trim(), new CultureInfo("en-GB", false));
                    }

                }
                // dvS.Dispose();

                if (ts.Date > last_Seasonal.Date && count_sea_holidays > 0)
                {
                    ts = ts.AddDays(count_sea_holidays);
                    seasonalflag = 1;
                }
                else if (count_sea_holidays > 0)
                {
                    ts = last_Seasonal.AddDays(count_sea_holidays);
                    seasonalflag = 1;
                }
            }
            #region old code
            //clsBLGazzetedHolidays obj_holidays = new clsBLGazzetedHolidays();
            //obj_holidays.Active = "Y";
            //DataView dv_holidays = obj_holidays.GetAll(1);
            //if (dv_holidays.Count > 0)
            //{
            //    for (int j = 0; j < dv_holidays.Count; j++)
            //    {
            //        if (dv_holidays[j]["Type"].ToString().Trim() == "P")
            //        {
            //            if (dv_holidays[j]["Date_From"].ToString().Substring(0, 5) == ts.ToString("dd/MM/yyyy").Substring(0, 5))
            //            {
            //                ts = ts.AddDays(1);
            //            }
            //        }
            //        else if (dv_holidays[j]["Type"].ToString().Trim() == "S")
            //        {
            //            int noofholidays = Convert.ToInt16((DateTime.Parse(dv_holidays[j]["Date_To"].ToString().Trim(), new CultureInfo("en-GB", false)) - DateTime.Parse(dv_holidays[j]["Date_From"].ToString().Trim(), new CultureInfo("en-GB", false))).TotalDays);
            //            for (int k = 0; k <= noofholidays; k++)
            //            {
            //                DateTime dtee = DateTime.Parse(dv_holidays[j]["Date_From"].ToString().Trim(), new CultureInfo("en-GB", false));
            //                dtee = dtee.AddDays(k);
            //                if (dtee.ToString("dd/MM/yyyy") == ts.ToString("dd/MM/yyyy"))
            //                {
            //                    ts = (DateTime.Parse(dv_holidays[j]["Date_To"].ToString().Trim(), new CultureInfo("en-GB", false))).AddDays(k);
            //                    break;
            //                }
            //            }
            //        }
            //    }
            //}
            #endregion
            return ts;
        }
        private int get(DateTime date)
        {

            DateTime tempdate = date.AddDays(-date.Day + 1);

            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            int weekNumStart = ciCurr.Calendar.GetWeekOfYear(tempdate, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
            int weekNum = ciCurr.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);

            return weekNum - weekNumStart + 1;
        }

        public bool updatebookingtemp()
        {
            objdbhims.Query = "uPDATE dc_tpatient_bookingm_temp set Cancelled='X' where bookingid=" + StrBookingID;
            objTrans.Start_Transaction();
            StrError = objTrans.DataTrigger_Update(objdbhims);
            objTrans.End_Transaction();
            if (StrError.Equals("True"))
            {
                StrError = objTrans.OperationError;
                return false;
            }
            return true;
        }
        #endregion
    }
}
