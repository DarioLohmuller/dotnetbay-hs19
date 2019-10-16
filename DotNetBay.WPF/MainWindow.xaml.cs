using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using DotNetBay.Core;
using DotNetBay.Data.Entity;

namespace DotNetBay.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public readonly IAuctionService AuctionService;
        private ObservableCollection<Auction> auctions = new ObservableCollection<Auction>();
        public ObservableCollection<Auction> Auctions
        {
            get { return this.auctions; }
        }


        public MainWindow()
        {
            InitializeComponent();

            this.AuctionService = new AuctionService(App.MainRepository, new SimpleMemberService(App.MainRepository));
            this.auctions = new ObservableCollection<Auction>(this.AuctionService.GetAll());

            this.DataContext = this;
        }

        private void NewAuction_Click(object sender, RoutedEventArgs e)
        {
            var sellView = new SellView();
            sellView.ShowDialog(); // Blocking
        }

        private void PlaceBid_Click(object sender, RoutedEventArgs e)
        {
            var bidView = new BidView();
            bidView.ShowDialog(); // Blocking
        }
    }
}
