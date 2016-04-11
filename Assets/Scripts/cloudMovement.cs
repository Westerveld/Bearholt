using UnityEngine;
using System.Collections;

public class cloudMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0.5f, 0);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		Destroy (gameObject);
	}
}
