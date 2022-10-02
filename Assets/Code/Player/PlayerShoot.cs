using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
	public GameObject Bullet;
	private const int bulletSpeed = 10;
	private const float bulletReload = 0.1f;
	private float bulletReloadTimer = 0;
	
	void SpawnBullet() {
		Vector3 worldPosition =
			Camera.main.ScreenToWorldPoint(Input.mousePosition);
		GameObject bulletClone = Instantiate(Bullet,
			transform.position, Quaternion.identity);
			
			Vector2 bulletVelocity =
			new Vector2((worldPosition.x - transform.position.x),
				worldPosition.y - transform.position.y);
			bulletVelocity = bulletVelocity.normalized * bulletSpeed;
			
            bulletClone.GetComponent<Rigidbody2D>().velocity = bulletVelocity;
	}
	
    void Update()
    {
		Vector3 worldPosition =
			Camera.main.ScreenToWorldPoint(Input.mousePosition);	
		Debug.DrawLine(transform.position, worldPosition, Color.red);
		
		// When mouse button is held down, fire bullets at a fixed rate
		if (Input.GetMouseButton(0)) {
			bulletReloadTimer -= Time.deltaTime;
			if (bulletReloadTimer <= 0) {
				SpawnBullet();
				bulletReloadTimer = bulletReload;
			}
		}
		
		// Reset bullet reload timer when mouse button is released
		if (Input.GetMouseButtonUp(0)) {
			bulletReloadTimer = 0;
		}
	}
}
