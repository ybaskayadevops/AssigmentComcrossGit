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
    public class Status : XPObject
    { 
        public Status(Session session)
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
        public XPCollection<Task> Tasks
        {
            get
            {
                return GetCollection<Task>(nameof(Tasks));
            }
        }

        [Association]
        public XPCollection<Projects> Projects
        {
            get
            {
                return GetCollection<Projects>(nameof(Projects));
            }
        }

    }
}