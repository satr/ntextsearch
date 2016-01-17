NTextSearch - an util for searching text in files.
The running application NTextSearch.exe is located in the folder "bin".
Plugins should be placed into the folder "bin\plugins". These plugins are satellite assymblies, implementing an interface ITextSearch and marked by an attribute TextSearchEngine from the assembly NTextSearchInt.dll. (For quick starting it's possible to inherit the abstract class "AbstractTextSearchPlugin" in this assembly).


NTextSearch - утилита поиска текста в файлах.
В папке bin находится приложение NTextSearch.exe
В папке bin\plugins можно выкладывать плагины, поддерживающие интерфейс ITextSearch и отмеченные аттрибутом TextSearchEngine из сборки NTextSearchInt.dll (для начала можно унаследоваться от абстрактного класса AbstractTextSearchPlugin).