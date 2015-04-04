using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Odbc;
using DataLayer;

namespace BusinessLayer
{
	public class clsOrganization
	{
		#region Class Variables

		private const string Default = "~!@";
        private const string TableName = "dc_tp_organization";
        private const string TableName2 = "dc_tp_personnel";
		private string StrErrorMessage = "";

		private string _OrgId = Default;
		private string _Name = Default;
        private string _Acronym = Default;

		private string _Active = Default;
        private string _PhoneNo = Default;
        private string _FaxNo = Default;
        private string _Email = Default;

        private string _Web_Address = Default;
        private string _Address = Default;
        private string _Main = Default;
        private string _External = Default;

        private string _Main_of = Default;
        private string _Process_Fee = Default;
        private string _Indoor_Services = Default;

        private string _CollectionCenter = Default;
        private string _DefaultRoute = Default;

        private string _ClientId = Default;        
        private string _Enteredby = Default;
        private string _Enteredon = Default;


		#endregion

		#region Properties
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

        public string Web_Address
        {
            get
            {
                return _Web_Address;
            }
            set
            {
                _Web_Address = value;
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
        public string Main
        {
            get
            {
                return _Main;
            }
            set
            {
                _Main = value;
            }
        }
        public string External
        {
            get { return _External; }
            set { _External = value; }
        }

        public string Main_of
        {
            get
            {
                return _Main_of;
            }
            set
            {
                _Main_of = value;
            }
        }
        public string Process_Fee
        {
            get { return _Process_Fee; }
            set { _Process_Fee = value; }
        }
        public string Indoor_Service
        {
            get { return _Indoor_Services; }
            set { _Indoor_Services = value; }
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

        public string CollectionCenter
        {
            get { return _CollectionCenter; }
            set { _CollectionCenter = value; }
        }
        public string DefaultRoute
        {
            get { return _DefaultRoute; }
            set { _DefaultRoute = value; }
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
                    objdbhims.Query = "select t.OrgId,t.Name,t.Acronym,t.Active,external,ifnull(process_fee,0) as process_fee from " + TableName + " t where 1 = 1";
                    if (!_Main_of.Equals(Default))
                    {
                        objdbhims.Query += " and t.Main_of = '" + _Main_of + "'";
                    }
                    objdbhims.Query += " order by t.Name";
                    break;

				case 2:
                    objdbhims.Query = "select OrgId,Name,Active from " + TableName + " t ";
                    objdbhims.Query = objdbhims.Query + " Where Upper(t.Name) = '" + this._Name.ToUpper() + "'";
					break;

				case 3:
                    objdbhims.Query = "select OrgId,Name,Acronym,PhoneNo,FaxNo,Email,Web_Address,Address,Main,Main_of,ClientId,Active,external,ifnull(process_fee,0) as process_fee,indoor_services,collection_center,default_Route from " + TableName + " where OrgId = " + _OrgId;
					break;

                case 4:
                    objdbhims.Query = "select t.Name,t.OrgId from " + TableName + " t where t.Active='Y'";
                    if (!_Main.Equals(Default))
                    {
                        objdbhims.Query += " and t.Main = '" + _Main + "'";
                    }
                    if (!_External.Equals(Default))
                        objdbhims.Query += " and t.external='" + _External + "'";
                    objdbhims.Query += " order by t.Name";
                    break;

                case 5:
                    objdbhims.Query = "select OrgId,Acronym,Active from " + TableName + " t ";
                    objdbhims.Query = objdbhims.Query + " Where Upper(t.Acronym) = '" + this._Acronym.ToUpper() + "'";
                    break;

                case 6:
                    objdbhims.Query = "select Email from " + TableName + " where OrgId=" + _OrgId;
                    break;
                case 7: // main validate orga
                    objdbhims.Query = "select orgid from "+TableName+" where main='Y'";
                    break;
                case 8: // timing
                    objdbhims.Query = "select start_time, close_time, day from dc_tp_org_timing where orgid='"+_OrgId+"'";
                    break;
			}

			return objTrans.DataTrigger_Get_All(objdbhims);
		}

		public bool Insert(string[,] strArr)
		{
			if (Validation())
			{
				try
				{
					clsoperation objTrans = new clsoperation();
					QueryBuilder objQB = new QueryBuilder();
					objTrans.Start_Transaction();

                    objdbhims.Query = objQB.QBGetMax_Length("OrgId", TableName,"3");
                    this._OrgId = objTrans.DataTrigger_Get_Max(objdbhims);

                    if (!this._OrgId.Equals("True"))
					{
						objdbhims.Query = objQB.QBInsert(MakeArray(), TableName);
						this.StrErrorMessage = objTrans.DataTrigger_Insert(objdbhims);

						

						if (this.StrErrorMessage.Equals("True"))
						{
                            objTrans.End_Transaction();
							this.StrErrorMessage = objTrans.OperationError;
							return false;
						}
						else
						{
                            for (int i = 0; i <= strArr.GetUpperBound(0); i++)
                            {
                                objdbhims.Query = "insert into dc_tp_org_timing (start_time,close_time,day,orgid,enteredby,enteredon,clientid) values ('" + strArr[i, 0] + "','" + strArr[i, 1] + "','" + strArr[i, 2] + "','" + _OrgId + "'," + _Enteredby + ",str_to_date('" + _Enteredon + "','%d/%m/%Y %h:%i:%s %p'),'" + _ClientId + "')";
                                StrErrorMessage = objTrans.DataTrigger_Insert(objdbhims);

                                if (StrErrorMessage.Equals("True"))
                                {
                                    objTrans.End_Transaction();
                                    this.StrErrorMessage = objTrans.OperationError;
                                    return false;
                                }
                            }
                            if (StrErrorMessage.Equals("True"))
                            {
                                objTrans.End_Transaction();
                                this.StrErrorMessage = objTrans.OperationError;
                                return false;
                            }
                            else
                            {
                                objTrans.End_Transaction();
                                
                                return true;
                            }
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

		public bool Update(string[,] strArr)
		{
            if (Validation())
            {
                clsoperation objTrans = new clsoperation();
                QueryBuilder objQB = new QueryBuilder();

                objTrans.Start_Transaction();
                objdbhims.Query = objQB.QBUpdate(MakeArray(), TableName);
                this.StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);
                

                if (this.StrErrorMessage.Equals("True"))
                {
                    objTrans.End_Transaction();
                    this.StrErrorMessage = objTrans.OperationError;
                    return false;
                }
                else
                {
                    objdbhims.Query = "delete from dc_tp_org_timing where orgid='" + _OrgId + "'";
                    StrErrorMessage = objTrans.DataTrigger_Delete(objdbhims);
                    if (StrErrorMessage.Equals("True"))
                    {
                        objTrans.End_Transaction();
                        this.StrErrorMessage = objTrans.OperationError;
                        return false;
                    }

                    for (int i = 0; i <= strArr.GetUpperBound(0); i++)
                    {
                        objdbhims.Query = "insert into dc_tp_org_timing (start_time,close_time,day,orgid,enteredby,enteredon,clientid) values ('" + strArr[i, 0] + "','" + strArr[i, 1] + "','" + strArr[i, 2] + "','" + _OrgId + "'," + _Enteredby + ",str_to_date('" + _Enteredon + "','%d/%m/%Y %h:%i:%s %p'),'" + _ClientId + "')";
                        StrErrorMessage = objTrans.DataTrigger_Insert(objdbhims);

                        if (StrErrorMessage.Equals("True"))
                        {
                            objTrans.End_Transaction();
                            this.StrErrorMessage = objTrans.OperationError;
                            return false;
                        }
                    }
                    if (StrErrorMessage.Equals("True"))
                    {
                        objTrans.End_Transaction();
                        this.StrErrorMessage = objTrans.OperationError;
                        return false;
                    }
                    else
                    {
                        objTrans.End_Transaction();

                        return true;
                    }
                }
            }
            else
            {
                return false;
            }
		}

		private string[,] MakeArray()
		{
			string[,] arySAPS = new string[19, 3];

			if (!this._OrgId.Equals(Default))
			{
                arySAPS[0, 0] = "OrgId";
                arySAPS[0, 1] = this._OrgId;
                arySAPS[0, 2] = "string";
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

            if (!this._Web_Address.Equals(Default))
            {
                arySAPS[9, 0] = "Web_Address";
                arySAPS[9, 1] = this._Web_Address;
                arySAPS[9, 2] = "string";
            }

            if (!this._Address.Equals(Default))
            {
                arySAPS[10, 0] = "Address";
                arySAPS[10, 1] = this._Address;
                arySAPS[10, 2] = "string";
            }

            if (!this._Main.Equals(Default))
            {
                arySAPS[11, 0] = "Main";
                arySAPS[11, 1] = this._Main;
                arySAPS[11, 2] = "string";
            }

            if (!this._ClientId.Equals(Default))
            {
                arySAPS[12, 0] = "ClientId";
                arySAPS[12, 1] = this._ClientId;
                arySAPS[12, 2] = "string";
            }

            if (!this._Main_of.Equals(Default))
            {
                arySAPS[13, 0] = "Main_of";
                arySAPS[13, 1] = this._Main_of;
                arySAPS[13, 2] = "string";
            }
            else
            {
                arySAPS[13, 0] = "Main_of";
                arySAPS[13, 1] = "null";
                arySAPS[13, 2] = "int";
            }
            if (!this._External.Equals(Default))
            {
                arySAPS[14, 0] = "external";
                arySAPS[14, 1] = this._External;
                arySAPS[14, 2] = "string";
            }
            if (!this._Process_Fee.Equals(Default))
            {
                arySAPS[15, 0] = "process_fee";
                arySAPS[15, 1] = this._Process_Fee;
                arySAPS[15, 2] = "int";
            }
            if (!this._Indoor_Services.Equals(Default))
            {
                arySAPS[16, 0] = "indoor_services";
                arySAPS[16, 1] = this._Indoor_Services;
                arySAPS[16, 2] = "string";
            }
            if (!this._CollectionCenter.Equals(Default))
            {
                arySAPS[17, 0] = "collection_center";
                arySAPS[17, 1] = this._CollectionCenter;
                arySAPS[17, 2] = "string";
            }
            if (!this._DefaultRoute.Equals(Default))
            {
                arySAPS[18, 0] = "default_route";
                arySAPS[18, 1] = this._DefaultRoute;
                arySAPS[18, 2] = "string";
            }
            return arySAPS;
		}

		#endregion    

		#region "Validation Functions"

		private bool Validation()
		{
			if (!VD_Organization())
			{
				return false;
			}
            if (!VD_Acronym())
            {
                return false;
            }
            if (!VD_Main())
            {
                return false;
            }
			return true;
		}

        public bool VD_Organization()
		{

			if (this._Name.Equals(""))
			{
				this.StrErrorMessage = "Please Enter Organization Name. (empty is not allowed)";
				return false;
			}

			DataView dvTest = GetAll(2);

            if (!this._OrgId.Equals(Default))
			{
                dvTest.RowFilter = "OrgId <> '" + _OrgId + "' And Name = '" + _Name + "'";
			}
			else
			{
                dvTest.RowFilter = "Name = '" + _Name + "'";
			}

			if (dvTest.Count > 0)
			{
                this.StrErrorMessage = "Please Enter another Organization Name, it is already present.";
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

                if (!this._OrgId.Equals(Default))
                {
                    dvTest.RowFilter = "OrgId <> '" + _OrgId + "' And Acronym = '" + _Acronym + "'";
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

        private bool VD_Main()
        {
            if (_Main.Equals("Y"))
            {
                DataView dv = GetAll(7);
                if (dv.Count > 0)
                {
                    if (!_OrgId.Equals(Default) && !_OrgId.Equals("") && _OrgId != null)
                        dv.RowFilter = "orgid <> '" + _OrgId + "'";
                    if (dv.Count > 0)
                    {
                        StrErrorMessage = "It is already marked Main with other organization";
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
            return true;
        }

        private bool VD_DefaultRoute()
        {
            if (this._DefaultRoute.Equals("-1") && this._External.Equals("N"))
            {
                this.StrErrorMessage = "Please select default routing location.";
                return false;
            }

         

            return true;

        }

		#endregion

	}
}

