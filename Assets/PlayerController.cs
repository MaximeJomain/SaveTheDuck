using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    void GetCaught();
}

public class PlayerController : MonoBehaviour
{
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out RaycastHit hit, 100))
            {
                IEnemy enemy = hit.transform.GetComponent(typeof(IEnemy)) as IEnemy;
                if (enemy != null)
                {
                    enemy.GetCaught();
                }
            }
        }
    }
}
