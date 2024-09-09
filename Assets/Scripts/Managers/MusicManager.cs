using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource music;

    public void NormalPitch()
    {
        music.pitch = 1f;
    }

    public void SlowPitch()
    {
        music.pitch = 0.5f;
    }
}
