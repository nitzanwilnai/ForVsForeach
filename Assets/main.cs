using TMPro;
using UnityEngine;

public class main : MonoBehaviour
{
    public TextMeshProUGUI Result;
    public int ArraySize;
    public int NumIterations;

    int[] m_array;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_array = new int[ArraySize];
    }

    public void RunTest()
    {
        double forTime = 0.0d;
        double forTimeCached = 0.0f;
        double foreachTime = 0.0d;
        for (int t = 0; t < NumIterations; t++)
        {
            double time;

            time = Time.realtimeSinceStartupAsDouble;
            forTest(m_array);
            forTime += Time.realtimeSinceStartupAsDouble - time;

            time = Time.realtimeSinceStartupAsDouble;
            forTestCachedLength(m_array);
            forTimeCached += Time.realtimeSinceStartupAsDouble - time;

            time = Time.realtimeSinceStartupAsDouble;
            forEachTest(m_array);
            foreachTime += Time.realtimeSinceStartupAsDouble - time;
        }
        string s = "Results:\n";
        s += "For time " + forTime + "\n'";
        s += "For cached time " + forTimeCached + "\n";
        s += "Foreach time " + foreachTime + "\n";
        Result.text = s;
    }

    int forTest(int[] array)
    {
        int sum = 0;
        for (int i = 0; i < array.Length; i++)
            sum += array[i];
        return sum;
    }

    int forTestCachedLength(int[] array)
    {
        int sum = 0;
        int length = array.Length;
        for (int i = 0; i < length; i++)
            sum += array[i];
        return sum;
    }

    int forEachTest(int[] array)
    {
        int sum = 0;
        foreach (int value in array)
            sum += value;
        return sum;
    }
}
