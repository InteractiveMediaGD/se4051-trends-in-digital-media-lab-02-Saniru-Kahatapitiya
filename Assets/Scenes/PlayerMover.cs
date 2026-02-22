using UnityEngine;
using UnityEngine.InputSystem;

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
        }
    }

    void Update()
    {
        float h = 0f;
        float v = 0f;

        // Using the New Input System to get WASD and Arrow key input
        if (Keyboard.current != null)
        {
            if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) v += 1;
            if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) v -= 1;
            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) h -= 1;
            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) h += 1;
        }

        // Normalize move vector so moving diagonally isn't faster
        Vector3 direction = new Vector3(h, 0f, v);
        if (direction.magnitude > 1) direction.Normalize();

        Vector3 move = direction * moveSpeed * Time.deltaTime;
        transform.Translate(move, Space.World);

        if (enableDebug && (Mathf.Abs(h) > 0.01f || Mathf.Abs(v) > 0.01f))
        {
            Debug.Log($"Player position: {transform.position}");
        }
    }
}

