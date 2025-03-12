using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform target; // The player to follow
    public float smoothSpeed = 0.125f; // How smoothly the camera follows
    public Vector3 offset; // Offset from the target position

    void LateUpdate()
    {
        if (target == null)
            return;

        // Desired position based on target position and offset
        Vector3 desiredPosition = target.position + offset;
        
        // Smoothly interpolate between current and desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        
        // Apply the smoothed position to the camera
        transform.position = smoothedPosition;
    }
} 