using Firebase.Firestore;
using IceMap.Firestore.Database;

namespace IceMap.Firestore
{
    public class FirestoreManager
    {
        public SpotPosts SpotPosts { get; private set; } 
        
        public FirestoreManager(FirebaseFirestore db)
        {
            SpotPosts = new SpotPosts(db);
        }
    }
}