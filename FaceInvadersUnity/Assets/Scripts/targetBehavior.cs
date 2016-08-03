using UnityEngine;
using System.Collections;

public class targetBehavior : MonoBehaviour {

    private GameObject Controller;
    private GameController gameController;
    private GameObject Explosion;

    void Start () {
        Controller = GameObject.Find("Controller");
        gameController = Controller.GetComponent<GameController>();
    }
	
	void Update () {

        //transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time, 1)+2, transform.position.z);

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Target Hit!!!");
        
        gameController.AddScore(1);
        PlaySFX("success");
        Destroy(gameObject);
        Explosion = Instantiate(Resources.Load("Explosion"), gameObject.transform.position, Quaternion.identity) as GameObject;
        Destroy(Explosion, 5.0f);
    }

    void PlaySFX(string url, float volume = 1.0f)
    {
        AudioClip ac = Resources.Load(url) as AudioClip;
        GameObject sfx = new GameObject(); // create the temp object
        sfx.transform.position = Vector3.zero; // set its position
        AudioSource aSource = sfx.AddComponent<AudioSource>(); // add an audio source
        aSource.clip = ac; // define the clip
        aSource.volume = volume;
        aSource.Play(); // start the sound
        DontDestroyOnLoad(sfx);
        Destroy(sfx, ac.length + 0.5f); // destroy object after clip duration
    }
}
