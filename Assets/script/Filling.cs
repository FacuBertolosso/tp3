using System;


public class Filling : FillingState
{
	private static readonly FillingState instance = new Filling();
	private Filling ()
	{
	}
	public bool isFilling ()
	{
		return true;
	}
	public bool isFilled ()
	{
		return false;
	}
	public void update (Pipe pipe)
	{
		pipe.IncrementCurentTime();
		if ((pipe.GetCurrentTime() < pipe.fillingTime) && ((pipe.GetCurrentTime() - pipe.GetLastTime()) > pipe.frequency))
		{
			pipe.UpdateLastTime();
			pipe.SwapMaterial();
		}
		if (pipe.TimeText != null) pipe.TimeText.text = ((int) pipe.GetLastTime()).ToString();
		if (pipe.GetCurrentTime() > pipe.fillingTime) {
			pipe.SetFilligState (Filled.Instance);
			pipe.FillNext();
		}	
	}
	public static FillingState Instance
	{
		get 
		{
			return instance; 
		}
	}
}


