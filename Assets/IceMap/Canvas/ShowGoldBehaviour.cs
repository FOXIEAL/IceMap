using IceMap.Firestore;
using TMPro;
using UnityEngine;

namespace IceMap.Canvas
{
    public class ShowGoldBehavior : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI goldText;

        private FirestoreBehaviour _firestoreBehaviour;
        private FirestoreManager _firestoreManager;
        private string _uid;

        private void Awake()
        {
            _firestoreBehaviour = FindObjectOfType<FirestoreBehaviour>();
        }

        private async void DelayEnable()
        {
            _firestoreManager = _firestoreBehaviour.Manager;

            var gold = await _firestoreManager.Golds.Get("test");
            Debug.Log(gold);
            goldText.text = gold.ToString();
        }

        // Update is called once per frame
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                DelayEnable();
            }
        }
    }

}
