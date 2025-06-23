using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;
using DG.Tweening;


public enum Status
{
    open,
    close,
    inside,
}

public class Player : MonoBehaviour
{
    [SerializeField] public Transform Pos_Open, Pos_Close;
    [SerializeField] public Sound_effect sound_Effect;
    public Node _node;
    public Node CurrentNode => _node;
    public MeshRenderer _renderer;

    public Creat_Game map;
    public GameObject top;
    public Player Dad_player, Parent_player;

    public List<Node> list_node;
    public Status _status;
    [SerializeField] private float _travelTime = 0.2f;
    [SerializeField] private Main_Camera _camera;
    private void Start()
    {
        list_node = map.nodes;
    }
    void Update()
    {   
        if (_status == Status.close) top.transform.position = Pos_Close.position;
        else if (_status == Status.open) top.transform.position = Pos_Open.position;
        if(_status == Status.close || (_status == Status.inside && Dad_player._status == Status.open))
        {
            if (Input.GetKeyUp(KeyCode.S)) Move(Vector3.right);
            if (Input.GetKeyUp(KeyCode.W)) Move(Vector3.left);
            if (Input.GetKeyUp(KeyCode.A)) Move(Vector3.back);
            if (Input.GetKeyUp(KeyCode.D)) Move(Vector3.forward);
            if(Input.GetKeyUp(KeyCode.E) && Parent_player != null) separation();
        }
        if(_status == Status.inside) transform.position = Dad_player.transform.position;        
    }
    void Move(Vector3 dir)
    {
        var sequence = DOTween.Sequence();
        Node currentNode = GetTileAtIntPosition(this._node.Pos);
        Node targetNode = GetTileAtIntPosition(currentNode.Pos + dir );
        if(targetNode != null && targetNode._block == null)
        {
            if(targetNode._box != null)
            {
                targetNode._box.push_box(dir);
                Debug.Log("can_push sau khi push: " + targetNode._box.can_push);
                if (targetNode._box.can_push == true)
                {
                    transform.DOMove(targetNode.Pos + new Vector3(0, (float)0.5, 0), _travelTime);
                    if (_status == Status.inside)
                    {
                        _status = Status.close;
                        if (currentNode._player == this) currentNode._player = Dad_player;
                        targetNode._player = this;
                        _node = targetNode;
                        Dad_player.Parent_player = null;
                        Dad_player = null;

                    }
                    else if (_status == Status.close)
                    {
                        if (currentNode._player == this) currentNode._player = null;
                        targetNode._player = this;
                        _node = targetNode;
                    }
                    Node next = GetTileAtIntPosition(targetNode.Pos + dir);
                    targetNode._box.SetBox(next);

                }

            }
            else if (targetNode._player != null && targetNode._player._status == Status.open)
            {
                sound_Effect.Close_sound();
                enter(targetNode._player);
                Dad_player = targetNode._player;
                Dad_player.Parent_player = this;
                Debug.Log("enter");
                currentNode._player = null;
            }
            else if (targetNode._gate == null || targetNode._gate._renderer == null || targetNode._gate._renderer.material.color == _renderer.material.color)
            {
                transform.DOMove(targetNode.Pos + new Vector3(0, (float)0.5, 0), _travelTime);

                if (_status == Status.inside)
                {
                    _status = Status.close;
                    if (currentNode._player == this) currentNode._player = Dad_player;
                    targetNode._player = this;
                    _node = targetNode;
                    Dad_player.Parent_player = null;
                    Dad_player = null;
                }
                else if (_status == Status.close)
                {
                    if (currentNode._player == this) currentNode._player = null;
                    targetNode._player = this;
                    _node = targetNode;
                }
            }
        }
    }
    public void separation()
    {   
        sound_Effect.Open();
        _status = Status.open;
        Parent_player._status = Status.inside;
        _node._player = Parent_player;
        
        Parent_player._node = _node;
        _camera.Player = Parent_player;
    }
    public void enter(Player player)
    {
        _status = Status.inside;
        player._status = Status.close;       
    }



    public void SetPlayer(Node node)
    {
        if (_node != null) _node._player = null;

        _node = node;
        _node._player = this;
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
