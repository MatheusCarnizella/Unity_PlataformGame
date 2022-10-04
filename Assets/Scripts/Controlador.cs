using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controlador : MonoBehaviour
{
    public GameObject Fim;

    public static Controlador Control;
    // Start is called before the first frame update
    void Start()
    {
        Control = this;
    }

    public void FimdoJogo()
    {
        Fim.SetActive(true);
    }

    public void ResetGame(string level)
    {
        SceneManager.LoadScene(level);
    }
}
