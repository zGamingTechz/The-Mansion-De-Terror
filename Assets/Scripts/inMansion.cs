using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

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
                yesButton.onClick.AddListener(work_in_progress);
                noButton.onClick.AddListener(work_in_progress);
                break;
            case StoryState.YouDumb:
                yesButton.onClick.AddListener(ScrewYou);
                noButton.onClick.AddListener(CutRope);
                break;
            case StoryState.HeardFootsteps:
                yesButton.onClick.AddListener(work_in_progress);
                noButton.onClick.AddListener(LockedInRoom);
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
}
