using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdelanteRedo
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public static ProcessingMode ProcessingMode { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Set the processing mode for the ReportViewer to Remote  
            WebForm1.ProcessingMode = ProcessingMode.Remote;
        }
    }
}