using System;
using System.Linq;
using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.Security;
using ComcrossAssignment.Module.BusinessObjects;

namespace ComcrossAssignment.Module.DatabaseUpdate
{
    // For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Updating.ModuleUpdater
    public class Updater : ModuleUpdater
    {
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) :
            base(objectSpace, currentDBVersion)
        {
        }
        public override void UpdateDatabaseAfterUpdateSchema()
        {
            base.UpdateDatabaseAfterUpdateSchema();

            if (ObjectSpace.GetObjectsCount(typeof(AppSettings), null) == 0)
            {
                ObjectSpace.CreateObject<AppSettings>();
            }

            EmployeeRole adminEmployeeRole = ObjectSpace.
                FindObject<EmployeeRole>(new BinaryOperator("Name", SecurityStrategy.AdministratorRoleName));
            if (adminEmployeeRole == null)
            {
                adminEmployeeRole = ObjectSpace.CreateObject<EmployeeRole>();
                adminEmployeeRole.Name = SecurityStrategy.AdministratorRoleName;
                adminEmployeeRole.IsAdministrative = true;
                adminEmployeeRole.Save();
            }
            Employee adminEmployee = ObjectSpace.FindObject<Employee>(
                new BinaryOperator("UserName", "Administrator"));
            if (adminEmployee == null)
            {
                adminEmployee = ObjectSpace.CreateObject<Employee>();
                adminEmployee.UserName = "Administrator";
                adminEmployee.SetPassword("");
                adminEmployee.EmployeeRoles.Add(adminEmployeeRole);
            }
            //adminEmployee.SetPassword("");
            ObjectSpace.CommitChanges();
        }
        public override void UpdateDatabaseBeforeUpdateSchema()
        {
            base.UpdateDatabaseBeforeUpdateSchema();
            //if(CurrentDBVersion < new Version("1.1.0.0") && CurrentDBVersion > new Version("0.0.0.0")) {
            //    RenameColumn("DomainObject1Table", "OldColumnName", "NewColumnName");
            //}
        }
    }
}
