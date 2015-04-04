using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataLayer;
using System.Collections;
using BusinessLayer;

/// <summary>
/// Summary description for clsEmailConfiguration
/// </summary>
public class clsEmailConfiguration
{
    clsdbhims objdbhims = new clsdbhims();
    clsoperation objOperation = new clsoperation();

    private const string TableName = "kcdr_temailconfiguration";
    private const string Default = "~!@";
    private string StrError = Default;

    public clsEmailConfiguration()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    // Emailid	Username	Password	SendFrom	KeyNames	HostName	EnableSsl	Active

    private string _Emailid = Default;

    public string Emailid
    {
        get { return _Emailid; }
        set { _Emailid = value; }
    }
    private string _Username = Default;

    public string Username
    {
        get { return _Username; }
        set { _Username = value; }
    }
    private string _Password = Default;

    public string Password
    {
        get { return _Password; }
        set { _Password = value; }
    }
    private string _SendFrom = Default;

    public string SendFrom
    {
        get { return _SendFrom; }
        set { _SendFrom = value; }
    }
    private string _KeyNames = Default;

    public string KeyNames
    {
        get { return _KeyNames; }
        set { _KeyNames = value; }
    }
    private string _HostName = Default;

    public string HostName
    {
        get { return _HostName; }
        set { _HostName = value; }
    }
    private string _EnableSsl = Default;

    public string EnableSsl
    {
        get { return _EnableSsl; }
        set { _EnableSsl = value; }
    }
    private string _Active = Default;

    public string Active
    {
        get { return _Active; }
        set { _Active = value; }
    }

    private string[,] MakeArray()
    { 
        string[,] emailArray = new string[8,3];
        if (!_Emailid.Equals(Default))
        {
            emailArray[0, 0] = "Emailid";
            emailArray[0, 1] = this._Emailid;
            emailArray[0, 2] = "string";
        }
        if(!_Username.Equals(Default))
        {
            emailArray[1, 0] = "Username";
            emailArray[1, 1] = this._Username;
            emailArray[1, 2] = "string";
        }
        if (!_Password.Equals(Default))
        {
            emailArray[2, 0] = "Password";
            emailArray[2, 1] = this._Password;
            emailArray[2, 2] = "string";
        }
        if (!_SendFrom.Equals(Default))
        {
            emailArray[3, 0] = "SendFrom";
            emailArray[3, 1] = this._SendFrom;
            emailArray[3, 2] = "string";
        }
        if (!_KeyNames.Equals(Default))
        {
            emailArray[4, 0] = "KeyNames";
            emailArray[4, 1] = this._KeyNames;
            emailArray[4, 2] = "string";
        }
        if (!_HostName.Equals(Default))
        {
            emailArray[5, 0] = "HostName";
            emailArray[5, 1] = this._HostName;
            emailArray[5, 2] = "string";
        }
        if (!_EnableSsl.Equals(Default))
        {
            emailArray[6, 0] = "EnableSsl";
            emailArray[6, 1] = this._EnableSsl;
            emailArray[6, 2] = "string";
        }
        if (_Active.Equals(Default))
        {
            emailArray[7, 0] = "Active";
            emailArray[7, 1] = this._Active;
            emailArray[7, 2] = "string";
        }
        return MakeArray();
    }

    public DataView GetAll(int option)
    { 
        switch(option)
        {
            case 1:
                objdbhims.Query = "SELECT signature,Emailid,	Username,	Password,	SendFrom,	KeyNames,	HostName,	EnableSsl,	Active,ifnull(Replyaddress,sendfrom) as Replyaddress FROM kcdr_temailconfiguration WHERE Active = 't'";
                break;
            case 2:
                objdbhims.Query = "";
                break;
        }
            return objOperation.DataTrigger_Get_All(objdbhims);
    }

}
