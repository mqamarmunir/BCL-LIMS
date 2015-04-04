<%@ Application Language="C#" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.IO.Compression" %>
<%@ Import Namespace="BusinessLayer" %>


<script runat="server">

    void Application_PreRequestHandlerExecute(object sender, EventArgs e)
    {
        HttpApplication app = sender as HttpApplication;
        string acceptEncoding = app.Request.Headers["Accept-Encoding"];
        Stream prevUncompressedStream = app.Response.Filter;

        if (!(app.Context.CurrentHandler is Page ||
            app.Context.CurrentHandler.GetType().Name == "SyncSessionlessHandler") ||
            app.Request["HTTP_X_MICROSOFTAJAX"] != null)
            return;

        if (acceptEncoding == null || acceptEncoding.Length == 0)
            return;

        acceptEncoding = acceptEncoding.ToLower();

        if (acceptEncoding.Contains("deflate") || acceptEncoding == "*")
        {
            // defalte
            app.Response.Filter = new DeflateStream(prevUncompressedStream,
                CompressionMode.Compress);
            app.Response.AppendHeader("Content-Encoding", "deflate");
        }
        else if (acceptEncoding.Contains("gzip"))
        {
            // gzip
            app.Response.Filter = new GZipStream(prevUncompressedStream,
                CompressionMode.Compress);
            app.Response.AppendHeader("Content-Encoding", "gzip");
        }
    }
    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup        
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        //Code that runs when a new session is started
        Session["PersonId"] = "";
        Session["PersonName"] = "";
        Session["OrgId"] = "";
        Session["OrgId2"] = "";
        
        Session["DepartmentId"] = "";
        Session["SpecimenId"] = "";
        Session["GroupId"] = "";
        Session["TestId"] = "";
        
        Session["SubDepartmentId"] = "";
        Session["GroupDetailId"] = "";
        
        Session["AttributeId"] = "";
        Session["RangeId"] = "";
        
        Session["StudyId"] = "";
        Session["branchid"] = "";
        Session["dt"] = "";
        Session["f11"] = "";
        Session["dtsearch"] = "";

        Session["u_deptID"] = "";
        Session["u_subdeptID"] = "";
        Session["menu_xml"] = "";
        Session["spec_nature"] = "";

        Session["spec_grid"] = "";
        Session["spec_no"] = "";

        Session["selectionformula"] = "";
        Session["reportname"] = "";
        Session["reportdoc"] = "";
        Session["indoor_services"] = "";
        Session["org_timing"] = "";
        Session["consultfill"] = "";
        Session["default_route"] = "";
    }

    void Session_End(object sender, EventArgs e) 
    {

        //clsLogin objlogin = new clsLogin();
        //objlogin.PersonId = Session["personid"].ToString().Trim();
        //objlogin.hostname = Session["hostname"].ToString().Trim();
        //if (objlogin.Delete())
        //{ }
       
        Session.Abandon();
        
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.
        //Session["PersonId"] = "";
        //Session["PersonName"] = "";
        //Session["OrgId"] = "";
        //Session["OrgId2"] = "";

        //Session["DepartmentId"] = "";
        //Session["SpecimenId"] = "";
        //Session["GroupId"] = "";
        //Session["TestId"] = "";

        //Session["SubDepartmentId"] = "";
        //Session["GroupDetailId"] = "";

        //Session["AttributeId"] = "";
        //Session["RangeId"] = "";
       
        //Session["StudyId"] = "";
        //Session["branchid"] = "";
        //Session["dt"] = "";
        //Session["f11"] = "";
        //Session["dtsearch"] = "";


        //Session["u_deptID"] = "";
        //Session["u_subdeptID"] = "";
        //Session["menu_xml"] = "";
        //Session["spec_nature"] = "";

        //Session["spec_grid"] = "";
        //Session["spec_no"] = "";

        //Session["selectionformula"] = "";
        //Session["reportname"] = "";
        //Session["indoor_services"] = "";
        //Session["org_timing"] = "";
        //Session["consultfill"] = "";
        //Session["default_route"] = "";

        //if (Session["reportname"] != null && Session["reportname"]!="")
        //{
        //    ReportDocument rptDoc = (ReportDocument)Session["reportname"];
        //    rptDoc.Close();
        //    rptDoc.Dispose();
            GC.Collect();
        //}
        
    }
       
</script>
