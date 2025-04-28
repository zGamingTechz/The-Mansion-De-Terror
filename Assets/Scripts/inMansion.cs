using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using NUnit.Framework;

public class inMansion : MonoBehaviour
{
    public static StoryState startState = StoryState.LockedInRoom;
    [SerializeField] Text storyText;
    [SerializeField] Button yesButton;
    [SerializeField] Button noButton;

    private StoryState currentState;

    // Enum to define the different states in the story
    public enum StoryState
    {
        LockedInRoom,
        CutRope,
        YouDumb,
        RanAway,
        HeardFootsteps,
        HiddenFromThugs,
        Lost,
        BloodyRoom,
        RanFromRoom,
        StayedInRoom,
    }

    void Start()
    {
        if (startState == StoryState.LockedInRoom)
        {
            LockedInRoom();
        }
        else if (startState == StoryState.HeardFootsteps)
        {
            HeardFootsteps();
        }
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
            case StoryState.LockedInRoom:
                yesButton.onClick.AddListener(CutRope);
                noButton.onClick.AddListener(YouDumb);
                break;
            case StoryState.CutRope:
                yesButton.onClick.AddListener(RanAway);
                noButton.onClick.AddListener(RanAway);
                break;
            case StoryState.RanAway:
                yesButton.onClick.AddListener(Lost);
                noButton.onClick.AddListener(Lost);
                break;
            case StoryState.YouDumb:
                yesButton.onClick.AddListener(ScrewYou);
                noButton.onClick.AddListener(CutRope);
                break;
            case StoryState.HeardFootsteps:
                yesButton.onClick.AddListener(HiddenFromThugs);
                noButton.onClick.AddListener(LockedInRoom);
                break;
            case StoryState.HiddenFromThugs:
                yesButton.onClick.AddListener(work_in_progress);
                noButton.onClick.AddListener(RanAway);
                break;
            case StoryState.Lost:
                yesButton.onClick.AddListener(BloodyRoom);
                noButton.onClick.AddListener(RanFromRoom);
                break;
            case StoryState.BloodyRoom:
                yesButton.onClick.AddListener(RanFromRoom);
                noButton.onClick.AddListener(StayedInRoom);
                break;
            case StoryState.RanFromRoom:
                yesButton.onClick.AddListener(work_in_progress);
                noButton.onClick.AddListener(work_in_progress);
                break;
            case StoryState.StayedInRoom:
                yesButton.onClick.AddListener(work_in_progress);
                noButton.onClick.AddListener(work_in_progress);
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

    void LockedInRoom()
    {
        currentState = StoryState.LockedInRoom;
        DisplayStory("They drag and tie you up in a room. Try to escape?");
        UpdateButtons();
    }

    void CutRope()
    {
        currentState = StoryState.CutRope;
        DisplayStory("You try to cut your rope by scratching it with a piece of broken glass. Continue?");
        UpdateButtons();
    }

    void RanAway()
    {
        currentState = StoryState.RanAway;
        DisplayStory("You manage to run away from them and wander through random hallways. Continue?");
        UpdateButtons();
    }

    void YouDumb()
    {
        currentState = StoryState.YouDumb;
        DisplayStory("Come on! Are you dumb?");
        UpdateButtons();
    }

    void HeardFootsteps()
    {
        currentState = StoryState.HeardFootsteps;
        DisplayStory("As you enter the mansion, you immidiatly start hearing footsteps. Hide?");
        UpdateButtons();
    }

    void HiddenFromThugs()
    {
        currentState = StoryState.HiddenFromThugs;
        DisplayStory("You hide and peek from a corner. You see that they are the same thugs and they're searching for some hidden gem. Follow them?");
        UpdateButtons();
    }

    void Lost()
    {
        currentState = StoryState.Lost;
        DisplayStory("You seem to be lost. You see a room with blood cominng out. Do you want to check?");
        UpdateButtons();
    }

    void BloodyRoom()
    {
        currentState = StoryState.BloodyRoom;
        DisplayStory("You see all the thugs slaughtered in the room with blood flowing everywhere, RUN?");
        UpdateButtons();
    }

    void RanFromRoom()
    {
        currentState = StoryState.RanFromRoom;
        DisplayStory("You ran away from the room...To be continued.");
        UpdateButtons();
    }

    void StayedInRoom()
    {
        currentState = StoryState.StayedInRoom;
        DisplayStory("You tihnk you're hallucinating...you see the girl again...");
        UpdateButtons();
    }
}
