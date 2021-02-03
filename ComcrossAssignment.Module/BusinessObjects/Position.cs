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
     public class Position : XPObject
    { 
        public Position(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();           
        }

        private string _name;


        [RuleRequiredField]
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                SetPropertyValue("Name", ref _name, value);
            }
        }

        [Association]
        public XPCollection<Employee> Employees
        {
            get
            {
                return GetCollection<Employee>(nameof(Employees));
            }
        }
    }
}