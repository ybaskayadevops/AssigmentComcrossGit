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
using DevExpress.ExpressApp.Security;
using DevExpress.Persistent.Base.Security;

namespace ComcrossAssignment.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class Employee : XPObject, 
        ISecurityUser, IAuthenticationStandardUser, IAuthenticationActiveDirectoryUser, ISecurityUserWithRoles,
        IPermissionPolicyUser
    { 
        public Employee(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();            
        }

        private Company _company;
        private String _firstName;
        private string _lastName;
        private Department _department;
        private Position _position;
        private string _email;
        private string _gsm;


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

        
        [RuleRequiredField("RuleID_FirstNameIsRequired", DefaultContexts.Save, "A FirstName must be specified.")]
        public String FirstName
        {
            get
            {
                return _firstName;
            }

            set
            {
                SetPropertyValue("FirstName", ref _firstName, value);
            }
        }

        [RuleRequiredField(DefaultContexts.Save)]
        public string LastName
        {
            get
            {
                return _lastName;
            }

            set
            {
                SetPropertyValue("LastName", ref _lastName, value);
            }
        }

        [NonPersistent]
        public string FullName
        {
            get
            {
                return String.Format("{0} {1}",FirstName ?? "",LastName ?? "");
            }
        }

        [Association]
        public Department Department
        {
            get
            {
                return _department;
            }
            set
            {
                SetPropertyValue(nameof(Department), ref _department, value);
            }
        }


        [Association]
        public Position Position
        {
            get
            {
                return _position;
            }
            set
            {
                SetPropertyValue(nameof(Position), ref _position, value);
            }
        }

        [RuleRequiredField]
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

        [RuleRequiredField]
        public string GSM
        {
            get
            {
                return _gsm;
            }

            set
            {
                SetPropertyValue("GSM", ref _gsm, value);
            }
        }

        

        [Association("Employee-Task", UseAssociationNameAsIntermediateTableName = true)]
        public XPCollection<Task> Tasks
        {
            get
            {
                return GetCollection<Task>(nameof(Tasks));
            }
        }


        [Association("CustomerEmployee-Task", UseAssociationNameAsIntermediateTableName = true)]
        public XPCollection<Task> CustomerTasks
        {
            get
            {
                return GetCollection<Task>(nameof(CustomerTasks));
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


        


        #region ISecurityUser Members
        private bool isActive = true;
        public bool IsActive
        {
            get { return isActive; }
            set { SetPropertyValue(nameof(IsActive), ref isActive, value); }
        }
        private string userName = String.Empty;
        [RuleRequiredField("EmployeeUserNameRequired", DefaultContexts.Save)]
        [RuleUniqueValue("EmployeeUserNameIsUnique", DefaultContexts.Save,
            "The login with the entered user name was already registered within the system.")]
        public string UserName
        {
            get { return userName; }
            set { SetPropertyValue(nameof(UserName), ref userName, value); }
        }
        #endregion

        #region IAuthenticationStandardUser Members
        private bool changePasswordOnFirstLogon;
        public bool ChangePasswordOnFirstLogon
        {
            get { return changePasswordOnFirstLogon; }
            set
            {
                SetPropertyValue(nameof(ChangePasswordOnFirstLogon), ref changePasswordOnFirstLogon, value);
            }
        }
        private string storedPassword;
        [Browsable(true), Size(SizeAttribute.Unlimited), Persistent, SecurityBrowsable]
        protected string StoredPassword
        {
            get { return storedPassword; }
            set { storedPassword = value; }
        }
        public bool ComparePassword(string password)
        {
            return PasswordCryptographer.VerifyHashedPasswordDelegate(this.storedPassword, password);
        }
        public void SetPassword(string password)
        {
            this.storedPassword = PasswordCryptographer.HashPasswordDelegate(password);
            OnChanged(nameof(StoredPassword));
        }
        #endregion


        #region ISecurityUserWithRoles Members
        IList<ISecurityRole> ISecurityUserWithRoles.Roles
        {
            get
            {
                IList<ISecurityRole> result = new List<ISecurityRole>();
                foreach (EmployeeRole role in EmployeeRoles)
                {
                    result.Add(role);
                }
                return result;
            }
        }
        #endregion

        [Association("Employees-EmployeeRoles")]
        [RuleRequiredField("EmployeeRoleIsRequired", DefaultContexts.Save,
        TargetCriteria = "IsActive",
        CustomMessageTemplate = "An active employee must have at least one role assigned")]
        public XPCollection<EmployeeRole> EmployeeRoles
        {
            get
            {
                return GetCollection<EmployeeRole>(nameof(EmployeeRoles));
            }
        }

        #region IPermissionPolicyUser Members
        IEnumerable<IPermissionPolicyRole> IPermissionPolicyUser.Roles
        {
            get { return EmployeeRoles.OfType<IPermissionPolicyRole>(); }
        }
        #endregion

      


    }
}