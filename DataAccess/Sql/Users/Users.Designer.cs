﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess.Sql.Users {
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
    internal class Users {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Users() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("DataAccess.Sql.Users.Users", typeof(Users).Assembly);
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
        ///   Looks up a localized string similar to select *
        ///from &quot;DbUser&quot;.
        /// </summary>
        internal static string GetAll {
            get {
                return ResourceManager.GetString("GetAll", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select *
        ///from &quot;DbUser&quot;
        ///where &quot;Id&quot; = any(@ids).
        /// </summary>
        internal static string GetByIds {
            get {
                return ResourceManager.GetString("GetByIds", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select *
        ///from &quot;DbUser&quot;
        ///where &quot;Login&quot; = @login.
        /// </summary>
        internal static string GetByLogin {
            get {
                return ResourceManager.GetString("GetByLogin", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to insert into &quot;DbUser&quot; (&quot;Id&quot;, &quot;AvatarFileId&quot;, &quot;Login&quot;, &quot;PasswordHash&quot;, &quot;FirstName&quot;, &quot;LastName&quot;, &quot;Patronymic&quot;, &quot;PhoneNumber&quot;, &quot;Email&quot;)
        ///values (@Id, @AvatarFileId, @Login, @PasswordHash, @FirstName, @LastName, @Patronymic, @PhoneNumber, @Email)
        ///returning &quot;Id&quot;, &quot;AvatarFileId&quot;, &quot;Login&quot;, &quot;PasswordHash&quot;, &quot;FirstName&quot;, &quot;LastName&quot;, &quot;Patronymic&quot;, &quot;PhoneNumber&quot;, &quot;Email&quot;.
        /// </summary>
        internal static string Insert {
            get {
                return ResourceManager.GetString("Insert", resourceCulture);
            }
        }
    }
}