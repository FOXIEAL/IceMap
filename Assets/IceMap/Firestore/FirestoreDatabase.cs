using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase;
using Firebase.Firestore;
using UnityEngine;

namespace IceMap.Firestore
{
    public abstract class FirestoreDatabase
    {
        protected string CollectionName;
        protected string DocumentName;
        
        private readonly FirebaseFirestore _db;
        private readonly FirestoreWriter _writer;
        private readonly FirestoreReader _reader;
        
        protected FirestoreDatabase()
        {
            _db = FirebaseFirestore.DefaultInstance;
            _writer = new FirestoreWriter(_db);
            _reader = new FirestoreReader(_db);
        }

        public async void Write(string document, Dictionary<string, object> data)
        {
            if (IsNullOrEmptyLocalVar())
                return;
            
            await _writer.WriteAsync(document, data);
        }

        public async void Write(Dictionary<string, object> data)
        {
            if (IsNullOrEmptyLocalVar())
                return;
            
            await _writer.WriteAsync(CollectionName, data);
        }

        public async Task<Dictionary<string, object>> Read(string document)
        {
            if (IsNullOrEmptyLocalVar())
                return null;
            
            return await _reader.ReadAsync(CollectionName, document);
        }

        public async Task<QuerySnapshot> Read()
        {
            if (IsNullOrEmptyLocalVar())
                return null;

            return await _reader.ReadAsync(CollectionName);
        }

        private bool IsNullOrEmptyLocalVar()
        {
            if (string.IsNullOrEmpty(CollectionName))
            {
                Debug.LogError("CollectionName is null or empty");
                return true;
            }
            
            if (string.IsNullOrEmpty(DocumentName))
            {
                Debug.LogError("DocumentName is null or empty");
                return true;
            }
            
            return false;
        }
    }
}