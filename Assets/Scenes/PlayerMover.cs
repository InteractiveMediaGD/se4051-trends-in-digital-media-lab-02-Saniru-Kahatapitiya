using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMover : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;

    [Header("Debug")]
    public bool enableDebug = false;

    private Rigidbody rb;

    void Awake()
    {
        // Get the Rigidbody and freeze rotations to prevent the capsule from falling over
        rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.freezeRotation = true;
            // Also ensure it's not using gravity to drift or falls through ground if not set up
            // However, usually we want gravity for ground detection, so just freeze rotation.
        }
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal"); // A/D or Left/Right
        float v = Input.GetAxis("Vertical");   // W/S or Up/Down

        Vector3 move = new Vector3(h, 0f, v) * moveSpeed * Time.deltaTime;
        transform.Translate(move, Space.World);

        if (enableDebug && (Mathf.Abs(h) > 0.01f || Mathf.Abs(v) > 0.01f))
        {
            Debug.Log($"Player position: {transform.position}");
        }
    }
}
