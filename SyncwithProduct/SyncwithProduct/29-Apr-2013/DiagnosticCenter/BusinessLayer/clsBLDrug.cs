using System;
using System.Data;
using System.Data.OleDb;
using DataLayer;

namespace BusinessLayer
{
	/// <summary>
	/// Summary description for clsBLTestProcess.
	/// </summary>
	public class clsBLDrug
	{
		public clsBLDrug()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region "Class Variables"
		
		private const string Default = "~!@";
		private const string TableName = "dc_tp_Drug";
    private const string TableName1 = "dc_tDrugOrganism";
		private string StrErrorMessage = "";

		private string StrDrugID = Default;
		private string StrOrganismID = Default;		
		private string StrDrug = Default;		
		private string StrAcronym = Default;		
		private string StrActive = Default;		
		private string StrDescription = Default;
    private string StrEnteredBy= Default;
    private string StrEnteredOn = Default;
    private string StrClientID = Default;

    private string StrType = "D";		

		#endregion

		#region "Properties"
		
		
		public string DrugID
		{
			get{	return StrDrugID;	}
			set{	StrDrugID = value;	}
		}

		public string OrganismID
		{
			get{	return StrOrganismID;	}
			set{	StrOrganismID = value;	}
		}
		
		public string Drug
		{
			get{	return StrDrug;	}
			set{	StrDrug = value;	}
		}
		
		public string Acronym
		{
			get{	return StrAcronym;	}
			set{	StrAcronym = value;	}
		}
		
		public string Active
		{
			get{	return StrActive;	}
			set{	StrActive = value;	}
		}
		
		public string Description
		{
			get{	return StrDescription;	}
			set{	StrDescription = value;	}
		}

    public string EnteredBy
    {
      get
      {
        return StrEnteredBy;
      }
      set
      {
        StrEnteredBy= value;
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
			get{	return StrErrorMessage;	}
		}

		#endregion
		
		clsoperation objTrans = new clsoperation();
		clsdbhims objdbhims = new clsdbhims();

		#region "Methods"

    public bool Insert(string OrganismList)
		{
      string[] OrgList = OrganismList.Split(',');
      clsBLDrugOrganism objDrugOrgan = new clsBLDrugOrganism();

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
          StrDrugID = objDrugOrgan.GetAll(3).Table.Rows[0][0].ToString();

          for (int i = 0; i <= OrgList.GetUpperBound(0); i++)
          {
            if (!OrgList[i].Trim().Equals(""))
            {
              StrOrganismID = OrgList[i];

              objdbhims.Query = ObjQB.QBInsert(MakeArrayDrugOrganism(), TableName1);
              StrErrorMessage = objTrans.DataTrigger_Insert(objdbhims);

              if (StrErrorMessage.Equals("True"))
              {
                StrErrorMessage = objTrans.OperationError;
                objTrans.End_Transaction();
                return false;
              }
            }
          }
          objTrans.End_Transaction();
          return true;
        }
      }
      else
      {
        return false;
      }
		}

    public bool Update(string OrganismList)
		{


      if (Validate_Form())
      {
        QueryBuilder ObjQB = new QueryBuilder();
        clsBLDrugOrganism objDrugOrgan = new clsBLDrugOrganism();
        string[] OrgList = OrganismList.Split(',');

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
          objDrugOrgan.DrugID= StrDrugID;
          objDrugOrgan.Type = "D";

          objDrugOrgan.DeleteWithDrug();

          for (int i = 0; i <= OrgList.GetUpperBound(0); i++)
          {
            if (!OrgList[i].Trim().Equals(""))
            {
              StrOrganismID = OrgList[i];

              objdbhims.Query = ObjQB.QBInsert(MakeArrayDrugOrganism(), TableName1);
              
              StrErrorMessage = objTrans.DataTrigger_Insert(objdbhims);

              if (StrErrorMessage.Equals("True"))
              {
                StrErrorMessage = objTrans.OperationError;
                objTrans.End_Transaction();
                return false;
              }
            }
          }

          objTrans.End_Transaction();
          return true;
        }
      }
      else
      {
        return false;
      }
		}

		public DataView GetAll(int flag)
		{
			switch(flag)
			{
				case 1:
          objdbhims.Query = "SELECT d.DrugId,d.Drug,d.acronym,d.Active,d.Description FROM dc_tp_drug d order by Drug;";
					break;

				case 2:
					objdbhims.Query = "SELECT drugid FROM dc_tp_drug d where drug='" + StrDrug + "';";
					break;

				case 3:
          objdbhims.Query = "SELECT drugid FROM dc_tp_drug d where Acronym='" + StrAcronym + "';";
					break;

				case 4:
          objdbhims.Query = "SELECT d.DrugId,d.Drug FROM dc_tp_drug d where d.Active='Y' order by Drug;";
          break;
			}

			return objTrans.DataTrigger_Get_All(objdbhims);
		}	

		private string[,] MakeArray()
		{
			string[,] aryDrug= new string[8,3];

			if(!this.StrDrugID.Equals(Default))
			{
				aryDrug[0,0] = "DrugID";
				aryDrug[0,1] = this.StrDrugID;
				aryDrug[0,2] = "int";
			}

			if(!this.StrDrug.Equals(Default))
			{
				aryDrug[1,0] = "Drug";
				aryDrug[1,1] = this.StrDrug;
				aryDrug[1,2] = "string";
			}

			if(!this.StrActive.Equals(Default))
			{
				aryDrug[2,0] = "Active";
				aryDrug[2,1] = this.StrActive;
				aryDrug[2,2] = "string";
			}

			if(!this.StrAcronym.Equals(Default))
			{
				aryDrug[3,0] = "Acronym";
				aryDrug[3,1] = this.StrAcronym;
				aryDrug[3,2] = "string";
			}

			if(!this.StrDescription.Equals(Default))
			{
				aryDrug[4,0] = "Description";
				aryDrug[4,1] = this.StrDescription;
				aryDrug[4,2] = "string";
			}

			if (!this.StrEnteredBy.Equals(Default))
      {
        aryDrug[5, 0] = "EnteredBy";
        aryDrug[5, 1] = this.StrEnteredBy;
        aryDrug[5, 2] = "int";
      }

      if (!this.StrEnteredOn.Equals(Default))
      {
        aryDrug[6, 0] = "EnteredON";
        aryDrug[6, 1] = this.StrEnteredOn;
        aryDrug[6, 2] = "datetime";
      }

      if (!this.StrClientID.Equals(Default))
      {
        aryDrug[7, 0] = "ClientID";
        aryDrug[7, 1] = this.StrClientID;
        aryDrug[7, 2] = "string";
      }


			return aryDrug;
		}

    private string[,] MakeArrayDrugOrganism()
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
      if (!VD_Name())
      {
        return false;
      }
      if (!VD_Acronym())
      {
        return false;
      }
      else
      {
        return true;
      }
    }
    
    private bool VD_Name()
    {
      if (StrDrug.Equals(""))
      {
        StrErrorMessage = "please enter Drug name.";
        return false;
      }

      DataView dv = GetAll(2);
      if (dv.Count > 0)
      {
        if (!StrDrugID.Equals(Default) && !StrDrugID.Equals("") )
          dv.RowFilter = "DrugID<>" + StrDrugID;

        if (dv.Count > 0)
        {
          StrErrorMessage = "please enter other Drug name.It is already exist";
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
    
    private bool VD_Acronym()
    {
      if (StrAcronym.Trim().Equals(""))
      {
        return true;
      }

      DataView dv = GetAll(3);
      if (dv.Count > 0)
      {
        if (!StrDrugID.Equals(Default) && !StrDrugID.Equals("") )
          dv.RowFilter = "DrugID <>" + StrDrugID ;
        if (dv.Count > 0)
        {
          StrErrorMessage = "please enter other acronym.It is already exist";
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
