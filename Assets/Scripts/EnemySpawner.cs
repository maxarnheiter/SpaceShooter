using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class EnemySpawner : MonoBehaviour
{

    public bool endless;

    void Start()
    {
        var enemy = GameObject.Find("Test Enemy").GetComponent<EnemyMovement>();

        enemy.SetStartPosition(new Vector3(0f, 0f, 0f));
    }

    void Update()
    {
       
    }
}

