// ***********************************************************************
// Assembly         : LinkedFilesCloudMigrationUtility.Models
// Author           : Administrator
// Created          : 02-13-2014
//
// Last Modified By : Administrator
// Last Modified On : 02-13-2014
// ***********************************************************************
// <copyright file="BQEExtendedProperty.cs" company="BQE Software Inc">
//     Copyright (c) BQE Software Inc. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;

/// <summary>
/// The Model namespace.
/// </summary>
namespace LinkedFilesCloudMigrationUtility.Models
{

    /// <summary>
    /// Class BQEIgnoreModelIntegrity.
    /// </summary>
    public class BQEIgnoreModelIntegrity : System.Attribute
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="BQEIgnoreModelIntegrity"/> class.
        /// </summary>
        public BQEIgnoreModelIntegrity()
        {

        }
    }

    /// <summary>
    /// Class BQEIgnoreRead.
    /// </summary>
    public class BQEIgnoreRead : System.Attribute
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="BQEIgnoreRead"/> class.
        /// </summary>
        public BQEIgnoreRead()
        {

        }
    }
    /// <summary>
    /// Class BQEIgnoreWrite.
    /// </summary>
    public class BQEIgnoreWrite : System.Attribute
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="BQEIgnoreWrite"/> class.
        /// </summary>
        public BQEIgnoreWrite()
        {

        }
    }


    public class BQEIgnoreUpdate : System.Attribute
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="BQEIgnoreUpdate"/> class.
        /// </summary>
        public BQEIgnoreUpdate()
        {

        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class BQESecure : Attribute
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public class HasCustomLabel : Attribute
    {
        public HasCustomLabel(string property)
        {
            Property = property;
        }

        public string Property { get; }

    }


    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class ExportMemoTo : Attribute
    {
        public ExportMemoTo(string property)
        {
            Property = property;
        }

        public string Property { get; }

    }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class IgnoreCustomLabel : Attribute
    {
    }


    /// <summary>
    /// Class BQEMaxLengthAttribute.
    /// </summary>
    public class BQEMaxLengthAttribute : System.Attribute
    {
        /// <summary>
        /// The field maximum length
        /// </summary>
        int fieldMaxLength = -1;
        /// <summary>
        /// The supress data
        /// </summary>
        bool supressData;

        // Summary:
        //     Initializes a new instance of the System.ComponentModel.DataAnnotations.MaxLengthAttribute
        //     class.

        /// <summary>
        /// Initializes a new instance of the <see cref="BQEMaxLengthAttribute"/> class.
        /// </summary>
        public BQEMaxLengthAttribute() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="BQEMaxLengthAttribute"/> class.
        /// </summary>
        /// <param name="length">The maximum allowable length of array or string data.</param>
        /// <param name="supressData">true for suppress Data or false if don't want to suppress data exceeding field length</param>
        public BQEMaxLengthAttribute(int length, bool supressData)
        {
            this.supressData = supressData;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="BQEMaxLengthAttribute"/> class.
        /// </summary>
        /// <param name="supressData">true for suppress Data or false if don't want to suppress data exceeding field length</param>
        public BQEMaxLengthAttribute(bool supressData)
        {
            this.supressData = supressData;
        }



        /// <summary>
        /// Initializes a new instance of the <see cref="BQEMaxLengthAttribute"/> class.
        /// </summary>
        /// <param name="length">The maximum allowable length of array or string data.</param>
        public BQEMaxLengthAttribute(int length)
        {
            fieldMaxLength = length;
        }

        // Summary:
        //     Gets the maximum allowable length of the data.
        // Returns:
        //     The maximum allowable length of the array or string data.
        /// <summary>
        /// Gets the length.
        /// </summary>
        /// <value>The length.</value>

        public int Length { get { return fieldMaxLength; } }

        // Summary:
        //     Gets the boolean value to check
        //
        // Returns:
        //    default false for default .
        /// <summary>
        /// Gets a value indicating whether [supress data].
        /// </summary>
        /// <value><c>true</c> if [supress data]; otherwise, <c>false</c>.</value>
        public bool SupressData { get { return this.supressData; } }
    }

    /// <summary>
    /// class attribute to set object property as  primary key
    /// </summary>
    public class PrimaryKeyAttribute : Attribute { }

    /// <summary>
    /// class attribute to set object property as  ForeignProperty 
    /// </summary>
    /*public class ForeignPropertyAttribute : Attribute
    {

        private ModuleNames? foreignModel;

        public ModuleNames? ForeignModel { get { return foreignModel; } }

        public ForeignPropertyAttribute() { }

        public ForeignPropertyAttribute(ModuleNames foreignModel)
        {
            this.foreignModel = foreignModel;
        }

    }*/


    public static class StringExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string StripHtmlTags(this string text)
        {
            if (string.IsNullOrEmpty(text)) return text;

            var removeTags = new Regex("<(.|\\n)*?>");
            var compressSpaces = new Regex(@"[\r\n]+");
            text = removeTags.Replace(text, string.Empty);
            text = compressSpaces.Replace(text, " ");

            return text.Trim();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="times"></param>
        /// <returns></returns>
        public static string HtmlDecode(this string text, uint times = 1)
        {
            if (string.IsNullOrEmpty(text) || times <= 0) return text;

            for (var iteration = 1; iteration <= times; iteration++)
                text = HttpUtility.HtmlDecode(text);

            return text.Trim();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string HtmlEncode(this string text) =>
            string.IsNullOrEmpty(text) ? text : HttpUtility.HtmlEncode(text).Trim();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// WebApp double encodes some of the characters, hence, we default to a 2 times decode.
        /// <returns></returns>
        public static string ToExportFormat(this string text) => text.HtmlDecode(2).StripHtmlTags();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string Trim(this string value, int length) =>
            value?.Length >= length ? value.Substring(0, length) : value;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Attribute" />
    public class BQEIgnoreValueAttribute : Attribute
    {
    }


    
    

}
