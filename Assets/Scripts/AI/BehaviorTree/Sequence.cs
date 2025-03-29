using System.Collections;
using System.Collections.Generic;


namespace BehaviorTree
{
    public class Sequence : Node
    {
        public Sequence() : base() { }
        public Sequence(List<Node> children) : base(children) { }
        public override NodeState Evaluate()
        {
            //rework it to make a true Behavior tree
            bool bIsAnyChildRunning = false;
            foreach (Node node in children)
            {
                switch (node.Evaluate())
                {
                    case NodeState.FAILURE:
                        state = NodeState.FAILURE;
                        return state;
                    case NodeState.SUCCESS:
                        continue;
                    case NodeState.RUNNING:
                        bIsAnyChildRunning = true;
                        continue;
                    default:
                        state = NodeState.SUCCESS;
                        return state;
                }
            }
            state = bIsAnyChildRunning ? NodeState.RUNNING : NodeState.SUCCESS;
            return state;
        }
    }

}