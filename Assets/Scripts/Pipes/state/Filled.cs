public class Filled : FillingState
{
	private static readonly FillingState instance = new Filled();
	private Filled ()
	{
	}
	public bool IsFilling ()
	{
		return false;
	}
	public bool IsFilled ()
	{
		return true;
	}
	public void Update (Pipe pipe)
	{
		if (pipe.HasVoidPipeMaterial())
			pipe.SwapMaterial();
	}
	public static FillingState Instance
	{
		get 
		{
			return instance; 
		}
	}
}

