using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.U2D;
using UnityEngine.UI;

namespace alexnown.AddressablesAndAtlases
{
    public class Loader : MonoBehaviour
    {
        [SerializeField]
        private Text _debug;

        private static Loader _instance;
        private void Awake()
        {
            _instance = this;
            SpriteAtlasManager.atlasRequested += (s, action) =>
            {
                Log($"{Time.frameCount}: {s} atlas requested.");
                Addressables.LoadAsset<SpriteAtlas>(s).Completed += operation =>
                {
                    Log($"{Time.frameCount}: {s} atlas loaded {operation.Result != null}");
                    action.Invoke(operation.Result);
                };
            };
            SpriteAtlasManager.atlasRegistered += atlas =>
            {
                Log($"{Time.frameCount}: {atlas.name} atlas registered!");
            };
        }

        private void Start()
        {
            Addressables.Instantiate<GameObject>("Spawner").Completed += operation =>
            {
                Log($"{Time.frameCount}: Spawner loaded {operation.Result != null}");
            };
        }

        public static void Log(string msg)
        {
            Debug.Log(msg);
            _instance._debug.text += msg + "\n";
        }
    }
}

