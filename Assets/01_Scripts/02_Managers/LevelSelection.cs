using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    [SerializeField] private Scenes GoToScene;


    public void OpenScene()
    {
        SceneManager.LoadScene((int)GoToScene);
    }
    
}
