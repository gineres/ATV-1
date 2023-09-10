using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectibleMag : MonoBehaviour
{
    public Carregador magType = Carregador.Pistol;
    public TextMeshProUGUI infoText;
    void Start()
    {
        infoText.text = "TYPE: " + magType.ToString();
    }
}
