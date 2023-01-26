using UnityEngine;
using System.Collections;

public class AudioTest : MonoBehaviour
{
    public AudioClip clip;
    public float[] allSamples;

    void Start()
    {
        allSamples = new float[clip.samples * clip.channels];
        clip.GetData(allSamples, 0);
    }
}