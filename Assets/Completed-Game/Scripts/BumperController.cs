﻿using UnityEngine;
using System.Collections;

public class BumperController : MonoBehaviour {

    public  int scoreIncrement = 100;
    
    public AudioSource bumperSound;
    public Material bumperOff;
    public Material bumperOn;

    MeshRenderer renderer;

    public int hitCount = 0;
    bool bHitLight = false;
    float hitLightTimer = 0;
    

    private void Start()
    {
        renderer = gameObject.GetComponent<MeshRenderer>();
        bumperSound = GetComponent<AudioSource>();
    }

    // Before rendering each frame..
    void Update () 
	{
         //continuously rotates cuvbe
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);

        // assign material depending on whether bumper hit or not
        Material[] materials = renderer.materials;
        if ((bHitLight)&&(hitLightTimer<5))
        {
            materials[0] = bumperOn;
            hitLightTimer = hitLightTimer + 1;
        }
        else {
            materials[0] = bumperOff;
            bHitLight = false;
        };
        //renderer.materials = materials;
    }


    void OnCollisionEnter(Collision myCollision)
    {
        if (myCollision.gameObject.tag == "Ball")
        {
            // each time bumper is hit, hitCount increases by one
            hitCount = hitCount + 1;
            //if bumper gets hit 3 times, it disappears (gets set inactive and isn't displayed in scene anymore)

            //myCollision.gameObject.GetComponent<MeshRenderer>().enabled = false;
            if (hitCount == 1)
            {
                this.gameObject.SetActive(false);
                this.gameObject.GetComponent<MeshRenderer>().enabled = false;
                //this.gameObject.GetComponent<BoxCollider>().enabled = false;

                //GameObject.Find("Cylinder").GetComponent<MeshRenderer>().enabled = true;
                //GameObject.Find("Cylinder").transform.position = this.gameObject.transform.position;

            }
            //trigger hit light (change material assigned to bumper object, so bumper "lights up"), reset hitlight timer 
            bHitLight = true;
            hitLightTimer = 0;

            bumperSound.Play();

            if(this.gameObject.tag =="SSD")
            {
                GameObject.Find("Pinball Table").GetComponent<PinballGame>().SSDLeft = GameObject.Find("Pinball Table").GetComponent<PinballGame>().SSDLeft - 1;
       
            }
             if(this.gameObject.tag =="CPU")
            {
                GameObject.Find("Pinball Table").GetComponent<PinballGame>().CPUleft = GameObject.Find("Pinball Table").GetComponent<PinballGame>().CPUleft - 1;
       
            }
             if(this.gameObject.tag =="MotherBoard")
            {
                GameObject.Find("Pinball Table").GetComponent<PinballGame>().MotherboardLeft = GameObject.Find("Pinball Table").GetComponent<PinballGame>().MotherboardLeft - 1;
       
            }
             if(this.gameObject.tag =="PowerSupply")
            {
                GameObject.Find("Pinball Table").GetComponent<PinballGame>().PowerSupplyLeft = GameObject.Find("Pinball Table").GetComponent<PinballGame>().PowerSupplyLeft - 1;
       
            }
             if(this.gameObject.tag =="Ram")
            {
                GameObject.Find("Pinball Table").GetComponent<PinballGame>().RamLeft = GameObject.Find("Pinball Table").GetComponent<PinballGame>().RamLeft - 1;
       
            }

             if(this.gameObject.tag =="Hard Drive")
            {
                GameObject.Find("Pinball Table").GetComponent<PinballGame>().HardDriveleft = GameObject.Find("Pinball Table").GetComponent<PinballGame>().HardDriveleft - 1;
       
            }

             if(this.gameObject.tag =="GPU")
            {
                GameObject.Find("Pinball Table").GetComponent<PinballGame>().Gpuleft = GameObject.Find("Pinball Table").GetComponent<PinballGame>().Gpuleft - 1;
       
            }

             if(this.gameObject.tag =="Case")
            {
                GameObject.Find("Pinball Table").GetComponent<PinballGame>().CaseLeft = GameObject.Find("Pinball Table").GetComponent<PinballGame>().CaseLeft - 1;
       
            }

            //adds bumper score to the score talley being summed in the PinballGame script
            GameObject.Find("Pinball Table").GetComponent<PinballGame>().score = GameObject.Find("Pinball Table").GetComponent<PinballGame>().score + scoreIncrement;
        }
    }
}	