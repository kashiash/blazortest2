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
namespace Solution1.Module.BusinessObjects.Slowniki
{

    public partial class car_specification_value : XPLiteObject
    {
        int fid_car_specification_value;
        [Key]
        public int id_car_specification_value
        {
            get { return fid_car_specification_value; }
            set { SetPropertyValue<int>("id_car_specification_value", ref fid_car_specification_value, value); }
        }
        string fvalue1;
        [Size(255)]
        [Persistent(@"value")]
        public string value1
        {
            get { return fvalue1; }
            set { SetPropertyValue<string>("value1", ref fvalue1, value); }
        }
        string funit;
        [Size(255)]
        public string unit
        {
            get { return funit; }
            set { SetPropertyValue<string>("unit", ref funit, value); }
        }
        car_specification fid_car_specification;
        [Association(@"car_specification_valueReferencescar_specification")]
        public car_specification id_car_specification
        {
            get { return fid_car_specification; }
            set { SetPropertyValue<car_specification>("id_car_specification", ref fid_car_specification, value); }
        }
        car_trim fid_car_trim;
        [Association(@"car_specification_valueReferencescar_trim")]
        public car_trim id_car_trim
        {
            get { return fid_car_trim; }
            set { SetPropertyValue<car_trim>("id_car_trim", ref fid_car_trim, value); }
        }
        int fdate_create;
        public int date_create
        {
            get { return fdate_create; }
            set { SetPropertyValue<int>("date_create", ref fdate_create, value); }
        }
        int fdate_update;
        public int date_update
        {
            get { return fdate_update; }
            set { SetPropertyValue<int>("date_update", ref fdate_update, value); }
        }
        car_type fid_car_type;
        [Association(@"car_specification_valueReferencescar_type")]
        public car_type id_car_type
        {
            get { return fid_car_type; }
            set { SetPropertyValue<car_type>("id_car_type", ref fid_car_type, value); }
        }
    }

}
