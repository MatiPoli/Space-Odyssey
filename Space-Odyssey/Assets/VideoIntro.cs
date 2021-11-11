using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
 
public class VideoIntro : MonoBehaviour
{

    private VideoPlayer vid;
    private float beginning;


    private void Update()
    {
        if (Input.GetKey(KeyCode.Return)) {
            SceneManager.LoadScene("Scenes/Espacio");
        }
    }
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        vid = GetComponent<VideoPlayer>();
        beginning = Time.time;
        vid.Play();
        StartCoroutine(waitmethod());
    }

    IEnumerator waitmethod()
    {
        while (Time.time - beginning < vid.length)
        {
            yield return null;
        }
        SceneManager.LoadScene("Scenes/Espacio");
    }

}
