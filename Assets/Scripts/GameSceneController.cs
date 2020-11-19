using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneController : MonoBehaviour
{
    public static GameSceneController Instance;
    [SerializeField] GameObject defeatUI;
    [SerializeField] GameObject winUI;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Defeat()
    {
        defeatUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void Win()
    {
        winUI.SetActive(true);
        Time.timeScale = 0;
    }
}
