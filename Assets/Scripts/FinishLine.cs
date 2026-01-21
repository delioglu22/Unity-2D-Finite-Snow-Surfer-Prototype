using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float delay = 1f; 
    [SerializeField] ParticleSystem finishparticles;
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
    void OnTriggerEnter2D(Collider2D collision) {

        int layerIndex = LayerMask.NameToLayer("Player");
        if (collision.gameObject.layer == layerIndex)
        {
            finishparticles.Play();
            Invoke("ReloadScene", delay);
        }

    }
}
