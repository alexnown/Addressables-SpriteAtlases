using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace alexnown.AddressablesAndAtlases
{
    public class InstantiatePrefabByAddress : MonoBehaviour, IInstantiateAndRelease
    {
        public string PrefabAddresses;
        private readonly List<GameObject> _instantiatedGo = new List<GameObject>();

        public void Instantiate()
        {
            Addressables.Instantiate<GameObject>(PrefabAddresses, 3 * Random.insideUnitCircle, Quaternion.identity).Completed += operation =>
            {
                if (operation.Result == null)
                {
                    DebugLogger.Log($"Prefab not found by address {PrefabAddresses}");
                }
                else _instantiatedGo.Add(operation.Result);
            };
        }

        public void Release()
        {
            foreach (var instances in _instantiatedGo)
            {
                Addressables.ReleaseInstance(instances);
            }
            _instantiatedGo.Clear();
        }

        private void OnDestroy() { Release(); }
    }
}
