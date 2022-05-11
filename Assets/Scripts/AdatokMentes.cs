using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class AdatokMentes
{
    public static void Mentes(int kov)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string ut = Application.dataPath + "/mentettadatok.txt";
        FileStream fstream = new FileStream(ut, FileMode.OpenOrCreate);
        Adatok adat = new Adatok();
        adat.sceneIndex += kov;
        formatter.Serialize(fstream, adat);
        fstream.Close();
    }

    public static Adatok AdatokBetolt()
    {
        string ut = Application.dataPath + "/mentettadatok.txt";
        if(File.Exists(ut))
        {
            BinaryFormatter formattr = new BinaryFormatter();
            FileStream fstream = new FileStream(ut, FileMode.Open);
            Adatok adat = formattr.Deserialize(fstream) as Adatok;

            fstream.Close();
            return adat;
        }
        else
        {
            return null;
        }
    }
    
}
