using UnityEngine;

namespace Assets.Scripts
{
    public class PurchasableObject : MonoBehaviour
    {
        private ParticleSystem _particleSystem;
        private PurchaseManager _purchaseManager;
        private UiManager _uiManager;
        private bool _contact;
        [SerializeField] private bool _empty;
        [SerializeField] private int _price;
        [SerializeField] private string _type;


        // Use this for initialization
        void Start ()
        {
            _particleSystem = GetComponentInChildren<ParticleSystem>();
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
            _particleSystem.Play();
            var temp = GetComponent<MeshRenderer>();
            temp.enabled = false;
            this.name = "EmptyObject";
            this.tag = "EmptyObject";
            _empty = true;
        }


        public void TurnIntoObject()
        {
            _particleSystem.Stop();
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

    }
}

