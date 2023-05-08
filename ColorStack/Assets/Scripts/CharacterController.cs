using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    Rigidbody rigidBody;
    bool left;
    bool right;
    float speed = 3f;
    float xSpeed = 2f;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        float mouseX = Input.GetAxis("Mouse X");
        Vector3 movement = new Vector3(0f, 0f, mouseX) * xSpeed * Time.deltaTime;
        transform.Translate(movement);
        /*
        Vector3 rightWay = new Vector3(transform.position.x, transform.position.y,2.50f);
        Vector3 leftWay = new Vector3(transform.position.x, transform.position.y, -2.50f);



        if (Input.touchCount > 0) // touchCount ekranda dokunma alg�lar
        {
            Touch finger = Input.GetTouch(0); // Parma��n konumunu al�r�z.
            if (finger.deltaPosition.x>.50f)   // dokundu�umuz pixel
            {
                right = true;
                left = false;
            }
            if (finger.deltaPosition.x < .50f)   // dokundu�umuz pixel
            {
                right = false;
                left = true;
            }
            if(right == true)
            {
                transform.position = Vector3.Lerp(transform.position, rightWay, 5 * Time.deltaTime);  // yumu�ak hareket eder.
            }
            if (left == true)
            {
                transform.position = Vector3.Lerp(transform.position, leftWay, 5 * Time.deltaTime);  // yumu�ak hareket eder.
            }
        }*/
    }

}
