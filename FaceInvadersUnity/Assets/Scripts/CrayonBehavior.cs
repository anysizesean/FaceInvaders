using UnityEngine;
using System.Collections;

public class CrayonBehavior : MonoBehaviour {

    private GameObject Controller;
    private GameController gameController;
    private GameObject FreshBalls;
    private bool hasFallen = false;

    void Start () {

        Controller = GameObject.Find("Controller");
        gameController = Controller.GetComponent<GameController>();
    }
	
	void Update () {

        if (!hasFallen && gameObject.transform.position.y <= 3f)
        {
            hasFallen = true;

            Debug.Log("Crayon Down!!!");

            gameController.AddBalls("crayon");
        }

        if (gameObject.transform.position.y <= -3f)
        {
            Destroy(gameObject);
        }

    }

}
