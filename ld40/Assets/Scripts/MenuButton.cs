using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuButton : MonoBehaviour {
    // Use this for initialization
    public void Pressed()
    {
        transform.GetChild(3).GetComponent<AudioSource>().Play();
        SceneManager.LoadScene(0);

    }
}
