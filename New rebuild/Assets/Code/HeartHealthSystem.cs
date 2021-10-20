using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartHealthSystem
{

    public const int MAX_FRAGMENT_AMOUNT = 4;
    
    //event triggered when health system takes damage
    public event EventHandler onDamaged;

    //event triggered when health system is healed
    public event EventHandler onHealed;

    public event EventHandler onDead;

    //list of all hearts
    private List<Heart> heartList;
    
    //constructor that recieves heart amount
    //also stores fragment int
    public HeartHealthSystem(int heartAmount) {
       
        heartList = new List<Heart>();

        for(int i = 0; i < heartAmount; i++){
            // all hearts start at full health (2)
            Heart heart = new Heart(3);
            heartList.Add(heart);
        }

        heartList[heartList.Count - 1].SetFragments(0);
    }
    public List<Heart> GetHeartList() {
        return heartList;
    }

    public void Damage(int damageAmount)
    {
        //Cycle through all hearts starting from end   
        for(int i = heartList.Count - 1; i >= 0; i--)
        {
            Heart heart = heartList[i];
            //Test if this heart can absorb damageAmount
            if(damageAmount > heart.GetFragmentAmount())
            {
                //Heart cannot absorb full damageAmount, damage heart and keep going to next heart
                damageAmount -= heart.GetFragmentAmount();
                heart.Damage(heart.GetFragmentAmount());
            }
            else
            {
                //this heart can handle all the damage, absorb and break out of cycle
                heart.Damage(damageAmount);
                break;

            }
        }
        if (onDamaged != null) onDamaged(this, EventArgs.Empty);

        //when you take damage it checks isDead
        if (isDead())
        {
            if (onDead != null) onDead(this, EventArgs.Empty);
        }
    }

    public void Heal(int healAmount)
    {
        for (int i = 0; i < heartList.Count; i++)
        {
            Heart heart = heartList[i];
            int missingFragments = MAX_FRAGMENT_AMOUNT - heart.GetFragmentAmount();

            if(healAmount > missingFragments) //we can still heal heart
            {
                healAmount -= missingFragments;
                heart.Heal(missingFragments);
            }
            else{
                heart.Heal(healAmount);
                break;
            }

        }
        if (onHealed != null) onHealed(this, EventArgs.Empty);
    }

    public bool isDead()
    {
        //if fragment amount is == 0
        return heartList[0].GetFragmentAmount() == 0;
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

        public void SetFragments(int fragments){
            this.fragments = fragments;
        }
        public void Damage(int damageAmount)
        {
            if (damageAmount >= fragments)
            {
                //creates empty heart if damage amount > fragment
                fragments = 0;
            }
            else
            {
                fragments -= damageAmount;
            }
        }

        public void Heal(int healAmount)
        {
            if (fragments + healAmount > MAX_FRAGMENT_AMOUNT)
            {
                //if health after heal amount is over Max fragment amount
                fragments = MAX_FRAGMENT_AMOUNT;
            }
            else
            {
                fragments += healAmount;
            }
        }
    }


    }



