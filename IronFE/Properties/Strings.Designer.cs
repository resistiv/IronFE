﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IronFE.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("IronFE.Properties.Strings", typeof(Strings).Assembly);
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
        ///   Looks up a localized string similar to Expected BinHex 4.0 stream marker at the beginning of stream..
        /// </summary>
        public static string BinHex4ExpectedMarkerAtBeginning {
            get {
                return ResourceManager.GetString("BinHex4ExpectedMarkerAtBeginning", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unexpected byte 0x{0:X} in BinHex 4.0 stream..
        /// </summary>
        public static string BinHex4UnexpectedByte {
            get {
                return ResourceManager.GetString("BinHex4UnexpectedByte", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Encountered unexpected end of stream in BinHex 4.0 stream..
        /// </summary>
        public static string BinHex4UnexpectedEndOfStream {
            get {
                return ResourceManager.GetString("BinHex4UnexpectedEndOfStream", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CRC initial value must fit within the provided bit width ({0} bits)..
        /// </summary>
        public static string CrcParametersInitialValueOutOfRange {
            get {
                return ResourceManager.GetString("CrcParametersInitialValueOutOfRange", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CRC name must not be null..
        /// </summary>
        public static string CrcParametersNameNull {
            get {
                return ResourceManager.GetString("CrcParametersNameNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CRC output XOR mask must fit within the provided bit width ({0} bits)..
        /// </summary>
        public static string CrcParametersOutputXorOutOfRange {
            get {
                return ResourceManager.GetString("CrcParametersOutputXorOutOfRange", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CRC polynomial must fit within the provided bit width ({0} bits)..
        /// </summary>
        public static string CrcParametersPolynomialOutOfRange {
            get {
                return ResourceManager.GetString("CrcParametersPolynomialOutOfRange", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CRC width must be between 8 and 64 bits, inclusive..
        /// </summary>
        public static string CrcParametersWidthOutOfRange {
            get {
                return ResourceManager.GetString("CrcParametersWidthOutOfRange", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This operation is not supported within a DecodingStream..
        /// </summary>
        public static string DecodingStreamNotSupported {
            get {
                return ResourceManager.GetString("DecodingStreamNotSupported", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DecodingStream class does not support unreadable Stream objects..
        /// </summary>
        public static string DecodingStreamNotSupportedUnreadableStream {
            get {
                return ResourceManager.GetString("DecodingStreamNotSupportedUnreadableStream", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid DosDateTimeOrder value..
        /// </summary>
        public static string DosDateTimeInvalidDosDateTimeOrder {
            get {
                return ResourceManager.GetString("DosDateTimeInvalidDosDateTimeOrder", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot convert a DateTime later than {0:G} to DOS format..
        /// </summary>
        public static string DosDateTimeOutOfRangeMax {
            get {
                return ResourceManager.GetString("DosDateTimeOutOfRangeMax", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot convert a DateTime earlier than {0:G} to DOS format..
        /// </summary>
        public static string DosDateTimeOutOfRangeMin {
            get {
                return ResourceManager.GetString("DosDateTimeOutOfRangeMin", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot add an entry&apos;s direct ancestor to itself as a child..
        /// </summary>
        public static string FileEntryBaseAddAncestorAsChild {
            get {
                return ResourceManager.GetString("FileEntryBaseAddAncestorAsChild", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot add a root entry as the child of another entry..
        /// </summary>
        public static string FileEntryBaseCannotAddRootAsChild {
            get {
                return ResourceManager.GetString("FileEntryBaseCannotAddRootAsChild", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This operation is not supported on non-directory entries..
        /// </summary>
        public static string FileEntryBaseDirectoryOperationNotSupported {
            get {
                return ResourceManager.GetString("FileEntryBaseDirectoryOperationNotSupported", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This operation is not supported on directory entries..
        /// </summary>
        public static string FileEntryBaseFileOperationNotSupported {
            get {
                return ResourceManager.GetString("FileEntryBaseFileOperationNotSupported", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This operation is not supported on root entries..
        /// </summary>
        public static string FileEntryBaseRootOperationNotSupported {
            get {
                return ResourceManager.GetString("FileEntryBaseRootOperationNotSupported", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The name of an entry cannot be the same as one of its siblings..
        /// </summary>
        public static string FileEntryBaseSiblingNameConflict {
            get {
                return ResourceManager.GetString("FileEntryBaseSiblingNameConflict", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot convert a DateTime later than {0:G} to HFS+ format..
        /// </summary>
        public static string HfsPlusDateTimeOutOfRangeMax {
            get {
                return ResourceManager.GetString("HfsPlusDateTimeOutOfRangeMax", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot convert a DateTime earlier than {0:G} to HFS+ format..
        /// </summary>
        public static string HfsPlusDateTimeOutOfRangeMin {
            get {
                return ResourceManager.GetString("HfsPlusDateTimeOutOfRangeMin", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Expected run length in RLE90 stream, but encountered end of stream..
        /// </summary>
        public static string Rle90EosExpectedRunLength {
            get {
                return ResourceManager.GetString("Rle90EosExpectedRunLength", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Encountered a run before buffering a literal byte in RLE90 stream..
        /// </summary>
        public static string Rle90RunBeforeLiteral {
            get {
                return ResourceManager.GetString("Rle90RunBeforeLiteral", resourceCulture);
            }
        }
    }
}
