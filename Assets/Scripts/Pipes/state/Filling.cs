using System;
using UnityEngine;


public class Filling : FillingState
{
    private static readonly FillingState instance = new Filling();

    private Filling()
    {
    }

    public bool IsFilling()
    {
        return true;
    }

    public bool IsFilled()
    {
        return false;
    }

    public void Update(Pipe pipe)
    {
        pipe.IncrementCurentTime();
        if ((pipe.GetCurrentTime() < pipe.FillingTime) &&
            ((pipe.GetCurrentTime() - pipe.GetLastTime()) > pipe.Frequency))
        {
            pipe.UpdateLastTime();
            pipe.SwapMaterial();
            pipe.UpdateProgressBar();
        }
        if (pipe.GetCurrentTime() > pipe.FillingTime)
        {
            pipe.SetFilligState(Filled.Instance);
            pipe.FillNext();
        }
    }

    public static FillingState Instance
    {
        get { return instance; }
    }
}