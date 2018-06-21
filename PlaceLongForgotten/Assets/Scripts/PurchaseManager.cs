using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace Assets.Scripts
{
    public class PurchaseManager : MonoBehaviour
    {

        [SerializeField] private int _credits;
        private PurchasableObject _currentObject;
        private RigidbodyFirstPersonController _characterController;
        private GameObject[] _purchaseObjects;
        private UiManager _uiManager;
        public AudioSource _audioSource;
        public AudioClip _SfxBuy;
        public AudioClip _SfxSell;
        public AudioClip _SfxDenied;

        // Use this for initialization
        void Start ()
        {
            Cursor.visible = false;
            _characterController = FindObjectOfType<RigidbodyFirstPersonController>();
            _purchaseObjects = GameObject.FindGameObjectsWithTag("Object");
            _uiManager = FindObjectOfType<UiManager>();
           // TakePlayerControl();
        }
	
        // Update is called once per frame
        void Update () {
        }

        // Enable the player controolled and kill the cursor
        public void ReturnPlayerControl()
        {
            Cursor.lockState = CursorLockMode.Confined;
            _uiManager.Cursor.SetActive(false);
        
            _characterController.enabled = true; // Turn off the component
        }

        //Bring the cursor back and freeze the player
        public void TakePlayerControl()
        {
            Cursor.lockState = CursorLockMode.None;
            _uiManager.Cursor.SetActive(true);
            _characterController.enabled = false; // Turn off the component
        }

        //Bring the cursor back and freeze the player
        public void Sell()
        {
            if (_currentObject == null) return;
            _credits += _currentObject.GetPrice();
            _currentObject.TurnIntoEmpty();
            ReturnPlayerControl();
            _currentObject = null;
            _uiManager.ClosePopUp();
            _audioSource.PlayOneShot(_SfxSell);
        }

        //Bring the cursor back and freeze the player
        public void Buy()
        {
            if (_currentObject == null) return;
            if (_credits - _currentObject.GetPrice() < 0)
            {
                _uiManager.OutOfCash();
                _currentObject = null;
                _audioSource.PlayOneShot(_SfxDenied);
                return;
            }
            _audioSource.PlayOneShot(_SfxBuy);
            _uiManager.ClosePopUp();
            _credits -= _currentObject.GetPrice();
            _currentObject.TurnIntoObject();
            ReturnPlayerControl();
            _currentObject = null;
        }

        //Sets object selected
        public void SetCurrentObject(PurchasableObject purchasableObject)
        {
            _currentObject = purchasableObject;
        }
    }
}
