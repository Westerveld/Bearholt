using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EncounterBehaviour : MonoBehaviour {

	public GameObject EncounterUI;
	public GameObject rollButton;
	public GameObject returnButton;
	public GameObject dice;
	public GameObject EnemyDice;
	public GameObject[] PlayerResult;
	public GameObject[] EnemyResult;
	public Text infoText;
	public Text moraleText;

	private GameManager manager;
	private int result;
	private int enemyResult;
	private Text iText;

	void Start(){
		manager = gameObject.GetComponent<GameManager> ();
		iText = infoText.GetComponent<Text> ();
	}
	public void encounter(){
		dice.SetActive (true);
		EnemyDice.SetActive (true);
		EncounterUI.SetActive (true);
		moraleText.GetComponent<Text> ().text = "";
	}

	public void myRoll()
	{
		int morale = gameObject.GetComponent<GameManager> ().Morale;
		dice.SetActive (true);
		EnemyDice.SetActive (true);
		result = Random.Range (1, 6);
		enemyResult = Random.Range (1, 6);
		if (result == 1) {
			dice.SetActive (false);
			rollButton.SetActive (false);
			PlayerResult [result - 1].SetActive (true);
			StartCoroutine ("waitForMeSenpai");
		} else if (result == 2) {
			dice.SetActive (false);
			rollButton.SetActive (false);
			PlayerResult [result - 1].SetActive (true);
			StartCoroutine ("waitForMeSenpai");
		} else if (result == 3) {
			dice.SetActive (false);
			rollButton.SetActive (false);
			PlayerResult [result - 1].SetActive (true);
			StartCoroutine ("waitForMeSenpai");
		} else if (result == 4) {
			
			dice.SetActive (false);
			rollButton.SetActive (false);
			PlayerResult [result - 1].SetActive (true);
			StartCoroutine ("waitForMeSenpai");
		} else if (result == 5) {
			dice.SetActive (false);
			rollButton.SetActive (false);
			PlayerResult [result - 1].SetActive (true);
			StartCoroutine ("waitForMeSenpai");
		} else if (result == 6) {
			dice.SetActive (false);
			rollButton.SetActive (false);
			PlayerResult [result - 1].SetActive (true);
			StartCoroutine ("waitForMeSenpai");
		}

		if (enemyResult == 1) {
			EnemyDice.SetActive (false);
			EnemyResult [enemyResult - 1].SetActive (true);
		} else if (enemyResult == 2) {
			EnemyDice.SetActive (false);
			EnemyResult [enemyResult - 1].SetActive (true);
		} else if (enemyResult == 3) {
			EnemyDice.SetActive (false);
			EnemyResult [enemyResult - 1].SetActive (true);
		} else if (enemyResult == 4) {
			EnemyDice.SetActive (false);
			EnemyResult [enemyResult - 1].SetActive (true);

		} else if (enemyResult == 5) {
			EnemyDice.SetActive (false);
			EnemyResult [enemyResult - 1].SetActive (true);
		} else if (enemyResult == 6) {
			EnemyDice.SetActive (false);
			EnemyResult [enemyResult - 1].SetActive (true);
		}
		if (morale == 1) {
			moraleText.GetComponent<Text> ().text = "You Rolled " + result + " but due to low morale, your result went down by 2";
			result -= 2;
		} else if (morale == 2) {
			moraleText.GetComponent<Text> ().text = "You Rolled " + result + " but due to low morale, your result went down by 1";
			result -= 1;
		}else if(morale ==3){
			moraleText.GetComponent<Text> ().text = "Your morale didnt effect your roll.";
		}else if (morale == 4) {
			moraleText.GetComponent<Text> ().text = "You Rolled " + result + " but thanks to high morale, your result went up by 1!";
			result += 1;
		} else if (morale == 5) {
			moraleText.GetComponent<Text> ().text = "You Rolled " + result + " but thanks to high morale, your result went up by 2!";
			result += 2;
		}
		if (result < enemyResult) {
			manager.Health -= 1;
			if(manager.Morale == 1){
				iText.text = "The Coyote rolled higher than you, you take one health point of damage";
			} else {
			manager.Morale -= 1;
			infoText.GetComponent<Text>().text = "The Coyote rolled higher than you, you take one health point of damage and lose one morale point";
			}
			returnButton.SetActive (true);
		} else if (result == enemyResult) {
			infoText.GetComponent<Text>().text = "You rolled the same, No damage was taken, but the coyote wasnt moved back";
			returnButton.SetActive (true);
		} else if (result > enemyResult) {
			manager.CoyoteValue -= 1;
			manager.CoyoteKilled = true;
			iText.text = "You rolled higher than the coyote, and the coyote gets killed! But another coyote is on the horizon. Be sure to attack it before he reaches your cubs";
			returnButton.SetActive (true);
		}
	}

	public void ReturnToGame(){
		for (int i = 0; i < 5; i++) {
			PlayerResult [i].SetActive (false);
			EnemyResult [i].SetActive (false);
		}
		rollButton.SetActive (true);
		EncounterUI.SetActive (false);
		returnButton.SetActive (false);
		GameObject.Find ("UserInput").SetActive (true);
	}
	IEnumerator waitForMeSenpai(){
		yield return new WaitForSeconds(2f);
	}
}
