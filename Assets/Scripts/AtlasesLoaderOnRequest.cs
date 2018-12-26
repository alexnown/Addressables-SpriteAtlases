using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.U2D;

namespace alexnown.AddressablesAndAtlases
{
    public class AtlasesLoaderOnRequest : MonoBehaviour
    {
        private void Start()
        {
            SpriteAtlasManager.atlasRequested += SpriteAtlasManager_atlasRequested;
            SpriteAtlasManager.atlasRegistered += SpriteAtlasManager_atlasRegistered;
        }

        private void SpriteAtlasManager_atlasRegistered(SpriteAtlas atlas)
        {
            DebugLogger.Log($"{atlas.name} atlas registered!");
        }

        private void SpriteAtlasManager_atlasRequested(string s, System.Action<SpriteAtlas> action)
        {
            DebugLogger.Log($"{s} atlas requested.");
            Addressables.LoadAsset<SpriteAtlas>(s).Completed += operation =>
            {
                DebugLogger.Log($"{s} atlas loaded {operation.Result != null}");
                if (operation.Result != null)
                {
                    action.Invoke(operation.Result);
                    //Addressables.ReleaseAsset(operation.Result);
                }
            };
        }

        private void OnDestroy()
        {
            SpriteAtlasManager.atlasRequested -= SpriteAtlasManager_atlasRequested;
            SpriteAtlasManager.atlasRegistered -= SpriteAtlasManager_atlasRegistered;
        }
    }
}
