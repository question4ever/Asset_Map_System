using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronPdf;

namespace Asset_Map_System
{
    class PDFtoSVG
    {
        public static void PDFRead()
        {
            PdfDocument pdf = PdfDocument.FromFile("../../Assets/047-3.pdf");
            //Get all Images
            System.Drawing.Bitmap bitmap = pdf.PageToBitmap(1);
        }
    }
}
