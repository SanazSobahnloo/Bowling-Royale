using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
    //BoJack Horseman
    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
    //Rick and Morty
    public void LoadLevel3()
    {
        SceneManager.LoadScene("Level3");
    }
    //Hogwarts
    public void LoadLevel4()
    {
        SceneManager.LoadScene("Level4");
    }
}
