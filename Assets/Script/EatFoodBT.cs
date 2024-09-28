using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatFoodBT : MonoBehaviour
{
    // Step 1: Declare references to other scripts
    private Hunger hunger;


    // Step 2: Declare all the nodes. The root node is a Sequence
    private Sequence rootNode;
    private ActionNode an_checkHunger;
    private Selector selector_checkInventory;

    private void Awake()
    {
        // Step 3: Get Components of all action-related nodes
    }

    private void Start()
    {
        // Step 4: Make the behavior tree. Use the constructors to
        // build up instances each node. It is better to build up
        // the tree from the children nodes all the way up to the
        // parent nodes

        an_checkHunger = new ActionNode(CheckHunger);

        List<Node> selectorNodes = new();
        selectorNodes.Add(an_checkHunger);
        selector_checkInventory = new Selector(selectorNodes);

        // Step 5: Store all nodes as children of the root node
    }

    private void Update()
    {
        // Step 6: Simply call the Evaluate function of the root node
    }

    // You can declare all action node functions here
    // Example only:

    private NodeState CheckHunger()
    {
        return hunger.IsHungry() ? NodeState.SUCCESS : NodeState.FAILURE;
    }
    
}
