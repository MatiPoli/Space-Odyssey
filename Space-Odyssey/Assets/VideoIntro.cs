﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
 
public class VideoIntro : MonoBehaviour
{

    private VideoPlayer vid;
    private float beginning;

    void Awake()
    {
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
