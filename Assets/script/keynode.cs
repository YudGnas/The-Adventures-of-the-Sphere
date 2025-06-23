using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyNode : MonoBehaviour
{
    public Node _node;

    public GameObject gate;
    public Gate _gate;
    void Start()
    {
        
    }
    void Update()
    {
        if(_node._player != null || _node._box != null)
        {
            activate();
        }
        else
        {
            deactivate();
        }
    }

    public void activate()
    {
        _gate._renderer = null;
        gate.SetActive(false);
    }
    public void deactivate()
    {
        gate.SetActive(true);
        _gate._renderer = _gate.Renderer_key;
    }

}
