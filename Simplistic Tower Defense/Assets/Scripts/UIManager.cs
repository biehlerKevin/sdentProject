using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
}
