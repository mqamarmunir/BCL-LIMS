using System;
using MySql.Data.MySqlClient;

namespace DataLayer
{	
	/// <summary>
	/// Summary description for IInterface.
	/// </summary>
	public interface Iinterface
	{
/*		 string PKeycode
		 {
			 get;
			 set;
		 }
*/
		#region "Methods"

		MySqlCommand Insert();
		 
		MySqlCommand Update();

        MySqlCommand Delete();

        MySqlCommand Get_All();

        MySqlCommand Get_Single();

        MySqlCommand Get_Max();

	
		#endregion

        MySqlCommand Get_Login(string clinetID, string loginID, string password, string branchID);
    }
}