# Unity Addressable Asset Management

This Unity project demonstrates the use of Unity's Addressable Asset System to manage the loading and releasing of assets. The Addressable Asset System provides a powerful way to handle assets efficiently, especially when dealing with large projects or multiple platforms.

## Features

- **Load and Release Assets Dynamically**: This project showcases how to load assets asynchronously using the Addressables system and release them when they are no longer needed.
- **UI Integration**: Simple UI buttons are used to load and release an environment prefab in the scene.

## Project Structure

- **Scripts/AddressableManager.cs**: The main script that handles the loading and releasing of assets via UI buttons.

## Script Overview

### AddressableManager.cs

The `AddressableManager` script is responsible for managing the loading and releasing of a prefab asset using Unity's Addressable Asset System. 

#### Key Functions:

- **LoadAsset**: 
  - This method asynchronously loads a prefab from the Addressables system using the specified address.
  - Once the asset is loaded successfully, it is instantiated in the scene.
  - If the asset fails to load, an error message is logged.

- **ReleaseAsset**: 
  - This method releases the asset from memory and destroys the instantiated prefab if it exists.
  - Ensures efficient memory usage by cleaning up assets that are no longer in use.

#### Example Usage:

```csharp
[SerializeField] private Button loadAssetButton;
[SerializeField] private Button releaseAssetButton;
[SerializeField] private GameObject environmentPrefab;

private AsyncOperationHandle<GameObject> asyncOperationHandle;
```

## License

This project is licensed under the **MIT License**. For more details, please refer to the `LICENSE` file in the repository.


private void Awake()
{
    loadAssetButton.onClick.AddListener(LoadAsset);
    releaseAssetButton.onClick.AddListener(ReleaseAsset);
}
