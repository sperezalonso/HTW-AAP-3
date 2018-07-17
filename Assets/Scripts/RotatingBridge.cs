using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingBridge : MonoBehaviour
{

    [SerializeField] private float waitTime = 8.0f;
    public float smoothing;
    private float timer = 0.0f;
    private bool rotate = true;
    private Quaternion newRotation;
    
	// Use this for initialization
	void Start ()
	{
	    newRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    timer += Time.deltaTime;
	    
	    if (timer > waitTime)
	    {
	        timer = 0;
	        newRotation *= Quaternion.AngleAxis(180f, Vector3.up);
	    }
	    transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, smoothing * Time.deltaTime);
	}
}
