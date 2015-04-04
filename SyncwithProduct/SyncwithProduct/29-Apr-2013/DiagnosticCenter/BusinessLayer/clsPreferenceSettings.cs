using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataLayer;

namespace BusinessLayer
{
    public class clsPreferenceSettings
    {
        clsdbhims objdbhims = new clsdbhims();
        clsoperation objTrans = new clsoperation();

        private const string Default = "~!@";
        private const string TableName = "dc_tpreference_settings";
      
        private string StrError = Default;
        private string _PreferenceID = Default;
        


        public string PreferenceID
        {
            get { return _PreferenceID; }
            set { _PreferenceID = value; }
        }
        private string _PreferenceName = Default;

        public string PreferenceName
        {
            get { return _PreferenceName; }
            set { _PreferenceName = value; }
        }
        private string _PreferenceType = Default;

        public string PreferenceType
        {
            get { return _PreferenceType; }
            set { _PreferenceType = value; }
        }
        private string _Description = Default;

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        private string _path_location = Default;

        public string Path_location
        {
            get { return _path_location; }
            set { _path_location = value; }
        }
        private string _EnteredBy = Default;

        public string EnteredBy
        {
            get { return _EnteredBy; }
            set { _EnteredBy = value; }
        }
        private string _EnteredOn = Default;

        public string EnteredOn
        {
            get { return _EnteredOn; }
            set { _EnteredOn = value; }
        }
        private string _Active = Default;

        public string Active
        {
            get { return _Active; }
            set { _Active = value; }
        }

        


        public DataView GetALL(int flag)
        {
            switch (flag)
            {
                case 1: 
                    objdbhims.Query = "SELECT PreferenceID,PreferenceName,PreferenceType,Description,path_location FROM dc_tpreference_settings WHERE PreferenceType = 'Header' AND Active = '1'";
                    break;
                case 2:
                    objdbhims.Query = "SELECT PreferenceID,PreferenceName,PreferenceType,Description,path_location FROM dc_tpreference_settings WHERE PreferenceType = 'Footer' AND Active = '1'";
                    break;
                case 3:
                    objdbhims.Query = "SELECT PreferenceID,PreferenceName,PreferenceType,Description,path_location,Active FROM dc_tpreference_settings";
                    break;
            }
            return objTrans.DataTrigger_Get_All(objdbhims);
        }

        // PreferenceID,PreferenceName,PreferenceType,Description,path_location,EnteredBy,EnteredOn,Active

        private string[,] MakeArray()
        {
            string[,] arySettings = new string[8, 3];

            if (!this._PreferenceID.Equals(Default))
            {
                arySettings[0, 0] = "PreferenceID";
                arySettings[0, 1] = this._PreferenceID;
                arySettings[0, 2] = "int";
            }

            if (!this._PreferenceName.Equals(Default))
            {
                arySettings[1, 0] = "PreferenceName";
                arySettings[1, 1] = this._PreferenceName;
                arySettings[1, 2] = "string";
            }

            if (!this._PreferenceType.Equals(Default))
            {
                arySettings[2, 0] = "PreferenceType";
                arySettings[2, 1] = this._PreferenceType;
                arySettings[2, 2] = "string";
            }

            if (!this._Description.Equals(Default))
            {
                arySettings[3, 0] = "Description";
                arySettings[3, 1] = this._Description;
                arySettings[3, 2] = "string";
            }

            if (!this._path_location.Equals(Default))
            {
                arySettings[4, 0] = "path_location";
                arySettings[4, 1] = this._path_location;
                arySettings[4, 2] = "string";
            }

           
            if (!this._EnteredBy.Equals(Default))
            {
                arySettings[5, 0] = "EnteredBy";
                arySettings[5, 1] = this._EnteredBy;
                arySettings[5, 2] = "string";
            }
            if (!this._EnteredOn.Equals(Default))
            {
                arySettings[6, 0] = "EnteredOn";
                arySettings[6, 1] = this._EnteredOn;
                arySettings[6, 2] = "datetime";
            }
            if (!this._Active.Equals(Default))
            {
                arySettings[7, 0] = "Active";
                arySettings[7, 1] = this._Active;
                arySettings[7, 2] = "string";
            }
           
            return arySettings;
        }

        public bool Insert()
        {
                QueryBuilder objQB = new QueryBuilder();
                objTrans.Start_Transaction();
                objdbhims.Query = objQB.QBInsert(MakeArray(), TableName);
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

        public bool Update()
        {
                QueryBuilder objQB = new QueryBuilder();
                objTrans.Start_Transaction();

                objdbhims.Query = objQB.QBUpdate(MakeArray(), TableName);
                StrError = objTrans.DataTrigger_Update(objdbhims);

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
    }
}
