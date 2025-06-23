using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keynode_Player : MonoBehaviour
{
    [SerializeField] public Player _player;
    [SerializeField] public Node _node;
    private bool _isActive = false;
    void Start()
    {
        _player.GetComponent<Player>().enabled = false;
    }
    void Update()
    {
        if (_node._player != null || _node._box != null)
        {   
            if( _isActive == false)
            {
                activate();
                _isActive = true;
            }
            
        }
        else
        {
            deactivate();
            _player.GetComponent<Player>().enabled = false;
            _isActive = false;
        }
    }
    public void activate()
    {
        _player.GetComponent<Player>().enabled = true;
        _player._status = Status.open;
    }
    public void deactivate()
    {   
        _player._status = Status.close;
                      
    }
}
