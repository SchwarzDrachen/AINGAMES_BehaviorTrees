using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private List<string> items = new List<string>();

    public bool ContainsItem(string id)
    {
        return (items.Contains(id));
    }
}
