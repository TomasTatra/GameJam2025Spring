using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BehaviorTree
{
    public class Timer : Node
    {
        private float _delay;
        private float _time;

        public delegate void TickEnded();
        public event TickEnded OnTickEnded;

        public Timer(float delay, TickEnded onTickEnded = null) : base() 
        {
            _delay = delay;
            _time = _delay;
            this.OnTickEnded = onTickEnded;
        }

        public Timer(float delay, List<Node> children, TickEnded onTickEnded = null) : base(children)
        {
            _delay = delay;
            _time = _delay;
            this.OnTickEnded = onTickEnded;
        }

        public override NodeState Evaluate()
        {
            if (HasChildren)
            {
                return NodeState.FAILURE;
            }

            if (_time <= 0)
            {
                _time = _delay;
                state = children[0].Evaluate();
                if (OnTickEnded != null)
                {
                    OnTickEnded();
                    state = NodeState.SUCCESS;
                }
            }
            else
            {
                _time -= Time.deltaTime;
                state = NodeState.RUNNING;
            }

            return state;
        }
    }

}