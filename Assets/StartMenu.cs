using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class StartMenu : SecuredBehaviourScript
{

    public string selectedButton;

    public override void AwakeCustom()
    {
        return;
    }
       
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Do1Clicked()
    {
        base.ShowOnClickMethodsOnScreen();
    }

    public void Do2Clicked()
    {
        base.ShowOnClickMethodsOnScreen();
    }

    public void Do3Clicked()
    {
        base.ShowOnClickMethodsOnScreen();
    }

    public void StartGame2()
    {
        StartGame();
    }

}
