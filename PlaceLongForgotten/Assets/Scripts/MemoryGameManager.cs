using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryGameManager : MonoBehaviour {

    public Text gradeTextUI;
    public Text efficiencyTextUI;
    public Text correctTextUI;
    public Text guessesTextUI;
    public Text inARowTextUI;

    public int gridSizeX, gridSizeY;
    public float cellSpacingX, cellSpacingY;
    public GameObject[] cardList;

    private GameObject[][] gameGrid;
    public GameObject cardSelectFirst;
    public GameObject cardSelectSecond;

    public float showCardTime;

    private float gridXOffset;
    private float gridYOffset;

    private float guessAttempts;
    private float correctGuesses;
    private float guessesInARow;

    private float waitToResolveTimer;

    // Use this for initialization
    void Awake() {
        gameGrid = new GameObject[gridSizeX][];

        for (int i = 0; i < gridSizeX; i++)
        {
            gameGrid[i] = new GameObject[gridSizeY];
        }

        gridXOffset = (cellSpacingX * (gridSizeX - 1)) / 2.0f;
        gridYOffset = (cellSpacingY * (gridSizeY + 1)) / 2.0f;

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                gameGrid[x][y] = Instantiate(cardList[Random.Range(0, cardList.Length)], new Vector2((x * cellSpacingX) - gridXOffset, ((gridSizeY - y) * cellSpacingY) - gridYOffset), Quaternion.identity, transform);
                gameGrid[x][y].GetComponent<GameCardController>().positionInGrid = new Vector2Int(x, y);
            }
        }

        guessAttempts = 32;
        correctGuesses = 24;
        guessesInARow = 0;

        waitToResolveTimer = 0;
    }
	
	// Update is called once per frame
	void Update () {

        if (cardSelectFirst != null && cardSelectSecond != null)
        {
            if (waitToResolveTimer < showCardTime)
            {
                waitToResolveTimer += Time.deltaTime;
            }
            else
            {
                guessAttempts++;
                if (cardSelectFirst.tag == cardSelectSecond.tag)
                {
                    correctGuesses++;
                    guessesInARow++;
                    ResolveCorrectMatch();
                }
                else
                {
                    guessesInARow = 0;
                    ResolveWrongMatch();
                }

                cardSelectFirst = null;
                cardSelectSecond = null;

                waitToResolveTimer = 0;
            }
        }

        UpdateUI();
	}

    void OnApplicationQuit()
    {
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Destroy(gameGrid[x][y]);
            }
        }
    }

    void ResolveCorrectMatch()
    {
        Vector2Int card1Position = cardSelectFirst.GetComponent<GameCardController>().positionInGrid;
        Destroy(cardSelectFirst);

        for (int y = card1Position.y; y >= 0; y--)
        {
            if (y != 0)
            {
                gameGrid[card1Position.x][y - 1].transform.position = new Vector2((card1Position.x * cellSpacingX) - gridXOffset, ((gridSizeY - y) * cellSpacingY) - gridYOffset);
                gameGrid[card1Position.x][y] = gameGrid[card1Position.x][y - 1];
                gameGrid[card1Position.x][y].GetComponent<GameCardController>().positionInGrid = new Vector2Int(card1Position.x, y);
            }
            else
            {
                gameGrid[card1Position.x][y] = Instantiate(cardList[Random.Range(0, cardList.Length)], new Vector2((card1Position.x * cellSpacingX) - gridXOffset, ((gridSizeY - y) * cellSpacingY) - gridYOffset), Quaternion.identity, transform);
                gameGrid[card1Position.x][y].GetComponent<GameCardController>().positionInGrid = new Vector2Int(card1Position.x, y);
            }
        }

        Vector2Int card2Position = cardSelectSecond.GetComponent<GameCardController>().positionInGrid;
        Destroy(cardSelectSecond);

        for (int y = card2Position.y; y >= 0; y--)
        {
            if (y != 0)
            {
                gameGrid[card2Position.x][y - 1].transform.position = new Vector2((card2Position.x * cellSpacingX) - gridXOffset, ((gridSizeY - y) * cellSpacingY) - gridYOffset);
                gameGrid[card2Position.x][y] = gameGrid[card2Position.x][y - 1];
                gameGrid[card2Position.x][y].GetComponent<GameCardController>().positionInGrid = new Vector2Int(card2Position.x, y);
            }
            else
            {
                gameGrid[card2Position.x][y] = Instantiate(cardList[Random.Range(0, cardList.Length)], new Vector2((card2Position.x * cellSpacingX) - gridXOffset, ((gridSizeY - y) * cellSpacingY) - gridYOffset), Quaternion.identity, transform);
                gameGrid[card2Position.x][y].GetComponent<GameCardController>().positionInGrid = new Vector2Int(card2Position.x, y);
            }
        }
    }

    void ResolveWrongMatch()
    {
        cardSelectFirst.GetComponent<GameCardController>().clicked = false;
        cardSelectFirst.GetComponent<GameCardController>().myCardBack.GetComponent<Animator>().SetBool("clicked", false);

        cardSelectSecond.GetComponent<GameCardController>().clicked = false;
        cardSelectSecond.GetComponent<GameCardController>().myCardBack.GetComponent<Animator>().SetBool("clicked", false);
    }

    void UpdateUI()
    {
        guessesTextUI.text = guessAttempts.ToString();
        correctTextUI.text = correctGuesses.ToString();
        inARowTextUI.text = guessesInARow.ToString();

        float efficiency = correctGuesses / guessAttempts;
        efficiency *= 100;
        Mathf.RoundToInt(efficiency);
        string efficiencyString = efficiency.ToString();
        efficiencyTextUI.text = efficiencyString;

        if (efficiency < 20)
        {
            gradeTextUI.text = "F";
        }
        else if (efficiency < 40)
        {
            gradeTextUI.text = "C";
        }
        else if (efficiency < 60)
        {
            gradeTextUI.text = "B";
        }
        else if (efficiency < 80)
        {
            gradeTextUI.text = "A";
        }
        else
        {
            gradeTextUI.text = "S";
        }
    }
}
