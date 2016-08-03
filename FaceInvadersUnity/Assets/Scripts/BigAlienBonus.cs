using UnityEngine;
using System.Collections;

public class BigAlienBonus : MonoBehaviour
{

    private GameObject Controller;
    private GameController gameController;
    private GameObject AlienDown;
    private GameObject Explosion;

    void Start()
    {

        Controller = GameObject.Find("Controller");
        gameController = Controller.GetComponent<GameController>();
    }


    void OnTriggerEnter(Collider other)
    {

        Debug.Log("Big Alien Down!!!");
        PlaySFX("success");
        Explosion = Instantiate(Resources.Load("Explosion"), gameObject.transform.position, Quaternion.identity) as GameObject;
        Destroy(Explosion, 5.0f);
    

        gameController.AddBalls("alien");

        Destroy(gameObject);
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