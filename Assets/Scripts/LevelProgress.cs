using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProgress : MonoBehaviour
{
    public List<CheckPoint> CheckPoints;
	public CheckPoint ActiveCheckPoint;
    public CheckPoint StartPoint;
    public CheckPoint GoalPoint;

    private void Awake()
    {
        ActiveCheckPoint = StartPoint;       
    }

    private void Start()
    {
        Events.CheckPointReachd.AddListener(ChangeActiveCheckpoint);
    }

    void ChangeActiveCheckpoint(CheckPoint cheackpoint)
    {
        ActiveCheckPoint = cheackpoint;
        if (ActiveCheckPoint == GoalPoint)
            Events.LevelCompleted.Invoke();
    }
}
