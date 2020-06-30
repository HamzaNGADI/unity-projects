using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class savingsys
{

    private static string path = Application.persistentDataPath + "/data.txt";
    public static void save(gamedata g)
    {
        BinaryFormatter b = new BinaryFormatter();
        FileStream fs = new FileStream(path, FileMode.Create);

        b.Serialize(fs, g);
        fs.Close();
    }
    public static gamedata load()
    {
        //        File.Delete(path);
        if (File.Exists(path))
        {
            if (new FileInfo(path).Length == 0)
            {
                save(new gamedata(0));
                return new gamedata(0);
            }
            BinaryFormatter bi = new BinaryFormatter();
            FileStream st = new FileStream(path, FileMode.Open);

            gamedata gg = bi.Deserialize(st) as gamedata;
            st.Close();
            return gg;
        }
        else
        {
            save(new gamedata(0));
            Debug.Log("error loading");
            return new gamedata(0);
        }


    }

}
