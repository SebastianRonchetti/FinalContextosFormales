using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class playerPowerUpInteraction : MonoBehaviour
{
    public static playerPowerUpInteraction Instance { get; private set; }
    public static playerPowerUpInteraction getSingleton()
    {
        return Instance;
    }

    public playerInputManager inputManager;
    public playerMovement movement;
    Collider playerCollider;
    int[] skillUses = new int[4];
    
    bool powerActive;

    public event EventHandler<onPowerUpSwitch_eventArgs> onPowerUpSwitch;
    public class onPowerUpSwitch_eventArgs : EventArgs
    {
        public int powerId;
        public float buffDuration;
    }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        inputManager = GetComponent<playerInputManager>();
        movement = GetComponent<playerMovement>();
        playerCollider = GetComponent<Collider>();

        //inputManager.onTriggerPower += triggerBuff;
    }

    //public void triggerBuff(object sender, playerInputManager.onTriggerPower_eventArgs e)
    //{
    //    if(skillUses[e.powerId] > 0)
    //    {
    //        onPowerUpSwitch?.Invoke(this, new onPowerUpSwitch_eventArgs {powerId = e.powerId});
    //        removeSkillCounter(e.powerId);
    //    }
    //}

    /*
        * 0 = Red
        * 1 = Blue
        * 2 = Cyan
        * 3 = Yellow
        * 4 = Green
        * 
    */

    public void grabPowerUp(int color, float duration)
    {
        /*if (canGainUses)
        {
            skillUses[color]++;
            canGainUses = !canGainUses;
        }*/
        onPowerUpSwitch?.Invoke(this, new onPowerUpSwitch_eventArgs { powerId = color, buffDuration = duration });
    }

    public void removeSkillCounter(int color)
    {
        skillUses[color] --;
    }
}
