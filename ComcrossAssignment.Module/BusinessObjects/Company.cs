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
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Company : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Company(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        private string _name;
        private string _address;
        private string _postcode;
        private string _city;
        private string _state;
        private string _country;
        private string _vatid;
        private string _www;
        private string _email;

        [RuleRequiredField]
        [RuleUniqueValue]
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

        [Size(1000)]
        public string Address
        {
            get
            {
                return _address;
            }

            set
            {
                SetPropertyValue("Address", ref _address, value);
            }
        }


        public string Postcode
        {
            get
            {
                return _postcode;
            }

            set
            {
                SetPropertyValue("Postcode", ref _postcode, value);
            }
        }

        public string City
        {
            get
            {
                return _city;
            }

            set
            {
                SetPropertyValue("City", ref _city, value);
            }
        }

        public string State
        {
            get
            {
                return _state;
            }

            set
            {
                SetPropertyValue("State", ref _state, value);
            }
        }



        public string Country
        {
            get
            {
                return _country;
            }

            set
            {
                SetPropertyValue("Country", ref _country, value);
            }
        }


        [RuleRequiredField]
        [RuleUniqueValue]
        public string Vatid
        {
            get
            {
                return _vatid;
            }

            set
            {
                SetPropertyValue("Vatid", ref _vatid, value);
            }
        }

        public string WWWW
        {
            get
            {
                return _www;
            }

            set
            {
                SetPropertyValue("WWW", ref _www, value);
            }
        }

        [RuleRequiredField]
        [RuleUniqueValue]
        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                SetPropertyValue("Email", ref _email, value);
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


        [Association]
        public XPCollection<Employee> Employees
        {
            get
            {
                return GetCollection<Employee>(nameof(Employees));
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
        public XPCollection<OwnCompany> OwnCompany
        {
            get
            {
                return GetCollection<OwnCompany>(nameof(OwnCompany));
            }
        }


    }
}