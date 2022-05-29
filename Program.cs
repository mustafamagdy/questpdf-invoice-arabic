using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using QuestPDF.Fluent;

namespace QuestPDF.ExampleInvoice
{
  class Program
  {
    /// <summary>
    /// For documentation and implementation details, please visit:
    /// https://www.questpdf.com/documentation/getting-started.html
    /// </summary>
    static void Main(string[] args)
    {
      var r = new Random();

      var filePath = $"invoice{r.Next(0, 1000)}.pdf";

      var model = InvoiceDocumentDataSource.GetInvoiceDetails();
      var document = new InvoiceDocument(model);
      document.GeneratePdf(filePath);

      if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
      {
        Process.Start("explorer.exe", filePath);
      }
      else
      {
        var fullPath = Path.Combine(Directory.GetCurrentDirectory(), filePath);
        Process.Start("open", fullPath);
        Console.WriteLine($"Output PDF file is available here: {fullPath}");
      }
    }
  }
}