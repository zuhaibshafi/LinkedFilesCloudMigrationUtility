
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

// ReSharper disable IdentifierTypo

namespace LinkedFilesCloudMigrationUtility.Models
{
    public interface IBaseObject
    {
        /// <summary>
        /// Gets or sets the creation date and time value. [Type: DateTime]
        /// </summary>
        /// <value>The Date Time.</value>
        DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for employee who created this record. [Type: GUID] [Show_On_Screen: No].
        /// </summary>
        /// <value>The ID of the User for this Budget.</value>
        Guid? CreatedBy_ID { get; set; }

        /// <summary>
        /// Gets or sets the last updated date and time value of this record.  [Type: DateTime] [Show_On_Screen: No].
        /// </summary>
        /// <value>The Date Time.</value>
        DateTime? LastUpdated { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the user who last updated this record. [Type: GUID] [Show_On_Screen: No].
        /// </summary>
        /// <value>The ID of the User.</value>
        Guid? LastUpdatedBy_ID { get; set; }

        /// <summary>
        /// Gets the time stamp of the record. [Type: ByteStream] [Show_On_Screen: No].
        /// </summary>
        /// <value>The RecordTimeStamp.</value>
        byte[] RecordTimeStamp { get; set; }

        /// <summary>
        /// Gets or sets the state of this record. [For Example: New, Old, Deleted Or Updated]. [Type: BOState]
        /// </summary>
        /// <value>The State of the Budget.</value>
        //BOState MyState { get; set; }

        /// <summary>
        /// Gets or sets the retrieval time stamp.[Type: DateTime]
        /// </summary>
        /// <value>The Date Time.</value>
        DateTime RetrievalTimeStamp { get; set; }
    }

    public class BaseObject : IBaseObject
    {
        /// <summary>
        /// Gets or sets the creation date and time value. [Type: DateTime]
        /// </summary>
        /// <value>The Date Time.</value>
        [BQEIgnoreUpdate, BQEIgnoreModelIntegrity]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for employee who created this record. [Type: GUID] [Show_On_Screen: No].
        /// </summary>
        /// <value>The ID of the User for this Budget.</value>
        [BQEIgnoreUpdate, BQEIgnoreModelIntegrity]
        public Guid? CreatedBy_ID { get; set; }

        /// <summary>
        /// Gets or sets the last updated date and time value of this record.  [Type: DateTime] [Show_On_Screen: No].
        /// </summary>
        /// <value>The Date Time.</value>
        [BQEIgnoreModelIntegrity]
        public DateTime? LastUpdated { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the user who last updated this record. [Type: GUID] [Show_On_Screen: No].
        /// </summary>
        /// <value>The ID of the User.</value>
        [BQEIgnoreModelIntegrity]
        public Guid? LastUpdatedBy_ID { get; set; }

        /// <summary>
        /// Gets the time stamp of the record. [Type: ByteStream] [Show_On_Screen: No].
        /// </summary>
        /// <value>The RecordTimeStamp.</value>
        [BQEIgnoreWrite]
        public byte[] RecordTimeStamp { get; set; }

        /// <summary>
        /// Gets or sets the state of this record. [For Example: New, Old, Deleted Or Updated]. [Type: BOState]
        /// </summary>
        /// <value>The State of the Budget.</value>
        //[BQEIgnoreRead, BQEIgnoreWrite, BQEIgnoreModelIntegrity]
        //public BOState MyState { get; set; }

        /// <summary>
        /// Gets or sets the retrieval time stamp.[Type: DateTime]
        /// </summary>
        /// <value>The Date Time.</value>
        [BQEIgnoreRead, BQEIgnoreWrite]
        public DateTime RetrievalTimeStamp { get; set; }


        /// <summary>
        /// Gets or sets the entity.
        /// </summary>
        /// <value>
        /// The entity.
        /// </value>
        [BQEIgnoreRead, BQEIgnoreWrite, BQEIgnoreModelIntegrity]
        private object Entity { get; set; }


        /// <summary>
        /// Sets the entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        //public void SetEntity<T>(T entity) where T : class, new() => Entity = entity.DeepCopy();


        /// <summary>
        /// Gets the entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetEntity<T>() => (T)Entity;
    }

    public interface IUpdatableEntity
    {
        /// <summary>
        /// Sets the entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        void SetEntity<T>(T entity) where T : class, new();


        /// <summary>
        /// Gets the entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T GetEntity<T>();

    }

}
