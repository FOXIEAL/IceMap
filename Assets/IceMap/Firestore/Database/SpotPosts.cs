using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Firestore;

namespace IceMap.Firestore.Database
{
    public class SpotPosts : FirestoreDatabase
    {
        private const string UserID = "uid";
        private const string Longitude = "longitude";
        private const string Latitude = "latitude";
        private const string Title = "title";
        private const string Content = "content";
        
        public SpotPosts(FirebaseFirestore db) : base(db)
        {
            CollectionName = "posts";
        }
        
        /// <summary>
        /// スポットを追加する
        /// </summary>
        /// <param name="uid">ユーザー ID</param>
        /// <param name="longitude">x 座標</param>
        /// <param name="latitude">z 座標</param>
        /// <param name="title">投稿タイトル</param>
        /// <param name="content">投稿内容</param>
        public void Create(string uid, float longitude, float latitude, string title, string content)
        {
            var data = new Dictionary<string, object>{
                {UserID, uid},
                {Longitude, longitude},
                {Latitude, latitude},
                {Title, title},
                {Content, content}
            };
            
            Write(data);
        }

        /// <summary>
        /// 全ての投稿を取得する
        /// </summary>
        /// <returns>Post のリスト</returns>
        public async Task<List<SpotData>> GetAll()
        {
            var snapshot = await Read();
            var result = new List<SpotData>();
            
            foreach (var docSnap in snapshot.Documents)
            {
                if (!docSnap.Exists) return result;
                
                var data = docSnap.ToDictionary();
                var post = new SpotData
                {
                    Longitude = float.Parse(data[Longitude].ToString()),
                    Latitude = float.Parse(data[Latitude].ToString()),
                    Title = data[Title].ToString(),
                    Content = data[Content].ToString()
                };
                result.Add(post);
            }
            
            return result;
        }
        
        public class SpotData
        {
            public float Longitude;
            public float Latitude;
            public string Title;
            public string Content;
        }
    }
}