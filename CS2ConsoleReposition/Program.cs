using System.Reflection;

namespace CS2ConsoleReposition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string cfgPath = "";
            string pathToCfgTextFile = "";
            string programDir = AppContext.BaseDirectory.ToString();


            try
            {
                if (!DoesFileExist(programDir))
                {
                    Console.Write("Paste the path of your cs2_machine_convars.vcfg: ");
                    cfgPath = Console.ReadLine();
                    cfgPath = cfgPath + @"\cs2_machine_convars.vcfg";
                    CreateFilePath(cfgPath);
                    pathToCfgTextFile = GetFilePath(programDir);
                    File.WriteAllText(pathToCfgTextFile, cfgPath);
                }
                
                    pathToCfgTextFile = GetFilePath(programDir);

                    string filePath = File.ReadAllLines(pathToCfgTextFile).FirstOrDefault();
                    string[] lines = File.ReadAllLines(filePath);
                    Console.WriteLine(programDir);

                    for (int i = 0; i < lines.Length; i++)
                    {
                        if (IsLinePanoramaConsole(lines[i]))
                        {
                            lines[i] = "        \"panorama_console_position_and_size\"        \"20.00|20.00|200.00|200.00\"";

                            break;
                        }

                    }

                    File.WriteAllLines(filePath, lines);

                    Console.WriteLine("Position of the console corrected you can close the console");
                    Console.ReadLine();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            Console.ReadLine();
        }

        static bool IsLinePanoramaConsole(string line)
        {
            return line.Contains("panorama_console_position_and_size");
        }


        static string GetFilePath(string programDir)
        {
            string filePath = $"{programDir}panoramaPath.txt";

            return filePath;

        }

        public static void CreateFilePath(string programDir)
        {
            string filePath = $"{programDir}panoramaPath.txt";
            File.Create(filePath);
        }

        

        static bool DoesFileExist(string programDir)
        {
            string filePath = $"{programDir}panoramaPath.txt";

            return File.Exists(filePath);
        }
    }
}