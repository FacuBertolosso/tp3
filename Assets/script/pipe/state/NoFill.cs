using System;

public class NoFill : FillingState
{
	private static readonly FillingState instance = new NoFill();
	private NoFill ()
	{
	}
	public bool IsFilling ()
	{
	return false;
	}
	public bool IsFilled ()
	{
	return false;
	}
	public void Update (Pipe pipe)
	{
	}
	public static FillingState Instance
	{
		get 
		{
			return instance; 
		}
	}
}


