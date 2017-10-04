using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionManager : AManager<PositionManager>
{


    public GameObject PlaySpace;
    public Camera ProjectorCam;
    public float factor = 0.001f;
	// Use this for initialization
	void Start () {
        if (Display.displays.Length > 1)
            Display.displays[1].Activate();
        if (Display.displays.Length > 2)
            Display.displays[2].Activate();

	}

    // Update is called once per frame
    void Update () {
		
	}

    public void MoveXLeft()
    {
        PlaySpace.transform.position = new Vector3(PlaySpace.transform.position.x - factor, PlaySpace.transform.position.y, PlaySpace.transform.position.z);
    }
    public void MoveXRight()
    {
        PlaySpace.transform.position = new Vector3(PlaySpace.transform.position.x + factor, PlaySpace.transform.position.y, PlaySpace.transform.position.z);
    }
    public void MoveXUp()
    {
        PlaySpace.transform.position = new Vector3(PlaySpace.transform.position.x , PlaySpace.transform.position.y + factor, PlaySpace.transform.position.z);
    }
    public void MoveXDown()
    {
        PlaySpace.transform.position = new Vector3(PlaySpace.transform.position.x, PlaySpace.transform.position.y - factor, PlaySpace.transform.position.z);
    }
    public void MoveSpace(Vector3 controllerPos)
    {
        PlaySpace.transform.position = new Vector3(0, controllerPos.y, 0);
        //PlaySpace.transform.position = new Vector3(controllerPos.x, 0, controllerPos.z);
    }
}
