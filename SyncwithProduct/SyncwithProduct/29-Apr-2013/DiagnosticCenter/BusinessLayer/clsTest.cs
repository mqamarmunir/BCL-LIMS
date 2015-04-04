using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Odbc;
using DataLayer;

namespace BusinessLayer
{
    public class clsTest
    {
        #region Class Variables

        private const string Default = "~!@";
        private const string TableName = "dc_tp_test";
        private const string TableName2 = "dc_tp_personnel";
        private const string TableName3 = "dc_tp_groupm";
        private const string TableName4 = "dc_tp_stype";
        private const string TableName5 = "dc_tp_subdepartments";
        private string StrErrorMessage = "";
        private string StrCliqtestid = Default;
        private string _TestId = Default;
        private string _GroupId = Default;
        private string _SpecimenId = Default;
        private string _SContainerId = Default;

        private string _SubdepartmentId = Default;
        private string _Test_Name = Default;
        private string _Acronym = Default;

        private string _Active = Default;
        private string _Charges = Default;

        private string _AutomatedText = Default;
        private string _ClinicalUse = Default;
        private string _DOrder = Default;

        private string _TestBatchNo = Default;
        private string _ReportNo = Default;

        private string _TestType = Default;
        private string _SpecimenType = Default;
        private string _SpecimenContainer = Default;

        private string _SepReport = Default;
        private string _PrintTest = Default;

        private string _PrintGroup = Default;
        private string _SpeedKey = Default;
        private string _ChargesUrgent = Default;

        private string _Urgent = Default;
        private string _Qty = Default;

        private string _ClientId = Default;
        private string _Enteredby = Default;
        private string _Enteredon = Default;

        private string _MethodID = Default;
        private string _ProcedureID = Default;
        private string _External = Default;
        private string _External_Org = Default;

        private string _Gender = Default;
        private string _MinAge = Default;
        private string _MaxAge = Default;
        private string _Unit = Default;

        private string _ReportFormat = Default;
        private string _ProvisionRpt = Default;
        private string _PerformType = Default;

        private string _Schedule = Default;
        private string _Charity = Default;
        private string _DepartmentID = Default;
        private string _Prev_SubID = Default;

        private string _mintime = Default;

      
        private string _maxtime = Default;
        private string _Instructions_Before = Default;

     
        private string _Instructions_After = Default;
        private string _Discount_Applicable = Default;

        private string _BranchID = Default;

        private string _TestInfoReport = Default;

        private string _DPlan = Default;

        
        private string _Time1 = Default;
        private string _DispatchTime1 = Default;
        private string _Time2 = Default;
        private string _DispatchTime2 = Default;
        private string _Time3 = Default;
        private string _DispatchTime3 = Default;
        private string _Time4 = Default;
        private string _DispatchTime4 = Default;

        private string _ProposedPrice = Default;

        
        private string _EffectiveDate = Default;
        private string _RateAlteredBy = Default;
        private string _RateAlteredOn = Default;
        private string _Special_Test = Default;

       

       // private string _OldPrice = Default;
       

      

        
        #endregion

        #region Properties
        public string Special_Test
        {
            get { return _Special_Test; }
            set { _Special_Test = value; }
        }
        public string CliQtest
        {
            get { return StrCliqtestid; }
            set { StrCliqtestid = value; }
        }
        public string ProposedPrice
        {
            get { return _ProposedPrice; }
            set { _ProposedPrice = value; }
        }
        public string EffectiveDate
        {
            get { return _EffectiveDate; }
            set { _EffectiveDate = value; }
        }
        public string RateAlteredBy
        {
            get { return _RateAlteredBy; }
            set { _RateAlteredBy = value; }
        }
        public string RateAlteredOn
        {
            get { return _RateAlteredOn; }
            set { _RateAlteredOn = value; }
        }
        public string TestId
        {
            get
            {
                return _TestId;
            }
            set
            {
                _TestId = value;
            }
        }
        public string GroupId
        {
            get
            {
                return _GroupId;
            }
            set
            {
                _GroupId = value;
            }
        }

        public string SpecimenId
        {
            get
            {
                return _SpecimenId;
            }
            set
            {
                _SpecimenId = value;
            }
        }
        public string SContainerId
        {
            get
            {
                return _SContainerId;
            }
            set
            {
                _SContainerId = value;
            }
        }

        public string SubdepartmentId
        {
            get
            {
                return _SubdepartmentId;
            }
            set
            {
                _SubdepartmentId = value;
            }
        }

        public string Test_Name
        {
            get
            {
                return _Test_Name;
            }
            set
            {
                _Test_Name = value;
            }
        }
        public string Acronym
        {
            get
            {
                return _Acronym;
            }
            set
            {
                _Acronym = value;
            }
        }
        public string Active
        {
            get
            {
                return _Active;
            }
            set
            {
                _Active = value;
            }
        }

        public string Charges
        {
            get
            {
                return _Charges;
            }
            set
            {
                _Charges = value;
            }
        }
        public string AutomatedText
        {
            get
            {
                return _AutomatedText;
            }
            set
            {
                _AutomatedText = value;
            }
        }
        public string ClinicalUse
        {
            get
            {
                return _ClinicalUse;
            }
            set
            {
                _ClinicalUse = value;
            }
        }

        public string DOrder
        {
            get
            {
                return _DOrder;
            }
            set
            {
                _DOrder = value;
            }
        }
        public string TestBatchNo
        {
            get
            {
                return _TestBatchNo;
            }
            set
            {
                _TestBatchNo = value;
            }
        }
        public string ReportNo
        {
            get
            {
                return _ReportNo;
            }
            set
            {
                _ReportNo = value;
            }
        }

        public string TestType
        {
            get
            {
                return _TestType;
            }
            set
            {
                _TestType = value;
            }
        }
        public string SpecimenType
        {
            get
            {
                return _SpecimenType;
            }
            set
            {
                _SpecimenType = value;
            }
        }
        public string SpecimenContainer
        {
            get
            {
                return _SpecimenContainer;
            }
            set
            {
                _SpecimenContainer = value;
            }
        }

        public string SepReport
        {
            get
            {
                return _SepReport;
            }
            set
            {
                _SepReport = value;
            }
        }
        public string PrintTest
        {
            get
            {
                return _PrintTest;
            }
            set
            {
                _PrintTest = value;
            }
        }
        public string PrintGroup
        {
            get
            {
                return _PrintGroup;
            }
            set
            {
                _PrintGroup = value;
            }
        }

        public string SpeedKey
        {
            get
            {
                return _SpeedKey;
            }
            set
            {
                _SpeedKey = value;
            }
        }
        public string ChargesUrgent
        {
            get
            {
                return _ChargesUrgent;
            }
            set
            {
                _ChargesUrgent = value;
            }
        }
        public string Urgent
        {
            get
            {
                return _Urgent;
            }
            set
            {
                _Urgent = value;
            }
        }

        public string ClientId
        {
            get
            {
                return _ClientId;
            }
            set
            {
                _ClientId = value;
            }
        }
        public string Qty
        {
            get
            {
                return _Qty;
            }
            set
            {
                _Qty = value;
            }
        }

        public string Enteredby
        {
            get
            {
                return _Enteredby;
            }
            set
            {
                _Enteredby = value;
            }
        }
        public string Enteredon
        {
            get
            {
                return _Enteredon;
            }
            set
            {
                _Enteredon = value;
            }
        }
        public string ErrorMessage
        {
            get { return StrErrorMessage; }
        }

        public string MethodID
        {
            get { return _MethodID; }
            set { _MethodID = value; }
        }
        public string ProcedureID
        {
            get { return _ProcedureID; }
            set { _ProcedureID = value; }
        }
        public string External
        {
            get { return _External; }
            set { _External = value; }
        }
        public string External_ORG
        {
            get { return _External_Org; }
            set { _External_Org = value; }
        }

        public string Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }
        public string MinAge
        {
            get { return _MinAge; }
            set { _MinAge = value; }
        }
        public string MaxAge
        {
            get { return _MaxAge; }
            set { _MaxAge = value; }
        }
        public string Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }

        public string ReportFormat
        {
            get { return _ReportFormat; }
            set { _ReportFormat = value; }
        }
        public string ProvisionRpt
        {
            get { return _ProvisionRpt; }
            set { _ProvisionRpt = value; }
        }
        public string PerformType
        {
            get { return _PerformType; }
            set { _PerformType = value; }
        }

        public string Schedule
        {
            get { return _Schedule; }
            set { _Schedule = value; }
        }
        public string Charity
        {
            get { return _Charity; }
            set { _Charity = value; }
        }
        public string DepartmentID
        {
            get { return _DepartmentID; }
            set { _DepartmentID = value; }
        }
        public string Prev_SubID
        {
            get { return _Prev_SubID; }
            set { _Prev_SubID = value; }
        }
        public string Maxtime
        {
            get { return _maxtime; }
            set { _maxtime = value; }
        }

        public string Mintime
        {
            get { return _mintime; }
            set { _mintime = value; }
        }

        public string Instructions_Before
        {
            get { return _Instructions_Before; }
            set { _Instructions_Before = value; }
        }
        public string Instructions_After
        {
            get { return _Instructions_After; }
            set { _Instructions_After = value; }
        }

        public string Discount_Applicable
        {
            get { return _Discount_Applicable; }
            set { _Discount_Applicable = value; }
        }
        public string BranchID
        {
            get { return _BranchID; }
            set { _BranchID = value; }
        }
        public string TestInfoReport
        {
            get { return _TestInfoReport; }
            set { _TestInfoReport = value; }
        }

        public string DPlan
        {
            get { return _DPlan; }
            set { _DPlan = value; }
        }
        public string Time1
        {
            get { return _Time1; }
            set { _Time1 = value; }
        }
        public string DispatchTime1
        {
            get { return _DispatchTime1; }
            set { _DispatchTime1 = value; }
        }
        public string Time2
        {
            get { return _Time2; }
            set { _Time2 = value; }
        }
        public string DispatchTime2
        {
            get { return _DispatchTime2; }
            set { _DispatchTime2 = value; }
        }
        public string Time3
        {
            get { return _Time3; }
            set { _Time3 = value; }
        }
        public string DispatchTime3
        {
            get { return _DispatchTime3; }
            set { _DispatchTime3 = value; }
        }
        public string Time4
        {
            get { return _Time4; }
            set { _Time4 = value; }
        }
        public string DispatchTime4
        {
            get { return _DispatchTime4; }
            set { _DispatchTime4 = value; }
        }
        #endregion
        
        clsoperation objTrans = new clsoperation();
        clsdbhims objdbhims = new clsdbhims();

        #region Methods

        public DataView GetAll(int flag)
        {
            switch (flag)
            {
                case 1:
                    objdbhims.Query = "select t.TestId,t.Test_Name,t.Acronym,g.Name as GroupName,s.Specimen_Name,t.Active,su.name as subname,ifnull(t.charges,0) as charges,ifnull((select group_concat(distinct ms.name) from dc_tp_method ms join dc_tp_tmethod mts  on mts.methodid=ms.methodid where ms.subdepartmentid=t.subdepartmentid  and mts.testid=t.testid and mts.m_default='Y'),'-') as defaultmethod,ifnull(t.charityrate,0) as charityrate,ifnull(t.dorder,'-') as dorder from " + TableName + " t left outer join " + TableName3 + " g on t.GroupId = g.GroupId left outer join " + TableName4 + " s on t.SpecimenId = s.SpecimenId left outer join " + TableName5 + " su on t.subdepartmentid=su.subdepartmentid  where 1 = 1"; //left outer join dc_tp_method m on t.d_methodid=m.methodid
                    if (!_GroupId.Equals(Default))
                    {
                        objdbhims.Query += " and t.GroupId = " + _GroupId;
                    }
                    if (!_SubdepartmentId.Equals(Default) && !_SubdepartmentId.Equals(""))
                    {
                        objdbhims.Query += " and t.SubdepartmentId = " + _SubdepartmentId;
                    }
                    if (!_SpecimenId.Equals(Default) && !_SpecimenId.Equals(""))
                    {
                        objdbhims.Query += " and t.SpecimenId = " + _SpecimenId;
                    }
                    if (!_SContainerId.Equals(Default) && !_SContainerId.Equals(""))
                    {
                        objdbhims.Query += " and t.SContainerId = " + _SContainerId;
                    }
                    if (!_TestType.Equals(Default) && !_TestType.Equals(""))
                    {
                        objdbhims.Query += " and t.TestType = '" + _TestType + "'";
                    }
                    if (!ClientId.Equals(Default) && !ClientId.Equals(""))
                    {
                        objdbhims.Query += " and t.ClientId = '" + _ClientId + "'";
                    }
                    if (!Test_Name.Equals(Default) && !Test_Name.Equals(""))
                    {
                        objdbhims.Query += " and t.Test_Name LIKE '" + _Test_Name + "%'";
                    }
                    objdbhims.Query += " order by su.name,ifnull(t.dorder,t.test_name)";
                    break;

                case 2:
                    objdbhims.Query = "select TestId,Test_Name,Acronym,Active from " + TableName + " t ";
                    objdbhims.Query = objdbhims.Query + " Where Upper(t.Test_Name) = '" + this._Test_Name.ToUpper() + "'";
                    if (!_SubdepartmentId.Equals(Default) && !_SubdepartmentId.Equals(""))
                        objdbhims.Query += " and subdepartmentid='" + _SubdepartmentId + "'";
                    break;

                case 3:
                    objdbhims.Query = "select SpecialTest,TestId,GroupId,SpecimenId,SContainerId,SubdepartmentId,Test_Name,Acronym,Charges,AutomatedText,ClinicalUse,DOrder,TestType,SepReport,PrintTest,PrintGroup,SpeedKey,ChargesUrgent,Urgent,Qty,ClientId,Active,d_methodid,procedureid,external,external_org,unit,reportformat,provisionrpt,ifnull(charityrate,0) as charityrate,maxtime,mintime,case when mintime <60 then 'M' when mintime >=60 and mintime < 1440 then 'H' else 'D' end as TimeType, case when mintime <60 then mintime when mintime >=60 and mintime < 1440 then format(mintime/60,0) else format(mintime/1440,0) end as MinTimeValue, case when maxtime <60 then maxtime when maxtime >=60 and maxtime < 1440 then format(maxtime/60,0) else format(maxtime/1440,0) end as MaxTimeValue,Instructions_before,Instructions_After,Discount_Applicable,TestInfoReport,Dplan,time1,dispatchtime1,time2,dispatchtime2,time3,dispatchtime3,time4,dispatchtime4 from " + TableName + " where TestId = " + _TestId;
                    break;

                case 4:
                    objdbhims.Query = "select t.Test_Name,t.TestId from " + TableName + " t where t.Active='Y'";
                    if (!_GroupId.Equals(Default))
                    {
                        objdbhims.Query += " and t.GroupId = " + _GroupId;
                    }                    
                    if (!_SubdepartmentId.Equals(Default))
                    {
                        objdbhims.Query += " and t.SubdepartmentId = " + _SubdepartmentId;
                    }
                    if (!_SpecimenId.Equals(Default))
                    {
                        objdbhims.Query += " and t.SpecimenId = " + _SpecimenId;
                    }
                    if (!_SContainerId.Equals(Default))
                    {
                        objdbhims.Query += " and t.SContainerId = " + _SContainerId;
                    }
                    if (!_TestType.Equals(Default))
                    {
                        objdbhims.Query += " and t.TestType = '" + _TestType + "'";
                    }
                    if (!_DepartmentID.Equals(Default) && !_DepartmentID.Equals("-1"))
                        objdbhims.Query += " and subdepartmentid in (select subdepartmentid from dc_tp_subdepartments where departmentid='" + _DepartmentID + "')";
                    objdbhims.Query += " order by t.Test_Name";
                    break;

                case 5:
                    objdbhims.Query = "select TestId,Acronym,Active from " + TableName + " t ";
                    objdbhims.Query = objdbhims.Query + " Where Upper(t.Acronym) = '" + this._Acronym.ToUpper() + "'";
                    break;

                case 6:
                    objdbhims.Query = "select TestId,DOrder,Active from " + TableName + " t ";
                    objdbhims.Query = objdbhims.Query + " Where DOrder = '" + this._DOrder + "' and subdepartmentid=" + _SubdepartmentId + "";
                    break;
                case 7: // fill method drop down
                    objdbhims.Query = "select methodid,name from dc_tp_method where active='Y' and subdepartmentid=" + _SubdepartmentId + "";
                    break;
                case 8: // fill procedure drop down
                    objdbhims.Query = "select procedureid,name from dc_tp_tprocedurem where active='Y'";
                    break;
                case 9: // fill method grid based upon testID
                    objdbhims.Query = "SELECT distinct t.methodid,t.testid,d.name FROM dc_tp_tmethod t left outer join dc_tp_method d on t.methodid=d.methodid where t.testid=" + _TestId + "";
                    break;
                case 10: // fill group grid based upon testid
                    objdbhims.Query = "SELECT distinct d.groupid, d.testid,m.name FROM dc_tp_groupd d left outer join dc_tp_groupm m on d.groupid=m.groupid where d.testid = " + _TestId + "";
                    break;
                case 11: // check b4 default method set 
                    objdbhims.Query = "select methodid from dc_tp_tmethod where testid=" + _TestId + "";
                    break;
                case 12: // get age applicable
                    objdbhims.Query = "select testid,minage,maxage,gender from dc_tp_test_Age where testid=" + _TestId + "";
                    break;
                case 13: // fill Org for external
                    objdbhims.Query = "SELECT orgid,name,ifnull(main_of,'0') as main_of,main FROM dc_tp_organization where active='Y'";
                    if (!_External.Equals(Default))
                        objdbhims.Query += " and external='" + _External + "'";
                    break;
                case 14: // get schedule on update
                    objdbhims.Query = "select testid,type,value from dc_tp_test_schedule where testid=" + _TestId + "";
                    break;
                case 15:
                    objdbhims.Query = "Select * From " + TableName + " where Active='Y' and SubDepartmentID=" + Convert.ToInt32(_SubdepartmentId) ;
                    if (!_BranchID.Equals(Default) && !_BranchID.Equals(""))
                    {
                        objdbhims.Query += @" and testid in (Select TestID From dc_tp_branchtestd where Active='Y' and External!='Y' and BranchID=" + Convert.ToInt32(_BranchID) + @")";
                    }
                    
                    break;
                case 16:
                    objdbhims.Query = @"SELECT parentid,name FROM dc_tp_branch WHERE Active = 'Y' ORDER BY name";
                    break;
                case 17:
                    objdbhims.Query = @"SELECT subdepartmentid,name FROM dc_tp_subdepartments WHERE   Active = 'Y' ORDER BY name";
                    break;
                case 18:
                    objdbhims.Query = @"SELECT groupid,name FROM  dc_tp_groupm  WHERE   Active = 'Y' ORDER BY name";
                    break;
                case 19:
                    objdbhims.Query = @"SELECT testid, test_name
FROM dc_tp_test  and  Active = 'Y' ORDER BY name";
                    break;
                case 20:
                    objdbhims.Query = "select t.Test_Name,t.TestId from " + TableName + " t where  t.Test_Name LIKE '" + _Test_Name + "%' ORDER BY Test_Name LIMIT 0 , 15";
                    break;
                case 21:
                    objdbhims.Query = @"Select SubDepartmentid,testid,Test_Name,Charges CurrentPrice,proposedprice,EffectiveDate
,ifnull(ratealteredby,1) ratealteredby,ifnull(ratealteredon,sysdate()) ratealteredon from dc_tp_test where proposedprice is not null and proposedprice<>0
and Active='Y' and proposedprice-Charges<>0 and Effectivedate<=str_to_Date('"+System.DateTime.Now.ToString("dd/MM/yyyy")+"','%d/%m/%Y')";
                    break;
                case 22:
                    objdbhims.Query = @"select distinct t.testid,t.test_name,m.name as method,t.cliqtestid from dc_tp_test t inner join dc_tp_tmethod tm on tm.testid=t.testid inner join
dc_tp_method m on

m.methodid=tm.methodid where m_default='Y' and t.Active='Y' order by cliqtestid desc,test_name asc";
                    break;

                   
                
            }

            return objTrans.DataTrigger_Get_All(objdbhims);
        }

        public bool Insert(string[,] str,string[,] sched)
        {
            if (Validation())
            {
                try
                {
                    clsoperation objTrans = new clsoperation();
                    QueryBuilder objQB = new QueryBuilder();

                    //DataView dv = GetAll(11);                    

                    objTrans.Start_Transaction();

                    objdbhims.Query = objQB.QBGetMax("TestId", TableName);
                    this._TestId = objTrans.DataTrigger_Get_Max(objdbhims);

                    if (!this._TestId.Equals("True"))
                    {
                        objdbhims.Query = objQB.QBInsert(MakeArray(), TableName);
                        this.StrErrorMessage = objTrans.DataTrigger_Insert(objdbhims);

                       

                        if (this.StrErrorMessage.Equals("True"))
                        {                            
                            this.StrErrorMessage = objTrans.OperationError;
                            objTrans.End_Transaction();
                            return false;
                        }
                        else
                        {
                            //if (dv.Count == 0)
                            //{
                            //    objdbhims.Query = "insert into dc_tp_tmethod (methodid,testid,enteredby,enteredon,clientid) values (" + _MethodID + "," + _TestId + "," + _Enteredby + ",str_to_date('" + _Enteredon + "','%d/%m/%Y %h:%i:%s %p'),'"+_ClientId+"') ";
                            //    StrErrorMessage = objTrans.DataTrigger_Insert(objdbhims);
                            //}

                            if (this.StrErrorMessage.Equals("True"))
                            {
                                this.StrErrorMessage = objTrans.OperationError;
                                objTrans.End_Transaction();
                                return false;
                            }
                            else
                            {
                                for (int i = 0; i <= str.GetUpperBound(0); i++)
                                {
                                    _MinAge = str[i, 0];
                                    _MaxAge = str[i, 1];
                                    _Gender = str[i, 2];

                                    if (_MinAge != null)
                                    {
                                        objdbhims.Query = "insert into dc_tp_test_Age (testid,gender,minage,maxage,enteredby,enteredon,clientid) values (" + _TestId + ",'" + _Gender + "'," + _MinAge + "," + _MaxAge + "," + _Enteredby + ",str_to_date('" + _Enteredon + "','%d/%m/%Y %h:%i:%s %p'),'" + _ClientId + "')";
                                        StrErrorMessage = objTrans.DataTrigger_Insert(objdbhims);
                                    }
                                   
                                }
                                if (StrErrorMessage.Equals("True"))
                                {
                                    StrErrorMessage = objTrans.OperationError;
                                    objTrans.End_Transaction();
                                    return false;
                                }
                                else
                                {
                                    objdbhims.Query = "delete from dc_tp_test_schedule where testid="+_TestId+"";
                                    StrErrorMessage = objTrans.DataTrigger_Delete(objdbhims);
                                    if (StrErrorMessage.Equals("True"))
                                    {
                                        StrErrorMessage = objTrans.OperationError;
                                        objTrans.End_Transaction();
                                        return false;
                                    }

                                    if (_PerformType.Equals("Daily"))
                                    {
                                        objdbhims.Query = "insert into dc_tp_test_schedule (testid,type,value,enteredby,enteredon,clientid) values (" + _TestId + ",'" + _PerformType + "','-'," + _Enteredby + ",str_to_date('" + _Enteredon + "','%d/%m/%Y %h:%i:%s %p'),'" + _ClientId + "')";
                                        StrErrorMessage = objTrans.DataTrigger_Insert(objdbhims);

                                        if (StrErrorMessage.Equals("True"))
                                        {
                                            StrErrorMessage = objTrans.OperationError;
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
                                        for (int i = 0; i <= sched.GetUpperBound(0); i++)
                                        {
                                            if (sched[i, 0] != null)
                                            {
                                                objdbhims.Query = "insert into dc_tp_test_schedule (testid,type,value,enteredby,enteredon,clientid) values (" + _TestId + ",'" + _PerformType + "','" + sched[i, 0] + "'," + _Enteredby + ",str_to_date('" + _Enteredon + "','%d/%m/%Y %h:%i:%s %p'),'" + _ClientId + "')";
                                                StrErrorMessage = objTrans.DataTrigger_Insert(objdbhims);

                                                if (StrErrorMessage.Equals("True"))
                                                {
                                                    StrErrorMessage = objTrans.OperationError;
                                                    objTrans.End_Transaction();
                                                    return false;
                                                }
                                            }
                                        }
                                        if (StrErrorMessage.Equals("True"))
                                        {
                                            StrErrorMessage = objTrans.OperationError;
                                            objTrans.End_Transaction();
                                            return false;
                                        }
                                        else
                                        {
                                            objTrans.End_Transaction();
                                            return true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        this.StrErrorMessage = objTrans.OperationError;
                        objTrans.End_Transaction();
                        return false;
                    }
                }
                catch (Exception e)
                {
                    this.StrErrorMessage = e.Message;
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool Update(string[,] str,string[,] sched)
        {
            if (Validation())
            {
                clsoperation objTrans = new clsoperation();
                QueryBuilder objQB = new QueryBuilder();
                //DataView dv = GetAll(11);

                objTrans.Start_Transaction();
                objdbhims.Query = objQB.QBUpdate(MakeArray(), TableName);
                this.StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);
                

                if (this.StrErrorMessage.Equals("True"))
                {                    
                    this.StrErrorMessage = objTrans.OperationError;
                    objTrans.End_Transaction();
                    return false;
                }
                else
                {
                    //if (dv.Count == 0)
                    //{
                    //    objdbhims.Query = "insert into dc_tp_tmethod (methodid,testid,enteredby,enteredon,clientid) values (" + _MethodID + "," + _TestId + "," + _Enteredby + ",str_to_date('" + _Enteredon + "','%d/%m/%Y %h:%i:%s %p'),"+_ClientId+") ";
                    //    StrErrorMessage = objTrans.DataTrigger_Insert(objdbhims);
                    //}

                    if (this.StrErrorMessage.Equals("True"))
                    {
                        this.StrErrorMessage = objTrans.OperationError;
                        objTrans.End_Transaction();
                        return false;
                    }
                    else
                    {
                        objdbhims.Query = "delete from dc_tp_test_age where testid="+_TestId+"";
                        StrErrorMessage = objTrans.DataTrigger_Delete(objdbhims);
                        
                        for (int i = 0; i <= str.GetUpperBound(0); i++)
                        {
                            
                            _MinAge = str[i, 0];
                            _MaxAge = str[i, 1];
                            _Gender = str[i, 2];
                            if (_MinAge != null)
                            {
                                objdbhims.Query = "insert into dc_tp_test_Age (testid,gender,minage,maxage,enteredby,enteredon,clientid) values (" + _TestId + ",'" + _Gender + "'," + _MinAge + "," + _MaxAge + "," + _Enteredby + ",str_to_date('" + _Enteredon + "','%d/%m/%Y %h:%i:%s %p'),'" + _ClientId + "')";
                                StrErrorMessage = objTrans.DataTrigger_Insert(objdbhims);

                            }
                        }
                        if (StrErrorMessage.Equals("True"))
                        {
                            StrErrorMessage = objTrans.OperationError;
                            objTrans.End_Transaction();
                            return false;
                        }
                        else
                        {

                            objdbhims.Query = "delete from dc_tp_test_schedule where testid=" + _TestId + "";
                            StrErrorMessage = objTrans.DataTrigger_Delete(objdbhims);
                            if (StrErrorMessage.Equals("True"))
                            {
                                StrErrorMessage = objTrans.OperationError;
                                objTrans.End_Transaction();
                                return false;
                            }
                            else
                            {
                                objdbhims.Query = "update dc_tp_attributes set subdepartmentid=" + _SubdepartmentId + " where testid=" + _TestId + "";
                                StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);
                                if (StrErrorMessage.Equals("True"))
                                {
                                    StrErrorMessage = objTrans.OperationError;
                                    objTrans.End_Transaction();
                                    return false;
                                }
                                else
                                {
                                    objdbhims.Query = "update dc_tp_aranges set subdepartmentid=" + _SubdepartmentId + " where testid=" + _TestId + "";
                                    StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);
                                    if (StrErrorMessage.Equals("True"))
                                    {
                                        StrErrorMessage = objTrans.OperationError;
                                        objTrans.End_Transaction();
                                        return false;
                                    }                                    
                                }
                            }
                            if (!StrErrorMessage.Equals("True"))
                            {
                                if (_PerformType.Equals("Daily"))
                                {
                                    objdbhims.Query = "insert into dc_tp_test_schedule (testid,type,value,enteredby,enteredon,clientid) values (" + _TestId + ",'" + _PerformType + "','-'," + _Enteredby + ",str_to_date('" + _Enteredon + "','%d/%m/%Y %h:%i:%s %p'),'" + _ClientId + "')";
                                    StrErrorMessage = objTrans.DataTrigger_Insert(objdbhims);

                                    if (StrErrorMessage.Equals("True"))
                                    {
                                        StrErrorMessage = objTrans.OperationError;
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
                                    for (int i = 0; i <= sched.GetUpperBound(0); i++)
                                    {
                                        if (sched[i, 0] != null)
                                        {
                                            objdbhims.Query = "insert into dc_tp_test_schedule (testid,type,value,enteredby,enteredon,clientid) values (" + _TestId + ",'" + _PerformType + "','" + sched[i, 0] + "'," + _Enteredby + ",str_to_date('" + _Enteredon + "','%d/%m/%Y %h:%i:%s %p'),'" + _ClientId + "')";
                                            StrErrorMessage = objTrans.DataTrigger_Insert(objdbhims);

                                            if (StrErrorMessage.Equals("True"))
                                            {
                                                StrErrorMessage = objTrans.OperationError;
                                                objTrans.End_Transaction();
                                                return false;
                                            }
                                        }
                                    }
                                    if (StrErrorMessage.Equals("True"))
                                    {
                                        StrErrorMessage = objTrans.OperationError;
                                        objTrans.End_Transaction();
                                        return false;
                                    }
                                    else
                                    {
                                        objTrans.End_Transaction();
                                        return true;

                                    }
                                }
                            }
                            else
                            {
                                StrErrorMessage = objTrans.OperationError;
                                objTrans.End_Transaction();
                                return false;
                            }
                        }
                    }
                    
                }
            }
            else
            {
                return false;
            }
        }

        public bool updaterates()
        {
            try
            {
                QueryBuilder objQB = new QueryBuilder();
                objTrans.Start_Transaction();
                objdbhims.Query = objQB.QBInsert(MakeArray_RateAudit(), "dc_tp_testratesaudit");
                this.StrErrorMessage = objTrans.DataTrigger_Insert(objdbhims);
                if (StrErrorMessage.Equals("True"))
                {
                    this.StrErrorMessage = objTrans.OperationError;
                    objTrans.End_Transaction();
                    return false;
                }
                objdbhims.Query = "Update dc_tp_test set Charges=" + _ProposedPrice + ",proposedprice=Null,Effectivedate=Null,RateAlteredBy= Null,RateAlteredoN=Null where TestiD=" + _TestId;
                this.StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);
                if (StrErrorMessage.Equals("True"))
                {
                    this.StrErrorMessage = objTrans.OperationError;
                    objTrans.End_Transaction();
                    return false;
                }
                objTrans.End_Transaction();
                return true;
            }
            catch(Exception ee)
            {
                this.StrErrorMessage = ee.ToString().Substring(0, 100);
                objTrans.End_Transaction();
                return false;
 
            }
        }
        public bool updatCliqtestsInfo()
        {
            try
            {
                QueryBuilder objQB = new QueryBuilder();
                objTrans.Start_Transaction();
               
                objdbhims.Query = "Update dc_tp_test set cliqtestid=" + StrCliqtestid + " where testid=" + _TestId;
                this.StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);
                if (StrErrorMessage.Equals("True"))
                {
                    this.StrErrorMessage = objTrans.OperationError;
                    objTrans.End_Transaction();
                    return false;
                }
                objTrans.End_Transaction();
                return true;
            }
            catch (Exception ee)
            {
                this.StrErrorMessage = ee.ToString().Substring(0, 100);
                objTrans.End_Transaction();
                return false;

            }
        }

        private string[,] MakeArray()
        {
            string[,] arySAPS = new string[55, 3];

            if (!this._TestId.Equals(Default))
            {
                arySAPS[0, 0] = "TestId";
                arySAPS[0, 1] = this._TestId;
                arySAPS[0, 2] = "int";
            }

            if (!this._GroupId.Equals(Default))
            {
                arySAPS[1, 0] = "GroupId";
                arySAPS[1, 1] = this._GroupId;
                arySAPS[1, 2] = "int";
            }
            else
            {
                arySAPS[1, 0] = "GroupId";
                arySAPS[1, 1] = "null";
                arySAPS[1, 2] = "int";
            }


            if (!this._SpecimenId.Equals(Default))
            {
                arySAPS[2, 0] = "SpecimenId";
                arySAPS[2, 1] = this._SpecimenId;
                arySAPS[2, 2] = "int";
            }

            if (!this._SubdepartmentId.Equals(Default))
            {
                arySAPS[3, 0] = "SubdepartmentId";
                arySAPS[3, 1] = this._SubdepartmentId;
                arySAPS[3, 2] = "int";
            }

            if (!this._Test_Name.Equals(Default))
            {
                arySAPS[4, 0] = "Test_Name";
                arySAPS[4, 1] = this._Test_Name;
                arySAPS[4, 2] = "string";
            }

            if (!this._Acronym.Equals(Default))
            {
                arySAPS[5, 0] = "Acronym";
                arySAPS[5, 1] = this._Acronym;
                arySAPS[5, 2] = "string";
            }

            if (!this.Active.Equals(Default))
            {
                arySAPS[6, 0] = "Active";
                arySAPS[6, 1] = this.Active;
                arySAPS[6, 2] = "string";
            }

            if (!this._Enteredby.Equals(Default))
            {
                arySAPS[7, 0] = "Enteredby";
                arySAPS[7, 1] = this._Enteredby;
                arySAPS[7, 2] = "int";
            }

            if (!this._Enteredon.Equals(Default))
            {
                arySAPS[8, 0] = "Enteredon";
                arySAPS[8, 1] = this._Enteredon;
                arySAPS[8, 2] = "datetime";
            }

            if (!this._Charges.Equals(Default))
            {
                arySAPS[9, 0] = "Charges";
                arySAPS[9, 1] = this._Charges;
                arySAPS[9, 2] = "int";
            }            

            if (!this._AutomatedText.Equals(Default))
            {
                arySAPS[10, 0] = "AutomatedText";
                arySAPS[10, 1] = this._AutomatedText;
                arySAPS[10, 2] = "string";
            }

            if (!this._ClinicalUse.Equals(Default))
            {
                arySAPS[11, 0] = "ClinicalUse";
                arySAPS[11, 1] = this._ClinicalUse;
                arySAPS[11, 2] = "string";
            }

            if (!this._DOrder.Equals(Default))
            {
                arySAPS[12, 0] = "DOrder";
                arySAPS[12, 1] = this._DOrder;
                arySAPS[12, 2] = "int";
            }

            if (!this._TestBatchNo.Equals(Default))
            {
                arySAPS[13, 0] = "TestBatchNo";
                arySAPS[13, 1] = this._TestBatchNo;
                arySAPS[13, 2] = "int";
            }

            if (!this._ReportNo.Equals(Default))
            {
                arySAPS[14, 0] = "ReportNo";
                arySAPS[14, 1] = this._ReportNo;
                arySAPS[14, 2] = "string";
            }

            if (!this._TestType.Equals(Default))
            {
                arySAPS[15, 0] = "TestType";
                arySAPS[15, 1] = this._TestType;
                arySAPS[15, 2] = "string";
            }

            if (!this._SpecimenType.Equals(Default))
            {
                arySAPS[16, 0] = "SpecimenType";
                arySAPS[16, 1] = this._SpecimenType;
                arySAPS[16, 2] = "string";
            }

            if (!this._SpecimenContainer.Equals(Default))
            {
                arySAPS[17, 0] = "SpecimenContainer";
                arySAPS[17, 1] = this._SpecimenContainer;
                arySAPS[17, 2] = "string";
            }            

            if (!this._SepReport.Equals(Default))
            {
                arySAPS[18, 0] = "SepReport";
                arySAPS[18, 1] = this._SepReport;
                arySAPS[18, 2] = "string";
            }

            if (!this._PrintTest.Equals(Default))
            {
                arySAPS[19, 0] = "PrintTest";
                arySAPS[19, 1] = this._PrintTest;
                arySAPS[19, 2] = "string";
            }

            if (!this._PrintGroup.Equals(Default))
            {
                arySAPS[20, 0] = "PrintGroup";
                arySAPS[20, 1] = this._PrintGroup;
                arySAPS[20, 2] = "string";
            }

            if (!this._SpeedKey.Equals(Default))
            {
                arySAPS[21, 0] = "SpeedKey";
                arySAPS[21, 1] = this._SpeedKey;
                arySAPS[21, 2] = "string";
            }

            if (!this._ChargesUrgent.Equals(Default))
            {
                arySAPS[22, 0] = "ChargesUrgent";
                arySAPS[22, 1] = this._ChargesUrgent;
                arySAPS[22, 2] = "int";
            }

            if (!this._Urgent.Equals(Default))
            {
                arySAPS[23, 0] = "Urgent";
                arySAPS[23, 1] = this._Urgent;
                arySAPS[23, 2] = "string";
            }          

            if (!this._ClientId.Equals(Default))
            {
                arySAPS[24, 0] = "ClientId";
                arySAPS[24, 1] = this._ClientId;
                arySAPS[24, 2] = "string";
            }

            if (!this._SContainerId.Equals(Default))
            {
                arySAPS[25, 0] = "SContainerId";
                arySAPS[25, 1] = this._SContainerId;
                arySAPS[25, 2] = "int";
            }
            else
            {
                arySAPS[25, 0] = "SContainerId";
                arySAPS[25, 1] = "null";
                arySAPS[25, 2] = "int";
            }

            if (!this._Qty.Equals(Default))
            {
                arySAPS[26, 0] = "Qty";
                arySAPS[26, 1] = this._Qty;
                arySAPS[26, 2] = "string";
            }
            if (!this._MethodID.Equals(Default))
            {
                arySAPS[27, 0] = "d_methodid";
                arySAPS[27, 1] = this._MethodID;
                arySAPS[27, 2] = "int";
            }
            if (!this._ProcedureID.Equals(Default) && !this._ProcedureID.Equals("-1"))
            {
                arySAPS[28, 0] = "procedureid";
                arySAPS[28, 1] = this._ProcedureID;
                arySAPS[28, 2] = "int";
            }
            else
            {
                arySAPS[28, 0] = "procedureid";
                arySAPS[28, 1] = "null";
                arySAPS[28, 2] = "int";
            }
            if (!this._External.Equals(Default) && !this._External.Equals(""))
            {
                arySAPS[29, 0] = "external";
                arySAPS[29, 1] = this._External;
                arySAPS[29, 2] = "string";
            }
            if (!this._External_Org.Equals(Default))
            {
                arySAPS[30, 0] = "external_org";
                arySAPS[30, 1] = this._External_Org;
                arySAPS[30, 2] = "string";
            }
            else
            {
                arySAPS[30, 0] = "external_org";
                arySAPS[30, 1] = "null";
                arySAPS[30, 2] = "int";
            }
            if (!this._Unit.Equals(Default))
            {
                arySAPS[31, 0] = "unit";
                arySAPS[31, 1] = this._Unit;
                arySAPS[31, 2] = "string";
            }
            if (!this._ReportFormat.Equals(Default))
            {
                arySAPS[32, 0] = "reportformat";
                arySAPS[32, 1] = this._ReportFormat;
                arySAPS[32, 2] = "string";
            }
            if (!this._ProvisionRpt.Equals(Default))
            {
                arySAPS[33, 0] = "provisionRpt";
                arySAPS[33, 1] = this._ProvisionRpt;
                arySAPS[33, 2] = "string";
            }
            if (!this._Charity.Equals(Default))
            {
                arySAPS[34, 0] = "charityrate";
                arySAPS[34, 1] = this._Charity;
                arySAPS[34, 2] = "int";
            }
            if (!this._maxtime.Equals(Default))
            {
                arySAPS[35, 0] = "maxtime";
                arySAPS[35, 1] = this._maxtime;
                arySAPS[35, 2] = "int";
            }
            if (!this._mintime.Equals(Default))
            {
                arySAPS[36, 0] = "mintime";
                arySAPS[36, 1] = this._mintime;
                arySAPS[36, 2] = "int";
            }
            
            if (!this._Instructions_Before.Equals(Default))
            {
                arySAPS[37, 0] = "Instructions_Before";
                arySAPS[37, 1] = this._Instructions_Before;
                arySAPS[37, 2] = "string";
            }
            if (!this._Instructions_After.Equals(Default))
            {
                arySAPS[38, 0] = "Instructions_After";
                arySAPS[38, 1] = this._Instructions_After;
                arySAPS[38, 2] = "string";
            }
            if (!this._Discount_Applicable.Equals(Default))
            {
                arySAPS[39, 0] = "Discount_Applicable";
                arySAPS[39, 1] = this._Discount_Applicable;
                arySAPS[39, 2] = "string";
            }
            if (!this._TestInfoReport.Equals(Default))
            {
                arySAPS[40, 0] = "TestInfoReport";
                arySAPS[40, 1] = this._TestInfoReport;
                arySAPS[40, 2] = "string";
            }

            if (!this._DPlan.Equals(Default))
            {
                arySAPS[41, 0] = "DPlan";
                arySAPS[41, 1] = this._DPlan;
                arySAPS[41, 2] = "string";
            }
            if (!this._Time1.Equals(Default))
            {
                arySAPS[42, 0] = "Time1";
                arySAPS[42, 1] = this._Time1;
                arySAPS[42, 2] = "string";
            }
            if (!this._Time2.Equals(Default))
            {
                arySAPS[43, 0] = "Time2";
                arySAPS[43, 1] = this._Time2;
                arySAPS[43, 2] = "string";
            }
            if (!this._Time3.Equals(Default))
            {
                arySAPS[44, 0] = "Time3";
                arySAPS[44, 1] = this._Time3;
                arySAPS[44, 2] = "string";
            }
            if (!this._Time4.Equals(Default))
            {
                arySAPS[45, 0] = "Time4";
                arySAPS[45, 1] = this._Time4;
                arySAPS[45, 2] = "string";
            }
            if (!this._DispatchTime1.Equals(Default))
            {
                arySAPS[46, 0] = "DispatchTime1";
                arySAPS[46, 1] = this._DispatchTime1;
                arySAPS[46, 2] = "string";
            }
            if (!this._DispatchTime2.Equals(Default))
            {
                arySAPS[47, 0] = "DispatchTime2";
                arySAPS[47, 1] = this._DispatchTime2;
                arySAPS[47, 2] = "string";
            }
            if (!this._DispatchTime3.Equals(Default))
            {
                arySAPS[48, 0] = "DispatchTime3";
                arySAPS[48, 1] = this._DispatchTime3;
                arySAPS[48, 2] = "string";
            }
            if (!this._DispatchTime4.Equals(Default))
            {
                arySAPS[49, 0] = "DispatchTime4";
                arySAPS[49, 1] = this._DispatchTime4;
                arySAPS[49, 2] = "string";
            }
            if (!this.ProposedPrice.Equals(Default))
            {
                arySAPS[50, 0] = "ProposedPrice";
                arySAPS[50, 1] = this.ProposedPrice;
                arySAPS[50, 2] = "int";
            }
            if (!this.EffectiveDate.Equals(Default))
            {
                arySAPS[51, 0] = "EffectiveDate";
                arySAPS[51, 1] = this.EffectiveDate;
                arySAPS[51, 2] = "datetime";
            }
            if (!this.RateAlteredBy.Equals(Default))
            {
                arySAPS[52, 0] = "RateAlteredBy";
                arySAPS[52, 1] = this.RateAlteredBy;
                arySAPS[52, 2] = "int";
            }
            if (!this.RateAlteredOn.Equals(Default))
            {
                arySAPS[53, 0] = "RateAlteredOn";
                arySAPS[53, 1] = this.RateAlteredOn;
                arySAPS[53, 2] = "datetime";
            }
            if (!this.Special_Test.Equals(Default))
            {
                arySAPS[54, 0] = "SpecialTest";
                arySAPS[54, 1] = this.Special_Test;
                arySAPS[54, 2] = "string";
            }

            return arySAPS;
        }

        private string[,] MakeArray_RateAudit()
        {
            string[,] arySAPS = new string[7, 3];

            if (!this._TestId.Equals(Default))
            {
                arySAPS[0, 0] = "TestId";
                arySAPS[0, 1] = this._TestId;
                arySAPS[0, 2] = "int";
            }

            if (!this._Charges.Equals(Default))
            {
                arySAPS[1, 0] = "OldPrice";
                arySAPS[1, 1] = this.Charges;
                arySAPS[1, 2] = "int";
            }
           

            if (!this._ProposedPrice.Equals(Default))
            {
                arySAPS[2, 0] = "NEwPrice";
                arySAPS[2, 1] = this.ProposedPrice;
                arySAPS[2, 2] = "int";
            }

            if (!this._SubdepartmentId.Equals(Default))
            {
                arySAPS[3, 0] = "SubdepartmentId";
                arySAPS[3, 1] = this._SubdepartmentId;
                arySAPS[3, 2] = "int";
            }

           
           

            if (!this._Enteredby.Equals(Default))
            {
                arySAPS[4, 0] = "Enteredby";
                arySAPS[4, 1] = this._Enteredby;
                arySAPS[4, 2] = "int";
            }

            if (!this._Enteredon.Equals(Default))
            {
                arySAPS[5, 0] = "Enteredon";
                arySAPS[5, 1] = this._Enteredon;
                arySAPS[5, 2] = "datetime";
            }
            if (!this._ClientId.Equals(Default))
            {
                arySAPS[6, 0] = "ClientiD";
                arySAPS[6, 1] = this._ClientId;
                arySAPS[6, 2] = "string";
            }

            

            return arySAPS;
        }
        #endregion

        #region "Validation Functions"

        private bool Validation()
        {
            if (!VD_Test())
            {
                return false;
            }

            //if (!VD_Group())
            //{
            //    return false;
            //}

            //if (!VD_Specimen())
            //{
            //    return false;
            //}

            if (!VD_Subdepartment())
            {
                return false;
            }

            if (!VD_Acronym())
            {
                return false;
            }
            //if (!VD_Method())
            //{
            //    return false;
            //}

            if (!VD_DOrder())
            {
                return false;
            }
            //if (!VD_SContainer())
            //{
            //    return false;
            //}
            if (!VD_Charges())
            {
                return false;
            }
            if (!VD_ExternalOrg())
            {
                return false;
            }
            if (!VD_ProcedureID())
            {
                return false;
            }

            return true;
        }

        public bool VD_Test()
        {

            if (this._Test_Name.Equals(""))
            {
                this.StrErrorMessage = "Please Enter Test Name. (empty is not allowed)";
                return false;
            }

            DataView dvTest = GetAll(2);

            if (!this._TestId.Equals(Default) && !_TestId.Equals(""))
            {
                dvTest.RowFilter = "TestId <> '" + _TestId + "' "; //And Test_Name = '" + _Test_Name + "'
            }
            //else
            //{
            //    dvTest.RowFilter = "Test_Name = '" + _Test_Name + "'";
            //}

            if (dvTest.Count > 0)
            {
                this.StrErrorMessage = "Please Enter another Test Name, it is already present.";
                return false;
            }

            return true;
        }

        public bool VD_Group()
        {
            if (this._GroupId.Equals(Default))
            {
                this.StrErrorMessage = "Please Select Group First. (empty is not allowed)";
                return false;
            }
            return true;
        }
        public bool VD_Method()
        {
            if (this._MethodID.Equals(Default) || this._MethodID.Equals("-1"))
            {
                this.StrErrorMessage = "Please Select Method First. (empty is not allowed)";
                return false;
            }
            return true;
        }

        public bool VD_Specimen()
        {
            if (this._SpecimenId.Equals(Default))
            {
                this.StrErrorMessage = "Please Select Specimen First. (empty is not allowed)";
                return false;
            }
            return true;
        }
        public bool VD_Subdepartment()
        {
            if (this._SubdepartmentId.Equals(Default))
            {
                this.StrErrorMessage = "Please Select Sub Department First. (empty is not allowed)";
                return false;
            }
            return true;
        }

        private bool VD_Acronym()
        {
            if (this._Acronym.Equals(""))
            {
                this.StrErrorMessage = "Please Enter Acronym. (empty is not allowed)";
                return false;
            }

            if (!this._Acronym.Equals("") && !this._Acronym.Equals(Default))
            {
                DataView dvTest = GetAll(5);

                if (!this._TestId.Equals(Default))
                {
                    dvTest.RowFilter = "TestId <> '" + _TestId + "' And Acronym = '" + _Acronym + "'";
                }
                else
                {
                    dvTest.RowFilter = "Acronym = '" + _Acronym + "'";
                }

                if (dvTest.Count > 0)
                {
                    this.StrErrorMessage = "Please Enter another Acronym, it is already present.";
                    return false;
                }
            }

            return true;
        }
        private bool VD_DOrder()
        {
            //if (this._DOrder.Equals(""))
            //{
            //    this.StrErrorMessage = "Please Enter DOrder. (empty is not allowed)";
            //    return false;
            //}

            if (!this._DOrder.Trim().Equals("") && !this._DOrder.Trim().Equals(Default) && !this._DOrder.Trim().Equals("0"))
            {
                DataView dvTest = GetAll(6);

                if (!this._TestId.Equals(Default))
                {
                    dvTest.RowFilter = "TestId <> '" + _TestId + "' And DOrder = '" + _DOrder + "'";
                }
                else
                {
                    dvTest.RowFilter = "DOrder = '" + _DOrder + "'";
                }

                if (dvTest.Count > 0)
                {
                    this.StrErrorMessage = "Please Enter another DOrder, it is already present.";
                    return false;
                }
            }

            return true;

        }
        public bool VD_SContainer()
        {
            if (this._SContainerId.Equals(Default))
            {
                this.StrErrorMessage = "Please Select Container First. (empty is not allowed)";
                return false;
            }
            return true;
        }

        public bool VD_Charges()
        {
            if (this._Charges.Equals(Default))
            {
                this.StrErrorMessage = "Please enter test charges First. (empty is not allowed)";
                return false;
            }
            return true;
        }
        public bool VD_ExternalOrg()
        {
            if (_External.Equals("Y") && (_External_Org.Equals("-1") || _External_Org.Equals(Default)))
            {
                StrErrorMessage = "Please select performing location";
                return false;
            }
            return true;
        }
        public bool VD_ProcedureID()
        {
            if (_ProcedureID.Equals("") || _ProcedureID.Equals("-1"))
            {
                StrErrorMessage = "Please select procedure";
                return false;
            }
            return true;
        }
       
               
        #endregion

    }
}

