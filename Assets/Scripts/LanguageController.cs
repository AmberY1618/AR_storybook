using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class LanguageController : MonoBehaviour
{
//    [SerializeField] private string currentLanguage;
    [SerializeField] private int currentLanguageIndex;
    private const string SOURCE_CSV_FILE = "Assets/LanguageData/page2.csv";
    
    [SerializeField]
    private TextMeshProUGUI[] translatableText;
    // format <key: language name, value: [correct answer, wrong answer(s)*]>
    private Dictionary<string, string[]> data_dict = new Dictionary<string, string[]>();

    protected List<string> supportedLanguages = new List<string>();

    private void Start()
    {
//        Turn on flash for in-the-dark development
        CameraDevice.Instance.SetFlashTorchMode(true);
        Console.Write("LanguageController Start");
        ReadLanguageData();
        
        Console.Write("Default language: " + supportedLanguages[currentLanguageIndex]);
    }

    public void ReadLanguageData()
    {
        using(var reader = new StreamReader(SOURCE_CSV_FILE))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                supportedLanguages.Add(values[0]);
                data_dict[values[0]] = values.Skip(1).ToArray();
            }
        }
        
        Console.Write(supportedLanguages);
        // Set default language to first item
//        currentLanguage = data_dict.Keys.First();
    }

    public void SwitchLanguage(Text langLabel)
    {
        if (currentLanguageIndex == supportedLanguages.Count-1)
        {
            currentLanguageIndex = 0;
        }
        else
        {
            currentLanguageIndex++;
        }
        Console.Write("Language set to: " + supportedLanguages[currentLanguageIndex]);
        langLabel.text = supportedLanguages[currentLanguageIndex].ToUpper();
        for (int i = 0; i < translatableText.Length; i++)
        {
            translatableText[i].text = data_dict[supportedLanguages[currentLanguageIndex]][i].ToUpper();
        }
    }
}