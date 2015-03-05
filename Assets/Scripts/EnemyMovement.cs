using UnityEngine;
using System.Collections.Generic;
using System.Linq;


class EnemyMovement : MonoBehaviour
{
    private enum MovePhase
    {
        MoveToStart, 
        AttackMove
    }


    public float moveSpeed;
    public float floatRange;
    public float jerkRange;

    public EnemyMovmentMode movementMode;

    Vector3 target;
    Vector3 current;
    Vector3 anchor;
    bool hasTarget = false;

    MovePhase movePhase;

    void Start()
    {

    }

    void FixedUpdate()
    {
        current = transform.position;

        if(hasTarget)
            DoMove();
    }

    public void SetStartPosition(Vector3 startPosition)
    {
        anchor = startPosition;
        hasTarget = true;
        movePhase = MovePhase.MoveToStart;
    }

    void DoMove()
    {
        if(movePhase == MovePhase.MoveToStart)
        {
            DoStartBehavior();
        }
        if(movePhase == MovePhase.AttackMove)
        {
            if(movementMode == EnemyMovmentMode.Float)
                DoFloatBehavior();

            if(movementMode == EnemyMovmentMode.Jerk)
                DoJerkBehavior();

            if(movementMode == EnemyMovmentMode.Track)
                DoTrackBehavior();
        }
    }

    void DoStartBehavior()
    {
        if(current != target)
        {
            transform.position = Vector3.MoveTowards(current, anchor, moveSpeed);
        }
        if(current == target)
        {
            movePhase = MovePhase.AttackMove;
        }
    }

    void DoFloatBehavior()
    {
        if (current != target)
        {
            transform.position = Vector3.MoveTowards(current, target, moveSpeed);
        }
        if (current == target)
        {
            float xChange = Random.Range(floatRange * -1, floatRange);
            float yChange = Random.Range(floatRange * -1, floatRange);

            target = new Vector3(anchor.x + xChange, anchor.y + yChange, anchor.z);
        }
    }

    void DoJerkBehavior()
    {

    }

    void DoTrackBehavior()
    {

    }





}

