using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectibleGun : MonoBehaviour
{
    public Carregador gunType = Carregador.Pistol;
    public TextMeshProUGUI infoText;
    void Start()
    {
        infoText.text = "TYPE: " + gunType.ToString();
    }
}
