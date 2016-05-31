using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace MP3_Converter
{
    class Argument
    {
        private string name_;
        private string value_;

        public Argument(string name, string value)
        {
            name_ = name;
            value_ = value;
        }

        public override string ToString()
        {
            return name_;
        }

        public string getValue() { return value_; }


    }
    class Converter
    {
        public static void WaveToMP3(string inputFile, Argument arg)
        {
            inputFile = "testtt.wav";
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
            lame.FileName = "lame\\lame.exe";
            lame.Arguments = arg.getValue() + inputFile + " " + outputFile;
            lame.WindowStyle = ProcessWindowStyle.Hidden;
            Process p;
            p = Process.Start(lame);
            p.WaitForExit();
        } 
    }

    
}
