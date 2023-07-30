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

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                Manager.Golds.Plus("test", 100);
            }
            
            if (Input.GetKeyDown(KeyCode.D))
            {
                Manager.Golds.Minus("test", 100);
            }
            
            if (Input.GetKeyDown(KeyCode.R))
            {
                Manager.Golds.Get("test").ContinueWith(task => {
                    if (task.IsFaulted)
                    {
                        Debug.LogError(task.Exception);
                        return;
                    }

                    Debug.Log(task.Result);
                });
            }

        }
    }
}