using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Odbc;
using DataLayer;
using System.Web.Configuration;

namespace BusinessLayer
{
	public class clsGroupD
	{
		#region Class Variables

		private const string Default = "~!@";
        private const string TableName = "dc_tp_groupd";
        private const string TableName2 = "dc_tp_personnel";
        private const string TableName3 = "dc_tp_departments";
        private const string TableName4 = "dc_tp_groupm";        
        private const string TableName5 = "dc_tp_test";        
		private string StrErrorMessage = "";

        private string _GroupDetailId = Default;
        private string _GroupId = Default;
        private string _DepartmentId = Default;

        private string _TestId = Default;
        private string _Test_Name = Default;       
        private string _DOrder = Default;
        private string _Charges = Default;
      
        private string _ClientId = Default;        
        private string _Enteredby = Default;
        private string _Enteredon = Default;
        private string _Active = Default;

		#endregion

		#region Properties

        public string GroupDetailId
        {
            get
            {
                return _GroupDetailId;
            }
            set
            {
                _GroupDetailId = value;
            }
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
        public string Test_Name
		{
			get
			{
				return _Test_Name;
			}
			set
			{
                _Test_Name = value;
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
        public string Charges
        {
            get { return _Charges; }
            set { _Charges = value; }
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
        public string Active
        {
            get { return _Active; }
            set { _Active = value; }
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
                    objdbhims.Query = "select gd.GroupDetailId,gd.Test_Name,d.Name as DeptName,g.Name as GroupName ,gd.active,ifnull(gd.charges,0) as charges,ifnull((select sum(charges) from dc_tp_groupd where groupid=gd.groupid and active='Y'),0) as grouptotal from " + TableName + " gd left outer join " + TableName3 + " d on gd.DepartmentId = d.DepartmentId left outer join " + TableName4 + " g on gd.GroupId = g.GroupId where 1 = 1";
                    if (!_DepartmentId.Equals(Default))
                    {
                        objdbhims.Query += " and gd.DepartmentId = " + _DepartmentId;
                    }
                    if (!_GroupId.Equals(Default))
                    {
                        objdbhims.Query += " and gd.GroupId = " + _GroupId;
                    }
                    if (!_TestId.Equals(Default))
                    {
                        objdbhims.Query += " and gd.TestId = " + _TestId;
                    }
                    objdbhims.Query += " order by gd.Test_Name";
                    break;

				case 2:
                    objdbhims.Query = "select GroupDetailId,Test_Name from " + TableName + " t ";
                    objdbhims.Query = objdbhims.Query + " Where Upper(t.Test_Name) = '" + this._Test_Name.ToUpper() + "'";
					break;

				case 3:
                    objdbhims.Query = "select g.GroupDetailId,g.DepartmentId,g.GroupId,g.TestId,g.Test_Name,g.DOrder,g.ClientId,g.active,ifnull(g.charges,0) as charges,ifnull(t.charges,0) as testcharges,ifnull((select sum(charges) from dc_tp_groupd where groupid=g.groupid and active='Y'),0) as grouptotal from " + TableName + " g join dc_tp_test t on g.testid=t.testid where g.GroupDetailId = " + _GroupDetailId;
					break;

                case 4:
                    objdbhims.Query = "select t.Test_Name,t.GroupDetailId from " + TableName + " t where t.Active='Y'";
                    if (!_DepartmentId.Equals(Default))
                    {
                        objdbhims.Query += " and t.DepartmentId = " + _DepartmentId;
                    }
                    if (!_GroupId.Equals(Default))
                    {
                        objdbhims.Query += " and t.GroupId = " + _GroupId;
                    }
                    if (!_TestId.Equals(Default))
                    {
                        objdbhims.Query += " and t.TestId = " + _TestId;
                    }
                    objdbhims.Query += " order by t.Name";
                    break;

                case 6:
                    objdbhims.Query = "select GroupDetailId,DOrder from " + TableName + " t ";
                    objdbhims.Query = objdbhims.Query + " Where t.DOrder = '" + this._DOrder + "' and t.groupid="+_GroupId+"";
                    break;

                case 7:
                    objdbhims.Query = "select t.SubDepartmentId,g.TestId from " + TableName + " g left outer join " + TableName5 + " t on g.TestId = t.TestId where GroupDetailId = " + _GroupDetailId;
                    break;
                case 8: // test charges get
                    objdbhims.Query = "select ifnull(charges,0) as charges from dc_tp_test where testid="+_TestId+"";
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

                    objdbhims.Query = objQB.QBGetMax("GroupDetailId", TableName);
                    this._GroupDetailId = objTrans.DataTrigger_Get_Max(objdbhims);

                    if (!this._GroupDetailId.Equals("True"))
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

            if (!this._GroupDetailId.Equals(Default))
			{
                arySAPS[0, 0] = "GroupDetailId";
                arySAPS[0, 1] = this._GroupDetailId;
                arySAPS[0, 2] = "int";
			}

            if (!this._GroupId.Equals(Default))
            {
                arySAPS[1, 0] = "GroupId";
                arySAPS[1, 1] = this._GroupId;
                arySAPS[1, 2] = "int";
            }

            if (!this._DepartmentId.Equals(Default))
            {
                arySAPS[2, 0] = "DepartmentId";
                arySAPS[2, 1] = this._DepartmentId;
                arySAPS[2, 2] = "int";
            }

            if (!this._TestId.Equals(Default))
            {
                arySAPS[3, 0] = "TestId";
                arySAPS[3, 1] = this._TestId;
                arySAPS[3, 2] = "int";
            }

            if (!this._Test_Name.Equals(Default))
            {
                arySAPS[4, 0] = "Test_Name";
                arySAPS[4, 1] = this._Test_Name;
                arySAPS[4, 2] = "string";
            }

            if (!this._DOrder.Equals(Default))
            {
                arySAPS[5, 0] = "DOrder";
                arySAPS[5, 1] = this._DOrder;
                arySAPS[5, 2] = "int";
            }               

            if (!this._Enteredby.Equals(Default))
            {
                arySAPS[6, 0] = "Enteredby";
                arySAPS[6, 1] = this._Enteredby;
                arySAPS[6, 2] = "string";
            }

			if (!this._Enteredon.Equals(Default))
			{
                arySAPS[7, 0] = "Enteredon";
                arySAPS[7, 1] = this._Enteredon;
                arySAPS[7, 2] = "datetime";
			}           
            
            if (!this._ClientId.Equals(Default))
            {
                arySAPS[8, 0] = "ClientId";
                arySAPS[8, 1] = this._ClientId;
                arySAPS[8, 2] = "string";
            }
            if (!this._Active.Equals(Default))
            {
                arySAPS[9, 0] = "active";
                arySAPS[9, 1] = this._Active;
                arySAPS[9, 2] = "string";
            }
            if (!this._Charges.Equals(Default))
            {
                arySAPS[10, 0] = "charges";
                arySAPS[10, 1] = this._Charges;
                arySAPS[10, 2] = "int";
            }
           
            return arySAPS;
		}

		#endregion    

		#region "Validation Functions"

		private bool Validation()
		{
            if (!VD_GroupDetail())
			{
				return false;
			}

            if (!VD_DOrder())
            {
                return false;
            }

			return true;
		}

        public bool VD_GroupDetail()
		{

			if (this._Test_Name.Equals(""))
			{
                this.StrErrorMessage = "Please select Test Name. (empty is not allowed)";
				return false;
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

                if (!this._GroupDetailId.Equals(Default))
                {
                    dvTest.RowFilter = "GroupDetailId <> '" + _GroupDetailId + "' And DOrder = '" + _DOrder + "'";
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

