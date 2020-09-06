using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer;

namespace ConverterPhoto__dll
{
    public class ConverterPhotos
    {
        public void SetPath()
        {
            string fileName = Guid.NewGuid().ToString() + ".jpg";

            string fullPath = Server.MapPath("~/img/") + fileName;
        }
    }
}
