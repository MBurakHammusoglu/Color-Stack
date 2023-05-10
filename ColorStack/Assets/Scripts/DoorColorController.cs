using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorColorController : MonoBehaviour
{
    public GameObject redDoorColor; // Kýrmýzý kapý GameObject'ini referans alacak bir deðiþken
    public GameObject blueDoorColor;
    public GameObject greenDoorColor;

    private void OnTriggerEnter(Collider other)
     {
         if (other.gameObject == redDoorColor)
         {
             MeshRenderer[] meshRenderers = GetComponentsInChildren<MeshRenderer>();
             foreach (MeshRenderer renderer in meshRenderers)
             {
                 renderer.material.color = Color.red;
             }
        }
        else if (other.gameObject == blueDoorColor)
        {
            MeshRenderer[] meshRenderers = GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer renderer in meshRenderers)
            {
                renderer.material.color = Color.blue;
            }
        }
        else if (other.gameObject == greenDoorColor)
        {
            MeshRenderer[] meshRenderers = GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer renderer in meshRenderers)
            {
                renderer.material.color = Color.green;
            }
        }

    } 

}




