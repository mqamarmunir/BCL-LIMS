using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;

namespace Shared.WebControls
{
	public class ReportGridViewPageBreak : Control, INamingContainer
	{
		private int _currentPage;

		public int CurrentPage
		{
			get { return _currentPage; }
			set { _currentPage = value; }
		}

		public ReportGridViewPageBreak(int currentPage)
		{
			this._currentPage = currentPage;
		}
	}
}
