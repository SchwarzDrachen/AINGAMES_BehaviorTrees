using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private List<string> items = new List<string>();

    private void Awake()
    {
        ActionNode actionNode = new(CheckInventoryForMeat);
    }
    public bool ContainsItem(string id)
    {
        return (items.Contains(id));
    }

    public NodeState CheckInventoryForMeat()
    {
        if (items.Contains("Meat"))
            return NodeState.SUCCESS;
        else
            return NodeState.FAILURE;
    }
}
