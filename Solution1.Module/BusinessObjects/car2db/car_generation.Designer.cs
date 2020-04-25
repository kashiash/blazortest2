﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;

namespace Solution1.Module.BusinessObjects.Slowniki
{

    public partial class car_generation : XPLiteObject
    {
        int fid_car_generation;
        [Key(false)]
        public int id_car_generation
        {
            get { return fid_car_generation; }
            set { SetPropertyValue<int>("id_car_generation", ref fid_car_generation, value); }
        }
        string fname;
        [Size(255)]
        [VisibleInLookupListView(true)]
        [XafDisplayName("Generacja")]
        public string name
        {
            get { return fname; }
            set { SetPropertyValue<string>("name", ref fname, value); }
        }
        car_model fid_car_model;
        [Association(@"car_generationReferencescar_model")]
        public car_model id_car_model
        {
            get { return fid_car_model; }
            set { SetPropertyValue<car_model>("id_car_model", ref fid_car_model, value); }
        }
        string fyear_begin;
        [Size(255)]
        [XafDisplayName("Od roku")]
        [VisibleInLookupListView(true)]
        public string year_begin
        {
            get { return fyear_begin; }
            set { SetPropertyValue<string>("year_begin", ref fyear_begin, value); }
        }
        string fyear_end;
        [Size(255)]
        [XafDisplayName("Do roku")]
        [VisibleInLookupListView(true)]
        public string year_end
        {
            get { return fyear_end; }
            set { SetPropertyValue<string>("year_end", ref fyear_end, value); }
        }
        int fdate_create;
        [Browsable(false)]
        public int date_create
        {
            get { return fdate_create; }
            set { SetPropertyValue<int>("date_create", ref fdate_create, value); }
        }
        int fdate_update;

        [Browsable(false)]
        public int date_update
        {
            get { return fdate_update; }
            set { SetPropertyValue<int>("date_update", ref fdate_update, value); }
        }
        car_type fid_car_type;
        [Association(@"car_generationReferencescar_type")]
        public car_type id_car_type
        {
            get { return fid_car_type; }
            set { SetPropertyValue<car_type>("id_car_type", ref fid_car_type, value); }
        }
        [Association(@"car_serieReferencescar_generation")]
        public XPCollection<car_serie> car_series { get { return GetCollection<car_serie>("car_series"); } }
    }

}
