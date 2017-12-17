public static class LiteDBHelper
    {
        // LiteDBHelper
        // Melih SAFRAN
        // Create: 18.09.2017
        // Update: 08.12.2017

        // Basic CRUD
        public static LiteDatabase GetDatabase(string liteDbPath)
        {
            LiteDatabase liteDatabaseCurrent = null;

            using (var liteDatabase = new LiteDatabase(liteDbPath))
            {
                liteDatabaseCurrent = liteDatabase;
            }

            return liteDatabaseCurrent;
        }

        public static bool TruncateCollection<T>(string liteDbPath, string liteDbCollectionName)
        {
            LiteDatabase liteDatabase = GetDatabase(liteDbPath);
            return liteDatabase.DropCollection(liteDbCollectionName);
        }

        public static LiteCollection<T> GetCollection<T>(string liteDbPath, string liteDbCollectionName)
        {
            LiteCollection<T> liteCollection = null;

            using (var liteDatabase = new LiteDatabase(liteDbPath))
            {
                liteCollection = liteDatabase.GetCollection<T>(liteDbCollectionName);
            }

            return liteCollection;
        }

        public static IEnumerable<T> FindAll<T>(string liteDbPath, string liteDbCollectionName)
        {
            LiteCollection<T> liteCollection = GetCollection<T>(liteDbPath, liteDbCollectionName);
            return liteCollection.FindAll();
        }

        public static IEnumerable<T> Find<T>(string liteDatabasePath, string liteDbCollectionName, System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            LiteCollection<T> liteCollection = GetCollection<T>(liteDatabasePath, liteDbCollectionName);
            return liteCollection.Find(predicate);
        }

        public static IEnumerable<T> Find<T>(string liteDbPath, string liteDbCollectionName, Query liteDBQuery)
        {
            LiteCollection<T> liteCollection = GetCollection<T>(liteDbPath, liteDbCollectionName);
            return liteCollection.Find(liteDBQuery);
        }

        public static T FindById<T>(string liteDbPath, string liteDbCollectionName, int id)
        {
            LiteCollection<T> liteCollection = GetCollection<T>(liteDbPath, liteDbCollectionName);
            return liteCollection.FindById(new BsonValue(id));
        }

        public static bool Insert<T>(string liteDbPath, string liteDbCollectionName, T item)
        {
            BsonValue bsonValueInsertResult = null;
            LiteCollection<T> liteCollection = GetCollection<T>(liteDbPath, liteDbCollectionName);
            bsonValueInsertResult = liteCollection.Insert(item);
            return bsonValueInsertResult != null;
        }

        public static bool Insert<T>(string liteDbPath, string liteDbCollectionName, IEnumerable<T> items)
        {
            BsonValue bsonValueInsertResult = null;
            LiteCollection<T> liteCollection = GetCollection<T>(liteDbPath, liteDbCollectionName);
            bsonValueInsertResult = liteCollection.Insert(items);
            return bsonValueInsertResult != null;
        }

        public static bool Update<T>(string liteDbPath, string liteDbCollectionName, T item)
        {
            BsonValue bsonValueUpdateResult = null;
            LiteCollection<T> liteCollection = GetCollection<T>(liteDbPath, liteDbCollectionName);
            bsonValueUpdateResult = liteCollection.Update(item);
            return bsonValueUpdateResult != null;
        }

        public static bool Delete<T>(string liteDbPath, string liteDbCollectionName, int id)
        {
            LiteCollection<T> liteCollection = GetCollection<T>(liteDbPath, liteDbCollectionName);
            return liteCollection.Delete(id);
        }

        public static int Delete<T>(string liteDbPath, string liteDbCollectionName, Query liteDBQuery)
        {
            LiteCollection<T> liteCollection = GetCollection<T>(liteDbPath, liteDbCollectionName);
            return liteCollection.Delete(liteDBQuery);
        }

        public static int Delete<T>(string liteDbPath, string liteDbCollectionName, System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            LiteCollection<T> liteCollection = GetCollection<T>(liteDbPath, liteDbCollectionName);
            return liteCollection.Delete(predicate);
        }

        public static bool Exist<T>(string liteDbPath, string liteDbCollectionName, System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            LiteCollection<T> liteCollection = GetCollection<T>(liteDbPath, liteDbCollectionName);
            return liteCollection.Exists(predicate);
        }

        public static bool Exist<T>(string liteDbPath, string liteDbCollectionName, Query liteDBQuery)
        {
            LiteCollection<T> liteCollection = GetCollection<T>(liteDbPath, liteDbCollectionName);
            return liteCollection.Exists(liteDBQuery);
        }
    }