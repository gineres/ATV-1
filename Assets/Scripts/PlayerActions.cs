using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public GunScript gunScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("ENTROU");
        if (other.gameObject.tag == "Mag")
        {
            CollectibleMag mag = other.gameObject.GetComponent<CollectibleMag>() as CollectibleMag;
            if (gunScript.carregador.GetTipoCarregador() == mag.magType)
            {
                gunScript.carregador.SetTipoCarregador(mag.magType); // colocar pra ser flexivel dps
                Destroy(other.gameObject);
            } else
            {
                Debug.Log("NÃO COMPATÍVEL!!!");
            }
        } else if (other.gameObject.tag == "Gun")
        {
            CollectibleGun gun = other.gameObject.GetComponent<CollectibleGun>() as CollectibleGun;
            gunScript.carregador.SetTipoCarregador(gun.gunType); // colocar pra ser flexivel dps
            Destroy(other.gameObject);
        }
    }
}
