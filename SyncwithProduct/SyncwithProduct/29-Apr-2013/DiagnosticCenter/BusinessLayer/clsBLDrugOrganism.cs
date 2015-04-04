using System;
using System.Collections.Generic;
using System.Text;
using DataLayer;
using System.Data;

namespace BusinessLayer
{
  public class clsBLDrugOrganism
  {
    public clsBLDrugOrganism()
		{
			//
			// TODO: Add constructor logic here
			//
		}

    #region "Class Variables"

    private const string Default = "~!@";
    private const string TableName = "dc_tDrugOrganism";
    private string StrErrorMessage = "";

    private string StrOrganismID = Default;
    private string StrDrugID= Default;
    private string StrType= Default;
    private string StrEnteredBy = Default;
    private string StrEnteredOn = Default;
    private string StrClientID = Default;

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

    public string Type
    {
      get
      {
        return StrType;
      }
      set
      {
        StrType= value;
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

    #endregion

    clsoperation objTrans = new clsoperation();
    clsdbhims objdbhims = new clsdbhims();

    #region "Methods"

    public bool Insert()
    {
      if (Validate_Form())
      {
        QueryBuilder ObjQB = new QueryBuilder();
        //objTrans.Start_Transaction();

        objdbhims.Query = ObjQB.QBInsert(MakeArray(), TableName);
        StrErrorMessage = objTrans.DataTrigger_Insert(objdbhims);

        if (StrErrorMessage.Equals("True"))
        {
          StrErrorMessage = objTrans.OperationError;
          //objTrans.End_Transaction();
          return false;
        }
        else
        {
          //objTrans.End_Transaction();
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

    public bool DeleteWithOrganism()
    {
      QueryBuilder ObjQB = new QueryBuilder();
      objTrans.Start_Transaction();

      objdbhims.Query = "Delete From " + TableName + " where OrganismId=" + StrOrganismID + " and Type= '" + StrType + "' ";
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

    public bool DeleteWithDrug()
    {
      QueryBuilder ObjQB = new QueryBuilder();
      objTrans.Start_Transaction();

      objdbhims.Query = "Delete From " + TableName + " where DrugID=" + StrDrugID + " and Type= '" + StrType + "' ";
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
          objdbhims.Query = "SELECT max(organismId +1) as OrganismId FROM dc_tp_Organism";
          break;
        case 2:
          objdbhims.Query = "SELECT d.DrugId,d.Drug FROM " + TableName + " do,dc_tp_drug d where do.drugID=d.drugid  and Type = '" + StrType + "' and  do.OrganismId=" + StrOrganismID;
          break;
        case 3:
          objdbhims.Query = "SELECT max(DrugID +1) as DrugID FROM dc_tp_drug";
          break;
        case 4:
          objdbhims.Query = "SELECT o.OrganismID,o.Organism FROM " + TableName + " do,dc_tp_Organism o where do.OrganismID=o.OrganismID and  Type = '" + StrType + "' and  do.drugid=" + StrDrugID;
          break;
      }

      return objTrans.DataTrigger_Get_All(objdbhims);
    }

    private string[,] MakeArray()
    {
      string[,] aryDrugOrganism = new string[6, 3];

      if (!this.StrOrganismID.Equals(Default))
      {
        aryDrugOrganism[0, 0] = "OrganismID";
        aryDrugOrganism[0, 1] = this.StrOrganismID;
        aryDrugOrganism[0, 2] = "int";
      }

      if (!this.StrDrugID.Equals(Default))
      {
        aryDrugOrganism[1, 0] = "DrugID";
        aryDrugOrganism[1, 1] = this.StrDrugID;
        aryDrugOrganism[1, 2] = "int";
      }

      if (!this.StrType.Equals(Default))
      {
        aryDrugOrganism[2, 0] = "Type";
        aryDrugOrganism[2, 1] = this.StrType;
        aryDrugOrganism[2, 2] = "string";
      }

      if (!this.StrEnteredBy.Equals(Default))
      {
        aryDrugOrganism[3, 0] = "EnteredBY";
        aryDrugOrganism[3, 1] = this.StrEnteredBy;
        aryDrugOrganism[3, 2] = "int";
      }

      if (!this.StrEnteredOn.Equals(Default))
      {
        aryDrugOrganism[4, 0] = "EnteredON";
        aryDrugOrganism[4, 1] = this.StrEnteredOn;
        aryDrugOrganism[4, 2] = "datetime";
      }

      if (!this.StrClientID.Equals(Default))
      {
        aryDrugOrganism[5, 0] = "ClientID";
        aryDrugOrganism[5, 1] = this.StrClientID;
        aryDrugOrganism[5, 2] = "string";
      }

      return aryDrugOrganism;
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
