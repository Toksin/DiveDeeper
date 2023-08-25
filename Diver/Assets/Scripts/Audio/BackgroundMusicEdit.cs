using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicEdit : MonoBehaviour
{
    DepthCounter depth;
    private int zoneBorder;

  

    void Start()
    {
        depth = FindFirstObjectByType<DepthCounter>();
        AudioManager.instance.PlayMusic("firstLayerBack");
    }

    void StartPlayComposition()
    {
        if(depth.depth * -1 > 52 && depth.depth * -1 < 150) 
        {
            AudioManager.instance.PlayMusic("firstLayerBack");
            
        }       
    }

    private void Update()
    {
      // StartPlayComposition();
    }
}
