using UnityEngine.SceneManagement;
using UnityEngine;

public class ClosePipe : Pipe
{
    public override void Start()
    {
        base.Start();
        IsFixed = true;
    }

    public override void FillNext()
    {
        print("You WIN!!");
        if (LevelManager.Level == 3) 
            SceneManager.LoadScene("win_Game");
        else if (LevelManager.Level < 3) {
            LevelManager.NextLevel() ;
            SceneManager.LoadScene("Level1");
        }
    }

    public override void AddNextPipe(GameObject pipe) {
        //Do nothing
    }
}