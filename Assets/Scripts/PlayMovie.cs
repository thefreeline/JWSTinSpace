using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayMovie : MonoBehaviour
{

    public RawImage rawimage;
    public MovieTexture movie;
    int vsyncprevious;

    // Use this for initialization
    void Start()
    {
        vsyncprevious = QualitySettings.vSyncCount;
        QualitySettings.vSyncCount = 0;

        rawimage.texture = movie;

        if (movie)
        {
            movie.Play();
            movie.loop = true;
        }
        
    }

    void Update()
    {
        if (movie)
        {
            if (movie.isPlaying)
            {
            }
                if (!movie.isPlaying)
            {
                QualitySettings.vSyncCount = vsyncprevious;
            }
        }
            
    }

    public void StopMovie()
    {
        movie.Stop();
    }

    public void StopMovieRemote()
    {
        movie = rawimage.GetComponent<RawImage>().texture as MovieTexture;
        movie.Stop();
    }
}
