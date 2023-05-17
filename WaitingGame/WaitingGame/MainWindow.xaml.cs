using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace WaitingGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Stopwatch stopwatch;
        private int clickCounter = 0;

        public MainWindow()
        {
            InitializeComponent();

            // Create the stopwatch
            stopwatch = new Stopwatch();
        }

        /// <summary>
        /// Generates a random number between 2 and 4
        /// </summary>
        /// <returns></returns>
        public int RandomNumber()
        {
            Random random = new Random();

            int target = random.Next(2, 5);

            return target;
        }

        /// <summary>
        /// Start and stop stopwatch on button clicks to display results
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void myButton_click(object sender, RoutedEventArgs e)
        {
            clickCounter++;

            if (stopwatch.IsRunning)
            {
                // Stop the stopwatch
                stopwatch.Stop();

                // Display the elapsed time
                double seconds = stopwatch.Elapsed.TotalSeconds;
                string formattedTime = seconds.ToString("0.000");
                myButton.Content = $"Elapsed time: {formattedTime} seconds";

                // Display if timing was correct 
                if (seconds == RandomNumber())
                    MessageBox.Show("Unbelievable! Perfect timing!");
                else if (seconds < RandomNumber())
                    MessageBox.Show($"{RandomNumber() - seconds:F3} seconds too fast");
                else
                    MessageBox.Show($"{seconds - RandomNumber():F3} seconds too slow");

                if (clickCounter == 4)
                {
                    // Display a confirmation message before closing main window 
                    MessageBoxResult result = MessageBox.Show("Do you want to continue playing?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (result == MessageBoxResult.No)
                    {
                        // Close the main window to exit the program
                        Close();
                    }
                    else
                    {
                        // Reset the click counter if the user cancels
                        clickCounter = 0;
                    }
                }

                // Reset the stopwatch
                stopwatch.Restart();

                // Change the button content
                myButton.Content = $"Click again after {RandomNumber()} seconds";
            }
            else
            {
                // Change the button content
                myButton.Content = $"Click again after {RandomNumber()} seconds";

                // Start the stopwatch
                stopwatch.Start();
            }           
        }

        /// <summary>
        /// Change button display when mouse enters button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void myButton_MouseEnter(object sender, MouseEventArgs e)
        {
            myButton.FontSize = 32;
            myButton.FontWeight = FontWeights.Bold;
        }

        /// <summary>
        /// Change button display back when mouse leaves button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void myButton_MouseLeave(object sender, MouseEventArgs e)
        {
            myButton.Background = Brushes.White;
            myButton.FontSize = 30;
            myButton.FontWeight = FontWeights.Normal;
        }
    }
}
