using UnityEngine;

namespace alexnown.AddressablesAndAtlases
{
    public class Spawner : MonoBehaviour
    {
        public GameObject[] Prefabs;

        private void Start()
        {
            for (int i = 0; i < Prefabs.Length; i++)
            {
                var obj = Instantiate(Prefabs[i], 2 * Vector2.right +3 * Random.insideUnitCircle, Quaternion.identity);
                DebugLogger.Log($"{Prefabs[i].name} prefab instantiatedfrom spawner.", obj);
            }
        }
    }
}
