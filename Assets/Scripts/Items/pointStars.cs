using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointStars : MonoBehaviour
{
    public pointCounter counter;

    private void Start()
    {
        counter = GetComponentInParent<pointCounter>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<playerPowerUpInteraction>())
        {
            counter.actualizarPuntos(1);
            Destroy(this.gameObject);
        }
    }
}
