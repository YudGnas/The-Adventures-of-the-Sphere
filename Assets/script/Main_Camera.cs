using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Camera : MonoBehaviour
{
    [SerializeField] public Player Player;
    [SerializeField] public double x, y, z;
    void Start()
    {
        
    }
    void Update()
    {
        transform.position = Player.transform.position + new Vector3((float)x, (float)y, (float)z);
        transform.LookAt(Player.transform.position);
    }
}
