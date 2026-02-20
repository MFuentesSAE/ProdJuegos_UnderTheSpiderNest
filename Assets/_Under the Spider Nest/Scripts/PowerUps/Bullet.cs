using UnityEngine;

public class Bullet : MonoBehaviour
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	protected void Start()
    {
        
    }

	// Update is called once per frame
	protected void Update()
    {
        MoveBullet();
    }

    public virtual void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {

            collision.gameObject.GetComponent<EnemyMovement>().Dying();
        }
        else if (!collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    protected void MoveBullet()
    {
        transform.Translate(Vector3.forward * 15f * Time.deltaTime);
        Destroy(gameObject, 0.5f);
    }

}
