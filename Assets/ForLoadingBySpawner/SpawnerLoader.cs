using UnityEngine;
using UnityEngine.AddressableAssets;

namespace alexnown.AddressablesAndAtlases
{
    public class SpawnerLoader : MonoBehaviour
    {
        public string PrefabAddress;

        private void Start()
        {
            DebugLogger.Log($"Loading prefab by addr = {PrefabAddress}", gameObject);
            Addressables.Instantiate<GameObject>(PrefabAddress).Completed += operation =>
            {
                DebugLogger.Log($"Object with addr = {PrefabAddress} instantiated {operation.Result != null}", gameObject);
            };
        }
    }
}