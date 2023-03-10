using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockLogic : MonoBehaviour
{
    public playerPowerUpInteraction plaInteraction;
    //existing block
    public int colorCode;
    Collider col;
    bool buffActive;
    [SerializeField] float buffDuration;
    [SerializeField] MeshRenderer meshRend;
    [SerializeField] Material mat1, mat2;

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
        col = gameObject.GetComponent<Collider>();
        switch (colorCode){
            case 0:
                meshRend.material = mat1;
                break;
            case 1:
                meshRend.material = mat2;
                break;
        }
        plaInteraction = playerPowerUpInteraction.getSingleton();
        plaInteraction.onPowerUpSwitch += activateBuffStatus;
        
        endBuffStatus();
    }

    void activateBuffStatus(object sender, playerPowerUpInteraction.onPowerUpSwitch_eventArgs e)
    {
        if(e.powerId == 0 || e.powerId == 1)
        {
            if(e.powerId == colorCode)
            {
                buffDuration = e.buffDuration;
                beginBuffStatus();
            }
            else
            {
                buffDuration = 0;
                endBuffStatus();
            }
        }
    }

    void beginBuffStatus()
    {
        buffActive = true;
        switch (colorCode)
        {
            case 0:
                //solid to intangible
                this.col.enabled = false;
                break;
            case 1:
                //intangible to solid
                this.col.enabled = true;
                break;
        }
        StartCoroutine(activeStateTimer());
    }

    void endBuffStatus()
    {
        buffActive = false;
        buffDuration = 0f;
        switch (colorCode)
        {
            case 0:
                //solid to intangible
                this.col.enabled = true;
                break;
            case 1:
                //intangible to solid
                this.col.enabled = false;
                break;
        }
    }

    IEnumerator activeStateTimer()
    {
        yield return new WaitForSeconds(buffDuration);
        endBuffStatus();
    }
   
    int myColorIs()
    {
        return colorCode;
    }
}
