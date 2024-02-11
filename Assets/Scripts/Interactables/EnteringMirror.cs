using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnteringMirror : MonoBehaviour, IInteractable
{
    Material mat;
    bool isInsideMirror = false;
    GameObject Player;

    private void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
        Player = GameObject.FindWithTag("Player");
    }
    public string GetDescription()
    {
        return "Enter the mirror";
    }

    public void Interact()
    {
        Debug.LogWarning("I interacted!!");
        isInsideMirror = true;
        Player.SetActive(false);
        mat.color = new Color(300, 0, 0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInsideMirror)
        {
            Player.SetActive(true);
            isInsideMirror = false;
            mat.color = new Color(0, 0, 0);
        }
    }
}
