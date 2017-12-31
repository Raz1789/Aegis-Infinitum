using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour {

    public Text prompt;
    public Text optionOne;
    public Text optionTwo;

    public string promptA = "ARE YOU LOST, STRANGER?";
    public string promptAA = "GOOD DAY TO YOU THEN. DO YOU REQUIRE ASSISTANCE?";
    public string promptAB = "WHAT HAS GOT YOU IN SUCH A FOUL MOOD?!";
    public string promptAAA = "VISIT THE DRUNKEN ACHOO FOR A GOOD MEAL AND A PLACE TO REST YOUR HEAD.";
    public string promptABB = "HOW UNFORTUNATE. YOU SHOULD LET THE DUKE KNOW OF THIS NEW THREAT!";
    public string promptAAAA = "HAVE NICE LIFE.";

    public string replyAA = "NOT AT ALL, KIND SIRE.";
    public string replyAB = "BUZZ OFF!";
    public string replyABA = "I'M JUST TIRED AND HUNGRY!";
    public string replyAAA = "NO, JUST HAVING A STROLL THROUGH THE WOODLAND PATH.";
    public string replyAAB = "DO YOU KNOW OF AN INN NEARBY";
    public string replyABB = "I WAS ASSAULTED BY SOME BANDITS UP THE ROAD!";
    public string replyAAAA = "GOODBYE.";

    public int placeInConvo = 0;

    public bool optionOneChosen = false;
    public bool optionTwoChosen = false;

	void Start ()
    {

	}
	
	void Update ()
    {
        HandleDialogue();

        //optionOne.text = replyAA;
        //optionTwo.text = replyAB;
	}

    public void HandleDialogue()
    {
        if (placeInConvo == 0)
        {
            prompt.text = promptA;
        }

        if(placeInConvo == 1 && optionOneChosen)
        {
            prompt.text = promptAA;
        }

        if (placeInConvo == 1 && optionTwoChosen)
        {
            prompt.text = promptAB;
        }

        if (placeInConvo == 2 && optionOneChosen)
        {
            prompt.text = promptAAA;
        }

        if (placeInConvo == 2 && optionTwoChosen && prompt.text == promptAA && optionTwo.text == replyAAB)
        {
            prompt.text = promptAAA;
        }

        if (placeInConvo == 2 && optionTwoChosen && prompt.text != promptAAA && optionTwo.text != replyAAB)
        {
            prompt.text = promptABB;
        }

        if (placeInConvo == 3 && optionOneChosen)
        {
            prompt.text = promptAAAA;
        }

        //12345678

        if (placeInConvo == 0)
        {
            optionOne.text = replyAA;
        }

        if (placeInConvo == 1 && prompt.text == promptAA)
        {
            optionOne.text = replyAAA;
        }

        if (placeInConvo == 2 && prompt.text == promptAAA)
        {
            optionOne.text = replyAAAA;
            optionTwo.text = "";
        }

        //12345678

        if (placeInConvo == 0)
        {
            optionTwo.text = replyAB;
        }

        if (placeInConvo == 1 && prompt.text == promptAB)
        {
            optionTwo.text = replyABB;
        }

        if (placeInConvo == 1 && prompt.text == promptAB)
        {
            optionOne.text = replyABA;
        }

        if (placeInConvo == 2 && prompt.text == promptABB)
        {
            optionOne.text = replyAAAA;
        }

        if (placeInConvo == 2 && prompt.text == promptABB)
        {
            optionTwo.text = "";
        }

        if (placeInConvo == 1 && prompt.text == promptAA)
        {
            optionTwo.text = replyAAB;
        }
    }

    public void DialogueOptionOne()
    {
        optionOneChosen = true;
        optionTwoChosen = false;
        placeInConvo++;
    }

    public void DialogueOptionTwo()
    {
        optionTwoChosen = true;
        optionOneChosen = false;
        placeInConvo++;    }
}

