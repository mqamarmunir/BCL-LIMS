using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Odbc;
using DataLayer;
using System.Web.Configuration;

namespace BusinessLayer
{
	public class clsGroupM
	{
		#region Class Variables

		private const string Default = "~!@";
        private const string TableName = "dc_tp_groupm";
        private const string TableName2 = "dc_tp_personnel";
		private string StrErrorMessage = "";

        private string _GroupId = Default;
		private string _Name = Default;
        private string _Acronym = Default;
		private string _Active = Default;
        private string _Description = Default;
        private string _DOrder = Default;       
        private string _ClientId = Default;        
        private string _Enteredby = Default;
        private string _Enteredon = Default;
        private string _Package = Default;

        
        private string _packageDateFrom = Default;
        private string _packagedateto = Default;
		#endregion

		#region Properties

        public string Package
        {
            get { return _Package; }
            set { _Package = value; }
        }
        public string packageDateFrom
        {
            get { return _packageDateFrom; }
            set { _packageDateFrom = value; }
        }
        public string packagedateto
        {
            get { return _packagedateto; }
            set { _packagedateto = value; }
        }
        public string GroupId
        {
            get
            {
                return _GroupId;
            }
            set
            {
                _GroupId = value;
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
                    objdbhims.Query = "select g.GroupId,g.Name,g.Acronym,g.Description,g.Active from " + TableName + " g where 1 = 1";                    
                    objdbhims.Query += " order by g.Name";
                    break;

				case 2:
                    objdbhims.Query = "select GroupId,Name,Active from " + TableName + " t ";
                    objdbhims.Query = objdbhims.Query + " Where Upper(t.Name) = '" + this._Name.ToUpper() + "'";
					break;

				case 3:
                    objdbhims.Query = "select GroupId,Name,Acronym,Description,DOrder,ClientId,Active,Package,date_format(packagedatefrom,'%d/%m/%Y') packagedatefrom,date_format(packagedateto,'%d/%m/%Y') packagedateto  from " + TableName + " where GroupId = " + _GroupId;
					break;

                case 4:
                    objdbhims.Query = "select t.Name,t.GroupId from " + TableName + " t where t.Active='Y'";                    
                    objdbhims.Query += " order by t.Name";
                    break;

                case 5:
                    objdbhims.Query = "select GroupId,Acronym,Active from " + TableName + " t ";
                    objdbhims.Query = objdbhims.Query + " Where Upper(t.Acronym) = '" + this._Acronym.ToUpper() + "'";
                    break;

                case 6:
                    objdbhims.Query = "select GroupId,DOrder from " + TableName + " t ";
                    objdbhims.Query = objdbhims.Query + " Where DOrder = '" + this._DOrder + "'";
                    break;
                case 7:
                    objdbhims.Query = " SELECT * FROM dc_tp_groupm d where Active='Y'  and Clientid='" + WebConfigurationManager.AppSettings["Clientid"].ToString().Trim()+"'";
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

                    objdbhims.Query = objQB.QBGetMax("GroupId", TableName);
                    this._GroupId = objTrans.DataTrigger_Get_Max(objdbhims);

                    if (!this._GroupId.Equals("True"))
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
			string[,] arySAPS = new string[12, 3];

            if (!this._GroupId.Equals(Default))
			{
                arySAPS[0, 0] = "GroupId";
                arySAPS[0, 1] = this._GroupId;
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

            if (!this._ClientId.Equals(Default))
            {
                arySAPS[8, 0] = "ClientId";
                arySAPS[8, 1] = this._ClientId;
                arySAPS[8, 2] = "string";
            }
            if (!this._Package.Equals(Default))
            {
                arySAPS[9, 0] = "Package";
                arySAPS[9, 1] = this._Package;
                arySAPS[9, 2] = "string";
            }
            if (!this._packageDateFrom.Equals(Default))
            {
                arySAPS[10, 0] = "packageDateFrom";
                arySAPS[10, 1] = this._packageDateFrom;
                arySAPS[10, 2] = "datetime";
            }
            if (!this._packagedateto.Equals(Default))
            {
                arySAPS[11, 0] = "packagedateto";
                arySAPS[11, 1] = this._packagedateto;
                arySAPS[11, 2] = "datetime";
            }   

            return arySAPS;
		}

		#endregion    

		#region "Validation Functions"

		private bool Validation()
		{
			if (!VD_Group())
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

        public bool VD_Group()
		{

			if (this._Name.Equals(""))
			{
                this.StrErrorMessage = "Please Enter Group Name. (empty is not allowed)";
				return false;
			}

			DataView dvTest = GetAll(2);

            if (!this._GroupId.Equals(Default))
			{
                dvTest.RowFilter = "GroupId <> '" + _GroupId + "' And Name = '" + _Name + "'";
			}
			else
			{
                dvTest.RowFilter = "Name = '" + _Name + "'";
			}

			if (dvTest.Count > 0)
			{
                this.StrErrorMessage = "Please Enter another Group Name, it is already present.";
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

                if (!this._GroupId.Equals(Default))
                {
                    dvTest.RowFilter = "GroupId <> '" + _GroupId + "' And Acronym = '" + _Acronym + "'";
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

                if (!this._GroupId.Equals(Default))
                {
                    dvTest.RowFilter = "GroupId <> '" + _GroupId + "' And DOrder = '" + _DOrder + "'";
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

