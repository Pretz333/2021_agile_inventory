using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;


namespace Inventory
{
    public partial class Locations : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        [Obsolete]
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=LocationDetails.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            System.IO.StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            gvLocations.AllowPaging = false;
            gvLocations.DataBind();
            gvLocations.RenderControl(hw);
            gvLocations.HeaderRow.Style.Add("width", "15%");
            gvLocations.HeaderRow.Style.Add("font-size", "10px");
            gvLocations.Style.Add("text-decoration", "none");
            gvLocations.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
            gvLocations.Style.Add("font-size", "8px");
            StringReader sr = new StringReader(sw.ToString());
            iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(PageSize.A2, 7f, 7f, 7f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            Font titleFont = FontFactory.GetFont("Arial", 32);
            Paragraph title;
            title = new Paragraph("Location", titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            pdfDoc.Add(title);
            pdfDoc.Add(new Chunk("\n"));
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
        }
    }
}