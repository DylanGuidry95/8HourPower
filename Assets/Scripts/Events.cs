using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Events : MonoBehaviour
{
    //Braodcast from player
    public static PlayerEvent PlayerDamaged = new PlayerEvent();
    public static PlayerEvent PlayerDied = new PlayerEvent();
    public static PlayerEvent PlayerAtMaxHealth = new PlayerEvent();
    public static PlayerEvent PlayerOutOfLives = new PlayerEvent();
    public static PlayerEvent PlayerGrounded = new PlayerEvent();
    public static UIInfoEvent PlayerHealthChanged = new UIInfoEvent();
    public static UIInfoEvent PlayerLivesChanged = new UIInfoEvent();

    //Listen by player
    public static PlayerEvent PlayerRespawned = new PlayerEvent();
    public static PlayerEvent LivesRemainingIncrease = new PlayerEvent();
    public static PlayerEvent HealthPickedUp = new PlayerEvent();

    //Broadcast from Checkpoint
    public static CheckPointEvent CheckPointReachd = new CheckPointEvent();

    //Broadcast from KillBox
    public static KillBoxEvent KillBoxHit = new KillBoxEvent();

    //Broadcast from the Level
    public static LevelEvent LevelCompleted = new LevelEvent();

    //Broadcast from GameState
    public static UIEvent LevelCompleteFade = new UIEvent();
    public static PlayerMovementEvent ResetPlayerMovement = new PlayerMovementEvent();
    public static GameEvent GameWin = new GameEvent();
    public static GameEvent GameOver = new GameEvent();

    //Broadcast from UI
    public static GameEvent StartLevel = new GameEvent();

    //Broadcast from Enemy
    public static EnemyEvent AttackPlayer = new EnemyEvent();
}

public class PlayerEvent : UnityEvent { }
public class PlayerMovementEvent : UnityEvent<Vector3> { }

public class CheckPointEvent : UnityEvent<CheckPoint> { }

public class KillBoxEvent : UnityEvent { }

public class LevelEvent : UnityEvent { }

public class UIEvent : UnityEvent { }

public class UIInfoEvent : UnityEvent<int> { }

public class GameEvent : UnityEvent { }

public class EnemyEvent : UnityEvent { }