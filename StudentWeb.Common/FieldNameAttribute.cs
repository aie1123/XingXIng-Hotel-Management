using System;

namespace StudentWeb.Common
{
    public class FieldNameAttribute: Attribute
    {
        public string FieldName = string.Empty;

        public FieldNameAttribute(string fieldName)
        {
            FieldName = fieldName;
        }
    }
}
