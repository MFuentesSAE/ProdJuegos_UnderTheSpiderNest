using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    public float fireRate;
    public float damage;
	public Transform firePoint;
	protected float nextFireTime;

    void Start()
    {
        
    }

	protected void Update()
	{
		if (Input.GetMouseButton(0))
		{
			Shoot();
		}
	}

	//Lógica base del fireRate
	protected void Shoot()
	{
		//Cada cierto tiempo se dispara una bala
		if (Time.time > nextFireTime)
		{
			ShootBehaviour();

			//Para determinar el fireRate es dividir entre uno el firate, cuantos disparos se permiten por segundo y sumar eso al timepo actual.
			nextFireTime = Time.time + (1/fireRate);
		}
	}

	//Función para sobrecargar el disparo
	protected virtual void ShootBehaviour()
	{ 

	}

}
