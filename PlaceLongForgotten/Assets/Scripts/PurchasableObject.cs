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

        public string buyText;
        public string sellText;
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
            SetText();
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
                    _price = 500;
                    break;
                case "SleepingBag":
                    buyText = "Wrap up safely in a warm sleeping bag.";
                    sellText = "";
                    _price = 800;
                    break;
                case "Fire":
                    buyText = "Warm your life up with a fire.";
                    sellText = "";
                    _price = 1000;
                    break;
                case "Stars":
                    buyText = " Light up the sky!";
                    sellText = "";
                    _price = 1000;
                    break;
                case "JetSki":
                    buyText = "Zoom across the lake on your private jet ski.";
                    sellText = "";
                    _price = 10000;
                    break;
                case "Boat":
                    buyText = " Glam up your camping trip!";
                    sellText = "";
                    _price = 9999999;
                    break;
                case "Canoes":
                    buyText = "Take a scenic paddle on the lake.";
                    sellText = "";
                    _price = 2500;
                    break;
                case "Barbecue":
                    buyText = "Put your best chef foot forward.";
                    sellText = "";
                    _price = 1500;
                    break;
                case "Fireflies":
                    buyText = "Add some magic to your memory!";
                    sellText = "";
                    _price = 800;
                    break;


                case "MusicRecorder":
                    buyText = "Rock your party with some music!";
                    sellText = "600";
                    _price = 800;
                    break;
                case "ChampagneBottle":
                    buyText = "Bubbles to make you feel precious!";
                    sellText = "1000";
                    _price = 1000;
                    break;
                case "CakeCandles":
                    buyText = " Light up your party!";
                    sellText = "500";
                    _price = 500;
                    break;
                case "Presents":
                    buyText = "Treat yourself with some presents!";
                    sellText = "1000";
                    _price = 1000;
                    break;
                case "Balloons":
                    buyText = "Blow up balloons so your party doesn’t blow!";
                    sellText = "500";
                    _price = 500;
                    break;
                case "Confetti":
                    buyText = "Sprinkle joy on your celebration!";
                    sellText = "1000";
                    break;
                case "Puppy":
                    buyText = "A puppy is the life of the party!!";
                    sellText = "1500";
                    _price = 1500;
                    break;
                case "People ":
                    buyText = "The more, the merrier! Friends are the best!";
                    sellText = "1000";
                    _price = 1000;
                    break;
                case "Beatles":
                    buyText = "Bringing the concert to you: the Beatles!";
                    sellText = "25000";
                    _price = 25000;
                    break;


                case "Boss":
                    buyText = "Knock yourself (and your boss) out!";
                    sellText = "";
                    _price = 10000;
                    break;
                case "Helicopter":
                    buyText = "Get high on Life.";
                    sellText = "";
                    _price = 100000;
                    break;
                case "Presidential":
                    buyText = "Get high on Life.";
                    sellText = "";
                    _price = 10000;
                    break;
                case "Graduation":
                    buyText = "Enjoy the taste of freedom. You got your degree!";
                    sellText = "";
                    _price = 2500;
                    break;
                case "Crowd":
                    buyText = "Choose your groupies.";
                    sellText = "";
                    _price = 1000;
                    break;
                case "Banners":
                    buyText = "You’re successful, spell it out.";
                    sellText = "";
                    _price = 500;
                    break;
                case "Fireworks":
                    buyText = "Light up the sky with fireworks!";
                    sellText = "";
                    _price = 700;
                    break;
                case "Girlfriend":
                    buyText = "You’re sexy and you know it.";
                    sellText = "";
                    _price = 3000;
                    break;
                case "Boyfriend":
                    buyText = "You’re sexy and you know it.";
                    sellText = "";
                    _price = 3000;
                    break;
                case "Bodyguards":
                    buyText = "Keep your friends close but keep your bodyguards closer.";
                    sellText = "";
                    _price = 1200;
                    break;
            }
        }

    }
}

