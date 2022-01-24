using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    //default movement speed
    public float movementSpeed = 5f;
    //player rigid body
    public Rigidbody2D body;
    //reference to vector
    public Vector2 movementVector2;
    //reference to player Animator
    public Animator playerMovement;

    public Tilemap grid;
    public bool canPlayerMove = true;
    public bool isPlayerAlive = true;

    // Update is called once per frame
    void Update()
    {
        if(canPlayerMove)
        {
            //Input
            movementVector2.x = Input.GetAxisRaw("Horizontal");
            movementVector2.y = Input.GetAxisRaw("Vertical");

            //Animator
            playerMovement.SetFloat("Horizontal", movementVector2.x);
            playerMovement.SetFloat("Vertical", movementVector2.y);
            //can use sqrMagnitude instead of magnitude for optimized performance. (note to self)
            playerMovement.SetFloat("Speed", movementVector2.magnitude);
        }
    }


    void FixedUpdate()
    {
        if (canPlayerMove)
        { //Movement
            body.MovePosition(body.position + movementVector2 * movementSpeed * Time.fixedDeltaTime);
        }
    }

    public void stopMovement()
    {
        canPlayerMove = false;
    }
    public void enableMovement()
    {
        canPlayerMove = true;
    }

    public void DestroyPlayer()
    {
        isPlayerAlive = false;
    }
}
