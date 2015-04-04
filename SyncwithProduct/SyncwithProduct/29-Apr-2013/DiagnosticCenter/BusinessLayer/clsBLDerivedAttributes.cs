using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer;
using System.Data;
namespace BusinessLayer
{
    public class clsBLDerivedAttributes
    {
        public clsBLDerivedAttributes()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region Variables
        private const string Default = "~!@";
        private const string TableName = "LS_TDerivedAttributes";
        private string StrErrorMessage = "";
        private string StrAttributeID = Default;
        private string StrDerivedID = Default;
        private string StrFormula = Default;
        private string StrAttributeName = Default;
        private string StrDescription = Default;
        private string StrEnteredBy = Default;
        private string StrEnteredOn = Default;
        private string StrClientID = Default;
        private string StrMlValue = Default;
        private string StrFmlValue = Default;
        private string StrTestID = Default;

        #endregion

        #region Properties
        public string DerivedID
        {
            get { return StrDerivedID; }
            set { StrDerivedID = value; }
        }

        public string AttributeID
        {
            get { return StrAttributeID; }
            set { StrAttributeID = value; }
        }

        public string AttributeName
        {
            get { return StrAttributeName; }
            set { StrAttributeName = value; }
        }
        public string ErrorMessage
        {
            get { return StrErrorMessage; }
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

        public string Formula
        {
            get { return StrFormula; }
            set { StrFormula = value; }
        }
        public string Description
        {
            get { return StrDescription; }
            set { StrDescription = value; }
        }

        public string ClientID
        {
            get { return StrClientID; }
            set { StrClientID = value; }
        }

        public string MlValue
        {
            get { return StrMlValue; }
            set { StrMlValue = value; }
        }
        public string FmlValue
        {
            get { return StrFmlValue; }
            set { StrFmlValue = value; }
        }
        public string TestID
        {
            get { return StrTestID; }
            set { StrTestID = value; }
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
                    objdbhims.Query = " Select DerivedID,Description,Formula,GenderValue_M,GenderValue_F From LS_TDerivedAttributes where AttributeID='" + StrAttributeID + "'";
                    break;
                case 2:
                    objdbhims.Query = "Select Max(DerivedID) DerivedID From LS_TDerivedAttributes";
                    break;
                case 3:
                    objdbhims.Query = " Select DerivedID,Description,Formula From LS_TDerivedAttributes where TestID='" + StrTestID + "'";
                    break;
            }
            return objTrans.DataTrigger_Get_All(objdbhims);

        }
        public bool Update()
        {
            try
            {

                QueryBuilder objQB = new QueryBuilder();

                if (this.StrDerivedID == null || this.StrDerivedID == Default)
                {
                    objdbhims.Query = "Select DerivedID From LS_TDerivedAttributes where AttributeID='" + this.StrAttributeID + "'";
                    objTrans.Start_Transaction();
                    DataView dv_Derived = objTrans.DataTrigger_Get_All(objdbhims);
                    if (dv_Derived.Count > 0)
                    {
                        this.StrDerivedID = dv_Derived[0]["DerivedID"].ToString();
                        dv_Derived.Dispose();
                        objdbhims.Query = objQB.QBUpdate(MakeArray(), TableName);
                        objTrans.Start_Transaction();
                        this.StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);
                        if (this.StrErrorMessage.Equals("True"))
                        {
                            this.StrErrorMessage = objTrans.OperationError;
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
                        //this.StrErrorMessage = "No DerivedID found with this AttributeID('" + StrAttributeID + "')";
                        objTrans.End_Transaction();
                        bool issuccessful = insert();
                        return issuccessful;

                        //return false;

                    }
                }
                else
                {
                    objdbhims.Query = objQB.QBUpdate(MakeArray(), TableName);
                    objTrans.Start_Transaction();
                    this.StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);
                    if (this.StrErrorMessage.Equals("True"))
                    {
                        this.StrErrorMessage = objTrans.OperationError;
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
            catch (Exception ee)
            {
                this.StrErrorMessage = ee.ToString();
                return false;
            }
        }

        public bool insert()
        {
            try
            {
                QueryBuilder objQB = new QueryBuilder();

                objTrans.Start_Transaction();

                objdbhims.Query = objQB.QBGetMax("DERIVEDID", TableName);
                this.StrDerivedID = objTrans.DataTrigger_Get_Max(objdbhims);
                if (this.StrDerivedID.Equals("True"))
                {
                    this.StrErrorMessage = objTrans.OperationError;
                    objTrans.End_Transaction();
                    return false;
                }
                else
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
                        objTrans.End_Transaction();
                        return true;
                    }
                }

            }
            catch (Exception ee)
            {
                this.StrErrorMessage = ee.ToString();
                return false;
            }


        }

        public void update_Acronyms()
        {
            objdbhims.Query = "Update Ls_TDerivedAttributes Set";
        }

        private string[,] MakeArray()
        {
            string[,] AryDerivedAttribute = new string[11, 3];
            if (!StrDerivedID.Equals(Default))
            {
                AryDerivedAttribute[0, 0] = "DerivedID";
                AryDerivedAttribute[0, 1] = StrDerivedID;
                AryDerivedAttribute[0, 2] = "int";
            }
            if (!StrAttributeID.Equals(Default))
            {
                AryDerivedAttribute[1, 0] = "AttributeID";
                AryDerivedAttribute[1, 1] = StrAttributeID;
                AryDerivedAttribute[1, 2] = "int";
            }
            if (!StrAttributeName.Equals(Default))
            {
                AryDerivedAttribute[2, 0] = "AttributeName";
                AryDerivedAttribute[2, 1] = StrAttributeName;
                AryDerivedAttribute[2, 2] = "string";
            }
            if (!StrDescription.Equals(Default))
            {
                AryDerivedAttribute[3, 0] = "Description";
                AryDerivedAttribute[3, 1] = StrDescription;
                AryDerivedAttribute[3, 2] = "string";
            }
            if (!StrFormula.Equals(Default))
            {
                AryDerivedAttribute[4, 0] = "Formula";
                AryDerivedAttribute[4, 1] = StrFormula;
                AryDerivedAttribute[4, 2] = "string";
            }

            if (!StrEnteredBy.Equals(Default))
            {
                AryDerivedAttribute[5, 0] = "EnteredBy";
                AryDerivedAttribute[5, 1] = StrEnteredBy;
                AryDerivedAttribute[5, 2] = "int";
            }

            if (!StrEnteredOn.Equals(Default))
            {
                AryDerivedAttribute[6, 0] = "EnteredOn";
                AryDerivedAttribute[6, 1] = StrEnteredOn;
                AryDerivedAttribute[6, 2] = "datetime";
            }
            if (!StrClientID.Equals(Default))
            {
                AryDerivedAttribute[7, 0] = "ClientID";
                AryDerivedAttribute[7, 1] = StrClientID;
                AryDerivedAttribute[7, 2] = "string";
            }

            if (!StrMlValue.Equals(Default) && !StrMlValue.Equals(""))
            {
                AryDerivedAttribute[8, 0] = "GenderValue_M";
                AryDerivedAttribute[8, 1] = StrMlValue;
                AryDerivedAttribute[8, 2] = "int";
            }
            if (!StrFmlValue.Equals(Default) && !StrFmlValue.Equals(""))
            {
                AryDerivedAttribute[9, 0] = "GenderValue_F";
                AryDerivedAttribute[9, 1] = StrFmlValue;
                AryDerivedAttribute[9, 2] = "int";
            }
            if (!StrTestID.Equals(Default) && !StrTestID.Equals(""))
            {
                AryDerivedAttribute[10, 0] = "TestID";
                AryDerivedAttribute[10, 1] = StrTestID;
                AryDerivedAttribute[10, 2] = "int";
            }


            return AryDerivedAttribute;

        }
        #endregion
    }
}
