using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    string validCharacters = "1234567890";
    public float spawnRate { get; set; }
    public float speed { get; set; }
    public float distance { get; set; }
    private CubeScript cubeParams;
    private SpawnManager spawnManager;
    public TMP_InputField distanceField;
    public TMP_InputField spawnRateField;
    public TMP_InputField speedField;
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }
    public void EnterSpawnRate(string value)
    {
        spawnRateField.onValidateInput = (string text, int charIndex, char value) =>
        {
            return ValidateChar(validCharacters, value);
        };
        spawnManager.StopSpawningCube();
        spawnRate = float.Parse(value);
        if (spawnRate != 0)
        {
            spawnManager.SpawningCube();
        }
    }
    public void EnterDistance(string value)
    {
        distanceField.onValidateInput = (string text, int charIndex, char value) =>
        {
            return ValidateChar(validCharacters, value);
        };
        distance = float.Parse(value);
    }
    public void EnterSpeed(string value)
    {
        speedField.onValidateInput = (string text, int charIndex, char value) =>
        {
            return ValidateChar(validCharacters, value);
        };
        speed = float.Parse(value);
    }
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Cube"))
        {
            cubeParams = GameObject.FindGameObjectWithTag("Cube").GetComponent<CubeScript>();
        }
    }
    private char ValidateChar(string validCharacters, char addedChar)
    {
        if (validCharacters.IndexOf(addedChar) != -1)
        {
            //0123456789

            return addedChar;
        }
        //Все остальное
        else return '\0';
    }
}
