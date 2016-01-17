# ntextsearch
NTextSearch - an util for searching text in files. Exported from code.google.com/p/ntextsearch
The running application NTextSearch.exe is located in the folder "bin". 
Plugins should be placed into the folder "bin\plugins". 
These plugins are satellite assemblies, implementing an interface ITextSearch and marked by an attribute TextSearchEngine
from the assembly NTextSearchInt.dll. 
For quick start it's possible to inherit the abstract class "AbstractTextSearchPlugin" from this assembly.
