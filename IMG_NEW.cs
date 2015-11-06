using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using XArchiveDragon;
using System.Threading;

namespace imageArchive
{
    class IMG
    {
        IMG_Archive archive = null; // initializate value
        string archivePath = string.Empty;
        ///<summary>
        ///Open( путь к архиву ).
        /// <returns>
        /// Вернет true при успешном открытии архива.
        /// Вернет false в том случае, если архив был открыт, путь некорректный или произошла ошибка при инициализации класса.
        /// </returns>
        ///</summary>
        public bool Open(string path, bool check = true)
        {
            /*
                open(path, false) обновит данные архива
             */
            if (check)
                if (archive != null)
                    return false;

                if (!File.Exists(path))
                    return false;

            try
            {
                archivePath = path;
                archive = new IMG_Archive(path); // open
            }
            catch(Exception ex)
            {
                Console.WriteLine( ex.Message );
                return false;
            }
            
            return true;
        }

        /// <summary>
        /// Получить содержимое открытого архива
        /// </summary>
        /// <returns>Возвращает содержимое архива в виде List(IMG_Item></returns>
        public List<IMG_Item> getItems() {
            return archive.Items;
        }
        /// <summary>
        /// Пиндосы очень тупые и прикрутили тьму ненужных аргументов в виде прогрессБара и проверки на валидноть. Затея бред, пришлось полностью переписывать функцию
        /// </summary>
        /// <param name="file">Путь к файлу, который следует добавить в архив</param>
        /// <returns>true при удачном добавлении, false при ошибке</returns>
        public bool Add(string filePath, string fileName)
        {
            if (!File.Exists(filePath))
            {
                return false;
            }

            for (int item = 0; item != archive.Items.Count; item++)
            {
                if (fileName != archive.Items[item].Name)
                    continue;
 
                Delete(fileName);
                break;
            }

            try
            {
                IMG_Item file = new IMG_Item();
                file.OffsetBlock = this.GetEOFoffsetBlock();
                file.SizeInBytes = (int)new FileInfo(filePath).Length;
                file.Name = fileName;

                archive.Items.Add(file);

                BinaryWriter binaryWriter = new BinaryWriter(new FileStream(archivePath, FileMode.Open));
                binaryWriter.BaseStream.Position = (long)((ulong)(file.OffsetBlock * 2048u));
                binaryWriter.Write(File.ReadAllBytes(filePath));
                binaryWriter.BaseStream.Position = 0L;
                archive.WriteHeader(binaryWriter);
                binaryWriter.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            Open(archivePath, false);
            return true;
        }

        /// <summary>
        /// Создает временную папку с оригинальными файлами и заменяет их на ваши
        /// </summary>
        /// <param name="path">Файл, который заменит временно оригинальный</param>
        /// <param name="filename">Название заменяемого файла в архиве</param>
        /// <param name="tempDirectory">Папка для временного хранения оригиналов</param>
        /// <returns>none</returns>
        public bool AddTempFile(string path, string filename, string tempDirectory)
        {
            if (!Directory.Exists(tempDirectory))
                Directory.CreateDirectory(tempDirectory);

            Extract(filename, tempDirectory);
            return Add(path, filename);
        }

        /// <summary>
        /// Восстанавливает архив в исходное положение из директории
        /// </summary>
        /// <param name="filename">Название файла</param>
        /// <param name="tempDirectory"></param>
        public bool RemoveTempFile(string filename, string tempDirectory)
        {
            return Add(tempDirectory, filename);
        }

        internal uint GetEOFoffsetBlock()
        {
            uint num = 1u;
            for (int i = 0; i < archive.Items.Count; i++)
            {
                uint num2 = (uint)((ulong)archive.Items[i].OffsetBlock + (ulong)((long)archive.Items[i].SizeInBlock));
                if (num2 > num)
                {
                    num = num2;
                }
            }
            return num;
        }

        /// <summary>
        /// Удаляет файл из архива
        /// </summary>
        /// <param name="filePath">fileName - название файла</param>
        /// <returns></returns>
        public bool Delete(string fileName)
        {
            try
            {
                archive.Items.RemoveAt(archive.GetIndexByName(fileName));
                BinaryWriter binaryWriter = new BinaryWriter(new FileStream(archivePath, FileMode.OpenOrCreate));
                archive.WriteHeader(binaryWriter);
                binaryWriter.Flush();
                binaryWriter.Close();
                Open(archivePath, false);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            
            return true;
        }

        /// <summary>
        /// Достает файл из архива
        /// </summary>
        /// <param name="fileName">Название файла</param>
        /// <param name="toPath">Путь к сохранению</param>
        /// <returns>true or false</returns>
        public bool Extract(string fileName, string toPath)
        {
            Open(archivePath, false); // update

            try
            {
                for (int item = 0; item != getItems().Count; item++)
                {
                    if (archive.Items[item].Name != fileName)
                        continue;

                    byte[] data = archive.Items[item].GetData();
                    File.WriteAllBytes(toPath + "\\" + fileName, data);
                    break;
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public int GetIndexByName(string searchName)
        {
            searchName = searchName.ToLower();
            int result;
            for (int i = 0; i < archive.Items.Count; i++)
            {
                if (archive.Items[i].NameLowered == searchName)
                {
                    result = i;
                    return result;
                }
            }
            result = -1;

            Open(archivePath, false);
            return result;
        }
    }
}
