using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TestObject
{
    public int value;
}

public class main : MonoBehaviour
{
    public TextMeshProUGUI Result;
    public int ArraySize;
    public int NumIterations;

    public int[] m_array;

    public TestObject[] m_objectArray;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_array = new int[ArraySize];
        m_objectArray = new TestObject[ArraySize];
        for (int i = 0; i < ArraySize; i++)
        {
            m_objectArray[i] = new TestObject();
            m_objectArray[i].value = i;
        }
    }

    public void RunTest()
    {
        double forTime = 0.0d;
        double forTimeCached = 0.0f;
        double foreachTime = 0.0d;

        double forTimeFA = 0.0d;
        double forTimeCachedFA = 0.0f;
        double foreachTimeFA = 0.0d;

        double forTimeObject = 0.0d;
        double forTimeCachedObject = 0.0f;
        double foreachTimeObject = 0.0d;

        double forTimeFAObject = 0.0d;
        double forTimeCachedFAObject = 0.0f;
        double foreachTimeFAObject = 0.0d;
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

            time = Time.realtimeSinceStartupAsDouble;
            forTestFA();
            forTimeFA += Time.realtimeSinceStartupAsDouble - time;

            time = Time.realtimeSinceStartupAsDouble;
            forTestCachedLengthFA();
            forTimeCachedFA += Time.realtimeSinceStartupAsDouble - time;

            time = Time.realtimeSinceStartupAsDouble;
            forEachTestFA();
            foreachTimeFA += Time.realtimeSinceStartupAsDouble - time;


            time = Time.realtimeSinceStartupAsDouble;
            forTestObject(m_objectArray);
            forTimeObject += Time.realtimeSinceStartupAsDouble - time;

            time = Time.realtimeSinceStartupAsDouble;
            forTestCachedLengthObject(m_objectArray);
            forTimeCachedObject += Time.realtimeSinceStartupAsDouble - time;

            time = Time.realtimeSinceStartupAsDouble;
            forEachTestObject(m_objectArray);
            foreachTimeObject += Time.realtimeSinceStartupAsDouble - time;

            time = Time.realtimeSinceStartupAsDouble;
            forTestObjectFA();
            forTimeFAObject += Time.realtimeSinceStartupAsDouble - time;

            time = Time.realtimeSinceStartupAsDouble;
            forTestCachedLengthObjectFA();
            forTimeCachedFAObject += Time.realtimeSinceStartupAsDouble - time;

            time = Time.realtimeSinceStartupAsDouble;
            forEachTestObjectFA();
            foreachTimeFAObject += Time.realtimeSinceStartupAsDouble - time;        }
        string s = "Results:\n";
        s += "For time " + forTime + "\n";
        s += "For cached time " + forTimeCached + "\n";
        s += "Foreach time " + foreachTime + "\n";
        s += "For time field access " + forTimeFA + "\n";
        s += "For cached time field acess " + forTimeCachedFA + "\n";
        s += "Foreach time field access " + foreachTimeFA + "\n";

        s += "For object time " + forTimeObject + "\n";
        s += "For object cached time " + forTimeCachedObject + "\n";
        s += "Foreach object time " + foreachTimeObject + "\n";
        s += "For object time field access " + forTimeFAObject + "\n";
        s += "For object cached time field acess " + forTimeCachedFAObject + "\n";
        s += "Foreach object time field access " + foreachTimeFAObject + "\n";
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

    int forTestFA()
    {
        int sum = 0;
        for (int i = 0; i < m_array.Length; i++)
            sum += m_array[i];
        return sum;
    }

    int forTestCachedLengthFA()
    {
        int sum = 0;
        int length = m_array.Length;
        for (int i = 0; i < length; i++)
            sum += m_array[i];
        return sum;
    }

    int forEachTestFA()
    {
        int sum = 0;
        foreach (int value in m_array)
            sum += value;
        return sum;
    }


    int forTestObject(TestObject[] array)
    {
        int sum = 0;
        for (int i = 0; i < array.Length; i++)
            sum += array[i].value;
        return sum;
    }

    int forTestCachedLengthObject(TestObject[] array)
    {
        int sum = 0;
        int length = array.Length;
        for (int i = 0; i < length; i++)
            sum += array[i].value;
        return sum;
    }

    int forEachTestObject(TestObject[] array)
    {
        int sum = 0;
        foreach (TestObject testObject in array)
            sum += testObject.value;
        return sum;
    }

    int forTestObjectFA()
    {
        int sum = 0;
        for (int i = 0; i < m_objectArray.Length; i++)
            sum += m_objectArray[i].value;
        return sum;
    }

    int forTestCachedLengthObjectFA()
    {
        int sum = 0;
        int length = m_objectArray.Length;
        for (int i = 0; i < length; i++)
            sum += m_objectArray[i].value;
        return sum;
    }

    int forEachTestObjectFA()
    {
        int sum = 0;
        foreach (TestObject testObject in m_objectArray)
            sum += testObject.value;
        return sum;
    }
}
