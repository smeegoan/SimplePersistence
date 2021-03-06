using System;
using FluentNHibernate.Mapping;
using SimplePersistence.Example.WebApi.Models.Logging;

namespace SimplePersistence.Example.WebApi.UoW.NH.Mapping.Logging
{
    [CLSCompliant(false)]
    public class LevelMapping : ClassMap<Level>
    {
        public LevelMapping()
        {
            Table("Levels");
            Schema("Logging");

            Id(e => e.Id, "Id").Length(128);
            Map(e => e.Description, "Description").Not.Nullable().Length(512);
            HasMany(e => e.Logs).Cascade.All();

            this.MapCreatedMeta().MapUpdatedMeta().MapDeletedMeta().MapByteArrayVersion();
        }
    }
}