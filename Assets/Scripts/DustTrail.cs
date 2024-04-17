using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField] private ParticleSystem dustParticles;

    private void OnCollisionEnter2D(Collision2D _collision)
    {
        if(_collision.gameObject.tag == "Ground")
        {
            dustParticles.Play();
        }
    }
    private void OnCollisionExit2D(Collision2D _collision)
    {
        if (_collision.gameObject.tag == "Ground")
        {
            dustParticles.Stop(); 
        }
    }
}
