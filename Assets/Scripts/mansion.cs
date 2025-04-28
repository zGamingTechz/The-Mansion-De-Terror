using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mansion : MonoBehaviour
{
    [SerializeField] Text storyText;
    [SerializeField] Button yesButton;
    [SerializeField] Button noButton;

    public static bool inhaler = false;

    private StoryState currentState;

    // Enum to define the different states in the story
    public enum StoryState
    {
        FollowedPath,
        SawMushroom,
        NoEatMushroom,
        YesConsoleWoman,
        NoConsoleWoman,
        FoundHouse,
        YesCheckNoise,
        Kidnapped,
        NoCheckNoise,
        OutsideHouse,
        GoBack,
        InCar,
        CrossedMansion,
        TurnedLeft,
        TurnedRight,
        TakenToMansion,
        LockedInRoom,
    }

    void Start()
    {
        FollowedPath();
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
            case StoryState.FollowedPath:
                yesButton.onClick.AddListener(Died);
                noButton.onClick.AddListener(NoEatMushroom);
                break;
            case StoryState.NoEatMushroom:
                yesButton.onClick.AddListener(YesConsoleWoman);
                noButton.onClick.AddListener(NoConsoleWoman);
                break;
            case StoryState.NoConsoleWoman:
                yesButton.onClick.AddListener(Quit);
                noButton.onClick.AddListener(ScrewYou);
                break;
            case StoryState.YesConsoleWoman:
                yesButton.onClick.AddListener(FoundHouse);
                noButton.onClick.AddListener(FoundHouse);
                break;
            case StoryState.FoundHouse:
                yesButton.onClick.AddListener(YesCheckNoise);
                noButton.onClick.AddListener(NoCheckNoise);
                break;
            case StoryState.YesCheckNoise:
                yesButton.onClick.AddListener(Died);
                noButton.onClick.AddListener(Kidnapped);
                break;
            case StoryState.NoCheckNoise:
                yesButton.onClick.AddListener(OutsideHouse);
                noButton.onClick.AddListener(OutsideHouse);
                break;
            case StoryState.Kidnapped:
                yesButton.onClick.AddListener(TakenToMansion);
                noButton.onClick.AddListener(TakenToMansion);
                break;
            case StoryState.OutsideHouse:
                yesButton.onClick.AddListener(work_in_progress);
                noButton.onClick.AddListener(GoBack);
                break;
            case StoryState.GoBack:
                yesButton.onClick.AddListener(InCar);
                noButton.onClick.AddListener(InCar);
                break;
            case StoryState.InCar:
                yesButton.onClick.AddListener(CrossedMansion);
                noButton.onClick.AddListener(CrossedMansion);
                break;
            case StoryState.CrossedMansion:
                yesButton.onClick.AddListener(TurnedRight);
                noButton.onClick.AddListener(TurnedLeft);
                break;
            case StoryState.TurnedRight:
                yesButton.onClick.AddListener(YesTurnedRight);
                noButton.onClick.AddListener(NoTurnedRight);
                break;
            case StoryState.TakenToMansion:
                yesButton.onClick.AddListener(LockedInRoom);
                noButton.onClick.AddListener(LockedInRoom);
                break;
            case StoryState.LockedInRoom:
                yesButton.onClick.AddListener(YesTurnedRight);
                noButton.onClick.AddListener(NoTurnedRight);
                break;
        }
    }

    void work_in_progress()
    {
        DisplayStory("Work in progress hehe...");
    }

    void Died()
    {
        SceneManager.LoadScene(2);
    }

    public void Quit()
    {
        Application.Quit();
    }

    void ScrewYou()
    {
        SceneManager.LoadScene(3);
    }

    void FollowedPath()
    {
        currentState = StoryState.FollowedPath;
        DisplayStory("You decided to come out of the car and follow the path. You're starving and after walking for a while you see a mushroom on the side. Eat it?");
        UpdateButtons();
    }

    void NoEatMushroom()
    {
        currentState = StoryState.NoEatMushroom;
        DisplayStory("Maybe you should've eaten it..After walking for a while you see the same woman you saw earlier, she seems to be crying. Console her?");
        UpdateButtons();
    }

    void NoConsoleWoman()
    {
        currentState = StoryState.NoConsoleWoman;
        DisplayStory("You first left her alone on a lonely highway and now don't even show empathy. Rethink your life. Just leave my game?");
        UpdateButtons();
    }

    void YesConsoleWoman()
    {
        currentState = StoryState.YesConsoleWoman;
        DisplayStory("She tells you she was murdered and thanks you for consoling her and tells you that there's fuel in a house nearby. Continue?");
        UpdateButtons();
    }

    void FoundHouse()
    {
        currentState = StoryState.FoundHouse;
        DisplayStory("You find the house and put the fuel in your inventory. Strange noises come from outside—check it out?");
        UpdateButtons();
    }

    void YesCheckNoise()
    {
        currentState = StoryState.YesCheckNoise;
        DisplayStory("You go outside and see some poeple in a jeep with guns. They try to kidnap you, fight back?");
        UpdateButtons();
    }

    void NoCheckNoise()
    {
        currentState = StoryState.NoCheckNoise;
        DisplayStory("You decide to stay in and look out the window. You see some armed men in a jeep and decide to hide until they're gone.");
        UpdateButtons();
    }

    void Kidnapped()
    {
        currentState = StoryState.Kidnapped;
        DisplayStory("You chose not to fight back—how brave. They tie you up, toss you in their jeep, and you overhear them saying they’re taking you to a nearby mansion.");
        UpdateButtons();
    }

    void OutsideHouse()
    {
        currentState = StoryState.OutsideHouse;
        DisplayStory("You come out once they're gone. You have fuel, Wanna go back to the car or follow them? (Yes to follow)?");
        UpdateButtons();
    }

    void GoBack()
    {
        currentState = StoryState.GoBack;
        DisplayStory("You decided to go back with the fuel. You're not the adventurous type for sure. Continue?");
        UpdateButtons();
    }

    void InCar()
    {
        currentState = StoryState.InCar;
        DisplayStory("You're back to your car with fuel and resume your journey. You spot a creepy mansion far away in the forest. You're glad that you didn't stop! Continue?");
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

    void TakenToMansion()
    {
        currentState = StoryState.TakenToMansion;
        DisplayStory("They take you to a mansion, from outside it looks creepy asf. They're dragging you in. Continue?");
        UpdateButtons();
    }

    void LockedInRoom()
    {
        currentState = StoryState.LockedInRoom;
        DisplayStory("They drag and lock you in a room. Try to escape?");
        UpdateButtons();
    }
}
