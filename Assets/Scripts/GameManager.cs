using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	public float requiredRoll;
	public GameObject bear;
	public GameObject FightMonster;
	public GameObject EatFood;
	public GameObject GoFish;
	public GameObject EndTurn;
	public GameObject UserInput;
	public GameObject Coyote;
	public GameObject DayBox;
	public GameObject sun;
	public GameObject cloudLeft;
	public GameObject cloudRight;
	public GameObject[] leftSpawn;
	public GameObject[] rightSpawn;
	public bool CoyoteKilled;
	public Text infoText;
	public GameObject coyoteText;

	public static int CurrentDay;
	public static int CoyoteLocation;
	private Vector2 oldpos;
	private RandomEvents rand;

	public Text HealthLabel;
	private int health;
	public int Health { //Public class for access to the health.
		get{ return health;}
		set {
			health = value;
			HealthLabel.GetComponent<Text> ().text = "Health: " + health + "/10";
		}
	}

	public Text HungerLabel;
	private int hunger;
	public int Hunger{//Public class for access to the hunger.
		get{ return hunger;}
		set{
			hunger = value;
			HungerLabel.GetComponent<Text> ().text = "Hunger: " + hunger + "/5";
		}
	}

	public Text actionLabel;
	private int actions;
	public int Actions {//Public class for access to the actions.
		get{ return actions;}
		set {
			actions = value;
			actionLabel.GetComponent<Text> ().text = "Actions: " + actions + "/3";
		}
	}

	public Text fishLabel;
	private int fishes;
	public int Fishes {//Public class for access to the amount of fish avaliable.
		get{ return fishes;}
		set {
			fishes = value;
			fishLabel.GetComponent<Text> ().text = "Fish: " + fishes;
		}
	}
	
	public Text dayText; 
	private int day;
	public int Day {
		get{ return day;}
		set {
			day = value;
			dayText.GetComponent<Text> ().text = "Day: " + day;
		}
	}

	private int coyote;
	public int CoyoteValue{
		get {return coyote;}
		set { coyote = value;}
	}

	public Text moraleLabel;
	private int morale;
	public int Morale{
		get{ return morale;}
		set{ 
			morale = value;
			moraleLabel.GetComponent<Text>().text = "Morale: " + morale + "/5";
		}
	}

	void Start(){
		Health = 10;
		Hunger = 3;
		Actions = 3;
		Fishes = 5;
		requiredRoll = 1;
		Day = 1;
		CoyoteValue = 0;
		Morale = 3;
		StartCoroutine ("StartDay");
		oldpos = Coyote.GetComponent<Rigidbody2D> ().position;
		InvokeRepeating ("SpawnLeft", 5f, 25f);
		InvokeRepeating ("SpawnRight", 3f, 20f);
	}

	void Update(){
		CoyoteLocation = CoyoteValue;
		if (Health == 0) {
			Application.LoadLevel("end");
		}
		if (CoyoteValue == 5) {
			Application.LoadLevel ("end");
		}
		if (Actions == 3) {
			sun.GetComponent<Transform> ().position = new Vector2(0, 2.15f);
		} else if (Actions == 2) {
			sun.GetComponent<Transform> ().position = new Vector2(0, 1.9f);
		} else if (Actions == 1) {
			sun.GetComponent<Transform> ().position = new Vector2(0, 1.65f);
		} else if (Actions == 0) {
			sun.GetComponent<Transform>().position = new Vector2(0, 1.4f);
		}

	} 

	void FixedUpdate(){
		if (bear.GetComponent<BearBehaviour> ().moving) {
			FightMonster.SetActive (false); //Hides Button
			EatFood.SetActive(false); //Hides Button
			GoFish.SetActive(false); //Hides Button
			EndTurn.SetActive(false); //Hides Button
		}
		if (bear.GetComponent<BearBehaviour> ().moving == false) {
			FightMonster.SetActive(true); //Shows Button
			EatFood.SetActive(true); //Shows Button
			GoFish.SetActive(true); //Shows Button
			EndTurn.SetActive(true); //Shows Button
		}
		CurrentDay = Day; //Makes the Day value avaliable to other scripts without referencing a gameobject
		CoyoteLocation = CoyoteValue; //Makes the coyoteValue avaliable to other scripts without referencing a gameobject
	}

	public void fightMonster(){
		if (!CoyoteKilled) {
			if (Actions > 0) {
				UserInput.SetActive (false); //Hides User Input panel
				Actions--;
				gameObject.GetComponent<EncounterBehaviour> ().encounter ();
				UserInput.SetActive (true); //Shows User Input panel
			} else {
				infoText.GetComponent<Text> ().text = "No Actions Avaliable for today, End day to get more action points";
			}
		} else {
			infoText.GetComponent<Text>().text = "The Coyote has already been killed this turn";
		}
	}

	public void eatFood(){
		if (Actions > 0) {
			if (Fishes > 0) {
				bear.GetComponent<AudioSource>().Play ();
				if (hunger == 1) { //stops the value of hunger going below 0
					infoText.GetComponent<Text>().text = "You eat 1 fish and remove 1 point from hunger";
					Hunger--; //Take away 1 from hunger
					Fishes--; //Take away 1 from the amount of fish avaliable
					Actions--; //Take away 1 from the number of actions avaliable
				} else if (hunger > 1) {
					infoText.GetComponent<Text>().text = "You eat 1 fish and remove 2 points from hunger";
					Hunger -= 2; //Take away 2 from hunger
					Fishes--; //Take away 1 from the amount of fish avaliable
					Actions--; //Take away 1 from the number of actions avaliable
				} else {
					int rollResult = Roll ();
					if(rollResult > 3)
					{
						if(Morale < 4){
							infoText.GetComponent<Text> ().text = "You ate a fish but are already full. The Bear Gods smile on you and you gain 1 morale";
							Morale +=1;
						}else{
							infoText.GetComponent<Text>().text = "You eat the fish but are already full. You dont gain any morale as you are at max morale already!";
						}
					}else{
						infoText.GetComponent<Text> ().text = "You ate a fish but are already full. Maybe you should eat more fish.";
					}
					Actions--;
				}
			} else {
				infoText.GetComponent<Text> ().text = "No fish avaliable to eat!";
			}
		} else {
			infoText.GetComponent<Text> ().text = "No Actions Avaliable for today, End day to get more action points";
		}
	}

	public int Roll(){
			int result;
			result = Random.Range (1, 6);
			return result;
		}

	public void goFishing(){
		if (Actions > 0) {
			int result = Roll();
			if(result >= requiredRoll)//Checks if the roll meets requirements
			{
				Fishes++; //Adds one to fish
				bear.GetComponent<BearBehaviour>().fish(); //does the fish function within the bear.
				infoText.GetComponent<Text>().text = "You were able to catch a fish!";
			}else{
				infoText.GetComponent<Text>().text = "You didnt roll high enough to successfully fish.. maybe they are running out";
			}
		Actions--; // Take away 1 from the number of actions avaliable
		}else{
			infoText.GetComponent<Text> ().text = "No Actions Avaliable for today, End the day to get more action points";
		}
	}

	public void endTurn(){
		Actions = 3;
		Day++; // Adds one to the day value
		if (Hunger == 5) //If at max hunger, take away 1 from health.
		{
			Health--; 
		} else {
			Hunger++;
		}
		
		Vector2 currentPos = Coyote.GetComponent<Rigidbody2D>().position;
		if (CoyoteKilled) {
			if( oldpos.x < currentPos.x){
				CoyoteKilled = false;
				CoyoteValue = 0;
			}else{
				Coyote.GetComponent<Rigidbody2D>().position = new Vector2(oldpos.x, -4.5f);
				CoyoteKilled = false;
				CoyoteValue = 0;
			}
		} else {
			CoyoteValue++;
			Coyote.GetComponent<Rigidbody2D>().position = new Vector2(currentPos.x - 2.5f, -4.5f);
		}

		if (requiredRoll <= 5.6f ) {
			requiredRoll += 0.2f;
		}
		
		SelectRandomEvent ();
		
		StartCoroutine ("StartDay");
	}

	IEnumerator StartDay(){
		DayBox.SetActive (true);
		DayBox.GetComponent<Image> ().CrossFadeAlpha (0f, 2f, false);
		infoText.GetComponent<Text> ().text = "A day has passed, you have three avaliable actions. Choose wisely, your cubs depend upon you!";
		yield return new WaitForSeconds (1.9f);
		DayBox.SetActive (false);
		if (CoyoteValue == 4) {
			StartCoroutine("CoyoteWarning");
		}
	}

	IEnumerator waitForMoveToFinish(){
		yield return new WaitForSeconds(10f);
	}

	void SpawnLeft(){
		Instantiate (cloudLeft, leftSpawn [0].GetComponent<Transform>().position, Quaternion.identity);

	}

	void SpawnRight(){
		Instantiate (cloudRight, rightSpawn [0].GetComponent<Transform>().position, Quaternion.identity);
	}

	IEnumerator CoyoteWarning(){
		coyoteText.SetActive (true);
		coyoteText.GetComponent<Image> ().CrossFadeAlpha (0.5f, 3f, false);
		yield return new WaitForSeconds (3f);
		coyoteText.SetActive (false);
	}

	void SelectRandomEvent(){
		rand = gameObject.GetComponent<RandomEvents>();
		int rollDice = Random.Range (1, 11);
		Debug.Log (rollDice);
		if (rollDice == 1) {
			rand.EventOneSetup ();
		} else if (rollDice == 2) {
			rand.EventTwoSetup ();
		} else if (rollDice == 3) {
			rand.EventThreeSetup ();
		} else if (rollDice == 4) {
			rand.EventFourSetup ();
		} else if (rollDice == 5) {
			rand.EventFiveSetup ();
		} else if (rollDice == 6) {
			rand.EventSixSetup ();
		} else if (rollDice == 7) {
			rand.EventSevenSetup ();
		} else if (rollDice == 8) {
			rand.EventEightSetup();
		} else if (rollDice == 9) {
			rand.EventNineSetup ();
		} else if (rollDice == 10) {
			rand.EventTenSetup ();
		}
	}
}