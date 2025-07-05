using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : Singleton<RoadManager>
{
    [SerializeField] private Animator _roadAnimator;

    private void Start()
    {
        OnPlayRoadAnimation();
    }

    public void OnPlayRoadAnimation()
    {
        _roadAnimator.Play("Road Animation");
    }

    public void OnStopRoadAnimation()
    {
        Debug.Log("Stop road animation");
        _roadAnimator.Play("Stop");
    }
}
