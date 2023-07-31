using IceMap.Firestore;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace IceMap.OnClick
{
    public class SpotPost : MonoBehaviour
    {
        [SerializeField] private TMP_InputField titleInput;
        [SerializeField] private TMP_InputField contentInput;
        [SerializeField] private Button postButton;
        
        private FirestoreBehaviour _firestoreBehaviour;
        private UIDBehaviour _uidBehaviour;
        private GPS _gpsTest;
        private FirestoreManager _firestoreManager;
        
        
        private void Awake()
        {
            _firestoreBehaviour = FindObjectOfType<FirestoreBehaviour>();
            _uidBehaviour = FindObjectOfType<UIDBehaviour>();
            _gpsTest = FindObjectOfType<GPS>();
        }
        
        private void Start()
        {
            postButton.onClick.AddListener(OnClick);
        }

        private void OnEnable()
        {
            _firestoreManager = _firestoreBehaviour.Manager;
        }

        private void OnClick()
        {
            _firestoreManager.SpotPosts.Create(
                _uidBehaviour.UID,
                _gpsTest.longitude,
                _gpsTest.latitude,
                titleInput.text,
                contentInput.text
            );
        }
    }
}