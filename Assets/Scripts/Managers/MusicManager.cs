using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource music;

    public bool timeSlow = false;

    public float maxPitch = 1f;
    public float minPitch = 0.5f;

    void FixedUpdate()
    {
        if(timeSlow == false)
        {
            if(music.pitch >= maxPitch) return;
            music.pitch += 0.05f;
        }
        if(timeSlow == true)
        {
            if(music.pitch <= minPitch) return;
            music.pitch -= 0.05f;
        }
    }

    public void NormalPitch()
    {
        timeSlow = false;
    }

    public void SlowPitch()
    {
        timeSlow = true;
    }
}
