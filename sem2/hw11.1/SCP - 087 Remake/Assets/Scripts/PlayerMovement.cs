using System;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

/// <summary>
/// Represents class which is responsible for the movement of player using keyboard.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public float gravity = 9.81f;
    public float jumpHeight = 4f;
    public float heightOfStairs = 11f;
    public float teleportDescendingPoint = -25f;
    public float teleportRaisingPoint = -8.26f;
    public GameObject enemy;
    public Vector3 scaleOfEnemy = new Vector3(3,3 ,3 );
    public float distanceBetweenPlayer = 3.5f;
    public int enemyAppearancePercentage;
    public GameObject endOfGameMenu;
    
    private CharacterController controller;
    private Vector3 velocity;
    private float depth;
    private Vector3 teleportVec;
    private GameObject lastHittedGameObject;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        
        var args = Environment.GetCommandLineArgs();
        foreach (var arg in args)
        {
            if (!int.TryParse(arg, out enemyAppearancePercentage))
            {
                enemyAppearancePercentage = 10;
            }
        }
    }

    private void Update()
    {
        var xMovement = Input.GetAxis("Horizontal");
        var zMovement = Input.GetAxis("Vertical");

        if (controller.isGrounded)
        {
            velocity = Vector3.zero;
        }

        if (Input.GetButton("Jump") && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * 2f * gravity);
        }

        velocity.y -= gravity * Time.deltaTime;
        var transformOfCurrentGameObject = transform;
        var movement = zMovement * transformOfCurrentGameObject.forward + xMovement * transformOfCurrentGameObject.right;
        controller.Move((movement * speed + velocity) * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        if (transform.position.y >= teleportRaisingPoint && depth > 0)
        {
            depth--;
            transform.position -= new Vector3(0,heightOfStairs, 0 );
        }

        if (!(transform.position.y <= teleportDescendingPoint)) return;
        depth++;
        transform.position += new Vector3(0,heightOfStairs, 0 );
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (!hit.gameObject.CompareTag("Plate")) return;
        if (hit.gameObject == lastHittedGameObject) return;
        if (Random.Range(0, 100) <= enemyAppearancePercentage)
        {
            CreateEnemy();
        }

        lastHittedGameObject = hit.gameObject;
    }

    private void CreateEnemy()
    {
        SoundManagerScript.PlaySound("enemyAppearance");
        endOfGameMenu.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
        var transformOfCurrentGameObject = controller.transform;
        var enemyRotation = transformOfCurrentGameObject.rotation.eulerAngles + new Vector3(0, 180, 0);
        var enemyGameObject = Instantiate(enemy,
            transform.position + distanceBetweenPlayer * transformOfCurrentGameObject.forward -
            new Vector3(0, transformOfCurrentGameObject.localScale.y, 0), Quaternion.Euler(enemyRotation));
        enemyGameObject.transform.localScale = scaleOfEnemy;
    }
}