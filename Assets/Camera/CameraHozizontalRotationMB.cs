using UnityEngine;

public class CameraHozizontalRotationMB : MonoBehaviour
{
    public  float rotationSpeed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(2))
        {
            UpdateByMouseInput();
        }
            
    }

    void UpdateByMouseInput()
    {
                // Get mouse horizontal movement
        float mouseX = Input.GetAxis("Mouse X");

        // Calculate rotation around the Y axis (horizontal)
        float rotationAmount = mouseX * rotationSpeed;

        // Apply rotation to the pivot (this GameObject)
        transform.Rotate(Vector3.up, rotationAmount, Space.World);
    }

    
}
