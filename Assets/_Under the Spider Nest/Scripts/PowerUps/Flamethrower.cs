using UnityEngine;
using UnityEngine.Rendering;

public class Flamethrower : Weapons
{

    public ParticleSystem insecticide;
    public float range = 8;
    public float radius = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            ShootBehaviour();
        }
    }


    protected override void ShootBehaviour()
    {
        insecticide.Play();


        //Se hará un SpherecastAll que regresa un arreglo de los colliders con los que colisiona.
        RaycastHit [] hits;

        //Crear un rayo en dirección frontal del firepoint
        Ray shootRay = new Ray(firePoint.position, firePoint.forward * range);
        Debug.DrawRay(shootRay.origin, shootRay.direction, Color.red, 1);

        //SphereCastAll es similar a un raycast normal, con la diferencia que regresa varios hits (un arrgelo) ya que "traspasa" más allá del primer collider con el que golpea.
        //También se le puede dar un radio para que tenga volumen
        hits = Physics.SphereCastAll(shootRay, radius, range);


        //De la lista de colliders obtenidos verificamos quienes son enemigos para aplicar daño
        for(int i = 0; i < hits.Length; i++)
        {
            EnemyMovement enemy = hits[i].collider.gameObject.GetComponent<EnemyMovement>();    
            if(enemy != null)
            {
                enemy.Dying();
            }
        }
    }

}
