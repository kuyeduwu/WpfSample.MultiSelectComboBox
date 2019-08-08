using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFComboBoxMultiSelect.Models.Business
{
    public class Book
    {
        private string _name { get; set; }

        public string Name => this._name;

        public Book(string name)
        {
            this._name = name;
        }
    }
}
