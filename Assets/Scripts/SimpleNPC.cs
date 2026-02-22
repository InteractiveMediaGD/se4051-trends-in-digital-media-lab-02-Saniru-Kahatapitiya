using UnityEngine;

public class SimpleNPC : MonoBehaviour
{
    [Header("References")]
    public Transform player;

    [Header("Behavior")]
    public float chaseDistance = 6f;
    public float moveSpeed = 2f;

    [Header("Debug")]
    public bool enableDebug = false;

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (enableDebug)
        {
            Debug.Log($"NPC distance to player: {distance:F2}");
        }

        if (distance <= chaseDistance)
        {
            // Look at player (only rotate on Y axis)
            Vector3 lookPos = new Vector3(player.position.x, transform.position.y, player.position.z);
            transform.LookAt(lookPos);

            // Move toward player
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }
}
