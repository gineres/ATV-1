using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Carregador
{
    Pistol,
    Shotgun,
    Rifle
}

public class CarregadorScript : MonoBehaviour
{
    float[] bulletWeightPossibilities = {0.00012f, 0.0002f, 0.00025f, 0.00028f, 0.0003f, 0.00032f, 0.00036f, 0.0004f, 0.00043f};
    Carregador tipoCarregador = Carregador.Pistol;
    int capacity;
    int currentBullets;
    float bulletWeight;

    [Header("UI Handling")]
    public Text weightText;
    public Text magText;

    public float BulletWeight { get => bulletWeight; set => bulletWeight = value; }

    public void SetTipoCarregador(Carregador tipoCarregador)
    {
        this.tipoCarregador = tipoCarregador;
        UpdateCarregadorInfo();
    }

    public Carregador GetTipoCarregador()
    {
        return tipoCarregador;
    }

    public void SetCurrentBullets(int currentBullets)
    {
        this.currentBullets = currentBullets;
    }

    public int GetCurrentBullets()
    {
        return currentBullets;
    }

    public float GetBulletWeight()
    {
        return bulletWeight;
    }

    void Start()
    {
        UpdateCarregadorInfo();
    }

    void UpdateCarregadorInfo()
    {
        switch (tipoCarregador)
        {
            case Carregador.Pistol:
                capacity = 50;
                break;
            case Carregador.Shotgun:
                capacity = 30;
                break;
            case Carregador.Rifle:
                capacity = 100;
                break;
            default:
                break;
        }
        currentBullets = capacity;
        int randomIndex = Random.Range(0, bulletWeightPossibilities.Length);
        bulletWeight = bulletWeightPossibilities[randomIndex];
        weightText.text = "Peso BB: " + (bulletWeight*100).ToString() + "g";
        magText.text = tipoCarregador.ToString();
    }
}
