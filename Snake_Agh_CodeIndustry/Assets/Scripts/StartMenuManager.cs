using UnityEngine.SceneManagement;
using UnityEngine;

public class StartMenuManager : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("Scene1");
        }
    }
}
