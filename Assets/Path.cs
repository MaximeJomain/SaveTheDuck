using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField]
    private Transform[] Points;

    private float movementSpeed = 6.5f, rotationSpeed = 5f;

    private int pointsIndex;

    private void Start()
    {
        transform.position = Points[pointsIndex].transform.position;
        movementSpeed /= 10;
    }

    private void Update()
    {
        if (pointsIndex <= Points.Length - 1)
        {
            var targetRotation = Quaternion.LookRotation(Points[pointsIndex].transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            
            transform.position = Vector3.MoveTowards(transform.position, Points[pointsIndex].transform.position,
                movementSpeed * Time.deltaTime);

            if (transform.position == Points[pointsIndex].transform.position)
            {
                pointsIndex++;
            }

            if (pointsIndex == Points.Length)
            {
                pointsIndex = 0;
            }
        }
    }
}
