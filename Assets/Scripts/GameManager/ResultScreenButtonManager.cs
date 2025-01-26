using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ResultScreenButtonManager : MonoBehaviour
{
    private int activeSceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        activeSceneIndex = PlayerPrefs.GetInt("ActiveSceneIndex", 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RestartScene()
    {

        SceneManager.LoadScene(activeSceneIndex);
    }
}
