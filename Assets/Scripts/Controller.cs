using UnityEngine;

// Class to allow the character to move around once spawned
public class Controller : MonoBehaviour
{
    // Serializing private variables to make them visible and editable in the inspector (but still private to the class)
    // rather than making them public and thus accessible and editable by other classes

    // Variable to control the speed of the character
    [SerializeField] private float speed;

    // Variable to store the joystick object
    private FixedJoystick fixedJoystick;

    // Variable to store the rigidbody component of the character
    private Rigidbody rigidBody;

    // Get the joystick object and the rigidbody component of the character
    private void OnEnable()
    {
        fixedJoystick = FindFirstObjectByType<FixedJoystick>();
        rigidBody = gameObject.GetComponent<Rigidbody>();
    }

    // Move the character based on the joystick input
    private void FixedUpdate()
    {
        // Get the joystick x and y values
        float x = fixedJoystick.Horizontal;
        float y = fixedJoystick.Vertical;

        // Define the movement vector and move the character
        Vector3 movement = new Vector3(x, 0, y); // Character can only move in x & z, not y plane
        rigidBody.velocity = movement * speed; // Move the character in joystick direction at speed

        // Rotate the character to face the direction of movement
        if (x != 0 && y != 0)
        {
            // Rotate character around y axis, rotation in x & z axes remains unchanged
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(x, y) * Mathf.Rad2Deg, transform.eulerAngles.z);
        }
    }
}