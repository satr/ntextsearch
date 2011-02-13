using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using NTextSearch.PluginPropertyControls;

namespace NTextSearch{
    internal static class PluginPropertiesAssembler{
        public static Control[] BuildControls(List<PluginProperty> pluginProperties) {
            var controls = new List<Control>();
            pluginProperties.ForEach(property => AddBuildPluginProperty(controls, property));
            return controls.ToArray();
        }

        private static void AddBuildPluginProperty(ICollection<Control> controls, PluginProperty pluginProperty){
            var pluginPropertyControl = BuildPluginProperty(pluginProperty);
            if (pluginPropertyControl != null)
                controls.Add(pluginPropertyControl);
        }

        private static Control BuildPluginProperty(PluginProperty pluginProperty){
            switch(pluginProperty.PropertyType){
                case PluginPropertyType.Boolean:
                    return new BooleanPluginPropertyControl{Dock = DockStyle.Top, Property = pluginProperty};
            }
            Debug.Fail(string.Format("Unsupported plugin property type \"{0}\"", pluginProperty));
            return null;
        }
    }
}