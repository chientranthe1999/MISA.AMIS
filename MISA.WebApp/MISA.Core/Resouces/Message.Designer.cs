﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MISA.Core.Resouces {
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
    public class Message {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Message() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MISA.Core.Resouces.Message", typeof(Message).Assembly);
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
        ///   Looks up a localized string similar to Thêm dữ liệu thất bại.
        /// </summary>
        public static string AddError {
            get {
                return ResourceManager.GetString("AddError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Thêm dữ liệu thành công.
        /// </summary>
        public static string AddSuccess {
            get {
                return ResourceManager.GetString("AddSuccess", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Xóa dữ liệu thất bại.
        /// </summary>
        public static string DeleteError {
            get {
                return ResourceManager.GetString("DeleteError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Xóa dữ liệu thành công.
        /// </summary>
        public static string DeleteSuccess {
            get {
                return ResourceManager.GetString("DeleteSuccess", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Mã khách hàng bị trùng.
        /// </summary>
        public static string DuplicateCustomerCode {
            get {
                return ResourceManager.GetString("DuplicateCustomerCode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Mã Khách hàng ko được để trống.
        /// </summary>
        public static string EmptyCustomerCode {
            get {
                return ResourceManager.GetString("EmptyCustomerCode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Nhóm khách hàng không được để trống.
        /// </summary>
        public static string EmptyCustomerGroupId {
            get {
                return ResourceManager.GetString("EmptyCustomerGroupId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Tên không được để trống.
        /// </summary>
        public static string EmptyCustomerName {
            get {
                return ResourceManager.GetString("EmptyCustomerName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ID ko được để trống.
        /// </summary>
        public static string EmptyID {
            get {
                return ResourceManager.GetString("EmptyID", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Có lỗi xảy ra, vui lòng liên hệ MISA!!!.
        /// </summary>
        public static string ExceptionError {
            get {
                return ResourceManager.GetString("ExceptionError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cập nhật dữ liệu thất bại.
        /// </summary>
        public static string UpdateError {
            get {
                return ResourceManager.GetString("UpdateError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cập nhật dữ liệu thành công.
        /// </summary>
        public static string UpdateSuccess {
            get {
                return ResourceManager.GetString("UpdateSuccess", resourceCulture);
            }
        }
    }
}
