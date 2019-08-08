using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFComboBoxMultiSelect.Models.Common;

namespace WPFComboBoxMultiSelect.ViewModels
{
    public class BookExtCollection : ObservableObject
    {
        private string _selectedText;
        private ObservableCollection<BookExt> _books;

        public string SelectedText
        {
            get
            {
                return this._selectedText;
            }
            set
            {
                this._selectedText = value;
                RaisePropertyChanged("SelectedText");
            }
        }

        public ObservableCollection<BookExt> BookExts
        {
            get
            {
                if (this._books == null)
                {
                    _books = new ObservableCollection<BookExt>();
                    _books.CollectionChanged += (sender, e) =>
                    {
                        if (e.OldItems != null)
                        {
                            foreach (var item in e.OldItems)
                            {
                                (item as BookExt).PropertyChanged -= ItemPropertyChanged;
                            }
                        }
                        if (e.NewItems != null)
                        {
                            foreach (var item in e.NewItems)
                            {
                                (item as BookExt).PropertyChanged += ItemPropertyChanged;
                            }
                        }
                    };
                }

                return _books;
            }
        }

        private void ItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsSelected")
            {
                var bookExt = sender as BookExt;

                if (bookExt != null)
                {
                    this.SelectedText = string.Join("; ", 
                        BookExts.Where(r => r.IsSelected).Select(r=>r.Book.Name).ToArray()
                        );
                }
            }
        }
    }
}
