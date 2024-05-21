using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public float sensitivity;

    //private Vector3 offset;
    //private Rigidbody rb;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
       
        Cursor.visible = false;

    }
    private void Update()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Rotate the camera based on mouse input
        transform.Rotate(Vector3.up * mouseX * sensitivity);
        transform.Rotate(Vector3.left * mouseY * sensitivity);

        // Ensure the camera doesn't flip upside down
        float xRotation = transform.eulerAngles.x;
        if (xRotation > 180f)
        {
            xRotation -= 360f;
        }

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Apply the new rotation
        transform.eulerAngles = new Vector3(xRotation, transform.eulerAngles.y, 0f);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

    }

}

