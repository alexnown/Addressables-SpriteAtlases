using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.U2D;

namespace alexnown.AddressablesAndAtlases
{
    public class AtlasesLoaderOnRequest : MonoBehaviour
    {
        private void Start()
        {
            SpriteAtlasManager.atlasRequested += (s, action) =>
            {
                DebugLogger.Log($"{s} atlas requested.");
                Addressables.LoadAsset<SpriteAtlas>(s).Completed += operation =>
                {
                    DebugLogger.Log($"{s} atlas loaded {operation.Result != null}");
                    action.Invoke(operation.Result);
                };
            };
            SpriteAtlasManager.atlasRegistered += atlas =>
            {
                DebugLogger.Log($"{atlas.name} atlas registered!");
            };
        }
    }
}
