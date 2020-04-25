using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;

namespace Solution1.Module.BusinessObjects.Slowniki
{

    [XafDisplayName("Wyposażenie")]
    [NavigationItem("Słowniki")]
    [DefaultClassOptions]
    [System.ComponentModel.DefaultProperty("name")]
    public partial class car_equipment
    {
        public car_equipment(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
