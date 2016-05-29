using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace MP3_Converter
{
    class Converter
    {
        public static void WaveToMP3(string inputFile)
        {
            string outputFile = (string)inputFile.Clone();

            int count = 0;
            for (int i = outputFile.Length; i > 0; i--)
            {
                if (outputFile[i-1] == '.')
                    break;

                count++;
            }
            outputFile = outputFile.Remove(outputFile.Length - count, count);
            outputFile += "mp3";
            File.Create(outputFile).Dispose();
            ProcessStartInfo lame = new ProcessStartInfo();
            lame.FileName = "lame\\lamess.exe";
            lame.Arguments = "-V2 " + inputFile + " " + outputFile;
            lame.WindowStyle = ProcessWindowStyle.Hidden;
            Process p;
            try
            {
                p = Process.Start(lame);
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                throw ex;
            }
            p.WaitForExit();
        } 
    }

    class Arguments
    {

    }
}
