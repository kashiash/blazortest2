﻿using DevExpress.Xpo;
using Solution1.Module.BusinessObjects.Slowniki;
using FleetmanCommon;
using kashiash.utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution1.Module.Utils
{
    public class Car2dbOptionImporter : CSVImporter
    {
        UnitOfWork unitOfWork;
        Session _session;
        CultureInfo culture = CultureInfo.InvariantCulture;

  

        public void Import(string FileName, bool deleteFile = false)
        {

            if (File.Exists(FileName))
            {
                 watch = new System.Diagnostics.Stopwatch();

                watch.Start();

                ImportujPlik(FileName, ',');
                if (unitOfWork != null)
                {
                    unitOfWork.CommitChanges();
                }




                if (deleteFile)
                {
                    File.Delete(FileName);
                }
            }
        }



        public Car2dbOptionImporter()
        {
            _session = new Session() { ConnectionString = AppSettings.ConnectionString };


        }

        public override void ImportRow(CsvRow csv)
        {
            if (unitOfWork == null)
            {
                unitOfWork = new UnitOfWork(_session.DataLayer);
            }
            // throw new NotImplementedException();
            var rec = unitOfWork.GetObjectByKey<car_option>(csv[0].ToInt());
            if (rec == null)
            {
                rec = new car_option(unitOfWork);
            }


            //'id_car_option','name','id_parent','date_create','date_update','id_car_type'
            //'1','Komfort',NULL,'1464484023','1518975461','1'

            int i = 0;
            rec.id_car_option = csv[i].ToInt(); i++;
            rec.name = csv[i].Truncate(100); i++;
            rec.id_parent = csv[i].ToInt(); i++;



            rec.date_create = csv[i].ToInt(); i++;
            rec.date_update = csv[i].ToInt();i++;
            rec.id_car_type = unitOfWork.GetObjectByKey<car_type>(csv[i].ToInt()); i++;
            rec.Save();

          //  Console.WriteLine($"   {rec.value1}");
            if (rowCnt % 100000 == 0)
            {
                Console.WriteLine($"recs: {rowCnt} Execution Time: {watch.ElapsedMilliseconds} ms");
                unitOfWork.CommitChanges();
                unitOfWork.Dispose();
                unitOfWork = null;

               

                Console.WriteLine($"After commit Execution Time: {watch.ElapsedMilliseconds} ms");
                //Console.ReadLine();
                //watch.Restart();

            }
        }

    }
}
