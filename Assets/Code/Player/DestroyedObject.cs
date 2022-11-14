using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedObject : MonoBehaviour
{
    private Rigidbody2D rb;
	
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2(Random.Range(-7f, 7f), Random.Range(10f, 12f));
    }
	
	void FixedUpdate()
    {
		// Destroy object if out of bounds
		if (transform.position.x >= 31f
		|| transform.position.x <= -31f
		|| transform.position.y >= 21f
		|| transform.position.y <= -21f) {
			Destroy(gameObject);
		}
		
		// Rotate destroyed objects (except circular particles)
		if (gameObject.name != "SootParticle(Clone)") {
			transform.rotation *=
				Quaternion.AngleAxis(Time.fixedDeltaTime * 100f,
				Vector3.forward);
		}
    }
}
