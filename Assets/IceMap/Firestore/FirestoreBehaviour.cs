using System;
using Firebase;
using Firebase.Firestore;
using IceMap.Firestore.Database;
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
            // press "s" key to write data
            if (Input.GetKeyDown(KeyCode.S))
            {
                Manager.SpotPosts.Create("test", 0, 0, "test", "test ctx");
            }
            
            // press "r" key to read data
            if (Input.GetKeyDown(KeyCode.R))
            {
                Manager.SpotPosts.GetAll().ContinueWith(task => {
                    if (task.IsFaulted)
                    {
                        Debug.LogError("Error: " + task.Exception);
                        return;
                    }

                    foreach (var spot in task.Result)
                    {
                        Debug.Log($"{spot.PosX}, {spot.PosZ}, {spot.Title}, {spot.Content}");
                    }
                });
            }

        }
    }
}