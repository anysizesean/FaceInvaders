using UnityEngine;
using System.Collections;

public class ballSpawn : MonoBehaviour {

    private GameObject NextShot;
    private float faceHeight;
    private float forceMultiplier = 35f;

    void Start () {

        Invoke("placeBall", 2);
	}
	
	void Update () {
	
	}


    void placeBall()
    {
        NextShot = Instantiate(Resources.Load("Ball"), gameObject.transform.position, Quaternion.identity) as GameObject;
        Invoke("playSound", .9f);
        Invoke("shotOnGoal", 1);
        Debug.Log("New Ball");
    }

    void playSound()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
    }

    void shotOnGoal()
    {

        GameObject face = GameObject.Find("Face");
        faceHeight = face.transform.position.y;
        Debug.Log("Face height is: " + faceHeight);
        NextShot.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.back * 500f);
        NextShot.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * (forceMultiplier * faceHeight));
        NextShot.gameObject.GetComponent<Rigidbody>().AddTorque(transform.right * 5f);
        Invoke("placeBall", 3);
        Debug.Log("Shot on goal!");
    }
}
