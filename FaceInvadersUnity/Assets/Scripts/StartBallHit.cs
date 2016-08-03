using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartBallHit : MonoBehaviour {

    void Update()
    {
        if(gameObject.transform.position.z > 10f)
        {
            SceneManager.LoadScene("Scene2");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * 200f);
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
    }
}
