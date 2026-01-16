using UnityEngine;
using UnityEngine.SceneManagement;

public class IndexManager : MonoBehaviour
{
    
    public void LoadMap1()
    {
        SceneManager.LoadScene("Map_Grassland");
    }

    public void LoadMap2()
    {
        SceneManager.LoadScene("Map_Desert");
    }

    public void LoadMap3()
    {
        SceneManager.LoadScene("Map_Snow");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
