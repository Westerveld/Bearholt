using UnityEngine;
using System.Collections;

public class BearBehaviour : MonoBehaviour {

	public float speed;
	public GameObject fishGO;
	public bool moving;
	public bool facingRight;

	private Rigidbody2D rigid;

	// Use this for initialization
	void Start () {
		facingRight = true;
		rigid = gameObject.GetComponent<Rigidbody2D> ();
	}

	public void fish(){
		moving = true;
		MoveBear (speed);
	}

	IEnumerator waitThenMove(){
		yield return new WaitForSeconds(1.5f);
		MoveBear (-speed);
	}

	void MoveBear(float moveSpeed){
		rigid.velocity = new Vector2(moveSpeed, 0);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.name == "home") {
			Flip();
			rigid.velocity = new Vector2(0, 0);
			moving = false;
		} else {
			Flip ();
			rigid.velocity = new Vector2 (0, 0);
			StartCoroutine ("waitThenMove");
			StartCoroutine("FishAnimation");
		}
	}

	void Flip(){
		facingRight = !facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
	
	
	IEnumerator FishAnimation(){
		fishGO.SetActive (true);
		fishGO.GetComponent<AudioSource> ().Play ();
		yield return new WaitForSeconds (1.8f);
		fishGO.SetActive (false);
	}
}
