using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
public class VillagerBT : BehaviorTree.BehaviorTree
{

    [SerializeField]
    private float _speed = 20;

    [SerializeField]
    private float _walkingDistance = 10;

    protected override Node SetUpTree()
    {
        //Node root = new RandomWalk(transform, 200);

        Node root = new Sequence(new List<Node> {
            new RandomWalk(this.transform)
            }
            );

        root.SetData("VillagerSpeed", _speed);
        root.SetData("WalkingDistance",_walkingDistance);
        return root;
    }
}
