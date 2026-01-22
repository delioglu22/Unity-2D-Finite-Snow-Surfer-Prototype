using Unity.Mathematics;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 3f;
    [SerializeField] float baseSpeed = 30f;
    [SerializeField] float boostSpeed = 35f;
    [SerializeField] ParticleSystem powerupParticles;
    [SerializeField] ScoreManager scoreManager;
    InputAction moveAction;
    Rigidbody2D rigidBody;
    Vector2 moveVector;
    SurfaceEffector2D surEff2D;
    bool canControlPlayer = true;
    float previousRotation;
    float totalRotation;
    int flipCount;
    int powerupCount;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        rigidBody = GetComponent<Rigidbody2D>();
        surEff2D = FindFirstObjectByType<SurfaceEffector2D>();
    }

    void Update()
    {
        if (canControlPlayer)
        {
            RotatePlayer();
            BoostPlayer();
            CalculateFlips();
        }
    }
    void RotatePlayer()
    {
        moveVector = moveAction.ReadValue<Vector2>();
        if (moveVector.x > 0)
            rigidBody.AddTorque(-torqueAmount);
        else if (moveVector.x < 0)
            rigidBody.AddTorque(torqueAmount);
    }
    void BoostPlayer()
    {
        if(moveVector.y > 0)
        {
            surEff2D.speed = boostSpeed;  
        }
        else
        {
            surEff2D.speed = baseSpeed;
        }
    }
    void CalculateFlips()
    {
        float currentRotation = transform.rotation.eulerAngles.z;
        totalRotation += Mathf.DeltaAngle(previousRotation, currentRotation);
        if(totalRotation > 340 || totalRotation < -340)
        {
            totalRotation = 0;
            scoreManager.AddScore(100);
        }
        previousRotation = currentRotation; 
    }
    public void DisableControls()
    {
        canControlPlayer = false;
    }
    public void ActivatePowerup(PowerupSo powerup)
    {
        powerupCount++;
        powerupParticles.Play();
        if(powerup.GetpowerupType() == "speed")
        {
            baseSpeed += powerup.GetvalueChange();
            boostSpeed += powerup.GetvalueChange();
        }
        if(powerup.GetpowerupType() == "torque")
        {
            torqueAmount += powerup.GetvalueChange();
        }
    }
    public void DeactivatePowerup(PowerupSo powerup)
    {
        powerupCount--;
        if(powerupCount == 0)
        {
            powerupParticles.Stop();
        }
        if(powerup.GetpowerupType() == "speed")
        {
            baseSpeed -= powerup.GetvalueChange();
            boostSpeed -= powerup.GetvalueChange();
        }
        if(powerup.GetpowerupType() == "torque")
        {
            torqueAmount -= powerup.GetvalueChange();
        }
    }
}

