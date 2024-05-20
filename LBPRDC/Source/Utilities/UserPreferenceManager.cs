using System.Text.Json;

namespace LBPRDC.Source.Utilities
{
    internal class UserPreferenceManager
    {
        public static UserPreference LoadPreference()
        {
            string appDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string settingsFilePath = Path.Combine(appDataDir, "LBPRDC", "userPreferences.json");

            if (File.Exists(settingsFilePath))
            {
                string json = File.ReadAllText(settingsFilePath);
                return JsonSerializer.Deserialize<UserPreference>(json);
            }
            else
            {
                return new UserPreference
                {
                    ShowEmployeeID = true,
                    ShowName = true,
                    SelectedNameFormat = NameFormat.Full1,
                    ShowGender = true,
                    ShowEmploymentStatus = true,
                    ShowClassification = true,
                    ShowDepartment = true,
                    ShowLocation = true,
                    ShowEmailAddress = true,
                    SelectedEmailFormat = EmailFormat.FirstOnly,
                    ShowContactNumber = true,
                    SelectedContactFormat = ContactFormat.FirstOnly,
                    ShowPosition = true,
                    SelectedPositionFormat = PositionFormat.NameOnly,
                    ShowSalaryRate = true,
                    ShowBillingRate = true,
                    ShowWageType = true
                };
            }
        }

        public static void SavePreferences(UserPreference preferences)
        {
            string appDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string appDataSubDir = Path.Combine(appDataDir, "LBPRDC");
            Directory.CreateDirectory(appDataSubDir);
            string settingsFilePath = Path.Combine(appDataSubDir, "userPreferences.json");

            string json = JsonSerializer.Serialize(preferences);
            File.WriteAllText(settingsFilePath, json);
        }
    }
}
