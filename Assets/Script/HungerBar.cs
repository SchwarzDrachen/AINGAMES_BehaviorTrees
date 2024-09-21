using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class HungerBar : MonoBehaviour
{
    [SerializeField]
    private Image fill_hunger;
    [SerializeField]
    private Text txt_hunger;
    [SerializeField]
    private Hunger hunger;

    private void Start()
    {
        hunger.OnHungerDepleted += HungerDepleted;
        hunger.OnHungerUpdated += UpdateHungerValue;
        hunger.OnCheckHunger += CheckHunger;
       
    }

    private void Update()
    {
        hunger.HungerSample(() =>
        {
            Debug.Log("BUSOG NA KO");
        }, () =>
        {
            Debug.Log("GUTOM NA KO");
        });
    }

    private void OnFullHunger()
    {
        Debug.Log("Do something when hunger is full");
    }

    private void HungerDepleted()
    {
        fill_hunger.fillAmount = 0;
        txt_hunger.text = "0/100";
    }

    private void UpdateHungerValue(float value)
    {
        fill_hunger.fillAmount = value / 100;
        txt_hunger.text = $"{value.ToString("N0")}/100";
    }

    private bool CheckHunger(float value, float value2, float value3)
    {
        return false;
    }
}
