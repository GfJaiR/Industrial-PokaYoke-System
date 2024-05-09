using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comparacion2024
{
   public class EncodingDetector
    {
        public Encoding DetectEncoding(byte[] buffer)
        {
            Ude.CharsetDetector detector = new Ude.CharsetDetector();
            detector.Feed(buffer, 0, buffer.Length);
            detector.DataEnd();

            if (detector.Charset != null)
            {
                return Encoding.GetEncoding(detector.Charset);
            }

            return null;
        }
    }
}
