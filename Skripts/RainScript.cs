using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainScript : MonoBehaviour
{
    private ParticleSystem ps;
    private bool isRaining = false;
    public Light brightnes;
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        StartCoroutine(Weather());
    }

    private void Update()
    {
        if(isRaining && brightnes.intensity > 0.5f)
        {
            intensityChange(-1);
        }
        else if(!isRaining && brightnes.intensity < 1f)
        {
            intensityChange(1);
        }
    }

    private void intensityChange(int v)
    {
        brightnes.intensity += v * Time.deltaTime * 0.1f;
        if(isRaining)
        {
            AudioManager.instance.Play("Rain");
        }
        else if(!isRaining)
        {
            AudioManager.instance.Stop("Rain");
        }
    }

    IEnumerator Weather()
    {
        while (true)
        {

            yield return new WaitForSeconds(Random.Range(30f, 35f));

            if (isRaining)
            {
                ps.Stop();
            }
            else if (!isRaining)
            {
                ps.Play();
            }

            isRaining = !isRaining;
        }
    }
}
