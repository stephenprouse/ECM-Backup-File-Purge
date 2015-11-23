using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ECM_Backup_File_Purge
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DateTime now = DateTime.Now;

                string[] AlphaBackupFolder = Directory.GetFiles(@"E:\ECMLIVE\ALPHACOLDFDLIVEBKUP");
                string[] WoundCareBackupFolder = Directory.GetFiles(@"E:\ECMLIVE\ECMWOUNDEXPERTBKUP");
                string[] ForerunBackupFolder = Directory.GetFiles(@"E:\ECMLIVE\FORERUNLIVEBKUP");

                int count1 = 0;
                int count2 = 0;
                int count3 = 0;

                string LogFilePath = @"E:\ECMLIVE\purgelog.txt";

                using (StreamWriter LogFile = File.AppendText(LogFilePath))
                {
                    LogFile.WriteLine("### Purge process started on " + now.ToString());
                }

                foreach (string file in AlphaBackupFolder)
                {
                    if (File.GetCreationTime(file) <= now.AddDays(-30))
                    {
                        Console.WriteLine(file.ToString() + " " + File.GetCreationTime(file) + " DELETED");
                        using (StreamWriter LogFile = File.AppendText(LogFilePath))
                        {
                            LogFile.WriteLine(file.ToString() + " " + File.GetCreationTime(file) + " DELETED on " + now.ToString());
                        }
                        File.Delete(file);
                        count1++;
                    }
                }

                foreach (string file in WoundCareBackupFolder)
                {
                    if (File.GetCreationTime(file) <= now.AddDays(-30))
                    {
                        Console.WriteLine(file.ToString() + " " + File.GetCreationTime(file) + " DELETED");
                        using (StreamWriter LogFile = File.AppendText(LogFilePath))
                        {
                            LogFile.WriteLine(file.ToString() + " " + File.GetCreationTime(file) + " DELETED on " + now.ToString());
                        }
                        File.Delete(file);
                        count2++;
                    }
                }

                foreach (string file in ForerunBackupFolder)
                {
                    if (File.GetCreationTime(file) <= now.AddDays(-30))
                    {
                        Console.WriteLine(file.ToString() + " " + File.GetCreationTime(file) + " DELETED");
                        using (StreamWriter LogFile = File.AppendText(LogFilePath))
                        {
                            LogFile.WriteLine(file.ToString() + " " + File.GetCreationTime(file) + " DELETED on" + now.ToString());
                        }
                        File.Delete(file);
                        count3++;
                    }
                }
                using (StreamWriter sw = File.AppendText(LogFilePath))
                {
                    sw.WriteLine("### Total files deleted from AlphaBackupFolder = " + count1);
                    sw.WriteLine("### Total files deleted from WoundCareBackupFolder = " + count2);
                    sw.WriteLine("### Total files deleted from ForerunBackupFolder = " + count3);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }
    }
}
