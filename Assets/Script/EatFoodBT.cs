using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EatFoodBT : MonoBehaviour
{
    // Step 1: Declare references to other scripts
    private Hunger hunger;
    private Inventory inventory;
    private Awareness awareness;


    // Step 2: Declare all the nodes. The root node is a Sequence
    private Sequence rootNode;
    private ActionNode an_checkHunger;
    private Selector selector_checkInventory;
    private ActionNode an_meat;
    private ActionNode an_vegs;
    private ActionNode an_fruits;
    private Inverter in_enemyNear;
    private ActionNode an_enemyNear;
    private ActionNode an_eat;

    private void Awake()
    {
        // Step 3: Get Components of all action-related nodes
        hunger = GetComponent<Hunger>();
        inventory = GetComponent<Inventory>();
        awareness = GetComponent<Awareness>();
        Player player = GetComponent<Player>();
        Enemy enemy = GetComponent<Enemy>();
    }

    private void Start()
    {
        // Step 4: Make the behavior tree. Use the constructors to
        // build up instances each node. It is better to build up
        // the tree from the children nodes all the way up to the
        // parent nodes

        an_checkHunger = new ActionNode(CheckHunger);
        an_meat = new ActionNode(inventory.CheckInventoryForMeat);
        an_vegs = new ActionNode(inventory.CheckInventoryForVegs);
        an_fruits = new ActionNode(inventory.CheckInventoryForFruits);
        an_eat = new ActionNode(Eat);
        an_enemyNear = new ActionNode(CheckEnemy);

        List<Node> selectorNodes = new();
        selectorNodes.Add(an_meat);
        selectorNodes.Add(an_vegs);
        selectorNodes.Add(an_fruits);
        selector_checkInventory = new Selector(selectorNodes);

        in_enemyNear = new Inverter(an_enemyNear);
        // Step 5: Store all nodes as children of the root node
        List<Node> childrenNodes = new();
        childrenNodes.Add(an_checkHunger);
        childrenNodes.Add(selector_checkInventory);
        childrenNodes.Add(in_enemyNear);
        childrenNodes.Add(an_eat);
        rootNode = new Sequence(childrenNodes);
    }

    private void Update()
    {
        // Step 6: Simply call the Evaluate function of the root node
       rootNode.Evaluate();
           
    }

    // You can declare all action node functions here
    // Example only:

    private NodeState CheckHunger()
    {
        return hunger.IsHungry() ? NodeState.SUCCESS : NodeState.FAILURE;
    }
    
    private NodeState Eat(){
        hunger.SetHunger(100);
        return NodeState.SUCCESS;
    }
    private NodeState CheckEnemy(){
        return awareness.IsEnemyAround() ? NodeState.SUCCESS : NodeState.FAILURE ;
    }
}
