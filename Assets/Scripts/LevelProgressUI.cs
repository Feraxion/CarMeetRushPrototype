using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressUI : MonoBehaviour
{
    [Header("UI references :")]
    [SerializeField] private Image uiFillImage;
    [SerializeField] private TextMeshProUGUI currentLevelText;
    [SerializeField] private TextMeshProUGUI nextLevelText;
    public static int currentLevelIndex; // get index to UI variable

    [Header("Player & Finish Line references :")]
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform finishLineTransform;

    private Vector3 finishLinePosition; // get finish position

    private float fullDistance; // get game progress

    void Awake()
    {
        currentLevelIndex = PlayerPrefs.GetInt("CurrentLevelIndex", 1); // Get current level data
    }
    void Start()
    {
        finishLinePosition = finishLineTransform.position;
        fullDistance = GetDistance();
    }

    void Update()
    {
        if (playerTransform == null)
        {
            return;
        }
        if (playerTransform.position.z <= finishLinePosition.z)
        {
            float newDistance = GetDistance();
            float progressValue = Mathf.InverseLerp(fullDistance, 0f, newDistance);
            UpdateProgressFill(progressValue);
        }

        // Update our UI
        SetLevelTexts();
    }

    private void UpdateProgressFill(float value)
    {
        uiFillImage.fillAmount = value;
    }

    private float GetDistance() //getting full distance
    {
        return Vector3.Distance(playerTransform.position, finishLinePosition);  
        // return (finishLinePosition - playerTransform.position).sqrMagnitude; // more performance able // cuz of sqrMagnitude not true for finish progress
    }

    public void SetLevelTexts()  // UI Level texts adjusting
    {
        currentLevelText.text = currentLevelIndex.ToString();
        nextLevelText.text = (currentLevelIndex + 1).ToString();
    }
}
