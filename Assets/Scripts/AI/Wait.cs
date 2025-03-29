using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;
public class WaitNode : Node
{
    float _waitTime;
    float _waitTimer;

   public WaitNode(float time) : base()
    {
        _waitTime = time;
    }

    public override NodeState Evaluate()
    {
        if (_waitTimer > _waitTime)
        {
            state = NodeState.SUCCESS;
            _waitTimer = 0;
        }
        else
        {
            state = NodeState.FAILURE;
            _waitTimer += Time.deltaTime;
        }
        Debug.Log(state);
        return state;
    }
}