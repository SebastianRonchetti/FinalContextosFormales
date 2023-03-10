using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class playerInputManager : MonoBehaviour
{
    playerMovement movement;
    playerPowerUpInteraction powerManager;

    public event EventHandler<onTriggerPower_eventArgs> onTriggerPower;
    public class onTriggerPower_eventArgs : EventArgs
    {
        public int powerId;
    }
    /*
        * 0 = Red
        * 1 = Blue
        * 2 = Cyan
        * 3 = Yellow
        * 4 = Green
    */

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<playerMovement>();
        powerManager = GetComponent<playerPowerUpInteraction>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //interact 
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //trigger power
            onTriggerPower?.Invoke(this, new onTriggerPower_eventArgs { powerId = 0 });
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //trigger power
            onTriggerPower?.Invoke(this, new onTriggerPower_eventArgs { powerId = 1 });
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            //trigger power
            onTriggerPower?.Invoke(this, new onTriggerPower_eventArgs { powerId = 2 });
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            //trigger power
            onTriggerPower?.Invoke(this, new onTriggerPower_eventArgs { powerId = 3 });
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            //trigger power
            onTriggerPower?.Invoke(this, new onTriggerPower_eventArgs { powerId = 4 });
        }
    }
}
