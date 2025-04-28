using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using static main;

public class forest : MonoBehaviour
{
    [SerializeField] Text storyText;
    [SerializeField] Button yesButton;
    [SerializeField] Button noButton;

    bool inhaler = main.inhaler;

    private StoryState currentState;

    // Enum to define the different states in the story
    public enum StoryState
    {       
        EnteredForest,
        Foggy,
        UsedInhaler,
        NotUsedInhaler,
        NoInhaler,
        StoppedForMan,
        GotInhaler,
        StartedMovingAfterInhaler,
    }

    void Start()
    {
        currentState = StoryState.EnteredForest;
        DisplayStory("You have entered a scary foggy forest area. You realise you took the wrong path but you're too brave(dumb) to turn around");
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
            case StoryState.EnteredForest:
                yesButton.onClick.AddListener(Foggy);
                noButton.onClick.AddListener(Foggy);
                break;
            case StoryState.Foggy:
                if (inhaler)
                {
                    yesButton.onClick.AddListener(UsedInhaler);
                    noButton.onClick.AddListener(NotUsedInhaler);
                }
                else
                {
                    yesButton.onClick.AddListener(NoInhaler);
                    noButton.onClick.AddListener(NoInhaler);
                }
                break;
            case StoryState.NotUsedInhaler:
                yesButton.onClick.AddListener(died);
                noButton.onClick.AddListener(died);
                break;
            case StoryState.NoInhaler:
                yesButton.onClick.AddListener(StoppedForMan);
                noButton.onClick.AddListener(died);
                break;
            case StoryState.StoppedForMan:
                yesButton.onClick.AddListener(died);
                noButton.onClick.AddListener(GotInhaler);
                break;
            case StoryState.GotInhaler:
                yesButton.onClick.AddListener(UsedInhaler);
                noButton.onClick.AddListener(NotUsedInhaler);
                break;
            case StoryState.UsedInhaler:
                yesButton.onClick.AddListener(StartedMovingAfterInhaler);
                noButton.onClick.AddListener(StartedMovingAfterInhaler);
                break;
        }
    }

    void Foggy()
    {
        currentState = StoryState.Foggy;
        if (inhaler)
        {
            DisplayStory("The fog is getting more and more dense, you're having difficulty breathing but luckily you bought a ihaler. Kindness certainly pays off. Do you want to use it?");
        }
        else
        {
            DisplayStory("The fog is getting more and more dense, you're having difficulty breathing. Now you realise you should've bought the inhaler. Karma is real.");
        }
        UpdateButtons();
    }

    void NotUsedInhaler()
    {
        currentState = StoryState.NotUsedInhaler;
        DisplayStory("You decided to not use the inhaler even after having it and died of suffocation. Smart move right??");
        UpdateButtons();
    }

    void died()
    {
        SceneManager.LoadScene(2);
    }

    public void Quit()
    {
        Application.Quit();
    }

    void NoInhaler()
    {
        currentState = StoryState.NoInhaler;
        DisplayStory("You're halluciating or something because you see a man on the side of the road with an inhaler. Want to stop?");
        UpdateButtons();
    }

    void StoppedForMan()
    {
        currentState = StoryState.StoppedForMan;
        DisplayStory("You stopped...you can barely breath. You ask the man for the inhaler but he declines. Want to snatch it?");
        UpdateButtons();
    }

    void GotInhaler()
    {
        currentState = StoryState.GotInhaler;
        DisplayStory("The man sees you suffering and decides to give you the inhaler. What a kind soul! Use the inhaler now?");
        UpdateButtons();
    }

    void UsedInhaler()
    {
        currentState = StoryState.UsedInhaler;
        DisplayStory("You used the inhaler and started movig again. Wanna go high speed?");
        UpdateButtons();
    }

    void StartedMovingAfterInhaler()
    {
        currentState = StoryState.StartedMovingAfterInhaler;
        DisplayStory("Anyways, i haven't worked on the next part yet. gotta wait");
        UpdateButtons();
    }
}
