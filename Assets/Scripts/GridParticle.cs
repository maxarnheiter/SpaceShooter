using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class GridParticle : MonoBehaviour 
{

    public List<Vector3> positions;
    public float moveSpeed;

    Vector3 targetPosition;
    Vector3 first;
    Vector3 last;
    Vector3 current;

    int index;

    bool forward;

	void Start () 
    {
        first = positions.First();
        last = positions.Last();

        targetPosition = first;

        transform.position = first;
	}
	

	void FixedUpdate () 
    {
        current = transform.position;

        Move();

        KeepTarget();
	}

    void Move()
    {
        transform.position = Vector3.MoveTowards(current, targetPosition, moveSpeed);
    }

    void KeepTarget()
    {
        if (current == targetPosition)
        {
            GetNextTarget();
            targetPosition = positions.ElementAt(index);
        }
    }

    void GetNextTarget()
    {
        if (forward == true && current != last)
            index++;
        if (forward == true && current == last)
        {
            forward = false;
            index--;
            return;
        }

        if (forward == false && current != first)
            index--;
        if(forward == false && current == first)
        {
            forward = true;
            index++;
            return;
        }

    }
}
