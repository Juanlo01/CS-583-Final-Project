using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DirectionsManager : MonoBehaviour
{
    public GameObject GOPanel;
    public GameObject EnemiesPanel;
    public GameObject CharacterPanel;
    public GameObject ControlsPanel;
    public GameObject MainPanel;
    public GameObject TowersPanel;

    public void MainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    void Start()
    {
        MainPanel.SetActive(true);
        GOPanel.SetActive(false);
        EnemiesPanel.SetActive(false);
        CharacterPanel.SetActive(false);
        ControlsPanel.SetActive(false);
        TowersPanel.SetActive(false);
    }

    public void MainPanelActive()
    {
        GOPanel.SetActive(false);
        CharacterPanel.SetActive(false);
        ControlsPanel.SetActive(false);
        EnemiesPanel.SetActive(false);
        TowersPanel.SetActive(false);
    }

    public void Objective()
    {
        GOPanel.SetActive(true);
        EnemiesPanel.SetActive(false);
        CharacterPanel.SetActive(false);
        ControlsPanel.SetActive(false);
        TowersPanel.SetActive(false);
    }

    public void Enemies()
    {
        EnemiesPanel.SetActive(true);
        GOPanel.SetActive(false);
        CharacterPanel.SetActive(false);
        ControlsPanel.SetActive(false);
        TowersPanel.SetActive(false);
    }

    public void Character()
    {
        CharacterPanel.SetActive(true);
        ControlsPanel.SetActive(false);
        EnemiesPanel.SetActive(false);
        GOPanel.SetActive(false);
        TowersPanel.SetActive(false);
    }

    public void Controls()
    {
        ControlsPanel.SetActive(true);
        CharacterPanel.SetActive(false);
        EnemiesPanel.SetActive(false);
        GOPanel.SetActive(false);
        TowersPanel.SetActive(false);
    }

    public void Towers()
    {
        ControlsPanel.SetActive(false);
        CharacterPanel.SetActive(false);
        EnemiesPanel.SetActive(false);
        GOPanel.SetActive(false);
        TowersPanel.SetActive(true);
    }

}








