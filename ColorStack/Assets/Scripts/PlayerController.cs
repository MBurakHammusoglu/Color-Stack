using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Color myColor;
    [SerializeField] Renderer[] myRends;

    [SerializeField] bool isPlaying;
    [SerializeField] float forwardSpeed;

    [SerializeField] float sideLerpSpeed;
    Rigidbody myRB;

    
    [SerializeField] Transform stackPosition;
    Transform parentPickup;
    
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        SetColor(myColor);
       
        
    }

    void Update()
    {
        if (isPlaying)
        {
            MoveForward();
        }
        if (Input.GetMouseButton(0))
        {
            if (isPlaying == false)
            {
                isPlaying = true;
            }
            MoveSideWays();
        }
    }
    void SetColor(Color colorIn)
    {
        myColor = colorIn;
        for(int i = 0; i < myRends.Length; i++)
        {
            myRends[i].material.SetColor("_Color", myColor);
        }
    }
    void MoveForward()
    {
        myRB.velocity = Vector3.forward * forwardSpeed;
    }
    void MoveSideWays()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit, 100))
        {
            transform.position = Vector3.Lerp(transform.position,
                new Vector3(hit.point.x, transform.position.y, transform.position.z), sideLerpSpeed * Time.deltaTime);
        }
    }
   /* private void OnTriggerEnter(Collider other)
    {
        Debug.Log("çalýþtý");
        if (other.tag == "Pickup" )
        {
            pickUpRb.isKinematic = true;
            Transform pickupTransform = other.transform;
            pickupTransform.parent = stackPosition;
            Vector3 newPosition = stackPosition.childCount * Vector3.up;
            pickupTransform.localPosition = newPosition;
            if(pickupTransform.parent.tag == "Pickup")
            {
                Debug.Log("pickuplar çarpýþýyor");
            }
            
        }
    } */
     private void OnTriggerEnter(Collider other)
     {

         if(other.tag == "Pickup")
         {

             Transform otherTransform = other.transform;
             Rigidbody otherRB = other.transform.GetComponent<Rigidbody>();
             otherRB.isKinematic = true;
             other.enabled = false;
             if (parentPickup == null)
             {

                 parentPickup = otherTransform;
                 parentPickup.position = stackPosition.position;
                parentPickup.parent = stackPosition;
             }
             else
             {

                 parentPickup.position += Vector3.up * (otherTransform.localScale.y);
                 otherTransform.position = stackPosition.position;
                 otherTransform.parent = parentPickup;
             }
         }
     }
    
}
