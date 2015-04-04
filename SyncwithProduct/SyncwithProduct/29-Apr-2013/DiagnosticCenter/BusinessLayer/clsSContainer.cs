using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Odbc;
using DataLayer;

namespace BusinessLayer
{
	public class clsSContainer
	{
		#region Class Variables

		private const string Default = "~!@";
        private const string TableName = "dc_tp_scontainer";
        private const string TableName2 = "dc_tp_personnel";
        private const string TableName3 = "dc_tp_stype";
		private string StrErrorMessage = "";

        private string _SContainerId = Default;
        private string _SpecimenId = Default;
        private string _Container_Name = Default;
        private string _Acronym = Default;
		private string _Active = Default;
        private string _Description = Default;
        private string _Qty = Default;       
        private string _ClientId = Default;        
        private string _Enteredby = Default;
        private string _Enteredon = Default;

		#endregion

		#region Properties

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

        public string Container_Name
		{
			get
			{
                return _Container_Name;
			}
			set
			{
                _Container_Name = value;
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
                    objdbhims.Query = "select sc.SContainerId,sc.SpecimenId,sc.Container_Name,sc.Acronym,s.Specimen_Name,sc.Active from " + TableName + " sc left outer join " + TableName3 + " s on sc.SpecimenId = s.SpecimenId where 1 = 1";
                    if (!_SpecimenId.Equals(Default))
                    {
                        objdbhims.Query += " and sc.SpecimenId = " + _SpecimenId;
                    }
                    objdbhims.Query += " order by sc.Container_Name";
                    break;

				case 2:
                    objdbhims.Query = "select SContainerId,Container_Name,Active from " + TableName + " t ";
                    objdbhims.Query = objdbhims.Query + " Where Upper(t.Container_Name) = '" + this._Container_Name.ToUpper() + "'";
					break;

				case 3:
                    objdbhims.Query = "select SContainerId,SpecimenId,Container_Name,Acronym,Description,Qty,ClientId,Active from " + TableName + " where SContainerId = " + _SContainerId;
					break;

                case 4:
                    objdbhims.Query = "select t.Container_Name,t.SContainerId from " + TableName + " t where t.Active='Y'";
                    if (!_SpecimenId.Equals(Default))
                    {
                        objdbhims.Query += " and t.SpecimenId = " + _SpecimenId;
                    }
                    objdbhims.Query += " order by t.Container_Name";
                    break;

                case 5:
                    objdbhims.Query = "select SContainerId,Acronym,Active from " + TableName + " t ";
                    objdbhims.Query = objdbhims.Query + " Where Upper(t.Acronym) = '" + this._Acronym.ToUpper() + "'";
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

                    objdbhims.Query = objQB.QBGetMax("SContainerId", TableName);
                    this._SContainerId = objTrans.DataTrigger_Get_Max(objdbhims);

                    if (!this._SContainerId.Equals("True"))
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
			string[,] arySAPS = new string[10, 3];

            if (!this._SContainerId.Equals(Default))
			{
                arySAPS[0, 0] = "SContainerId";
                arySAPS[0, 1] = this._SContainerId;
                arySAPS[0, 2] = "int";
			}            

			if (!this._Container_Name.Equals(Default))
			{
                arySAPS[1, 0] = "Container_Name";
                arySAPS[1, 1] = this._Container_Name;
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

            if (!this._Qty.Equals(Default))
            {
                arySAPS[7, 0] = "Qty";
                arySAPS[7, 1] = this._Qty;
                arySAPS[7, 2] = "string";
            }
            
            if (!this._ClientId.Equals(Default))
            {
                arySAPS[8, 0] = "ClientId";
                arySAPS[8, 1] = this._ClientId;
                arySAPS[8, 2] = "string";
            }

            if (!this._SpecimenId.Equals(Default))
            {
                arySAPS[9, 0] = "SpecimenId";
                arySAPS[9, 1] = this._SpecimenId;
                arySAPS[9, 2] = "int";
            }

            return arySAPS;
		}

		#endregion    

		#region "Validation Functions"

		private bool Validation()
		{
			if (!VD_SContainer())
			{
				return false;
			}
           
            if (!VD_Specimen())
            {
                return false;
            }

            if (!VD_Acronym())
            {
                return false;
            }

			return true;
		}

        public bool VD_SContainer()
		{

			if (this._Container_Name.Equals(""))
			{
                this.StrErrorMessage = "Please Enter Container Name. (empty is not allowed)";
				return false;
			}

			DataView dvTest = GetAll(2);

            if (!this._SContainerId.Equals(Default))
			{
                dvTest.RowFilter = "SContainerId <> '" + _SContainerId + "' And Container_Name = '" + _Container_Name + "'";
			}
			else
			{
                dvTest.RowFilter = "Container_Name = '" + _Container_Name + "'";
			}

			if (dvTest.Count > 0)
			{
                this.StrErrorMessage = "Please Enter another Container Name, it is already present.";
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

                if (!this._SContainerId.Equals(Default))
                {
                    dvTest.RowFilter = "SContainerId <> '" + _SContainerId + "' And Acronym = '" + _Acronym + "'";
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

