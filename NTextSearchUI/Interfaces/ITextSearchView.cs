using System.Collections.Generic;

namespace NTextSearch{
    public interface ITextSearchView{
        void Close();
        void RefreshPlugins(List<ITextSearch> plugins);
        void SetStatus(string message);
        void ClearList();
        void RefreshPluginProperties(List<PluginProperty> pluginProperties);
        void RefreshSearchState(bool inProcess);
        void SetFoundFilesStatus(string message);
    }
}