using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Odbc;
using DataLayer;

namespace BusinessLayer
{
	public class clsDesignation
	{
		#region Class Variables

		private const string Default = "~!@";
        private const string TableName = "dc_tp_designations";
        private const string TableName2 = "dc_tp_personnel";
        private const string TableName3 = "dc_tp_organization";
		private string StrErrorMessage = "";

        private string _DesignationId = Default;
        private string _OrgId = Default;
		private string _Name = Default;
        private string _Acronym = Default;
		private string _Active = Default;
        private string _Description = Default;
        private string _DOrder = Default;
        private string _DLevel = Default;        
        private string _ClientId = Default;        
        private string _Enteredby = Default;
        private string _Enteredon = Default;

		#endregion

		#region Properties
        public string DesignationId
		{
			get
			{
                return _DesignationId;
			}
			set
			{
                _DesignationId = value;
			}
		}

        public string OrgId
        {
            get
            {
                return _OrgId;
            }
            set
            {
                _OrgId = value;
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

        public string DLevel
        {
            get
            {
                return _DLevel;
            }
            set
            {
                _DLevel = value;
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

		#endregion

		
		clsoperation objTrans = new clsoperation();
		clsdbhims objdbhims = new clsdbhims();

		#region Methods

		public DataView GetAll(int flag)
		{
			switch (flag)
			{
				case 1:
                    objdbhims.Query = "select d.DesignationId,d.Name,d.Acronym,org.Name as OrgName,d.Active from " + TableName + " d left outer join " + TableName3 + " org on d.OrgId = org.OrgId";
                    if (!_OrgId.Equals(Default))
                    {
                        objdbhims.Query += " and d.OrgId = " + _OrgId;
                    }
                    objdbhims.Query += " order by d.Name";
                    break;

				case 2:
                    objdbhims.Query = "select DesignationId,Name,Active from " + TableName + " t ";
                    objdbhims.Query = objdbhims.Query + " Where Upper(t.Name) = '" + this._Name.ToUpper() + "'";
					break;

				case 3:
                    objdbhims.Query = "select DesignationId,OrgId,Name,Acronym,Description,DOrder,DLevel,ClientId,Active from " + TableName + " where DesignationId = " + _DesignationId;
					break;

                case 4:
                    objdbhims.Query = "select t.Name,t.DesignationId from " + TableName + " t where t.Active='Y' order by t.Name";
                    break;

                case 5:
                    objdbhims.Query = "select DesignationId,Acronym,Active from " + TableName + " t ";
                    objdbhims.Query = objdbhims.Query + " Where Upper(t.Acronym) = '" + this._Acronym.ToUpper() + "'";
                    break;

                case 6:
                    objdbhims.Query = "select DesignationId,DOrder from " + TableName + " t ";
                    objdbhims.Query = objdbhims.Query + " Where DOrder = '" + this._DOrder + "'";
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

                    objdbhims.Query = objQB.QBGetMax("DesignationId", TableName);
                    this._DesignationId = objTrans.DataTrigger_Get_Max(objdbhims);

                    if (!this._DesignationId.Equals("True"))
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
			string[,] arySAPS = new string[11, 3];

			if (!this._DesignationId.Equals(Default))
			{
                arySAPS[0, 0] = "DesignationId";
                arySAPS[0, 1] = this._DesignationId;
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

            if (!this._Description.Equals(Default))
            {
                arySAPS[5, 0] = "Description";
                arySAPS[5, 1] = this._Description;
                arySAPS[5, 2] = "string";
            }

            if (!this._Acronym.Equals(Default))
            {
                arySAPS[6, 0] = "Acronym";
                arySAPS[6, 1] = this._Acronym;
                arySAPS[6, 2] = "string";
            }

            if (!this._DOrder.Equals(Default))
            {
                arySAPS[7, 0] = "DOrder";
                arySAPS[7, 1] = this._DOrder;
                arySAPS[7, 2] = "int";
            }

            if (!this._DLevel.Equals(Default))
            {
                arySAPS[8, 0] = "DLevel";
                arySAPS[8, 1] = this._DLevel;
                arySAPS[8, 2] = "int";
            }            

            if (!this._ClientId.Equals(Default))
            {
                arySAPS[9, 0] = "ClientId";
                arySAPS[9, 1] = this._ClientId;
                arySAPS[9, 2] = "string";
            }

            if (!this._OrgId.Equals(Default))
            {
                arySAPS[10, 0] = "OrgId";
                arySAPS[10, 1] = this._OrgId;
                arySAPS[10, 2] = "string";
            }
           
            return arySAPS;
		}

		#endregion    

		#region "Validation Functions"

		private bool Validation()
		{
			if (!VD_Designation())
			{
				return false;
			}

            if (!VD_Organization())
            {
                return false;
            }

            if (!VD_Acronym())
            {
                return false;
            }

            if (!VD_DOrder())
            {
                return false;
            }

			return true;
		}

        public bool VD_Designation()
		{

			if (this._Name.Equals(""))
			{
				this.StrErrorMessage = "Please Enter Designation Name. (empty is not allowed)";
				return false;
			}

			DataView dvTest = GetAll(2);

            if (!this._DesignationId.Equals(Default))
			{
                dvTest.RowFilter = "DesignationId <> '" + _DesignationId + "' And Name = '" + _Name + "'";
			}
			else
			{
                dvTest.RowFilter = "Name = '" + _Name + "'";
			}

			if (dvTest.Count > 0)
			{
                this.StrErrorMessage = "Please Enter another Designation Name, it is already present.";
				return false;
			}

			return true;
		}

        public bool VD_Organization()
        {
            if (this._OrgId.Equals(Default))
            {
                this.StrErrorMessage = "Please Select Organization First. (empty is not allowed)";
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

                if (!this._DesignationId.Equals(Default))
                {
                    dvTest.RowFilter = "DesignationId <> '" + _DesignationId + "' And Acronym = '" + _Acronym + "'";
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

            if (!this._DOrder.Equals("") && !this._DOrder.Equals(Default))
            {
                DataView dvTest = GetAll(6);

                if (!this._DesignationId.Equals(Default))
                {
                    dvTest.RowFilter = "DesignationId <> '" + _DesignationId + "' And DOrder = '" + _DOrder + "'";
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

		#endregion

	}
}

