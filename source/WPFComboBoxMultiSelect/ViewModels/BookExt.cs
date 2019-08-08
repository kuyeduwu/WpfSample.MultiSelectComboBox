using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFComboBoxMultiSelect.Models.Business;
using WPFComboBoxMultiSelect.Models.Common;

namespace WPFComboBoxMultiSelect.ViewModels
{
    public class BookExt : ObservableObject
    {
        private bool _isSelected;

        public Book Book { get; private set; }
        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                _isSelected = value;
                RaisePropertyChanged("IsSelected");
            }
        }

        public BookExt(Book book)
        {
            Book = book;
        }
    }
}
