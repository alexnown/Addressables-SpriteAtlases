# Addressables-SpriteAtlases
Testing sprite atlases with Addressables preview package 

## LoadAtlasesFromDifferentPlaces scene
Shows atlases loading time from different sources: Included in build, from Resources folder, Default/Custom addressables group.

## LoadingPrefabFromAddressables and LoadingPrefabFromResources scenes
These scenes shows memory leak after release instances.
Prefab with SpriteRenderer component loaded from addressables group or resources folder. Sprite packed to atlas, which loaded by Addressables.LoadAsset from group. After release object instance and reload scene (UnloadUnusedAssets) textures didnt unload from memory.
Forum thread: [Memory leak after release assets](https://forum.unity.com/threads/bug-memory-leak-after-release-assets.594532/)
