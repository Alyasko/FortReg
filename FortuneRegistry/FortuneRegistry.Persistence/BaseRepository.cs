using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using LiteDB;

namespace FortuneRegistry.Persistence
{
    public abstract class BaseRepository<T> : IDisposable
    {
        public const string DatabaseFileName = "fortreg.db";

        protected LiteDatabase Database { get; private set; }

        protected BaseRepository()
        {
            Database = new LiteDatabase(DatabaseFileName);
        }

        protected abstract string CollectionName { get; set; }
        public LiteCollection<T> Collection => Database.GetCollection<T>(CollectionName);

        public BsonValue Add(T item)
        {
            return Collection.Insert(item);
        }

        public BsonValue Add(IEnumerable<T> items)
        {
            return Collection.Insert(items);
        }

        public IEnumerable<T> GetAll()
        {
            return Collection.FindAll();
        }

        public bool DeleteDatabaseFile()
        {
            try
            {
                if (File.Exists(DatabaseFileName))
                {
                    File.Delete(DatabaseFileName);
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
