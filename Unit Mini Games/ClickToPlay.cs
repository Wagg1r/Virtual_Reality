using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToPlay : MonoBehaviour
{
    AudioSource audio;
    public float spinSpeed = 100.0f;

    Color randomColor;
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.enabled = false;

        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        SoundOnClick();
        AnimationOnClick();

        randomColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));


    }
    void SoundOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray rayFromMouse = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitFromRay;

            if (Physics.Raycast(rayFromMouse.origin, rayFromMouse.direction, out hitFromRay))
            {
                if (hitFromRay.transform == this.transform)
                {
                    audio.enabled = true;
                }
                else audio.enabled = false;
            }
        }
    }
    void AnimationOnClick()
    {
        if (audio.enabled == true)
        {
            transform.Rotate(0, spinSpeed * Time.deltaTime, 0, Space.Self);
            rend.material.color = randomColor;

        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            rend.material.color = Color.white;
        }
    }
}
