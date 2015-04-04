using System;
using System.Collections.Generic;
using System.Text;
using DataLayer;
using System.Data;

namespace BusinessLayer
{
  public  class clsBLWard
  {
      clsoperation ObjTrans = new clsoperation();
      clsdbhims objdbhims = new clsdbhims();

      #region "Variables"

      private const string TableName = "dc_tp_WARD";
      private const string Default = "~!@";

      private string StrError = Default;
      private string StrWardID = Default;
      private string strName = Default;

      private string StrAcronym = Default;
      private string StrDesccription = Default;
      private string StrActive = Default;
      private string _BranchID = Default;

      
      private string StrEnteredBy = Default;
      private string StrEnteredOn = Default;
      private string StrClientID = Default;

      #endregion

      #region"Properties"
      public string BranchID
      {
          get { return _BranchID; }
          set { _BranchID = value; }
      }
      public string WardID
      {
          set { StrWardID = value; }
          get { return StrWardID; }
      }
      public string Name
      {
          get { return strName; }
          set { strName = value; }
      }
      public string Acronym
      {
          get { return StrAcronym; }
          set { StrAcronym = value; }
      }

      public string Description
      {
          get { return StrDesccription; }
          set { StrDesccription = value; }
      }
      public string Active
      {
          get { return StrActive; }
          set { StrActive = value; }
      }

      public string EnteredBy
      {
          get { return StrEnteredBy; }
          set { StrEnteredBy = value; }
      }
      public string EnteredOn
      {
          get { return StrEnteredOn; }
          set { StrEnteredOn = value; }
      }
      public string ClientID
      {
          get { return StrClientID; }
          set { StrClientID = value; }
      }
      public string Error
      {
          get { return StrError; }
      }
      #endregion

      #region "Method"

      public DataView GetAll(int flag)
      {
          switch (flag)
          {
              case 1: // gridview
                  objdbhims.Query = "select wardid,name,acronym,active,description from dc_tp_ward where 1=1";
                  if (!_BranchID.Equals(Default) && !_BranchID.Equals(""))
                  {
                      objdbhims.Query += @" and BranchID=" + _BranchID;
                  }
                  break;
              case 2: // valid ward name
                  objdbhims.Query = "select wardid from dc_tp_ward where name ='" + strName + "'";
                  break;
              case 3: // valid ward name
                  objdbhims.Query = "select wardid from dc_tp_ward where acronym ='" + StrAcronym + "'";
                  break;
          }
          return ObjTrans.DataTrigger_Get_All(objdbhims);
      }

      public bool Insert()
      {
          if (Validate_form())
          {
              QueryBuilder objQb = new QueryBuilder();

              ObjTrans.Start_Transaction();

              objdbhims.Query = objQb.QBInsert(MakeArray(), TableName);
              StrError = ObjTrans.DataTrigger_Insert(objdbhims);

              if (StrError.Equals("True"))
              {
                  ObjTrans.End_Transaction();
                  StrError = ObjTrans.OperationError;
                  return false;
              }
              else
              {
                  ObjTrans.End_Transaction();
                  return true;
              }
          }
          else
              return false;
      }

      public bool Update()
      {
          if (Validate_form())
          {
              QueryBuilder objQb = new QueryBuilder();

              ObjTrans.Start_Transaction();

              objdbhims.Query = objQb.QBUpdate(MakeArray(), TableName);
              StrError = ObjTrans.DataTrigger_Update(objdbhims);

              if (StrError.Equals("True"))
              {
                  ObjTrans.End_Transaction();
                  StrError = ObjTrans.OperationError;
                  return false;
              }
              else
              {
                  ObjTrans.End_Transaction();
                  return true;
              }
          }
          else
              return false;
      }


      private string[,] MakeArray()
      {
          string[,] wArr = new string[9, 3];

          if (!StrWardID.Equals(Default))
          {
              wArr[0, 0] = "wardid";
              wArr[0, 1] = this.StrWardID;
              wArr[0, 2] = "int";
          }
          if (!strName.Equals(Default))
          {
              wArr[1, 0] = "name";
              wArr[1, 1] = this.strName;
              wArr[1, 2] = "string";
          }
          if (!StrAcronym.Equals(Default))
          {
              wArr[2, 0] = "acronym";
              wArr[2, 1] = this.StrAcronym;
              wArr[2, 2] = "string";
          }
          if (!StrDesccription.Equals(Default))
          {
              wArr[3, 0] = "description";
              wArr[3, 1] = this.StrDesccription;
              wArr[3, 2] = "string";
          }

          if (!StrActive.Equals(Default))
          {
              wArr[4, 0] = "active";
              wArr[4, 1] = this.StrActive;
              wArr[4, 2] = "string";
          }
          if (!StrEnteredBy.Equals(Default))
          {
              wArr[5, 0] = "enteredby";
              wArr[5, 1] = this.StrEnteredBy;
              wArr[5, 2] = "int";
          }
          if (!StrEnteredOn.Equals(Default))
          {
              wArr[6, 0] = "enteredon";
              wArr[6, 1] = this.StrEnteredOn;
              wArr[6, 2] = "datetime";
          }
          if (!StrClientID.Equals(Default))
          {
              wArr[7, 0] = "clientid";
              wArr[7, 1] = this.StrClientID;
              wArr[7, 2] = "string";
          }
          if (!_BranchID.Equals(Default))
          {
              wArr[8, 0] = "BranchID";
              wArr[8, 1] = this._BranchID;
              wArr[8, 2] = "int";
          }
          return wArr;
      }

      private bool Validate_form()
      {
          if (!Vd_Name())
              return false;
          //if (!Vd_Acronym())
          //    return false;
          else
              return true;
      }
      private bool Vd_Name()
      {
          DataView dv = GetAll(2);

          if (dv.Count > 0)
          {
              if (!StrWardID.Equals(Default) && !StrWardID.Equals("") && StrWardID != null)
                  dv.RowFilter = " wardid<>" + StrWardID;
              if (dv.Count > 0)
              {
                  StrError = "Please enter other ward name. it is alreay exist";
                  return false;
              }
              else
                  return true;
          }
          else
              return true;
      }
      private bool Vd_Acronym()
      {
          DataView dv = GetAll(3);

          if (dv.Count > 0)
          {
              if (!StrWardID.Equals(Default) && !StrWardID.Equals("") && StrWardID != null)
                  dv.RowFilter = " wardid<>" + StrWardID;
              if (dv.Count > 0)
              {
                  StrError = "Please enter other acronym. it is alreay exist";
                  return false;
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
