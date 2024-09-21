using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Awareness : MonoBehaviour
{
    [SerializeField]
    private float detectRange = 3.0f;
    [SerializeField]
    private List<GameObject> enemies;

    private void Update()
    {
        IsEnemyAround();
    }

    public bool IsEnemyAround()
    {
        //check if there are enemies near based on the detect range
        for(int i = 0; i < enemies.Count; i++)
        {
            if (Vector3.Distance(transform.position, enemies[i].transform.position) < detectRange)
            {
                Debug.Log("near the enemy!");
                return true;
            } 
        }
        return false;
    }
   
}
