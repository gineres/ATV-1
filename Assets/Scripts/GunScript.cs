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
    public Text backspinText;

    private float shootTimer; 
    private bool isShooting; 
    private float adjustableBackspin = .02f;
    private float scrollSensitivity = .1f;
    private bool autoMode = false;

    void Update()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        
        adjustableBackspin += scrollInput * scrollSensitivity;

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (autoMode)
            {
                TurnAutoOff();
            } else {
                TurnAutoOn();
            }
        } 

        currentBullets = carregador.GetCurrentBullets();
        UpdateUI();

        if (isShooting)
        {
            shootTimer -= Time.deltaTime;
            if (shootTimer <= 0f)
            {
                isShooting = false;
            }
        }

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
        if (carregador.GetTipoCarregador() == Carregador.Pistol)
        {
            shootTimer = .2f; 
        }
        else if (carregador.GetTipoCarregador() == Carregador.Shotgun)
        {
            shootTimer = 0.13f;
        }
        else
        {
            shootTimer = 0.05f; 
        }

        isShooting = true;
        Invoke("Shoot", shootTimer);
    }

    void UpdateUI()
    {
        bulletsText.text = currentBullets.ToString();
        backspinText.text = "BACKSPIN: " + adjustableBackspin.ToString();
    }

    void Shoot()
    {
        GameObject bb = Instantiate(bbObject, bbFirePos.position, bbFirePos.rotation) as GameObject;
        Ball bbScript = bb.GetComponent<Ball>();
        bbScript.AdjustBallSettings(1.2f, carregador.GetBulletWeight(), adjustableBackspin);
        carregador.SetCurrentBullets(currentBullets - 1);
    }

    public void TurnAutoOn(){
        autoMode = true;
    }

    public void TurnAutoOff(){
        autoMode = false;
    }
}
