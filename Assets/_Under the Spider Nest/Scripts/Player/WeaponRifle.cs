using UnityEngine;

public class WeaponRifle : WeaponBase
{
	public float range;
	public LayerMask mask;

	/// <summary>
	/// Disparar rifle por Raycast
	/// </summary>
	protected override void ShootBehaviour()
	{
		Ray ray = new Ray(firePoint.position, firePoint.forward);

		float rayLenght = range;

		RaycastHit hit;
		if(Physics.Raycast(ray, out hit, range, mask))
		{
			rayLenght = hit.distance; //hacer que la distancia del rao sea entre su origen y el objeto que se impactó.
			EnemyMovement enemy = hit.collider.GetComponent<EnemyMovement>();
			enemy?.Dying();
		}

		Debug.DrawRay(ray.origin, ray.direction * rayLenght, Color.yellow);
	}
}
