using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Odbc;
using DataLayer;

namespace BusinessLayer
{
	public class clsAttribute
	{
		#region Class Variables

		private const string Default = "~!@";
        private const string TableName = "dc_tp_attributes";
        private const string TableName2 = "dc_tp_personnel";
        private const string TableName3 = "dc_tp_subdepartments";
        private const string TableName4 = "dc_tp_test";     
		private string StrErrorMessage = "";

        private string _AttributeId = Default;
        private string _SubdepartmentId = Default;
        private string _TestId = Default;

        private string _Attribute_Name = Default;
        private string _Acronym = Default;
		private string _Active = Default;
        private string _Description = Default;

        private string _DOrder = Default;
        private string _Attribute_Type = Default;
        private string _D_A_Formula = Default;
        private string _D_A_Formula_Desc = Default;

        private string _LinesNo = Default;
        private string _DefaultValue = Default;
        private string _Interfaced = Default;   
    
        private string _ClientId = Default;        
        private string _Enteredby = Default;
        private string _Enteredon = Default;

        private string _Drived = Default;
        private string _ParentID = Default;
		private string _Heading = Default;
        private string _Print = Default;

		#endregion

		#region Properties

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

        public string Attribute_Name
		{
			get
			{
				return _Attribute_Name;
			}
			set
			{
                _Attribute_Name = value;
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
        public string Attribute_Type
        {
            get
            {
                return _Attribute_Type;
            }
            set
            {
                _Attribute_Type = value;
            }
        }

        public string D_A_Formula
        {
            get
            {
                return _D_A_Formula;
            }
            set
            {
                _D_A_Formula = value;
            }
        }
        public string D_A_Formula_Desc
        {
            get
            {
                return _D_A_Formula_Desc;
            }
            set
            {
                _D_A_Formula_Desc = value;
            }
        }
        public string LinesNo
        {
            get
            {
                return _LinesNo;
            }
            set
            {
                _LinesNo = value;
            }
        }

        public string DefaultValue
        {
            get
            {
                return _DefaultValue;
            }
            set
            {
                _DefaultValue = value;
            }
        }
        public string Interfaced
        {
            get
            {
                return _Interfaced;
            }
            set
            {
                _Interfaced = value;
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

        public string Drived
        {
            get { return _Drived; }
            set { _Drived = value; }
        }
        public string ParentID
        {
            get { return _ParentID; }
            set { _ParentID = value; }
        }

		public string Heading
		{
			get { return _Heading; }
			set { _Heading= value; }
		}
        public string Print
        {
            get { return _Print; }
            set { _Print = value; }
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
                    objdbhims.Query = "select a.AttributeId,a.Attribute_Name,a.Acronym,sd.Name as SubDeptName,t.Test_Name,a.Active,a.drived,a.DOrder,a.testID,a.heading,a.print from " + TableName + " a left outer join " + TableName3 + " sd on a.SubdepartmentId = sd.SubdepartmentId left outer join " + TableName4 + " t on a.TestId = t.TestId where 1 = 1";
                    if (!_SubdepartmentId.Equals(Default))
                    {
                        objdbhims.Query += " and a.SubdepartmentId = " + _SubdepartmentId;
                    }
                    if (!_TestId.Equals(Default))
                    {
                        objdbhims.Query += " and a.TestId = " + _TestId;
                    }
                    if (!_Attribute_Type.Equals(Default))
                    {
                        objdbhims.Query += " and a.Attribute_Type = '" + _Attribute_Type + "'";
                    }
                    objdbhims.Query += "  order by ifnull(a.DOrder,100000)";
                    break;

				case 2:
                    objdbhims.Query = "select AttributeId,Attribute_Name,Active from " + TableName + " t ";
                    objdbhims.Query = objdbhims.Query + " Where Upper(t.Attribute_Name) = '" + this._Attribute_Name.ToUpper() + "' and testid="+_TestId+"";
					break;

				case 3:
                    objdbhims.Query = "select AttributeId,SubdepartmentId,TestId,Attribute_Name,Acronym,Description,DOrder,Attribute_Type,D_A_Formula,D_A_Formula_Desc,LinesNo,DefaultValue,Interfaced,ClientId,Active,drived,parentid,heading,print from " + TableName + " where AttributeId = " + _AttributeId;
					break;

                case 4:
                    objdbhims.Query = "select t.Attribute_Name,t.AttributeId from " + TableName + " t where t.Active='Y'";
                    if (!_SubdepartmentId.Equals(Default))
                    {
                        objdbhims.Query += " and t.SubdepartmentId = " + _SubdepartmentId;
                    }
                    if (!_TestId.Equals(Default))
                    {
                        objdbhims.Query += " and t.TestId = " + _TestId;
                    }
                    if (!_Attribute_Type.Equals(Default))
                    {
                        objdbhims.Query += " and t.Attribute_Type = '" + _Attribute_Type + "'";
                    }
                    objdbhims.Query += " order by t.Attribute_Name";
                    break;

                case 5:
                    objdbhims.Query = "select AttributeId,Acronym,Active from " + TableName + " t ";
                    objdbhims.Query = objdbhims.Query + " Where Upper(t.Acronym) = '" + this._Acronym.ToUpper() + "'";
                    break;

                case 6:
                    objdbhims.Query = "select AttributeId,dorder from " + TableName + " ";
                    objdbhims.Query = objdbhims.Query + " Where dorder="+_DOrder+" and testid="+_TestId+"";
                    break;

                case 7: //,t.GroupId  ....left outer join " + TableName4 + " t on a.TestId = t.TestId091221
                    objdbhims.Query = "select a.SubdepartmentId,a.TestId from " + TableName + " a  where AttributeId = " + _AttributeId;
                    break;
                case 8: // fill attribute
                    objdbhims.Query = "select a.attribute_name as att_name,a.attributeid,t.test_name FROM dc_tp_attributes a left outer join dc_tp_test t on t.testid=a.testid where a.active='Y'";
                    if (!_Attribute_Name.Equals("") && !_Attribute_Name.Equals(Default))
                        objdbhims.Query += " and a.attribute_name like '%" + _Attribute_Name + "%'";
                    objdbhims.Query += " order by t.test_name ";
                    break;
                case 9:
                    objdbhims.Query = "select testid from dc_tp_attributes where attributeid in (select attributeid from dc_tp_aranges) and attributeid=" + _AttributeId + "";
                    break;
                case 10:
                    objdbhims.Query = @"Select Max(AttributeID) AttributeID From dc_tp_attributes where Active='Y'";
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

                    objdbhims.Query = objQB.QBGetMax("AttributeId", TableName);
                    this._AttributeId = objTrans.DataTrigger_Get_Max(objdbhims);

                    if (!this._AttributeId.Equals("True"))
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

        public bool UpdateDOrder(string[,] arr)
        {

            clsoperation objTrans = new clsoperation();
            QueryBuilder objQB = new QueryBuilder();

            objTrans.Start_Transaction();

            for (int i = 0; i <= arr.GetUpperBound(0); i++)
            {
                //if (!arr[i, 4].Trim().Equals(""))
                //{
                    this._AttributeId = arr[i, 0];
                    this._Enteredby = arr[i, 2];
                    this._Enteredon = arr[i, 1];
                    this._ClientId = arr[i, 3];
                    this._DOrder = arr[i, 4];
                    this._TestId = arr[i, 5];

                    //if (!VD_DOrder())
                    //{
                    //    objTrans.End_Transaction();
                    //    return false;
                    //}

                    objdbhims.Query = objQB.QBUpdate(MakeArray(), TableName);
                    this.StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);

                    if (this.StrErrorMessage.Equals("True"))
                    {
                        this.StrErrorMessage = objTrans.OperationError;
                        objTrans.End_Transaction();
                        return false;
                    }
                //}
            }

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

		private string[,] MakeArray()
		{
			string[,] arySAPS = new string[21, 3];

			if (!this._AttributeId.Equals(Default))
			{
                arySAPS[0, 0] = "AttributeId";
                arySAPS[0, 1] = this._AttributeId;
                arySAPS[0, 2] = "int";
			}

            if (!this._SubdepartmentId.Equals(Default))
            {
                arySAPS[1, 0] = "SubdepartmentId";
                arySAPS[1, 1] = this._SubdepartmentId;
                arySAPS[1, 2] = "int";
            }

            if (!this._TestId.Equals(Default))
            {
                arySAPS[2, 0] = "TestId";
                arySAPS[2, 1] = this._TestId;
                arySAPS[2, 2] = "int";
            }    

			if (!this._Attribute_Name.Equals(Default))
			{
                arySAPS[3, 0] = "Attribute_Name";
                arySAPS[3, 1] = this._Attribute_Name;
                arySAPS[3, 2] = "string";
			}

            if (!this._Acronym.Equals(Default))
            {
                arySAPS[4, 0] = "Acronym";
                arySAPS[4, 1] = this._Acronym;
                arySAPS[4, 2] = "string";
            }

            if (!this.Active.Equals(Default))
            {
                arySAPS[5, 0] = "Active";
                arySAPS[5, 1] = this.Active;
                arySAPS[5, 2] = "string";
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

            if (!this._Description.Equals(Default))
            {
                arySAPS[8, 0] = "Description";
                arySAPS[8, 1] = this._Description;
                arySAPS[8, 2] = "string";
            }

            if (!this._Attribute_Type.Equals(Default))
            {
                arySAPS[9, 0] = "Attribute_Type";
                arySAPS[9, 1] = this._Attribute_Type;
                arySAPS[9, 2] = "string";
            }

            if (!this._D_A_Formula.Equals(Default))
            {
                arySAPS[10, 0] = "D_A_Formula";
                arySAPS[10, 1] = this._D_A_Formula;
                arySAPS[10, 2] = "string";
            }

            if (!this._D_A_Formula_Desc.Equals(Default))
            {
                arySAPS[11, 0] = "D_A_Formula_Desc";
                arySAPS[11, 1] = this._D_A_Formula_Desc;
                arySAPS[11, 2] = "string";
            }

            if (!this._DOrder.Equals(Default) && !this._DOrder.Equals(""))
            {
                arySAPS[12, 0] = "DOrder";
                arySAPS[12, 1] = this._DOrder;
                arySAPS[12, 2] = "int";
            }
            else
            {
                arySAPS[12, 0] = "DOrder";
                arySAPS[12, 1] ="null";
                arySAPS[12, 2] = "int";
            }

            if (!this._LinesNo.Equals(Default))
            {
                arySAPS[13, 0] = "LinesNo";
                arySAPS[13, 1] = this._LinesNo;
                arySAPS[13, 2] = "int";
            }

            if (!this._DefaultValue.Equals(Default))
            {
                arySAPS[14, 0] = "DefaultValue";
                arySAPS[14, 1] = this._DefaultValue;
                arySAPS[14, 2] = "string";
            }

            if (!this._Interfaced.Equals(Default))
            {
                arySAPS[15, 0] = "Interfaced";
                arySAPS[15, 1] = this._Interfaced;
                arySAPS[15, 2] = "string";
            }

            if (!this._ClientId.Equals(Default))
            {
                arySAPS[16, 0] = "ClientId";
                arySAPS[16, 1] = this._ClientId;
                arySAPS[16, 2] = "string";
            }
            if (!this._Drived.Equals(Default))
            {
                arySAPS[17, 0] = "drived";
                arySAPS[17, 1] = this._Drived;
                arySAPS[17, 2] = "string";
            }
            if (!this._ParentID.Equals(Default) && !this._ParentID.Equals(""))
            {
                arySAPS[18, 0] = "parentid";
                arySAPS[18, 1] = this._ParentID;
                arySAPS[18, 2] = "int";
            }
            else
            {
                arySAPS[18, 0] = "parentid";
                arySAPS[18, 1] = this._AttributeId;
                arySAPS[18, 2] = "int";
            }
			if (!this._Heading.Equals(Default))
			{
			arySAPS[19 , 0] = "Heading";
			arySAPS[19 , 1] = this._Heading;
			arySAPS[19 , 2] = "string";
			}
            if (!this._Print.Equals(Default))
            {
                arySAPS[20, 0] = "print";
                arySAPS[20, 1] = this._Print;
                arySAPS[20, 2] = "string";
            }
            return arySAPS;
		}

		#endregion    

		#region "Validation Functions"

		private bool Validation()
		{
            if (!VD_Attribute())
			{
				return false;
			}

            if (!VD_SubDepartmentId())
            {
                return false;
            }

            if (!VD_TestId())
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
            if (!VD_Att_range())
                return false;

			return true;
		}

        public bool VD_Attribute()
		{

			if (this._Attribute_Name.Equals(""))
			{
                this.StrErrorMessage = "Please Enter Attribute Name. (empty is not allowed)";
				return false;
			}
           
                DataView dvTest = GetAll(2);

                if (!this._AttributeId.Equals(Default))
                {
                    dvTest.RowFilter = "AttributeId <> '" + _AttributeId + "' And Attribute_Name = '" + _Attribute_Name + "'";
                }
                else
                {
                    dvTest.RowFilter = "Attribute_Name = '" + _Attribute_Name + "'";
                }

                if (dvTest.Count > 0)
                {
                    this.StrErrorMessage = "Please Enter another Attribute Name, it is already present.";
                    return false;
                }
           

			return true;
		}

        public bool VD_SubDepartmentId()
        {
            if (this._SubdepartmentId.Equals(Default))
            {
                this.StrErrorMessage = "Please Select Sub Department First. (empty is not allowed)";
                return false;
            }
            return true;
        }

        public bool VD_TestId()
        {
            if (this._TestId.Equals(Default))
            {
                this.StrErrorMessage = "Please Select Test First. (empty is not allowed)";
                return false;
            }
            return true;
        }

        private bool VD_Acronym()
        {
            //if (this._Acronym.Equals(""))
            //{
            //    this.StrErrorMessage = "Please Enter Acronym. (empty is not allowed)";
            //    return false;
            //}

            if (!this._Acronym.Equals("") && !this._Acronym.Equals(Default))
            {
                DataView dvTest = GetAll(5);

                if (!this._AttributeId.Equals(Default))
                {
                    dvTest.RowFilter = "AttributeId <> '" + _AttributeId + "' And Acronym = '" + _Acronym + "'";
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

            if (!this._AttributeId.Equals("") && !this._AttributeId.Equals(Default))
            {
                DataView dvTest = GetAll(6);
                if (dvTest.Count > 0)
                {
                    if (!this._AttributeId.Equals(Default))
                        dvTest.RowFilter = " attributeid <>"+_AttributeId+"";


                    if (dvTest.Count > 0)
                    {
                        this.StrErrorMessage = "Please Enter another DOrder, it is already present.";
                        return false;
                    }
                }
                else
                    return true;
            }

            return true;

        }

        private bool VD_Att_range()
        {
            if (!_AttributeId.Equals(Default) && !_AttributeId.Equals(""))
            {
                DataView dv = GetAll(9);
                if (dv.Count > 0)
                {
                    dv.RowFilter = "testid<>" + _TestId;
                    if (dv.Count > 0)
                    {
                        StrErrorMessage = "Attribute has ranges so it can't be updated";
                        return false;
                    }
                    else
                        return true;
                }
                else
                    return true;
            }
            else
                return true;
        }

		#endregion

	}
}

