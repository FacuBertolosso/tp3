using System;

public class OpenPipe : Pipe
{
    public override void Start()
    {
        base.Start();
        IsFixed = true;
    }

}