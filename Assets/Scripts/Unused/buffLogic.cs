using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buffLogic : MonoBehaviour
{
    //Player affecting effects
    [SerializeField] int colorCode;
    [SerializeField] float buffDuration;
    bool buffActive;

    /*
        * 0 = Red
        * 1 = Cyan
        * 2 = Blue
        * 3 = Green
        * 4 = Yellow
    */

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onBuffActivationCall(playerPowerUpInteraction.onPowerUpSwitch_eventArgs e)
    {
        switch (e.powerId)
        {
            case 0:
                //RED
                //All red blocks become semi transparent and intangible to the player

                break;
            case 1:
                //BLUE
                //All blue blocks become opaque and tangible to the player
                break;
            case 2:
                //CYAN
                //Player gains increased jump height
                break;
            case 3:
                //YELLOW
                //player gains increased speed
                break;
            case 4:
                //GREEN
                //If player touches a green block, gets teleported to brother green block
                break;
        }
    }
}
