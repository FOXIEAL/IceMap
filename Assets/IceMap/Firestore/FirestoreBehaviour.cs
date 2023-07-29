using Firebase;
using Firebase.Firestore;
using UnityEngine;

namespace IceMap.Firestore
{
    public class FirestoreBehaviour : MonoBehaviour
    {
        public FirestoreManager Manager { get; private set; }
        
        private void Start()
        {
            FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(_ => {
                var app = FirebaseApp.DefaultInstance;
                var db = FirebaseFirestore.DefaultInstance;
                Manager = new FirestoreManager(db);
                Debug.Log("Firebase initialized successfully!");
            });
            
            DontDestroyOnLoad(gameObject);
        }
    }
}