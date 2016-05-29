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
        OpenFileDialog ofd_ = new OpenFileDialog();
        public MainWindow()
        {
            InitializeComponent();
            arguments_cb.Items.Clear();
            arguments_cb.Items.Add("64 kbps");
            arguments_cb.Items.Add("128 kbps");
            arguments_cb.Items.Add("192 kbps");
            arguments_cb.Items.Add("256 kbps");
            arguments_cb.Items.Add("320 kbps");
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
                arguments_cb.Items.Add("V1");
                arguments_cb.Items.Add("V2");
                arguments_cb.Items.Add("V3");
                arguments_cb.Items.Add("V4");
                arguments_cb.Items.Add("V5");
                arguments_cb.SelectedIndex = 1;
            }
            else
            {
                cbr_rb.IsChecked = true;
                vbr_rb.IsChecked = false;
                arguments_cb.Items.Clear();
                arguments_cb.Items.Add("64 kbps");
                arguments_cb.Items.Add("128 kbps");
                arguments_cb.Items.Add("192 kbps");
                arguments_cb.Items.Add("256 kbps");
                arguments_cb.Items.Add("320 kbps");
                arguments_cb.SelectedIndex = 1;
            }
        }

        private void removeFile_b_Click(object sender, RoutedEventArgs e)
        {
            path_tb.Text = "Empty";
        }

        private void convert_b_Click(object sender, RoutedEventArgs e)
        {
            Converter.WaveToMP3(path_tb.Text);
        }
    }
}
