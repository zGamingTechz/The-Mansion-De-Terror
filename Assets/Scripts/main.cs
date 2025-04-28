using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main : MonoBehaviour
{
    [SerializeField] Text storyText;
    [SerializeField] Button yesButton;
    [SerializeField] Button noButton;

    bool fuel = false;
    public static bool inhaler = false;

    private StoryState currentState;

    // Enum to define the different states in the story
    public enum StoryState
    {
        StartGame,
        SpottedWoman,
        TookWomanIn,
        NotTookWomanIn,
        StoppedAtPump,
        HelpedMan,
        NotHelpedMan,
        AtStore,
        LeftPump,
        AfterPump,
        ReachedMansion,
        FollowedPath,
        StayedInCar,
        HungryInCar,
        CrossedMansion,
        TurnedLeft,
        TurnedRight
    }

    void Start()
    {
        currentState = StoryState.StartGame;
        DisplayStory("You are on the way to your granny's on a highway. It's a late sunday night. Do you still want to play the game?");
        UpdateButtons();
    }

    void DisplayStory(string text)
    {
        storyText.text = text;
    }

    void UpdateButtons()
    {
        yesButton.onClick.RemoveAllListeners(); // Clear previous listeners
        noButton.onClick.RemoveAllListeners();

        switch (currentState)
        {
            case StoryState.StartGame:
                yesButton.onClick.AddListener(SpottedWoman);
                noButton.onClick.AddListener(Quit);
                break;
            case StoryState.SpottedWoman:
                yesButton.onClick.AddListener(TookWomanIn);
                noButton.onClick.AddListener(NotTookWomanIn);
                break;
            case StoryState.TookWomanIn:
                yesButton.onClick.AddListener(LookedBehind);
                noButton.onClick.AddListener(LookedBehind);
                break;
            case StoryState.NotTookWomanIn:
                yesButton.onClick.AddListener(StoppedAtPump);
                noButton.onClick.AddListener(LeftPump);
                break;
            case StoryState.StoppedAtPump:
                yesButton.onClick.AddListener(HelpedMan);
                noButton.onClick.AddListener(NotHelpedMan);
                break;
            case StoryState.HelpedMan:
                yesButton.onClick.AddListener(AtStore);
                noButton.onClick.AddListener(AtStore);
                break;
            case StoryState.NotHelpedMan:
                yesButton.onClick.AddListener(AtStore);
                noButton.onClick.AddListener(AtStore);
                break;
            case StoryState.AtStore:
                yesButton.onClick.AddListener(LeftPump);
                noButton.onClick.AddListener(LeftPump);
                break;
            case StoryState.LeftPump:
                yesButton.onClick.AddListener(AfterPump);
                noButton.onClick.AddListener(AfterPump);
                break;
            case StoryState.AfterPump:
                yesButton.onClick.AddListener(ReachedMansion);
                noButton.onClick.AddListener(ReachedMansion);
                break;
            case StoryState.ReachedMansion:
                if (fuel == true)
                {
                    yesButton.onClick.AddListener(CrossedMansion);
                    noButton.onClick.AddListener(CrossedMansion);
                }
                else
                {
                    yesButton.onClick.AddListener(FollowedPath);
                    noButton.onClick.AddListener(StayedInCar);
                }
                break;
            case StoryState.StayedInCar:
                yesButton.onClick.AddListener(HungryInCar);
                noButton.onClick.AddListener(HungryInCar);
                break;
            case StoryState.HungryInCar:
                yesButton.onClick.AddListener(FollowedPath);
                noButton.onClick.AddListener(died);
                break;
            case StoryState.CrossedMansion:
                yesButton.onClick.AddListener(TurnedRight);
                noButton.onClick.AddListener(TurnedLeft);
                break;
            case StoryState.TurnedRight:
                yesButton.onClick.AddListener(YesTurnedRight);
                noButton.onClick.AddListener(NoTurnedRight);
                break;
        }
    }

    void work_in_progress()
    {
        DisplayStory("Work in progress hehe...");
    }

    public void Quit()
    {
        Application.Quit();
    }

    void died()
    {
        SceneManager.LoadScene(2);
    }

    void SpottedWoman()
    {
        currentState = StoryState.SpottedWoman;
        DisplayStory("You spot a woman dressed as a bride on roadside waving her hand, asking for a ride to some mansion on your way. Do you want to pick her up?");
        UpdateButtons();
    }

    void TookWomanIn()
    {
        currentState = StoryState.TookWomanIn;
        DisplayStory("The woman is sitting behind you but wait...she's not appearing in the mirror! Do you want to look behind?");
        UpdateButtons();
    }

    void NotTookWomanIn()
    {
        currentState = StoryState.NotTookWomanIn;
        DisplayStory("After leavng a helpless woman alone this late at night and driving for a while you arrived at a petrol pump. Want to stop?");
        UpdateButtons();
    }

    void LookedBehind()
    {
        SceneManager.LoadScene(2);
    }

    void StoppedAtPump()
    {
        fuel = true;
        currentState = StoryState.StoppedAtPump;
        DisplayStory("A man approaches you after stopping, asking for directions. Do you want to help?");
        UpdateButtons();
    }

    void HelpedMan()
    {
        currentState = StoryState.HelpedMan;
        DisplayStory("The man says thanks and hands you 50 cash. Do you want to continue?");
        UpdateButtons();
    }

    void NotHelpedMan()
    {
        currentState = StoryState.NotHelpedMan;
        DisplayStory("You refused to help the man even tho you knew the directions. Are you sure about your life?");
        UpdateButtons();
    }

    void AtStore()
    {
        if (currentState == StoryState.HelpedMan)
        {
            DisplayStory("You see a store and it sells asthma inhalers for 50 bucks. You have enough so you bought one. Continue?");
            inhaler = true;
        }
        else
        {
            DisplayStory("You see a store and it sells asthma inhalers for 50 bucks. You have no money to buy one. Continue?");
        }
        currentState = StoryState.AtStore;
        UpdateButtons();
    }

    void LeftPump()
    {
        if (currentState == StoryState.AtStore)
        {
            if (inhaler == true)
            {
                DisplayStory("You left the petrol pump with an inhaler. It might come in handy.");
            }
            else
            {
                DisplayStory("You left the petrol pump without an inhaler. Hope everything goes well...");
            }
        }
        else
        {
            DisplayStory("You didn't stop to fuel up. Hope everything goes well...");
        }
        currentState = StoryState.LeftPump;
        UpdateButtons();
    }

    void AfterPump()
    {
        currentState = StoryState.AfterPump;
        DisplayStory("You're passing by a forest, Everything looks creepy. You're not getting good vibes..");
        UpdateButtons();
    }

    void ReachedMansion()
    {
        currentState = StoryState.ReachedMansion;
        if (fuel == true)
        {
            DisplayStory("You spot a creepy looking mansion far away in the forest. You're happy that you didn't stop!");
        }
        else
        {
            DisplayStory("Your car runs out of fuel in the middle of this creepy forest. You see a pathway leading into the forest. Do you want to follow or stay in the car? (yes to follow)");
        }
        UpdateButtons();
    }

    void FollowedPath()
    {
        SceneManager.LoadScene(5);
    }

    void StayedInCar()
    {
        currentState = StoryState.StayedInCar;
        DisplayStory("You try to start the car but it just won't start without fuel. Quit trying?");
        UpdateButtons();
    }

    void HungryInCar()
    {
        currentState = StoryState.HungryInCar;
        DisplayStory("You get tired of trying and you're starving to death, you can't just sit here in hope of someone saving you. Wanna go outside?");
        UpdateButtons();
    }

    void CrossedMansion()
    {
        currentState = StoryState.CrossedMansion;
        DisplayStory("You are lost, you don't remember the way back. There are two ways, left & right. Do you wannt to turn right?");
        UpdateButtons();
    }

    void TurnedRight()
    {
        currentState = StoryState.TurnedRight;
        DisplayStory("You turn right, and after a while, you realize it indeed was the right way. You reached your home safely—how exciting... Not! Next time, try living a little dangerously?");
        UpdateButtons();
    }

    void YesTurnedRight()
    {
        SceneManager.LoadScene(0);
    }

    void NoTurnedRight()
    {
        SceneManager.LoadScene(3);
    }

    void TurnedLeft()
    {
        SceneManager.LoadScene(4);
    }
}
