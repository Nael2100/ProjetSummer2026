namespace Plate.Gameplay.Save
{
    [System.Serializable]
    public class SaveData
    {
        public string playerName;
        public string currentGradeName;
        public int currentStars;
        public int daysLeft;
        public string[] skillsNames;
        
        
        public SaveData(SaveManager saveManager)
        {
            playerName = saveManager.GetPlayerName();
            currentGradeName = saveManager.GetPlayerGrade();
            currentStars = saveManager.GetPlayerStars();
            daysLeft = saveManager.GetDaysLeft();
            skillsNames = saveManager.GetPlayerSkills();
        }
    }
}