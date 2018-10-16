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
                Instantiate(Prefabs[i], 3 * Random.insideUnitCircle, Quaternion.identity);
                Loader.Log($"{Time.frameCount}: {Prefabs[i].name} prefab instantiated.");
            }
        }
    }
}
