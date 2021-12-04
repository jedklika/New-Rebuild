using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip CleanUp, Close, ItemSelect, Pistol, Shotgun, Rebuild, Walk, Open;
    static AudioSource Source;
    // Start is called before the first frame update
    void Start()
    {
        CleanUp = Resources.Load<AudioClip>("Clean up");
        Close = Resources.Load<AudioClip>("Close SFX");
        ItemSelect = Resources.Load<AudioClip>("Item Selection SFX");
        Pistol = Resources.Load<AudioClip>("Pistol SFX");
        Shotgun = Resources.Load<AudioClip>("Shotgun SFX");
        Rebuild = Resources.Load<AudioClip>("Rebuild SFX");
        Walk = Resources.Load<AudioClip>("Footsteps SFX");
        Open = Resources.Load<AudioClip>("Open SFX");

        Source = GetComponent<AudioSource>();
    }

    public static void PlaySound (string clip)
    {
        switch(clip)
        {
            case "Clean up":
                Source.PlayOneShot(CleanUp);
                break;
            case "Close SFX":
                Source.PlayOneShot(Close);
                break;
            case "Item Selection SFX":
                Source.PlayOneShot(ItemSelect);
                break;
            case "Pistol SFX":
                Source.PlayOneShot(Pistol);
                break;
            case "Shotgun SFX":
                Source.PlayOneShot(Shotgun);
                break;
            case "Rebuild SFX":
                Source.PlayOneShot(Rebuild);
                break;
            case "Walk":
                Source.PlayOneShot(Walk);
                break;
            case "Open SFX":
                Source.PlayOneShot(Open);
                break;

        }
    }
}
