using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    private static AudioSource audioSource;

    private static AudioClip enemyAppearanceSound;
    
    private void Start()
    {
        enemyAppearanceSound = Resources.Load<AudioClip>("enemyAppearance");
        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "enemyAppearance":
                audioSource.PlayOneShot(enemyAppearanceSound, 1f);
                break;
        }
    }
}
