using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Firestore;

namespace IceMap.Firestore.Database
{
    public class Golds : FirestoreDatabase
    {
        private const string UserID = "uid";
        private const string Gold = "gold";
        
        public Golds(FirebaseFirestore db) : base(db)
        {
            CollectionName = "golds";
        }
        
        /// <summary>
        /// gold を加算する
        /// </summary>
        /// <param name="uid">ユーザー ID</param>
        /// <param name="gold">加算する値</param>
        public async void Plus(string uid, int gold)
        {
            var current = await Get(uid);
            
            var data = new Dictionary<string, object>{
                {UserID, uid},
                {Gold, current + gold},
            };
            
            Write(uid, data);
        }
        
        /// <summary>
        /// gold を減算する
        /// </summary>
        /// <param name="uid">ユーザー ID</param>
        /// <param name="gold">減算する値</param>
        public async void Minus(string uid, int gold)
        {
            var current = await Get(uid);
            
            var data = new Dictionary<string, object>{
                {UserID, uid},
                {Gold, current - gold},
            };
            
            Write(uid, data);
        }

        /// <summary>
        /// uid が持つ Gold を取得する
        /// </summary>
        /// <param name="uid">ユーザー ID</param>
        /// <returns>uid gold</returns>
        public async Task<long> Get(string uid)
        {
            var data = await Read(uid);

            if (data != null)
            {
                return (long) data[Gold];
            }
            
            Register(uid);
            return 0;
        }
        
        private void Register(string uid)
        {
            var data = new Dictionary<string, object>{
                {UserID, uid},
                {Gold, 0},
            };
            
            Write(uid, data);
        }
    }
}