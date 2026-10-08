//Version 1

//using UnityEngine;


//public class MainClick : MonoBehaviour
//{
//    public int numberclass1 = 0;
//    private void OnMouseDown()
//    {
//        Debug.Log("Object clicked!");
//        // Add your click logic here
//        numberclass1 += 1;
//        Debug.Log("New number value: " + numberclass1);
//    }
//}

//Version 0.1.1 this version there is a button that you press and number goes up and that's it

using UnityEngine;
using TMPro;
using Unity.VisualScripting; // Required to work with TextMeshPro components

public class MainClick : MonoBehaviour
{
    public int numberclass1 = 0; //main number variable
    public TMP_Text numberText; // Slot for your UI Text component
    public bool isReachedFive = false; //variable sees if they reached 5

    [Header("Audio Settings")]
    public AudioSource audioSource;
    public AudioClip confettiSound;

    private void Start()
    {
        //Auto-detect Audio Sourece if it's on the same object
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
        // Show the initial starting number on game launch
        UpdateTextDisplay();
    }

    private void OnMouseDown()
    {
        //updates the variable
        numberclass1 += 1;
        UpdateTextDisplay();
        Debug.Log("New number value: " + numberclass1);
        //checks if var numberclass = 5
        if (numberclass1 == 5)
        {
            isReachedFive = true;
            PlayConfettiSound();
            Debug.Log("Reached 5!");
        }

    }

    private void UpdateTextDisplay()
    {
        if (numberText != null)
        {
            //Displays the Number on the screen
            numberText.text = "Number: " + numberclass1;
        }
    }

    private void PlayConfettiSound()
    {
        if (audioSource != null && confettiSound != null)
        {
            audioSource.PlayOneShot(confettiSound);
        }
    }
}
