public class Filled : FillingState
{
	private static readonly FillingState instance = new Filled();
	private Filled ()
	{
	}
	public bool isFilling ()
	{
		return false;
	}
	public bool isFilled ()
	{
		return true;
	}
	public void update (Pipe pipe)
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

