using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ObjectiveController : MonoBehaviour
{
    public int ID;
    public string description;
    public bool isComplete;
    public bool isActive;
    public ObjectiveType type;
    public float progress;
    public Requirement ObjectiveRequirement;
    public HintData ObjectiveHint;
    public UnityEvent requirement;

    public ObjectivesManager objectiveManager;
    

    public void MarkObjectiveAsComplete()
    {
       isComplete = true;
       isActive = false;
       gameObject.SetActive(false);
    }

 


    private bool CheckConditionsForObjective2()
    {
        //untuk memeriksa apakah obj 1 sudah selesai atau belum
        ObjectiveController objective1 = GetObjectiveByID(1);
        if (objective1 != null && objective1.isComplete)
        {
            //untuk menambahkan kondisi lain jika ada
            return true;
        }
        return false;
    }

    private ObjectiveController GetObjectiveByID(int objectiveID)
    {
        foreach (var objective in objectiveManager.objectiveDatas)
        {
            if (objective.ID == objectiveID)
            {
                return objective;
            }
        }
        return null;
    }

    public void ActivateObjective(ObjectiveController objective)
    {
        objective.isActive = true;
        objective.gameObject.SetActive(true);
    }


    public ObjectiveController(int id, string description, ObjectiveType type, Requirement requirement, HintData hint)
    {
        ID = id;
        description = description;
        isComplete = false;
        isActive = false;
        type = type;
        progress = 0f;
        ObjectiveRequirement = requirement;
        ObjectiveHint = hint;
    }


    public class Requirement
    {
        public string Description;
        public bool IsFulfilled;

        public Requirement(string description)
        {
            Description = description;
            IsFulfilled = false;
        }
    }

    public class HintData
    {
        public string Description;
        public HintType Type;
        public bool isActive;

        public HintData(string description, HintType type)
        {
            Description = description;
            Type = type;
            isActive = false;
        }
    }

    public enum ObjectiveType
    {
        Item,
        Trigger,
        Activate
    }

    public enum HintType
    {
        FuseHint,
        VentHint,
        ToolkitHint
    }

}

