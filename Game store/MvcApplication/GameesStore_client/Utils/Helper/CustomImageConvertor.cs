using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace GameesStore_client.Utils.Helper
{
    public static class CustomImageConvertor
    {
        public static Bitmap ConverrtBitmap(Bitmap bitmap, int width, int height)
        {
            Bitmap picture = new Bitmap(width, height);
            using (Graphics graphics = Graphics.FromImage(picture))
            {
                graphics.DrawImage(bitmap, 0, 0, width, height);
            }

            return new Bitmap(picture);
        }
    }
}