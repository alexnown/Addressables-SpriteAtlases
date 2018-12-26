using System.Collections.Generic;
using UnityEngine;

namespace alexnown.AddressablesAndAtlases
{
    public class InstantiatePrefabFromResources : MonoBehaviour, IInstantiateAndRelease
    {
        public string PathToPrefabInResources;
        private readonly List<GameObject> _instances = new List<GameObject>();
        public void Instantiate()
        {
            var prefab = Resources.Load<GameObject>(PathToPrefabInResources);
            if (prefab == null)
            {
                DebugLogger.Log($"Prefab not found by path {PathToPrefabInResources}");
                return;
            }
            var instance = Instantiate(prefab, 3 * Random.insideUnitCircle, Quaternion.identity);
            _instances.Add(instance);
            Resources.UnloadAsset(prefab);
        }

        public void Release()
        {
            foreach (var instance in _instances)
            {
                if (instance != null) Destroy(instance);
            }
            _instances.Clear();
        }

        private void OnDestroy() { Release(); }
    }
}
