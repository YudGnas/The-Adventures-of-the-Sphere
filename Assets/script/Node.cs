using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Vector3 Pos => transform.position;
    public Player _player;
    public MeshRenderer _renderer;
    public Gate _gate;
    public Block _block;
    public Box _box;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Finish")
        {
            Gate gate = collision.gameObject.GetComponent<Gate>();
            if(gate != null)
            {
                Debug.Log("done");
                gate.SetGate(this);
            }
            
        }
    }
}
