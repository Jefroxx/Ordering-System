using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Drawing.Printing;
using System.Drawing;
using System.Xml.Linq;
using FinalEDPOrderingSystem.Code.Product;

namespace FinalEDPOrderingSystem.Code.Repositories
{
    public static class ReceiptPDF
    {
        public static void Generate(string filePath, List<Products> products)
        {
            Document doc = new Document(PageSize.A4, 25, 25, 30, 30);

            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                PdfWriter.GetInstance(doc, stream);
                doc.Open();

                iTextSharp.text.Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
                iTextSharp.text.Font normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 11);

                // Title
                Paragraph title = new Paragraph("Receipt", headerFont);
                title.Alignment = Element.ALIGN_CENTER;
                doc.Add(title);

                doc.Add(new Paragraph("\n"));

                // Table
                PdfPTable table = new PdfPTable(4);
                table.WidthPercentage = 100;

                table.AddCell("Product");
                table.AddCell("Price");
                table.AddCell("Qty");
                table.AddCell("Subtotal");

                decimal grandTotal = 0;

                foreach (var p in products)
                {
                    decimal subtotal = p.Price * p.Quantity;
                    grandTotal += subtotal;

                    table.AddCell(p.Name);
                    table.AddCell("₱" + p.Price.ToString("N2"));
                    table.AddCell(p.Quantity.ToString());
                    table.AddCell("₱" + subtotal.ToString("N2"));
                }

                doc.Add(table);

                doc.Add(new Paragraph("\nTotal: ₱" + grandTotal.ToString("N2"), headerFont));

                doc.Close();
            }
        }
    }
}
