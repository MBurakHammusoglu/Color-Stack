using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupStackColor : MonoBehaviour
{
    [SerializeField] int value;
    [SerializeField] Color pickUpColor;
    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.SetColor("_Color", pickUpColor);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
