using DotNetBay.Core.Execution;
using DotNetBay.Data.Provider.FileStorage;
using DotNetBay.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using DotNetBay.Core;
using DotNetBay.Data.Entity;

namespace DotNetBay.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static readonly IMainRepository MainRepository = new FileSystemMainRepository("WPF_Repository");
        public readonly IAuctionRunner AuctionRunner = new AuctionRunner(MainRepository);

        public App()
        {
            this.AuctionRunner.Start();
            LoadDemoData();
        }

        private static void LoadDemoData()
        {
            var memberService = new SimpleMemberService(MainRepository);
            var service = new AuctionService(MainRepository, memberService);

            if (!service.GetAll().Any())
            {
                var me = memberService.GetCurrentMember();

                service.Save(new Auction
                {
                    Title = "My First Auction",
                    StartDateTimeUtc = DateTime.UtcNow.AddSeconds(10),
                    EndDateTimeUtc = DateTime.UtcNow.AddDays(14),
                    StartPrice = 72,
                    Seller = me
                });

                service.Save(new Auction
                {
                    Title = "My Second Auction",
                    StartDateTimeUtc = DateTime.UtcNow.AddSeconds(100),
                    EndDateTimeUtc = DateTime.UtcNow.AddDays(20),
                    StartPrice = 44,
                    Seller = me
                });

                service.Save(new Auction
                {
                    Title = "My Third Auction",
                    StartDateTimeUtc = DateTime.UtcNow.AddSeconds(20),
                    EndDateTimeUtc = DateTime.UtcNow.AddDays(3),
                    StartPrice = 53.60,
                    Seller = me
                });
            }
        }
    }
}
