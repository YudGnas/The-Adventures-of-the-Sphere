using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public Node _node;
    private bool hasFinish;
    public int Level;
    public MeshRenderer _renderer;
    public Sound_effect _effect;
    public AudioSource _audio;
    void Start()
    {
           
    }
    void Update()
    {   
         
        if (Level <=2)
        {
            if (_node._player != null && hasFinish == false)
            {   
                  StartCoroutine(HadFinish());
            }
        }
        else
        {
            if (_node._player != null && hasFinish == false && _node._player._renderer.material.color == _renderer.material.color )
            {
                StartCoroutine(HadFinish());
            }
        }
    }

    IEnumerator HadFinish()
    {
        Debug.Log("Finish!!!");
        hasFinish = true;
        _effect.Finish();
        yield return new WaitForSeconds(_audio.clip.length);
        SceneManager.LoadScene(Level);
    }
}
