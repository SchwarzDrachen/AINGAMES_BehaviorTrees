using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatFoodBT : MonoBehaviour
{
    // Step 1: Declare references to other scripts
    private Hunger hunger;
    private Awareness awareness;
    private Inventory inventory;

    // Step 2: Declare all the nodes. The root node is a Sequence
    private Sequence rootNode;
    private ActionNode an_checkHunger;
    private Selector selector_checkInventory;
    private ActionNode an_checkMeat;
    private ActionNode an_checkVegetables;
    private ActionNode an_checkFruits;
    private Inverter inv_checkEnemies;
    private ActionNode an_checkEnemies;
    private ActionNode an_eatFood;

    private void Awake()
    {
        // Step 3: Get Components of all action-related nodes
        hunger = GetComponent<Hunger>();
        awareness = GetComponent<Awareness>();
        inventory = GetComponent<Inventory>();
    }

    private void Start()
    {
        // Step 4: Make the behavior tree. Use the constructors to
        // build up instances each node. It is better to build up
        // the tree from the children nodes all the way up to the
        // parent nodes

        an_checkHunger = new ActionNode(CheckHunger);

        // Check Inventory Selector 
        // Define the action nodes under it first
        an_checkMeat = new ActionNode(CheckForMeat);
        an_checkVegetables = new ActionNode(CheckForVegetables);
        an_checkFruits = new ActionNode(CheckForFruits);
        // Build the actual selector node
        List<Node> childNodes = new();
        childNodes.Add(an_checkMeat);
        childNodes.Add(an_checkVegetables);
        childNodes.Add(an_checkFruits);
        selector_checkInventory = new Selector(childNodes);

        // Inverter
        // Define the child node first
        an_checkEnemies = new ActionNode(CheckForEnemies);
        inv_checkEnemies = new Inverter(an_checkEnemies);

        // EatFood
        an_eatFood = new ActionNode(EatFood);

        // Step 5: Store all nodes as children of the root node
        childNodes.Clear();
        childNodes.Add(an_checkHunger);
        childNodes.Add(selector_checkInventory);
        childNodes.Add(inv_checkEnemies);
        childNodes.Add(an_eatFood);
        // Add all childNodes to rootNode as constructor
        rootNode = new Sequence(childNodes);
    }

    private void Update()
    {
        // Step 6: Simply call the Evaluate function of the root node
        rootNode.Evaluate();
    }

    // You can declare all action node functions here

    private NodeState CheckHunger()
    {
        Debug.Log(hunger.IsHungry());
        return hunger.IsHungry() ? NodeState.SUCCESS : NodeState.FAILURE;
    }
    

    private NodeState CheckForMeat()
    {
        //return inventory.CheckInventory("Meat");
        return inventory.CheckInventoryForMeat();
    }

    private NodeState CheckForVegetables()
    {
        return inventory.CheckInventory("Vegetable");
    }
    private NodeState CheckForFruits()
    {
        return inventory.CheckInventory("Fruit");
    }

    private NodeState CheckForEnemies()
    {
        return awareness.IsEnemyAround() ?
            NodeState.SUCCESS :
            NodeState.FAILURE;
    }
    private NodeState EatFood()
    {
        hunger.Eat(100);
        return NodeState.SUCCESS;
    }
}
