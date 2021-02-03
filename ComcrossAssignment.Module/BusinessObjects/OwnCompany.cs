using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace ComcrossAssignment.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class OwnCompany : XPObject
    { 
        public OwnCompany(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        private Company _company;

        [Association]
        [RuleRequiredField]
        public Company Company
        {
            get
            {
                return _company;
            }
            set
            {
                SetPropertyValue(nameof(Company), ref _company, value);
            }
        }

    }
}