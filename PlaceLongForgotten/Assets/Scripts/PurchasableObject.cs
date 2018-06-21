using UnityEngine;

namespace Assets.Scripts
{
    public class PurchasableObject : MonoBehaviour
    {
        private SphereCollider _emptyHologram;
        private PurchaseManager _purchaseManager;
        private UiManager _uiManager;
        private bool _contact;
        [SerializeField] private bool _empty;
        [SerializeField] private int _price;
       
        private string buyText;
        private string sellText;
        public string _type;
        private enum Type
        {
            Tent, SleepingBag, Fire, Stars, JetSki, Boat, Canoes, Barbecue, Fireflies,
            Recorder, Champagne, Candles, Presents, Balloons, Confetti, Puppy, Friends, Beatles,
            Boss, Helicopter, PresidentialMarch, Graduation, Crowd, Banners, Fireworks, Girlfriend, Bodyguards
        }

        // Use this for initialization
        void Start ()
        {
            _emptyHologram = GetComponentInChildren<SphereCollider>();
            _purchaseManager = FindObjectOfType<PurchaseManager>();
            _uiManager = FindObjectOfType<UiManager>();
            if (_empty)
            {
                TurnIntoEmpty();
            }
            else
            {
                TurnIntoObject();
            }
        }
	
        // Update is called once per frame
        void Update () {
            if (_contact)
            {
                if (Input.GetKeyDown(KeyCode.C))
                {
                    _uiManager.SetUpPopUp(this);
                    _uiManager.OpenPopUp();
                    _purchaseManager.TakePlayerControl();
                    _purchaseManager.SetCurrentObject(this);
                }
            }
        }

        void OnCollisionEnter(Collision other)
        {
            Debug.Log(other.gameObject.tag);
            if (other.gameObject.tag == "Player")
            {
                _contact = true;
            }
        }

        void OnCollisionExit(Collision other)
        {
            Debug.Log(other.gameObject.tag);
            if (other.gameObject.tag == "Player")
            {
                _contact = false;
            }
        }

        public void TurnIntoEmpty()
        {
            _emptyHologram.gameObject.SetActive(true);
            var temp = GetComponent<MeshRenderer>();
            temp.enabled = false;
            this.name = "EmptyObject";
            this.tag = "EmptyObject";
            _empty = true;
        }


        public void TurnIntoObject()
        {
            _emptyHologram.gameObject.SetActive(false);
            var temp = GetComponent<MeshRenderer>();
            temp.enabled = true;
            this.name = _type;
            this.tag = "Object";
            _empty = false;
        }

        public int GetPrice()
        {
            return _price;
        }

        public void SetPrice(int price)
        {
            _price = price;
        }

        public bool GetStatus()
        {
            return _empty;
        }


        private void SetText()
        {
            switch (_type)
            {
                case "Tent":
                    buyText = "Buy a tent for that rainy day.";
                    sellText = "";
                    break;
                case "SleepingBag":
                    buyText = "Wrap up safely in a warm sleeping bag.";
                    sellText = "";
                    break;
                case "Fire":
                    buyText = "Warm your life up with a fire.";
                    sellText = "";
                    break;
                case "Stars":
                    buyText = " Light up the sky!";
                    sellText = "";
                    break;
                case "JetSki":
                    buyText = "Zoom across the lake on your private jet ski.";
                    sellText = "";
                    break;
                case "Boat":
                    buyText = " Glam up your camping trip!";
                    sellText = "";
                    break;
                case "Canoes":
                    buyText = "Take a scenic paddle on the lake.";
                    sellText = "";
                    break;
                case "Barbecue":
                    buyText = "Put your best chef foot forward.";
                    sellText = "";
                    break;
                case "Fireflies":
                    buyText = "Add some magic to your memory!";
                    sellText = "";
                    break;


                case "MusicRecorder":
                    buyText = "Rock your party with some music!";
                    sellText = "";
                    break;
                case "ChampagneBottle":
                    buyText = "Bubbles to make you feel precious!";
                    sellText = "";
                    break;
                case "CakeCandles":
                    buyText = " Light up your party!";
                    sellText = "";
                    break;
                case "Presents":
                    buyText = "Treat yourself with some presents!";
                    sellText = "";
                    break;
                case "Balloons":
                    buyText = "Blow up balloons so your party doesn’t blow!";
                    sellText = "";
                    break;
                case "Confetti":
                    buyText = "Sprinkle joy on your celebration!";
                    sellText = "";
                    break;
                case "Puppy":
                    buyText = "A puppy is the life of the party!!";
                    sellText = "";
                    break;
                case "People ":
                    buyText = "The more, the merrier! Friends are the best!";
                    sellText = "";
                    break;
                case "Beatles":
                    buyText = "Bringing the concert to you: the Beatles!";
                    sellText = "";
                    break;


                case "Boss":
                    buyText = "Knock yourself (and your boss) out!";
                    sellText = "";
                    break;
                case "Helicopter":
                    buyText = "Get high on Life.";
                    sellText = "";
                    break;
                case "Presidential":
                    break;
                case "Graduation":
                    break;
                case "Crowd":
                    break;
                case "Banners":
                    break;
                case "Fireworks":
                    break;
                case "Girlfriend":
                    break;
                case "Bodyguards":
                    break;
            }
        }

    }
}

