using UnityEngine;

// Group under the GameManagers namespace, and to not pollute the global namespace
namespace GameManagers
{
    // Class to manage the audio in the game
    public class AudioManager : MonoBehaviour
    {
        // Static (won't change) reference to the singleton AudioManager instance
        public static AudioManager Instance;

        // Array to store the sound effects
        public AudioClip[] soundEffects;
        private AudioSource audioSource;

        // Function to play a sound effect
        private void Awake()
        {
            // Singleton design pattern: only one instance of the AudioManager can exist at any time

            // If the singleton instance has not been set, set it to this instance
            if (Instance == null)
            {
                // Keep the gameObject this component is attached to, across different scenes
                DontDestroyOnLoad(gameObject);
                Instance = this;
            }
            // If the singleton instance has already been set to another instance, destroy this instance
            else if (Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            // Get the AudioSource component
            audioSource = GetComponent<AudioSource>();
        }

        // Find a sound effect by name
        private AudioClip FindClipByName(string clipName)
        {
            // Loop through the sound effects array
            foreach (AudioClip clip in soundEffects)
            {
                // If the clip name matches the clip name passed in, return the clip
                if (clip.name.Equals(clipName))
                {
                    return clip;
                }
            }

            // If no clip is found, return null
            return null;
        }

        // Play a sound effect by name
        public void PlaySoundEffect(string clipName)
        {
            // Find the clip by name
            AudioClip clip = FindClipByName(clipName);

            // If the clip is found, play it
            if (clip != null)
            {
                audioSource.PlayOneShot(clip);
            }
            else
            {
                Debug.LogWarning("Sound effect not found: " + clipName);
            }
        }
    }
}