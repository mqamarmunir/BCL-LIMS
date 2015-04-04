using System;
using System.Data;
using DataLayer;

namespace BusinessLayer
{
    /// <summary>
    /// Summary description for clsBLLogin.
    /// </summary>
    public class clsLogin
    {
        private string StrErrorMessage = "";
        private string _PersonId = "";
        private string _Loginid = "";
        private string _Password = "";
        private string _Active = "";
        private string _OptionID = "";
        private string _ClientID = "";
        private string _BranchID = "";

        private string _enteredon = "";

        
        private string _ipaddress = "";

        
        private string _macaddress = "";
        private string _hostname = "";


     


        clsoperation objTrans = new clsoperation();
        clsdbhims objdbhims = new clsdbhims();

        #region Properties

        public string Enteredon
        {
            get { return _enteredon; }
            set { _enteredon = value; }
        }
        public string Ipaddress
        {
            get { return _ipaddress; }
            set { _ipaddress = value; }
        }
        public string macaddress
        {
            get { return _macaddress; }
            set { _macaddress = value; }
        }
        public string hostname
        {
            get { return _hostname; }
            set { _hostname = value; }
        }
        public string PersonId
        {
            get { return _PersonId; }
            set { _PersonId = value; }
        }
        public string Loginid
        {
            get { return _Loginid; }
            set { _Loginid = value; }
        }
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        public string Active
        {
            get { return _Active; }
            set { _Active = value; }
        }
        public string ErrorMessage
        {
            get { return StrErrorMessage; }
            set { StrErrorMessage = value; }
        }
        public string OptionId
        {
            get { return  _OptionID;}
            set { _OptionID = value; }
        }
        public string ClientID
        {
            get { return _ClientID; }
            set { _ClientID = value; }
        }

        public string BranchID
        {
            get { return _BranchID; }
            set { _BranchID = value; }
        }
            
        #endregion

        #region Method
        public DataView GetLogin(int flag)
        {
            switch (flag)
            {
                case 1:

                    objdbhims.Query = "Select ifnull(tb.BranchCode,'') as BranchCode,u.groupid,p.PersonId, p.designationid,concat(p.salutation,p.FName,' ',p.MName,' ',p.LName) as PersonName,tb.Type BrType,p.OrgId,p.subdepartmentid,ifnull(crossdept,'N') as crossdept,p.departmentid,u.defaultpage,p.orgid,ifnull(p.crosslab,'N') as crosslab, (select indoor_services from dc_Tp_organization where orgid=?ClientID) as indoor_services,(select name from dc_Tp_organization where orgid=?ClientID) as orgname,(select default_route from dc_Tp_organization where orgid=?ClientID) as default_route,p.BranchID BranchID,tb.Name BRName,ifnull(tb.cliqbranchid,0) as cliqbranchid from dc_tp_personnel p left outer join dc_tu_userright u on u.personid=p.personid left outer join dc_tp_branch tb on tb.BranchID=p.BranchID Where p.Active='Y' and p.LoginId = ?LoginID and p.Pasword =?Password and p.BranchID=?BranchID";
               //   objdbhims.Query = "Select u.groupid,p.PersonId, p.designationid,concat(p.salutation,p.FName,' ',p.MName,' ',p.LName) as PersonName,tb.Type BrType,p.OrgId,p.subdepartmentid,ifnull(crossdept,'N') as crossdept,p.departmentid,u.defaultpage,p.orgid,ifnull(p.crosslab,'N') as crosslab, (select indoor_services from dc_Tp_organization where orgid='" + _ClientID + "') as indoor_services,(select name from dc_Tp_organization where orgid='" + _ClientID + "') as orgname,(select default_route from dc_Tp_organization where orgid='" + _ClientID+"') as default_route,p.BranchID BranchID,tb.Name BRName from dc_tp_personnel p left outer join dc_tu_userright u on u.personid=p.personid left outer join dc_tp_branch tb on tb.BranchID=p.BranchID Where p.Active='Y' and p.LoginId = '" + _Loginid.ToString() + "' and p.Pasword ='" + _Password.ToString() + "' and p.BranchID='" + _BranchID + "'";
                   
                //return objTrans.DataTrigger_Login(objdbhims ,_ClientID,_Loginid.ToString(),_Loginid.ToString(),  _BranchID );
               break;
                case 2: // user matrix
                    objdbhims.Query = "select gr.OptionId from dc_tu_userright m,dc_tu_accessgroup ag,dc_tu_groupright gr where ag.GroupId = gr.GroupId and m.GroupId = gr.GroupId and ag.Active = 'Y' and m.Active = 'Y' and m.personid = "+_PersonId+" and gr.OptionId = "+_OptionID+"";
                    break;
                case 3: // access option user wise
                    objdbhims.Query = "SELECT distinct o.optionid,o.optionname FROM dc_tu_accessoption o left outer join dc_tu_groupright r on o.optionid=r.optionid left outer join dc_tu_userright u on r.groupid = u.groupid where u.personid="+_PersonId+" order by o.optionid";
                    break;
                case 4: // get password for change
                    objdbhims.Query = "select pasword from dc_tp_personnel where personid="+_PersonId+"";
                    break;
                case 5: // get version
                    objdbhims.Query = "select edUl as version,oWZUjiWb as exp_date,Z_hf as prid,(select max(prid) from dc_tpatient) as maxPRID from behjdeyuluyz where Z_ffW ='`'";
                    break;
            }
            if (flag == 1)
            {
                return objTrans.DataTrigger_Login(objdbhims, _ClientID, _Loginid.ToString(), _Password.ToString(), _BranchID);
            }
            return objTrans.DataTrigger_Get_All(objdbhims);
        }

        public bool Update_Password()
        {
            objTrans.Start_Transaction();
            objdbhims.Query = "update dc_Tp_personnel set pasword='"+_Password+"' where personid="+_PersonId+"";
            StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);

            if (StrErrorMessage.Equals("True"))
            {
                StrErrorMessage = objTrans.OperationError;
                objTrans.End_Transaction();
                return false;
            }
            else
            {
                objTrans.End_Transaction();
                return true;
            }

        }

        public bool insert()
        {
            try
            {
                clsoperation objTrans = new clsoperation();
                QueryBuilder objQB = new QueryBuilder();
                objTrans.Start_Transaction();

                objdbhims.Query = objQB.QBInsert(MakeArray(), "SessionInfo");
                this.StrErrorMessage = objTrans.DataTrigger_Insert(objdbhims);

                objTrans.End_Transaction();

                if (this.StrErrorMessage.Equals("True"))
                {
                    this.StrErrorMessage = objTrans.OperationError;
                    return false;
                }
                

            }
            catch (Exception e)
            {
                this.StrErrorMessage = e.Message;
                return false;
            }
            return true;
        }

        private string[,] MakeArray()
        {
            string[,] aryMeth = new string[5, 3];

            if (!_PersonId.Equals(""))
            {
                aryMeth[0, 0] = "PersonId";
                aryMeth[0, 1] = this._PersonId;
                aryMeth[0, 2] = "int";
            }
            if (!_ipaddress.Equals(""))
            {
                aryMeth[1, 0] = "ipaddress";
                aryMeth[1, 1] = this._ipaddress;
                aryMeth[1, 2] = "string";
            }
            if (!_macaddress.Equals(""))
            {
                aryMeth[2, 0] = "macaddress";
                aryMeth[2, 1] = this._macaddress;
                aryMeth[2, 2] = "string";
            }
            if (!_hostname.Equals(""))
            {
                aryMeth[3, 0] = "hostname";
                aryMeth[3, 1] = this._hostname;
                aryMeth[3, 2] = "string";
            }
            if (!_enteredon.Equals(""))
            {
                aryMeth[4, 0] = "enteredon";
                aryMeth[4, 1] = this._enteredon;
                aryMeth[4, 2] = "datetime";
            }
            

            return aryMeth;
        }

        //public bool Delete()
        //{
        //    //objdbhims.Query = @"Delete from sessioninfo where personid=" + PersonId;
        //}
            
        #endregion

        public clsLogin()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
