using System;

// =================================================================================
// CREATIVITY AND EXCEEDING REQUIREMENTS REPORT:
// 1. Added a custom 'Mood rating' field to each Entry (scale 1-5 or descriptive text).
// 2. The user is prompted to input their current mood during the 'Write' action.
// 3. The mood data is successfully integrated into the saving, loading, and display systems.
// =================================================================================

class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        
        bool keepRunning = true;
        Console.WriteLine("Welcome to the Journal Program!");

        while (keepRunning)
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // Lấy câu hỏi và ghi nhận câu trả lời
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"\nPrompt: {prompt}");
                    Console.Write("> ");
                    string response = Console.ReadLine();

                    // Phần sáng tạo thêm: Nhập tâm trạng
                    Console.Write("How is your mood today (1-5 stars, or Great/Sad)? ");
                    string mood = Console.ReadLine();

                    // Lấy ngày hiện tại
                    string currentDate = DateTime.Now.ToShortDateString();

                    // Đóng gói vào đối tượng Entry
                    Entry entry = new Entry();
                    entry._date = currentDate;
                    entry._promptText = prompt;
                    entry._entryText = response;
                    entry._mood = mood;

                    // Thêm vào Journal
                    myJournal.AddEntry(entry);
                    break;

                case "2":
                    Console.WriteLine("\n--- Journal Entries ---");
                    myJournal.DisplayAll();
                    break;

                case "3":
                    Console.Write("\nWhat is the filename to load? ");
                    string loadFile = Console.ReadLine();
                    myJournal.LoadFromFile(loadFile);
                    break;

                case "4":
                    Console.Write("\nWhat is the filename to save? ");
                    string saveFile = Console.ReadLine();
                    myJournal.SaveToFile(saveFile);
                    break;

                case "5":
                    Console.WriteLine("Goodbye!");
                    keepRunning = false;
                    break;

                default:
                    Console.WriteLine("Invalid option. Please choose 1-5.");
                    break;
            }
        }
    }
}