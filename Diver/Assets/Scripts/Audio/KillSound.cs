using UnityEngine;

public class KillSound : MonoBehaviour
{
    AudioSource sourse;

    void Start()
    {
        sourse = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        if (!sourse.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
