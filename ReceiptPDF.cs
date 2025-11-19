using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing.Printing;
using System.Drawing;
using System.Xml.Linq;
using FinalEDPOrderingSystem.Code.Product;


namespace FinalEDPOrderingSystem
{
    public static class ReceiptPDF
    {
        public static void Generate(string filePath, List<Product> products)
        {
            if (products == null || products.Count == 0)
                throw new Exception("No products available for receipt.");
            Document doc = new Document(PageSize.A4, 40, 40, 40, 40);

            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                PdfWriter.GetInstance(doc, fs);
                doc.Open();

                // Title
                iTextSharp.text.Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20);
                Paragraph title = new Paragraph("RECEIPT\n\n", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                doc.Add(title);

                // Date
                iTextSharp.text.Font smallFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);
                doc.Add(new Paragraph($"Date: {DateTime.Now}\n\n", smallFont));

                // Table
                PdfPTable table = new PdfPTable(4);
                table.WidthPercentage = 100;
                table.SetWidths(new float[] { 40, 20, 20, 20 });

                AddTableHeader(table, "Product");
                AddTableHeader(table, "Price");
                AddTableHeader(table, "Qty");
                AddTableHeader(table, "Total");

                decimal grandTotal = 0m;

                foreach (var p in products)
                {
                    decimal lineTotal = p.Price * p.Quantity;
                    grandTotal += lineTotal;

                    table.AddCell(p.Name);
                    table.AddCell($"₱{p.Price:N2}");
                    table.AddCell(p.Quantity.ToString());
                    table.AddCell($"₱{lineTotal:N2}");
                }

                doc.Add(table);

                // Total
                Paragraph totalText = new Paragraph($"\nGRAND TOTAL: ₱{grandTotal:N2}",
                    FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14));
                totalText.Alignment = Element.ALIGN_RIGHT;
                doc.Add(totalText);

                doc.Close();
            }
        }

        private static void AddTableHeader(PdfPTable table, string text)
        {
            PdfPCell cell = new PdfPCell(new Phrase(text, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.BackgroundColor = BaseColor.LIGHT_GRAY;
            table.AddCell(cell);
        }
    }
}
