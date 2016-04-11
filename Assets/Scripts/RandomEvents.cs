using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RandomEvents : MonoBehaviour {

	private GameManager manager;
	private Text nText;
	private Text nTitle;
	public GameObject eventPanel;
	public GameObject EventOneRoll;
	public GameObject returnButton;
	public GameObject EventTwoOne; //Option 1 for Event 2
	public GameObject EventTwoTwo; //Option 2 for Event 2
	public GameObject EventThreeOne; // Option 1 for Event 3
	public GameObject EventThreeTwo; // Option 2 for Event 3
	public GameObject EventFourOne; // Option 1 for Event 4
	public GameObject EventFourTwo; // Option 2 for Event 4
	public GameObject EventFiveOne; // Option 1 for Event 5
	public GameObject EventFiveTwo; // Option 2 for Event 5
	public GameObject EventSixOne; // Option 1 for Event 6
	public GameObject EventSevenOne; // Option 1 for Event 7
	public GameObject EventSevenTwo; // Option 2 for Event 7
	public GameObject EventEightOne; // Option 1 for Event 8
	public GameObject EventEightTwo; // Option 2 for Event 8
	public GameObject EventNineOne; // Option 1 for Event 9
	public GameObject EventNineTwo; // Option 2 for Event 9
	public GameObject EventTenOne; // Option 1 for Event 10
	public GameObject EventTenTwo; // Option 2 for Event 10
	public GameObject UserInput;
	public GameObject DayBox;
	public Text eventInfo;
	public Text titleText;

	void Start(){
		manager = gameObject.GetComponent<GameManager> ();
		nText = eventInfo.GetComponent<Text> ();
		nTitle = titleText.GetComponent<Text> ();
	}
	//Event One -  chance to gain morale or lose health and morale
	public void EventOneSetup(){
		UserInput.SetActive(false);
		DayBox.SetActive (false);
		nTitle.text = "Damn those Coyotes!";
		nText.text = "You were walking your cubs around the watering hole, when suddenly a pack of Coyotes jump out at you! Roll to repel them!";
		EventOneRoll.SetActive (true);
		eventPanel.SetActive (true);
	}
	public void RollEventOne(){
		EventOneRoll.SetActive (false);
		returnButton.SetActive (true);
		int rollResult = Random.Range (1, 6);
		if (rollResult > 4) {
			manager.Health--;
			if(manager.Morale >= 2){
				manager.Morale--;
				nText.text = "Oh no! You failed to succesfully defend your cubs. They attack you, hitting you for 1 health and 1 morale point in the process.";
			} else {
				nText.text = "Oh no! You failed to succesfully defend your cubs. THey attack you, hitting you for 1 health.";
			}
		} else if (rollResult < 3) {
			if(manager.Morale <= 4){
				manager.Morale += 1;
				nText.text = "Wow! You successfully defended your cubs, and gain 1 morale point!";
			} else {
				nText.text = "Wow! You successfully defended your cubs!";
			}
		}
	}

	//Event Two - possibility to lose 2, 1 or no health
	public void EventTwoSetup(){
		UserInput.SetActive(false);
		DayBox.SetActive (false);
		eventPanel.SetActive (true);
		EventTwoOne.SetActive (true);
		EventTwoTwo.SetActive (true);
		nTitle.text = "Hunters!";
		nText.text = "You've seen a group of human hunters nearby. There's a chance they could try to attack you and your family if you stay, but you know that travelling to the next closest cave is dangerous.";
	}
	public void OptionOneEventTwo(){
		EventTwoOne.SetActive (false);
		EventTwoTwo.SetActive (false);
		returnButton.SetActive (true);
		int rollResult = Random.Range (1, 6);
		if (rollResult <= 2) {
			nText.text = "Humans don't scare bears, but your over confidence draws the hunters attention. THey shoot when they find your cave, and in the escape, you lose 2 health";
			manager.Health -= 2;
		} else {
			nText.text = "Humans don't scare bears! You terrify the humans by installing fear with a mighty roar, and they run, never even touching you.";
		}
	}
	
	public void OptionTwoEventTwo(){
		EventTwoOne.SetActive (false);
		EventTwoTwo.SetActive (false);
		returnButton.SetActive (true);
		nText.text = "You take a dangerous route to find a new home. Narrowly winning in a bid against the original owner of the new cave, you lose 1 health";
		manager.Health--;
	}

	//Event Three - Chance to lose all fish, or gain 1, or 3 fish
	public void EventThreeSetup(){
		UserInput.SetActive(false);
		DayBox.SetActive (false);
		EventThreeOne.SetActive (true);
		EventThreeTwo.SetActive (true);
		eventPanel.SetActive (true);
		nTitle.text = "Hunting season";
		nText.text = "The forest gets quite crowded when there's food around. Search parties of animals go looking in every direction. You might get lucky too if you join in, but there's always a chance that your own food stockpile is pinched.";
	}

	public void OptionOneEventThree(){
		EventThreeOne.SetActive (false);
		EventThreeTwo.SetActive (false);
		returnButton.SetActive (true);
		int rollResult = Random.Range(1,6);
		if (rollResult == 1) {
			nText.text = "While you were trying to scavange food, some pesky animals came along and stole all your fish! You lose all your food.";
			manager.Fishes = 0;
		} else if (rollResult > 1 && rollResult < 6) {
			nText.text = "You managed to scavange 1 fish!";
			manager.Fishes++;
		} else if (rollResult == 6) {
			nText.text = "You found a stash of fish in an untouched section of a lake! You manage to find 3 fish to add to your stockpile.";
			manager.Fishes += 3;
		}
	}
	
	public void OptionTwoEventThree(){
		EventThreeOne.SetActive (false);
		EventThreeTwo.SetActive (false);
		returnButton.SetActive (true);
		nText.text = "You decide to not risk it, and stay in your cave. You hope it's a wise choice.";
	}

	//Event Four - chance to gain health or lose health or lose morale
	public void EventFourSetup(){
		UserInput.SetActive(false);
		DayBox.SetActive (false);
		EventFourOne.SetActive (true);
		EventFourTwo.SetActive (true);
		eventPanel.SetActive (true);
		nTitle.text = "Well of Rejuvination!";
		nText.text = "You find the fabled well of rejuvination! Of the tales that are told about it, only the most adventurous will experience.";
	}
	public void OptionOneEventFour(){
		EventFourOne.SetActive (false);
		EventFourTwo.SetActive (false);
		returnButton.SetActive (true);
		int rollResult = Random.Range (1, 6);
		if (rollResult < 4) {
			nText.text = "Y'know... you are a bear, right? Bear's can't handle wells. You fail dismally at attempting to pull up the well's bucket, and as you keep trying, a poacher shoots at you, making you forced to flee. You lose 2 health";
			manager.Health -= 2;
		} else if (rollResult > 3) {
			nText.text = "With the power of your mighty claws, some sticks, and game elements that make this task otherwise impossible, you operate the well to bring up the bucket. You gain 1 health!";
			if(manager.Health > 10){
			manager.Health++;
			}
		}
	}
	
	public void OptionTwoEventFour(){
		EventFourOne.SetActive (false);
		EventFourTwo.SetActive (false);
		returnButton.SetActive (true);
		if (manager.Morale > 2) {
			manager.Morale--;
		}
		nText.text = "But... I'm not an adventurer, you say to yourself. With low self-esteem, you walk back to your cave empty-clawed.";
	}

	//Event Five - bear family
	public void EventFiveSetup(){
		UserInput.SetActive(false);
		DayBox.SetActive (false);
		EventFiveOne.SetActive (true);
		EventFiveTwo.SetActive (true);
		eventPanel.SetActive (true);
		nTitle.text = "Its a bear life";
		nText.text = "You meet a neighboring family of bears. They look like they may be hostile... maybe giving them a couple of fish will sate them?";
	}

	public void OptionOneEventFive(){
		EventFiveOne.SetActive (false);
		EventFiveTwo.SetActive (false);
		returnButton.SetActive (true);
		int rollResult = Random.Range (1, 6);
		int enemyResult = Random.Range (1, 6);
		if (rollResult > enemyResult) {
			nText.text = "Never! You say to yourself. Yours is a proud family. You successfully defeat the bears, but don't kill them, and receive 1 fish in exchange for your mercy.";
			manager.Fishes++;
		} else if (enemyResult > rollResult) {
			if(manager.Morale >= 2){
				nText.text = "Never! You say to yourself. Yours is a proud family. However you were unable to defeat them, and lose 1 morale as you flee terrified back to your cave.";
				manager.Morale--;
			}else{
				nText.text = "Never! You say to yourself. Yours is a proud family. However you were unable to defeat them, and flee back to your cave.";
			}
		} else {
			nText.text = "Never! You say to yourself. Yours is a proud family. After a long and brutal fight, you both decide there will be no winner, and go back to your cave with a story to tell your cubs.";
		}
	}
	
	public void OptionTwoEventFive(){
		EventFiveOne.SetActive (false);
		EventFiveTwo.SetActive (false);
		returnButton.SetActive (true);
		if (manager.Fishes >= 2) {
			manager.Fishes -= 2;
			if (manager.Morale <= 4) {
				manager.Morale++;
				nText.text = "You plead to the bears. Take my fish! - You lose 2 fish, but it turns out that the bears weren't mean after all! It makes you happy to know that you've made a new friend in the forest, and you gain 1 morale (but they keep the fish).";
			} else {
				nText.text = "You plead to the bears. Take my fish! - You lose 2 fish, but it turns out that the bears weren't mean after all! It makes you happy to know that you've made a new friend in the forest (but they keep the fish).";
			}
		} else if (manager.Fishes == 1) {
			manager.Fishes--;
			if (manager.Morale <= 4) {
				nText.text = "You plead to the bears. Take my fish! - You lose 1 fish, but it turns out that the bears weren't mean after all! It makes you happy to know that you've made a new friend in the forest, and you gain 1 morale (but they keep the fish).";
				manager.Morale++;
			} else {
				nText.text = "You plead to the bears. Take my fish! - You lose 1 fish, but it turns out that the bears weren't mean after all! It makes you happy to know that you've made a new friend in the forest (but they keep the fish).";
			}
		} else if (manager.Fishes == 0) {
			nText.text = "You plead to the bears. Don't hurt me! - They don't, as it turns out, and walk away.";
			
		}
	}

	//Event Six - A Thief strikes in the night
	public void EventSixSetup(){
		UserInput.SetActive(false);
		DayBox.SetActive (false);
		EventSixOne.SetActive (true);
		eventPanel.SetActive (true);
		nTitle.text = "Thief";
		nText.text = "A thief takes some fish from your stockpile in the night.";
	}

	public void OptionOneEventSix(){
		EventSixOne.SetActive (false);
		returnButton.SetActive (true);
		if (manager.Fishes >= 2) {
			manager.Fishes -= 2;
			nText.text = "I bet it was squirrels. you say to yourself, and find that you lost 2 fish.";
		}else if (manager.Fishes == 1) {
			manager.Fishes--;
			nText.text = "I bet it was squirrels. you say to yourself, and find that you lost 1 fish.";
		}
	}

	//Event Seven - Bearpocalypse
	public void EventSevenSetup(){
		UserInput.SetActive(false);
		DayBox.SetActive (false);
		EventSevenOne.SetActive (true);
		EventSevenTwo.SetActive (true);
		eventPanel.SetActive (true);
		nTitle.text = "Passing Comet";
		nText.text = "In times of peril, comets have been seen as a mark of the end times... for bears. ";
	}

	public void OptionOneEventSeven(){
		EventSevenOne.SetActive (false);
		EventSevenTwo.SetActive (false);
		returnButton.SetActive (true);
		if (manager.Morale >= 2) {
			nText.text = "How positively frightening! (you lose 1 morale)";
			manager.Morale--;
		} else {
			
			nText.text = "You're already at the worst possible morale. The end times are just another additionm to your list of worries.";
		}
	}

	public void OptionTwoEventSeven(){
		EventSevenOne.SetActive (false);
		EventSevenTwo.SetActive (false);
		returnButton.SetActive (true);
		if (manager.Morale >= 2) {
			manager.Morale--;
			nText.text = "If only we had more fish (you lose 1 morale)";
		} else {
			
			nText.text = "If only we had more fish";
		}
	}

	//Event Eight - Good deeds
	public void EventEightSetup(){
		UserInput.SetActive(false);
		DayBox.SetActive (false);
		EventEightOne.SetActive (true);
		EventEightTwo.SetActive (true);
		eventPanel.SetActive (true);
		nTitle.text = "Good Night";
		nText.text = "It's a good night today. You feel it would be useful to teach your cubs a lesson.";
	}

	public void OptionOneEventEight(){
		EventEightOne.SetActive (false);
		EventEightTwo.SetActive (false);
		returnButton.SetActive (true);
		nText.text = "You decide your cubs a lesson in fishing. They wade into the waters of a nearby lake, and start pouncing at anything that moves. How cute! You gain 2 fish.";
		manager.Fishes += 2;
	}

	public void OptionTwoEventEight(){
		EventEightOne.SetActive (false);
		EventEightTwo.SetActive (false);
		returnButton.SetActive (true);
		if (manager.Morale < 5) {
			nText.text = "You indulge the cubs in the sweeter things in life... like honey! You find a bee hive hiding in a nearby tree, and let your cubs have at it. You gain 1 morale, as well as a really sticky face.";
			manager.Morale++;
		} else if (manager.Morale == 5) {
			nText.text = "You indulge the cubs in the sweeter things in life... like honey! You find a bee hive hiding in a nearby tree, and let your cubs have at it. You gain a really sticky face.";

		}
	}

	//Event Nine - magical potion of healing
	public void EventNineSetup(){	
		UserInput.SetActive(false);
		DayBox.SetActive (false);	
		EventNineOne.SetActive (true);
		EventNineTwo.SetActive (true);
		eventPanel.SetActive (true);
		nTitle.text = "Magical Potion of Healing";
		nText.text = "You find a magical potion of healing, left by some idiot who must've hoarded it for a boss battle and died on the way.";
	}

	public void OptionOneEventNine(){
		EventNineOne.SetActive (false);
		EventNineTwo.SetActive (false);
		returnButton.SetActive (true);
		nText.text = "You decide to drink it. It tastes really, really bad, losing you 2 morale, but at least you gain 1 hp in the process.";
		manager.Health++;
		if (manager.Morale >= 3) {
			manager.Morale -= 2;
			if(manager.Health < 10){
				manager.Health++;
				nText.text = "You decide to drink it. It tastes really, really bad, losing you 2 morale, but at least you gain 1 hp in the process.";
			} else {
				nText.text = "You decide to drink it. It tastes really, really bad, and worst of all, you're on max health! You lose 2 morale, and hopefully gain some common sense.";
			}
		} else if (manager.Morale == 2) {
			manager.Morale--;
			if(manager.Health < 10){
				nText.text = "You decide to drink it. It tastes really, really bad, losing you 1 morale, but at least you gain 1 hp in the process.";
				manager.Health++;
			}else{
				nText.text = "You decide to drink it. It tastes really, really bad, and worst of all, you're on max health! You lose 1 morale, and hopefully gain some common sense.";
			}
		} else if (manager.Morale == 1) {
			if(manager.Health < 10){
				nText.text = "You decide to drink it. It tastes really, really bad, but at least you gain 1 hp in the process.";
				manager.Health++;
			}else{
				nText.text = "You decide to drink it. It tastes really, really bad, and worst of all, you're on max health! You don't lose any morale, but hopefully gain some common sense.";
			}
		}
	}

	public void OptionTwoEventNine(){
		EventNineOne.SetActive (false);
		EventNineTwo.SetActive (false);
		returnButton.SetActive (true);
		nText.text = "You use the healing potion on one of your injured cubs. Making the family happier, you gain 1 morale.";
		if (manager.Morale <= 4) {
			manager.Morale++;
		} else {
			nText.text = "You use the healing potion on one of your injured cubs. The family is happy as it can be, but you bet that'll help your cub in the meantime.";
		}
	}

	//Event Ten - to pile or not to pile
	public void EventTenSetup(){
		UserInput.SetActive(false);
		DayBox.SetActive (false);
		EventTenOne.SetActive (true);
		EventTenTwo.SetActive (true);
		eventPanel.SetActive (true);
		nTitle.text = "To Pile Or Not To Pile";
		nText.text = "There's a sizeable stockpile of fish left by a family of migrating otters. It looks and smells unappealing, so it's up to you whether you want to eat it.";
	}

	public void OptionOneEventTen(){
		EventTenOne.SetActive (false);
		EventTenTwo.SetActive (false);
		returnButton.SetActive (true);
		manager.Fishes += 5;
		if (manager.Morale <= 3) {
			nText.text = "Why waste good... well, food? You gain 5 fish, but lose 2 morale.";
			manager.Morale -= 2;
		} else if (manager.Morale == 2) {
			nText.text = "Why waste good... well, food? You gain 5 fish, but lose 1 morale.";
			manager.Morale--;
		} else if (manager.Morale == 1) {
			nText.text = "Why waste good... well, food? You gain 5 fish.";
		}

	}

	public void OptionTwoEventTen(){
		EventTenOne.SetActive (false);
		EventTenTwo.SetActive (false);
		returnButton.SetActive (true);
		nText.text = "You decide to keep walking. The day dawns once more.";
	}

	public void ReturnToGame(){
		returnButton.SetActive (false);
		eventPanel.SetActive (false);
		UserInput.SetActive (true);
	}
}
