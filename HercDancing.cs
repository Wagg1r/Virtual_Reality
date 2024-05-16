using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HercDancing : MonoBehaviour
{
    Animator anim;
    
    // Array to track character dance moves
    bool[] movesBusted;

    //number of moves available
    public int numberOfMoves;

    // Start is called before the first frame update
    void Start()
    {
        // Setting the animator to the animator component
        anim = GetComponent<Animator>();
        movesBusted = new bool[numberOfMoves];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            BustRandomMove();
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            anim.SetTrigger("Dance Circuit 1");
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            anim.SetTrigger("old dances");
        }
    }

    void BustRandomMove()
    {
        // first, make sure we have at least one unused move to choose
        CheckMoves(movesBusted);
        
        //pick random number
        int moveIndex = Random.Range(0, numberOfMoves);

        //pick another move if already choosen
        if (movesBusted[moveIndex] == true)
        { BustRandomMove(); }
        
        //bust move and add it to the array of previously used moves
        else
        {
            movesBusted[moveIndex] = true;
            anim.SetInteger("MoveIndex", moveIndex);
            anim.SetTrigger("Bust move");
        }
    }
    void ResetMoves(bool[] moves, bool isBusted)
    {
        // loop through the array, setting them all to the reques value
        for (int i = 0; i < moves.Length; i++) 
        {
            moves[i] = isBusted;
        }
    }
    /// <summary>
    /// loops through an array of booleans checking their values. if they are all true reset all to false
    /// </summary>
    /// <param name="moves"></param>
    void CheckMoves(bool[] moves)
    {
        int numMovesBusted = 0;
        foreach(bool move in moves) 
        {
            if (move == true)
            {
              numMovesBusted += 1; 
            }
        }
        if (numMovesBusted >= moves.Length)
        {
            ResetMoves(moves, false);
        }
    }
}
