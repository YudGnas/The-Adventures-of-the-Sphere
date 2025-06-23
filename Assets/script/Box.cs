using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Box : MonoBehaviour
{
    public Node _node;
    public Creat_Game _map;
    public List<Node> list_node;
    public bool can_push=true;
    [SerializeField] private float _travelTime = 0.2f;
    
    void Start()
    {
        list_node = _map.nodes;
    }

    public void SetBox(Node node)
    {
        if(_node._box != null) _node._box = null;
        
        _node = node;
        _node._box = this;
    }
    public void push_box(Vector3 dir)
    {
        Node currentNode = GetTileAtIntPosition(this._node.Pos);
        Node targetNode = GetTileAtIntPosition(currentNode.Pos + dir);
        Debug.Log(targetNode.Pos.x);
        
        if (targetNode._player == null && targetNode._block == null && 
            (targetNode._gate == null || targetNode._gate._renderer == null))
        {   
            can_push = true;
            // Di chuyển box
            transform.DOMove(targetNode.Pos + new Vector3(0, (float)0.6, 0), _travelTime);

        }
        else can_push = false;
    
    }
    Node GetTileAtIntPosition(Vector3 pos)
    {
        Vector3Int intPos = Vector3Int.RoundToInt(pos);      
        return list_node.FirstOrDefault(n =>
        {
            Vector3Int nodePos = Vector3Int.RoundToInt(n.Pos);
            return nodePos.x == intPos.x && nodePos.z == intPos.z;
        });
    }
}
