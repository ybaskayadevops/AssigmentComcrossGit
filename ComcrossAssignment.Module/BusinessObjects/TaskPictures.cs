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
    public class TaskPictures : XPObject
    { 
        public TaskPictures(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        private Task _task;
        private MediaDataObject _image;
        private string _name;
        private string _description;


        [Association]
        public Task Task
        {
            get
            {
                return _task;
            }
            set
            {
                SetPropertyValue(nameof(Task), ref _task, value);
            }
        }

        [RuleRequiredField]
        public MediaDataObject Image
        {
            get
            {
                return _image;
            }
            set
            {
                SetPropertyValue(nameof(Image), ref _image, value);
            }
        }


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

        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                SetPropertyValue("Description", ref _description, value);
            }
        }


    }
}