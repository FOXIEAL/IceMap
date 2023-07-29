using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Firestore;
using UnityEngine;

namespace IceMap.Firestore
{
    public abstract class FirestoreDatabase
    {
        protected string CollectionName;
        protected string DocumentName;
        
        private readonly FirestoreWriter _writer;
        private readonly FirestoreReader _reader;
        
        protected FirestoreDatabase(FirebaseFirestore db)
        {
            _writer = new FirestoreWriter(db);
            _reader = new FirestoreReader(db);
        }

        protected async void Write(string document, Dictionary<string, object> data)
        {
            if (IsNullOrEmptyLocalVar())
                return;
            
            await _writer.WriteAsync(document, data);
        }

        protected async void Write(Dictionary<string, object> data)
        {
            if (IsNullOrEmptyLocalVar())
                return;
            
            await _writer.WriteAsync(CollectionName, data);
        }

        protected async Task<Dictionary<string, object>> Read(string document)
        {
            if (IsNullOrEmptyLocalVar())
                return null;
            
            return await _reader.ReadAsync(CollectionName, document);
        }

        protected async Task<QuerySnapshot> Read()
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