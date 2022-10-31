using System.Collections;
using UnityEngine;
using TMPro;
public class UIValues : MainGP
{
    //Values: 0 - speed 1 - distance 2 - time 
    [SerializeField] private TMP_InputField[] fields = new TMP_InputField[3];
    [SerializeField] private float[] curValues = new float[3];
    [SerializeField] private float[] prevValues = new float[3];
    [SerializeField] private TextMeshProUGUI vrongText;

    [SerializeField] private Creator creator;
    public void CheckSmthFieldChange(int field)
    {
        try
        {
            curValues[field] = float.Parse(fields[field].text);
            UpdateValues();
            prevValues[field] = curValues[field];
        }
        catch
        {
            Debug.Log("ErrorOnChange");
            StartCoroutine(HideText());
            fields[field].text = prevValues[field].ToString();
        }
    }
    private void UpdateValues()
    {
        creator.UIToCreator(curValues);
    }
    private IEnumerator HideText()
    {
        Color textColor = vrongText.color;
        textColor.a = 1;
        vrongText.color = textColor;
        float TimeToHide = 1.5f; 
        float timer = TimeToHide; 
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            textColor.a = 1f / TimeToHide * timer;
            vrongText.color = textColor;
            yield return null;
        }
    }
}
