using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    private GameObject number01;
    private GameObject number02;
    private GameObject number03;

    private GameObject NextShot;
    public Transform ballSpawn;
    private float faceHeight;
    private float forceMultiplier = 35f;
    private Vector3 randomPlacement;

    private int shotsRemaining = 20;
    private int scoreInt;
    private bool textUpdate = false;

    private GameObject Score;
    //private TextMesh scoreMesh;
    private TextMesh scoreInfo;

    private bool newGame = true;

    void Start () {
        Score = GameObject.Find("Score");
        //scoreMesh = Score.GetComponent<TextMesh>();
        scoreInfo = GetComponent<TextMesh>();
        Invoke("CountDown3", 2f);
    }
	
	void Update () {
	
	}

    void CountDown3()
    {
        number03 = Instantiate(Resources.Load("number03"), gameObject.transform.position, Quaternion.identity) as GameObject;
        number03.gameObject.transform.position = new Vector3(0f, 2f, 30f);
        number03.gameObject.transform.Rotate(0, 180, 0, Space.World);
        number03.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.back * 500f);
        Destroy(number03, 2f);
        Invoke("CountDown2", 2f);
    }

    void CountDown2()
    {
        number02 = Instantiate(Resources.Load("number02"), gameObject.transform.position, Quaternion.identity) as GameObject;
        number02.gameObject.transform.position = new Vector3(0f, 2f, 30f);
        number02.gameObject.transform.Rotate(0, 180, 0, Space.World);
        number02.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.back * 500f);
        Destroy(number02, 2f);
        Invoke("CountDown1", 2f);
    }

    void CountDown1()
    {
        number01 = Instantiate(Resources.Load("number01"), gameObject.transform.position, Quaternion.identity) as GameObject;
        number01.gameObject.transform.position = new Vector3(0f, 2f, 30f);
        number01.gameObject.transform.Rotate(0, 180, 0, Space.World);
        number01.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.back * 500f);
        Destroy(number01, 2f);
        Invoke("PlaceBall", 2f);
    }

    void PlaceBall()
    {

        if (newGame)
        {
            scoreInfo.text = "Balls: " + shotsRemaining + "  Score: 0";
            //scoreMesh.text = "Score: 0";
            newGame = false;
        }

        if (scoreInt >= 24)
        {
            scoreInfo.text = "You Win!";
            Invoke("RestartGame", 5);
            return;
        }

        if (shotsRemaining > 0)
        {
            Vector3 randomPlacement = new Vector3(ballSpawn.position.x + Random.Range(-0.5f, 0.5f), ballSpawn.position.y, ballSpawn.position.z);
            NextShot = Instantiate(Resources.Load("Ball"), randomPlacement, Quaternion.identity) as GameObject;
            Invoke("ShotOnGoal", 1);
            shotsRemaining--;
            
            Debug.Log("New Ball. Shots Remaining: " + shotsRemaining);
        }else
        {
            scoreInfo.text = "Game Over! You scored " + scoreInt + " points";
            Debug.Log("Out of balls!");
            Invoke("RestartGame", 5);
        }
        
    }

    void ShotOnGoal()
    {
        GameObject soundSource = GameObject.Find("BallSpawn");
        PlaySFX(soundSource, "ballHit");
        GameObject face = GameObject.Find("Face");
        faceHeight = face.transform.position.y;
        Debug.Log("Face height is: " + faceHeight);
        NextShot.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.back * 500f);
        NextShot.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * (forceMultiplier * faceHeight));
        NextShot.gameObject.GetComponent<Rigidbody>().AddTorque(transform.right * 5f);
        UpdateScore();
        Invoke("PlaceBall", 3);

        Debug.Log("Shot on goal!");
    }

    void PlaySFX(GameObject soundSource, string url, float volume = 1.0f)
    {
        AudioClip ac = Resources.Load(url) as AudioClip;
       // GameObject sfx = new GameObject(); // create the temp object
        //sfx.transform.position = Vector3.zero; // set its position
        AudioSource aSource = soundSource.AddComponent<AudioSource>(); // add an audio source
        aSource.clip = ac; // define the clip
        aSource.volume = volume;
        aSource.Play(); // start the sound
        //DontDestroyOnLoad(sfx);
        //Destroy(sfx, ac.length + 0.5f); // destroy object after clip duration
    }

    public void AddScore(int newScoreValue)
    {
        scoreInt += newScoreValue;
        UpdateScore();
    }

    public void AddBalls(string bonus)
    {
        if(bonus == "alien")
        {
            shotsRemaining += 10;
            scoreInfo.text = "Mothership down! +10 Balls";
        }
        else if(bonus == "crayon")
        {
            shotsRemaining += 2;
            scoreInfo.text = "Crayon down! +2 Balls";
        }

        textUpdate = true;
        Invoke("UpdateOver", 3);
    }

    void UpdateScore()
    {
        if (!textUpdate)
        {
            scoreInfo.text = "Balls: " + shotsRemaining + "  Score: " + scoreInt;
        }
        
    }

    void UpdateOver()
    {
        textUpdate = false;
        UpdateScore();
    }

    void RestartGame()
    {
        SceneManager.LoadScene("Scene1");
    }
}
