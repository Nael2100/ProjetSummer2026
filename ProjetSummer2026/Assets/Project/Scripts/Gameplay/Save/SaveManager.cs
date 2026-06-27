using System;
using Plate.Gameplay.Player;
using UnityEngine;

namespace Plate.Gameplay.Save
{
    public class SaveManager : MonoBehaviour
    {
        public static SaveManager Instance { get; private set; }
        
        [field : SerializeField]
        public int playerStars { get; private set; }
        [field : SerializeField]
        public string playerGrade { get; private set; }
        [field : SerializeField]
        public  string[] playerSkills { get; private set; }
        [field : SerializeField]
        public string playerName { get; private set; }
        [field : SerializeField]
        public int daysLeft { get; private set; }
        
        [SerializeField] private PlayerRef playerRef;

        public SaveManager()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }
        private void Awake()
        {
            LoadSave();
        }

        public void CreateSave()
        {
            Debug.Log("Creating new save");
            if (playerRef != null)
            {
                playerStars = playerRef.GetStars();
                playerGrade = playerRef.GetGrade().gradeName;
                playerSkills = playerRef.GetSkills();
                playerName = playerRef.GetPlayerName();
                daysLeft = playerRef.GetDaysLeft();
            }
            SaveWriter.Save(this);
        }

        public void LoadSave()
        {
            SaveData loadedSave = SaveWriter.Load();
            if (loadedSave != null)
            {
                playerStars = loadedSave.currentStars;
                playerGrade = loadedSave.currentGradeName;
                playerSkills = loadedSave.skillsNames;
                playerName = loadedSave.playerName;
                daysLeft = loadedSave.daysLeft;
            }
        }
        public int GetPlayerStars()
        {
            return playerStars;
        }

        public string GetPlayerGrade()
        {
            return playerGrade;
        }

        public string[] GetPlayerSkills()
        {
            return playerSkills;
        }

        public string GetPlayerName()
        {
            return playerName;
        }

        public int GetDaysLeft()
        {
            return daysLeft;
        }
    }
}