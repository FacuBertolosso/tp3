using System;

public interface FillingState
{
	bool isFilling ();
	bool isFilled ();
	void update (Pipe pipe);
}

