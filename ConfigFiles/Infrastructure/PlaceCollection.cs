using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ConfigFiles.Infrastructure
{
    public class PlaceCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new Place();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((Place)element).Code;
        }
        public new Place this[string key]
        {
            get { return (Place)BaseGet(key); }
        }
    }
}