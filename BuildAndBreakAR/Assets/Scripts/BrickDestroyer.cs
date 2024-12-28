using UnityEngine;

public class BrickDestroyer : MonoBehaviour
{
    // Function to destroy all objects with the tag "Brick"
    public void DestroyAllBricks()
    {
        // Find all objects with the tag "Brick"
        GameObject[] bricks = GameObject.FindGameObjectsWithTag("Brick");

        // Loop through the array and destroy each object and its parent if necessary
        foreach (GameObject brick in bricks)
        {
            Destroy(brick.transform.root.gameObject);
        }
    }

    // OnTriggerEnter is called when another collider enters the trigger zone
    private void OnTriggerEnter(Collider other)
    {
        DestroySingleBrick(other.gameObject);
    }

    // Function to destroy the root (most parent) object of a triggered brick
    private void DestroySingleBrick(GameObject brick)
    {
        // Check if the triggered object has the tag "Brick"
        if (brick.CompareTag("Brick"))
        {
            // Get the root object of the brick
            GameObject rootObject = brick.transform.root.gameObject;

            // Ensure the root object is the intended parent
            if (rootObject.CompareTag("Brick"))
            {
                // Destroy the root (most parent) object
                Destroy(rootObject);
                Debug.Log("Parent object of the brick destroyed.");
            }
        }
    }
}
