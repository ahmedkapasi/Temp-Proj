﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RPN_Coder.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("RPN_Coder.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to vm.@@action_method@@ = function(record){
        ///logc(&apos;@@action_method@@&apos;);
        ///};.
        /// </summary>
        internal static string gridActionMethodTemplate {
            get {
                return ResourceManager.GetString("gridActionMethodTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {text: translate(&apos;@@action_name@@&apos;),data: { data: record},method: model.getMethod(&apos;@@action_method@@&apos;)},.
        /// </summary>
        internal static string gridActionTemplate {
            get {
                return ResourceManager.GetString("gridActionTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {key: &quot;@@col_name@@&quot;},.
        /// </summary>
        internal static string gridColsDetailsTemplate {
            get {
                return ResourceManager.GetString("gridColsDetailsTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {key: &quot;@@col_name@@&quot;,type: &quot;@@col_type@@&quot;},.
        /// </summary>
        internal static string gridColsFltrTemplate {
            get {
                return ResourceManager.GetString("gridColsFltrTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {key: &quot;@@col_name@@&quot;,text: translate(&apos;@@col_text@@&apos;),isSortable: true},.
        /// </summary>
        internal static string gridColsHdrTemplate {
            get {
                return ResourceManager.GetString("gridColsHdrTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &quot;@@module_name@@&quot;: [&quot;css&quot;, &quot;js&quot;, &quot;lang&quot;],.
        /// </summary>
        internal static string lazyloadTemplate {
            get {
                return ResourceManager.GetString("lazyloadTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to routes[&apos;@@module_name@@&apos;] = {
        ///            url: &apos;/@@module_url@@&apos;,
        ///            controller: &apos;@@controller_name@@ as page&apos;,
        ///            lazyLoad: [{
        ///                rerun: true,
        ///                files: [
        ///                    &quot;@@module_file_bundle@@&quot;,
        ///                    &quot;lib.realpage.grid-pagination&quot;
        ///                ]
        ///            }]
        ///        };.
        /// </summary>
        internal static string routeTemplate {
            get {
                return ResourceManager.GetString("routeTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to //@@For RPN Coder Don&apos;t Delete@@.
        /// </summary>
        internal static string rpnSearchString {
            get {
                return ResourceManager.GetString("rpnSearchString", resourceCulture);
            }
        }
    }
}
