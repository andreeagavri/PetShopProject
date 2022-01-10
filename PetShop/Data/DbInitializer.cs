using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetShopModel.Models;

namespace PetShopModel.Data
{
    public class DbInitializer
    {
        public static void Initialize(PetShopContext context)
        {
            context.Database.EnsureCreated();
            if (context.SuppliedProducts.Any())
            {
                return; // BD a fost creata anterior
            }


            var products = new Product[]
            {
                new Product{Title="PURINA PRO PLAN Nutrisavour Sterilised",Brand="Purina",ProductType="Mancare pisici",Price=Decimal.Parse("5"),Image="https://shop-cdn-m.mediazs.com/bilder/purina/pro/plan/nutrisavour/sterilised/x/g/6/400/66003_pro_plan_sterilised_h_6.jpg"},
                new Product{Title="Purina ONE Sterilcat cu somon",Brand="Purina",ProductType="Mancare pisici",Price=Decimal.Parse("31"),Image="https://shop-cdn-m.mediazs.com/bilder/purina/one/sterilcat/cu/somon/7/400/71071_pla_purinaone_sterilcatlachs_800g_01_7.jpg"},
                new Product{Title="Royal Canin Pliculețe Caini Rase Mici",Brand="Royal Canin",ProductType="Mancare caini",Price=Decimal.Parse("37"),Image="https://shop-cdn-m.mediazs.com/bilder/gratis/royal/canin/pliculee/cini/rase/mici/0/400/1591355865402_img1_0.jpg"},
                new Product{Title="PURINA PRO PLAN Medium Adult Sensitive Skin OPTIDERMA",Brand="Purina",ProductType="Mancare caini",Price=Decimal.Parse("260"),Image="https://shop-cdn-m.mediazs.com/bilder/purina/pro/plan/medium/adult/sensitive/skin/optiderma/8/400/67040_pla_pp_mediumadultsensiderma12kg_8.jpg"},
                new Product{Title="Leo Jucarie undita pentru pisici",Brand="Tiger",ProductType="Jucarii pisici",Price=Decimal.Parse("7"),Image="https://shop-cdn-m.mediazs.com/bilder/leo/jucrie/undi/pentru/pisici/5/400/58428_PLA_Katzenangel_Leo_FG__64_5.jpg"},
                new Product{Title="Set jucării mingiuțe & șoricei pentru pisici",Brand="Tiger",ProductType="Jucarii pisici",Price=Decimal.Parse("23"),Image="https://shop-cdn-m.mediazs.com/bilder/set/jucrii/mingiue/oricei/pentru/pisici/5/400/55406_PLA_Katzenspielzeug_Set_mit_Baellen___Maeusen_FG_DSC0362_5.jpg"},
                new Product{Title="Chuckit! Ultra Ball",Brand="FunTime",ProductType="Jucarii caini",Price=Decimal.Parse("29"),Image="https://shop-cdn-m.mediazs.com/bilder/chuckit/ultra/ball/5/400/64169_pla_chuckit_ultra_ball_m_hs_01_5.jpg"},
                new Product{Title="Spikey Jucărie câini",Brand="FunTime",ProductType="Jucarii caini",Price=Decimal.Parse("14"),Image="https://shop-cdn-m.mediazs.com/bilder/spikey/jucrie/cini/1/400/179099_pla_spikey_fg_7422_1.jpg"},

            };
            foreach (Product s in products)
            {
                context.Products.Add(s);
            }

            context.SaveChanges();
            var clients = new Client[]
            {
                new Client{ClientID=1,Name="Gavri Andreea",BirthDate=DateTime.Parse("1997-09-18")},
                new Client{ClientID=2,Name="Berari Raul",BirthDate=DateTime.Parse("1998-05-25")},
                new Client{ClientID=3,Name="Gherasim Mihaela",BirthDate=DateTime.Parse("1996-05-15")},
                new Client{ClientID=4,Name="Simion Gabriel",BirthDate=DateTime.Parse("1995-02-25")}
            };

            foreach (Client c in clients)
            {
                context.Clients.Add(c);
            }
            context.SaveChanges();
            var orders = new Order[]
            {
                new Order{ProductID=1,ClientID=3},
                new Order{ProductID=3,ClientID=4},
                new Order{ProductID=1,ClientID=1},
                new Order{ProductID=2,ClientID=2}
            };
            foreach (Order e in orders)
            {
                context.Orders.Add(e);
            }
            context.SaveChanges();
            var suppliers = new Supplier[]
                {
                    new Supplier{SupplierName="ZooPlus",Adress="Str. Randunicii, nr. 40, Oradea"},
                    new Supplier{SupplierName="Zoo Hobby",Adress="Str. Avram Iancu, nr. 12,Timisoara"},
                    new Supplier{SupplierName="Royal Play",Adress="Str. Plopilor, nr. 2, Bucuresti"},
                };
            foreach (Supplier s in suppliers)
            {
                context.Suppliers.Add(s);
            }
            context.SaveChanges();

            var suppliedproducts = new SuppliedProduct[]
            {
                new SuppliedProduct {ProductID = products.Single(c => c.Title == "PURINA PRO PLAN Nutrisavour Sterilised" ).ProductID,SupplierID = suppliers.Single(i => i.SupplierName =="ZooPlus").ID},
                new SuppliedProduct {ProductID = products.Single(c => c.Title == "Purina ONE Sterilcat cu somon" ).ProductID,SupplierID = suppliers.Single(i => i.SupplierName =="Zoo Hobby").ID},
                new SuppliedProduct {ProductID = products.Single(c => c.Title == "Royal Canin Pliculețe Caini Rase Mici" ).ProductID,SupplierID = suppliers.Single(i => i.SupplierName =="Royal Play").ID},
                new SuppliedProduct {ProductID = products.Single(c => c.Title == "PURINA PRO PLAN Medium Adult Sensitive Skin OPTIDERMA" ).ProductID,SupplierID = suppliers.Single(i => i.SupplierName == "ZooPlus").ID},
                new SuppliedProduct {ProductID = products.Single(c => c.Title == "Leo Jucarie undita pentru pisici" ).ProductID,SupplierID = suppliers.Single(i => i.SupplierName == "ZooPlus").ID},
                new SuppliedProduct {ProductID = products.Single(c => c.Title == "Set jucării mingiuțe & șoricei pentru pisici" ).ProductID, SupplierID = suppliers.Single(i => i.SupplierName == "Zoo Hobby").ID},
            };

            foreach (SuppliedProduct sp in suppliedproducts)
            {
                context.SuppliedProducts.Add(sp);
            }
            context.SaveChanges();
        }
    }
    }

