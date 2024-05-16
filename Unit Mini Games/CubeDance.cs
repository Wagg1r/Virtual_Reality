using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDance : MonoBehaviour
{
    public AudioPeer peer;
    public int frequencyBand = 0;
    public float multiplier = 3.0f;
    public Vector3 bumpDimensions =  new Vector3 (0, 1, 0);

    private Vector3 baseScale;
    private Material material;

    Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        baseScale = transform.localScale;
        material = GetComponent<MeshRenderer>().material;
        //startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float bounce = peer.GetAudioBand(frequencyBand);
        transform.localScale = baseScale + bumpDimensions * peer.GetFrequencyBand(frequencyBand) * multiplier;

        Color color = new Color(bounce, bounce * .4f, bounce * .3f);
        material.SetColor("_EmissionColor",color);
        material.EnableKeyword("_EMISSION");

        //transform.position = startPos + new Vector3(0, bounce, 0);
    }
}
