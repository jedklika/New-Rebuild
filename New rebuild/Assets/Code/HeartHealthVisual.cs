using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using CodeMonkey; // remove later

public class HeartHealthVisual : MonoBehaviour
{

    //serialized field makes variable private but i can still view in editor
    [SerializeField] private Sprite heart0Sprite;
    [SerializeField] private Sprite heart1Sprite;
    [SerializeField] private Sprite heart2Sprite;


    //stores list of heart images
    private List<HeartImage> heartImageList;
    //store hearts in SetHeartsHealthSystem
    private HeartHealthSystem heartsHealthSystem;

    //heart image created here
    private void Awake()
    {
        heartImageList = new List<HeartImage>();
    }


    private void Start()
    {
        //create new health system with 3 hearts
        HeartHealthSystem heartsHealthSystem = new HeartHealthSystem(3);

        //call this function to set our hearts
        SetHeartsHealthSystem(heartsHealthSystem);

        //create testing buttons
     //   CMDebug.ButtonUI(new Vector2(-50, -100),"Damage 1", () => heartsHealthSystem.Damage(1)); //18:14
     //   CMDebug.ButtonUI(new Vector2(50, -100),"Heal 1",() => heartsHealthSystem.Heal(1));
        
        //  CreateHeartImage(new Vector2(-360, 0)).SetHeartFragments(2);
        //  CreateHeartImage(new Vector2(-310, 0)).SetHeartFragments(1);
        //  CreateHeartImage(new Vector2(-260, 0)).SetHeartFragments(0);

    }

    //connects logic from HeartHealthSystem to the Visual
    public void SetHeartsHealthSystem(HeartHealthSystem heartsHealthSystem)
    {
        this.heartsHealthSystem = heartsHealthSystem;

        List<HeartHealthSystem.Heart> heartList = heartsHealthSystem.GetHeartList();
        Vector2 heartAnchoredPosition = new Vector2(-360, 195);
        for (int i = 0; i < heartList.Count; i++)
        {
            //offset images, everytime you add a heart it will move 50 spaces right
            //original place is -360,195
            //for every heart create a new image 
            HeartHealthSystem.Heart heart = heartList[i];
            //fragments based on hearts
            //This creates a heart at a certain position then uses GetFragmentAmount to choose which fragment (empty,full,half)
            CreateHeartImage(heartAnchoredPosition).SetHeartFragments(heart.GetFragmentAmount());
            heartAnchoredPosition += new Vector2(50, 0); // issue, all hearts are in the same position

        }
        //suscribe to damaga and healing events + death events
        heartsHealthSystem.onDamaged += HeartsHealthSystem_OnDamaged;
        heartsHealthSystem.onHealed += HeartsHealthSystem_OnHealed;
        heartsHealthSystem.onDead += HeartsHealthSystem_OnDead;

    }

    //if you lose all health, print out your dead/ later will create popup
    private void HeartsHealthSystem_OnDead(object sender, System.EventArgs e)
    {
        print("You Dead");
        
    }
    private void HeartsHealthSystem_OnHealed(object sender, System.EventArgs e)
    {
        //Hearts health system was healed=
         RefreshAllHearts();
    }
    private void HeartsHealthSystem_OnDamaged(object sender, System.EventArgs e)
    {
        //Hearts health system was damaged
          RefreshAllHearts();
  
    }

    private void RefreshAllHearts()
    {
        List<HeartHealthSystem.Heart> heartList = heartsHealthSystem.GetHeartList();
        //cycle through hearts and "refresh them"
        for (int i = 0; i < heartImageList.Count; i++)
        {
            HeartImage heartImage = heartImageList[i];
            HeartHealthSystem.Heart heart = heartList[i];
            heartImage.SetHeartFragments(heart.GetFragmentAmount());
        }
    }




    //Function to create heart images and returns them
    //Vector is to choose heart positions on screen
    private HeartImage CreateHeartImage(Vector2 anchoredPosition)
    {
        //Create Game Object
        GameObject heartGameObject = new GameObject("Heart", typeof(Image));

        //set as child of this transform(gives object its position)
        heartGameObject.transform.parent = transform;
        heartGameObject.transform.localPosition = Vector3.zero;

        // location for hearts, sets size of hearts
        heartGameObject.GetComponent<RectTransform>().anchoredPosition = anchoredPosition;
        heartGameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(150, 150);

        //set heart sprite
        Image heartImageUI = heartGameObject.GetComponent<Image>();
        heartImageUI.sprite = heart0Sprite;

        //create heart image, will be added to heart image list
        HeartImage heartImage = new HeartImage(this, heartImageUI);
        heartImageList.Add(heartImage);


        return heartImage;

    }

    //represents a single heart

    public class HeartImage
    {
        private int fragments; //maybe remove
        private Image heartImage;
        private HeartHealthVisual heartsHealthVisual;
        public HeartImage(HeartHealthVisual heartsHealthVisual, Image heartImage)
        {

            this.heartsHealthVisual = heartsHealthVisual;
            this.heartImage = heartImage;
        }

        //sets the "fragments"; half heart, full heart, empty heart
        public void SetHeartFragments(int fragments)

        {
            this.fragments = fragments; //maybe remove
            switch (fragments)
            {
                case 0: heartImage.sprite = heartsHealthVisual.heart0Sprite; break;
                case 1: heartImage.sprite = heartsHealthVisual.heart1Sprite; break;
                case 2: heartImage.sprite = heartsHealthVisual.heart2Sprite; break;
            }

        }


    }

}

    




