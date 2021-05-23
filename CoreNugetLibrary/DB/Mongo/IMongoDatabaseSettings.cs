using System;
namespace APMAN.Core.DB.Mongo
{
    public interface IMongoDatabaseSettings
    {
        public string CollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
