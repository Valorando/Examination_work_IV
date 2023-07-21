/*Создать приложение «Словари».
Основная задача проекта: хранить словари на разных языках и разрешать пользова-
телю находить перевод нужного слова или фразы.
Интерфейс приложения должен предоставлять такие возможности:
■ Создавать словарь. При создании нужно указать тип словаря.
Например, англо-русский или русско-английский.
■ Добавлять слово и его перевод в уже существующий словарь. Так как у слова мо-
жет быть несколько переводов, необходимо поддерживать возможность создания
нескольких вариантов перевода.
■ Заменять слово или его перевод в словаре.
■ Удалять слово или перевод. Если удаляется слово, все его переводы удаляются
вместе с ним. Нельзя удалить перевод слова, если это последний вариант пере-
вода.
■ Искать перевод слова.
■ Словари должны храниться в файлах.
■ Слово и варианты его переводов можно экспортировать в отдельный файл резуль-
тата. 
■ При старте программы необходимо показывать меню для работы с программой.
Если выбор пункта меню открывает подменю, то тогда в нем требуется предусмо-
треть возможность возврата в предыдущее меню.*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

Console.OutputEncoding = Encoding.UTF8;
Console.ForegroundColor = ConsoleColor.Green;
Dictionary_Manager dictionary_Manager = new Dictionary_Manager();

int key;
while (true)
{
    try
    {
        Console.WriteLine();
        Console.WriteLine("Введите 1 чтобы создать словарь.");
        Console.WriteLine("Введите 2 чтобы открыть словарь.");
        Console.WriteLine("Введите 3 чтобы выйти.");
        Console.WriteLine();
        Console.Write("Ваш выбор: ");
        key = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();

        if (key == 1)
        {
            try
            {
                dictionary_Manager.Create_Dictionary();
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine();
            }
        }

        if (key == 2)
        {
            try
            {
                dictionary_Manager.Open_Dictionary();
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine();
            }
        }

        if (key == 3)
        {
            Console.WriteLine();
            Console.WriteLine("Выполняется выход....");
            Console.WriteLine();
            break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine();
        Console.WriteLine($"Ошибка: {ex.Message}");
        Console.WriteLine();
    }
}

class Dictionary_Manager
{
    public void Create_Dictionary()
    {
        int key_two;
        Console.WriteLine();
        Console.Write("Введите название нового словаря: ");
        string dictionaryName = Console.ReadLine();
        Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

        Console.WriteLine();
        Console.WriteLine("Словарь создан, перед началом работы сохраните его.");

        if (dictionaryName != "Examination_work_IV.deps" && dictionaryName != "Examination_work_IV.runtimeconfig")
        {
            while (true)
            {


                Console.WriteLine();
                Console.WriteLine("Введите 1 чтобы добавить слово.");
                Console.WriteLine("Введите 2 чтобы изменить слово.");
                Console.WriteLine("Введите 3 чтобы удалить слово.");
                Console.WriteLine("Введите 4 чтобы найти перевод слова.");
                Console.WriteLine("Введите 5 чтобы сохранить словарь или его изменения(обязательно).");
                Console.WriteLine("Введите 6 чтобы посмотреть содержимое словаря.");
                Console.WriteLine("Введите 7 чтобы веруться в предыдущее меню.");

                Console.Write("Ваш выбор: ");
                key_two = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                if (key_two == 1)
                {
                    try
                    {
                        Add_Word(dictionary);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Ошибка: {ex.Message}");
                        Console.WriteLine();
                    }
                }

                if (key_two == 2)
                {
                    try
                    {
                        Change_Word(dictionary);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Ошибка: {ex.Message}");
                        Console.WriteLine();
                    }
                }

                if (key_two == 3)
                {
                    try
                    {
                        Delete_Word(dictionary);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Ошибка: {ex.Message}");
                        Console.WriteLine();
                    }
                }

                if (key_two == 4)
                {
                    try
                    {
                        Search_Translation(dictionary);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Ошибка: {ex.Message}");
                        Console.WriteLine();
                    }
                }

                if (key_two == 5)
                {
                    try
                    {
                        Save_Dictionary(dictionary, dictionaryName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Ошибка: {ex.Message}");
                        Console.WriteLine();
                    }
                }

                if (key_two == 6)
                {
                    try
                    {
                        Show_Content(dictionaryName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Ошибка: {ex.Message}");
                        Console.WriteLine();
                    }
                }

                if (key_two == 7)
                {
                    break;
                }
            }
        }
        else
        {
            Console.WriteLine("Недопустимое имя словаря.");
        }

    }

    static void Add_Word(Dictionary<string, List<string>> dictionary)
    {
        Console.WriteLine();
        Console.Write("Введите слово: ");
        string word = Console.ReadLine();

        if (dictionary.ContainsKey(word))
        {
            Console.WriteLine();
            Console.WriteLine("Такое слово уже существует в словаре.");
            Console.WriteLine();
            return;
        }

        List<string> translations = new List<string>();

        while (true)
        {
            Console.WriteLine();
            Console.Write("Введите переводы: (если слово имеет один перевод, остальные ячейки оставьте пустыми): ");
            string translation = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(translation))
            {
                break;
            }

            translations.Add(translation);
        }

        dictionary[word] = translations;
        Console.WriteLine("Не забудьте сохранить изменения через опцию 5.");
    }

    static void Change_Word(Dictionary<string, List<string>> dictionary)
    {
        Console.WriteLine();
        Console.Write("Введите слово, которое требуется заменить: ");
        string word = Console.ReadLine();

        if (!dictionary.ContainsKey(word))
        {
            Console.WriteLine();
            Console.WriteLine("Такого слова нет в словаре.");
            return;
        }

        List<string> translations = new List<string>();

        while (true)
        {
            Console.WriteLine();
            Console.Write("Введите новые переводы: (если слово имеет один перевод или новые переводы не требуются, оставьте остальные ячейки оставьте пустыми):");
            string translation = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(translation))
            {
                break;
            }

            translations.Add(translation);
        }

        dictionary[word] = translations;
        Console.WriteLine("Не забудьте сохранить изменения через опцию 5.");
    }

    static void Delete_Word(Dictionary<string, List<string>> dictionary)
    {
        Console.WriteLine();
        Console.Write("Введите слово, которое требуется удалить: ");
        string word = Console.ReadLine();

        if (!dictionary.ContainsKey(word))
        {
            Console.WriteLine();
            Console.WriteLine("Такого слова нет в словаре.");
            return;
        }

        dictionary.Remove(word);
        Console.WriteLine("Не забудьте сохранить изменения через опцию 5.");
    }

    static void Search_Translation(Dictionary<string, List<string>> dictionary)
    {
        Console.WriteLine();
        Console.Write("Введите слово, перевод которого требуется найти: ");
        string word = Console.ReadLine();

        if (dictionary.TryGetValue(word, out List<string> translations))
        {
            Console.WriteLine();
            Console.WriteLine("Переводы:");
            foreach (string translation in translations)
            {
                Console.WriteLine(translation);
            }
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Такого слова нет в словаре.");
        }
    }

    static void Save_Dictionary(Dictionary<string, List<string>> dictionary, string dictionaryName)
    {
        string json = JsonSerializer.Serialize(dictionary);
        File.WriteAllText($"{dictionaryName}.json", json);
        Console.WriteLine("Словарь успешно cохранён.");
    }

    public void Open_Dictionary()
    {

        Console.WriteLine();
        Console.WriteLine("Список доступных словарей: (если вашего словаря нет в списке, значит вы его не сохранили)");
        string[] dictionaryFiles = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.json");

        if (dictionaryFiles.Length == 0)
        {
            Console.WriteLine();
            Console.WriteLine("Нет доступных словарей.");
            return;
        }

        List<string> availableDictionaries = new List<string>();
        foreach (string file in dictionaryFiles)
        {
            string fileName = Path.GetFileNameWithoutExtension(file);
            if (fileName != "Examination_work_IV.deps" && fileName != "Examination_work_IV.runtimeconfig")
            {
                availableDictionaries.Add(fileName);
            }
        }

        if (availableDictionaries.Count == 0)
        {
            Console.WriteLine();
            Console.WriteLine("Нет доступных словарей.");
            return;
        }

        for (int i = 0; i < availableDictionaries.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {availableDictionaries[i]}");
        }

        Console.WriteLine();
        Console.Write("Введите номер словаря: ");
        int selectedDictionaryIndex = int.Parse(Console.ReadLine()) - 1;

        if (selectedDictionaryIndex < 0 || selectedDictionaryIndex >= availableDictionaries.Count)
        {
            Console.WriteLine();
            Console.WriteLine("Ошибка: неверный выбор.");
            return;
        }

        string selectedDictionaryName = availableDictionaries[selectedDictionaryIndex];
        string selectedDictionaryPath = $"{selectedDictionaryName}.json";
        string json = File.ReadAllText(selectedDictionaryPath);
        var dictionary = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(json);

        if (dictionary == null)
        {
            dictionary = new Dictionary<string, List<string>>();
        }

        Open_Dictionary_Menu(selectedDictionaryName, dictionary);
    }

    static void Open_Dictionary_Menu(string dictionaryName, Dictionary<string, List<string>> dictionary)
    {
        while (true)
        {
            int key_three;
            Console.WriteLine();
            Console.WriteLine("Введите 1 чтобы добавить слово.");
            Console.WriteLine("Введите 2 чтобы изменить слово.");
            Console.WriteLine("Введите 3 чтобы удалить слово.");
            Console.WriteLine("Введите 4 чтобы найти перевод слова.");
            Console.WriteLine("Введите 5 чтобы сохранить словарь или его изменения(обязательно).");
            Console.WriteLine("Введите 6 чтобы посмотреть содержимое словаря.");
            Console.WriteLine("Введите 7 чтобы вернуться в предыдущее меню..");
            Console.WriteLine();
            Console.Write("Ваш выбор: ");
            key_three = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            if (key_three == 1)
            {
                try
                {
                    Add_Word(dictionary);
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    Console.WriteLine();
                }
            }

            if (key_three == 2)
            {
                try
                {
                    Change_Word(dictionary);
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    Console.WriteLine();
                }
            }

            if (key_three == 3)
            {
                try
                {
                    Delete_Word(dictionary);
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    Console.WriteLine();
                }
            }

            if (key_three == 4)
            {
                try
                {
                    Search_Translation(dictionary);
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    Console.WriteLine();
                }
            }

            if (key_three == 5)
            {
                try
                {
                    Save_Dictionary(dictionary, dictionaryName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    Console.WriteLine();
                }
            }

            if (key_three == 6)
            {
                try
                {
                    Show_Content(dictionaryName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    Console.WriteLine();
                }
            }

            if (key_three == 7)
            {
                break;
            }
        }
    }

    static void Show_Content(string dictionaryName)
    {
        string filePath = $"{dictionaryName}.json";

        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Словарь с именем \"{dictionaryName}\" не найден.");
            return;
        }

        string json = File.ReadAllText(filePath);
        var dictionary = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(json);

        if (dictionary == null)
        {
            Console.WriteLine($"Содержимое словаря \"{dictionaryName}\" пусто.");
            return;
        }

        Console.WriteLine($"Содержимое словаря \"{dictionaryName}\":");
        Console.WriteLine();

        foreach (var kvp in dictionary)
        {
            Console.WriteLine($"Слово: {kvp.Key}");
            Console.WriteLine("Переводы:");
            foreach (var translation in kvp.Value)
            {
                Console.WriteLine(translation);
            }
            Console.WriteLine();
        }
    }
}
