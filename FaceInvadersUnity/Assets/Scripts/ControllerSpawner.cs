using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(SteamVR_TrackedObject))]

public class ControllerSpawner : MonoBehaviour
{

    SteamVR_TrackedObject trackedObj;
    SteamVR_Controller.Device device;

    public Transform spawnPoint;
    private GameObject newCube;

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    void Start()
    {
        Weep();
    }

    void Weep()
    {

        device = SteamVR_Controller.Input((int)trackedObj.index);
        Transform origin = trackedObj.origin ? trackedObj.origin : trackedObj.transform.parent;

        if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        {
            newCube = Instantiate(Resources.Load("SpawnCube"), gameObject.transform.position, Quaternion.identity) as GameObject;
            //newCube.gameObject.transform.position = new Vector3(0f, 2f, 30f);
            //newCube.gameObject.transform.Rotate(0, 180, 0, Space.World);
            //newCube.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.back * 300f);
            //newCube.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 300f);

            if (origin != null)
            {
                newCube.GetComponent<Rigidbody>().velocity = origin.TransformVector(device.velocity);
                newCube.GetComponent<Rigidbody>().angularVelocity = origin.TransformVector(device.angularVelocity);
            }
            else
            {
                newCube.GetComponent<Rigidbody>().velocity = device.velocity;
                newCube.GetComponent<Rigidbody>().angularVelocity = device.angularVelocity;
            }

            Destroy(newCube, 2f);
            

        }

        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            
        }

        Invoke("Weep", .03f);
    }

}