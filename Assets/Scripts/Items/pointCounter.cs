using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pointCounter : MonoBehaviour
{
    int currentPoints = 0;
    public Text display;
    public pointStars lastStar;

    private void Start()
    {
        actualizarPuntos(0);
    }

    public void actualizarPuntos(int suma)
    {
        currentPoints += suma;
        display.text = currentPoints.ToString();
        if(currentPoints == 34)
        {
            lastStar.gameObject.SetActive(true);
        }
    }
}
