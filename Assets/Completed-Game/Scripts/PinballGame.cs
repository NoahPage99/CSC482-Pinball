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

    private void Update()
    {

        if (Input.GetKey(newGameKey) == true) NewGame();
        if (Input.GetKey(plungerKey) == true) Plunger();
        if (Input.GetKey(puzzlecameraKey) == true) switchCamera();

        // detect ball going past flippers into "drain"
        if ((ball.activeSelf == true) && (ball.transform.position.z < drain.transform.position.z))
        {
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
        else if (score == 1500) winText.text = "Superstar!";
        else if (score >= 2100) winText.text = "You won!";
        else winText.text = "";

        if (score > highscore) highscore = score;
        highScoreText.text = highscore.ToString();
    }

    void NewGame()
    {
        ballsLeft = 3;
        gameOver = false;
        ball.SetActive(false);
        score = 0;

        GameObject[] bumpers;
        bumpers = GameObject.FindGameObjectsWithTag("Bumper");

        foreach (GameObject bumper in bumpers)
        {
            bumper.GetComponent<MeshRenderer>().enabled = true;
            bumper.GetComponent<BoxCollider>().enabled = true;
            bumper.GetComponent<BumperController>().hitCount = 0;
        }
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
            ball.transform.position = plunger.transform.position;
            ballsLeft = ballsLeft - 1;

            audioPlayer.PlayOneShot(plungerClip);
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


