using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.PropertyEditors;

namespace EnumLists
{
    [PropertyValueType(typeof(IEnumerable<string>))]
    [PropertyValueCache(PropertyCacheValue.All, PropertyCacheLevel.Request)]
    public class EnumListsConverter : PropertyValueConverterBase
    {
        public override bool IsConverter(PublishedPropertyType propertyType)
        {
            return "EnumCheckBoxList".Equals(propertyType.PropertyEditorAlias);
        }

        public override object ConvertSourceToObject(PublishedPropertyType propertyType, object source, bool preview)
        {
            if (source == null)
            {
                return null;
            }

            try
            {
                return JsonConvert.DeserializeObject<IEnumerable<string>>(source.ToString());
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}