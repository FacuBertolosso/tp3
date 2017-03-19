using System;

public interface FillingState
{
	 bool IsFilling ();
	 bool IsFilled ();
	 void Update (Pipe pipe);
}

