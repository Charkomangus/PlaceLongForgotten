using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCardController : MonoBehaviour {

    public Vector2Int positionInGrid;
    public bool clicked;

	// Use this for initialization
	void Start () {
        clicked = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseOver() {

        if (Input.GetMouseButtonDown(0) && clicked == false)
        {
            GameObject memoryGame = GameObject.FindGameObjectWithTag("GameGrid");

            if (memoryGame.GetComponent<MemoryGameManager>().cardSelectFirst == null)
            {
                memoryGame.GetComponent<MemoryGameManager>().cardSelectFirst = gameObject;
            }
            else if (memoryGame.GetComponent<MemoryGameManager>().cardSelectSecond == null)
            {
                memoryGame.GetComponent<MemoryGameManager>().cardSelectSecond = gameObject;
            }

            clicked = true;
        }

    }
}
