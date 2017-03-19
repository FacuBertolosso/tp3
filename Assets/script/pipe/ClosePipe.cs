using UnityEngine.SceneManagement;

public class ClosePipe : Pipe
{
    public override void FillNext()
    {
        print("You WIN!!");
        SceneManager.LoadScene("win_Game");
    }
}