using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    public ParticleSystem fireEffect;
    
    public AudioSource disparoSound;
    
    private float lastShootTime;
    
    public float shootRate;

    public GameObject shootingPoint;

    private string layerName;

    public bool ShootBullet(string layerName, float delay)
    {
        if (Time.timeScale > 0)
        {
            var timeSinceLastShoot = Time.time - lastShootTime;
            if (timeSinceLastShoot < shootRate)
            {
                return false;
            }

            lastShootTime = Time.time;
            this.layerName = layerName;
            Invoke("FireBullet", delay);

            return true;
        }

        return false;
    }

    void FireBullet()
        {
            var bala = ObjectPool.SharedInstance.GetFirstPooledObject();
            bala.layer = LayerMask.NameToLayer(layerName);
            bala.transform.position = shootingPoint.transform.position;
            bala.transform.rotation = shootingPoint.transform.rotation;
            bala.SetActive(true);

            if (fireEffect != null)
            {
                fireEffect.Play();
            }

            if (disparoSound != null)
            {
                Instantiate(disparoSound, transform.position, transform.rotation).
                    GetComponent<AudioSource>().Play();
            }
        }
}
