using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerPickupDropItem : MonoBehaviour
{
    [SerializeField] Transform playerMainCameraPos;
    [SerializeField] LayerMask pickUpLayer;
    [SerializeField] Transform holdItemPoint;
    float grabDistance = 4f;
    pickableItemScript heldItem;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(heldItem == null)
            {
                //grab pointed object
                if(Physics.Raycast(playerMainCameraPos.position, playerMainCameraPos.forward,
                    out RaycastHit raycastHit, grabDistance, pickUpLayer))
                {
                    if(raycastHit.transform.TryGetComponent(out heldItem))
                    {
                        heldItem.objectGrab(holdItemPoint);
                    }
                }
            }
            else
            {
                //drop held object
                heldItem.objectDrop();
                heldItem = null;
            }
        }
    }
}
