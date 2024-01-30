using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeOfScene : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            ChangeOfSceneMenu();
        }
    }
    public void ChangeOfSceneMenu()
    {
        SceneManager.LoadScene("Game");
    }
}
