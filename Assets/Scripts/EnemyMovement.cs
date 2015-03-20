using UnityEngine;
using System.Collections.Generic;
using System.Linq;


class EnemyMovement : MonoBehaviour, IAdjustedDifficulty
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

    GameObject playerObj;

    Vector3 target;
    Vector3 current;
    Vector3 anchor;
    Vector3 player;
    bool hasTarget;

    MovePhase movePhase;

    void Start()
    {
        playerObj = GameObject.Find("Player Ship");

        AdjustForDifficulty();
    }

    public void AdjustForDifficulty()
    {
        if (GLogic.difficultyMode == DifficultyMode.Easy)
            Easy();
        if (GLogic.difficultyMode == DifficultyMode.Hard)
            Hard();
    }

    public void Easy()
    {
        moveSpeed = moveSpeed * 0.55f;
    }

    public void Hard()
    {
        moveSpeed = moveSpeed * 1.3f;
    }


    void FixedUpdate()
    {
        if (movePhase == MovePhase.MoveToStart)
            hasTarget = true;

        current = transform.position;
        player = playerObj.transform.position;

        if(hasTarget)
            DoMove();
    }

    public void SetStartPosition(Vector3 startPosition)
    {
        anchor = startPosition;
        target = anchor;
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
        if (current != target)
        {
            transform.position = Vector3.MoveTowards(current, target, moveSpeed);
        }
        if (current == target)
        {
            int rand = Random.Range(0, 2);

            float xChange = Random.Range(jerkRange * -1, jerkRange);
            float yChange = Random.Range(jerkRange * -1, jerkRange);

            var randomPosition = new Vector3(anchor.x + xChange, anchor.y + yChange, anchor.z);

            float difX = randomPosition.x - current.x;
            float difY = randomPosition.y - current.y;

            if(rand == 0)
                target = new Vector3(current.x + difX, current.y, current.z);
            if(rand == 1)
                target = new Vector3(current.x, current.y + difY, current.z);
        }
    }

    void DoTrackBehavior()
    {

            transform.position = Vector3.MoveTowards(current, target, moveSpeed);
            target = new Vector3(player.x, current.y, current.z);
        
    }





}

