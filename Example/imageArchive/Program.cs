using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using XArchiveDragon;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace imageArchive
{
    class Program
    {
        static void Main(string[] args)
        {
            IMG archive = new IMG();
            archive.Open(@"S:\games\Grand Theft Auto\models\gta3.img"); //путь к архиву

            string[] pathToTimedFiles = { // путь к файлам, которые будут временно установлены
                                            @"S:\gta-o\infernus.txd",
                                            @"S:\gta-o\infernus.dff"
                                        };

            string[] fileNamesInArchive = { // названия данных файлов в архиве в той же последовательности
                                              "infernus.txd",
                                              "infernus.dff"
                                          };

            string tempDirectory = @"S:\games\Grand Theft Auto\models\tempArchive\"; // директория для хранения оригиналов

            for (int j = 0; j != pathToTimedFiles.Length; j++) // цикл по массиву с путями к файлам
            {
                if (archive.AddTempFile(pathToTimedFiles[j], fileNamesInArchive[j], tempDirectory)) 
                { //  попытка установки файла в архив и сохранения оригинала в папку
                    Console.WriteLine("File {0} was added in archive. Dump saved.", fileNamesInArchive[j]);
                }
                else
                { // если произошла ошибка =)
                    Console.WriteLine("Error");
                }
            }

            Process game; // в дальнейшем пригодится
            while (true)
            { // вечный цикл 
                Process[] procs = Process.GetProcessesByName("gta_sa"); // выдираем из списка процессов gta_sa
                if (procs.Length == 0)
                { // дабы сильно не грузило процессор - нажмем на паузу
                    Thread.Sleep(3000); 
                }
                else
                { // если найден процесс с игрок, то запишем его в пригодившуюся переменную
                    game = procs[0];
                    break; // прервем цикл
                }
            }

            game.WaitForExit(); // подождем, пока игрок наиграется в игрушку
            if (game.HasExited) // пользователь наигрался
            {
                for (int j = 0; j != pathToTimedFiles.Length; j++)
                { // начинаем возвращать файлы на место
                    if (archive.RemoveTempFile(fileNamesInArchive[j], tempDirectory + fileNamesInArchive[j]))
                    { // при удачной попытке вернуть исходники выведем сообщение
                        Console.WriteLine("File {0} was returned ;", fileNamesInArchive[j]);
                    }
                    else
                    { // ну и при ошибке естественно выведем текст
                        Console.WriteLine("error");
                    }
                }
            }

            Directory.Delete(tempDirectory); // удалим директорию для временного хранения файлов

            Console.ReadLine();
        }
    }
}
