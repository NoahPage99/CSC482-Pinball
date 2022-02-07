using UnityEngine;


public class BallController : MonoBehaviour
{

    public float speed;
    public AudioSource audioPlayer;
    public AudioClip bounceClip;
    public AudioClip ballRoller;
    // Create private references to the rigidbody component on the ball
    private Rigidbody rb;


    // At the start of the game..
    void Start()
    {
        // Assign the Rigidbody component to our private rb variable
        rb = GetComponent<Rigidbody>();

        audioPlayer = GetComponent<AudioSource>();
        audioPlayer.loop = true;
        audioPlayer.clip = ballRoller;
        audioPlayer.volume = 0.3f;
        audioPlayer.Play(); 
    }

    // Each physics step..
    void FixedUpdate()
    {
        
    }

    void OnCollisionEnter(Collision myCollision)
    {

        Debug.Log(myCollision.relativeVelocity.magnitude);
        //only generate collision sound on harder hits
        if (myCollision.relativeVelocity.magnitude > 20)
        {
            audioPlayer.PlayOneShot(bounceClip);
        }
    }
}