using FileManagement.Deutsch;
using FileManagement.Food;
using FileManagement.Performance;
using FileManagement.Stocks;
using System.Diagnostics;
using TextHelper;

namespace FileManagement
{
    class Program
    {
        //created 20180211
        static void Main(string[] args)
        {
            var process = Process.GetCurrentProcess();
            process.PriorityClass = ProcessPriorityClass.High;

            //AudioHelper.Start();

            //CreateLinkToRAMDisk.Start();

            //Statistic.Manager.Start();

            //Court.Start();

            //PdfToPngConverter.Start();
            //JunctionPointHelper.Start();

            //Clean.Start();
            CleanKingsoft.Start();

            //Deutsch
            Transkript.Start();
            DeutschToNotepad.Start();
            Subtitles.Start();

            //Trading
            GetTrades.Start();
            //PlaybookHelper.Start();

            //Utex
            UtexLog.Start();
            UtexLogAfter.Start();
            UtexLogToMt5Arrows.Start();

            //X5
            PerekrestokLog.Start();

            //BackupFiles.Start();

            //GenerateRussianHolidayCalendar.Start();
            //CreatePlaybookSuffixList.Start();
            //GetTrades.Start();
            //MergeExchangeData.Start();

            //CheckFileDateTime.Start();
            //Recovery2.Start();
            //HashRegister.Start();

            //FileUnification.Start();
            //GetTrades.Start();

            //SecureZip.StartZipFile();

            //ArgonPackTest.Start();

            //ConverterHelperTest.Start();

            //RsaEncryptionTest.Start();
            //Mix1.Start();

            //FileHelper.CopyFiles(".*rar", @"x:\Media\", @"r:\1\");

            /*ServiceBase[] servicesToRun = new ServiceBase[] { new CopyFileService() };
            ServiceBase.Run(servicesToRun);*/

            //Console.WriteLine("Press \'y\' to continue...");
            //while(Console.Read()!='y');

            //QToxExporterHelper.Start();
            TextHelperHelper.Start();
            //TamaraQToxHelper.Start();
        }
    }
}
