using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataLayer;

namespace BusinessLayer
{
    public class clsBLPreferenceSettings
    {
        public clsBLPreferenceSettings()
        {
            /// Add Constructor logic here...
        }

        #region Variables

        private const string TableName = "dc_tp_preferencesettings";
        private const string Default="~!@";



        private string StrErrorMessage = "";

       

    
         private string _PreferenceID = Default;



     
        private string _BranchText = Default;
        private string _PrintBranches = Default;
        private string _PrintPathologists = Default;
        private string _PrintPanelText = Default;
        private string _PrintGeneralComments = Default;
        private string _GeneralComments = Default;
        private string _Printrecieptonspecimen = Default;
        private string _Recordsperpage_cashrec = Default;
        private string _Onbookingcashcollection = Default;
        private string _Roundingofffactor = Default;
        private string _loginInstructions = Default;

       
       
        


        
        private string _ClientId = Default;
        private string _Enteredby = Default;
        private string _Enteredon = Default;
 

   


      

        clsoperation objTrans = new clsoperation();
        clsdbhims objdbhims = new clsdbhims();

        #endregion

        #region Properties
        public string LoginInstructions
        {
            get { return _loginInstructions; }
            set { _loginInstructions = value; }
        }
       
        public string Roundingofffactor
        {
            get { return _Roundingofffactor; }
            set { _Roundingofffactor = value; }
        }
        public string Onbookingcashcollection
        {
            get { return _Onbookingcashcollection; }
            set { _Onbookingcashcollection = value; }
        }
        public string Recordsperpage_cashrec
        {
            get { return _Recordsperpage_cashrec; }
            set { _Recordsperpage_cashrec = value; }
        }
        
        public string PreferenceID
        {
            get { return _PreferenceID; }
            set { _PreferenceID = value; }
        }
        public string BranchText
        {
            get { return _BranchText; }
            set { _BranchText = value; }
        }
        public string PrintBranches
        {
            get { return _PrintBranches; }
            set { _PrintBranches = value; }
        }
        public string PrintPathologists
        {
            get { return _PrintPathologists; }
            set { _PrintPathologists = value; }
        }
        public string PrintPanelText
        {
            get { return _PrintPanelText; }
            set { _PrintPanelText = value; }
        }
        public string PrintGeneralComments
        {
            get { return _PrintGeneralComments; }
            set { _PrintGeneralComments = value; }
        }
        public string GeneralComments
        {
            get { return _GeneralComments; }
            set { _GeneralComments = value; }
        }
        public string Printrecieptonspecimen
        {
            get { return _Printrecieptonspecimen; }
            set { _Printrecieptonspecimen = value; }
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
                    objdbhims.Query = @"Select * From " + TableName;
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

                    objdbhims.Query = objQB.QBGetMax("PreferenceID", TableName);
                    this._PreferenceID = objTrans.DataTrigger_Get_Max(objdbhims);

                    if (!this._PreferenceID.Equals("True"))
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
            string[,] arySAPS = new string[15, 3];

            if (!this._PreferenceID.Equals(Default))
            {
                arySAPS[0, 0] = "PreferenceID";
                arySAPS[0, 1] = this._PreferenceID;
                arySAPS[0, 2] = "int";
            }

            if (!this._BranchText.Equals(Default))
            {
                arySAPS[1, 0] = "PrintTestComents";
                arySAPS[1, 1] = this._BranchText;
                arySAPS[1, 2] = "string";
            }

            if (!this._PrintBranches.Equals(Default))
            {
                arySAPS[2, 0] = "PrintBranches";
                arySAPS[2, 1] = this._PrintBranches;
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

            if (!this._PrintPathologists.Equals(Default))
            {
                arySAPS[5, 0] = "PrintPathologists";
                arySAPS[5, 1] = this._PrintPathologists;
                arySAPS[5, 2] = "string";
            }

            if (!this._PrintPanelText.Equals(Default))
            {
                arySAPS[6, 0] = "PrintPanelText";
                arySAPS[6, 1] = this._PrintPanelText;
                arySAPS[6, 2] = "string";
            }

            if (!this._PrintGeneralComments.Equals(Default))
            {
                arySAPS[7, 0] = "PrintGeneralComments";
                arySAPS[7, 1] = this._PrintGeneralComments;
                arySAPS[7, 2] = "string";
            }

            if (!this._ClientId.Equals(Default))
            {
                arySAPS[8, 0] = "ClientId";
                arySAPS[8, 1] = this._ClientId;
                arySAPS[8, 2] = "string";
            }
            if (!this._GeneralComments.Equals(Default))
            {
                arySAPS[9, 0] = "GeneralComments";
                arySAPS[9, 1] = this._GeneralComments;
                arySAPS[9, 2] = "string";
            }
            if (!this._Printrecieptonspecimen.Equals(Default))
            {
                arySAPS[10, 0] = "Printrecieptonspecimen";
                arySAPS[10, 1] = this._Printrecieptonspecimen;
                arySAPS[10, 2] = "string";
            }
            if (!this._Recordsperpage_cashrec.Equals(Default))
            {
                arySAPS[11, 0] = "Recordsperpage_cashrec";
                arySAPS[11, 1] = this._Recordsperpage_cashrec;
                arySAPS[11, 2] = "int";

            }
            if (!this._Onbookingcashcollection.Equals(Default))
            {
                arySAPS[12, 0] = "Onbookingcashcollection";
                arySAPS[12, 1] = this._Onbookingcashcollection;
                arySAPS[12, 2] = "int";
            }
            if (!this._Roundingofffactor.Equals(Default))
            {
                arySAPS[13, 0] = "RoundOfffactor";
                arySAPS[13, 1] = this._Roundingofffactor;
                arySAPS[13, 2] = "int";
            }
            if (!this._loginInstructions.Equals(Default))
            {
                arySAPS[14, 0] = "loginInstructions";
                arySAPS[14, 1] = this._loginInstructions;
                arySAPS[14, 2] = "string";
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
