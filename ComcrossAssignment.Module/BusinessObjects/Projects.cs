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
    public class Projects : XPObject
    {
        public Projects(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        private string _projectName;
        private Company _customer;
        private Employee _projectOwner;
        private string _counterPrefix;
        private DateTime _startDate;
        private DateTime _endDate;
        private Status _defaultStatus;

        [RuleRequiredField]
        public string ProjectName
        {
            get
            {
                return _projectName;
            }

            set
            {
                SetPropertyValue("ProjectName", ref _projectName, value);
            }
        }


        [Association]
        [RuleRequiredField]
        public Company Customer
        {
            get
            {
                return _customer;
            }
            set
            {
                SetPropertyValue(nameof(Customer), ref _customer, value);
            }
        }


        [Association]
        [RuleRequiredField]
        public Employee ProjectOwner
        {
            get
            {
                return _projectOwner;
            }
            set
            {
                SetPropertyValue(nameof(ProjectOwner), ref _projectOwner, value);
            }
        }

        [RuleRequiredField]
        public string CounterPrefix
        {
            get
            {
                return _counterPrefix;
            }

            set
            {
                SetPropertyValue("CounterPrefix", ref _counterPrefix, value);
            }
        }

        [RuleRequiredField]
        public DateTime StartDate
        {
            get
            {
                return _startDate;
            }

            set
            {
                SetPropertyValue("StartDate", ref _startDate, value);
            }
        }

        public DateTime EndDate
        {
            get
            {
                return _endDate;
            }

            set
            {
                SetPropertyValue("EndDate", ref _endDate, value);
            }
        }


        [Association]
        [RuleRequiredField]
        public Status DefaultStatus
        {
            get
            {
                return _defaultStatus;
            }
            set
            {
                SetPropertyValue(nameof(DefaultStatus), ref _defaultStatus, value);
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

    }
}