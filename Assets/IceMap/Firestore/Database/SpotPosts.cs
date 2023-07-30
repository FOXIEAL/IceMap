using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Firestore;

namespace IceMap.Firestore.Database
{
    public class SpotPosts : FirestoreDatabase
    {
        private const string UserID = "uid";
        private const string PosX = "px";
        private const string PosZ = "pz";
        private const string Title = "title";
        private const string Content = "content";
        
        public SpotPosts(FirebaseFirestore db) : base(db)
        {
            CollectionName = "posts";
            DocumentName = "none";
        }
        
        /// <summary>
        /// スポットを追加する
        /// </summary>
        /// <param name="uid">ユーザー ID</param>
        /// <param name="px">x 座標</param>
        /// <param name="pz">z 座標</param>
        /// <param name="title">投稿タイトル</param>
        /// <param name="content">投稿内容</param>
        public void Create(string uid, float px, float pz, string title, string content)
        {
            var data = new Dictionary<string, object>{
                {UserID, uid},
                {PosX, px},
                {PosZ, pz},
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
                    PosX = float.Parse(data[PosX].ToString()),
                    PosZ = float.Parse(data[PosZ].ToString()),
                    Title = data[Title].ToString(),
                    Content = data[Content].ToString()
                };
                result.Add(post);
            }
            
            return result;
        }
        
        public class SpotData
        {
            public float PosX;
            public float PosZ;
            public string Title;
            public string Content;
        }
    }
}