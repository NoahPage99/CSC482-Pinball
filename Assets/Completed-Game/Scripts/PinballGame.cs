using UnityEngine;

// Include the namespace required to use Unity UI
using UnityEngine.UI;

public class PinballGame : MonoBehaviour
{

    public Text scoreText;
    public Text highScoreText;
    public Text winText;
    public Text ballsText;
    public Text CPU;
    public Text Motherboard;
    public Text Ram;
    public Text SSD;
    public Text HardDrive;
    public Text GPU;
    public Text Case;
    public Text PowerSupply;
    public Text Multiplier;

    public int maxBalls = 3;
    public int score = 0;
    private int highscore = 0;
    public int CPUleft = 1;
    public int MotherboardLeft = 1;
    public int RamLeft = 1;
    public int SSDLeft = 1;
    public int HardDriveleft = 1;
    public int Gpuleft = 1;
    public int CaseLeft = 1;
    public int PowerSupplyLeft = 1;
    public int scoreMultiplier = 1;

    public float plungerSpeed = 100;

    public AudioSource audioPlayer;
    public AudioClip plungerClip;
    public AudioClip soundtrackClip;
    public AudioClip gameoverClip;
    public AudioClip ballLostClip;

    public KeyCode newGameKey;
    public KeyCode plungerKey;
    public KeyCode puzzlecameraKey;


    private int ballsLeft = 3;
    private bool gameOver = false;
    private GameObject ball;
    private GameObject plunger;
    private GameObject drain;

    private GameObject maincam;
    private GameObject puzzleCamera;
    

    // At the start of the game..
    void Start()
    {
        plunger = GameObject.Find("Plunger");
        drain = GameObject.Find("Drain");
        ball = GameObject.Find("Ball");
        maincam = GameObject.FindGameObjectWithTag("MainCamera");
        puzzleCamera = GameObject.Find("PuzzleCamera");

        puzzleCamera.SetActive(false);

        ball.SetActive(false);

        audioPlayer = GetComponent<AudioSource>();

        audioPlayer.loop = true;
        audioPlayer.clip = soundtrackClip;
        audioPlayer.volume = 0.3f;
        audioPlayer.Play(); 
    }

    private int partChecker()
    {
        int temp = CPUleft + MotherboardLeft + RamLeft + SSDLeft + HardDriveleft + Gpuleft + CaseLeft + PowerSupplyLeft;
        return temp; 
    }

    private void Update()
    {

        if (Input.GetKey(newGameKey) == true) NewGame();
        if (Input.GetKey(plungerKey) == true) Plunger();
        if (Input.GetKey(puzzlecameraKey) == true) switchCamera();

        // detect ball going past flippers into "drain"
        if ((ball.activeSelf == true) && (ball.transform.position.z < drain.transform.position.z))
        {
            audioPlayer.PlayOneShot(ballLostClip);
            ball.SetActive(false);
        }

        if ((ball.activeSelf == false) && (ballsLeft == 0))
        {
            if (gameOver == false)
            {
                gameOver = true;
                audioPlayer.PlayOneShot(gameoverClip);
            }
        }

        SetText();
    }

    // Each physics step..
    void FixedUpdate()
    {

    }

    // Create a standalone function that can update the 'countText' UI and check if the required amount to win has been achieved
    void SetText()
    {
        // Update the text field of our 'countText' variable
        scoreText.text = score.ToString();

        ballsText.text = ballsLeft.ToString();

        CPU.text = "CPU: " + CPUleft.ToString();

        Motherboard.text = "MotherBoard: " + MotherboardLeft.ToString();

        Ram.text = "Ram: " + RamLeft.ToString();

        SSD.text = "SSD: " +  SSDLeft.ToString();

        HardDrive.text = "Hard Drive: " + HardDriveleft.ToString();

        GPU.text = "GPU: " + Gpuleft.ToString();

        Case.text = "Case: " + CaseLeft.ToString();

        PowerSupply.text = "Power Supply: " + PowerSupplyLeft.ToString(); 

        Multiplier.text = scoreMultiplier.ToString();



        // private int CPUleft = 0;
        // private int MotherboardLeft = 0;
        // private int RamLeft = 0;
        // private int SSDLeft = 0;
        // private int HardDriveleft = 0;
        // private int Gpuleft = 0;
        // private int GPULeft = 0;
        // private int PowerSupplyLeft = 0;

        // Check if our 'count' is equal to or exceeded 12
        if (gameOver) winText.text = "Game Over";
        else if (partChecker() == 0) winText.text = "You Win";
        else winText.text = "";

        if (score > highscore) highscore = score;
        highScoreText.text = highscore.ToString();
    }

    void NewGame()
    {
        ballsLeft = 3;
        gameOver = false;
        winText.text = "";
        ball.SetActive(false);
        score = 0;

        GameObject[] coins;
        GameObject[] temp;
        coins = GameObject.FindGameObjectsWithTag("coin");

        foreach (GameObject c in coins)
        {
            
            c.GetComponent<MeshRenderer>().enabled = true;
            c.GetComponent<BoxCollider>().enabled = true;
            c.GetComponent<BumperController>().hitCount = 0;
        }
        
        temp = GameObject.FindGameObjectsWithTag("SSD");

        foreach (GameObject t in temp)
        {
            
            t.GetComponent<MeshRenderer>().enabled = true;
            t.GetComponent<BoxCollider>().enabled = true;
            t.GetComponent<BumperController>().hitCount = 0;
        }
        
        temp = GameObject.FindGameObjectsWithTag("CPU");

         foreach (GameObject t in temp)
        {
            
            t.GetComponent<MeshRenderer>().enabled = true;
            t.GetComponent<BoxCollider>().enabled = true;
            t.GetComponent<BumperController>().hitCount = 0;
        }
        
        temp = GameObject.FindGameObjectsWithTag("MotherBoard");

         foreach (GameObject t in temp)
        {
            
            t.GetComponent<MeshRenderer>().enabled = true;
            t.GetComponent<BoxCollider>().enabled = true;
            t.GetComponent<BumperController>().hitCount = 0;
        }
        
        temp = GameObject.FindGameObjectsWithTag("PowerSupply");

         foreach (GameObject t in temp)
        {
            
            t.GetComponent<MeshRenderer>().enabled = true;
            t.GetComponent<BoxCollider>().enabled = true;
            t.GetComponent<BumperController>().hitCount = 0;
        }
        
        temp = GameObject.FindGameObjectsWithTag("Ram");

         foreach (GameObject t in temp)
        {
            
            t.GetComponent<MeshRenderer>().enabled = true;
            t.GetComponent<BoxCollider>().enabled = true;
            t.GetComponent<BumperController>().hitCount = 0;
        }
        
        temp = GameObject.FindGameObjectsWithTag("Hard Drive");

         foreach (GameObject t in temp)
        {
            
            t.GetComponent<MeshRenderer>().enabled = true;
            t.GetComponent<BoxCollider>().enabled = true;
            t.GetComponent<BumperController>().hitCount = 0;
        }
        
        temp = GameObject.FindGameObjectsWithTag("GPU");

         foreach (GameObject t in temp)
        {
            
            t.GetComponent<MeshRenderer>().enabled = true;
            t.GetComponent<BoxCollider>().enabled = true;
            t.GetComponent<BumperController>().hitCount = 0;
        }
        
        temp = GameObject.FindGameObjectsWithTag("SuperGPU");

         foreach (GameObject t in temp)
        {
            
            t.GetComponent<MeshRenderer>().enabled = true;
            t.GetComponent<BoxCollider>().enabled = true;
            t.GetComponent<BumperController>().hitCount = 0;
        }
        
        temp = GameObject.FindGameObjectsWithTag("Case");

         foreach (GameObject t in temp)
        {
            
            t.GetComponent<MeshRenderer>().enabled = true;
            t.GetComponent<BoxCollider>().enabled = true;
            t.GetComponent<BumperController>().hitCount = 0;
        }

        
        SSDLeft = 1;
        CPUleft = 1;
        MotherboardLeft = 1;
        PowerSupplyLeft = 1;
        HardDriveleft = 1;
        CaseLeft = 1;
        RamLeft = 1;
        Gpuleft = 1;
    }

    void Plunger()
    {
        if ((ballsLeft > 0) && (ball.activeSelf == false))
        {
            ball.SetActive(true);

            Rigidbody rb = ball.GetComponent<Rigidbody>();
            Vector3 movement = new Vector3(0.0f, 0.0f, 1.0f);
            rb.AddForce(movement * plungerSpeed);

            // set ball position to location of plunger
            rb.velocity = Vector3.zero;
            ball.transform.position = plunger.transform.position;
            ballsLeft = ballsLeft - 1;

            audioPlayer.PlayOneShot(plungerClip, 2.0f);
        }
    }

    void switchCamera()
    {

        if (maincam.activeSelf == true)
        {
            maincam.SetActive(false);
            puzzleCamera.SetActive(true);
        }
        else
        {
            puzzleCamera.SetActive(false);
            maincam.SetActive(true);

        }
    }
}


