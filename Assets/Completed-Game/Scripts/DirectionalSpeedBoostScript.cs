using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalSpeedBoostScript : MonoBehaviour
{

    public float addedSpeed = 1000;
    public Vector3 direction = new Vector3(0.0f, 0.0f, 1.0f);

    private GameObject ball;
    
    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.Find("Ball");
        //ball.SetActive(false);
    }

    void OnCollisionEnter(Collision myCollision)
    {
        if(myCollision.gameObject.tag == "Ball") {
            if (this.gameObject.tag == "directionalSpeed"){
                Rigidbody rb = ball.GetComponent<Rigidbody>();
                rb.AddForce(direction * addedSpeed);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
