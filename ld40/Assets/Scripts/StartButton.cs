using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class StartButton : MonoBehaviour {

	// Use this for initialization
    public void QuitGame()
    {
        transform.GetChild(2).GetComponent<AudioSource>().Play();
        Debug.Log("bye");
        Application.Quit();
    }
    
	public void PlayGame()
    {
        SceneManager.LoadScene(1);
        transform.GetChild(2).GetComponent<AudioSource>().Play();
    }
}
