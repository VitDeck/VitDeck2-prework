using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace VitDeck.Localization
{
    public class LocalizeDictionary : ScriptableObject, ILocalizeDictionary
    {
        [SerializeField] private string[] keys;
        [SerializeField] private Language[] languages;

        private int languageIndex = 0;

        public void SetLanguage(string languageName)
        {
            for (int i = 0; i < languages.Length; i++)
            {
                if (languages[i].name == languageName)
                {
                    languageIndex = i;
                    return;
                }
            }

            throw new ArgumentException($"言語名が不正です。{languageName}");
        }

        public string Localize(string key)
        {
            int index = -1;
            for (int i = 0; i < keys.Length; i++)
            {
                if (keys[i] == key)
                {
                    index = i;
                    break;
                }
            }

            if (index < 0)
            {
                throw new KeyNotFoundException();
            }

            return languages[languageIndex].values[index];
        }

        [MenuItem("CONTEXT/LocalizeDictionary/Copy CSV To Clipboard")]
        private static void CopyCsvToClipboard(MenuCommand command)
        {
            var dict = command.context as LocalizeDictionary ?? throw new InvalidProgramException();
            var csv = dict.ToTsv();
            EditorGUIUtility.systemCopyBuffer = csv;
        }

        [MenuItem("CONTEXT/LocalizeDictionary/Import CSV From Clipboard")]
        private static void ImportCsvFromClipboard(MenuCommand command)
        {
            var dict = command.context as LocalizeDictionary ?? throw new InvalidProgramException();
            var csv = EditorGUIUtility.systemCopyBuffer;
            dict.FromTsv(csv);
        }

        private string ToTsv()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"Key\t{string.Join("\t", languages.Select(l => l.name))}");

            for (var i = 0; i < keys.Length; i++)
            {
                var index = i;
                builder.AppendLine(
                    $"{keys[i]}\t{string.Join("\t", languages.Select(l => l.values[index]))}");
            }

            return builder.ToString();
        }

        private void FromTsv(string tsv)
        {
            var lines = tsv.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            var header = lines[0].Split('\t');
            var keyIndex = Array.IndexOf(header, "Key");
            if (keyIndex == -1)
            {
                throw new ArgumentException("TSV must have a column named 'Key'.");
            }

            languages = header
                .Where((_, i) => i != keyIndex)
                .Select(name => new Language { name = name })
                .ToArray();

            keys = lines
                .Skip(1)
                .Select(line => line.Split('\t'))
                .Select(values => values[keyIndex])
                .ToArray();

            foreach (var language in languages)
            {
                language.values = lines
                    .Skip(1)
                    .Select(line => line.Split('\t'))
                    .Select(values => values[Array.IndexOf(header, language.name)])
                    .ToArray();
            }
        }
    }

    [Serializable]
    public class Language
    {
        [SerializeField] public string name;
        [SerializeField] public string[] values;
    }
}