using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunScript : MonoBehaviour
{
    public CarregadorScript carregador;
    public GameObject bbObject;
    public Transform bbFirePos;
    int currentBullets;

    [Header("UI Handling")]
    public Text bulletsText;

    private float shootTimer; // Timer for shooting delay
    private bool isShooting; // Flag to control shooting delay
    private bool autoMode = false;

    void Update()
    {
        currentBullets = carregador.GetCurrentBullets();
        UpdateUI();

        // Check if the gun is currently shooting and the delay has passed
        if (isShooting)
        {
            shootTimer -= Time.deltaTime;
            if (shootTimer <= 0f)
            {
                isShooting = false;
            }
        }

        // If the fire button is held down and there are bullets, shoot continuously
        if (autoMode)
        {
            if (Input.GetMouseButton(0) && currentBullets > 0 && !isShooting)
            {
                CallShooting();
            }   
        } else
        {
            if (Input.GetMouseButtonDown(0) && currentBullets > 0 && !isShooting)
            {
                CallShooting();
            } 
        }
    }

    void CallShooting()
    {
        // Set the shooting delay based on the carregador type
        if (carregador.GetTipoCarregador() == Carregador.Pistol)
        {
            shootTimer = .2f; // Adjust this value as needed
        }
        else if (carregador.GetTipoCarregador() == Carregador.Shotgun)
        {
            shootTimer = 0.13f; // Adjust this value as needed
        }
        else
        {
            shootTimer = 0.05f; // Adjust this value as needed
        }

        isShooting = true;
        Invoke("Shoot", shootTimer);
    }

    void UpdateUI()
    {
        bulletsText.text = currentBullets.ToString();
    }

    void Shoot()
    {
        GameObject bb = Instantiate(bbObject, bbFirePos.position, bbFirePos.rotation) as GameObject;
        Ball bbScript = bb.GetComponent<Ball>();
        bbScript.AdjustBallSettings(1.2f, carregador.GetBulletWeight());
        carregador.SetCurrentBullets(currentBullets - 1);
    }

    public void TurnAutoOn(){
        autoMode = true;
    }

    public void TurnAutoOff(){
        autoMode = false;
    }
}
