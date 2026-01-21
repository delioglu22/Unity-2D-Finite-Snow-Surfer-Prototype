using UnityEngine;
using UnityEngine.SceneManagement;
public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delay = 1f;
    [SerializeField] ParticleSystem crashparticles;
     
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
    void OnTriggerEnter2D(Collider2D collision) {

        int layerIndex = LayerMask.NameToLayer("Floor");
        if (collision.gameObject.layer == layerIndex)
        {
            crashparticles.Play();
            Invoke("ReloadScene", delay);
        }
    }

}
