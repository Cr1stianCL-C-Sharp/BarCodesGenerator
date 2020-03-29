


using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;

namespace barcodeskc2017
{
    class Program
    {
        private static StreamReader streamToPrint;
        public static String Directorio = Directory.GetCurrentDirectory();

        static void Main(string[] args)
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);
            printDoc.Print();

        }

        static void printDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {

                int SpaceFecha = 95;
                DateTime time = DateTime.Now;
                string format = "d-MM-yyyy";
                String Fecha = time.ToString(format);
                Font fBody = new Font("Lucida Console", 8, FontStyle.Bold);
                Font fBody1 = new Font("Lucida Console", 8, FontStyle.Regular);
                SolidBrush sb = new SolidBrush(Color.Black);

                BarCodeGeneration bcg = new BarCodeGeneration();
                string nro = "12345678";
                String imgRoute =
                    string.Format("{0}\\{1}\\{2}.{3}", Directorio, "logos", "logoskc2", "png"); ////--->>>logo skc
                //////String imgRoute =$"{Directorio}\\logos\\logoskc.jpg"; ////--->>>logo skc
                Image logo = Image.FromFile(imgRoute);
                Image barcode = Image.FromFile(bcg.Get128BarCode(nro));

                Console.WriteLine("Printing...");
                Graphics g = e.Graphics;
                g.DrawImage(logo, 5, 0);
                g.DrawString("Fecha:", fBody, sb, 10, SpaceFecha);
                g.DrawString(Fecha, fBody, sb, 10, SpaceFecha + 15);
                g.DrawImage(barcode, 8, 140);
                g.DrawString(nro, fBody1, sb, 10, 185);

            }
            catch (Exception ex)
            {
                Console.WriteLine("error en la impression...");
            }


        }


        //////    ////////////BarCodeGeneration bc = new BarCodeGeneration();
        //////    ////////////String barcode = bc.Get128BarCode("123456");
        //////    //////////VoucherGenerator vg = new VoucherGenerator();
        //////    //////////bool ok;
        //////    //////////ok = vg.GetVoucherFinal();
        //////    ////////////String backImage =  vg.CreateEmptyImage();
        //////}
        //static void Main(string[] args)
        //{
        ////////string printFormat;
        ////////printFormat = BarCodeGeneration.Tipo.png.ToString();

        ////////try
        ////////{
        ////////    String title = string.Format("{0}\\{1}\\{2}.{3}", Directorio, "logos", "skclogo105x125", BarCodeGeneration.Tipo.png);

        ////////    //streamToPrint = new StreamReader(title);
        ////////    PrintDocument printDoc = new PrintDocument
        ////////    {
        ////////        PrinterSettings = new PrinterSettings
        ////////        {
        ////////            PrinterName = "Microsoft Print to PDF",
        ////////            PrintToFile = true,
        ////////            PrintFileName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/" + title
        ////////        }
        ////////    };

        ////////    printDoc.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("A4", 210, 290);
        ////////    printDoc.PrinterSettings.DefaultPageSettings.Landscape = false;
        ////////    printDoc.PrinterSettings.DefaultPageSettings.Margins.Top = 0;
        ////////    printDoc.PrinterSettings.DefaultPageSettings.Margins.Left = 0;

        ////////    switch (printFormat)
        ////////    {
        ////////        case "jpg":
        ////////            printDoc.PrintPage += printDoc_PrintImage;
        ////////            break;
        ////////        case "png":
        ////////            printDoc.PrintPage += printDoc_PrintImage;
        ////////            break;
        ////////        //case "txt":
        ////////        //    printDoc.PrintPage += printDoc_PrintText;
        ////////        //    break;
        ////////        default:
        ////////            break;
        ////////    }
        ////////    printDoc.Print();


        ////////}
        ////////finally
        ////////{
        ////////    streamToPrint.Close();
        ////////}
        ////////Console.ReadKey(true);

        ////static void printDoc_PrintPage(object sender, PrintPageEventArgs e)
        ////{
        ////    String logo = string.Format("{0}\\{1}\\{2}.{3}", Directorio, "logos", "skclogo105x125", BarCodeGeneration.Tipo.png);

        ////    Image photo = Image.FromFile(logo);
        ////    Point pPoint = new Point(0, 0);
        ////    e.Graphics.DrawImage(photo, pPoint);
        ////}


        //private void PrintPage(object o, PrintPageEventArgs e)
        //{
        //    System.Drawing.Image img = System.Drawing.Image.FromFile("D:\\Foto.jpg");
        //    Point loc = new Point(100, 100);
        //    e.Graphics.DrawImage(img, loc);
        //}

        //static void printDoc_PrintText(object sender, PrintPageEventArgs e)
        //{

        //    Font printFont;
        //    printFont = new Font("Arial", 10);

        //    float linesPerPage = 0;
        //    // Calculate the number of lines per page.
        //    linesPerPage = e.MarginBounds.Height / printFont.GetHeight(e.Graphics);

        //    float yPos = 0;
        //    int count = 0;
        //    float leftMargin = e.MarginBounds.Left;
        //    float topMargin = e.MarginBounds.Top;

        //    string line = null;

        //    while (count < linesPerPage &&
        //           ((line = streamToPrint.ReadLine()) != null))
        //    {
        //        yPos = topMargin + (count *
        //                            printFont.GetHeight(e.Graphics));
        //        e.Graphics.DrawString(line, printFont, Brushes.Black,
        //            leftMargin, yPos, new StringFormat());
        //        count++;
        //    }

        //    // If more lines exist, print another page.
        //    if (line != null)
        //        e.HasMorePages = true;
        //    else
        //        e.HasMorePages = false;
        //}




    }
}
