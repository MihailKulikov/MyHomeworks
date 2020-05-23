using UnityEngine;

public class FootstepSoundManager : MonoBehaviour
{
    private CharacterController controller;
    private AudioSource audioSource;
    
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        controller = GetComponent<CharacterController>();
    }
    
    private void Update()
    {
        if (!(controller.velocity.magnitude > 0) || !controller.isGrounded || audioSource.isPlaying) return;
        audioSource.volume = Random.Range(0.5f, 1f);
        audioSource.pitch = Random.Range(1.1f, 1.5f);
        audioSource.PlayDelayed(0.5f);
    }
}
