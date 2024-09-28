using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private List<string> items = new List<string>();

    private void Awake()
    {
        ActionNode actionNodeMeat = new(CheckInventoryForMeat);
        ActionNode actionNodeVegs = new(CheckInventoryForVegs);
        ActionNode actionNodeFruits = new(CheckInventoryForFruits);
        items.Add("Meat");
        items.Add("Vegs");
        items.Add("Fruits");
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

    public NodeState CheckInventoryForVegs()
    {
        if (items.Contains("Vegs"))
            return NodeState.SUCCESS;
        else
            return NodeState.FAILURE;
    }

    public NodeState CheckInventoryForFruits()
    {
        if (items.Contains("Fruits"))
            return NodeState.SUCCESS;
        else
            return NodeState.FAILURE;
    }
}
