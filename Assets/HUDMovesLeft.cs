using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDMovesLeft : MonoBehaviour {

	public World world;
	public TextMeshProUGUI text;
	int movesLeft = 0;

	void Update() {
		if (movesLeft != world.movesLeft) {
			movesLeft = world.movesLeft;
			text.text = "" + movesLeft;
		}
	}
}
