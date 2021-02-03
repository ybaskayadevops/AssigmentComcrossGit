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
    public class Task : XPObject
    { 
        public Task(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        private Projects _project;
        private Company _company;
        private Employee _employee;
        private Status _status;
        private Employee _customerEmployee;
        private int _numericID;


        [Association]
        public Projects Project
        {
            get
            {
                return _project;
            }
            set
            {
                SetPropertyValue(nameof(Project), ref _project, value);
            }
        }


        [Association]
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


        [Association("Employee-Task", UseAssociationNameAsIntermediateTableName = true)]
        [Persistent("Employee")]
        public Employee Employee
        {
            get
            {
                return _employee;
            }
            set
            {
                SetPropertyValue(nameof(Employee), ref _employee, value);
            }
        }



        [Association]
        public Status Status
        {
            get
            {
                return _status;
            }
            set
            {
                SetPropertyValue(nameof(Status), ref _status, value);
            }
        }


        [Association("CustomerEmployee-Task", UseAssociationNameAsIntermediateTableName = true)]
        [Persistent("CustomerEmployee")]
        public Employee CustomerEmployee
        {
            get
            {
                return _customerEmployee;
            }
            set
            {
                SetPropertyValue(nameof(CustomerEmployee), ref _customerEmployee, value);
            }
        }

        public int NumericID
        {
            get
            {
                return _numericID;
            }
            set
            {
                SetPropertyValue(nameof(NumericID), ref _numericID, value);
            }
        }

        [Association]
        public XPCollection<TaskFiles> TaskFiles
        {
            get
            {
                return GetCollection<TaskFiles>(nameof(TaskFiles));
            }
        }

        [Association]
        public XPCollection<TaskPictures> TaskPictures
        {
            get
            {
                return GetCollection<TaskPictures>(nameof(TaskPictures));
            }
        }

        [Association]
        public XPCollection<Comments> Comments
        {
            get
            {
                return GetCollection<Comments>(nameof(Comments));
            }
        }
    }
}