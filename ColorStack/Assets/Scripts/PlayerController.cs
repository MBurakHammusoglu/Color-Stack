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
}
