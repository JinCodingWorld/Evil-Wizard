using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform target;  // The AR camera that enemies will follow

    void Update()
    {
        if (target != null)
        {
            // Rotate the enemy to always face the target (camera)
            transform.LookAt(target);
        }
        else
        {
            return;
        }
    }
}
