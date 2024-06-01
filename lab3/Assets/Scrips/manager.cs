using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class manager : MonoBehaviour
{
    public void play_button()
    {
        SceneManager.LoadScene(1);
    }
    public void quit_button() 
    {
        Debug.Log("im out");
    }
    public void scores_button() 
    {
        Debug.Log("im in scores");
    }
    public void back_button()
    {
        Debug.Log("im back at menu");
    }
}
