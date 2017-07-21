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
        Debug.Log("You WIN!!");
        // if (LevelManager.Level == 3) 
        SceneManager.LoadScene("Piper-Win");
        // else if (LevelManager.Level < 3) {
            // LevelManager.NextLevel() ;
            // SceneManager.LoadScene("Level1");
        // }
    }

    public override void AddNextPipe(GameObject pipe) {
        //Do nothing
    }
}