//using System;
//using System.Drawing;
//using System.Windows.Forms;
//using System.Xml.Serialization;

//namespace EventPlayground
//{
//    //public delegate void ColorHandler(Color newColor);
//    //public delegate void TextHandler(string newText);

//    public delegate void ColorChangedEventHandler(object sender, ColorEventArgs e);
//    public delegate void TextChangedEventHandler(object sender, EventArgs e);

//    public class ColorEventArgs : EventArgs
//    {
//        public string ColorName { get; }
//        public Color Color { get; }

//        public ColorEventArgs(string colorName, Color color)
//        {
//            ColorName = colorName;
//            Color = color;
//        }
//    }
//    public partial class Form1 : Form
//    {
//        //public event ColorHandler ColorEvent;
//        //public event TextHandler TextEvent;

        
//        public event ColorChangedEventHandler ColorChangedEvent;
//        public event TextChangedEventHandler TextChangedEvent;

//        public Form1()
//        {
//            InitializeComponent();
//            //ColorEvent += OnColorChange;
//            //TextEvent += OnTextChange;

//            //Multiple subscribers to demonstrate multicast behavior
//            ColorChangedEvent += UpdateLabelColor;  // First subscriber
//            ColorChangedEvent += ShowNotification;  // Second subscriber
//            TextChangedEvent += OnTextChange;
//        }

//        private void Form1_Load(object sender, EventArgs e)
//        {
//            cmbColors.Items.AddRange(new string[] { "Red", "Green", "Blue", "Orange", "Yellow", "Brown" });
//            cmbColors.SelectedIndex = 0;
//        }
//        //Event handler for ChangeColor click
//        private void ChangeColor_Click(object sender, EventArgs e)
//        {
//            //// Get the selected color from ComboBox
//            //Color selectedColor = GetSelectedColor();

//            //// Raise the custom ColorChangedEvent
//            //ColorEvent?.Invoke(selectedColor);

//            string colorName = cmbColors.SelectedItem?.ToString() ?? "Red";
//            Color selectedColor = GetSelectedColor();

//            // Create ColorEventArgs and raise ColorChangedEvent
//            ColorEventArgs colorArgs = new ColorEventArgs(colorName, selectedColor);
//            ColorChangedEvent?.Invoke(this, colorArgs);

//        }

//        // Event handler for ChangeText click
//        private void ChangeText_Click(object sender, EventArgs e)
//        {
//            // Create new text with current date and time
//            //string newText = $"Current Time: {DateTime.Now:yyyy-MM-dd HH:mm:ss}";

//            //// Raise the custom TextChangedEvent
//            //TextEvent?.Invoke(newText);

//            TextChangedEvent?.Invoke(this, EventArgs.Empty);
//        }

//        // Custom event handler for ColorEvent
//        //private void OnColorChange(Color newColor)
//        //{
//        //    lblDisplay.ForeColor = newColor;
//        //}

//        //First subscriber: UpdateLabelColor method
//        private void UpdateLabelColor(object sender, ColorEventArgs e)
//        {
//            lblDisplay.ForeColor = e.Color;
//        }

//        //Task 2 - Second subscriber: ShowNotification method
//        private void ShowNotification(object sender, ColorEventArgs e)
//        {
//            MessageBox.Show($"Color changed to: {e.ColorName}",
//                          "Color Change Notification",
//                          MessageBoxButtons.OK,
//                          MessageBoxIcon.Information);
//        }


//        // Custom event handler for TextEvent
//        //private void OnTextChange(string newText)
//        //{
//        //    lblDisplay.Text = newText;
//        //}

//        //Event handler for TextChangedEvent
//        private void OnTextChange(object sender, EventArgs e)
//        {
//            lblDisplay.Text = $"Current Time: {DateTime.Now:yyyy-MM-dd HH:mm:ss}";
//        }

//        // Helper method to convert ComboBox selection to Color
//        private Color GetSelectedColor()
//        {
//            return cmbColors.SelectedItem?.ToString() switch
//            {
//                "Red" => Color.Red,
//                "Green" => Color.Green,
//                "Blue" => Color.Blue,
//                "Orange" => Color.Orange,
//                "Yellow" => Color.Yellow,
//                "Brown" => Color.Brown,
//                _ => Color.Black
//            };
//        }
//    }
//}