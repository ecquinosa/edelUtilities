﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EdelUtilities.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.10.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://aub.allcard.com.ph:82/ACC_MS_WEBSERVICE.asmx")]
        public string EdelUtilities_aubWS_ACC_MS_WEBSERVICE {
            get {
                return ((string)(this["EdelUtilities_aubWS_ACC_MS_WEBSERVICE"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://ubp.allcard.com.ph:82/ACC_MS_WEBSERVICE.asmx")]
        public string EdelUtilities_ubpWS_ACC_MS_WEBSERVICE {
            get {
                return ((string)(this["EdelUtilities_ubpWS_ACC_MS_WEBSERVICE"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://172.16.7.171:82/ACC_MS_WEBSERVICE.asmx")]
        public string EdelUtilities_rbankSIT_WS_ACC_MS_WEBSERVICE {
            get {
                return ((string)(this["EdelUtilities_rbankSIT_WS_ACC_MS_WEBSERVICE"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://172.16.7.184:8444/ACC_MS_WEBSERVICE.asmx")]
        public string EdelUtilities_aubWS_SIT_OLD_ACC_MS_WEBSERVICE {
            get {
                return ((string)(this["EdelUtilities_aubWS_SIT_OLD_ACC_MS_WEBSERVICE"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://10.88.87.67:8444/ACC_MS_WEBSERVICE.asmx")]
        public string EdelUtilities_ubpWS_SIT_ACC_MS_WEBSERVICE {
            get {
                return ((string)(this["EdelUtilities_ubpWS_SIT_ACC_MS_WEBSERVICE"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://10.88.77.177:8555/ACC_MS_WEBSERVICE.asmx")]
        public string EdelUtilities_aubWS_PreProd_ACC_MS_WEBSERVICE {
            get {
                return ((string)(this["EdelUtilities_aubWS_PreProd_ACC_MS_WEBSERVICE"]));
            }
        }
    }
}
