using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public abstract class BehaviorTree : MonoBehaviour
    {
        protected Node root = null;

        protected void Start()
        {
            root = SetUpTree();
        }

        private void Update()
        {
            if (root != null)
            {
                root.Evaluate();
            }
        }
        protected abstract Node SetUpTree();
    }
}
