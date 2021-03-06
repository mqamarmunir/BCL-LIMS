using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Odbc;
using DataLayer;

namespace BusinessLayer
{
	public class clsSubDepartment
	{
		#region Class Variables

		private const string Default = "~!@";
        private const string TableName = "dc_tp_subdepartments";
        private const string TableName2 = "dc_tp_personnel"; 
        private const string TableName3 = "dc_tp_departments";               
		private string StrErrorMessage = "";

        private string _SubdepartmentId = Default;
        private string _DepartmentId = Default;
		private string _Name = Default;
        private string _Acronym = Default;
		private string _Active = Default;
        private string _HOD = Default;
        private string _Type = Default;
        private string _PhoneNo = Default;
        private string _FaxNo = Default;
        private string _Email = Default;        
        private string _Address = Default;
        private string _ClientId = Default;        
        private string _Enteredby = Default;
        private string _Enteredon = Default;
        private string _Dorder = Default;

		#endregion

		#region Properties

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

        public string DepartmentId
        {
            get
            {
                return _DepartmentId;
            }
            set
            {
                _DepartmentId = value;
            }
        }       

        public string Name
		{
			get
			{
				return _Name;
			}
			set
			{
                _Name = value;
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

        public string HOD
        {
            get
            {
                return _HOD;
            }
            set
            {
                _HOD = value;
            }
        }

        public string Type
        {
            get
            {
                return _Type;
            }
            set
            {
                _Type = value;
            }
        }

        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
            }
        }

        public string PhoneNo
        {
            get
            {
                return _PhoneNo;
            }
            set
            {
                _PhoneNo = value;
            }
        }

        public string FaxNo
        {
            get
            {
                return _FaxNo;
            }
            set
            {
                _FaxNo = value;
            }
        }
       
        public string Address
        {
            get
            {
                return _Address;
            }
            set
            {
                _Address = value;
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

        public string Dorder
        {
            get { return _Dorder; }
            set { _Dorder = value; }
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
                    objdbhims.Query = "select sd.SubdepartmentId,sd.DepartmentId,sd.Name,sd.Acronym,d.Name as DeptName,sd.Active,sd.dorder from " + TableName + " sd left outer join " + TableName3 + " d on sd.DepartmentId = d.DepartmentId where 1 = 1";
                    if (!_DepartmentId.Equals(Default))
                    {
                        objdbhims.Query += " and sd.DepartmentId = " + _DepartmentId;
                    }
                    objdbhims.Query += " order by sd.dorder";
                    break;

				case 2:
                    objdbhims.Query = "select SubdepartmentId,Name,Active from " + TableName + " t ";
                    objdbhims.Query = objdbhims.Query + " Where Upper(t.Name) = '" + this._Name.ToUpper() + "'";
					break;

				case 3:
                    objdbhims.Query = "select SubdepartmentId,DepartmentId,Name,Acronym,HOD,Type,PhoneNo,FaxNo,Email,Address,ClientId,Active,dorder from " + TableName + " where SubdepartmentId = " + _SubdepartmentId;
					break;

                case 4:
                    objdbhims.Query = "select t.Name,t.SubdepartmentId from " + TableName + " t where t.Active='Y'";
                    if (!_DepartmentId.Equals(Default))
                    {
                        objdbhims.Query += " and t.DepartmentId = " + _DepartmentId;
                    }
                    objdbhims.Query += " order by t.Name";
                    break;

                case 5:
                    objdbhims.Query = "select SubdepartmentId,Acronym,Active from " + TableName + " t ";
                    objdbhims.Query = objdbhims.Query + " Where Upper(t.Acronym) = '" + this._Acronym.ToUpper() + "'";
                    break;

                case 6:
                    objdbhims.Query = "select Email from " + TableName + " where SubdepartmentId = " + _SubdepartmentId;
                    break;

                case 7:
                    objdbhims.Query = "select DepartmentId from " + TableName + " where SubdepartmentId = " + _SubdepartmentId;
                    break;

                case 8:
                    objdbhims.Query = "Select * From " + TableName + " where Active='Y'";
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

                    objdbhims.Query = objQB.QBGetMax("SubdepartmentId", TableName);
                    this._SubdepartmentId = objTrans.DataTrigger_Get_Max(objdbhims);

                    if (!this._SubdepartmentId.Equals("True"))
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
			string[,] arySAPS = new string[15, 3];

			if (!this._SubdepartmentId.Equals(Default))
			{
                arySAPS[0, 0] = "SubdepartmentId";
                arySAPS[0, 1] = this._SubdepartmentId;
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
                arySAPS[3, 2] = "string";
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

            if (!this._Email.Equals(Default))
            {
                arySAPS[7, 0] = "Email";
                arySAPS[7, 1] = this._Email;
                arySAPS[7, 2] = "string";
            }

            if (!this._FaxNo.Equals(Default))
            {
                arySAPS[8, 0] = "FaxNo";
                arySAPS[8, 1] = this._FaxNo;
                arySAPS[8, 2] = "string";
            }

            if (!this._HOD.Equals(Default))
            {
                arySAPS[9, 0] = "HOD";
                arySAPS[9, 1] = this._HOD;
                arySAPS[9, 2] = "int";
            }

            if (!this._Address.Equals(Default))
            {
                arySAPS[10, 0] = "Address";
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

            if (!this._DepartmentId.Equals(Default))
            {
                arySAPS[13, 0] = "DepartmentId";
                arySAPS[13, 1] = this._DepartmentId;
                arySAPS[13, 2] = "int";
            }
            if (!this._Dorder.Equals(Default))
            {
                arySAPS[14, 0] = "dorder";
                arySAPS[14, 1] = this._Dorder;
                arySAPS[14, 2] = "int";
            }
            else
            {
                arySAPS[14, 0] = "dorder";
                arySAPS[14, 1] = "null";
                arySAPS[14, 2] = "int";
            }


            return arySAPS;
		}

		#endregion    

		#region "Validation Functions"

		private bool Validation()
		{
            if (!VD_SubDepartment())
			{
				return false;
			}

            if (!VD_DepartmentId())
            {
                return false;
            }

            if (!VD_Acronym())
            {
                return false;
            }

			return true;
		}

        public bool VD_SubDepartment()
		{

			if (this._Name.Equals(""))
			{
                this.StrErrorMessage = "Please Enter Sub Department Name. (empty is not allowed)";
				return false;
			}

			DataView dvTest = GetAll(2);

            if (!this._SubdepartmentId.Equals(Default))
			{
                dvTest.RowFilter = "SubdepartmentId <> '" + _SubdepartmentId + "' And Name = '" + _Name + "'";
			}
			else
			{
                dvTest.RowFilter = "Name = '" + _Name + "'";
			}

			if (dvTest.Count > 0)
			{
                this.StrErrorMessage = "Please Enter another Sub Department Name, it is already present.";
				return false;
			}

			return true;
		}

        public bool VD_DepartmentId()
        {
            if (this._DepartmentId.Equals(Default))
            {
                this.StrErrorMessage = "Please Select Department First. (empty is not allowed)";
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

                if (!this._SubdepartmentId.Equals(Default))
                {
                    dvTest.RowFilter = "SubdepartmentId <> '" + _SubdepartmentId + "' And Acronym = '" + _Acronym + "'";
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

		#endregion

	}
}

