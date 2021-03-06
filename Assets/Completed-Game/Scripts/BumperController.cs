using UnityEngine;
using System.Collections;

public class BumperController : MonoBehaviour {

    public  int scoreIncrement = 100;
    
    public AudioSource bumperSound;
    public Material bumperOff;
    public Material bumperOn;
    private bool gpuNeeded;
    private GameObject ball;
    public AudioClip bumperClip;

    MeshRenderer renderer;

    public int hitCount = 0;
    bool bHitLight = false;
    float hitLightTimer = 0;
    int scoreMultiplier;
    

    private void Start()
    {
        renderer = gameObject.GetComponent<MeshRenderer>();
        bumperSound = GetComponent<AudioSource>();
        gpuNeeded = true;
        scoreMultiplier = 1;
        ball = GameObject.Find("Ball");
    }

    // Before rendering each frame..
    void Update () 
	{
        if(this.gameObject.tag == "coin"){
             //continuously rotates cuvbe
            transform.Rotate (new Vector3 (180, 0, 0) * Time.deltaTime);
        } else if(this.gameObject.tag != "Bump") {
    		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
        }

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

    private void NoPhysicsCollision(GameObject gameObject) {
        if (gameObject.tag == "Ball")
        {
            //bumperSound.PlayOneShot(bumperClip);

            if(this.gameObject.tag == "coin" && this.gameObject.GetComponent<MeshRenderer>().enabled){
                GameObject.Find("Pinball Table").GetComponent<PinballGame>().score = GameObject.Find("Pinball Table").GetComponent<PinballGame>().score + 50 *  GameObject.Find("Pinball Table").GetComponent<PinballGame>().scoreMultiplier;
                //this.gameObject.SetActive(false);
                this.gameObject.GetComponent<MeshRenderer>().enabled = false;
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
            } else if(this.gameObject.tag != "coin"){
                // computer part:

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
                    if(GameObject.Find("Pinball Table").GetComponent<PinballGame>().Gpuleft != 0)
                    {
                        GameObject.Find("Pinball Table").GetComponent<PinballGame>().Gpuleft = GameObject.Find("Pinball Table").GetComponent<PinballGame>().Gpuleft - 1;
                    }
                    else
                    {
                        scoreIncrement = -100 / scoreMultiplier;
                    }
            
                }

                if(this.gameObject.tag =="SuperGPU")
                {
                     if(GameObject.Find("Pinball Table").GetComponent<PinballGame>().Gpuleft != 0){
                        GameObject.Find("Pinball Table").GetComponent<PinballGame>().Gpuleft = GameObject.Find("Pinball Table").GetComponent<PinballGame>().Gpuleft - 1;
                        GameObject.Find("Pinball Table").GetComponent<PinballGame>().scoreMultiplier =  GameObject.Find("Pinball Table").GetComponent<PinballGame>().scoreMultiplier * 2;
                     }     
           
                }
                

                 if(this.gameObject.tag =="Case")
                {
                    GameObject.Find("Pinball Table").GetComponent<PinballGame>().CaseLeft = GameObject.Find("Pinball Table").GetComponent<PinballGame>().CaseLeft - 1;
           
                }

                GameObject.Find("Pinball Table").GetComponent<PinballGame>().score = GameObject.Find("Pinball Table").GetComponent<PinballGame>().score + scoreIncrement *  GameObject.Find("Pinball Table").GetComponent<PinballGame>().scoreMultiplier;

                
                this.gameObject.GetComponent<MeshRenderer>().enabled = false;
                this.gameObject.GetComponent<BoxCollider>().enabled = false;

            }
        }
    }

    // Collision Trigger for bumpers with no physics collision (Coins, parts)
    void OnTriggerEnter(Collider other) {
        this.NoPhysicsCollision(other.gameObject);
    }

    // Collision Trigger for bumpers with physics collision (bumpers)
    void OnCollisionEnter(Collision myCollision)
    {
         
        if (myCollision.gameObject.tag == "Ball")
        {
            

            // each time bumper is hit, hitCount increases by one
            hitCount = hitCount + 1;
            //if bumper gets hit 3 times, it disappears (gets set inactive and isn't displayed in scene anymore)

            //myCollision.gameObject.GetComponent<MeshRenderer>().enabled = false;
           
            
            //bumperSound.PlayOneShot(bumperClip);
            
            
            
             if(this.gameObject.tag =="Bump")
            {
                
                Rigidbody rb = ball.GetComponent<Rigidbody>();
                //rb.AddExplosionForce(800, transform.position,1);

                Vector3 noY = new Vector3(1,0,1);
                Vector3 direction = Vector3.Scale((rb.transform.position - this.gameObject.transform.position) , noY).normalized;
                rb.AddForce(direction * 2000);
       
            }

            //adds bumper score to the score talley being summed in the PinballGame script
 
            if (this.gameObject.tag == "Bump")
            {
                GameObject.Find("Pinball Table").GetComponent<PinballGame>().score = GameObject.Find("Pinball Table").GetComponent<PinballGame>().score + scoreIncrement *  GameObject.Find("Pinball Table").GetComponent<PinballGame>().scoreMultiplier;
            }

 
            //trigger hit light (change material assigned to bumper object, so bumper "lights up"), reset hitlight timer 
            bHitLight = true;
            hitLightTimer = 0;
        }
    }
}	