using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;
public class FindNearestObject : Node
{

    private Transform _character;

    private GameObject[] _objects;
    public FindNearestObject(Transform character, GameObject[] objects)
    {
        _character = character;
        _objects = objects;
    }

    public override NodeState Evaluate()
    {
        if (Root.GetData("nearestObject") == null)
        {
            float nearestDistance = -1;
            GameObject nearestObject = null;
            foreach (var obj in _objects)
            {
                float distance = (obj.transform.position - _character.transform.position).magnitude;

                // If it isnt initialized or there is a closer object then set it
                if (nearestDistance == -1 || nearestDistance >= distance)
                {
                    nearestDistance = distance;
                    nearestObject = obj;
                }
            }

            Root.SetData("nearestObject", nearestObject);
        }

        state = NodeState.SUCCESS;
        return state;
    }
}