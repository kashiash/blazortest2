﻿using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace Solution1.Module.BusinessObjects.Slowniki
{

    public partial class car_option_value
    {
        public car_option_value(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
