using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Odbc;
using DataLayer;

namespace BusinessLayer
{
	public class clsARange
	{
		#region Class Variables

		private const string Default = "~!@";
        private const string TableName = "dc_tp_aranges";
        private const string TableName2 = "dc_tp_personnel";

        private const string TableName3 = "dc_tp_subdepartments";
        private const string TableName4 = "dc_tp_groupm";        
        private const string TableName5 = "dc_tp_test";        
		private string StrErrorMessage = "";

        private string _RangeId = Default;
        private string _AttributeId = Default;
        private string _GroupId = Default;
        private string _SubdepartmentId = Default;

        private string _TestId = Default;
        private string _Sex = Default;
        private string _Age_Min = Default;
        private string _Age_Max = Default;
        private string _Min_Value = Default;

        private string _Max_Value = Default;
        private string _AUnit = Default;
        private string _Active = Default;

        private string _Min_Panic_Value = Default;
        private string _Max_Panic_Value = Default;
        private string _MethodID = Default;
      
        private string _ClientId = Default;        
        private string _Enteredby = Default;
        private string _Enteredon = Default;
        private string _Description = Default;
        private string _ASIUnit = Default;

        
        private string _Conversionfactor = Default;

        

		#endregion

		#region Properties

        public string RangeId
        {
            get
            {
                return _RangeId;
            }
            set
            {
                _RangeId = value;
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
        public string Sex
		{
			get
			{
				return _Sex;
			}
			set
			{
                _Sex = value;
			}
		}     

        public string Age_Min
        {
            get
            {
                return _Age_Min;
            }
            set
            {
                _Age_Min = value;
            }
        }
        public string Age_Max
        {
            get
            {
                return _Age_Max;
            }
            set
            {
                _Age_Max = value;
            }
        }

        public string Min_Value
        {
            get
            {
                return _Min_Value;
            }
            set
            {
                _Min_Value = value;
            }
        }
        public string Max_Value
        {
            get
            {
                return _Max_Value;
            }
            set
            {
                _Max_Value = value;
            }
        }

        public string AUnit
        {
            get
            {
                return _AUnit;
            }
            set
            {
                _AUnit = value;
            }
        }
        public string Active
        {
            get { return _Active; }
            set { _Active = value; }
        }

        public string Min_Panic_Value
        {
            get
            {
                return _Min_Panic_Value;
            }
            set
            {
                _Min_Panic_Value = value;
            }
        }
        public string Max_Panic_Value
        {
            get
            {
                return _Max_Panic_Value;
            }
            set
            {
                _Max_Panic_Value = value;
            }
        }
        public string MethodID
        {
            get { return _MethodID; }
            set { _MethodID = value; }
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
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        public string ASIUnit
        {
            get { return _ASIUnit; }
            set { _ASIUnit = value; }
        }
        public string Conversionfactor
        {
            get { return _Conversionfactor; }
            set { _Conversionfactor = value; }
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
                    objdbhims.Query = "select r.RangeId,g.Name as GroupName,case when r.Sex = 'M' then 'Male' when r.sex='F' then 'Female' else 'All' end as Sex,r.Age_Min,r.Age_Max,r.AUnit,r.methodid,r.active,concat(ifnull(r.min_value,'-'),'-',ifnull(r.max_value,'-'),'-',ifnull(r.aunit,'-')) as referencerange,concat('(',concat(case when r.age_min % 365=0 then floor(r.age_min/365) when r.age_min%30=0  then floor(r.age_min/30) else r.age_min end,'-',case when r.age_max % 365=0 then floor(r.age_max/365) when r.age_max%30=0  then floor(r.age_max/30) else r.age_max end),')',' ',case when r.age_max % 365=0 then 'Year(s)' when r.age_max%30=0  then 'Month(s)' else 'Day(s)' end)  as TotalAge,case when r.age_max % 365=0 then concat(floor(r.age_max/365),' Year(s)') when r.age_max%30=0  then concat(floor(r.age_max/30),' Month(s)') else concat(r.age_max,' Day(s)') end as MAX_age_show,t.test_name,a.attribute_name,concat(r.age_min,'-',r.age_max) totaldays,m.name as methodname,concat( (case when Age_Min > 365 then concat(Floor(Age_Min/365),' (Y) ') else '' end) ,(case when  ((Age_Min%365)  <> 0 )  then concat(Floor( ((Age_Min%365)) /30),' (M) ') else '' end),(case when  ( (Age_Min%365)  <> 0  and (Floor(Age_Min/365) % 30) <> 0 )  then concat(Floor(Age_Min % 30),' (D)')  else '' end)) as total_min,concat( (case when Age_Max > 365 then concat(Floor(Age_Max/365),' (Y) ') else '' end) ,(case when  ((Age_Max % 365)  <> 0 )  then concat(Floor( ((Age_Max%365)) /30),' (M) ') else '' end),(case when  ( (Age_Max % 365)  <> 0  and (Floor(Age_Max%365) % 30) <> 0 )  then concat(Floor(Age_Max % 30),' (D)')  else '' end)) as total_max from " + TableName + " r left outer join " + TableName5 + " t on r.TestId = t.TestId left outer join " + TableName4 + " g on r.GroupId = g.GroupId left outer join dc_tp_attributes a on r.attributeid=a.attributeid join dc_tp_method m on r.methodid=m.methodid where 1 = 1";
                    if (!_SubdepartmentId.Equals(Default))
                    {
                        objdbhims.Query += " and r.SubdepartmentId = " + _SubdepartmentId;
                    }
                    if (!_AttributeId.Equals(Default))
                    {
                        objdbhims.Query += " and r.AttributeId = " + _AttributeId;
                    }
                    if (!_GroupId.Equals(Default))
                    {
                        objdbhims.Query += " and r.GroupId = " + _GroupId;
                    }
                    if (!_TestId.Equals(Default))
                    {
                        objdbhims.Query += " and r.TestId = " + _TestId;
                    }
                    objdbhims.Query += " order by ifnull(a.dorder,a.attribute_name)";
                    break;

				case 2:
                    objdbhims.Query = "select RangeId,Sex from " + TableName + " t ";
                    objdbhims.Query = objdbhims.Query + " Where Upper(t.Sex) = '" + this._Sex.ToUpper() + "'";
					break;

				case 3:
                    objdbhims.Query = "select RangeId,AttributeId,SubdepartmentId,GroupId,TestId,Sex,Age_Min,Age_Max,Min_Value,Max_Value,AUnit,Min_Panic_Value,Max_Panic_Value,ClientId,methodid,active,description,ASiunit,conversionfactor from " + TableName + " where RangeId = " + _RangeId;
					break;

                case 4:
                    objdbhims.Query = "select AttributeId from " + TableName + " where RangeId = " + _RangeId;
                    break;
                case 5: // fill method
                    objdbhims.Query = "select methodid,name from dc_tp_method where active='Y' and subdepartmentid="+_SubdepartmentId+"";
                    break;
                case 6: // duplicate validation
                    objdbhims.Query = "select rangeid from dc_tp_aranges where testid=" + _TestId + " and attributeid=" + _AttributeId + " and methodid=" + _MethodID + " and sex='" + _Sex + "' and age_min >= " + _Age_Min + " and age_min <=" + _Age_Max + " and age_max >="+_Age_Min+" and age_max <="+_Age_Max+"";
                    break;
                case 7: // group ddl
                    objdbhims.Query = "SELECT groupid,name FROM dc_tp_groupm where active='Y'";
                        //"SELECT distinct d.groupid,s.name FROM dc_tp_test d left outer join dc_tp_groupm s on d.groupid = s.groupid where d.subdepartmentid="+_SubdepartmentId+" and d.groupid is not null";
                    break;
                case 8: // fill test ddl
                    objdbhims.Query = "select testid,test_name from dc_tp_test where active='Y' and subdepartmentid="+_SubdepartmentId+"  ";
                    //if (!_GroupId.Equals(Default))
                    //{
                    //    objdbhims.Query += " and GroupId = " + _GroupId;
                    //}
                    break;
                case 9: // fill attribute
                    objdbhims.Query = "SELECT attributeid,attribute_name FROM dc_tp_attributes  where active='Y' and subdepartmentid="+_SubdepartmentId+" and testid="+_TestId+" and heading='N'";
                    break;
                case 10: // duplicate validation against method
                    objdbhims.Query = "select rangeid from dc_tp_aranges where testid=" + _TestId + " and attributeid=" + _AttributeId + " and methodid=" + _MethodID + " and (sex='" + _Sex + "' or sex='A') and ((" + _Age_Min + " BETWEEN age_min and age_max) OR  (" + _Age_Max + " BETWEEN age_min and age_max))";
                    break;
                case 11: // test fill based upon groupID
                    objdbhims.Query = "SELECT testid,test_name  FROM dc_tp_groupd where active='Y' and groupid="+_GroupId+"";
                    break;
			}
			return objTrans.DataTrigger_Get_All(objdbhims);
		}

		public bool Insert()
		{
			if (Validation_Form())
			{
				try
				{
					clsoperation objTrans = new clsoperation();
					QueryBuilder objQB = new QueryBuilder();
					objTrans.Start_Transaction();

                    objdbhims.Query = objQB.QBGetMax("RangeId", TableName);
                    this._RangeId = objTrans.DataTrigger_Get_Max(objdbhims);

                    if (!this._RangeId.Equals("True"))
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
			if (Validation_Form())
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
			string[,] arySAPS = new string[21, 3];

            if (!this._RangeId.Equals(Default))
			{
                arySAPS[0, 0] = "RangeId";
                arySAPS[0, 1] = this._RangeId;
                arySAPS[0, 2] = "int";
			}

            if (!this._GroupId.Equals(Default))
            {
                arySAPS[1, 0] = "GroupId";
                arySAPS[1, 1] = this._GroupId;
                arySAPS[1, 2] = "int";
            }

            if (!this._SubdepartmentId.Equals(Default))
            {
                arySAPS[2, 0] = "SubdepartmentId";
                arySAPS[2, 1] = this._SubdepartmentId;
                arySAPS[2, 2] = "int";
            }

            if (!this._TestId.Equals(Default))
            {
                arySAPS[3, 0] = "TestId";
                arySAPS[3, 1] = this._TestId;
                arySAPS[3, 2] = "int";
            }

            if (!this._AttributeId.Equals(Default))
            {
                arySAPS[4, 0] = "AttributeId";
                arySAPS[4, 1] = this._AttributeId;
                arySAPS[4, 2] = "int";
            }

            if (!this._Sex.Equals(Default))
            {
                arySAPS[5, 0] = "Sex";
                arySAPS[5, 1] = this._Sex;
                arySAPS[5, 2] = "string";
            }

            if (!this._Age_Min.Equals(Default))
            {
                arySAPS[6, 0] = "Age_Min";
                arySAPS[6, 1] = this._Age_Min;
                arySAPS[6, 2] = "int";
            }

            if (!this._Age_Max.Equals(Default))
            {
                arySAPS[7, 0] = "Age_Max";
                arySAPS[7, 1] = this._Age_Max;
                arySAPS[7, 2] = "int";
            }

            if (!this._Min_Value.Equals(Default))
            {
                arySAPS[8, 0] = "Min_Value";
                arySAPS[8, 1] = this._Min_Value;
                arySAPS[8, 2] = "string";
            }

            if (!this._Max_Value.Equals(Default))
            {
                arySAPS[9, 0] = "Max_Value";
                arySAPS[9, 1] = this._Max_Value;
                arySAPS[9, 2] = "string";
            }

            if (!this._AUnit.Equals(Default))
            {
                arySAPS[10, 0] = "AUnit";
                arySAPS[10, 1] = this._AUnit;
                arySAPS[10, 2] = "string";
            }

            if (!this._Min_Panic_Value.Equals(Default))
            {
                arySAPS[11, 0] = "Min_Panic_Value";
                arySAPS[11, 1] = this._Min_Panic_Value;
                arySAPS[11, 2] = "string";
            }

            if (!this._Max_Panic_Value.Equals(Default))
            {
                arySAPS[12, 0] = "Max_Panic_Value";
                arySAPS[12, 1] = this._Max_Panic_Value;
                arySAPS[12, 2] = "string";
            }       
            if (!this._Enteredby.Equals(Default))
            {
                arySAPS[13, 0] = "Enteredby";
                arySAPS[13, 1] = this._Enteredby;
                arySAPS[13, 2] = "string";
            }

			if (!this._Enteredon.Equals(Default))
			{
                arySAPS[14, 0] = "Enteredon";
                arySAPS[14, 1] = this._Enteredon;
                arySAPS[14, 2] = "datetime";
			}           
            
            if (!this._ClientId.Equals(Default))
            {
                arySAPS[15, 0] = "ClientId";
                arySAPS[15, 1] = this._ClientId;
                arySAPS[15, 2] = "string";
            }
            if (!this._MethodID.Equals(Default))
            {
                arySAPS[16, 0] = "methodid";
                arySAPS[16, 1] = this._MethodID;
                arySAPS[16, 2] = "int";
            }
            if (!this._Active.Equals(Default))
            {
                arySAPS[17, 0] = "active";
                arySAPS[17, 1] = this._Active;
                arySAPS[17, 2] = "string";
            }
            if (!this._Description.Equals(Default))
            {
                arySAPS[18, 0] = "description";
                arySAPS[18, 1] = this._Description;
                arySAPS[18, 2] = "string";
            }
            if (!this._ASIUnit.Equals(Default))
            {
                arySAPS[19, 0] = "ASIUnit";
                arySAPS[19, 1] = this._ASIUnit;
                arySAPS[19, 2] = "string";
            }
            if (!this._Conversionfactor.Equals(Default) && !this._Conversionfactor.Trim().Equals(""))
            {
                arySAPS[20, 0] = "Conversionfactor";
                arySAPS[20, 1] = this._Conversionfactor;
                arySAPS[20, 2] = "int";
            }
           
            return arySAPS;
		}

		#endregion    

		#region "Validation Functions"

		private bool Validation_Form()
		{
            if (!VD_Method())
            {
                return false;
            }

			return true;
		}
        private bool VD_Method()
        {
            DataView dv = GetAll(10); // 6
            if (dv.Count > 0)
            {
                if (!_RangeId.Equals(Default) && !_RangeId.Equals("") && _RangeId != null)
                    dv.RowFilter = "rangeid <>" + _RangeId;
                if (dv.Count > 0)
                {
                    StrErrorMessage = "This gender and age is already configured with this method.";
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }
              
		#endregion

	}
}

