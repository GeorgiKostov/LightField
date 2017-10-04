/*
 * Copyright (c) 2016 Razeware LLC
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using UnityEngine;
using Valve.VR;

public class ControllerGrabObject : MonoBehaviour
{
    private SteamVR_TrackedObject trackedObj;
    Vector2 touchpad;
    public GameObject collidingObject;
    public GameObject objectInHand;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    public void OnTriggerEnter(Collider other)
    {
        SetCollidingObject(other);
        Debug.Log("enter");
    }

    public void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);
    }

    public void OnTriggerExit(Collider other)
    {
        if (!collidingObject)
        {
            return;
        }
        Debug.Log("exit");

        //collidingObject = null;
    }

    private void SetCollidingObject(Collider col)
    {
        if (collidingObject || !col.GetComponent<Rigidbody>())
        {
            return;
        }

        collidingObject = col.gameObject;
    }

    void Update()
    {
        //if (Controller.GetPress(EVRButtonId.k_EButton_Grip))
        //{
        //    PositionManager.Instance.MoveSpace(Controller.transform.pos);

        //}

            if (Controller.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
            {
                //Read the touchpad values
                touchpad = Controller.GetAxis(EVRButtonId.k_EButton_SteamVR_Touchpad);


                if (touchpad.y > 0.3f)
                {
                    PositionManager.Instance.MoveXDown();

                }
                if (touchpad.y < 0.3f)
                {
                    PositionManager.Instance.MoveXUp();

                }
                // handle rotation via touchpad
                if (touchpad.x > 0.3f)
                {
                    PositionManager.Instance.MoveXLeft();

                }
                if (touchpad.x < 0.3f)
                {
                    PositionManager.Instance.MoveXRight();

                }
            }
        

        

        if (Controller.GetPress(EVRButtonId.k_EButton_DPad_Left))
        {
            print("left");

        }            // Handle movement via touchpad

        if (Controller.GetPress(EVRButtonId.k_EButton_DPad_Right))
        {

        }
        if (Controller.GetPress(EVRButtonId.k_EButton_DPad_Up))
        {

        }
        if (Controller.GetPress(EVRButtonId.k_EButton_DPad_Left))
        {

        }
        if (Controller.GetHairTriggerDown())
        {
            if (collidingObject)
            {
                GrabObject();
            }
        }

        if (Controller.GetHairTriggerUp())
        {
            if (objectInHand)
            {
                ReleaseObject();
                collidingObject = null;
            }
        }
        if (Controller.GetHairTrigger())
        {
            if (objectInHand)
            {
                //collidingObject.transform.position = Controller.transform.pos;
            }
        }
    }

    private void GrabObject()
    {
        //print("grab");
        objectInHand = collidingObject;
        collidingObject = null;
    }

    private void CheckCalibrationButton()
    {

        if (collidingObject.transform.tag.Equals("CalibrationBeam"))
        {

        }
    }
    private void ReleaseObject()
    {
        objectInHand = null;
    }
}
