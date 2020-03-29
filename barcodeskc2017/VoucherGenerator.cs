using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
//using iTextSharp.text.pdf;
//using Font = iTextSharp.text.Font;
//using Image = iTextSharp.text.Image;

namespace barcodeskc2017
{
    class VoucherGenerator
    {
        public String Directorio = Directory.GetCurrentDirectory();


        public Boolean GetVoucherFinal()
        {
            int SPACE = 145;
            String title = string.Format("{0}\\{1}\\{2}.{3}", Directorio, "logos", "skclogo105x125", BarCodeGeneration.Tipo.png); ////--->>>logo skc
            // String route = string.Format("{0}\\{1}.{2}", Directorio, token, BarCodeGeneration.Tipo.png);
            //string title = Application.StartupPath + "\\CBT_Title.png";
            //string barcode = Application.StartupPath + "\\code128bar.jpg";
            System.Drawing.Bitmap finalImage = null;

            String barcodeid = "123456";
            BarCodeGeneration bc = new BarCodeGeneration();
            String barcode = bc.Get128BarCode(barcodeid);
            String EmptyImage = CreateEmptyImage();
            int IntWidth = 377;
            int IntHeight = 560;

            String token = bc.CreateUniqueToken();
            String route = string.Format("{0}\\{1}.{2}", Directorio, token, BarCodeGeneration.Tipo.png);
            finalImage = new System.Drawing.Bitmap(IntWidth, IntHeight);
            using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(finalImage))
            {

                g.DrawRectangle(Pens.Black, 5, 5, 420, 450);

                string TType = "S";

                g.DrawImage(System.Drawing.Image.FromFile(title), 50, 7);
                Font fBody = new Font("Lucida Console", 15, FontStyle.Bold);
                Font fBody1 = new Font("Lucida Console", 15, FontStyle.Regular);
                Font rs = new Font("Stencil", 25, FontStyle.Bold);
                Font fTType = new Font("", 150, FontStyle.Bold);
                SolidBrush sb = new SolidBrush(Color.Black);


                g.DrawString("---------------", fBody1, sb, 10, 120);

                g.DrawString("Date :", fBody, sb, 10, SPACE);
                g.DrawString(DateTime.Now.ToShortDateString(), fBody1, sb, 90, SPACE);

                g.DrawString("Time :", fBody, sb, 10, SPACE + 30);
                g.DrawString(DateTime.Now.ToShortTimeString(), fBody1, sb, 90, SPACE + 30);

                g.DrawString("TicketNo.:", fBody, sb, 10, SPACE + 60);
                g.DrawString("", fBody1, sb, 120, SPACE + 60);

                //g.DrawString("BusNo.:", fBody, sb, 10, SPACE + 90);
                //g.DrawString(txtBusNo.Text, fBody1, sb, 100, SPACE + 90);

                //g.DrawString("DriverName:", fBody, sb, 10, SPACE+120);
                //g.DrawString(txtDriveName.Text, fBody1, sb, 153, SPACE + 120);

                //g.DrawString("Route:", fBody, sb, 10, SPACE + 120);
                //g.DrawString(cbRoute.SelectedItem.ToString(), fBody1, sb, 100, SPACE + 120);

                //g.DrawString("Full:", fBody, sb, 10, SPACE + 150);
                //g.DrawString("1 X 8.00 = 8.00", fBody1, sb, 80, SPACE + 150);

                //g.DrawString("Rs. 8.00", rs, sb, 10, SPACE + 180);

                g.DrawString(TType, fTType, sb, 230, 120);

                //g.DrawImage(Image.FromFile(barcode), 10, SPACE + 240);
                //g.DrawString("Helpline No.: +91 9999999999", fBody, sb, 10, 465);
                return true;
            }
        }

        public Boolean GetVoucherFinal333()
        {
            String barcodeid = "123456";
            BarCodeGeneration bc = new BarCodeGeneration();
            String barcode = bc.Get128BarCode(barcodeid);
            String EmptyImage = CreateEmptyImage();

            String token = bc.CreateUniqueToken();
            String route = string.Format("{0}\\{1}.{2}", Directorio, token, BarCodeGeneration.Tipo.png);

            System.Drawing.Image backImg = System.Drawing.Image.FromFile(EmptyImage);
            System.Drawing.Image mrkImg = System.Drawing.Image.FromFile(barcode);
            Graphics g = Graphics.FromImage(backImg);
            g.DrawImage(mrkImg, 317 / 2, 10);
            backImg.Save(route, System.Drawing.Imaging.ImageFormat.Jpeg);

            return true;
        }


        public bool GetVoucherFinal222(String RutaBarcode)
        {
            ///// String Ruta = System.Reflection.Assembly.GetExecutingAssembly().Location.Replace("CartaCortesiaPDF.exe", "");

            //Image ImagenJCOBRANZA = Image.GetInstance(RutaBarcode);

            //ImagenJCOBRANZA.ScaleToFit(200f, 200f);
            //ImagenJCOBRANZA.SpacingBefore = 10f;
            //ImagenJCOBRANZA.SpacingAfter = 1f;
            //ImagenJCOBRANZA.SetAbsolutePosition(70, 10);

            //StringBuilder sb = new StringBuilder();


            //string firstText = "Hello";
            //string secondText = "World";

            //PointF firstLocation = new PointF(10f, 10f);
            //PointF secondLocation = new PointF(10f, 50f);

            //string imageFilePath = @"path\picture.bmp";
            //Bitmap bitmap = (Bitmap)Image.FromFile(imageFilePath);//load the image file

            //using (Graphics graphics = Graphics.FromImage(bitmap))
            //{
            //    using (Font arialFont = new Font("Arial", 10))
            //    {
            //        graphics.DrawString(firstText, arialFont, Brushes.Blue, firstLocation);
            //        graphics.DrawString(secondText, arialFont, Brushes.Red, secondLocation);
            //    }
            //}

            // bitmap.Save(imageFilePath);//save the image file

            //Document pdfDoc = new Document(PageSize.LETTER, 10f, 10f, 10f, 0f);
            //if (VieneAutomatico == "S")
            //{
            //    RutaFINAL = RutaFINAL + RUT_CLIENTE.Replace("-", "_") + "_" + NUM_CESION + ".pdf";
            //}
            //else
            //{
            //    if (!NombreArchivoFinal.Contains(".pdf"))
            //    {
            //        NombreArchivoFinal = NombreArchivoFinal + ".pdf";
            //    }
            //    RutaFINAL = RutaFINAL + NombreArchivoFinal;
            //}
            //String NombreArchivoFinal = "carlos";
            //NombreArchivoFinal = NombreArchivoFinal + ".pdf";
            ////PdfWriter wri = PdfWriter.GetInstance(pdfDoc, new FileStream(RutaFINAL, FileMode.Create));//  = @"D:\\PDFCESION\\";  @"C:\ocx\archivo1.pdf", FileMode.Create));
            //PdfWriter wri = PdfWriter.GetInstance(pdfDoc, new FileStream(NombreArchivoFinal, FileMode.Create));//  = @"D:\\PDFCESION\\";  @"C:\ocx\archivo1.pdf", FileMode.Create));
            //pdfDoc.Open();

            //Font fntTableFont = FontFactory.GetFont("Times New Roman", 10, Font.NORMAL, BaseColor.BLACK);




            //pdfDoc.Add(ImagenJCOBRANZA);
            //StringReader str = new StringReader(sb.ToString());
            //HTMLWorker htmlworker = new HTMLWorker(pdfDoc);
            //htmlworker.Parse(str);

            //Phrase p2 = null; Phrase p3 = null; Phrase p4 = null;
            //int Parrafo = 0;
            //int recorre = 10;

            ////while (recorre < StrSegunParte.Length)
            ////{
            ////    if (!StrSegunParte.Contains("<br"))
            ////    {
            //        if (StrSegunParte.Length > 0)
            //        {
            //            StrSegunParte = StrSegunParte.Replace("</p>", "").Replace("</font>", "");
            //        }
            //        recorre = StrSegunParte.Length;
            //    }
            //    if (recorre < StrSegunParte.Length)
            //    {
            //        if (StrSegunParte.Substring(recorre, 5) == "<br/>")
            //        {
            //            if (Parrafo == 0)
            //            {
            //                p2 = new Phrase(StrSegunParte.Substring(0, recorre).Replace("<br/>", ""), fntTableFont);
            //                StrSegunParte = StrSegunParte.Replace(StrSegunParte.Substring(0, recorre + 5), "");
            //                // Parrafo += 1;
            //                recorre = 0;
            //            }
            //            if (Parrafo == 1)
            //            {
            //                p3 = new Phrase(StrSegunParte.Substring(0, recorre).Replace("<br/>", ""), fntTableFont);
            //                StrSegunParte = StrSegunParte.Replace(StrSegunParte.Substring(0, recorre + 5), "");
            //                // Parrafo += 1;
            //                recorre = 0;
            //            }
            //            if (Parrafo == 2)
            //            {
            //                p4 = new Phrase(StrSegunParte.Substring(0, recorre).Replace("<br/>", ""), fntTableFont);
            //                StrSegunParte = StrSegunParte.Replace(StrSegunParte.Substring(0, recorre + 5), "");
            //                // Parrafo += 1;
            //                recorre = 0;
            //            }
            //            Parrafo += 1;
            //        }
            //    }



            ////    recorre += 1;
            ////}
            //String StrSegunParte = "holaaaaaa";
            //p4 = new Phrase(StrSegunParte, fntTableFont);

            //// Parrafo += 1;
            //recorre = 0;
            ////if (GlobCantidadLineasDoc >= 12)
            ////{
            ////    pdfDoc.NewPage();
            ////    Paragraph par2 = new Paragraph();
            ////    Paragraph par3 = new Paragraph();
            //    Paragraph par4 = new Paragraph();
            //    //phrase.Add(new Chunk("REASON(S) FOR CANCELLATION:", boldFont));
            //    par2.Add(p2);
            //    par3.Add(p3);
            //    par4.Add(p4);


            //    pdfDoc.Add(ImagenJCOBRANZA);
            //    pdfDoc.Add(ImagenJNORMALIZACION);
            //    //Paragraph p = new Paragraph();
            //    //p.Add(p1);
            //    pdfDoc.Add(new Paragraph(" "));
            //    pdfDoc.Add(par2);
            //    pdfDoc.Add(new Paragraph(" "));
            //    pdfDoc.Add(par3);
            //    pdfDoc.Add(new Paragraph(" "));
            //    pdfDoc.Add(par4);
            //    //pdfDoc.Add(p);
            //}
            //else
            //{
            //    Paragraph par2 = new Paragraph();
            //    Paragraph par3 = new Paragraph();
            //    Paragraph par4 = new Paragraph();

            //    par2.Add(p2);
            //    par3.Add(p3);
            //    par4.Add(p4);
            //    pdfDoc.Add(new Paragraph(" "));
            //    pdfDoc.Add(par2);
            //    pdfDoc.Add(new Paragraph(" "));
            //    pdfDoc.Add(par3);
            //    pdfDoc.Add(new Paragraph(" "));
            //    pdfDoc.Add(par4);
            ////}


            //pdfDoc.Close();
            ////pdfDoc.NewPage(); 




            return true;

        }


        public String CreateEmptyImage()
        {
            BarCodeGeneration bc = new BarCodeGeneration();
            String token = bc.CreateUniqueToken();
            String route = string.Format("{0}\\{1}.{2}", Directorio, token, BarCodeGeneration.Tipo.jpg);

            System.Drawing.Image resultImage = new Bitmap(317, 577, PixelFormat.Format24bppRgb);

            using (Graphics grp = Graphics.FromImage(resultImage))
            {
                grp.FillRectangle(
                    Brushes.White, 0, 0, 317, 577);
                resultImage = new Bitmap(317, 577, grp);
                resultImage.Save(route, System.Drawing.Imaging.ImageFormat.Jpeg);
            }

            return route;

        }
    }
}
