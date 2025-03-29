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
        protected NodeState state;

        public Node Parent;
        public Node Root;

        protected List<Node> children = new List<Node>();

        private Dictionary<string, object> dataContext = new Dictionary<string, object>();

        public bool HasChildren => children.Count > 0;
        public Node()
        {
            Parent = null;
            Root = this;
        }

        public Node(List<Node> children, bool bForceRoot = false)
        {
            foreach (var child in children)
            {
                AttachChild(child);
            }
            if (bForceRoot)
            {
                Root = this;
            }
        }

        

        private void AttachChild(Node node)
        {
            node.Parent = this;
            children.Add(node);
        }

        private void SetRoot(Node node)
        {
            Root = node;
            foreach (Node child in children)
            {
                child.SetRoot(Root);
            }
        }

        public virtual NodeState Evaluate() => NodeState.FAILURE;

        public void SetData(string key, object value)
        {
            dataContext[key] = value;
        }

        public object GetData(string key)
        {
            object value = null;
            if (dataContext.TryGetValue(key,out value))
            {
                return value;
            }

            Node node = Parent;
            while (node != null)
            {
                value = node.GetData(key);
                if (value != null)
                {
                    return value;
                }
                node = node.Parent;
            }

            return null;
        }

        public bool ClearData(string key)
        {
            object value = null;
            if (dataContext.TryGetValue(key, out value))
            {
                return dataContext.Remove(key);
            }

            Node node = Parent;
            while (node != null)
            {
                if (node.ClearData(key))
                {
                    return true;
                }
                node = node.Parent;
            }

            return false;
        }
    }
}