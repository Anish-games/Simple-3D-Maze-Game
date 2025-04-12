using UnityEngine;

public class BallControl : MonoBehaviour
{
    Rigidbody rb;
    [Range(0.2f, 10f)]
    public float moveSpeedModifier = 0.5f; // Default sensitivity
    public CountdownTimer countdownTimer; // Reference to CountdownTimer script
    public GameManager gameManager; // Reference to GameManager script
    float dirX, dirY;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Calculate movement direction based on keyboard and device acceleration input
        float accelX = Input.acceleration.x * moveSpeedModifier;
        float accelY = Input.acceleration.y * moveSpeedModifier;

        float keyX = Input.GetAxis("Horizontal") * moveSpeedModifier;
        float keyY = Input.GetAxis("Vertical") * moveSpeedModifier;

        dirX = accelX + keyX;
        dirY = accelY + keyY;
    }

    private void FixedUpdate()
    {
        // Apply force to move the ball
        rb.AddForce(new Vector3(-dirX, 0, -dirY), ForceMode.Acceleration);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "flag")
        {
            Debug.Log("Player reached the flag!");
            gameManager.PlayerWins(); // Notify GameManager about the win
        }
        else if (other.gameObject.tag == "obstacles")
        {
            Debug.Log("Player hit an obstacle!");
            countdownTimer.ReduceTime(3f); // Reduce time on collision
            other.gameObject.SetActive(false); // Deactivate the obstacle
        }
    }
}