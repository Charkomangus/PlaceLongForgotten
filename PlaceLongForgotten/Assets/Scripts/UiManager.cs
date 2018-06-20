using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class UiManager : MonoBehaviour
    {
        public Button BuyButton;
        public Button SellButton;
        public Text MainText;
        public CanvasGroup PopUp;

        public GameObject Cursor;
        // Use this for initialization
        void Start () {
		
        }
	
        // Update is called once per frame
        void Update () {
            Cursor.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z);
        }

        //Open the pop up
        public void OpenPopUp()
        {
            PopUp.blocksRaycasts = true;
            PopUp.alpha = 1.0f;
            PopUp.interactable = true;
        }

        public void SetUpPopUp(PurchasableObject _object)
        {
            if (_object.tag == "EmptyObject")
            {
                MainText.text = "THIS IS AN AMAZING " + _object.name + " THAT IMPROVES THIS MEMORY. BUY IT FOR " + _object.GetPrice() + " NEURONS?";
                BuyButton.gameObject.SetActive(true);
                SellButton.gameObject.SetActive(false);
            }
            else
            {
                MainText.text = "THIS IS AN AMAZING " + _object.name + " THAT IMPROVES THIS MEMORY. SELL IT FOR " + _object.GetPrice() + " NEURONS?";
                BuyButton.gameObject.SetActive(false);
                SellButton.gameObject.SetActive(true);
            }
        }

        public void OutOfCash()
        {
            MainText.text = "NOT ENOUGH MONEY. YOU MUST WORK MORE CITIZEN";
            BuyButton.gameObject.SetActive(false);
            SellButton.gameObject.SetActive(false);

        }

        //Close the pop up
        public void ClosePopUp()
        {
            PopUp.blocksRaycasts = false;
            PopUp.alpha = 0.0f;
            PopUp.interactable = false;
        }
    }
}
