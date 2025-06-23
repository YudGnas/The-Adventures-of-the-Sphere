using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public Node _node;
    
    public void SetBlock(Node node)
    {
        if (node != null) _node._block = null;
        
        _node = node;
        _node._block = this;
    }
}
