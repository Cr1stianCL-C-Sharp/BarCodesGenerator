using System;
using System.Drawing;
using System.IO;
using Zen.Barcode;

namespace barcodeskc2017
{
    public class BarCodeGeneration
    {
        public String Directorio = Directory.GetCurrentDirectory();

        public String Get128BarCode(String barcode)
        {
            String token = CreateUniqueToken();
            String Route = string.Format("{0}\\{1}.{2}", Directorio, token, Tipo.jpg);

            int maxheight = 40;
            Code128BarcodeDraw barcode128 = BarcodeDrawFactory.Code128WithChecksum;
            Image img = barcode128.Draw(barcode, maxheight);

            img.Save(Route, System.Drawing.Imaging.ImageFormat.Jpeg);
            return Route;

        }

        public String Get39BarCode(String barcode)
        {
            String token = CreateUniqueToken();
            String Route = string.Format("{0}\\{1}.{2}", Directorio, token, Tipo.jpg);
            int maxheight = 40;
            Code39BarcodeDraw barcode39 = BarcodeDrawFactory.Code39WithoutChecksum;
            Image img = barcode39.Draw(barcode, maxheight);

            img.Save(Route, System.Drawing.Imaging.ImageFormat.Jpeg);
            return Route;
        }

        public String CreateUniqueToken()
        {
            string token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            return token;
        }

        public enum Tipo
        {
            jpg = 1,
            gif = 2,
            png = 3
        }

    }
}
