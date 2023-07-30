using Firebase.Firestore;
using IceMap.Firestore.Database;

namespace IceMap.Firestore
{
    public class FirestoreManager
    {
        public SpotPosts SpotPosts { get; } 
        public Golds Golds { get; }
        
        public FirestoreManager(FirebaseFirestore db)
        {
            SpotPosts = new SpotPosts(db);
            Golds = new Golds(db);
        }
    }
}