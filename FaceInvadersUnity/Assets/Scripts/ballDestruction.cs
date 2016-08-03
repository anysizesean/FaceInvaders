using UnityEngine;
using System.Collections;

public class ballDestruction : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(gameObject.transform.position.y < -5)
        {
            Destroy(gameObject);
        }
	}
}
