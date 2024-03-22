﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess.Sql.Violations {
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
    internal class Violations {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Violations() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("DataAccess.Sql.Violations.Violations", typeof(Violations).Assembly);
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
        ///   Looks up a localized string similar to delete
        ///from &quot;DbViolation&quot;
        ///where &quot;Id&quot; = @id.
        /// </summary>
        internal static string Delete {
            get {
                return ResourceManager.GetString("Delete", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select *
        ///from &quot;DbViolation&quot;
        ///where &quot;UserId&quot; = any (@userIds).
        /// </summary>
        internal static string GetAllByLifeSpheres {
            get {
                return ResourceManager.GetString("GetAllByLifeSpheres", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select *
        ///from &quot;DbViolation&quot;
        ///where &quot;Id&quot; = any (@ids).
        /// </summary>
        internal static string GetByIds {
            get {
                return ResourceManager.GetString("GetByIds", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to insert into &quot;DbViolation&quot; (&quot;Id&quot;, &quot;UserId&quot;, &quot;Address&quot;, &quot;ViolationType&quot;, &quot;EventDate&quot;, &quot;CreatedDate&quot;, &quot;Comment&quot;, &quot;ViolationStatus&quot;)
        ///values (@Id, @UserId, @Address, @ViolationType, @EventDate, @CreatedDate, @Comment, @ViolationStatus@)
        ///returning &quot;Id&quot;, &quot;UserId&quot;, &quot;Address&quot;, &quot;ViolationType&quot;, &quot;EventDate&quot;, &quot;CreatedDate&quot;, &quot;Comment&quot;, &quot;ViolationStatus&quot;.
        /// </summary>
        internal static string Insert {
            get {
                return ResourceManager.GetString("Insert", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to insert into &quot;DbTask&quot; (&quot;Id&quot;, &quot;Title&quot;, &quot;CreatedDate&quot;, &quot;StartExecutionDate&quot;, &quot;DeadlineDate&quot;)
        ///values (@Id, @Title, @CreatedDate, @StartExecutionDate, @DeadlineDate)
        ///returning &quot;Id&quot;, &quot;ProjectId&quot;, &quot;Title&quot;, &quot;CreatedDate&quot;, &quot;StartExecutionDate&quot;, &quot;DeadlineDate&quot;.
        /// </summary>
        internal static string Update {
            get {
                return ResourceManager.GetString("Update", resourceCulture);
            }
        }
    }
}
