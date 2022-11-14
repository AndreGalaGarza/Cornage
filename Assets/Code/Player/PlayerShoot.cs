using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
	public SpriteRenderer sRenderer;
	public GameObject Bullet;
	private const int bulletSpeed = 10;
	private const float bulletReload = 0.1f;
	private float bulletReloadTimer = 0;
	private AudioSource audioSource;
	private AudioClip CornShoot;
	
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
	
	void Start() {
		sRenderer = GetComponent<SpriteRenderer>();
		audioSource = GetComponent<AudioSource>();
		CornShoot = Resources.Load<AudioClip>("Audio/CornShoot");
	}
	
    void Update()
    {	
		// When mouse button is held down, fire bullets at a fixed rate
		if (Input.GetMouseButton(0)) {
			bulletReloadTimer -= Time.deltaTime;
			if (bulletReloadTimer <= 0) {
				bulletReloadTimer = bulletReload;
				if (GlobalVariables.playerCorn > 25) {
					GlobalVariables.playerCorn -= 1;
					audioSource.pitch = Random.Range(0.9f, 1.1f);
					audioSource.PlayOneShot(CornShoot, 0.7f);
					SpawnBullet();
				}
			}
		}
		
		// Reset bullet reload timer when mouse button is released
		if (Input.GetMouseButtonUp(0)) {
			bulletReloadTimer = 0;
		}
		
		// Flip sprite depending on mouse position
		if (Input.mousePosition.x < (Screen.width / 2f)) {
			sRenderer.flipX = true;
		}
		else {
			sRenderer.flipX = false;
		}
	}
	
	void FixedUpdate()
	{
		Vector3 worldPosition =
			Camera.main.ScreenToWorldPoint(Input.mousePosition);
		// DEBUG: Draw line of fire for bullets
		//Debug.DrawLine(transform.position, worldPosition, Color.red);
	}
}
