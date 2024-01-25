using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG_MAUI_todo_app
{
    public class TodoItems
    {

        private string _item;
        private bool _isDone;
        private DateTime _date;

        public TodoItems(string title, DateTime date, bool isDone) 
        {
            this._item = title;
            this._date = date;
            this._isDone = isDone;
        }
        public string Title
        {
            get { return _item; }
            set {  _item = value; }
        }
        public DateTime Date
        {
            get { return _date; }
            set {  this._date = value; }
        }
        public bool IsDone
        {
            get { return _isDone; }
            set { this._isDone = value; }
        }
    }

}
