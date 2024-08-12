using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;

public class AddressableManager : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button loadAssetButton;
    [SerializeField] private Button releaseAssetButton;

    [Header("Asset References")]
    [SerializeField] private GameObject environmentPrefab;

    private AsyncOperationHandle<GameObject> asyncOperationHandle;

    private void Awake()
    {
        loadAssetButton.onClick.AddListener(LoadAsset);
        releaseAssetButton.onClick.AddListener(ReleaseAsset);
    }

    private void LoadAsset()
    {
        asyncOperationHandle = Addressables.LoadAssetAsync<GameObject>("Assets/Prefabs/Environment.prefab");
        asyncOperationHandle.Completed += (handle) =>
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                environmentPrefab = Instantiate(handle.Result);
            }
            else
            {
                Debug.LogError("Failed to load asset");
            }
        };
    }

    private void ReleaseAsset()
    {
        if (asyncOperationHandle.IsValid())
        {
            Addressables.Release(asyncOperationHandle);
            if (environmentPrefab != null)
            {
                Destroy(environmentPrefab);
            }
        }
    }
}
