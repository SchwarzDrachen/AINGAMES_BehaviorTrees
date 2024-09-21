using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Hunger hunger;

    private void OnEnable()
    {
        hunger.OnHungerUpdated += RageMode;
    }

    private void OnDisable()
    {
        hunger.OnHungerUpdated -= RageMode;
    }

    private void RageMode(float value)
    {
        if(value <= 50)
        {
            transform.localScale = Vector3.one * 2.0f;
            Debug.Log($"{gameObject.name} is anger");
        }
       
    }
}
