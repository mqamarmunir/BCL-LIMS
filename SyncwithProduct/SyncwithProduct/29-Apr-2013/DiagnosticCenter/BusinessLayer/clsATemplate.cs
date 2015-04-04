using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Odbc;
using DataLayer;

namespace BusinessLayer
{
	public class clsATemplate
	{
		#region Class Variables

		private const string Default = "~!@";
        private const string TableName = "dc_tp_atemplates";
        private const string TableName2 = "dc_tp_personnel";
        private const string TableName3 = "dc_tp_attributes";
		private string StrErrorMessage = "";

        private string _TemplateId = Default;
        private string _AttributeId = Default;
        private string _PersonId = Default;
        private string _Description = Default;
        private string _Defaultt = Default;
		private string _Active = Default;               
        private string _ClientId = Default;        
        private string _Enteredby = Default;
        private string _Enteredon = Default;

        private string _TestID = Default;
        private string _SubDepartmentID = Default;

		#endregion

		#region Properties

        public string TemplateId
        {
            get
            {
                return _TemplateId;
            }
            set
            {
                _TemplateId = value;
            }
        }

        public string AttributeId
		{
			get
			{
                return _AttributeId;
			}
			set
			{
                _AttributeId = value;
			}
		}

        public string PersonId
        {
            get
            {
                return _PersonId;
            }
            set
            {
                _PersonId = value;
            }
        }

        public string Description
		{
			get
			{
				return _Description;
			}
			set
			{
                _Description = value;
			}
		}

        public string Defaultt
        {
            get
            {
                return _Defaultt;
            }
            set
            {
                _Defaultt = value;
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

        public string TestID
        {
            get { return _TestID; }
            set { _TestID = value; }
        }
        public string SubDepartmentID
        {
            get { return _SubDepartmentID; }
            set { _SubDepartmentID = value; }
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
                    objdbhims.Query = "select t.TemplateId,a.Attribute_Name,concat(p.FName,' ',p.MName,' ',p.LName) as PersonName,t.Description,t.Defaultt,t.Active from " + TableName + " t left outer join " + TableName2 + " p on t.PersonId = p.PersonId left outer join " + TableName3 + " a on t.AttributeId = a.AttributeId where 1 = 1";
                    if (!_AttributeId.Equals(Default))
                    {
                        objdbhims.Query += " and t.AttributeId = " + _AttributeId;
                    }
                    if (!_PersonId.Equals(Default))
                    {
                        objdbhims.Query += " and t.PersonId = " + _PersonId;
                    }
                    objdbhims.Query += " order by a.Attribute_Name";
                    break;

				case 2:
                    objdbhims.Query = "select TemplateId,Description,Active from " + TableName + " t ";
                    objdbhims.Query = objdbhims.Query + " Where Upper(t.Description) = '" + this._Description.ToUpper() + "'";
					break;

				case 3:
                    objdbhims.Query = "select TemplateId,AttributeId,PersonId,Description,ClientId,Defaultt,Active from " + TableName + " where TemplateId = " + _TemplateId;
					break;       
                case 4: // subdepartment drop down
                    objdbhims.Query = "select subdepartmentid,name from dc_tp_subdepartments where active='Y'";
                    break;
                case 5: // test drop down
                    objdbhims.Query = "select testid,test_name as name from dc_tp_test where active='Y' ";
                    if (!_SubDepartmentID.Equals(Default) && !_SubDepartmentID.Equals("") && !_SubDepartmentID.Equals("-1"))
                        objdbhims.Query += " and subdepartmentid="+_SubDepartmentID+"";
                    break;
                case 6: // check default validation
                    objdbhims.Query = "select templateid from "+TableName+" where defaultt='Y' and attributeid="+_AttributeId+"";
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

                    objdbhims.Query = objQB.QBGetMax("TemplateId", TableName);
                    this._TemplateId = objTrans.DataTrigger_Get_Max(objdbhims);

                    if (!this._TemplateId.Equals("True"))
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
			string[,] arySAPS = new string[9, 3];

			if (!this._TemplateId.Equals(Default))
			{
                arySAPS[0, 0] = "TemplateId";
                arySAPS[0, 1] = this._TemplateId;
                arySAPS[0, 2] = "int";
			}

            if (!this._AttributeId.Equals(Default))
            {
                arySAPS[1, 0] = "AttributeId";
                arySAPS[1, 1] = this._AttributeId;
                arySAPS[1, 2] = "int";
            }

            if (!this._PersonId.Equals(Default))
            {
                arySAPS[2, 0] = "PersonId";
                arySAPS[2, 1] = this._PersonId;
                arySAPS[2, 2] = "int";
            }

			if (!this._Description.Equals(Default))
			{
                arySAPS[3, 0] = "Description";
                arySAPS[3, 1] = this._Description;
                arySAPS[3, 2] = "string";
			}

            if (!this._Active.Equals(Default))
            {
                arySAPS[4, 0] = "Active";
                arySAPS[4, 1] = this.Active;
                arySAPS[4, 2] = "string";
            }

            if (!this._Enteredby.Equals(Default))
            {
                arySAPS[5, 0] = "Enteredby";
                arySAPS[5, 1] = this._Enteredby;
                arySAPS[5, 2] = "int";
            }

			if (!this._Enteredon.Equals(Default))
			{
                arySAPS[6, 0] = "Enteredon";
                arySAPS[6, 1] = this._Enteredon;
                arySAPS[6, 2] = "datetime";
			}

            if (!this._Defaultt.Equals(Default))
            {
                arySAPS[7, 0] = "Defaultt";
                arySAPS[7, 1] = this._Defaultt;
                arySAPS[7, 2] = "string";
            }
                        
            if (!this._ClientId.Equals(Default))
            {
                arySAPS[8, 0] = "ClientId";
                arySAPS[8, 1] = this._ClientId;
                arySAPS[8, 2] = "string";
            }           

            return arySAPS;
		}

		#endregion    

		#region "Validation Functions"

		private bool Validation()
		{
			if (!VD_Template())
			{
				return false;
			}
           
            if (!VD_Attribute())
            {
                return false;
            }            

			return true;
		}

        public bool VD_Template()
		{

			if (this._Description.Equals(""))
			{
                this.StrErrorMessage = "Please Enter Description. (empty is not allowed)";
				return false;
			}

            //DataView dvTest = GetAll(2);

            //if (!this._TemplateId.Equals(Default))
            //{
            //    dvTest.RowFilter = "TemplateId <> '" + _TemplateId + "' And Description = '" + _Description + "'";
            //}
            //else
            //{
            //    dvTest.RowFilter = "Description = '" + _Description + "'";
            //}

            //if (dvTest.Count > 0)
            //{
            //    this.StrErrorMessage = "Please Enter another Description, it is already present.";
            //    return false;
            //}

            if (_Defaultt.Equals("Y"))
            {
                DataView dvDft = GetAll(6);

                if (dvDft.Count > 0)
                {
                    if (!this._TemplateId.Equals(Default) && !this._TemplateId.Equals("") && this._TemplateId != null)
                        dvDft.RowFilter = "templateid<>" + _TemplateId + "";
                    if (dvDft.Count > 0)
                    {
                        StrErrorMessage = "Default template already exist.";
                        return false;
                    }
                    else
                        return true;
                }
                else
                {
                    return true;
                }
            }

			return true;
		}

        public bool VD_Attribute()
        {
            if (this._AttributeId.Equals(Default))
            {
                this.StrErrorMessage = "Please Select Attribute First. (empty is not allowed)";
                return false;
            }
            return true;
        }     

		#endregion

	}
}


