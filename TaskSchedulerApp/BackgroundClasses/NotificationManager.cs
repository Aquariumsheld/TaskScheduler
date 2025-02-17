using System;
using static TranslationsLibrary.TranslationManager;
public class NotificationManager
{
    public void SendNotification(string message)
    {
        string CurrentLanguage = GetCurrentLanguage();
        Console.WriteLine(GetTranslation(CurrentLanguage, message));
    }
}
