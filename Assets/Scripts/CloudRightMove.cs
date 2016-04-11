using UnityEngine;
using System.Collections;

public class CloudRightMove : MonoBehaviour {

	void Start () {
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-0.5f, 0);
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		Destroy (gameObject);
	}
}
