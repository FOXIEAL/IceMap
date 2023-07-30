using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Firestore;

namespace IceMap.Firestore
{
    public class FirestoreReader
    {
        private readonly FirebaseFirestore _db;
        
        public FirestoreReader(FirebaseFirestore db)
        {
            _db = db;
        }
        
        /// <summary>
        /// Firestore から table と 主キー でデータを取得する
        /// </summary>
        /// <param name="collection">RDB でいう table</param>
        /// <param name="document">RDB でいう 主キー</param>
        /// <returns>Dict 型の検索結果</returns>
        public async Task<Dictionary<string, object>> ReadAsync(string collection, string document)
        {
            var docRef = _db.Collection(collection).Document(document);
            var snapshot = await docRef.GetSnapshotAsync();

            if (!snapshot.Exists) 
                return default;
            
            var data = snapshot.ToDictionary();
            return data;
        }
        
        /// <summary>
        /// Firestore から table のデータを取得する
        /// </summary>
        /// <param name="collection">RDB でいう table</param>
        /// <returns>複数の検索結果</returns>
        public async Task<QuerySnapshot> ReadAsync(string collection)
        {
            var docRef = _db.Collection(collection);
            var snapshot = await docRef.GetSnapshotAsync();

            return snapshot;
        }
    }
}