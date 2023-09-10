using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public GunScript gunScript;
    
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("ENTROU");
        if (other.gameObject.tag == "Mag")
        {
            CollectibleMag mag = other.gameObject.GetComponent<CollectibleMag>() as CollectibleMag;
            if (gunScript.carregador.GetTipoCarregador() == mag.magType)
            {
                gunScript.carregador.SetTipoCarregador(mag.magType); // colocar pra ser flexivel dps
                Destroy(other.gameObject.transform.parent.gameObject);
            } else
            {
                Debug.Log("NAO COMPATIVEL!!!");
            }
        } else if (other.gameObject.tag == "Gun")
        {
            CollectibleGun gun = other.gameObject.GetComponent<CollectibleGun>() as CollectibleGun;
            gunScript.carregador.SetTipoCarregador(gun.gunType); // colocar pra ser flexivel dps
            Destroy(other.gameObject.transform.parent.gameObject);
        }
    }
}
