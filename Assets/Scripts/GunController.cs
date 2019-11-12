using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Camera cam;
    public Rigidbody2D rb;
    Vector2 mousePos;


    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        Vector2 lookdir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookdir.y, lookdir.x)*Mathf.Rad2Deg;
        rb.rotation = angle;
    }
}
