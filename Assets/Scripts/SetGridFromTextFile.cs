using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SetGridFromTextFile
{
    List<int> values;

    int lines, rows;
    public int Lines
    {
        get
        {
            return lines;
        }
    }
    public int Rows
    {
        get
        {
            return rows;
        }
    }

    public int Lenght
    {
        get
        {
            return lines * rows;
        }
    }

    public SetGridFromTextFile (TextAsset textFile)
    {
        // Count lines & rows by splitting
        lines = textFile.text.Split("\n"[0]).Length;
        rows = textFile.text.Split("\n"[0])[0].Split(","[0]).Length;

        Debug.Log("Rows" + rows);
        Debug.Log("Lines" + lines);

        // Initialize values List
        values = new List<int>();
        
        // Set values
        for (int i=0; i<lines; i++)
        {
            for (int j=0; j<rows; j++)
            {
                values.Add(int.Parse(textFile.text.Split("\n"[0])[i].Split(","[0])[j]));
                //Debug.Log("DefaultValues: " + int.Parse(textFile.text.Split("\n"[0])[i].Split(","[0])[j]));
            }
        }
        
        // Reorder List
        for (int i=0; i<Lenght; i++)
        {
            for (int j=0; j<Lenght; j++)
            {
                if (values[j]==i)
                {
                    values.Insert(Lenght + i, j);
                    //Debug.Log("ReOrdered_" + (Lenght + i) + " Value:" + j);
                    j = Lenght;
                }
            }
        }

        for (int i=0; i<Lenght; i++)
        {
            values.RemoveAt(0);
        }
    }

    public int GetPathValue (int index)
    {
        if (index < lines*rows)
        {
            return values[index];
        }
        else return 0;
    }

    public int[] GetPathValues ()
    {
        //for (int i = 0; i < Lenght; i++) Debug.Log(values[i]);
        return values.ToArray();
    }
}
