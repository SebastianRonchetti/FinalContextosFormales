using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class objectiveReceiver : MonoBehaviour
{
    [SerializeField] int objectiveId;
    [SerializeField] Animation doorAnimation, keyActiveAnimation;
    [SerializeField] GameObject placedKey;
    CapsuleCollider col;
    pickableItemScript levelKey;
    [SerializeField] Text idDisplay;
    bool triggered = false;
    public event EventHandler<onLevelFinished_EventArgs> onLevelfinished;
    public class onLevelFinished_EventArgs
    {
        public int levelId;
    }

    private void Awake()
    {
        col = gameObject.GetComponent<CapsuleCollider>();
        idDisplay.text = objectiveId.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out levelKey))
        {
            if(levelKey.keyId() == objectiveId)
            {
                if (!triggered)
                {
                    levelKey.objectDrop();
                    levelKey.gameObject.SetActive(false);
                    triggered = true;

                    placedKey.gameObject.SetActive(true);
                    keyActiveAnimation.Play();
                    doorAnimation.Play();
                }
            }
        }
    }
}
