using Bogus;
using Demo1.Module.BusinessObjects;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Solution1.Module.BusinessObjects
{
   public static class DataGenerator
    {



        public static void WygenerujKlientow(IObjectSpace ObjectSpace)
        {
            var cusFaker = new Faker<Klient>("pl")
              .CustomInstantiator(f => ObjectSpace.CreateObject<Klient>())
              .RuleFor(o => o.Telefon, f => f.Person.Phone)
              .RuleFor(o => o.Skrot, f => f.Company.CompanyName())
              .RuleFor(o => o.Nazwa, f => f.Company.CompanyName())
              .RuleFor(o => o.Email, (f, u) => f.Internet.Email())
              .RuleFor(o => o.Miejscowosc, f => f.Address.City())
              .RuleFor(o => o.KodPocztowy, f => f.Address.ZipCode())
              .RuleFor(o => o.Ulica, f => f.Address.StreetName());
            var customers = cusFaker.Generate(1000);
            ObjectSpace.CommitChanges();

            var conFaker = new Faker<Kontakt>("pl")
            .CustomInstantiator(f => ObjectSpace.CreateObject<Kontakt>())
            .RuleFor(o => o.Imie, f => f.Person.FirstName)
            .RuleFor(o => o.Nazwisko, f => f.Person.LastName)
            .RuleFor(o => o.Klient, f => f.PickRandom(cusFaker))
            .RuleFor(o => o.Email, (f, u) => f.Internet.Email())
            .RuleFor(o => o.Telefon, f => f.Person.Phone);

            var contacts = conFaker.Generate(1000);

            var stawki = new List<StawkaVAT>();
            stawki.Add(NowaStawka( ObjectSpace,"23%", 23M));
            stawki.Add(NowaStawka(ObjectSpace, "0%", 0M));
            stawki.Add(NowaStawka(ObjectSpace, "7%", 7M));
            stawki.Add(NowaStawka(ObjectSpace, "ZW", 0M));



            var prodFaker = new Faker<Produkt>("pl")
             .CustomInstantiator(f => ObjectSpace.CreateObject<Produkt>())
             .RuleFor(o => o.Nazwa, f => f.Commerce.ProductName())
             .RuleFor(o => o.StawkaVAT, f => f.PickRandom(stawki))
             .RuleFor(o => o.Cena, f => f.Random.Decimal(0.01M, 1000M));

            var products = prodFaker.Generate(100);

            ObjectSpace.CommitChanges();

            WygenerujFaktury(ObjectSpace, 1000, customers, products);
        }



        private static StawkaVAT NowaStawka(IObjectSpace ObjectSpace,string symbol, decimal wartosc)
        {

            var stawka = ObjectSpace.FindObject<StawkaVAT>(new BinaryOperator("Symbol", symbol));
            if (stawka == null)
            {
                stawka = ObjectSpace.CreateObject<StawkaVAT>();
                stawka.Symbol = symbol;
                stawka.Stawka = wartosc;

            }
            return stawka;
        }

        private static void WygenerujFaktury(IObjectSpace ObjectSpace,int liczbaFaktur, IList<Klient> customers, IList<Produkt> products)
        {
            if (customers is null)
            {
                customers = ObjectSpace.GetObjectsQuery<Klient>().ToList();
            }

            var orderFaker = new Faker<Faktura>("pl")
            .CustomInstantiator(f => ObjectSpace.CreateObject<Faktura>())
            .RuleFor(o => o.NumerFaktury, f => f.Random.Int().ToString())
            .RuleFor(o => o.DataFaktury, f => f.Date.Past(2))
            .RuleFor(o => o.DataSprzedazy, f => f.Date.Past(20))
            .RuleFor(o => o.Klient, f => f.PickRandom(customers));
            var orders = orderFaker.Generate(liczbaFaktur);
            if (products == null)
            {
                products = ObjectSpace.GetObjectsQuery<Produkt>().ToList();
            }

            var itemsFaker = new Faker<PozycjaFaktury>()
            .CustomInstantiator(f => ObjectSpace.CreateObject<PozycjaFaktury>())
            .RuleFor(o => o.Faktura, f => f.PickRandom(orders))
            .RuleFor(o => o.Produkt, f => f.PickRandom(products))

            .RuleFor(o => o.Ilosc, f => f.Random.Decimal(0.01M, 100M));

            var items = itemsFaker.Generate(liczbaFaktur * 10);
        }

      public static   void DodajKraje(IObjectSpace ObjectSpace)
        {

            foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.FrameworkCultures))

            {

                RegionInfo ri = null;

                try

                {
                    ri = new RegionInfo(ci.Name);
                }

                catch

                {
                    continue;
                }

                var a = ri.EnglishName;
                var a1 = ri.NativeName;
                var a2 = ri.ThreeLetterISORegionName;
                var a3 = ri.CurrencyEnglishName;
                var a4 = ri.CurrencyNativeName;
                var a5 = ri.CurrencySymbol;
                var a6 = ri.ISOCurrencySymbol;

                var waluta = ObjectSpace.FindObject<Waluta>(new BinaryOperator("Symbol", ri.ISOCurrencySymbol));
                if (waluta == null)
                {
                    waluta = ObjectSpace.CreateObject<Waluta>();
                    waluta.Symbol = ri.ISOCurrencySymbol;
                    waluta.Nazwa = ri.CurrencyEnglishName;
                    waluta.LokalnaNazwa = ri.CurrencyNativeName;
                    waluta.LokalnySymbol = ri.CurrencySymbol;
                }

                var kraj = ObjectSpace.FindObject<Kraj>(new BinaryOperator("Symbol", ri.ThreeLetterISORegionName));
                if (kraj == null)
                {
                    kraj = ObjectSpace.CreateObject<Kraj>();
                    kraj.Symbol = ri.ThreeLetterISORegionName;
                    kraj.Nazwa = ri.EnglishName;
                    kraj.LokalnySymbol = ri.TwoLetterISORegionName;
                    kraj.LokalnaNazwa = ri.NativeName;
                    kraj.GeoId = ri.GeoId;
                    kraj.Waluta = waluta;
                    kraj.IsMetric = ri.IsMetric;

                }
                waluta.Kraj = kraj;
            }
        }
    }
}
