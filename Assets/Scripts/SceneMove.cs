using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    public int sceneNumber;

    public void Open()
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
