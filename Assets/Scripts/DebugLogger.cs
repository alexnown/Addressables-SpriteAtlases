using UnityEngine;
using UnityEngine.UI;

namespace alexnown.AddressablesAndAtlases
{
    public class DebugLogger : MonoBehaviour
    {
        [SerializeField]
        private Text _debug;

        private static DebugLogger _instance;
        private void Awake()
        {
            _instance = this;
        }

        public static void Log(string msg, GameObject go = null)
        {
            string finalMsg = $"{Time.frameCount} frame: {msg}";
            Debug.Log(finalMsg, go);
            if (_instance != null) _instance._debug.text += finalMsg + "\n";
        }
    }
}

