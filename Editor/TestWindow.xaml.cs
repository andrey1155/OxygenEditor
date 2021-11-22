using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Editor
{
    /// <summary>
    /// Логика взаимодействия для TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {
        private TestActionTabViewModel tatv;
        public TestWindow()
        {
            InitializeComponent();

            tatv = new TestActionTabViewModel();
            tabs.ItemsSource = tatv.Tabs;

            tatv.AddTab("Test", TextChanged, 20, tabs, BreakpointClick);
            tatv.AddTab("Test2", TextChanged, 20, tabs, BreakpointClick);
        }

        private void TextChanged(object sender, TextChangedEventArgs e) 
        {
            TestActionTabItem active = (TestActionTabItem)tabs.SelectedItem;
            setStringsCounter(active.Counter, CountLines(active.Content));

        }

        public int CountLines(RichTextBox rtb)
        {
            TextRange documentRange = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);

            string[] T = documentRange.Text.Split('\r');

            return T.Length-1;
        }

        private void setStringsCounter(RichTextBox LineCounter,int lines)
        {
            TextRange documentRange = new TextRange(LineCounter.Document.ContentStart, LineCounter.Document.ContentEnd);

            documentRange.Text = "";
            for(int i = 1; i <= lines; i++)
            {
                documentRange.Text += i.ToString() + "\n";
            }
        }

        
        private void ScrollChange(object sender, ScrollChangedEventArgs e)
        {
            TestActionTabItem active = (TestActionTabItem)tabs.SelectedItem;

            active.Counter.ScrollToVerticalOffset(e.VerticalOffset);
        }

        private double GetLineClick(double y)
        {
            Rect T = ((TestActionTabItem)tabs.SelectedItem).Content.CaretPosition.GetCharacterRect(LogicalDirection.Forward);

            return T.Height;
        }

        private void BreakpointClick(object sender, MouseButtonEventArgs e)
        {
            double height = GetLineClick(e.GetPosition(((TestActionTabItem)tabs.SelectedItem).Content).Y);

            double line = e.GetPosition((UIElement)sender).Y / height;

            int l = (int)line;         
        }
    }

    public class TestActionTabItem
    {
        public string Header { get; set; }
        public RichTextBox Content { get; set; }
        public RichTextBox Counter { get; set; }

        public Canvas Breakpoints { get; set; }
    }

    public class TestActionTabViewModel
    {
        public ObservableCollection<TestActionTabItem> Tabs { get; set; }

        public TestActionTabViewModel()
        {
            Tabs = new ObservableCollection<TestActionTabItem>();
        }
        public void AddTab(string header, TextChangedEventHandler textChanged, double fontSize, TabControl parent, MouseButtonEventHandler mouseDawn)
        {
            var T = new RichTextBox();
            T.TextChanged += textChanged;
            T.FontSize = fontSize;

            var T2 = new RichTextBox();
            T2.FontSize = fontSize;
            T2.PreviewMouseLeftButtonDown += mouseDawn;

            var T3 = new Canvas();           
            T3.PreviewMouseLeftButtonDown += mouseDawn;
            T3.PreviewMouseDown += mouseDawn;


            var tab = new TestActionTabItem {Breakpoints = T3 ,Header = header, Content = T, Counter = T2 };
            Tabs.Add(tab);
            parent.SelectedItem = tab;
        }
    }
}
