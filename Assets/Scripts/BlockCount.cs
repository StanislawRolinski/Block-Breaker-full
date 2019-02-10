using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlockCount : MonoBehaviour
{
    SceneLoader sceneLoader;
    [SerializeField] int breakableBlocks;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void CountBlocks()
    {

        breakableBlocks++;
    }
    
    public void BlockDestroyed()
    {
        breakableBlocks--;
        if(breakableBlocks == 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
