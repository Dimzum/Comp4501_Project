﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Stats))]
public class ShipyardManager : MonoBehaviour {

    GameMaster gm;
    ResourceManager rm;

    private Player p_owner;
    public Player Owner {
        get { return this.p_owner; }
        set { this.p_owner = value; }
    }

    public Stats stats;

    public GameObject shipyardUI;
    public GameObject shipBuildingUI;

    // Start is called before the first frame update
    void Start() {
        gm = GameMaster.instance;
        rm = ResourceManager.instance;

        shipyardUI = rm.shipyardMenuUI;
        shipBuildingUI = rm.shipyardUI;

        stats.MaxHealth = 100;
        stats.Armor = 30;
        stats.Speed = 0;
    }

    // Update is called once per frame
    void Update() {
        if (stats.isSelected) {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                stats.isSelected = false;

                if (shipyardUI.activeSelf) {
                    ToggleShipyardUI();
                }

                if (shipBuildingUI.activeSelf) {
                    ToggleShipBuildingUI();
                }
            }
        }
    }

    private void OnMouseDown() {
        //if (p_owner == gm.player) {
        if (true) {
            stats.ToggleIsSelected();

            ToggleShipyardUI();
        }
    }
    
    // Opens shipyard UI
    public void ToggleShipyardUI() {
        shipyardUI.SetActive(!shipyardUI.activeSelf);
    }

    public void ToggleShipBuildingUI() {
        shipBuildingUI.SetActive(!shipBuildingUI.activeSelf);
    }

    public void Destroy() {
        Debug.Log("DEAD");
        ToggleShipyardUI();
        stats.Die();
    }

    public void Build() {
        ToggleShipBuildingUI();
    }
}
