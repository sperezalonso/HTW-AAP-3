using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditorInternal;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offsetPosition;
    [SerializeField] private bool mouseLook = false;
    public float lerpValue;
    public float mouseSensitivity = 100f;
    public float clampAngle = 60f;

    private float rotX = 0f;
    private float rotY = 0f;

    private Camera cam;
    private float currentX = 0f;
    private float currentY = 0f;
    
    void Start()
    {
        Vector3 rotation = transform.localRotation.eulerAngles;
        rotX = rotation.x;
        rotY = rotation.y;

        cam = Camera.main;
    }

    void Update()
    {
        float k = mouseSensitivity * Time.deltaTime;
        
        currentX += Input.GetAxis("Mouse X");
        currentY += Input.GetAxis("Mouse Y");

        // Clamp the Y rotation so the camera doesn't go too far up or down
        currentY = Mathf.Clamp(currentY, -clampAngle, clampAngle);
    }
	
    // Update is called once per frame
    void LateUpdate ()
    {
        if (player == null)
        {
            Debug.LogWarning("Missing target ref!", this);
            return;
        }
        
        Quaternion localRotation = Quaternion.Euler(currentY, currentX, 0f);
        
        // Mouse-controlled camera
        if (mouseLook)
        { 
            // Compute position   
            transform.position = player.position + localRotation * offsetPosition;
            
            // Compute rotation
            transform.LookAt(player.position);
        }
        
        // Fixed over-the-shoulder camera
        else
        {
            // Compute position
            transform.position = Vector3.Lerp(transform.position, player.TransformPoint(offsetPosition), lerpValue);
            
            // Compute rotation
            transform.rotation = player.rotation;
            
        }
    }
}