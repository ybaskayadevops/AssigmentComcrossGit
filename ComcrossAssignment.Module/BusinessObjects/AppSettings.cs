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
    [RuleObjectExists("AnotherSingletonExists", DefaultContexts.Save, "True", InvertResult = true,
    CustomMessageTemplate = "Another Singleton already exists.")]
    [RuleCriteria("CannotDeleteSingleton", DefaultContexts.Delete, "False",
    CustomMessageTemplate = "Cannot delete Singleton.")]
    public class AppSettings : BaseObject
    {
        public AppSettings(Session session) : base(session) { }

        private string _name;
        private string _description;


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

        


        [RuleRequiredField]
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