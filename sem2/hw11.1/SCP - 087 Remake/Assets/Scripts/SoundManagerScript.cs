using UnityEngine;

/// <summary>
/// Represents sound manager. Provides methods to play music from resources file.
/// </summary>
public class SoundManagerScript : MonoBehaviour
{
    private static AudioSource audioSource;

    private static AudioClip enemyAppearanceSound;
    
    private void Start()
    {
        enemyAppearanceSound = Resources.Load<AudioClip>("enemyAppearance");
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Play audio with specified name.
    /// </summary>
    /// <param name="clipName">Name of the audio.</param>
    public static void PlaySound(string clipName)
    {
        switch (clipName)
        {
            case "enemyAppearance":
                audioSource.PlayOneShot(enemyAppearanceSound, 1f);
                break;
        }
    }
}
