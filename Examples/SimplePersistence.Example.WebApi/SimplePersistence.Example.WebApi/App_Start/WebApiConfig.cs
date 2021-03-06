﻿using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using SimplePersistence.Example.WebApi.Helpers;
using SimplePersistence.Example.WebApi.Models.Logging;

namespace SimplePersistence.Example.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            #region OData Registration

            var builder = new ODataConventionModelBuilder
            {
                OnModelCreating = modelBuilder =>
                {
                    //  Because we are using convention builder but not
                    //  using anotations, it will duplicate all the Version properties
                    foreach (var st in modelBuilder.StructuralTypes)
                    {
                        st.ExcludeDuplicatedVersionPropertiesNotSetAsConcurrencyToken();
                    }
                }
            };

            builder.EntitySet<Application>().EntityType(cfg =>
            {
                cfg.Property(e => e.Version).IsConcurrencyToken().IsRequired();
            });
            builder.EntitySet<Level>().EntityType(cfg =>
            {
                cfg.Property(e => e.Version).IsConcurrencyToken().IsRequired();
            });
            builder.EntitySet<Log>();

            config.MapODataServiceRoute("ODataRoute", "odata", builder.GetEdmModel());

            #endregion
        }
    }
}
