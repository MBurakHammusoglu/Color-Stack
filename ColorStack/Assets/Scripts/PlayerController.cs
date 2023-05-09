using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Color myColor;
    [SerializeField] Renderer[] myRends;

    [SerializeField] bool isPlaying;
    [SerializeField] float forwardSpeed;
    Rigidbody myRB;
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
}
