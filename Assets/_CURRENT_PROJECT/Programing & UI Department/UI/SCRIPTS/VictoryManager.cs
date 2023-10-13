using Cinemachine;
using UnityEngine;

public class VictoryManager : MonoBehaviour
{
    public GameObject winnerFighter;
    public CinemachineVirtualCamera virtualCamera;
    public float rotationSpeed = 1f;  // Speed of rotation

    private bool isVictory = false;
    private float rotationAngle = 0f;  // Current angle of rotation

    private void Update()
    {
        // If victory has occurred, gradually rotate the camera around the winnerFighter
        if (isVictory)
        {
            // Increment the rotation angle based on speed and time
            rotationAngle += rotationSpeed * Time.deltaTime;
            // Calculate the new position of the camera
            float x = winnerFighter.transform.position.x + 10f * Mathf.Cos(rotationAngle);
            float z = winnerFighter.transform.position.z + 10f * Mathf.Sin(rotationAngle);
            // Update the position of the camera
            virtualCamera.transform.position = new Vector3(x, virtualCamera.transform.position.y, z);
            // Ensure the camera is looking at the winnerFighter
            virtualCamera.transform.LookAt(winnerFighter.transform);
        }
    }

    public void Victory()
    {
        // Set isVictory to true to start the rotation in the Update method
        isVictory = true;
    }
}
