using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f; // Adjust this value to set the speed of the car movement
    [SerializeField] private float rotationSpeed = 50f; // Adjust this value to set the speed of the car rotation
    [SerializeField] private float brakeStrength = 50f; // Adjust this value to set the strength of the brake

    private Rigidbody carRigidbody;

    private void Awake()
    {
        carRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // Get input from left and right arrow keys
        float verticalInput = Input.GetAxis("Vertical"); // Get input from up and down arrow keys

        if (verticalInput > 0f) // Only move forward if the player is pressing the up arrow key
        {
            Vector3 movement = new Vector3(0f, 0f, verticalInput) * moveSpeed; // Create movement vector based on input
            carRigidbody.AddRelativeForce(movement); // Apply movement to car
        }
        else if (verticalInput < 0f) // If player is pressing the down arrow key, apply the brake
        {
            float brakeForce = Mathf.Abs(verticalInput) * brakeStrength; // Calculate the strength of the brake based on input
            carRigidbody.AddRelativeForce(Vector3.back * brakeForce); // Apply brake force to car
        }

        float rotation = horizontalInput * rotationSpeed * Time.deltaTime; // Calculate rotation based on input
        transform.Rotate(0f, rotation, 0f); // Rotate car based on input

        if (carRigidbody.velocity.magnitude > 0f && verticalInput < 0f) // If the car is moving and the brake is applied, allow for drifting
        {
            float driftForce = Mathf.Abs(horizontalInput) * moveSpeed / 2f; // Calculate the strength of the drift based on input
            Vector3 driftDirection = -carRigidbody.velocity.normalized; // Calculate the direction of the drift
            carRigidbody.AddForce(driftDirection * driftForce); // Apply drift force to car
        }
    }
}
