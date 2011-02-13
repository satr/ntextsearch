using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using NTextSearch.PluginPropertyControls;

namespace NTextSearch{
    internal static class PluginPropertiesAssembler{
        public static Control[] BuildControls(){
            var controls = new List<Control>();
//            AddBuildPluginProperty(controls, PluginPropertyType.Boolean);//sample
            return controls.ToArray();
        }

        private static void AddBuildPluginProperty(ICollection<Control> controls, string pluginPropertyType){
            var pluginProperty = BuildPluginProperty(pluginPropertyType);
            if (pluginProperty != null)
                controls.Add(pluginProperty);
        }

        private static Control BuildPluginProperty(string pluginPropertyType){
            switch(pluginPropertyType){
                case PluginPropertyType.Boolean:
                    return new BooleanPluginPropertyControl{Dock = DockStyle.Top};
            }
            Debug.Fail(string.Format("Unsupported plugin property type \"{0}\"", pluginPropertyType));
            return null;
        }
    }
}