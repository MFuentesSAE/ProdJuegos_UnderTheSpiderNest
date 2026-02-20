using UnityEngine;

public class BulletRocket : Bullet
{
	public float explosionRadius = 5;
	public override void OnCollisionEnter(Collision collision)
	{
		//Physics.OverlapSphere es una funcion que crea una esfera a partir de una pocisión y radio dado. Regresa todos los colliders que "toque."
		Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
		
		// por cada collider vemos si son enemigos o el jugador. En ambos caso aplicamos daño
		for(int i = 0; i < colliders.Length; i++)
		{
			EnemyMovement enemy = colliders[i].GetComponent<EnemyMovement>();
			HP playerHp = colliders[i].GetComponent<HP>();
			
			if(enemy != null)
			{
				enemy.Dying();
			}

			if(playerHp != null)
			{
				playerHp.TakeDamage(1);
			}
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, explosionRadius);
	}
}
