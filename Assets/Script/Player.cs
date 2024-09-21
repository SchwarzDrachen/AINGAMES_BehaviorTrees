using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Hunger hunger;
    void Start()
    {
        // In-line function declaration using lambda operator
        hunger.OnHungerDepleted += ()=>
        {
            GetComponent<Renderer>().material.color = Color.red;
        };
        // is the same as
        //hunger.OnHungerDepleted += SomeFunction;
    }

   private void SomeFunction()
   {
        GetComponent<Renderer>().material.color = Color.red; 
   }
}
