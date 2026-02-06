using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float forwardSpeed = 5f;

    public float laneOffset = 2f;

    public float laneChangeSpeed = 10f;

    [Header("Game State")]
    public GameManager gameManager;

    private int currentLane = 1;
    private bool isDead;
    private Vector3 targetPosition;

    private void Start()
    {
        currentLane = 1;
        targetPosition = transform.position;
    }

    private void Update()
    {
        if (isDead) return;

        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime, Space.World);

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLane(-1);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveLane(1);
        }

        Vector3 desired = new Vector3(GetLaneXPosition(), transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, desired, laneChangeSpeed * Time.deltaTime);
    }

    private void MoveLane(int direction)
    {
        currentLane = Mathf.Clamp(currentLane + direction, 0, 2);
    }

    private float GetLaneXPosition()
    {
        return (currentLane - 1) * laneOffset;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isDead) return;

        if (other.CompareTag("Obstacle"))
        {
            isDead = true;
            forwardSpeed = 0f;
            gameManager.OnPlayerDied();
        }
    }

    public void ResetPlayer()
    {
        isDead = false;
        forwardSpeed = 5f; // مقدار پیش‌فرض
        currentLane = 1;
        transform.position = new Vector3(0, transform.position.y, 0);
    }
}

