using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartHealthSystem
{
    //list of all hearts
    private List<Heart> heartList;
    
    //constructor that recieves heart amount
    //also stores fragment int
    public HeartHealthSystem(int heartAmount) {
       
        heartList = new List<Heart>();

        for(int i = 0; i < heartAmount; i++){
            // all hearts start at full health (2)
            Heart heart = new Heart(2);
            heartList.Add(heart);
        }
    }
    public List<Heart> GetHeartList() {
        return heartList;
    }

        //Represents a Single Heart
        public class Heart {

        private int fragments;

        public Heart(int fragments){
            this.fragments = fragments;
        }
        
           public int GetFragmentAmount(){
                return fragments;
            }
        }
    }



