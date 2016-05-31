using Microsoft.Win32;
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

namespace MP3_Converter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private OpenFileDialog ofd_ = new OpenFileDialog();
        private List<Argument> arguments_ = new List<Argument>();
        public MainWindow()
        {
            InitializeComponent();
            arguments_.Add(new Argument("64 kbps", "-b64 "));
            arguments_.Add(new Argument("128 kbps", "-b128 "));
            arguments_.Add(new Argument("192 kbps", "-b192 "));
            arguments_.Add(new Argument("256 kbps", "-b256 "));
            arguments_.Add(new Argument("320 kbps", "-b320 "));
            arguments_.Add(new Argument("V1", "-V1 "));
            arguments_.Add(new Argument("V2", "-V2 "));
            arguments_.Add(new Argument("V3", "-V3 "));
            arguments_.Add(new Argument("V4", "-V4 "));
            arguments_.Add(new Argument("V5", "-V5 "));
            arguments_cb.Items.Clear();
            arguments_cb.Items.Add(arguments_[0]);
            arguments_cb.Items.Add(arguments_[1]);
            arguments_cb.Items.Add(arguments_[2]);
            arguments_cb.Items.Add(arguments_[3]);
            arguments_cb.Items.Add(arguments_[4]);
            arguments_cb.SelectedIndex = 1;
            ofd_.Filter = "Music files (*.mp3, *.wma, *.wav) | *.mp3; *.wma; *.wav";

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            ofd_.ShowDialog();
            path_tb.Text = ofd_.FileName;
        }

        private void radioButtonChecker(object sender, RoutedEventArgs e)
        {
            if ((bool)vbr_rb.IsChecked)
            {
                cbr_rb.IsChecked = false;
                vbr_rb.IsChecked = true;
                arguments_cb.Items.Clear();
                arguments_cb.Items.Add(arguments_[5]);
                arguments_cb.Items.Add(arguments_[6]);
                arguments_cb.Items.Add(arguments_[7]);
                arguments_cb.Items.Add(arguments_[8]);
                arguments_cb.Items.Add(arguments_[9]);
                arguments_cb.SelectedIndex = 1;
            }
            else
            {
                cbr_rb.IsChecked = true;
                vbr_rb.IsChecked = false;
                arguments_cb.Items.Clear();
                arguments_cb.Items.Clear();
                arguments_cb.Items.Add(arguments_[0]);
                arguments_cb.Items.Add(arguments_[1]);
                arguments_cb.Items.Add(arguments_[2]);
                arguments_cb.Items.Add(arguments_[3]);
                arguments_cb.Items.Add(arguments_[4]);
                arguments_cb.SelectedIndex = 1;
            }
        }

        private void removeFile_b_Click(object sender, RoutedEventArgs e)
        {
            path_tb.Text = "Empty";
        }

        private void convert_b_Click(object sender, RoutedEventArgs e)
        {
            Argument arg = (Argument)arguments_cb.SelectedItem;
            status_tb.Text = "Converting";
            Converter.WaveToMP3(path_tb.Text, arg);
            status_tb.Text = "Converted";
            status_tb.Foreground = Brushes.Green;

        }
    }
}
