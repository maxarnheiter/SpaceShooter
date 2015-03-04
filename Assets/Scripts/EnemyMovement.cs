using UnityEngine;
using System.Collections.Generic;
using System.Linq;


class EnemyMovement : MonoBehaviour
{
    public float moveSpeed;

    public EnemyMovmentMode movementMode;

    Vector3 targetPosition;
    bool hasTarget = false;

    void Start()
    {

    }

    void Update()
    {
       
    }

    void SetStartPosition(Vector3 startPosition)
    {
        targetPosition = startPosition;
        hasTarget = true;
    }




}

