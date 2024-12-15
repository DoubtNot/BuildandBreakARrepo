using UnityEngine;

public class ReturnToOriginalPosition : MonoBehaviour
{
    public Transform originalPosition;
    public Rigidbody rb; // Reference to the Rigidbody component

    private Vector3 initialPosition;
    private Quaternion initialRotation;

    private void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    public void ResetPosition()
    {
        // Reset to original position and rotation instantly
        transform.position = originalPosition.position;
        transform.rotation = originalPosition.rotation;

        // Freeze the movement by making the Rigidbody kinematic
        if (rb != null)
        {
            rb.isKinematic = true;
        }
    }
}
