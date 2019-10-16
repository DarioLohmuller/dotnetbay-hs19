using System;
using System.IO;
using System.Net;
using System.Net.Mime;
using System.Windows;
using DotNetBay.Core;
using DotNetBay.Data.Entity;
using Microsoft.Win32;

namespace DotNetBay.WPF
{
    /// <summary>
    /// Interaction logic for SellView.xaml
    /// </summary>
    public partial class SellView : Window
    {

        public SellView()
        {
            InitializeComponent();
        }

        private void OpenFileDialog_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                FilePathTxtBox.Text = openFileDialog.FileName;
            }
        }

        private void AddAuction_Click(object sender, RoutedEventArgs e)
        {
            byte[] img = File.ReadAllBytes(FilePathTxtBox.Text);

            var memberService = new SimpleMemberService(App.MainRepository);

            App.MainRepository.Add(new Auction
            {
                Title = TitleTxtBox.Text,
                Description = DescriptionTxtBox.Text,
                StartPrice = Double.Parse(StartPriceTxtBox.Text),
                StartDateTimeUtc = StartDatePicker.SelectedDate.GetValueOrDefault(DateTime.Now),
                EndDateTimeUtc = EndDatePicker.SelectedDate.GetValueOrDefault(DateTime.Now.AddDays(14)),
                Image = img,
                Seller = memberService.GetCurrentMember(),
            });
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
