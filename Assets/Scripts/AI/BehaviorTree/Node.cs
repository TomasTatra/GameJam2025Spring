using System.Collections;
using System.Collections.Generic;


namespace BehaviorTree
{
    public enum NodeState
    {
        SUCCESS,
        RUNNING,
        FAILURE
    }
    public class Node
    {
        protected Node state;

        public Node parent;

    }
}