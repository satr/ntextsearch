using System;

namespace NTextSearch {
    public class PluginProperty{
        public PluginProperty(string propertyType, object value, string title){
            Id = Guid.NewGuid();
            PropertyType = propertyType;
            Value = value;
            Title = title;
        }

        public Guid Id { get; private set; }
        public string PropertyType { get; private set; }
        public object Value { get; set; }
        public string Title { get; private set; }
    }
}
