using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDistance : MonoBehaviour
{
    public Transform objectA;
    public Transform objectB;

    private float distance = 0.0f;

    private void Update()
    {
        Debug.Log($"Distance between {objectA.name} and {objectB.name} is {Vector3.Distance(objectA.position, objectB.position)}.");
    }
}
