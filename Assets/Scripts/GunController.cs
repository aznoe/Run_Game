using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Camera cam;
    public Rigidbody2D rb;
    public Transform player;

    private Vector2 movement;
    Vector2 mousePos;
    
    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        movement = direction;


    }

    void FixedUpdate()
    {
        Vector2 lookdir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookdir.y, lookdir.x)*Mathf.Rad2Deg;
        rb.rotation = angle;

        folowCharacter(movement);
    }

    void folowCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + direction);
    }

}
