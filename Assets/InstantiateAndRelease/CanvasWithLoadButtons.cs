using UnityEngine;
using UnityEngine.SceneManagement;

namespace alexnown.AddressablesAndAtlases
{
    public interface IInstantiateAndRelease
    {
        void Instantiate();
        void Release();
    }
    
    public class CanvasWithLoadButtons : MonoBehaviour
    {
        public void InstantiateClick()
        {
            var components = gameObject.GetComponents<IInstantiateAndRelease>();
            foreach (var component in components)
            {
                component.Instantiate();
            }
        }

        public void ReleaseClick()
        {
            var components = gameObject.GetComponents<IInstantiateAndRelease>();
            foreach (var component in components)
            {
                component.Release();
            }
        }

        public void ReloadSceneClick()
        {
            Resources.UnloadUnusedAssets();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
