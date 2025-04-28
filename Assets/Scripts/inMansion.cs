using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class inMansion : MonoBehaviour
{
    [SerializeField] Text storyText;
    [SerializeField] Button yesButton;
    [SerializeField] Button noButton;

    public static bool inhaler = false;

    private StoryState currentState;

    // Enum to define the different states in the story
    public enum StoryState
    {
        LockedInRoom,
    }

    void Start()
    {
        LockedInRoom();
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
        DisplayStory("They drag and lock you in a room. Try to escape?");
        UpdateButtons();
    }
}
