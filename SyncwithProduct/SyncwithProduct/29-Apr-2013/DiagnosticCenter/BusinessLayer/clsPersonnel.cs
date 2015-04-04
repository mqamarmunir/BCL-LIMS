using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Odbc;
using DataLayer;

namespace BusinessLayer
{
	public class clsPersonnel
	{
		#region Class Variables

		private const string Default = "~!@";       
        private const string TableName = "dc_tp_personnel";
        private const string TableName2 = "dc_tp_organization";
        private const string TableName3 = "dc_tp_departments";
        private const string TableName4 = "dc_tp_subdepartments";
        private const string TableName5 = "dc_tp_designations";
		private string StrErrorMessage = "";

        private string _PersonId = Default;
        private string _OrgId = Default;        
        private string _DepartmentId = Default;
        private string _SubdepartmentId = Default;
        private string _DesignationId = Default;
        private string _ServiceNo = Default;
        private string _Salutation = Default; 
		private string _FName = Default;
        private string _MName = Default;
        private string _LName = Default;
        private string _Acronym = Default;
		private string _Active = Default;
        private string _FHName = Default;
        private string _Sex = Default;
        private string _DOB = Default;
        private string _BloodGroup = Default;
        private string _MS = Default;
        private string _NIC = Default;

        private string _NICValidUpto = Default;
        private string _Passport = Default;
        private string _PassportValidUpto = Default;
        private string _HPhoneNo1 = Default;
        private string _HPhoneNo2 = Default;
        private string _OPhoneNo1 = Default;
        private string _OPhoneNo2 = Default;
        private string _CPhoneNo = Default;
        private string _Email = Default;
        private string _CurrentAddress = Default;
        private string _PermanentAddress = Default;
        private string _PictureRef = Default;
        private string _LoginId = Default;
        private string _Pasword = Default;
        private string _ConfirmPasword = Default;
        private string _JoiningDate = Default;
        private string _LeavingDate = Default;

        private string _Education = Default;
        private string _Nature = Default;
        private string _ContractExpiry = Default;
        private string _ReferenceCode = Default;

        private string _Salary = Default;
        private string _FaxNo = Default;
        private string _CrossDept = Default;
        private string _CrossLab = Default;

        private string _ClientId = Default;        
        private string _Enteredby = Default;
        private string _Enteredon = Default;

        private string _BranchID = Default;

      


		#endregion

		#region Properties

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

        public string ServiceNo
        {
            get
            {
                return _ServiceNo;
            }
            set
            {
                _ServiceNo = value;
            }
        }

        public string Salutation
        {
            get
            {
                return _Salutation;
            }
            set
            {
                _Salutation = value;
            }
        }

        public string FName
        {
            get
            {
                return _FName;
            }
            set
            {
                _FName = value;
            }
        }

        public string MName
        {
            get
            {
                return _MName;
            }
            set
            {
                _MName = value;
            }
        }

        public string LName
        {
            get
            {
                return _LName;
            }
            set
            {
                _LName = value;
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
        public string FHName
        {
            get
            {
                return _FHName;
            }
            set
            {
                _FHName = value;
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
        public string DOB
        {
            get
            {
                return _DOB;
            }
            set
            {
                _DOB = value;
            }
        }
        public string BloodGroup
        {
            get
            {
                return _BloodGroup;
            }
            set
            {
                _BloodGroup = value;
            }
        }
        public string MS
        {
            get
            {
                return _MS;
            }
            set
            {
                _MS = value;
            }
        }
        public string NIC
        {
            get
            {
                return _NIC;
            }
            set
            {
                _NIC = value;
            }
        }
        public string NICValidUpto
        {
            get
            {
                return _NICValidUpto;
            }
            set
            {
                _NICValidUpto = value;
            }
        }
        public string Passport
        {
            get
            {
                return _Passport;
            }
            set
            {
                _Passport = value;
            }
        }
        public string PassportValidUpto
        {
            get
            {
                return _PassportValidUpto;
            }
            set
            {
                _PassportValidUpto = value;
            }
        }
        public string HPhoneNo1
        {
            get
            {
                return _HPhoneNo1;
            }
            set
            {
                _HPhoneNo1 = value;
            }
        }
        public string HPhoneNo2
        {
            get
            {
                return _HPhoneNo2;
            }
            set
            {
                _HPhoneNo2 = value;
            }
        }
        public string OPhoneNo1
        {
            get
            {
                return _OPhoneNo1;
            }
            set
            {
                _OPhoneNo1 = value;
            }
        }

        public string OPhoneNo2
        {
            get
            {
                return _OPhoneNo2;
            }
            set
            {
                _OPhoneNo2 = value;
            }
        }
        public string CPhoneNo
        {
            get
            {
                return _CPhoneNo;
            }
            set
            {
                _CPhoneNo = value;
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
        public string CurrentAddress
        {
            get
            {
                return _CurrentAddress;
            }
            set
            {
                _CurrentAddress = value;
            }
        }
        public string PermanentAddress
        {
            get
            {
                return _PermanentAddress;
            }
            set
            {
                _PermanentAddress = value;
            }
        }
        public string PictureRef
        {
            get
            {
                return _PictureRef;
            }
            set
            {
                _PictureRef = value;
            }
        }
        public string LoginId
        {
            get
            {
                return _LoginId;
            }
            set
            {
                _LoginId = value;
            }
        }

        public string Pasword
        {
            get
            {
                return _Pasword;
            }
            set
            {
                _Pasword = value;
            }
        }

        public string ConfirmPasword
        {
            get
            {
                return _ConfirmPasword;
            }
            set
            {
                _ConfirmPasword = value;
            }
        }

        public string JoiningDate
        {
            get
            {
                return _JoiningDate;
            }
            set
            {
                _JoiningDate = value;
            }
        }
        public string LeavingDate
        {
            get
            {
                return _LeavingDate;
            }
            set
            {
                _LeavingDate = value;
            }
        }
        public string Education
        {
            get
            {
                return _Education;
            }
            set
            {
                _Education = value;
            }
        }
        public string Nature
        {
            get
            {
                return _Nature;
            }
            set
            {
                _Nature = value;
            }
        }

        public string ContractExpiry
        {
            get
            {
                return _ContractExpiry;
            }
            set
            {
                _ContractExpiry = value;
            }
        }
        public string ReferenceCode
        {
            get
            {
                return _ReferenceCode;
            }
            set
            {
                _ReferenceCode = value;
            }
        }

        public string Salary
        {
            get
            {
                return _Salary;
            }
            set
            {
                _Salary = value;
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
        public string CrossDept
        {
            get { return _CrossDept; }
            set { _CrossDept = value; }
        }
        public string CrossLab
        {
            get { return _CrossLab; }
            set { _CrossLab = value; }
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
        public string BranchID
        {
            get { return _BranchID; }
            set { _BranchID = value; }
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
                    objdbhims.Query = "select p.PersonId,concat(p.FName,' ',p.MName,' ',p.LName) as PersonName,p.Acronym,d.Name as DeptName,p.Active from " + TableName + " p left outer join " + TableName3 + " d on p.DepartmentId = d.DepartmentId where 1 = 1";
                    if (!_OrgId.Equals(Default))
                    {
                        objdbhims.Query += " and p.OrgId = " + _OrgId;
                    }
                    if (!_DepartmentId.Equals(Default))
                    {
                        objdbhims.Query += " and p.DepartmentId = " + _DepartmentId;
                    }
                    if (!_SubdepartmentId.Equals(Default))
                    {
                        objdbhims.Query += " and p.SubdepartmentId = " + _SubdepartmentId;
                    }
                    if (!_DesignationId.Equals(Default))
                    {
                        objdbhims.Query += " and p.DesignationId = " + _DesignationId;
                    }
                    if (!_BranchID.Equals(Default))
                    {
                        objdbhims.Query += " and p.BranchID = " + _BranchID;
                    }
                    objdbhims.Query += " order by PersonName";
                    break;

				case 2:
                    objdbhims.Query = "select PersonId,concat(FName,MName,LName) as PersonName,Active from " + TableName + " t ";
                    objdbhims.Query = objdbhims.Query + " Where concat(Upper(FName),Upper(MName),Upper(LName)) = '" + this._FName.ToUpper() + this._MName.ToUpper() + this._LName.ToUpper() + "'";
					break;

				case 3:
                    objdbhims.Query = "select PersonId,OrgId,DepartmentId,SubdepartmentId,DesignationId,ServiceNo,Salutation,FName,MName,LName,Acronym,FHName,Sex,date_format(DOB,'%d/%m/%Y') as DOB,BloodGroup,MS,NIC,date_format(NICValidUpto,'%d/%m/%Y') as NICValidUpto,Passport,date_format(PassportValidUpto,'%d/%m/%Y') as PassportValidUpto,HPhoneNo1,HPhoneNo2";
                    objdbhims.Query += ",OPhoneNo1,OPhoneNo2,CPhoneNo,Email,CurrentAddress,PermanentAddress,PictureRef,LoginId,Pasword,date_format(JoiningDate,'%d/%m/%Y') as JoiningDate,date_format(LeavingDate,'%d/%m/%Y') as LeavingDate,Education,Nature,date_format(ContractExpiry,'%d/%m/%Y') as ContractExpiry,ReferenceCode,Salary,FaxNo,ClientId,Active,crossdept,crosslab from " + TableName + " where PersonId = '" + _PersonId + "'";
					break;

                case 4:
                    objdbhims.Query = "select concat(p.FName,' ',p.MName,' ',p.LName) as Name,p.PersonId from " + TableName + " p where p.Active='Y'";
                    if (!_OrgId.Equals(Default))
                    {
                        objdbhims.Query += " and p.OrgId = " + _OrgId;
                    }
                    if (!_DepartmentId.Equals(Default))
                    {
                        objdbhims.Query += " and p.DepartmentId = " + _DepartmentId;
                    }
                    objdbhims.Query += " order by Name";
                    break;

                case 5:
                    objdbhims.Query = "select PersonId,LoginId,Pasword from " + TableName + " t ";
                    objdbhims.Query = objdbhims.Query + " where Upper(t.LoginID) like '%'||'" + this.LoginId.ToUpper() + "'||'%'";
                    break;

                case 6:
                    objdbhims.Query = "select PersonId,Acronym,Active from " + TableName + " t ";
                    objdbhims.Query = objdbhims.Query + " Where Upper(Acronym) = '" + this._Acronym.ToUpper() + "'";
                    break;
                case 7:
                    objdbhims.Query="Select Max(PersonID) as MaxID From "+TableName;
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

                    objdbhims.Query = objQB.QBGetMax("PersonId", TableName);
                    this._PersonId = objTrans.DataTrigger_Get_Max(objdbhims);

                    if (!this._PersonId.Equals("True"))
					{
               //         this._PersonId = this._PersonId.PadLeft(6,'0').ToString();
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
			string[,] arySAPS = new string[46, 3];

			if (!this._PersonId.Equals(Default))
			{
                arySAPS[0, 0] = "PersonId";
                arySAPS[0, 1] = this._PersonId;
                arySAPS[0, 2] = "int";
			}

            if (!this._OrgId.Equals(Default))
            {
                arySAPS[1, 0] = "OrgId";
                arySAPS[1, 1] = this._OrgId;
                arySAPS[1, 2] = "string";
            }

            if (!this._DepartmentId.Equals(Default))
            {
                arySAPS[2, 0] = "DepartmentId";
                arySAPS[2, 1] = this._DepartmentId;
                arySAPS[2, 2] = "int";
            }

            if (!this._SubdepartmentId.Equals(Default))
            {
                arySAPS[3, 0] = "SubdepartmentId";
                arySAPS[3, 1] = this._SubdepartmentId;
                arySAPS[3, 2] = "int";
            }

            if (!this._DesignationId.Equals(Default))
            {
                arySAPS[4, 0] = "DesignationId";
                arySAPS[4, 1] = this._DesignationId;
                arySAPS[4, 2] = "int";
            }
			if (!this._ServiceNo.Equals(Default))
			{
                arySAPS[5, 0] = "ServiceNo";
                arySAPS[5, 1] = this._ServiceNo;
                arySAPS[5, 2] = "string";
			}

            if (!this.Active.Equals(Default))
            {
                arySAPS[6, 0] = "Active";
                arySAPS[6, 1] = this.Active;
                arySAPS[6, 2] = "string";
            }

            if (!this._Enteredby.Equals(Default))
            {
                arySAPS[7, 0] = "Enteredby";
                arySAPS[7, 1] = this._Enteredby;
                arySAPS[7, 2] = "string";
            }

			if (!this._Enteredon.Equals(Default))
			{
                arySAPS[8, 0] = "Enteredon";
                arySAPS[8, 1] = this._Enteredon;
                arySAPS[8, 2] = "datetime";
			}

            if (!this._Salutation.Equals(Default))
            {
                arySAPS[9, 0] = "Salutation";
                arySAPS[9, 1] = this._Salutation;
                arySAPS[9, 2] = "string";
            }

            if (!this._Acronym.Equals(Default))
            {
                arySAPS[10, 0] = "Acronym";
                arySAPS[10, 1] = this._Acronym;
                arySAPS[10, 2] = "string";
            }

            if (!this._FName.Equals(Default))
            {
                arySAPS[11, 0] = "FName";
                arySAPS[11, 1] = this._FName;
                arySAPS[11, 2] = "string";
            }

            if (!this._MName.Equals(Default))
            {
                arySAPS[12, 0] = "MName";
                arySAPS[12, 1] = this._MName;
                arySAPS[12, 2] = "string";
            }

            if (!this._LName.Equals(Default))
            {
                arySAPS[13, 0] = "LName";
                arySAPS[13, 1] = this._LName;
                arySAPS[13, 2] = "string";
            }

            if (!this._FHName.Equals(Default))
            {
                arySAPS[14, 0] = "FHName";
                arySAPS[14, 1] = this._FHName;
                arySAPS[14, 2] = "string";
            }

            if (!this._Sex.Equals(Default))
            {
                arySAPS[15, 0] = "Sex";
                arySAPS[15, 1] = this._Sex;
                arySAPS[15, 2] = "string";
            }

            if (!this._DOB.Equals(Default))
            {
                arySAPS[16, 0] = "DOB";
                arySAPS[16, 1] = this._DOB;
                arySAPS[16, 2] = "date";
            }
            if (!this._BloodGroup.Equals(Default))
            {
                arySAPS[17, 0] = "BloodGroup";
                arySAPS[17, 1] = this._BloodGroup;
                arySAPS[17, 2] = "string";
            }
            if (!this._MS.Equals(Default))
            {
                arySAPS[18, 0] = "MS";
                arySAPS[18, 1] = this._MS;
                arySAPS[18, 2] = "string";
            }
            if (!this._NIC.Equals(Default))
            {
                arySAPS[19, 0] = "NIC";
                arySAPS[19, 1] = this._NIC;
                arySAPS[19, 2] = "string";
            }
            if (!this._NICValidUpto.Equals(Default))
            {
                arySAPS[20, 0] = "NICValidUpto";
                arySAPS[20, 1] = this._NICValidUpto;
                arySAPS[20, 2] = "date";
            }
            if (!this._Passport.Equals(Default))
            {
                arySAPS[21, 0] = "Passport";
                arySAPS[21, 1] = this._Passport;
                arySAPS[21, 2] = "string";
            }
            if (!this._PassportValidUpto.Equals(Default))
            {
                arySAPS[22, 0] = "PassportValidUpto";
                arySAPS[22, 1] = this._PassportValidUpto;
                arySAPS[22, 2] = "date";
            }
            if (!this._HPhoneNo1.Equals(Default))
            {
                arySAPS[23, 0] = "HPhoneNo1";
                arySAPS[23, 1] = this._HPhoneNo1;
                arySAPS[23, 2] = "string";
            }
            if (!this._HPhoneNo2.Equals(Default))
            {
                arySAPS[24, 0] = "HPhoneNo2";
                arySAPS[24, 1] = this._HPhoneNo2;
                arySAPS[24, 2] = "string";
            }
            if (!this._OPhoneNo1.Equals(Default))
            {
                arySAPS[25, 0] = "OPhoneNo1";
                arySAPS[25, 1] = this._OPhoneNo1;
                arySAPS[25, 2] = "string";
            }
            if (!this._OPhoneNo2.Equals(Default))
            {
                arySAPS[26, 0] = "OPhoneNo2";
                arySAPS[26, 1] = this._OPhoneNo2;
                arySAPS[26, 2] = "string";
            }
            if (!this._CPhoneNo.Equals(Default))
            {
                arySAPS[27, 0] = "CPhoneNo";
                arySAPS[27, 1] = this._CPhoneNo;
                arySAPS[27, 2] = "string";
            }
            if (!this._Email.Equals(Default))
            {
                arySAPS[28, 0] = "Email";
                arySAPS[28, 1] = this._Email;
                arySAPS[28, 2] = "string";
            }
            if (!this._CurrentAddress.Equals(Default))
            {
                arySAPS[29, 0] = "CurrentAddress";
                arySAPS[29, 1] = this._CurrentAddress;
                arySAPS[29, 2] = "string";
            }
            if (!this._PermanentAddress.Equals(Default))
            {
                arySAPS[30, 0] = "PermanentAddress";
                arySAPS[30, 1] = this._PermanentAddress;
                arySAPS[30, 2] = "string";
            }
            if (!this._PictureRef.Equals(Default))
            {
                arySAPS[31, 0] = "PictureRef";
                arySAPS[31, 1] = this._PictureRef;
                arySAPS[31, 2] = "string";
            }
            if (!this._LoginId.Equals(Default))
            {
                arySAPS[32, 0] = "LoginId";
                arySAPS[32, 1] = this._LoginId;
                arySAPS[32, 2] = "string";
            }
            if (!this._Pasword.Equals(Default))
            {
                arySAPS[33, 0] = "Pasword";
                arySAPS[33, 1] = this._Pasword;
                arySAPS[33, 2] = "string";
            }
            if (!this._JoiningDate.Equals(Default))
            {
                arySAPS[34, 0] = "JoiningDate";
                arySAPS[34, 1] = this._JoiningDate;
                arySAPS[34, 2] = "date";
            }
            if (!this._LeavingDate.Equals(Default))
            {
                arySAPS[35, 0] = "LeavingDate";
                arySAPS[35, 1] = this._LeavingDate;
                arySAPS[35, 2] = "date";
            }
            if (!this._Education.Equals(Default))
            {
                arySAPS[36, 0] = "Education";
                arySAPS[36, 1] = this._Education;
                arySAPS[36, 2] = "string";
            }
            if (!this._Nature.Equals(Default))
            {
                arySAPS[37, 0] = "Nature";
                arySAPS[37, 1] = this._Nature;
                arySAPS[37, 2] = "string";
            }
            if (!this._ContractExpiry.Equals(Default))
            {
                arySAPS[38, 0] = "ContractExpiry";
                arySAPS[38, 1] = this._ContractExpiry;
                arySAPS[38, 2] = "date";
            }
            if (!this._ReferenceCode.Equals(Default))
            {
                arySAPS[39, 0] = "ReferenceCode";
                arySAPS[39, 1] = this._ReferenceCode;
                arySAPS[39, 2] = "string";
            }
            if (!this._Salary.Equals(Default))
            {
                arySAPS[40, 0] = "Salary";
                arySAPS[40, 1] = this._Salary;
                arySAPS[40, 2] = "int";
            }
            if (!this._FaxNo.Equals(Default))
            {
                arySAPS[41, 0] = "FaxNo";
                arySAPS[41, 1] = this._FaxNo;
                arySAPS[41, 2] = "string";
            }            
            if (!this._ClientId.Equals(Default))
            {
                arySAPS[42, 0] = "ClientId";
                arySAPS[42, 1] = this._ClientId;
                arySAPS[42, 2] = "string";
            }
            if (!this._CrossDept.Equals(Default))
            {
                arySAPS[43, 0] = "crossdept";
                arySAPS[43, 1] = this._CrossDept;
                arySAPS[43, 2] = "string";
            }
            if (!this._CrossLab.Equals(Default))
            {
                arySAPS[44, 0] = "crosslab";
                arySAPS[44, 1] = this._CrossLab;
                arySAPS[44, 2] = "string";
            }

            if (!this._BranchID.Equals(Default))
            {
                arySAPS[45, 0] = "BranchID";
                arySAPS[45, 1] = this._BranchID;
                arySAPS[45, 2] = "int";
            }

            return arySAPS;
		}

		#endregion    		

        #region "Validation Functions"

        private bool Validation()
        {
            if (!VD_Person())
            {
                return false;
            }           
            if (!VD_Salutation())
            {
                return false;
            }
            if (!VD_FName())
            {
                return false;
            }

            if (!VD_Acronym())
            {
                return false;
            }

            if (!VD_FHName())
            {
                return false;
            }

            if (!VD_Sex())
            {
                return false;
            }
           
            if (!VD_MS())
            {
                return false;
            }

            if (!VD_Contract())
            {
                return false;
            }

            //if (!VD_Date())
            //{
            //    return false;
            //}

            if (!VD_Email())
            {
                return false;
            }            
           
            //if (!VD_BloodGroup())
            //{
            //    return false;
            //}            

            //if (!VD_Organization())
            //{
            //    return false;
            //}
            if (!VD_Designation())
            {
                return false;
            }
            if (!VD_Department())
            {
                return false;
            }
            if (!VD_SubDepartment())
            {
                return false;
            }

            if (!VD_LoginID())
            {
                return false;
            }
            if (!VD_Pasword())
            {
                return false;
            }
            
            return true;
        }

        public bool VD_Person()
        {
            clsValidation objValid = new clsValidation();
            if (this._FName.Equals("") || this._FName.Equals(Default))
            {
                this.StrErrorMessage = "Please Enter First Name. (empty is not allowed)";
                return false;
            }

            DataView dvTest = GetAll(2);

            if (!this._PersonId.Equals(Default))
            {
                dvTest.RowFilter = "PersonId <> '" + _PersonId + "' And PersonName = '" + this._FName.ToUpper() + this._MName.ToUpper() + this._LName.ToUpper() + "'";
            }
            else
            {
                dvTest.RowFilter = "PersonName = '" + this._FName.ToUpper() + this._MName.ToUpper() + this._LName.ToUpper() + "'";
            }

            if (dvTest.Count > 0)
            {
                this.StrErrorMessage = "Please Enter another Person Name, it is already present.";
                return false;
            }

            if (!this._FName.Equals("") && !this._FName.Equals(Default))
            {
                if (!objValid.IsName(this.FName))
                {
                    this.StrErrorMessage = "Please enter valid FName. Use only (A-Z or a-z) letters.";
                    return false;
                }
            }

            if (!this._MName.Equals("") && !this._MName.Equals(Default))
            {
                if (!objValid.IsName(this.MName))
                {
                    this.StrErrorMessage = "Please enter valid MName. Use only (A-Z or a-z) letters.";
                    return false;
                }
            }

            if (!this._LName.Equals("") && !this._LName.Equals(Default))
            {
                if (!objValid.IsName(this.LName))
                {
                    this.StrErrorMessage = "Please enter valid LName. Use only (A-Z or a-z) letters.";
                    return false;
                }
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

        public bool VD_Designation()
        {            
            if (this._DesignationId.Equals(Default))
            {
                this.StrErrorMessage = "Please Select Designation First. (empty is not allowed)";
                return false;
            }
            return true;
        }

        public bool VD_Department()
        {
            if (this._DepartmentId.Equals(Default))
            {
                this.StrErrorMessage = "Please Select Department First. (empty is not allowed)";
                return false;
            }
            return true;
        }

        public bool VD_SubDepartment()
        {
            if (this._SubdepartmentId.Equals(Default))
            {
                this.StrErrorMessage = "Please Select Sub Department First. (empty is not allowed)";
                return false;
            }
            return true;
        }

        public bool VD_Salutation()
        {
            if (this._Salutation.Equals(Default))
            {
                this.StrErrorMessage = "Please Select Salutation First. (empty is not allowed)";
                return false;
            }
            return true;
        }

        public bool VD_FName()
        {
            clsValidation objValid = new clsValidation();
            if (this._FName.Equals("") || this._FName.Equals(Default))
            {
                this.StrErrorMessage = "Please enter FName. (empty is not allowed)";
                return false;
            }
            else if (!objValid.IsName(this.FName))
            {
                this.StrErrorMessage = "Please enter valid FName. Use only (A-Z or a-z) characters.";
                return false;
            }
            else
                return true;
        }

        public bool VD_FHName()
        {
            clsValidation objValid = new clsValidation();

            if (!this._FHName.Equals("") && !objValid.IsName(this.FHName))
            {
                this.StrErrorMessage = "Please enter valid FH Name . Use only (A-Z or a-z) letters.";
                return false;
            }
            else
                return true;
        }

        public bool VD_Sex()
        {           
            if (this._Sex.Equals(Default))
            {
                this.StrErrorMessage = "Please Select Gender First . (empty is not allowed)";
                return false;
            }
            return true;
        }       

        public bool VD_BloodGroup()
        {
            if (this._BloodGroup.Equals(Default))
            {
                this.StrErrorMessage = "Please Select Blood Group First . (empty is not allowed)";
                return false;
            }
            return true;
        }

        public bool VD_MS()
        {
            if (this._MS.Equals(Default))
            {
                this.StrErrorMessage = "Please Select Marital Status First . (empty is not allowed)";
                return false;
            }
            return true;
        }

        public bool VD_LoginID()
        {
            if (this._LoginId.Equals(""))
            {
                this.StrErrorMessage = "Please Enter LoginID First . (empty is not allowed)";
                return false;
            }

            DataView dvTest = GetAll(5);

            if (!this._PersonId.Equals(Default))
            {
                dvTest.RowFilter = "PersonID <> '" + _PersonId + "' And LoginID = '" + _LoginId + "'";
            }
            else
            {
                dvTest.RowFilter = "LoginID = '" + _LoginId + "'";
            }

            if (dvTest.Count > 0)
            {
                this.StrErrorMessage = "Please Enter another Login, it is already present.";
                return false;
            }
            return true;
        }

        public bool VD_Pasword()
        {
            if (this._Pasword.Equals(""))
            {
                this.StrErrorMessage = "Please Enter Password First . (empty is not allowed)";
                return false;
            }

            if (this._ConfirmPasword.Equals(""))
            {
                this.StrErrorMessage = "Please Enter Confirm Password First . (empty is not allowed)";
                return false;
            }

            if (!this._Pasword.Equals(this._ConfirmPasword))
            {
                this.StrErrorMessage = "Password and Confirm Password does not match . (enter password again)";
                return false;
            }

            return true;
        }

        public bool VD_Contract()
        {
            if (this._Nature.Equals("C"))
            {
                if (this._ContractExpiry.Equals("") || this._ContractExpiry.Equals(Default))
                {
                    this.StrErrorMessage = "Please Enter Contract Expiry Date First . (empty is not allowed)";
                    return false;
                }
            }
            return true;
        }

        private bool VD_Acronym()
        {
            if (this._Acronym.Equals("") || this._Acronym.Equals(Default))
            {
                this.StrErrorMessage = "Please Enter Acronym. (empty is not allowed)";
                return false;
            }
            if (!this._Acronym.Equals("") && !this._Acronym.Equals(Default))
            {
                DataView dvTest = GetAll(6);

                if (!this._PersonId.Equals(Default))
                {
                    dvTest.RowFilter = "PersonID <> '" + _PersonId + "' And Acronym = '" + _Acronym + "'";
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

        private bool VD_Date()
        {
            clsValidation objValid = new clsValidation();

            if (!this.DOB.Equals(Default) && !this.DOB.Equals(""))
            {
                if (!objValid.IsDate(this.DOB))
                {
                    this.StrErrorMessage = "Please enter valid DOB (Date of Birth).";
                    return false;
                }
            }

            if (!this.NICValidUpto.Equals(Default) && !this.NICValidUpto.Equals(""))
            {
                if (!objValid.IsDate(this.NICValidUpto))
                {
                    this.StrErrorMessage = "Please enter valid NIC Valid Upto date.";
                    return false;
                }
            }

            if (!this.PassportValidUpto.Equals(Default) && !this.PassportValidUpto.Equals(""))
            {

                if (!objValid.IsDate(this.PassportValidUpto))
                {
                    this.StrErrorMessage = "Please enter valid Passport Valid Upto date.";
                    return false;
                }

            }

            if (!this.JoiningDate.Equals(Default) && !this.JoiningDate.Equals(""))
            {
                if (!objValid.IsDate(this.JoiningDate))
                {
                    this.StrErrorMessage = "Please enter valid Joining date.";
                    return false;
                }
            }

            if (!this.LeavingDate.Equals(Default) && !this.LeavingDate.Equals(""))
            {
                if (!objValid.IsDate(this.LeavingDate))
                {
                    this.StrErrorMessage = "Please enter valid Retiring date.";
                    return false;
                }
            }

            if (!(this.LeavingDate.Equals(Default) || this.LeavingDate.Equals("")) && !(this.JoiningDate.Equals(Default) || this.JoiningDate.Equals("")))
            {
                if (Convert.ToDateTime(this.LeavingDate) < Convert.ToDateTime(this.JoiningDate))
                {
                    this.StrErrorMessage = "Retiring date can't be before joining date.";
                    return false;
                }
            }

            if (!this.ContractExpiry.Equals(Default) && !this.ContractExpiry.Equals(""))
            {
                if (!objValid.IsDate(this.ContractExpiry))
                {
                    this.StrErrorMessage = "Please enter valid Contact Expiry date.";
                    return false;
                }
            }
            return true;
        }

        private bool VD_Email()
        {
            clsValidation objValid = new clsValidation();

            if (!this.Email.Equals("") && !this.Email.Equals(Default))
            {
                if (!objValid.IsEmail(this.Email))
                {
                    this.StrErrorMessage = "Please enter valid Email address.";
                    return false;
                }
            }
            return true;
        }

        //private bool Validation()
        //{
        //    if (!VD_Station())
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        //public bool VD_Station()
        //{

        //    if (this._FName.Equals(""))
        //    {
        //        this.StrErrorMessage = "Please Enter Person Name. (empty is not allowed)";
        //        return false;
        //    }

        //    DataView dvTest = GetAll(2);

        //    if (!this._PersonId.Equals(Default))
        //    {
        //        dvTest.RowFilter = "PersonId <> '" + _PersonId + "' And PersonName = '" + this._FName.ToUpper() + this._MName.ToUpper() + this._LName.ToUpper() + "'";
        //    }
        //    else
        //    {
        //        dvTest.RowFilter = "PersonName = '" + this._FName.ToUpper() + this._MName.ToUpper() + this._LName.ToUpper() + "'";
        //    }

        //    if (dvTest.Count > 0)
        //    {
        //        this.StrErrorMessage = "Please Enter another Person Name, it is already present.";
        //        return false;
        //    }

        //    return true;
        //}

		#endregion

	}
}

