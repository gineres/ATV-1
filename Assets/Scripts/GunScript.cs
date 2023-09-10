using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunScript : MonoBehaviour
{
    //public Carregador carregadorArma = Carregador.Pistol;
    public CarregadorScript carregador;
    public GameObject bbObject;
    public Transform bbFirePos;

    int currentBullets;
    float rof;

    [Header ("UI Handling")]
    public Text bulletsText;

    void Update()
    {
        currentBullets = carregador.GetCurrentBullets();
        UpdateUI();
        Fire();
    }

    void UpdateUI()
    {
        bulletsText.text = currentBullets.ToString();
    }

    void Fire()
    {
        if (Input.GetMouseButtonDown(0) && currentBullets != 0)
        {
            GameObject bb = Instantiate(bbObject, bbFirePos.position, bbFirePos.rotation) as GameObject;
            Ball bbScript = bb.GetComponent<Ball>();
            bbScript.AdjustBallSettings(1.2f, carregador.GetBulletWeight());
            carregador.SetCurrentBullets(currentBullets - 1);
        }
    }
}
