using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ConfigFiles.Infrastructure
{
    public class CustomDefaults : ConfigurationSectionGroup
    {
        public NewUserDefaultsSection NewUserDefaults
        {
            get { return (NewUserDefaultsSection)Sections["newUserDefaults"]; }
        }
        public PlaceSection Places
        {
            get { return (PlaceSection)Sections["places"]; }
        }
    }
}