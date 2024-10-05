using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panda;

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
<<<<<<< Updated upstream
=======

    [Task]
    public void CheckMeat(){
        if (items.Contains("Meat")){
            Task.current.Succeed();
        }
        else{
            Task.current.Fail();
        }
    }

    [Task]
    public void CheckVegs(){
        if (items.Contains("Vegs"))
            Task.current.Succeed();
        else
            Task.current.Fail();
    }

    [Task]
    public void CheckFruit(){
        if (items.Contains("Fruits"))
            Task.current.Succeed();
        else
            Task.current.Fail();
    }
>>>>>>> Stashed changes
}
