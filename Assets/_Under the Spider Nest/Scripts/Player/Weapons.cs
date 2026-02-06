using UnityEngine;

public class Weapons : MonoBehaviour
{
    [Header("Ametralladora Weapon Settings")]
    public Transform spawnBulletAmetralladora;
    public GameObject bulletPrefabAmetralladora;
    int fireRateAmetralladora = 2;

    //[Header("Bazuca Weapon Settings")]
    //public Transform spawnBulletBazuca;
    //public GameObject bulletPrefabBazuca;

    //[Header("LanzaLlamas Weapon Settings")]
    //public Transform spawnBulletLanzaLlamas;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ShootAmetralladora();
    }

    void ChangeWeapon()
    {

    }

    void ShootAmetralladora()
    {
        //Cada cierto tiempo se dispara una bala
        if (Time.time >= fireRateAmetralladora)
        {
            Instantiate(bulletPrefabAmetralladora, spawnBulletAmetralladora.position, spawnBulletAmetralladora.rotation);
            fireRateAmetralladora = Mathf.FloorToInt(Time.time) + 1;

        }
    }

    //void ShootBazuca()
    //{
    //    Instantiate(bulletPrefabBazuca, spawnBulletBazuca.position, spawnBulletBazuca.rotation);
    //}

}
