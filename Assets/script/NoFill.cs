using System;

public class NoFill : FillingState
{
	private static readonly FillingState instance = new NoFill();
	private NoFill ()
	{
	}
	public bool isFilling ()
	{
	return false;
	}
	public bool isFilled ()
	{
	return false;
	}
	public void update (Pipe pipe)
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


