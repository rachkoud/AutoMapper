﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.EntityClient;
using System.Data.Metadata.Edm;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace AutoMapper.UnitTests.Bug.Data.Samples.EF5WithSelfTackingEntities
{
    public partial class SampleDatabaseWithSelfTrackingEntitiesEntities : ObjectContext
    {
        public const string ConnectionString = "name=SampleDatabaseWithSelfTrackingEntitiesEntities";
        public const string ContainerName = "SampleDatabaseWithSelfTrackingEntitiesEntities";
    
        #region Constructors
    
        public SampleDatabaseWithSelfTrackingEntitiesEntities()
            : base(ConnectionString, ContainerName)
        {
            Initialize();
        }
    
        public SampleDatabaseWithSelfTrackingEntitiesEntities(string connectionString)
            : base(connectionString, ContainerName)
        {
            Initialize();
        }
    
        public SampleDatabaseWithSelfTrackingEntitiesEntities(EntityConnection connection)
            : base(connection, ContainerName)
        {
            Initialize();
        }
    
        private void Initialize()
        {
            // Creating proxies requires the use of the ProxyDataContractResolver and
            // may allow lazy loading which can expand the loaded graph during serialization.
            ContextOptions.ProxyCreationEnabled = false;
            ObjectMaterialized += new ObjectMaterializedEventHandler(HandleObjectMaterialized);
        }
    
        private void HandleObjectMaterialized(object sender, ObjectMaterializedEventArgs e)
        {
            var entity = e.Entity as IObjectWithChangeTracker;
            if (entity != null)
            {
                bool changeTrackingEnabled = entity.ChangeTracker.ChangeTrackingEnabled;
                try
                {
                    entity.MarkAsUnchanged();
                }
                finally
                {
                    entity.ChangeTracker.ChangeTrackingEnabled = changeTrackingEnabled;
                }
                this.StoreReferenceKeyValues(entity);
            }
        }

        #endregion

        #region ObjectSet Properties
    
        public ObjectSet<Destination> Destinations
        {
            get { return _destinations  ?? (_destinations = CreateObjectSet<Destination>("Destinations")); }
        }
        private ObjectSet<Destination> _destinations;
    
        public ObjectSet<Source> Sources
        {
            get { return _sources  ?? (_sources = CreateObjectSet<Source>("Sources")); }
        }
        private ObjectSet<Source> _sources;

        #endregion

    }
}
