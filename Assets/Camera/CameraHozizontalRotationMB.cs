using Unity.VisualScripting;

using UnityEngine;

public class CameraHozizontalRotationMB : MonoBehaviour
{
    public  float rotationSpeed = 5f;
    private Vector3 initialPos;
    [SerializeField] private float camHeight = 2;
    [SerializeField] private float minPitch;
    [SerializeField] private float maxPitch;

    // Camera scroll stuff
    [SerializeField] private float scrollSpeed = 5f;
    [SerializeField] private float minZoom = -2f;
    [SerializeField] private float maxZoom = 20f;

    [SerializeField] private Transform cam;
    [SerializeField] private float camDistance;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialPos =transform.position;
        //camDistance = cam.localPosition.z * -1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(2))
        {
            UpdateByMouseInput();
        }

      cameraZoom();
            
    }

    void UpdateByMouseInput()
    {
         // Get mouse horizontal and vertical movement
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxisRaw("Mouse Y");
        
        float currPitch = transform.eulerAngles.x;
        float currYw = transform.eulerAngles.y;

        // Calculate rotation around the Y axis (horizontal)
        currYw += mouseX * rotationSpeed;
        currPitch -= mouseY * rotationSpeed;

        // Clamping yaw 
        currPitch = Mathf.Clamp(currPitch, minPitch, maxPitch);



        // Rotating
        transform.localRotation = Quaternion.Euler(currPitch, currYw, 0);




      

    }

    void cameraZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        camDistance -= scrollSpeed * scroll;
        camDistance = Mathf.Clamp(camDistance, minZoom, maxZoom);
  
        cam.localPosition = new Vector3 (transform.position.x ,camHeight,-camDistance);

    }

}
