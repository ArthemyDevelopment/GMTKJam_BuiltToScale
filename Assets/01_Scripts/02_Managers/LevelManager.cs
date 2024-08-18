using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : SingletonManager<LevelManager>
{

    [SerializeField] private List<CharController> LevelChars= new List<CharController>();

    private Dictionary<GameObject, CharController> CharsDataBase= new Dictionary<GameObject, CharController>();

    [SerializeField] private int CharsInGoal;


    public void AddLevelChar(CharController Char)
    {
        LevelChars.Add(Char);
        CharsDataBase.Add(Char.gameObject, Char);
    }
    
    public void StarLevel()
    {
        foreach (CharController Char in LevelChars)
        {
            Char.PlayChar();
        }
        
    }

    public void GameOver()
    {
        foreach (CharController Char in LevelChars)
        {
            Char.StopChar();
        }
        
        GameCanvasController.current?.GameOver();
        Debug.Log("GameOver");
    }


    private void CheckWinCondition()
    {
        if (LevelChars.Count == CharsInGoal)
        {
            GameCanvasController.current?.Win();
            Debug.Log("LevelWin");
        }
    }

    public void CharReachGoal()
    {
        CharsInGoal++;
        CheckWinCondition();
    }

    public CharController GetCharController(GameObject g)
    {
        return CharsDataBase[g];
    }
    
    
    
    

}
