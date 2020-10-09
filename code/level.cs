using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level : MonoBehaviour
{
    [SerializeField] int breakableblock;
    sceneloader Sceneloader;
    private void Start()
    {
        Sceneloader = FindObjectOfType<sceneloader>();
    }
    public void countbreakableblock()
    {
        breakableblock++;
    }
     public void breakedblock()
    {
        breakableblock--;
        if(breakableblock<=0)
        {
            Sceneloader.SceneLoaders();
        }
    }
  
}
