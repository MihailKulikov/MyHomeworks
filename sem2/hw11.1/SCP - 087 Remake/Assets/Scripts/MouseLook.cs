using UnityEngine;

/// <summary>
/// Provides class which is responsible for the movement of the camera using the player’s mouse.
/// </summary>
public class MouseLook : MonoBehaviour
{
    /// <summary>
    /// Mouse sensitivity value. The larger the value, the faster the cursor moves.
    /// </summary>
    public float mouseSensitivity = 100f;
    /// <summary>
    /// Transform of player.
    /// </summary>
    public Transform playerBody;
    
    private float xRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    private void Update()
    {
        var mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        var mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
