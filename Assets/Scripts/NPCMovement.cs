using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class NPCMovement : MonoBehaviour
{
    public float moveSpeed;
    private Vector2 minWalkPoint;
    private Vector2 maxWalkPoint;

    private Rigidbody2D orcRigidBody;
    
    public bool isWalking;

    public float walkTime;
    private float walkCounter;
    public float waitTime;
    private float waitCounter;

    private int walkDirection;

    public Collider2D restraintArea;
    private bool hasRestraint;

    public bool NPCcanMove;


    void Start()
    {
        orcRigidBody = GetComponent<Rigidbody2D>();
        
        waitCounter = waitTime;
        walkCounter = walkTime;

        ChooseDirection();

        if (restraintArea != null)
        {
            minWalkPoint = restraintArea.bounds.min;
            maxWalkPoint = restraintArea.bounds.max;
            hasRestraint = true;
        }

        NPCcanMove = true;
    }

    void Update()
    {
        if (!NPCcanMove)
        {
            orcRigidBody.velocity = Vector2.zero;
            return;
        }
        if (isWalking)
        {
            walkCounter -= Time.deltaTime;
            switch (walkDirection)
            {
                case 0:
                    orcRigidBody.velocity = new Vector2(0, moveSpeed);
                    if (hasRestraint && transform.position.y > maxWalkPoint.y)
                    {
                        isWalking = false;
                        walkCounter = waitTime;
                    }
                    break;

                case 1:
                    orcRigidBody.velocity = new Vector2(moveSpeed, 0);
                    if (hasRestraint && transform.position.x > maxWalkPoint.x)
                    {
                        isWalking = false;
                        walkCounter = waitTime;
                    }
                    break;

                case 2:
                    orcRigidBody.velocity = new Vector2(0, -moveSpeed);
                    if (hasRestraint && transform.position.y < minWalkPoint.y)
                    {
                        isWalking = false;
                        walkCounter = waitTime;
                    }
                    break;

                case 3:
                    orcRigidBody.velocity = new Vector2(-moveSpeed, 0);
                    if (hasRestraint && transform.position.x < minWalkPoint.x)
                    {
                        isWalking = false;
                        walkCounter = waitTime;
                    }
                    break;
            }
            if (walkCounter < 0)
            {
                isWalking = false;
                walkCounter = waitTime;
            }
        }
        else
        {
            waitCounter -= Time.deltaTime;
            orcRigidBody.velocity = Vector2.zero;
            if (waitCounter < 0)
            {
                ChooseDirection();
            }
        }
    }
    public void ChooseDirection()
    {
        walkDirection = Random.Range(0, 4);
        isWalking = true;
        walkCounter = walkTime;
    }
    
}
