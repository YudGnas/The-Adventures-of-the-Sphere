using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepOnlyLight : MonoBehaviour
{
    void Awake()
    {
        GameObject[] lights = GameObject.FindGameObjectsWithTag("MainLight");

        if (lights.Length > 1)
        {
            Destroy(gameObject); // Xóa cái dư
            Debug.Log("is remove");
        }
        else
        {
            DontDestroyOnLoad(gameObject); // Chỉ giữ một ánh sáng
        }
    }
}
