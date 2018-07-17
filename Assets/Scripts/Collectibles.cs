using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.U2D;
using UnityEngine;
using UnityEngine.Timeline;

public class Collectibles : MonoBehaviour
{
    private float speed;
    
    // Use this for initialization
    void Start ()
    {
        speed = Random.Range(6, 15);
    }
	
    // Update is called once per frame
    void Update()
    {

        if (transform.tag == "Coin")
        {
            transform.Rotate(0f, 0f, 110f * Time.deltaTime);
        }
        if (transform.tag == "Gem")
        {
            transform.Rotate(new Vector3(speed, speed * 2, speed * 3) * Time.deltaTime); // Randomly rotate the object
        }
    }

//    void OnTriggerEnter(Collider collider)
//    {
//        Debug.Log("Working");
//        if (collider.tag == "Player")
//        {
//            Destroy(this.gameObject);
//        }
//    }
}