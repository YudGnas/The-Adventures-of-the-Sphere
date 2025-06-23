using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] public MeshRenderer _renderer;
    public Node _node;
    public MeshRenderer Renderer_key;

    void Start()
    {
        _renderer = Renderer_key;
    }

    
    void Update()
    {
        
    }


    public void SetGate(Node node)
    {
        if (_node != null) _node._gate = null;

        _node = node;
        _node._gate = this;
    }
}
