using UnityEngine;

namespace IceMap
{
    public class UIDBehaviour : MonoBehaviour
    {
        public string UID { get; set; }

        private void Start()
        {
            UID = "1a2b3c4e";
            DontDestroyOnLoad(gameObject);
        }
    }

}
