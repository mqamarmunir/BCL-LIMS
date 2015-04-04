using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Odbc;
using DataLayer;

namespace BusinessLayer
{
	public class clsStudyD
	{
		#region Class Variables

		private const string Default = "~!@";
        private const string TableName = "dc_tp_studyd";
        private const string TableName2 = "dc_tp_personnel";
        private const string TableName3 = "dc_tp_studym";
        private const string TableName4 = "dc_tp_test";
         
		private string StrErrorMessage = "";

        private string _StudyId = Default;       
        private string _StudyDId = Default;        
        private string _TestId = Default;        
        private string _ClientId = Default;
        private string _Active = Default;      
        private string _Enteredby = Default;
        private string _Enteredon = Default;

		#endregion

		#region Properties

        public string StudyDId
        {
            get
            {
                return _StudyDId;
            }
            set
            {
                _StudyDId = value;
            }
        }       

        public string StudyId
        {
            get
            {
                return _StudyId;
            }
            set
            {
                _StudyId = value;
            }
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

		#endregion

		
		clsoperation objTrans = new clsoperation();
		clsdbhims objdbhims = new clsdbhims();

		#region Methods

		public DataView GetAll(int flag)
		{
			switch (flag)
			{
				case 1:
                    objdbhims.Query = "select s.StudyDId,sm.Study_Name,t.Test_Name,s.Active from " + TableName + " s left outer join " + TableName3 + " sm on s.StudyId = sm.StudyId left outer join " + TableName4 + " t on s.TestId = t.TestId where 1 = 1";
                    if (!_StudyId.Equals(Default))
                    {
                        objdbhims.Query += " and s.StudyId = " + _StudyId;
                    }                    
                    if (!_TestId.Equals(Default))
                    {
                        objdbhims.Query += " and s.TestId = " + _TestId;
                    }
                    objdbhims.Query += " order by sm.Study_Name";
                    break;

                //case 2:
                //    objdbhims.Query = "select StudyId,Test_Name from " + TableName + " t ";
                //    objdbhims.Query = objdbhims.Query + " Where Upper(t.Test_Name) = '" + this._Test_Name.ToUpper() + "'";
                //    break;

				case 3:
                    objdbhims.Query = "select StudyDId,StudyId,TestId,Active,ClientId from " + TableName + " where StudyDId = " + _StudyDId;
					break;

                //case 4:
                //    objdbhims.Query = "select t.Test_Name,t.StudyId from " + TableName + " t where t.Active='Y'";
                //    if (!_DepartmentId.Equals(Default))
                //    {
                //        objdbhims.Query += " and t.DepartmentId = " + _DepartmentId;
                //    }
                //    if (!_GroupId.Equals(Default))
                //    {
                //        objdbhims.Query += " and t.GroupId = " + _GroupId;
                //    }
                //    if (!_TestId.Equals(Default))
                //    {
                //        objdbhims.Query += " and t.TestId = " + _TestId;
                //    }
                //    objdbhims.Query += " order by t.Name";
                //    break;

                //case 6:
                //    objdbhims.Query = "select StudyId,DOrder from " + TableName + " t ";
                //    objdbhims.Query = objdbhims.Query + " Where DOrder = '" + this._DOrder + "'";
                //    break;     
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

                    objdbhims.Query = objQB.QBGetMax("StudyDId", TableName);
                    this._StudyDId = objTrans.DataTrigger_Get_Max(objdbhims);

                    if (!this._StudyDId.Equals("True"))
                    {
                        objdbhims.Query = objQB.QBInsert(MakeArray(), TableName);
                        this.StrErrorMessage = objTrans.DataTrigger_Insert(objdbhims);

                        objTrans.End_Transaction();

                        if (this.StrErrorMessage.Equals("True"))
                        {
                            this.StrErrorMessage = objTrans.OperationError;
                            return false;
                        }
                        else
                        {
                            return true;
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

		public bool Update()
		{
			if (Validation())
			{
				clsoperation objTrans = new clsoperation();
				QueryBuilder objQB = new QueryBuilder();

				objTrans.Start_Transaction();
				objdbhims.Query = objQB.QBUpdate(MakeArray(), TableName);
				this.StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);
				objTrans.End_Transaction();

				if (this.StrErrorMessage.Equals("True"))
				{
					this.StrErrorMessage = objTrans.OperationError;
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
			string[,] arySAPS = new string[7, 3];

            if (!this._StudyDId.Equals(Default))
            {
                arySAPS[0, 0] = "StudyDId";
                arySAPS[0, 1] = this._StudyDId;
                arySAPS[0, 2] = "int";
            } 

            if (!this._StudyId.Equals(Default))
			{
                arySAPS[1, 0] = "StudyId";
                arySAPS[1, 1] = this._StudyId;
                arySAPS[1, 2] = "int";
			}            

            if (!this._TestId.Equals(Default))
            {
                arySAPS[2, 0] = "TestId";
                arySAPS[2, 1] = this._TestId;
                arySAPS[2, 2] = "int";
            }

            if (!this._Active.Equals(Default))
            {
                arySAPS[3, 0] = "Active";
                arySAPS[3, 1] = this._Active;
                arySAPS[3, 2] = "string";
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
                arySAPS[6, 0] = "ClientId";
                arySAPS[6, 1] = this._ClientId;
                arySAPS[6, 2] = "string";
            }
           
            return arySAPS;
		}

		#endregion    

		#region "Validation Functions"

		private bool Validation()
		{            
            if (!VD_Study())
            {
                return false;
            } 

            if (!VD_Test())
            {
                return false;
            }            

			return true;
		}
       

        public bool VD_Study()
        {
            if (this._StudyId.Equals(Default))
            {
                this.StrErrorMessage = "Please Select Study First. (empty is not allowed)";
                return false;
            }
            return true;
        }    

        public bool VD_Test()
        {
            if (this._TestId.Equals(Default))
            {
                this.StrErrorMessage = "Please Select Test First. (empty is not allowed)";
                return false;
            }
            return true;
        }       

		#endregion

	}
}

