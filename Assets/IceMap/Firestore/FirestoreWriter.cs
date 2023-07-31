using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Firestore;

namespace IceMap.Firestore
{
    public class FirestoreWriter
    {
        private readonly FirebaseFirestore _db;
        
        public FirestoreWriter(FirebaseFirestore db)
        {
            _db = db;
        }
        
        /// <summary>
        /// Firestore のテーブルに主キーありでデータを書き込む
        /// </summary>
        /// <param name="collection">RDB でいう table 的な</param>
        /// <param name="document">RDB でいう 主キー 的な</param>
        /// <param name="data">書き込むデータ</param>
        public async Task WriteAsync(string collection, string document, Dictionary<string, object> data)
        {
            var docRef = _db.Collection(collection).Document(document);
            await docRef.SetAsync(data);
        }
        
        /// <summary>
        /// Firestore の table にデータを書き込む
        /// </summary>
        /// <param name="collection">RDB でいう table 的な</param>
        /// <param name="data">書き込むデータ</param>
        public async Task WriteAsync(string collection, Dictionary<string, object> data)
        {
            var docRef = _db.Collection(collection).Document();
            await docRef.SetAsync(data);
        }
    }
}