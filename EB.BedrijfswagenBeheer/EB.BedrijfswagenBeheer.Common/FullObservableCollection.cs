using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EB.BedrijfswagenBeheer.Common
{
	public class FullObservableCollection<T> : ObservableCollection<T> where T : INotifyPropertyChanged
	{
		public FullObservableCollection()
		{
			this.CollectionChanged += ObservableCollection_CollectionChanged;
		}

		private void ObservableCollection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			if (e.NewItems != null)
			{
				foreach (T item in e.NewItems)
				{
					item.PropertyChanged += Item_PropertyChanged;
				}
			}
			if (e.OldItems != null)
			{
				foreach (T item in e.OldItems)
				{
					item.PropertyChanged -= Item_PropertyChanged;
				}
			}
		}

		private void Item_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			this.OnCollectionChanged(new System.Collections.Specialized.NotifyCollectionChangedEventArgs(System.Collections.Specialized.NotifyCollectionChangedAction.Reset));
		}
	}
}
