using UnityEngine;
using System.Collections;

public class StartBall : MonoBehaviour {

    private GameObject FirstBall;
    private float faceX;
    private float faceY;
    private float faceZ;

    void Start()
    {

        Invoke("placeBall", 5);
    }

    void Update()
    {

    }


    void placeBall()
    {
        GameObject face = GameObject.Find("Face");
        faceX = face.transform.position.x;
        faceY = face.transform.position.y - .75f;
        faceZ = face.transform.position.z + 1f;
        FirstBall = Instantiate(Resources.Load("StartBall"), new Vector3(faceX,faceY,faceZ), Quaternion.identity) as GameObject;
        FirstBall.gameObject.GetComponent<Rigidbody>().AddTorque(transform.right * 5f);
    }
}
