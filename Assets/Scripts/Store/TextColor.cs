using TMPro;
using UnityEngine;

public class TextColor : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;
    private string previousText = "";


    private void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (textMeshPro.text != previousText)  // Eðer metin deðiþtiyse güncelle
        {
            textMeshPro.text = ApplyColorToText(textMeshPro.text);
            previousText = textMeshPro.text;  // Güncellenmiþ metni kaydet
        }
    }

    string ApplyColorToText(string inputText)
    {
        string[] lines = inputText.Split('\n');
        string coloredText = "";

        foreach (string line in lines)
        {
            if (line.StartsWith("+"))
            {
                if (line.Contains("Charge Speed") || line.Contains("Dash Cooldown"))
                    coloredText += $"<color=red>{line}</color>\n";
                else
                    coloredText += $"<color=green>{line}</color>\n";
            }
            else if (line.StartsWith("-"))
            {
                if (line.Contains("Charge Speed") || line.Contains("Dash Cooldown"))
                    coloredText += $"<color=green>{line}</color>\n";
                else
                    coloredText += $"<color=red>{line}</color>\n";  // Diðer "-" olanlar kýrmýzý
            }
            else
                coloredText += line + "\n";
        }

        return coloredText;
    }
}
