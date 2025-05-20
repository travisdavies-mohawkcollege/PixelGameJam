using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whichClass : StateMachineBehaviour
{
    public string Class;
    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        adventurer adventurer = animator.GetComponent<adventurer>();


        if (adventurer != null && adventurer.Class == "Rogue")
        {
            animator.SetBool("isRogue", true);
        }
        if (adventurer != null && adventurer.Class == "Fighter")
        {
            animator.SetBool("isFighter", true);
        }
        if (adventurer != null && adventurer.Class == "Mage")
        {
            animator.SetBool("isMage", true);
        }
        if (adventurer != null && adventurer.Class == "Archer")
        {
            animator.SetBool("isArcher", true);
        }
        if (adventurer.isDead == true)
        {
            animator.SetBool("isDead", true);
        }
    }



    // OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called before OnStateExit is called on any state inside this state machine
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called before OnStateMove is called on any state inside this state machine
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateIK is called before OnStateIK is called on any state inside this state machine
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMachineEnter is called when entering a state machine via its Entry Node
    //override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    //{
    //    
    //}

    // OnStateMachineExit is called when exiting a state machine via its Exit Node
    //override public void OnStateMachineExit(Animator animator, int stateMachinePathHash)
    //{
    //    
    //}
}
