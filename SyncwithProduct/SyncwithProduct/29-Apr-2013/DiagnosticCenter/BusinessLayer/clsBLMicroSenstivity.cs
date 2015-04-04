using System;
using System.Collections.Generic;
using System.Text;
using DataLayer;
using System.Data;

namespace BusinessLayer
{
  public class clsBLMicroSenstivity
  {
    public clsBLMicroSenstivity()
		{
			//
			// TODO: Add constructor logic here
			//
		}

    #region "Class Variables"

    private const string Default = "~!@";
    private const string TableName = "dc_tMicro_Senstivity";
    private string StrErrorMessage = "";

    private string StrLabID = Default;
    private string StrTestID = Default;
    private string StrOrganismID = Default;
    private string StrDrugID= Default;
    private string StrSenstivity = Default;
    private string StrEnteredBy = Default;
    private string StrEnteredOn = Default;
    private string StrClientID = Default;
      private string StrBookingDID = Default;

    #endregion

    #region "Properties"

    public string OrganismID
    {
      get
      {
        return StrOrganismID;
      }
      set
      {
        StrOrganismID = value;
      }
    }

    public string LabID
    {
      get
      {
        return StrLabID;
      }
      set
      {
        StrLabID = value;
      }
    }

    public string TestID
    {
      get
      {
        return StrTestID;
      }
      set
      {
        StrTestID= value;
      }
    }

    public string Senstivity
    {
      get
      {
        return StrSenstivity;
      }
      set
      {
        StrSenstivity= value;
      }
    }

    public string DrugID
    {
      get
      {
        return StrDrugID;
      }
      set
      {
        StrDrugID= value;
      }
    }

    public string EnteredBy
    {
      get
      {
        return StrEnteredBy;
      }
      set
      {
        StrEnteredBy = value;
      }
    }

    public string EnteredOn
    {
      get
      {
        return StrEnteredOn;
      }
      set
      {
        StrEnteredOn = value;
      }
    }

    public string ClientID
    {
      get
      {
        return StrClientID;
      }
      set
      {
        StrClientID = value;
      }
    }

    public string ErrorMessage
    {
      get
      {
        return StrErrorMessage;
      }
    }
      public string BookingDID
      {
          get { return StrBookingDID; }
          set { StrBookingDID = value; }
      }
    #endregion

    clsoperation objTrans = new clsoperation();
    clsdbhims objdbhims = new clsdbhims();

    #region "Methods"

    public bool Insert()
    {
      if (Validate_Form())
      {
        QueryBuilder ObjQB = new QueryBuilder();
        objTrans.Start_Transaction();

        objdbhims.Query = ObjQB.QBInsert(MakeArray(), TableName);
        StrErrorMessage = objTrans.DataTrigger_Insert(objdbhims);

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
      else
      {
        return false;
      }
    }

    public bool Update()
    {
      if (Validate_Form())
      {
        QueryBuilder ObjQB = new QueryBuilder();
        objTrans.Start_Transaction();

        objdbhims.Query = ObjQB.QBUpdate(MakeArray(), TableName);
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
      else
      {
        return false;
      }
    }

    public bool Delete()
    {
      QueryBuilder ObjQB = new QueryBuilder();
      objTrans.Start_Transaction();

      objdbhims.Query = "Delete From " + TableName + " where Labid=" + StrLabID+ " and TestID= '" + StrTestID+ "' ";
      StrErrorMessage = objTrans.DataTrigger_Delete(objdbhims);

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

    public DataView GetAll(int flag)
    {
      switch (flag)
      {
        case 1:
            objdbhims.Query = "SELECT 0 as SNo ,o.organismID,o.organism,d.drugid,d.drug,ms.senstivity FROM dc_tmicro_senstivity ms, dc_tp_Drug d, dc_tp_Organism o where o.organismId=ms.organismId and d.drugid=ms.drugid and ms.labid='" + StrLabID + "' and ms.testId = " + StrTestID + " and ms.bookingdid=" + StrBookingDID;
          break;
      }

      return objTrans.DataTrigger_Get_All(objdbhims);
    }

    private string[,] MakeArray()
    {
      string[,] aryOrganism = new string[8, 3];

      if (!this.StrLabID.Equals(Default))
      {
        aryOrganism[0, 0] = "LabID";
        aryOrganism[0, 1] = this.StrLabID;
        aryOrganism[0, 2] = "string";
      }

      if (!this.StrTestID.Equals(Default))
      {
        aryOrganism[1, 0] = "TestID";
        aryOrganism[1, 1] = this.StrTestID;
        aryOrganism[1, 2] = "int";
      }

      if (!this.StrOrganismID.Equals(Default))
      {
        aryOrganism[2, 0] = "OrganismID";
        aryOrganism[2, 1] = this.StrOrganismID;
        aryOrganism[2, 2] = "int";
      }

      if (!this.StrDrugID.Equals(Default))
      {
        aryOrganism[3, 0] = "DrugID";
        aryOrganism[3, 1] = this.StrDrugID;
        aryOrganism[3, 2] = "int";
      }

      if (!this.StrSenstivity.Equals(Default))
      {
        aryOrganism[4, 0] = "Senstivity";
        aryOrganism[4, 1] = this.StrSenstivity;
        aryOrganism[4, 2] = "string";
      }

      if (!this.StrEnteredBy.Equals(Default))
      {
        aryOrganism[5, 0] = "EnteredBY";
        aryOrganism[5, 1] = this.StrEnteredBy;
        aryOrganism[5, 2] = "int";
      }

      if (!this.StrEnteredOn.Equals(Default))
      {
        aryOrganism[6, 0] = "EnteredON";
        aryOrganism[6, 1] = this.StrEnteredOn;
        aryOrganism[6, 2] = "datetime";
      }

      if (!this.StrClientID.Equals(Default))
      {
        aryOrganism[7, 0] = "ClientID";
        aryOrganism[7, 1] = this.StrClientID;
        aryOrganism[7, 2] = "string";
      }

      return aryOrganism;
    }

    #endregion

    #region Validate

    private bool Validate_Form()
    {
        return true;
    }

    #endregion
  }
}
