using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportationgate : MonoBehaviour
{
    [SerializeField] public Node _node;
    [SerializeField] public teleportationgate _telenode;
    [SerializeField] public Sound_effect sound_Effect;
    public bool _istele;
    void Start()
    {
        
    }

    void Update()
    {
        if(_node._player != null && _istele == false)
        {
            sound_Effect.Teleport();
            _node._player.transform.DOMove(_telenode._node.Pos + new Vector3(0, (float)0.5, 0), (float)0.2);
            _node._player.SetPlayer(_telenode._node);
            _telenode._istele = true;
        }
        if(_node._player == null) _istele = false;
    }
}
