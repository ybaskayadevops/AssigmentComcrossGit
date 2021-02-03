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

    [RuleCriteria("", DefaultContexts.Save, "Comment.Length> 5000",
   "Comment Length should bigger then 5000", SkipNullOrEmptyValues = false)]
    public class Comments : XPObject
    {
        public Comments(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        private Task _task;
        private string _comment;
        private string _commentBy;
        private DateTime? _commentOn = null;

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
        public string Comment
        {
            get
            {
                return _comment;
            }

            set
            {
                SetPropertyValue("Comment", ref _comment, value);
            }


        }



        [RuleRequiredField]
        public string CommentBy
        {
            get
            {
                return _commentBy;
            }

            set
            {
                SetPropertyValue("CommentBy", ref _commentBy, value);
            }
        }

        [RuleRequiredField]
        public DateTime CommentOn
        {
            get
            {
                 return _commentOn.HasValue ? this._commentOn.Value : DateTime.Now; 
            }

            set
            {
                SetPropertyValue("CommentOn", ref _commentOn, value);
            }
        }




    }
}