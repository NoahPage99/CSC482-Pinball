using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedboost : MonoBehaviour
{

    public float addedSpeed = 100;
    private GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.Find("Ball");
    }

    void OnCollisionEnter(Collision myCollision)
    {
        if(myCollision.gameObject.tag == "Ball"){
            if (this.gameObject.tag == "speed"){
                Rigidbody rb = ball.GetComponent<Rigidbody>();
                Vector3 movement = new Vector3(0.0f, 0.0f, 1.0f);
                rb.AddForce(movement * addedSpeed);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
