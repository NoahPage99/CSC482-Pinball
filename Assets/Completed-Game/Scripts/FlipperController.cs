using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperController : MonoBehaviour
{

    public float restPosition = 0f;
    public float pressedPosition = 45f;
    public float hitStrength = 20000f;
    public float flipperDamper = 100f;
    public KeyCode inputKey;

    public AudioSource audioPlayer;
    public AudioClip flipClip;

    private bool playingSound = false;
    private bool pressed = false;

    HingeJoint hinge;


    // IEnumerator playFlipSound() {
    //     if (!playingSound) {
    //         playingSound = true;
    //         audioPlayer.PlayOneShot(flipClip);
    //         yield return new WaitForSeconds(0.1f);
    //         playingSound = false;
    //     }
    // }


    void Awake()
    {
    }


    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        hinge.useSpring = true;

        audioPlayer = GetComponent<AudioSource>();
        // audioPlayer.loop = true;
        // //audioPlayer.clip = flipClip;
        // audioPlayer.volume = 0.3f;
        // audioPlayer.Play(); 
    }

    // Update is called once per frame
    void Update()
    {
        JointSpring spring = new JointSpring();
        spring.spring = hitStrength;
        spring.damper = flipperDamper;

        if (Input.GetKey(inputKey) == true)
        {
            spring.targetPosition = pressedPosition;
            if (!pressed){
                audioPlayer.PlayOneShot(flipClip);
            }
            pressed = true;
        }
        else
        {
            spring.targetPosition = restPosition;
            pressed = false;
        }
        hinge.spring = spring;
        hinge.useLimits = true;
    }

    void FixedUpdate()
    {

    }
}
