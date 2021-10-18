using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartHealthVisual : MonoBehaviour
{

    //serialized field makes variable private but i can still view in editor
    [SerializeField] private Sprite heart0Sprite;
    [SerializeField] private Sprite heart1Sprite;
    [SerializeField] private Sprite heart2Sprite;


    //stores list of heart images
    private List<HeartImage> heartImageList;


    //heaert image created here
    private void Awake()
    {
        heartImageList = new List<HeartImage>();
    }


    private void Start()
    {
        //creates hearts
        CreateHeartImage(new Vector2(-360, 195)).SetHeartFragments(2);
        CreateHeartImage(new Vector2(-310, 195)).SetHeartFragments(1); ;
        CreateHeartImage(new Vector2(-260, 195)).SetHeartFragments(0); ;
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

        //idk i'm getting error
        return heartImage;

    }

    //represents a single heart
    public class HeartImage
    {
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
            switch (fragments)
            {
                case 0: heartImage.sprite = heartsHealthVisual.heart0Sprite; break;
                case 1: heartImage.sprite = heartsHealthVisual.heart1Sprite; break;
                case 2: heartImage.sprite = heartsHealthVisual.heart2Sprite; break;
            }

        }


    }

}
    




