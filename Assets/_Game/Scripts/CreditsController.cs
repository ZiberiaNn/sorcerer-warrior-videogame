using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsController : MonoBehaviour
{
    public AnimationClip _animation;
    private SoundManager soundManager;
    public void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        if (soundManager != null)
        {
            soundManager.Play("Background8");
        }
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(soundManager!=null) soundManager.Stop("Background" + SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene(0);  
        }
    }
    public void VolverEscenaAnterior()
    {
        if (soundManager != null) soundManager.Stop("Background" + SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(0);
    }
}
