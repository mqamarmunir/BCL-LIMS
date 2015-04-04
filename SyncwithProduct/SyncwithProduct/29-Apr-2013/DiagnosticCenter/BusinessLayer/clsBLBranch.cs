using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataLayer;

namespace BusinessLayer
{
    public class clsBLBranch
    {
        public clsBLBranch()
        {
            ///Add Constructor logic here...
        }

        #region Variables
        private const string Default = "~!@";
        private const string TableName = "dc_tp_Branch";

        private string StrErrorMessage = "";

    
        private string _BranchID = Default;

     
        private string _OrgId = Default;
        private string _Name = Default;
        private string _Acronym = Default;
        private string _Active = Default;
        private string _Percentage = Default;
        private string _Type = Default;
        private string _PhoneNo = Default;
        private string _FaxNo = Default;
        private string _Email = Default;
        private string _Address = Default;
        private string _City = Default;
        private string _ClientId = Default;
        private string _Enteredby = Default;
        private string _Enteredon = Default;
        private string _BusinessPolicy = Default;
        private string _ReportText = Default;
        private string _PrintReportText = Default;
        private string _StartTime = Default;

   
        private string _EndTime = Default;
        private string _24HrsService = Default;
        private string _Extension = Default;
        private string _Dplan_InternalTests = Default;
        private string _IndoorFacility = Default;
        private string _BranchCode = Default;
        private string _minimumcashcollection_booking = Default;

       

        
      
      
        
      
      

        clsoperation objTrans = new clsoperation();
        clsdbhims objdbhims = new clsdbhims();
        #endregion

        #region Properties
        public string Minimumcashcollection_booking
        {
            get { return _minimumcashcollection_booking; }
            set { _minimumcashcollection_booking = value; }
        }
        
        public string BranchCode
        {
            get { return _BranchCode; }
            set { _BranchCode = value; }
        }
        public string BranchID
        {
            get { return _BranchID; }
            set { _BranchID = value; }
        }
        public string OrgId
        {
            get { return _OrgId; }
            set { _OrgId = value; }
        }
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public string Acronym
        {
            get { return _Acronym; }
            set { _Acronym = value; }
        }
        public string Active
        {
            get { return _Active; }
            set { _Active = value; }
        }
        public string Percentage
        {
            get { return _Percentage; }
            set { _Percentage = value; }
        }
        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        public string PhoneNo
        {
            get { return _PhoneNo; }
            set { _PhoneNo = value; }
        }
        public string FaxNo
        {
            get { return _FaxNo; }
            set { _FaxNo = value; }
        }
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
        public string City
        {
            get { return _City; }
            set { _City = value; }
        }
        public string ClientId
        {
            get { return _ClientId; }
            set { _ClientId = value; }
        }
        public string Enteredby
        {
            get { return _Enteredby; }
            set { _Enteredby = value; }
        }
        public string Enteredon
        {
            get { return _Enteredon; }
            set { _Enteredon = value; }
        }

        public string BusinessPolicy
        {
            get { return _BusinessPolicy; }
            set { _BusinessPolicy = value; }
        }
        public string ErrorMessage
        {
            get { return StrErrorMessage; }
            set { StrErrorMessage = value; }
        }

        public string ReportText
        {
            get { return _ReportText; }
            set { _ReportText = value; }
        }
        public string PrintReportText
        {
            get { return _PrintReportText; }
            set { _PrintReportText = value; }
        }
        public string StartTime
        {
            get { return _StartTime; }
            set { _StartTime = value; }
        }
        public string EndTime
        {
            get { return _EndTime; }
            set { _EndTime = value; }
        }
        public string __24HrsService
        {
            get { return _24HrsService; }
            set { _24HrsService = value; }
        }
        public string Extension
        {
            get { return _Extension; }
            set { _Extension = value; }
        }
        public string Dplan_InternalTests
        {
            get { return _Dplan_InternalTests; }
            set { _Dplan_InternalTests = value; }
        }
        public string IndoorFacility
        {
            get { return _IndoorFacility; }
            set { _IndoorFacility = value; }
        }
        #endregion

        #region Methods
        public DataView GetAll(int flag)
        {
            switch (flag)
            {
                case 1:
                    objdbhims.Query = "Select tb.BranchID,tb.Name,tb.Active Active,case when tb.Type='F' then 'Franchise' when tb.type='R' then 'Rental Business' when tb.type='S' then 'Self Run' end as Type,tor.Name Organization,concat(tb.branchid,'-',p.loginid,'-',p.pasword) as logininfo From dc_tp_Branch tb,dc_tp_Organization tOR,dc_tp_personnel p where tb.ParentID=tor.OrgId and tb.Branchid=p.Branchid and  ParentID='"+_OrgId+"' and lower(p.loginid) like('br%')";
                    break;
                case 2:
                    objdbhims.Query = "Select * From " + TableName + " where BranchID=" + Convert.ToInt32(_BranchID);
                    break;
                case 3:
                    objdbhims.Query = "Select * From " + TableName + " where Active='Y' and (Type='F' or Type='S') and parentid is not null and parentid!=-1 and branchID in (Select branchID From dc_tp_Personnel where Active='Y')";
                    if (!_IndoorFacility.Equals("") && !_IndoorFacility.Equals(Default))
                    {
                        objdbhims.Query+= @" and Indoor_facility='"+_IndoorFacility+"'";
                    }
                    break;
                case 4:
                    objdbhims.Query = "Select * From " + TableName + " where Active='Y' and branchID!="+Convert.ToInt32(_BranchID)+" and parentid is not null and parentid!=-1 and branchID in (Select branchID From dc_tp_Personnel where Active='Y')";
                    break;
                case 5:
                    objdbhims.Query="Select MAX(BranchID) MaxID From "+TableName;
                    break;
                case 6:
                    objdbhims.Query = "Select CityID,Name From dc_tcity where Active='Y'";
                    break;
                case 7:
                    objdbhims.Query = "Select * From dc_tp_branch where Active='Y' and Type='" + _Type + "' and ParentID in('006','008') and BranchID in (Select BranchID From dc_tp_personnel where Active='Y')";
                    if (!_BusinessPolicy.Equals(Default) && !BusinessPolicy.Equals(""))
                    {
                        objdbhims.Query += " and BusinessPolicy='" + _BusinessPolicy + "'";
                    }
                    break;
                case 8:
                    objdbhims.Query = @"Select b.Name,b.streetaddress,b.faxno,b.phoneno,c.Name Cityname From dc_tp_branch b inner join dc_tcity c on c.cityid=b.city where b.branchid=" + Convert.ToInt16(_BranchID);
                    break;
                case 9:
                    objdbhims.Query = @"SELECT d.subdepartmentid,d.name FROM dc_tp_subdepartments d where d.active='Y'";
                    break;
                

            }
            return objTrans.DataTrigger_Get_All(objdbhims);
        }
        public bool Insert()
        {
            if (Validation())
            {
                try
                {
                    clsoperation objTrans = new clsoperation();
                    QueryBuilder objQB = new QueryBuilder();
                    objTrans.Start_Transaction();

                    objdbhims.Query = objQB.QBGetMax("BranchID", TableName);
                    this._BranchID = objTrans.DataTrigger_Get_Max(objdbhims);

                    if (!this._BranchID.Equals("True"))
                    {
                        objdbhims.Query = objQB.QBInsert(MakeArray(), TableName);
                        this.ErrorMessage = objTrans.DataTrigger_Insert(objdbhims);

                        objTrans.End_Transaction();

                        if (this.ErrorMessage.Equals("True"))
                        {
                            this.ErrorMessage = objTrans.OperationError;
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                    else
                    {
                        this.ErrorMessage = objTrans.OperationError;
                        objTrans.End_Transaction();
                        return false;
                    }
                }
                catch (Exception e)
                {
                    this.ErrorMessage = e.Message;
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool Update()
        {
            if (Validation())
            {
                clsoperation objTrans = new clsoperation();
                QueryBuilder objQB = new QueryBuilder();

                objTrans.Start_Transaction();
                objdbhims.Query = objQB.QBUpdate(MakeArray(), TableName);
                this.ErrorMessage = objTrans.DataTrigger_Update(objdbhims);
                objTrans.End_Transaction();

                if (this.ErrorMessage.Equals("True"))
                {
                    this.ErrorMessage = objTrans.OperationError;
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                
                return false;
            }
        }

        private string[,] MakeArray()
        {
            string[,] arySAPS = new string[25, 3];

            if (!this._BranchID.Equals(Default))
            {
                arySAPS[0, 0] = "BranchID";
                arySAPS[0, 1] = this._BranchID;
                arySAPS[0, 2] = "int";
            }

            if (!this._Name.Equals(Default))
            {
                arySAPS[1, 0] = "Name";
                arySAPS[1, 1] = this._Name;
                arySAPS[1, 2] = "string";
            }

            if (!this.Active.Equals(Default))
            {
                arySAPS[2, 0] = "Active";
                arySAPS[2, 1] = this.Active;
                arySAPS[2, 2] = "string";
            }

            if (!this._Enteredby.Equals(Default))
            {
                arySAPS[3, 0] = "Enteredby";
                arySAPS[3, 1] = this._Enteredby;
                arySAPS[3, 2] = "int";
            }

            if (!this._Enteredon.Equals(Default))
            {
                arySAPS[4, 0] = "Enteredon";
                arySAPS[4, 1] = this._Enteredon;
                arySAPS[4, 2] = "datetime";
            }

            if (!this._PhoneNo.Equals(Default))
            {
                arySAPS[5, 0] = "PhoneNo";
                arySAPS[5, 1] = this._PhoneNo;
                arySAPS[5, 2] = "string";
            }

            if (!this._Acronym.Equals(Default))
            {
                arySAPS[6, 0] = "Acronym";
                arySAPS[6, 1] = this._Acronym;
                arySAPS[6, 2] = "string";
            }

            if (!this._City.Equals(Default))
            {
                arySAPS[7, 0] = "City";
                arySAPS[7, 1] = this._City;
                arySAPS[7, 2] = "string";
            }

            if (!this._FaxNo.Equals(Default))
            {
                arySAPS[8, 0] = "FaxNo";
                arySAPS[8, 1] = this._FaxNo;
                arySAPS[8, 2] = "string";
            }

            if (!this._Percentage.Equals(Default))
            {
                arySAPS[9, 0] = "Percentage_share";
                arySAPS[9, 1] = this._Percentage;
                arySAPS[9, 2] = "int";
            }

            if (!this._Address.Equals(Default))
            {
                arySAPS[10, 0] = "StreetAddress";
                arySAPS[10, 1] = this._Address;
                arySAPS[10, 2] = "string";
            }

            if (!this._Type.Equals(Default))
            {
                arySAPS[11, 0] = "Type";
                arySAPS[11, 1] = this._Type;
                arySAPS[11, 2] = "string";
            }

            if (!this._ClientId.Equals(Default))
            {
                arySAPS[12, 0] = "ClientId";
                arySAPS[12, 1] = this._ClientId;
                arySAPS[12, 2] = "string";
            }

            if (!this._OrgId.Equals(Default))
            {
                arySAPS[13, 0] = "ParentID";
                arySAPS[13, 1] = this._OrgId;
                arySAPS[13, 2] = "string";
            }

            if (!this._BusinessPolicy.Equals(Default))
            {
                arySAPS[14, 0] = "BusinessPolicy";
                arySAPS[14, 1] = this._BusinessPolicy;
                arySAPS[14, 2] = "string";
            }
            if (!this._ReportText.Equals(Default))
            {
                arySAPS[15, 0] = "Report_Text";
                arySAPS[15, 1] = this._ReportText;
                arySAPS[15, 2] = "string";
            }
            if (!this._PrintReportText.Equals(Default))
            {
                arySAPS[16, 0] = "PrintReportText";
                arySAPS[16, 1] = this._PrintReportText;
                arySAPS[16, 2] = "string";
            }
            if (!this._StartTime.Equals(Default))
            {
                arySAPS[17, 0] = "StartTime";
                arySAPS[17, 1] = this._StartTime;
                arySAPS[17, 2] = "string";
            }
            if (!this._EndTime.Equals(Default))
            {
                arySAPS[18, 0] = "EndTime";
                arySAPS[18, 1] = this._EndTime;
                arySAPS[18, 2] = "string";
            }
            if (!this._24HrsService.Equals(Default))
            {
                arySAPS[19, 0] = "24HrsService";
                arySAPS[19, 1] = this._24HrsService;
                arySAPS[19, 2] = "string";
            }
            if (!this._Extension.Equals(Default) && !this._Extension.Equals(""))
            {
                arySAPS[20, 0] = "Extension";
                arySAPS[20, 1] = this._Extension;
                arySAPS[20, 2] = "int";
            }
            if (!this._Dplan_InternalTests.Equals(Default))
            {
                arySAPS[21, 0] = "Dplan_InternalTests";
                arySAPS[21, 1] = this._Dplan_InternalTests;
                arySAPS[21, 2] = "string";
            }
            if (!this._IndoorFacility.Equals(Default))
            {
                arySAPS[22, 0] = "Indoor_facility";
                arySAPS[22, 1] = this._IndoorFacility;
                arySAPS[22, 2] = "string";
            }
            if (!this._BranchCode.Equals(Default))
            {
                arySAPS[23, 0] = "BranchCode";
                arySAPS[23, 1] = this._BranchCode;
                arySAPS[23, 2] = "string";
            }
            if (!this._minimumcashcollection_booking.Equals(Default))
            {
                arySAPS[24, 0] = "minimumcashcollection_booking";
                arySAPS[24, 1] = this._minimumcashcollection_booking;
                arySAPS[24, 2] = "int";
            }
        

            return arySAPS;
        }
        #endregion

        #region Validation Functions
        private bool Validation()
        {
            return true;
        }
        #endregion

    }
}
