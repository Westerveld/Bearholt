using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndSceneScript : MonoBehaviour {

	public Text daysLabel;
	public Text deathLabel;
	private int days;

	// Use this for initialization
	void Start () {
		days = GameManager.CurrentDay;
		daysLabel.GetComponent<Text> ().text = "Days Survived: " + days;
		if (GameManager.CoyoteLocation == 5) {
			deathLabel.GetComponent<Text> ().text = "The coyote reached your cubs, and ate them! Next time remember to attack the coyote before he can get close";
		} else {
			deathLabel.GetComponent<Text> ().text = "You were killed due to running out of Health, try to keep your hunger low to prevent your health going down";
	
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
}
