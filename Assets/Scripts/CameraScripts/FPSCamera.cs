using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Filename : FPSCamera
 * 
 * Goal : Allows the player's camera to move freely in the world space with a FPS perspective
 * 
 * Requirements : Attach this script to the camera
 */


[RequireComponent(typeof(Camera))]
public class FPSCamera : MonoBehaviour
{
    private Camera controlCam;
     
   
    private float rotationSpeed = 2f;
    public float speed = 50;


    private Vector3 newRight;
    private Vector3 newForward;
    private Vector3 targetPos;


    
    void Start()
    {
        controlCam = GetComponent<Camera>();
        targetPos = transform.position;
        calculateVector();
    }

    
    void Update()
    {





        //Move Camera with WASD or arrows key
        userMovement();
        transform.position = Vector3.Lerp(transform.position, targetPos, 10 * Time.deltaTime);

        //Rotate Camera with Mouse's Right Click
        userRotation();
    }

    public void userMovement()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            targetPos += newForward * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            targetPos -= newForward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            targetPos -= newRight * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            targetPos += newRight * speed * Time.deltaTime;
        }

    }


    //Rotate instance of camera based on mouse movement
    public void userRotation()
    {
        if (Input.GetMouseButton(1))
        {
            float pitch = -Input.GetAxis("Mouse Y");
            float yaw = Input.GetAxis("Mouse X");
            transform.eulerAngles += rotationSpeed * new Vector3(Mathf.Clamp(pitch, -90, 90), yaw, 0);

            calculateVector();
        }

    }

    //Matrix multiplication to get the current forward vector and the current right vector
    public void calculateVector()
    {
        Vector3 forward = transform.eulerAngles;
        float z = Mathf.Cos(forward.y * Mathf.Deg2Rad) * Mathf.Cos(-forward.x * Mathf.Deg2Rad);
        float y = Mathf.Sin(-forward.x * Mathf.Deg2Rad);
        float x = Mathf.Sin(forward.y * Mathf.Deg2Rad) * Mathf.Cos(-forward.x * Mathf.Deg2Rad);
        newForward = new Vector3(x, y, z).normalized;
        newRight = Vector3.Cross(Vector3.up, newForward).normalized;
    }
}
