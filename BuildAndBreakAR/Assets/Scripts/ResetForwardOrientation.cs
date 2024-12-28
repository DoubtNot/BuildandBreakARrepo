using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ResetForwardOrientation : MonoBehaviour
{
    public Transform playerRoot; // The root object of your player rig
    public float longPressDuration = 2.0f; // Duration to detect long press

    private bool isPressing = false;
    private float pressTimer = 0f;

    void Update()
    {
        // Get the Meta Button state
        bool isMetaButtonPressed = OVRInput.Get(OVRInput.RawButton.Start); // Adjust this for your specific input system

        if (isMetaButtonPressed)
        {
            if (!isPressing)
            {
                isPressing = true;
                pressTimer = 0f;
            }
            else
            {
                pressTimer += Time.deltaTime;

                if (pressTimer >= longPressDuration)
                {
                    ResetOrientation();
                    isPressing = false; // Reset the state
                }
            }
        }
        else if (isPressing)
        {
            isPressing = false; // Reset if the button is released before the duration
        }
    }

    private void ResetOrientation()
    {
        if (playerRoot == null)
        {
            Debug.LogWarning("Player root is not assigned!");
            return;
        }

        // Reset the forward orientation
        Vector3 forwardDirection = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z).normalized;
        playerRoot.forward = forwardDirection;
        Debug.Log("Player forward orientation reset.");
    }
}
