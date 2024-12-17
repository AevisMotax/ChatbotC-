using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChatbotCSharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string userMessage = UserInput.Text.Trim();

            if (!string.IsNullOrEmpty(userMessage))
            {
                // Display user message
                AddMessageToChat("You: " + userMessage, isUser: true);

                // Process bot response
                string botResponse = BotLogic.GetResponse(userMessage);

                // Display bot response
                AddMessageToChat("Bot: " + botResponse, isUser: false);

                // Clear input field
                UserInput.Clear();
            }
        }

        private void AddMessageToChat(string message, bool isUser)
        {
            TextBlock chatMessage = new TextBlock
            {
                Text = message,
                TextWrapping = TextWrapping.Wrap,
                Margin = new Thickness(0, 5, 0, 5),
                FontWeight = isUser ? FontWeights.Bold : FontWeights.Normal
            };
            ChatPanel.Children.Add(chatMessage);
        }

    }

    // A helper class for bot logic
    public static class BotLogic
    {
        public static string GetResponse(string message)
        {
            // Simple keyword-based response logic
            if (message.ToLower().Contains("hello"))
                return "Hi there! How can I assist you?";
            else if (message.ToLower().Contains("time"))
                return "I'm just a bot, but I suggest checking your clock!";
            else if (message.ToLower().Contains("bye"))
                return "Goodbye! Have a great day!";
            else
                return "I'm sorry, I don't understand that. Can you rephrase?";
        }
    }
}
