using Unity.VisualScripting;
using UnityEditor.Timeline;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    [SerializeField] PowerupSo powerup;
    PlayerController player;
    SpriteRenderer spriteRenderer;
    float timeLeft;

    void Start()
    {
        player = FindFirstObjectByType<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        float timeLeft = powerup.Gettime();
    }
    void Update()
    {
        CountdownTimer();
    }
    void CountdownTimer()
    {
        if(spriteRenderer.enabled == false) {
            if(timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                print(timeLeft);
                if(timeLeft <= 0)
                {
                    player.DeactivatePowerup(powerup);
                }
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Player");
        if (collision.gameObject.layer == layerIndex && spriteRenderer.enabled)
        {
            player.ActivatePowerup(powerup);
            spriteRenderer.enabled = false;
            timeLeft = powerup.Gettime();
        }
    }
}
