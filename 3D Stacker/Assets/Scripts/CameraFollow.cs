using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float yOffset = 5f;
    public float zOffset = -10f;
    public float smoothSpeed = 2f;

    public float minDistance = -10f;     // Starting Z offset
    public float distancePerUnit = 0.2f; // How much farther back per block

    private float initialY;

    void Start()
    {
        initialY = transform.position.y;
    }

    void LateUpdate()
    {
        if (target == null) return;

        float targetY = target.position.y + yOffset;

        // Only move the camera upward
        float newY = Mathf.Max(initialY, targetY);

        // Move the camera backward slightly as tower grows
        float depthOffset = minDistance - (target.position.y * distancePerUnit);

        Vector3 desiredPosition = new Vector3(
            transform.position.x,
            newY,
            depthOffset
        );

        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
    }
}
