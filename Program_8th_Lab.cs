﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
abstract class Task
{
    protected string text;
    public Task(string text) { this.text = text; }

    protected string check = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯABCDEFGHIJKLMNOPQRSTUVWXYZ";
    protected virtual void Solution() { }
}

class Task_1 : Task
{
    string answer;
    public Task_1(string text) : base(text) { answer = ""; }
    public override string ToString()
    {
        Solution();
        return answer;
    }

    private string ReverseText(string txt)
    {
        string result = "";
        for (int i = 0; i < txt.Length; ++i)
        {
            string word = "";
            if (check.Contains(txt.ToUpper()[i]))
            {
                word += txt[i];
                while (i + 1 < txt.Length && check.Contains(txt.ToUpper()[i + 1]))
                {
                    word += txt[i + 1];
                    ++i;
                }
            }
            char[] arr = word.ToCharArray();
            Array.Reverse(arr);
            word = new string(arr);
            if (word != "")
                result += word;
            else
                result += txt[i];
        }
        return result;
    }
    protected override void Solution()
    {
        string tmp = ReverseText(text);
        answer = tmp + '\n' + ReverseText(tmp);
    }

}

class Task_2 : Task
{
    int count;
    public Task_2(string text) : base(text) { count = 0; }
    public override string ToString()
    {
        Solution();
        return Convert.ToString(count);
    }
    protected override void Solution()
    {
        char[] charSeparators = new char[] { ' ', ',', '-', '!', '.', ':', ';', '(', ')' };
        count = text.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries).Length;
        foreach (var i in text)
        {
            if (",-!.:;()".Contains(i))
            {
                ++count;
            }
        }

    }
}

class Task_3 : Task
{
    int[] count;
    public Task_3(string text) : base(text) { count = new int[40]; }
    public override string ToString()
    {
        Solution();
        string parse = "";
        for (int i = 0; i < 40; ++i)
        {
            if (count[i] != 0)
            {
                parse += i.ToString() + "слогов : " + count[i].ToString() + '\n';
            }
        }
        return parse;
    }
    protected override void Solution()
    {
        char[] charSeparators = new char[] { ' ', ',', '-', '!', '.', ':', ';', '(', ')' };
        string[] s = text.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
        string vow = "auoyieаиеёуояыюэ";
        foreach (var i in s)
        {
            int syll = 0;
            for (int j = 0; j < i.Length; ++j)
            {
                if (vow.Contains(i.ToLower()[j]))
                    ++syll;
            }
            if (syll > 0) count[syll]++;
        }

    }
}

class Task4 : Task
{
    private string cust_answer;
    public string Cust_Answer
    {
        get => cust_answer;
        protected set => cust_answer = value;
    }
    public Task4(string customText) : base(customText)
    {
        cust_answer = "";
    }
    protected override void Solution()
    {
        int _tmpLength = 0;
        int count, spacesPerWord, remainingSpaces;
        string[] cust_words = text.Split(' ', (char)StringSplitOptions.RemoveEmptyEntries);
        int lastWordIndex = 0;
        for (int i = 0; i < cust_words.Length; ++i)
        {
            _tmpLength += cust_words[i].Length + 1;

            if (_tmpLength >= 50)
            {
                _tmpLength -= (cust_words[i].Length + 2);
                count = 50 - _tmpLength;
                spacesPerWord = count / (i - lastWordIndex - 1);
                remainingSpaces = count % (i - lastWordIndex - 1);
                for (int j = lastWordIndex; j < i; ++j)
                {
                    cust_answer += cust_words[j];
                    cust_answer += " ";
                    for (int k = 0; k < spacesPerWord; ++k)
                    {
                        cust_answer += " ";
                    }
                    if (remainingSpaces > 0)
                    {
                        cust_answer += " ";
                        --remainingSpaces;
                    }
                }
                cust_answer += "\n";
                lastWordIndex = i;
                --i;
                _tmpLength = 0;
            }
        }
        if (lastWordIndex != cust_words.Length - 1)
        {
            int i = cust_words.Length - 1;
            _tmpLength -= 1;
            count = 50 - _tmpLength;
            spacesPerWord = count / (i - lastWordIndex);
            remainingSpaces = count % (i - lastWordIndex);
            for (int j = lastWordIndex; j <= i; ++j)
            {
                cust_answer += cust_words[j];
                cust_answer += " ";
                for (int k = 0; k < spacesPerWord; ++k)
                {
                    cust_answer += " ";
                }
                if (remainingSpaces > 0)
                {
                    cust_answer += " ";
                    --remainingSpaces;
                }
            }
            cust_answer += "\n";
        }
    }

    public override string ToString()
    {
        Solution();
        return Convert.ToString(cust_answer);
    }
}
class Task_5 : Task
{
    private string result;
    private string mod_Text;
    Dictionary<char, string> encodingMap;
    int startCode = 100;
    public string Result
    {
        get => result;
    }
    public Dictionary<char, string> EncodingMap
    {
        get => encodingMap;
    }
    public Task_5(string inputText) : base(inputText)
    {
        result = "";
        encodingMap = new Dictionary<char, string>();
        mod_Text = inputText.ToLower();
        Solution();
    }

    private bool IterateAndReplace()
    {
        Dictionary<string, int> pairCounter = new Dictionary<string, int>();
        for (int i = 0; i < mod_Text.Length; i++)
        {
            if (i + 1 < mod_Text.Length && check.Contains(mod_Text.ToUpper()[i]) && check.Contains(mod_Text.ToUpper()[i + 1]))
            {
                string pair = Convert.ToString(mod_Text[i]) + mod_Text[i + 1];
                if (pairCounter.ContainsKey(pair))
                {
                    pairCounter[pair]++;
                }
                else
                {
                    pairCounter[pair] = 1;
                }
                if (mod_Text[i] == mod_Text[i + 1] && i + 2 < mod_Text.Length && mod_Text[i + 1] == mod_Text[i + 2])
                    ++i;
            }
        }
        string mostFrequentPair = "";
        int maxCount = 0;
        foreach (string pair in pairCounter.Keys)
        {
            if (pairCounter[pair] > maxCount)
            {
                maxCount = pairCounter[pair];
                mostFrequentPair = pair;
            }
        }
        string temp = "";
        for (int i = 0; i < mod_Text.Length; i++)
        {
            if (i + 1 < mod_Text.Length && Convert.ToString(mod_Text[i]) + mod_Text[i + 1] == mostFrequentPair)
            {
                ++i;
                continue;
            }
            temp += mod_Text[i];
        }
        mod_Text = temp;
        while (text.Contains((char)startCode) || encodingMap.ContainsKey((char)startCode))
        {
            ++startCode;
        }
        encodingMap[(char)startCode] = mostFrequentPair;
        return true;
    }
    protected override void Solution()
    {
        for (int i = 0; i < 5; ++i)
        {
            IterateAndReplace();
        }
        result = text;
        foreach (var item in encodingMap)
        {
            result = result.Replace(item.Value, Convert.ToString(item.Key));
        }
    }
    public override string ToString()
    {
        return string.Join(Environment.NewLine, encodingMap) + '\n' + result + '\n';
    }
}
class Task_6 : Task
{
    private string result;
    Dictionary<char, string> mapping;
    public string Result
    {
        get => result;
    }
    public Task_6(string inputText, Dictionary<char, string> _mapping) : base(inputText)
    {
        result = "";
        mapping = _mapping;
    }

    protected override void Solution()
    {
        foreach (var character in text)
        {
            if (mapping.ContainsKey(character))
            {
                result += mapping[character];
            }
            else
            {
                result += character;
            }
        }
    }
    public override string ToString()
    {
        Solution();
        return result;
    }
}

class Program
{
    public static void Main()
    {
        string text = "1 июля 2015 года Греция объявила о дефолте по государственному долгу, став первой развитой страной в истории, которая не смогла выплатить свои долговые обязательства в полном объеме. Сумма дефолта составила порядка 1,6 миллиарда евро. Этому предшествовали долгие переговоры с международными кредиторами, такими как Международный валютный фонд (МВФ), Европейский центральный банк (ЕЦБ) и Европейская комиссия (ЕК), о программах финансовой помощи и реструктуризации долга. Основными причинами дефолта стали недостаточная эффективность реформ, направленных на улучшение финансовой стабильности страны, а также политическая нестабильность, что вызвало потерю доверия со стороны международных инвесторов и кредиторов. Последствия дефолта оказались глубокими и долгосрочными: сокращение кредитного рейтинга страны, увеличение затрат на заемный капитал, рост стоимости заимствований и утрата доверия со стороны международных инвесторов.";
        string sentense = "1 июля 2015 года Греция объявила о дефолте по государственному долгу, став первой развитой страной в истории, которая не смогла выплатить свои долговые обязательства в полном объеме.";
        Task_1 task1 = new Task_1(text);
        Task_2 task_2 = new Task_2(sentense);
        Task_3 task_3 = new Task_3(text);
        Task4 task_4 = new Task4(text);
        Task_5 task_5 = new Task_5(text);
        Task_6 task6 = new Task_6(text, task_5.EncodingMap);

        Console.WriteLine(task1);
        Console.WriteLine(task_2);
        Console.WriteLine(task_3);
        Console.WriteLine(task_4);
        Console.WriteLine(task_5);
        Console.WriteLine(task6);
    }
}