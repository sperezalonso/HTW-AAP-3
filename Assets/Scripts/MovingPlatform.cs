using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
    
    [SerializeField] private float lerpXValue = 0.5f;
    [SerializeField] private float speed = 1f;
    
    private float newX;
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
        newPosition = new Vector3(newX, initialPosition.y, initialPosition.z);
        transform.position = newPosition;
    }
}
