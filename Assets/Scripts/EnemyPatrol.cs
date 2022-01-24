using Assets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class EnemyPatrol : MonoBehaviour
{
    public bool isPatrolling;
    public float movementSpeed = 5f;
    public Rigidbody2D body;
    private Random rnd = new Random();
    private bool mustTurn;
    private bool canMove;

    // Start is called before the first frame update    

    Vector2 GetDirection()
    {
        Vector2 right = new Vector2(movementSpeed* Time.fixedDeltaTime, body.velocity.y);
        Vector2 left = new Vector2(movementSpeed * -1 * Time.fixedDeltaTime, body.velocity.y);
        Vector2 up = new Vector2(body.velocity.x, movementSpeed * Time.fixedDeltaTime);
        Vector2 down = new Vector2(body.velocity.x, movementSpeed * - 1 * Time.fixedDeltaTime);
        List<Vector2> directions = new List<Vector2>();
        directions.Add(right);
        directions.Add(left);
        directions.Add(up);
        directions.Add(down);
        body.velocity = Vector2.zero;
        return directions[rnd.Next(directions.Count)];
    }

    float GetRandomNumber(double minimum, double maximum)
    {
        double value = rnd.NextDouble() * (maximum - minimum) + minimum;
        return (float)value;
    }

    void Start()
    {
        canMove = true;
        isPatrolling = true; 
        mustTurn = false;
        if (isPatrolling)
        {
            Patrol(GetDirection());
        }
    }

    private void Update()
    {
        this.Wait(GetRandomNumber(0.5, 4), checkForDirection);
    }

    void checkForDirection()
    {
        Debug.Log("waiting");
        if (body.velocity == Vector2.zero && canMove)
        {
            body.velocity = GetDirection();
        }
    }




    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "bomb_explosion_0 Variant(Clone)")
        {
            canMove = false;
            body.GetComponent<Animator>().SetTrigger("slimeDeath");
        }

        if (collision.transform.name == "player")
        {
            GameObject instance = GameObject.Find("player");
            instance.GetComponent<Animator>().SetTrigger("death");
            
        }

        if (collision.transform.name == "Gameplay")
        {
            mustTurn = true;
            var newDirection = GetDirection();
            if(newDirection != body.velocity)
            {
                Debug.Log("New direction set");
                Patrol(newDirection);
            }
            else
            {
                while(newDirection == body.velocity)
                {
                    Debug.Log("Was already going in that direction... New direction set");
                    newDirection = GetDirection();
                }
                Patrol(newDirection);
            }
        }

    }

    private void Patrol(Vector2 direction)
    {
        if(canMove)
        {
            body.velocity = Vector2.zero;
            Debug.Log("Hit! changing direction...");
            if (mustTurn)
            {
                FlipX();
                mustTurn = false;
            }
            body.velocity = direction;
        }
    }

    void FlipX()
    {
        isPatrolling = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        isPatrolling = true;
    }
    public void DestroyMe()
    {
        Destroy(gameObject);
    }    
}
