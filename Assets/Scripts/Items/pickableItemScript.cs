using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pickableItemScript : MonoBehaviour
{
    [SerializeField]Rigidbody objectRigidbody;
    Transform objGrabPointTransform;
    [SerializeField] int id;
    [SerializeField] Text idDisplay;

    private void Awake()
    {
        objectRigidbody = GetComponent<Rigidbody>();
        idDisplay.text = id.ToString();
    }

    public void objectGrab(Transform holdItemPointTrans)
    {
        this.objGrabPointTransform = holdItemPointTrans;
        objectRigidbody.useGravity = false;
    }

    public void objectDrop()
    {
        objGrabPointTransform = null;
        objectRigidbody.useGravity = true;
    }

    public bool isNotBeingHeld()
    {
        if(objGrabPointTransform == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void FixedUpdate()
    {
        float lerpSpeed = 5f;
        if(objGrabPointTransform != null)
        {
            Vector3 freshPosition = Vector3.Lerp(transform.position, objGrabPointTransform.position, Time.deltaTime * lerpSpeed);
            objectRigidbody.MovePosition(freshPosition);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" && objGrabPointTransform != null)
        {
            Physics.IgnoreCollision(collision.collider, this.gameObject.GetComponent<Collider>());
        }
    }

    public int keyId()
    {
        return id;
    }
}
