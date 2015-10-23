<b>Open( "Путь к img архиву" )</B> -- Открывает IMG архив для работы</br>
<code>archive.Open(@"S:\games\Grand Theft Auto\models\gta3.img");</code></br></br>
<b>getItems()</b> -- Возвращает список элементов архива в виде List<IMG_Item></br>
<code>
for (int a = 0; a < archive.getItems().Count; a++)
{
    Console.WriteLine("Name: " + archive.getItems()[a].Name + "\tSize: " + archive.getItems()[a].SizeInBytes);
} // get item name and size</code></br></br>
<b>Add( "Путь к загружаемому файлу", "Название, с коим он сохранится в архиве")</b> -- Добавляет файл в IMG архив </br>
<code>
archive.Add(@"S:\gta-o\infernus.dff", "infernus.dff");
archive.Add(@"S:\gta-o\infernus.txd", "infernus.txd");
</code></br></br>
<b>Delete("Название файла")</b> -- Удаляет файл из IMG архива</br><
<code>archive.Delete("infernus.txd");</code></br>/br>
<b>Extract("Название файла", "Директория")</b> -- Извлекает файл из IMG архива в указанную директорию</br></br>
<code>archive.Extract("infernus.dff", "S:\\");</code>
