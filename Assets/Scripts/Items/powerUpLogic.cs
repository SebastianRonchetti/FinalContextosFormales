using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class powerUpLogic : MonoBehaviour
{
    //pickable powerup
    public int colorCode;
    public float waitToRespawn, buffDuration;
    Collider col;
    public playerPowerUpInteraction playerPower;
    public Renderer meshRend;
    public Material redMat, blueMat, cyanMat, yellowMat;

    // Start is called before the first frame update
    void Start()
    {
        meshRend = GetComponentInChildren<Renderer>();
        switch (colorCode)
        {
            //Red
            case 0:
                meshRend.material = redMat;
                break;
            //Blue
            case 1:
                meshRend.material = blueMat;
                break;
            //Cyan
            case 2:
                meshRend.material = cyanMat;
                break;
            //Yellow
            case 3:
                meshRend.material = yellowMat;
                break;
        }

        playerPower = playerPowerUpInteraction.getSingleton();

        gameObject.tag = "pickupPower";
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out playerPowerUpInteraction e))
        {
            StartCoroutine(pickUpPower());
        }
    }

    IEnumerator pickUpPower()
    {
        yield return new WaitForEndOfFrame();
        playerPower.grabPowerUp(colorCode, buffDuration);
        despawn();
    }

    void despawn()
    {
        StartCoroutine(respawn());
        this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
        meshRend.gameObject.SetActive(false);
    }

    IEnumerator respawn()
    {
        yield return new WaitForSeconds(waitToRespawn);
        this.gameObject.GetComponent<CapsuleCollider>().enabled = true;
        meshRend.gameObject.SetActive(true);
    }
}
