using System.IO;
using UnityEngine;

public class SaveFile : MonoBehaviour
{
    void Start()
    { 
        ReadRecords.SaveFileInString();
        string[] lines = ReadRecords.fileString.Split('\n');
        int recordPosition = -1;
        int startPosition = lines.Length;

        for(int i = 0; i < lines.Length; i++)
        {
            if(lines[i] == ("Level " + LevelSelect.level))
            {
                startPosition = i + 1;
                break;
            }
        }

        int[] records = new int[3];
        string ComplementFile = "";

        for (int i = 0; i < 3; i++)
        {
            try
            {
                    records[i] = int.Parse(lines[startPosition + i].Split(' ')[1]);
            }
            catch (System.IndexOutOfRangeException)
            {
                    records[i]  = 9999999;
            }
        } 

        if (RenderObjects.moves < records[0])
            recordPosition = 0;
        else if (RenderObjects.moves < records[1])
            recordPosition = 1;
        else if (RenderObjects.moves < records[2])
            recordPosition = 2; 
        if (recordPosition != -1)
        {
            //Se existe a linha da posição a ser modificada no arquivo
            try
            {
                int.Parse(lines[startPosition].Substring(0, 1)); //Tenta fazer, se não cai no catch;
                //Pode ser tanto exceção de Out Of Bounds, tanto não conseguir converter pra número

                for (int i = startPosition + recordPosition + 1; i >= startPosition + recordPosition; i--)
                {
                    try
                    {
                        if(lines[i+1] != "\n" && lines[i+1].Substring(0,1) != "L")
                            lines[i + 1] = (i-startPosition-recordPosition + 2) + lines[i].Substring(1,lines[i].Length-1);
                    }
                    catch (System.Exception)
                    {
                        try
                        {
                            int.Parse(lines[i].Substring(0, 1));
                            ComplementFile = (i - startPosition - recordPosition + 2) + lines[i].Substring(1, lines[i].Length - 1);
                        }
                        catch (System.Exception)
                        {   
                            if(lines[i].Length > 0)
                                ComplementFile = (i-1 - startPosition - recordPosition + 2) + lines[i-1].Substring(1, lines[i].Length - 1);
                        }
                        break;
                    }
                }

                lines[startPosition + recordPosition] = (recordPosition + 1).ToString() + ". " + RenderObjects.moves + " moves -> " + NicknameValidation.UserName;
            }
            catch (System.IndexOutOfRangeException)
            {
                if (recordPosition == 0)
                {
                    ComplementFile = "Level " + LevelSelect.level + "\n";
                    if (startPosition != 1)
                        ComplementFile = "\n" + ComplementFile;
                }
                    ComplementFile = ComplementFile + (recordPosition + 1).ToString() + ". " + RenderObjects.moves + " moves -> " + NicknameValidation.UserName;

            }
        }

        WriteFile(lines, ComplementFile);
    }

    public static void WriteFile(string[] lines, string Complement)
    {
        string path = @"Records";
        // Delete the file if it exists.
        if (File.Exists(path))
        {
            try
            {
                File.Delete(path);
            } 
            catch (System.Exception e)
            {
                Debug.Log(e);
            }
        }

        //Create the file.
        FileStream fs = File.Create(path);

        TextWriter tw = new StreamWriter("Records.txt");

        if (lines.Length > 1)
        {
            for (int i = 0; i < lines.Length; i++)
                tw.WriteLine(lines[i]);
        }

        if (Complement != "")
            tw.Write(Complement);

         tw.Close();
    }
}
