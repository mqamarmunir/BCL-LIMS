using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Odbc;
using DataLayer;

namespace BusinessLayer
{
	public class clsSpecimenType
	{
		#region Class Variables

		private const string Default = "~!@";
        private const string TableName = "dc_tp_stype";
        private const string TableName2 = "dc_tp_personnel";
		private string StrErrorMessage = "";

        private string _SpecimenId = Default;
        private string _Specimen_Name = Default;
        private string _Acronym = Default;
		private string _Active = Default;
        private string _Type = Default;        
        private string _ClientId = Default;        
        private string _Enteredby = Default;
        private string _Enteredon = Default;

		#endregion

		#region Properties
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

        public string Specimen_Name
		{
			get
			{
                return _Specimen_Name;
			}
			set
			{
                _Specimen_Name = value;
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
                    objdbhims.Query = "select t.SpecimenId,t.Specimen_Name,t.Acronym,case when t.Type = 'B' then 'Blood' when t.Type = 'U' then 'Urine' else ' ' end as Type,t.Active from " + TableName + " t where 1 = 1";
                    if (!_Type.Equals(Default))
                    {
                        objdbhims.Query += " and t.Type = '" + _Type + "'";
                    }
                    objdbhims.Query += " order by t.Specimen_Name";
                    break;

				case 2:
                    objdbhims.Query = "select SpecimenId,Specimen_Name,Active from " + TableName + " t ";
                    objdbhims.Query = objdbhims.Query + " Where Upper(t.Specimen_Name) = '" + this._Specimen_Name.ToUpper() + "'";
					break;

				case 3:
                    objdbhims.Query = "select SpecimenId,Specimen_Name,Acronym,Type,ClientId,Active from " + TableName + " where SpecimenId = " + _SpecimenId;
					break;

                case 4:
                    objdbhims.Query = "select t.Specimen_Name,t.SpecimenId from " + TableName + " t where t.Active='Y' order by t.Specimen_Name";
                    break;

                case 5:
                    objdbhims.Query = "select SpecimenId,Acronym,Active from " + TableName + " t ";
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

                    objdbhims.Query = objQB.QBGetMax("SpecimenId", TableName);
                    this._SpecimenId = objTrans.DataTrigger_Get_Max(objdbhims);

                    if (!this._SpecimenId.Equals("True"))
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
			string[,] arySAPS = new string[8, 3];

			if (!this._SpecimenId.Equals(Default))
			{
                arySAPS[0, 0] = "SpecimenId";
                arySAPS[0, 1] = this._SpecimenId;
                arySAPS[0, 2] = "int";
			}

			if (!this._Specimen_Name.Equals(Default))
			{
                arySAPS[1, 0] = "Specimen_Name";
                arySAPS[1, 1] = this._Specimen_Name;
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

            if (!this._Type.Equals(Default))
            {
                arySAPS[5, 0] = "Type";
                arySAPS[5, 1] = this._Type;
                arySAPS[5, 2] = "string";
            }

            if (!this._Acronym.Equals(Default))
            {
                arySAPS[6, 0] = "Acronym";
                arySAPS[6, 1] = this._Acronym;
                arySAPS[6, 2] = "string";
            }
           
            if (!this._ClientId.Equals(Default))
            {
                arySAPS[7, 0] = "ClientId";
                arySAPS[7, 1] = this._ClientId;
                arySAPS[7, 2] = "string";
            }
           
            return arySAPS;
		}

		#endregion    

		#region "Validation Functions"

		private bool Validation()
		{
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

        public bool VD_Specimen()
		{

			if (this._Specimen_Name.Equals(""))
			{
                this.StrErrorMessage = "Please Enter Specimen Name. (empty is not allowed)";
				return false;
			}

			DataView dvTest = GetAll(2);

            if (!this._SpecimenId.Equals(Default))
			{
                dvTest.RowFilter = "SpecimenId <> '" + _SpecimenId + "' And Specimen_Name = '" + _Specimen_Name + "'";
			}
			else
			{
                dvTest.RowFilter = "Specimen_Name = '" + _Specimen_Name + "'";
			}

			if (dvTest.Count > 0)
			{
                this.StrErrorMessage = "Please Enter another Specimen Name, it is already present.";
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

                if (!this._SpecimenId.Equals(Default))
                {
                    dvTest.RowFilter = "SpecimenId <> '" + _SpecimenId + "' And Acronym = '" + _Acronym + "'";
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


