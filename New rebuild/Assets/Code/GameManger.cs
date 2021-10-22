using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{
    public float playerHealth;
    public float Playerdamage;
    public float EnemyDamage;
    public int pistolLevel;
    public int shotgunLevel;
    public int rifleLevel;
    public Image Heart1;
    public Image Heart2;
    public Image Heart3;
    public Image Gameover;
    public Sprite FullHeart;
    public Sprite HalfHeart;
    public Sprite EmptyHeart;
    public bool isDead;
    PlayerMovement player;
    public Text GameOver;
    public Text Replay;
    public int healthKits;
    public Text MedKit;
    public bool CanPickUpHealth;
    public Text PickUp;
    PickUp Destory;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        Heart1.sprite = FullHeart;
        Heart2.sprite = FullHeart;
        Heart3.sprite = FullHeart;
        Gameover.enabled = false;
        player = FindObjectOfType<PlayerMovement>();
        player.enabled = true;
        GameOver.enabled = false;
        Replay.enabled = false;
        MedKit.text = "Current Medkits: " + healthKits.ToString();
        CanPickUpHealth = false;
        PickUp.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
        if(Input.GetKeyDown(KeyCode.E) && CanPickUpHealth)
        {
            healthKits += 1;
            MedKit.text = "Current Medkits: " + healthKits.ToString();
            PickUp.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.G) && playerHealth < 3 && healthKits > 0)
        {
            playerHealth += .5f;
            healthKits -= 1;
            MedKit.text = "Current Medkits: " + healthKits.ToString();
        }
        switch (playerHealth)
        {
            case 3:
                Heart1.sprite = FullHeart;
                Heart2.sprite = FullHeart;
                Heart3.sprite = FullHeart;
                break;
            case 2.5f:
                Heart1.sprite = HalfHeart;
                break;
            case 2:
                Heart1.sprite = EmptyHeart;
                Heart2.sprite = FullHeart;
                break;
            case 1.5f:
                Heart1.sprite = EmptyHeart;
                Heart2.sprite = HalfHeart;
                break;
            case 1:
                Heart1.sprite = EmptyHeart;
                Heart2.sprite = EmptyHeart;
                Heart3.sprite = FullHeart;
                break;
            case 0.5f:
                Heart1.sprite = EmptyHeart;
                Heart2.sprite = EmptyHeart;
                Heart3.sprite = HalfHeart;
                break;
            case 0:
                Heart1.sprite = EmptyHeart;
                Heart2.sprite = EmptyHeart;
                Heart3.sprite = EmptyHeart;
                isDead = true;
                StartCoroutine(EndScreen());
                break;
        }
        IEnumerator EndScreen()
        {
            player.enabled = false;
            yield return new WaitForSeconds(1);
            Gameover.enabled = true;
            yield return new WaitForSeconds(.5f);
            GameOver.enabled = true;
            yield return new WaitForSeconds(.5f);
            Replay.enabled = true;
        }
    }
}
