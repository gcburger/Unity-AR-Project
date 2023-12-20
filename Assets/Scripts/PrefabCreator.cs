using UnityEngine;
using UnityEngine.XR.ARFoundation;

// Class to spawn a prefab once a tracked image is detected
public class PrefabCreator : MonoBehaviour
{
    // Serializing private variables to make them visible and editable in the inspector (but still private to the class)
    // rather than making them public and thus accessible and editable by other classes

    // The prefab to be spawned once a tracked image is detected
    [SerializeField] private GameObject characterPrefab;
    // The offset to be applied to the prefab's position once it is spawned
    [SerializeField] private Vector3 prefabOffset;

    // Variable to store the instantiated prefab
    private GameObject character;

    // The ARTrackedImageManager component (attached to the XR Origin game object) used to track images
    private ARTrackedImageManager aRTrackedImageManager;

    // Get the ARTrackedImageManager component and subscribe to the trackedImagesChanged event
    private void OnEnable()
    {
        aRTrackedImageManager = gameObject.GetComponent<ARTrackedImageManager>();

        aRTrackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    // When a tracked image is detected, instantiate the prefab and set its position to the tracked image's position
    private void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (ARTrackedImage image in args.added)
        {
            character = Instantiate(characterPrefab, image.transform);
            
            character.transform.position += prefabOffset;
        }
    }
}