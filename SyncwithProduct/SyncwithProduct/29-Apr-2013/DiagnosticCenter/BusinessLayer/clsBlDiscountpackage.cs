using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataLayer;
using System.Globalization;

namespace BusinessLayer
{
    public class clsBlDiscountpackage
    {
        public clsBlDiscountpackage()
        {
            /// Add Constructor logic here...
        }

        #region Variables
        private const string TableName = "dc_tp_DiscountPackage";
        private const string Default = "~!@";
        private string StrErrorMessage = "";


        private string _PackageID = Default;


       
        private string _Name = Default;
        private string _Code= Default;
        private string _Active = Default;
        private string _Percentage = Default;
        private string _Type = Default;

        private string _StartDate = Default;
        private string _EndDate = Default;
        private string _ImgPath = Default;
        private string _WebText = Default;
        private string _ReportText = Default;

        private string _ClientId = Default;
        private string _Enteredby = Default;
        private string _Enteredon = Default;

        private string _StartDateFormatted = Default;
        private string _EndDateFormatted = Default;

        clsoperation objTrans = new clsoperation();
        clsdbhims objdbhims = new clsdbhims();
        #endregion

        #region Properties
        public string PackageID
        {
            get { return _PackageID; }
            set { _PackageID = value; }
        }
      
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public string Code
        {
            get { return _Code; }
            set { _Code = value; }
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
        public string StartDate
        {
            get { return _StartDate; }
            set { _StartDate = value; }
        }
        public string EndDate
        {
            get { return _EndDate; }
            set { _EndDate = value; }
        }
        public string ImgPath
        {
            get { return _ImgPath; }
            set { _ImgPath = value; }
        }
        public string WebText
        {
            get { return _WebText; }
            set { _WebText = value; }
        }
        public string ReportText
        {
            get { return _ReportText; }
            set { _ReportText = value; }
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

       
        public string ErrorMessage
        {
            get { return StrErrorMessage; }
            set { StrErrorMessage = value; }
        }

        
        #endregion

        #region Methods

        public DataView GetAll(int flag)
        {
            switch (flag)
            {
                case 1:
                    objdbhims.Query = @"Select *,date_format(Startdate,'%d/%m/%Y') Start_Date,date_format(EndDate,'%d/%m/%Y') End_Date From " + TableName + " where 1=1";
                    if (!_PackageID.Equals(Default))
                    {
                        objdbhims.Query += " and DiscountPackageID=" + Convert.ToInt32(_PackageID);
                    }
                    
                    break;
                case 2:
                    objdbhims.Query = @"Select * From " + TableName + " where Active='Y' and datediff(StartDate,'"+_StartDateFormatted+"')>0 and datediff(EndDate,'"+_EndDateFormatted+"')<0 and Type='"+_Type+"'";
                    break;
                case 3:
                    objdbhims.Query = @"Select DiscountPackageID,Name,StartDate,EndDate
                                        From dc_tp_DiscountPackage
                                        where Active='Y'
                                        and ((date_format('"+_StartDateFormatted+@"','%Y/%m/%d') between startdate and enddate)
                                        or (date_format('"+_EndDateFormatted+@"','%Y/%m/%d') between startdate and enddate))
                                        and Type='"+_Type+"' and DiscountPackageID!="+_PackageID;
                    break;
                case 4:
                    objdbhims.Query = @"Select DiscountPackageID,Name,StartDate,EndDate
                                        From dc_tp_DiscountPackage
                                        where Active='Y'
                                        and ((date_format('"+_StartDateFormatted+@"','%Y/%m/%d') between startdate and enddate)
                                        or (date_format('"+_EndDateFormatted+@"','%Y/%m/%d') between startdate and enddate)
                                        or startdate between date_format('"+_StartDateFormatted+@"','%Y/%m/%d') and  date_format('"+_EndDateFormatted+@"','%Y/%m/%d')
                                        or enddate between date_format('" + _StartDateFormatted + @"','%Y/%m/%d') and  date_format('" + _EndDateFormatted + @"','%Y/%m/%d'))
                                        and Type='"+_Type+@"' and DiscountPackageID!="+_PackageID;
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

                    objdbhims.Query = objQB.QBGetMax("DiscountPackageID", TableName);
                    this._PackageID = objTrans.DataTrigger_Get_Max(objdbhims);

                    if (!this._PackageID.Equals("True"))
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
            string[,] arySAPS = new string[14, 3];

            if (!this._PackageID.Equals(Default))
            {
                arySAPS[0, 0] = "DiscountPackageID";
                arySAPS[0, 1] = this._PackageID;
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

            if (!this._StartDate.Equals(Default))
            {
                arySAPS[5, 0] = "StartDate";
                arySAPS[5, 1] = this._StartDate;
                arySAPS[5, 2] = "datetime";
            }

            if (!this._Code.Equals(Default))
            {
                arySAPS[6, 0] = "Code";
                arySAPS[6, 1] = this._Code;
                arySAPS[6, 2] = "string";
            }

            if (!this._EndDate.Equals(Default))
            {
                arySAPS[7, 0] = "Enddate";
                arySAPS[7, 1] = this._EndDate;
                arySAPS[7, 2] = "datetime";
            }

            if (!this._WebText.Equals(Default))
            {
                arySAPS[8, 0] = "WebText";
                arySAPS[8, 1] = this._WebText;
                arySAPS[8, 2] = "string";
            }

            if (!this._Percentage.Equals(Default))
            {
                arySAPS[9, 0] = "Percentage";
                arySAPS[9, 1] = this._Percentage;
                arySAPS[9, 2] = "int";
            }

            if (!this._ImgPath.Equals(Default))
            {
                arySAPS[10, 0] = "ImagePath";
                arySAPS[10, 1] = this._ImgPath;
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

            if (!this._ReportText.Equals(Default))
            {
                arySAPS[13, 0] = "RecieptText";
                arySAPS[13, 1] = this._ReportText;
                arySAPS[13, 2] = "string";
            }

           


            return arySAPS;
        }
        #endregion

        #region Validation Functions
        private bool Validation()
        {
            if (!_VDStartDateLessLessthanEndDate())
            {
                return false;
            }
            if (!_VDchkmandatoryfields())
            {
                return false;
            }
            if (!_VDchkCodeAndPercentage())
            {
                return false;
            }
            if (!_VDchkActivePackages())
            {
                return false;
            }
            return true;
        }

        private bool _VDStartDateLessLessthanEndDate()
        {
            if (DateTime.Parse(_EndDate, new CultureInfo("en-GB", false)) < DateTime.Parse(_StartDate, new CultureInfo("en-GB", false)))
            {
                this.StrErrorMessage = "End Date should be greater than equal to Start Date. Record Could not be inserted.";
                return false;
            }
            return true;
        }

        private bool _VDchkmandatoryfields()
        {
            if (_Name.Trim().Equals(Default) || _Name.Trim().Equals("") || _Name.Trim().Equals("&nbsp;"))
            {
                this.StrErrorMessage = "Name could not be left Empty";
                return false;

            }
            if (_Code.Replace("___", "").Trim().Equals("") || _Code.Replace("___", "").Trim().Equals(Default) || _Code.Replace("___", "").Equals("&nbsp;"))
            {
                this.StrErrorMessage = "Code Could not be left Empty. Pleas Enter unique Code";
                return false;
            }

            if (_StartDate.Replace("__/__/____","").Trim().Equals("") || _StartDate.Replace("__/__/____","").Trim().Equals("&nbsp;") || _StartDate.Replace("__/__/____","").Trim().Equals(Default))
            {
                this.StrErrorMessage = "Start Date Could not be left Empty.";
                return false;
            }
            if (_EndDate.Replace("__/__/____", "").Trim().Equals("") || _EndDate.Replace("__/__/____", "").Trim().Equals("&nbsp;") || _EndDate.Replace("__/__/____", "").Trim().Equals(Default))
            {
                this.StrErrorMessage = "End Date Could not be left Empty.";
                return false;
            }

            if (_Percentage.Replace("__%", "").Trim().Equals("") || _Code.Replace("__%", "").Trim().Equals(Default) || _Code.Replace("__%", "").Equals("&nbsp;"))
            {
                this.StrErrorMessage = "Please Enter Discount Percentage.";
                return false;
            }
            if (_Type.Trim().Equals(Default) || _Type.Trim().Equals("-1") || _Type.Trim().Equals(""))
            {
                this.StrErrorMessage = "Please Select Discount Type";
                return false;
            }
            return true;
        }

        private bool _VDchkCodeAndPercentage()
        {
            if (_Code.Contains("_") || _Percentage.Contains("_"))
            {
                this.StrErrorMessage = "Please Enter valid Code and percentage.";
                return false;
            }

            try
            { 
                Convert.ToInt32(_Code);
                Convert.ToInt32(_Percentage);
            }
            catch
            { 
                this.StrErrorMessage = "Code and percentage could only contain Numeric characters.please Check.";
                return false;
            }
            return true;


           
        }

        private bool _VDchkActivePackages()
        {
            if (Active == "Y")
            {
                _StartDateFormatted = _StartDate.Substring(6, 4) + "/" + _StartDate.Substring(3, 2) + "/" + _StartDate.Substring(0, 2);
                _EndDateFormatted = _EndDate.Substring(6, 4) + "/" + _EndDate.Substring(3, 2) + "/" + _EndDate.Substring(0, 2);
                DataView dv_count = GetAll(4);
                
                if (dv_count.Count > 0)
                {
                    this.StrErrorMessage = "Only one Package of a certain Type could be Active in a Certain Time Period.";
                    return false;
                }
            }
            return true;
        }
        #endregion
    }
}
