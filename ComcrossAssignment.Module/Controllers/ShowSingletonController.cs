using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComcrossAssignment.Module.BusinessObjects;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;

namespace ComcrossAssignment.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class ShowSingletonController : WindowController
    {
        public ShowSingletonController()
        {
            this.TargetWindowType = WindowType.Main;
            PopupWindowShowAction showSingletonAction =
                new PopupWindowShowAction(this, "ShowSingleton", PredefinedCategory.View);
            showSingletonAction.CustomizePopupWindowParams += showSingletonAction_CustomizePopupWindowParams;
        }
        private void showSingletonAction_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            IObjectSpace objectSpace = Application.CreateObjectSpace(typeof(AppSettings));
            DetailView detailView = Application.CreateDetailView(objectSpace, objectSpace.GetObjects<AppSettings>()[0]);
            detailView.ViewEditMode = ViewEditMode.Edit;
            e.View = detailView;
        }
    }

}
