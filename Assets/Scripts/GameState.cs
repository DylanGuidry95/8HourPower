using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public List<GameObject> Levels;    
    public GameObject ActiveObj;
    public GameObject CurrentLevelObject;
    public LevelProgress CurrentLevel;

    private void Start()
    {
        Events.PlayerDied.AddListener(ResetPlayer);
        Events.KillBoxHit.AddListener(ResetPlayer);
        Events.LevelCompleted.AddListener(NextLevel);
        Events.PlayerOutOfLives.AddListener(GameOver);
        Events.StartLevel.AddListener(StartLevel);
    }    

    void StartLevel()
    {
        CurrentLevelObject = Instantiate(Levels[0]) as GameObject;
        ActiveObj = Levels[0];
        CurrentLevel = CurrentLevelObject.GetComponent<LevelProgress>(); ;
        ResetPlayer();
    }

    [ContextMenu("Reset")]
    private void ResetPlayer()
    {
        Events.ResetPlayerMovement.Invoke(
            new Vector3(CurrentLevel.ActiveCheckPoint.transform.position.x,
            CurrentLevel.ActiveCheckPoint.transform.position.y, 0));
        Events.PlayerRespawned.Invoke();
    }

    void NextLevel()
    {
        Events.LevelCompleteFade.Invoke();
        if(Levels.IndexOf(ActiveObj) != Levels.Count - 1)
        {            
            Destroy(CurrentLevelObject);
            CurrentLevelObject = Instantiate(Levels[Levels.IndexOf(CurrentLevelObject) + 2]) as GameObject;
            ActiveObj = Levels[Levels.IndexOf(ActiveObj) + 1];
            CurrentLevel = CurrentLevelObject.GetComponent<LevelProgress>();
            ResetPlayer();
        }
        else
        {            
            Events.GameWin.Invoke();
        }
    }    

    void GameOver()
    {        
        Events.GameOver.Invoke();
    }    
}
