using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Plate.Gameplay.Save
{
    public static class SaveWriter
    {
        public static void Save(SaveManager manager)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/save.dat";
            FileStream stream = new FileStream(path, FileMode.Create);
            
            SaveData data = new SaveData(manager);
            formatter.Serialize(stream, data);
            stream.Close();
        }

        public static SaveData Load()
        {
            DeleteSave();
            string path = Application.persistentDataPath + "/save.dat";
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);
                
                SaveData data = formatter.Deserialize(stream) as SaveData;
                stream.Close();
                return data;
            }
            return null;
        }

        public static void DeleteSave()
        {
            if (File.Exists(Application.persistentDataPath + "/save.dat"))
            {
                File.Delete(Application.persistentDataPath + "/save.dat");
            }
        }
    }
}