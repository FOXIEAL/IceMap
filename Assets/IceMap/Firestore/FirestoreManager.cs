using Firebase.Firestore;

namespace IceMap.Firestore
{
    public class FirestoreManager
    {
        private FirebaseFirestore _db;
        
        public FirestoreManager(FirebaseFirestore db)
        {
            _db = db;
        }
    }
}