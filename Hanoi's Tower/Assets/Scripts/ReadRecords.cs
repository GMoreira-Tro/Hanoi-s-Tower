using UnityEngine;
using UnityEngine.UI;
public class ReadRecords : MonoBehaviour
{
    public Text ShowRecord;
    public static string fileString;

    public void Start()
    {
        ReadRecordAndSetLevelText(4);
    }

    public void ReadRecordAndSetLevelText(int level)
    {   
        fileString = "";
        string line;
        System.IO.StreamReader file = new System.IO.StreamReader("Records.txt");

        ShowRecord.text = "\t\t\t\t\t\t\tLevel " + level + "\n";
        bool StartRead = false;

        while((line = file.ReadLine()) != null )
        {
            fileString += line + "\n";
            if (StartRead)
                ShowRecord.text += line + "\n";
            if (!StartRead && line == ("Level " + level))
                StartRead = true;
            else if (StartRead && line == "")
                break;
        }

        fileString = fileString.Substring(0, fileString.Length - 1);
        file.Close();
    }

    public static void SaveFileInString()
    {
        fileString = "";
        string line;
        System.IO.StreamReader file = new System.IO.StreamReader("Records.txt");

        while ((line = file.ReadLine()) != null)
        {
            fileString += line + "\n";
        }

        if(fileString != "")
            fileString = fileString.Substring(0, fileString.Length - 1);
        file.Close();
    }
}
