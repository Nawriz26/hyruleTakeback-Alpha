using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 5;
    void Update01() //rename to Update(); make active in Unity gaming loop
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print($"key press detected {DateTime.Now}");
            transform.position = new Vector3(10, 0, 0);
            //transform.position += new Vector3(1, 0, 0);
            //transform.Translate(0.5f, 0, 0);
        }
    }
    void Update02() //rename to Update() make active in Unity gaming loop
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(x, y, 0);
        //movement.Normalize();
        transform.Translate(
        movement * speed * Time.deltaTime);
    }
}