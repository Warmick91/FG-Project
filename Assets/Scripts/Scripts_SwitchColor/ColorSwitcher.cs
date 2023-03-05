using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwitcher : MonoBehaviour
{
    private MeshRenderer ballRenderer;
    private ParticleSystem ballParticles;
    private MeshRenderer cubeRenderer;
    private ParticleSystem cubeParticles;

    void Awake()
    {
        // Check if the object ball exists and add its required elements to variables.
        GameObject ball = GameObject.Find("Ball");
        if (ball != null)
        {
            ballRenderer = ball.GetComponent<MeshRenderer>();
            ballParticles = ball.transform.Find("ColorChangeParticles").GetComponent<ParticleSystem>();
        }
        else
        {

            Debug.LogError("The ball not found in the present scene");
        }

        // Add the cube's required elements to variables
        cubeRenderer = GetComponent<MeshRenderer>();
        cubeParticles = transform.Find("ColorChangeParticles").GetComponent<ParticleSystem>();

    }

    void OnMouseDown()
    {

        // Change the color only after half of the effect has been played
        StartCoroutine(DelayedColorChange(ballParticles, ballRenderer));
        StartCoroutine(DelayedColorChange(cubeParticles, cubeRenderer));

        /* A simple version without delay
        ballRenderer.material.color = CreateNewColor();
        ballParticles.Play();
        cubeRenderer.material.color = CreateNewColor();
        cubeParticles.Play(); */
    }

    IEnumerator DelayedColorChange(ParticleSystem ps, Renderer r)
    {
        ps.Play();
        yield return new WaitForSeconds(ps.main.duration / 2);
        r.material.color = CreateNewColor();
    }

    Color CreateNewColor()
    {
        float r = Random.Range(0f, 1.0f);
        float g = Random.Range(0f, 1.0f);
        float b = Random.Range(0f, 1.0f);
        return new Color(r, g, b);
    }
}
