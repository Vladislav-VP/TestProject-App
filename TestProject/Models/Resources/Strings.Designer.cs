﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestProject.Entities.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Strings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Strings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("TestProject.Entities.Resources.Strings", typeof(Strings).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cancel.
        /// </summary>
        public static string CancelButtonText {
            get {
                return ResourceManager.GetString("CancelButtonText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Are you sure yuo want to delete?.
        /// </summary>
        public static string DeleteMessageDialog {
            get {
                return ResourceManager.GetString("DeleteMessageDialog", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid format of password!.
        /// </summary>
        public static string InvalidPasswordFormatMessage {
            get {
                return ResourceManager.GetString("InvalidPasswordFormatMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Name can not be empty!.
        /// </summary>
        public static string InvalidTodoItemMessage {
            get {
                return ResourceManager.GetString("InvalidTodoItemMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Incorrect username or password! Check entered data.
        /// </summary>
        public static string LoginErrorMessage {
            get {
                return ResourceManager.GetString("LoginErrorMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No.
        /// </summary>
        public static string NoButtonText {
            get {
                return ResourceManager.GetString("NoButtonText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Yes.
        /// </summary>
        public static string OkButtonText {
            get {
                return ResourceManager.GetString("OkButtonText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Password is too short!.
        /// </summary>
        public static string TooShortPasswordMessage {
            get {
                return ResourceManager.GetString("TooShortPasswordMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to User with this name already exists!.
        /// </summary>
        public static string UserAlreadyExistsMessage {
            get {
                return ResourceManager.GetString("UserAlreadyExistsMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Username and password can not be empty!.
        /// </summary>
        public static string UserDataNullOrEmptyMessage {
            get {
                return ResourceManager.GetString("UserDataNullOrEmptyMessage", resourceCulture);
            }
        }
    }
}