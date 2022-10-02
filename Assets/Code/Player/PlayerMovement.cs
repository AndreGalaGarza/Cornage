using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private const int maxSpeed = 5;
	private const float speedModifier = 0.2f;
	private float speedX = 0;
	private float speedY = 0;
	
    void Update()
    {
		// Get keyboard input
		if (Input.GetKey(KeyCode.D)) {
			speedX += speedModifier * Time.deltaTime * 100f;
		}
		if (Input.GetKey(KeyCode.A)) {
			speedX -= speedModifier * Time.deltaTime * 100f;
		}
		if (Input.GetKey(KeyCode.W)) {
			speedY += speedModifier * Time.deltaTime * 100f;
		}
		if (Input.GetKey(KeyCode.S)) {
			speedY -= speedModifier * Time.deltaTime * 100f;
		}
		
		// Cap speed if input is received
		speedX = Mathf.Clamp(speedX, -(maxSpeed), maxSpeed);
		speedY = Mathf.Clamp(speedY, -(maxSpeed), maxSpeed);
		
		// If both or neither inputs on an axis are received,
		// slowly decrease speed
		if ((Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A)) ||
			(!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))) {
			if (speedX > 0) {
				speedX -= speedModifier * Time.deltaTime * 100f;
				if (speedX < 0) {
					speedX = 0;
				}
			}
			if (speedX < 0) {
				speedX += speedModifier * Time.deltaTime * 100f;
				if (speedX > 0) {
					speedX = 0;
				}
			}
		}
		if ((Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S)) ||
			(!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))) {
			if (speedY > 0) {
				speedY -= speedModifier * Time.deltaTime * 100f;
				if (speedY < 0) {
					speedY = 0;
				}
			}
			if (speedY < 0) {
				speedY += speedModifier * Time.deltaTime * 100f;
				if (speedY > 0) {
					speedY = 0;
				}
			}
		}
		
		// Move player
		transform.position += transform.right * speedX * Time.deltaTime;
		transform.position += transform.up * speedY * Time.deltaTime;
    }
}
