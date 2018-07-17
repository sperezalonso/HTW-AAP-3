using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FloatingPipe : MonoBehaviour
{

    [SerializeField] private float lerpXValue = 0.2f;
    [SerializeField] private float lerpYValue = 0.2f;
    [SerializeField] private float speed = 1f;
    [SerializeField] private bool hoverInXAxis;
    [SerializeField] private bool hoverInYAxis;
    
    private float newX, newY;
    private Vector3 initialPosition;
    private Vector3 newPosition;
    private Vector3 curPos;        // current position

    
    // Use this for initialization
    void Start ()
    {
        initialPosition = transform.position;
    }
	
    // Update is called once per frame
    void Update ()
    {
        newX = initialPosition.x + lerpXValue * Mathf.Sin(speed * Time.time);
        newY = initialPosition.y + lerpYValue * Mathf.Sin(speed * Time.time);
        
        if (!hoverInXAxis & hoverInYAxis) // only Y axis
            newPosition = new Vector3(initialPosition.x, newY, initialPosition.z);
        
        if (hoverInXAxis & !hoverInYAxis) // only X axis
            newPosition = new Vector3(newX, initialPosition.y, initialPosition.z);
        
        if (hoverInXAxis & hoverInYAxis)  // both X & Y axis
            newPosition = new Vector3(newX, newY, initialPosition.z);
            
        transform.position = newPosition;
    }

}
